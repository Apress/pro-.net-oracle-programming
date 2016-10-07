using System;
using System.Data.OracleClient;

namespace OSAuthenticatedConnection
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

      // our "default" database connection string
      string conn_1 = "User Id=/; Integrated Security=true";

      // our "tns alias" database connection string
      string conn_2 = "User Id=/;" +
        "Data Source=oranet; Integrated Security=true";

      // our "who am i?" query
      string l_sql = "select a.username, " +
        "b.global_name database " +
        "from user_users a, " +
        "global_name b";

      Console.WriteLine("Using the default database...");
      theClass.authenticationTest(conn_1, l_sql);

      Console.WriteLine("Using the tns alias...");      
      theClass.authenticationTest(conn_2, l_sql);
    }

    void authenticationTest(string p_connect, string p_sql)
    {
      // a simple little helper method
      // gets a connection, executes the sql statement,
      // and prints the results to the console
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
