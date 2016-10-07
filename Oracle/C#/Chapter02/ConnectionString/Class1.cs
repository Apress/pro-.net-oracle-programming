using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ConnectionString
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
      // create a connection object
      string connstr = "User Id=scott; Password=tiger; Data Source=oranet";
      OracleConnection con = new OracleConnection();

      // set the connection string
      con.ConnectionString = connstr;

      // display the ConnectionString property to the console
      // this will show the password
      Console.WriteLine("Connection String 1: {0}", con.ConnectionString);

      // open the connection
      con.Open();

      // display the ConnectionString property to the console
      // this will not show the password
      Console.WriteLine("Connection String 2: {0}", con.ConnectionString);

      // close the connection
      con.Close();

      // display the ConnectionString property to the console
      // this will not show the password
      Console.WriteLine("Connection String 3: {0}", con.ConnectionString);

      // clean up the connection object
      con.Dispose();
    }
	}
}
