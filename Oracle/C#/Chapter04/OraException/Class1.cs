using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace OraException
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

      theClass.oraException1();
      theClass.oraException2();
      theClass.oraException3();
    }

    void oraException1()
    {
      // create a connection string with an incorrect password
      // this is so an exception is thrown when the connection
      // is opened
      string c1 = "User Id=oranetuser;Password=badpass;Data Source=oranet";
      OracleConnection oraConn = new OracleConnection(c1);

      try
      {
        // This will throw an exception since we have
        // used an incorrect password
        oraConn.Open();
      }
      catch (OracleException ex)
      {
        // Write the properties to the console
        Console.WriteLine("Caught OracleException #1:");
        Console.WriteLine("  DataSource: " + ex.DataSource);
        Console.WriteLine("  Errors Count: " + ex.Errors.Count.ToString());
        Console.WriteLine("  Message: " + ex.Message);
        Console.WriteLine("  Number: " + ex.Number.ToString());
        Console.WriteLine("  Procedure: " + ex.Procedure);
        Console.WriteLine("  Source: " + ex.Source);
        Console.WriteLine();
      }
      finally
      {
        if (oraConn.State == ConnectionState.Open)
        {
          oraConn.Close();
        }
      }

      oraConn.Dispose();
    }

    void oraException2()
    {
      // create a connection string using our standard user and
      // standard tns alias
      string c1 = "User Id=oranetuser;Password=demo;Data Source=oranet";
      OracleConnection oraConn = new OracleConnection(c1);

      // this command will attempt to gather statistics on a table
      // that does not exist in our schema.  this will cause an
      // exception to be thrown.
      string l_sql = "begin " +
        "dbms_stats.gather_table_stats(" +
        "ownname=>'ORANETUSER',tabname=>'DOES_NOT_EXIST');" +
        "end;";
      
      OracleCommand oraCmd = new OracleCommand(l_sql,oraConn);

      try
      {
        oraConn.Open();

        oraCmd.ExecuteNonQuery();
      }
      catch (OracleException ex)
      {
        // Write the properties to the console
        Console.WriteLine("Caught OracleException #2:");
        Console.WriteLine("  DataSource: " + ex.DataSource);
        Console.WriteLine("  Errors Count: " + ex.Errors.Count.ToString());
        Console.WriteLine("  Message: " + ex.Message);
        Console.WriteLine("  Number: " + ex.Number.ToString());
        Console.WriteLine("  Procedure: " + ex.Procedure);
        Console.WriteLine("  Source: " + ex.Source);
        Console.WriteLine();
      }
      finally
      {
        if (oraConn.State == ConnectionState.Open)
        {
          oraConn.Close();
        }
      }

      oraConn.Dispose();
    }

    void oraException3()
    {
      // create a connection string using our standard user and
      // standard tns alias
      string c1 = "User Id=oranetuser;Password=demo;Data Source=oranet";
      OracleConnection oraConn = new OracleConnection(c1);

      // attempt to update the exception_test table.
      // this update will 'fail' since there are no values
      // in the table.
      string l_sql = "update exception_test set c=1 where c=0";
      
      OracleCommand oraCmd = new OracleCommand(l_sql,oraConn);

      try
      {
        oraConn.Open();

        oraCmd.ExecuteNonQuery();
      }
      catch (OracleException ex)
      {
        // Write the properties to the console
        Console.WriteLine("Caught OracleException #3:");
        Console.WriteLine("  DataSource: " + ex.DataSource);
        Console.WriteLine("  Errors Count: " + ex.Errors.Count.ToString());
        Console.WriteLine("  Message: " + ex.Message);
        Console.WriteLine("  Number: " + ex.Number.ToString());
        Console.WriteLine("  Procedure: " + ex.Procedure);
        Console.WriteLine("  Source: " + ex.Source);
        Console.WriteLine();
      }
      finally
      {
        if (oraConn.State == ConnectionState.Open)
        {
          oraConn.Close();
        }
      }

      oraConn.Dispose();
    }
  }
}

