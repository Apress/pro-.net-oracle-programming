using System;
using System.Data;
using System.IO;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace FSTest
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
      // create and open our standard connection
      string connStr = "User Id=oranetuser; Password=demo; Data Source=oranet";
      OracleConnection con = new OracleConnection(connStr);
      con.Open();

      // retrieve the blob from the database
      string sql = "select blob_data from blob_test where blob_id = 1";
      OracleCommand cmd = new OracleCommand(sql, con);
      OracleDataReader dataReader = cmd.ExecuteReader();

      // this will hold the time taken
      DateTime dtStart;
      DateTime dtEnd;
      double totalSeconds = 0;

      dtStart = DateTime.Now;
      
      // read the single row result
      cmd.InitialLOBFetchSize = 32767;
      dataReader.Read();

      // use typed accessor to retrieve the blob
      OracleBlob blob = dataReader.GetOracleBlob(0);

      dtEnd = DateTime.Now;

      // calculate the total time take to fetch
      totalSeconds = dtEnd.Subtract(dtStart).TotalSeconds;

      // we are done with the reader now, so we can close it
      dataReader.Close();

      // display some info about the time take to perform
      // the operation
      Console.WriteLine("Fetch time: {0} seconds.", totalSeconds.ToString());
    }
  }
}
