using System;
using System.Data.OracleClient;

namespace HelloOracle
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
      String connString = "User Id=oranetuser;Password=demo;Data Source=oranet";
      OracleConnection oraConnection = new OracleConnection(connString);

      try
      {
        oraConnection.Open();

        Console.WriteLine("\nHello, Oracle Here!\n");
        Console.WriteLine("Connection String: ");
        Console.WriteLine(oraConnection.ConnectionString.ToString() + "\n");
        Console.WriteLine("Current Connection State: ");
        Console.WriteLine(oraConnection.State.ToString() + "\n");
        Console.WriteLine("Oracle Database Server Version: ");
        Console.WriteLine(oraConnection.ServerVersion.ToString());
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error occured: " + ex.Message);
      }
      finally
      {
        if (oraConnection.State == System.Data.ConnectionState.Open)
        {
          oraConnection.Close();
        }
      }
    }
  }
}
