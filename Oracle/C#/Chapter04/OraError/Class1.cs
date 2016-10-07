using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace OraError
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
        // Now that we have an OracleException, we can
        // get the error object.
        OracleError theError = ex.Errors[0];
        
        // Write the properties to the console as we did
        // with the OracleException.  The values here will
        // be remarkably similar to those in the OracleException
        // sample code.
        Console.WriteLine("OracleError properties:");
        Console.WriteLine("  ArrayBindIndex: " + 
          theError.ArrayBindIndex.ToString());
        Console.WriteLine("  DataSource: " + theError.DataSource);
        Console.WriteLine("  Message: " + theError.Message);
        Console.WriteLine("  Number: " + theError.Number.ToString());
        Console.WriteLine("  Procedure: " + theError.Procedure);
        Console.WriteLine("  Source: " + theError.Source);
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
