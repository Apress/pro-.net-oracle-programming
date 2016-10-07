using System;
using System.Data;
using System.Diagnostics;
using System.Data.OracleClient;

namespace ExceptionApproach
{
  /// <summary>
  /// Summary description for Class1.
  /// </summary>
  class Class1
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]

    static void Main(string[] args)
    {
      Class1 theClass = new Class1();

      // create a connection string using our standard user with
      // an incorrect password. this will throw an error
      string c1 = "User Id=oranetuser;Password=badpass;Data Source=oranet";
      OracleConnection conn_1 = new OracleConnection(c1);

      // create a connection string using our standard user and
      // standard tns alias
      string c2 = "User Id=oranetuser;Password=demo;Data Source=oranet";
      OracleConnection conn_2 = new OracleConnection(c2);

      string exceptionInfo = "";

      // try to open a connection with an incorrect password
      // this will fail, so log to the Application log
      try
      {
        conn_1.Open();
      }
      catch (OracleException ex)
      {
        exceptionInfo = "Caught OracleException: " + ex.Message + "\r\n";
        exceptionInfo += "Location: Main method, conn_1.open event\r\n";
        
        theClass.writeAppLog(exceptionInfo);

        Console.WriteLine(exceptionInfo);
      }
      finally
      {
        if (conn_1.State == ConnectionState.Open)
        {
          conn_1.Close();
        }
      }

      conn_1.Dispose();

      // try to open a connection with the correct connect
      // information. this should not fail.
      try
      {
        conn_2.Open();
      }
      catch (OracleException ex)
      {
        exceptionInfo = "Caught OracleException: " + ex.Message + "\r\n";
        exceptionInfo += "Location: Main method, conn_2.open event\r\n";
        
        theClass.writeAppLog(exceptionInfo);

        Console.WriteLine(exceptionInfo);
      }

      // execute our test if we have an open connection
      if (conn_2.State == ConnectionState.Open)
      {
        // the column c is defined as number(4), so this
        // will be an error. insert this into our table
        // rather than into the Application log.
        string l_sql = "insert into exception_test(c) values (10001)";
        OracleCommand oraCmd = new OracleCommand(l_sql,conn_2);

        try
        {
          oraCmd.ExecuteNonQuery();
        }
        catch (OracleException ex)
        {
          exceptionInfo = "Caught OracleException: " + ex.Message + "\r\n";
          exceptionInfo += "Location: Main method, insert into exception_test event\r\n";
          exceptionInfo += "Connect: " + conn_2.ConnectionString;

          theClass.writeAppTable(exceptionInfo, conn_2);

          Console.WriteLine(exceptionInfo);
        }
      }

      if (conn_2.State == ConnectionState.Open)
      {
        conn_2.Close();
      }

      conn_2.Dispose();
    }

    void writeAppLog(string p_message)
    {
      // Open the Application log on the local machine
      EventLog appLog = new EventLog("Application");

      // create our event source if it does not exist
      if (!EventLog.SourceExists("ExceptionApproach"))
      {
        EventLog.CreateEventSource("ExceptionApproach", "Application");
      }

      // set the source as our source
      appLog.Source = "ExceptionApproach";

      // write entry to application log
      appLog.WriteEntry(p_message, EventLogEntryType.Error);

      // explicitly close and dispose the appLog      
      appLog.Close();
      appLog.Dispose();
    }

    void writeAppTable(string p_message, OracleConnection p_conn)
    {
      // this is the sql that we will use to insert a
      // row into the app_exceptions table.
      // we use a bind variable for the message column.
      // sysdate and user functions supplied by the database
      // they get the current date/time and username respectively.
      string l_sql = "insert into app_exceptions " +
        "(exception_date, username, exception_message) " +
        "values (sysdate, user, :1)";

      // bind the message passed as a parameter
      // we defined the column in the table as varchar2(512)
      // so ensure we use a message that is no greater than
      // 512 bytes in length
      OracleParameter oraParam = new OracleParameter();
      oraParam.DbType = DbType.AnsiString;
      oraParam.Direction = ParameterDirection.Input;
      oraParam.ParameterName = "1";
      
      if (p_message.Length < 513)
      {
        oraParam.Value = p_message;
      }
      else
      {
        oraParam.Value = p_message.Substring(1,512);
      }

      // create the command object, add the bind parameter
      // and insert.
      OracleCommand oraCmd = new OracleCommand(l_sql,p_conn);

      oraCmd.Parameters.Add(oraParam);

      oraCmd.ExecuteNonQuery();

      // explicitly dispose our objects
      oraCmd.Dispose();
    }
  }
}
