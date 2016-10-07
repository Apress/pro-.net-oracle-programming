using System;
using Oracle.DataAccess.Client;

namespace ConnectionPooling
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
      // create a connection string to our standard database
      // the pooling attribute defaults to "true" so we
      // do not need to include it to enable pooling
      string l_connect = "User Id=oranetuser;" +
        "Password=demo;" +
        "Data Source=oranet;";

      OracleConnection conn_1 = new OracleConnection(l_connect);
      conn_1.Open();

      // pause so we can monitor connection in
      // SQL*Plus
      Console.WriteLine("Connection 1 created... Hit enter key");
      Console.ReadLine();

      conn_1.Dispose();

      // pause so we can monitor connection in
      // SQL*Plus
      Console.WriteLine("Connection 1 disposed... Hit enter key");
      Console.ReadLine();

      OracleConnection conn_2 = new OracleConnection(l_connect);
      conn_2.Open();

      // pause so we can monitor connection in
      // SQL*Plus
      Console.WriteLine("Connection 2 created... Hit enter key");
      Console.ReadLine();

      conn_2.Dispose();

      // pause so we can monitor connection in
      // SQL*Plus
      Console.WriteLine("Connection 2 disposed... Hit enter key");
      Console.ReadLine();
    }
  }
}
