using System;
using System.Data.OracleClient;

namespace DefaultConnection
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
            // Use the default database by omitting the Data Source connect
            // string attribute.
            String connString = "User Id=oranetuser;Password=demo";
            OracleConnection oraConn = new OracleConnection(connString);

            try
            {
                oraConn.Open();

                Console.WriteLine("\nHello, Default Oracle Database Here!\n");
                Console.WriteLine("Connection String: ");
                Console.WriteLine(oraConn.ConnectionString.ToString() + "\n");
                Console.WriteLine("Current Connection State: ");
                Console.WriteLine(oraConn.State.ToString() + "\n");
                Console.WriteLine("Oracle Database Server Version: ");
                Console.WriteLine(oraConn.ServerVersion.ToString());
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
