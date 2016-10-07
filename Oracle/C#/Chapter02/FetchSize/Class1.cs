using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace FetchSize
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

      OracleConnection oraConn = new OracleConnection();
      oraConn.ConnectionString = "User Id=sh; Password=demo; Data Source=oranet";

      try
      {
        oraConn.Open();

        // fetch 10 rows per server trip
        theClass.doFetchTest(oraConn,10);

        // fetch 100 rows per server trip        
        theClass.doFetchTest(oraConn,100);

        // fetch 1000 rows per server trip        
        theClass.doFetchTest(oraConn,1000);

        // fetch 10000 rows per server trip
        theClass.doFetchTest(oraConn,10000);
    
        // fetch 100000 rows per server trip
        theClass.doFetchTest(oraConn,100000);

        // fetch 1 row per server trip
        theClass.doFetchTest(oraConn, 1);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Exception caught: {0}", ex.Message);
      }

      if (oraConn.State == ConnectionState.Open)
      {
        oraConn.Close();
      }

      oraConn.Dispose();
    }

    private void doFetchTest(OracleConnection con, long numRows)
    {
      // create our command and reader objects to be
      // used in the test
      OracleCommand cmdFetchTest = new OracleCommand();
      OracleDataReader dataReader = null;

      // this will hold the time taken and the "i"
      // will simply be incremented as we read through
      // the result set
      DateTime dtStart;
      DateTime dtEnd;
      double totalSeconds = 0;
      long i = 0;

      // Set the command object properties
      // the sales table is a "larger" table so we
      // will use it to test the fetch size impact
      cmdFetchTest.Connection = con;
      cmdFetchTest.CommandText = "select * from sales";

      // ensure we have an open connection
      if (con.State == ConnectionState.Open)
      {
        dtStart = DateTime.Now;

        dataReader = cmdFetchTest.ExecuteReader();

        // once we have the data reader we can get the
        // row size from the command object
        // set the fetch size to the number of rows passed
        // as a parameter
        dataReader.FetchSize = cmdFetchTest.RowSize * numRows;

        // ensure we actually fetch from the result set
        // even though this is a sort of "no-op" loop
        while (dataReader.Read())
        {
          i++;
        }

        dtEnd = DateTime.Now;

        // calculate the total time take to fetch
        totalSeconds = dtEnd.Subtract(dtStart).TotalSeconds;

        dataReader.Close();

        // display some info about the time take to perform
        // the operation
        Console.WriteLine("Number of rows per fetch: {0}", numRows.ToString());
        Console.WriteLine("  Fetch time: {0} seconds.", totalSeconds.ToString());
        Console.WriteLine();

        // explicitly dispose...
        dataReader.Dispose();
        cmdFetchTest.Dispose();
      }
    }
  }
}
