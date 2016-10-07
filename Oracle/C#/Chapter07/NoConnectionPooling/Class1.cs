using System;
using Oracle.DataAccess.Client;

namespace NoConnectionPooling
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
      // the pooling=false attribute disables connection pooling
      string l_connect = "User Id=oranetuser;" +
        "Password=demo;" +
        "Data Source=oranet;" +
        "pooling=false";

      OracleConnection conn_1 = new OracleConnection(l_connect);
      conn_1.Open();

      // pause so we can monitor connection in
      // SQL*Plus
      Console.WriteLine("Connection 1 created... Examine in SQL*Plus");
      Console.ReadLine();

      conn_1.Dispose();

      // pause so we can monitor connection in
      // SQL*Plus
      Console.WriteLine("Connection 1 disposed... Examine in SQL*Plus");
      Console.ReadLine();

      OracleConnection conn_2 = new OracleConnection(l_connect);
      conn_2.Open();

      // pause so we can monitor connection in
      // SQL*Plus
      Console.WriteLine("Connection 2 created... Examine in SQL*Plus");
      Console.ReadLine();

      conn_2.Dispose();

      // pause so we can monitor connection in
      // SQL*Plus
      Console.WriteLine("Connection 2 disposed... Examine in SQL*Plus");
      Console.ReadLine();
    }
  }
}
