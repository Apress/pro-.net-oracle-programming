using System;
using Oracle.DataAccess.Client;

namespace PrivilegedConnection
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

      // our "basic" connection string
      string conn_1 = "User Id=oranetadmin;" +
        "Password=demo;" +
        "Data Source=oranet";

      // our "sysdba" connection string
      string conn_2 = "User Id=oranetadmin;" +
        "Password=demo;" +
        "Data Source=oranet;" +
        "DBA Privilege=SYSDBA";
      
      // our "sysoper" connection string
      string conn_3 = "User Id=oranetadmin;" +
        "Password=demo;" +
        "Data Source=oranet;" +
        "DBA Privilege=SYSOPER";

      // our "who am i?" query
      string l_sql = "select a.username, " +
        "b.global_name database " +
        "from user_users a, " +
        "global_name b";

      theClass.privilegeTest(conn_1, l_sql);
      theClass.privilegeTest(conn_2, l_sql);
      theClass.privilegeTest(conn_3, l_sql);
    }

    void privilegeTest(string p_connect, string p_sql)
    {
      // a simple little helper method
      // gets a connection, executes the sql statement,
      // and prints the results (if any) to the console
      OracleCommand oraCmd;
      OracleDataReader oraReader;

      OracleConnection oraConn = new OracleConnection(p_connect);

      try
      {
        oraConn.Open();

        oraCmd = new OracleCommand(p_sql,oraConn);

        oraReader = oraCmd.ExecuteReader();

        while (oraReader.Read())
        {
          Console.WriteLine("User: ");
          Console.WriteLine("  " + oraReader.GetString(0));
          Console.WriteLine("Database: ");
          Console.WriteLine("  " + oraReader.GetString(1) + "\n");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error occured: " + ex.Message);
      }
      finally
      {
        if (oraConn.State == System.Data.ConnectionState.Open)
        {
          oraConn.Close();
        }
      }
    }
  }
}
