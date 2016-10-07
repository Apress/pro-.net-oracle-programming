using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace OraErrorCollection
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

      // this command will attempt to insert values that are too
      // large based on the table definition. The first two values
      // should not be in error and the last two should fail.
      // even though the first two values are not in error, the
      // entire insert operation will fail.
      string l_sql = "insert into exception_test(c) values (:c)";

      // our test array to use for the insert operation
      int[] testArray = new int[4]{9998,9999,10000,10001};

      // create a command object and set the values
      // the ArrayBindCount is a necessary property
      OracleCommand oraCmd = new OracleCommand();
     
      oraCmd.Connection = oraConn;
      oraCmd.CommandText = l_sql;
      oraCmd.ArrayBindCount = testArray.Length;

      // create a parameter object to hold our array
      // and add it to our command object's Parameters
      // collection
      OracleParameter p1 = new OracleParameter("c", OracleDbType.Int32);
      p1.Direction = ParameterDirection.Input;
      p1.Value = testArray;

      oraCmd.Parameters.Add(p1);

      try
      {
        oraConn.Open();
        
        // This should throw an exception
        oraCmd.ExecuteNonQuery();
      }
      catch (OracleException ex)
      {
        Console.WriteLine("Caught OracleException:");
        Console.WriteLine("  DataSource: " + ex.DataSource);
        Console.WriteLine("  Errors Count: " + ex.Errors.Count.ToString());
        Console.WriteLine("  Message: " + ex.Message);
        Console.WriteLine("  Number: " + ex.Number.ToString());
        Console.WriteLine("  Procedure: " + ex.Procedure);
        Console.WriteLine("  Source: " + ex.Source);
        Console.WriteLine();

        // iterate through the error collection and
        // display properties for each error object
        // to the console.
        for (int i=0; i<ex.Errors.Count; i++)
        {
          Console.WriteLine("ErrorCollection[{0}]:", i);
          Console.WriteLine("  ArrayBindIndex: " + 
            ex.Errors[i].ArrayBindIndex.ToString());
          Console.WriteLine("  DataSource: " + ex.Errors[i].DataSource);
          Console.WriteLine("  Message: " + ex.Errors[i].Message);
          Console.WriteLine("  Number: " + ex.Errors[i].Number.ToString());
          Console.WriteLine("  Procedure: " + ex.Errors[i].Procedure);
          Console.WriteLine("  Source: " + ex.Errors[i].Source);
          Console.WriteLine();
        }
      }
      finally
      {
        if (oraConn.State == ConnectionState.Open)
        {
          oraConn.Close();
        }
      }

      // explicitly dispose our objects
      p1.Dispose();
      oraCmd.Dispose();
      oraConn.Dispose();
    }
  }
}
