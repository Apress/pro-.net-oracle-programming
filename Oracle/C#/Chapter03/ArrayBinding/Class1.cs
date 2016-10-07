using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace ArrayBinding
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
      // need to call our helper methods
      Class1 theClass = new Class1();

      // our standard connect string
      string connStr = "User Id=oranetuser; Password=demo; Data Source=oranet";

      // create the connection
      OracleConnection oraConn = new OracleConnection(connStr);

      // open the connection to the database
      oraConn.Open();

      // call our helper method to insert using array binding
      theClass.arrayInsert(oraConn);

      // call our helper method to update using array binding
      theClass.arrayUpdate(oraConn);

      // call our helper method to delete using array binding
      theClass.arrayDelete(oraConn);

      // explicitly close the connection
      oraConn.Close();

      // explicitly dispose the connection object
      oraConn.Dispose();
    }

    private void arrayInsert(OracleConnection con)
    {
      // used to load array values
      int i;

      // sql statement to insert our array values
      string sqlInsert = "insert into array_test (c1, c2, c3) ";
      sqlInsert += "values (:c1, :c2, :c3)";

      // create and populate array for column 1
      int[] c1_vals = new int[1024];

      for (i = 0; i < 1024; i++)
      {
        c1_vals[i] = i;
      }

      // create and populate array for column 2
      string[] c2_vals = new string[1024];

      for (i = 0; i < 1024; i++)
      {
        c2_vals[i] = "Column 2 Row " + i.ToString();
      }

      // create and populate array for column 3
      string[] c3_vals = new string[1024];

      for (i = 0; i < 1024; i++)
      {
        c3_vals[i] = "Column 3 Row " + i.ToString();
      }

      // create parameter for column 1
      OracleParameter c1 = new OracleParameter();
      c1.OracleDbType = OracleDbType.Decimal;
      c1.Value = c1_vals;

      // create parameter for column 2
      OracleParameter c2 = new OracleParameter();
      c2.OracleDbType = OracleDbType.Varchar2;
      c2.Value = c2_vals;

      // create parameter for column 3
      OracleParameter c3 = new OracleParameter();
      c3.OracleDbType = OracleDbType.Varchar2;
      c3.Value = c3_vals;

      // create the command object
      OracleCommand cmdInsert = new OracleCommand();
      cmdInsert.Connection = con;
      cmdInsert.CommandText = sqlInsert;
      cmdInsert.ArrayBindCount = c1_vals.Length;

      // add the parameters to the collection
      cmdInsert.Parameters.Add(c1);
      cmdInsert.Parameters.Add(c2);
      cmdInsert.Parameters.Add(c3);

      // insert all 1024 rows in one round trip
      cmdInsert.ExecuteNonQuery();
    }

    private void arrayUpdate(OracleConnection con)
    {
      // we will update the "lower" 512 rows in the array_test table

      // used to load array values
      int i;

      // sql statement to update our array values
      string sqlUpdate = "update array_test set c1 = :p1 where c1 = :p2";

      // create and populate array for new column 1 values
      int[] c1_new = new int[512];

      for (i = 0; i < 512; i++)
      {
        c1_new[i] = i + 2000;
      }

      // create and populate array for existing column 2 values
      int[] c1_old = new int[512];

      for (i = 0; i < 512; i++)
      {
        c1_old[i] = i;
      }

      // create parameter for new column 1 values
      OracleParameter p1 = new OracleParameter();
      p1.OracleDbType = OracleDbType.Decimal;
      p1.Value = c1_new;

      // create parameter for old column 1 values
      OracleParameter p2 = new OracleParameter();
      p2.OracleDbType = OracleDbType.Decimal;
      p2.Value = c1_old;

      // create the command object
      OracleCommand cmdInsert = new OracleCommand();
      cmdInsert.Connection = con;
      cmdInsert.CommandText = sqlUpdate;
      cmdInsert.ArrayBindCount = c1_new.Length;

      // add the parameters to the collection
      cmdInsert.Parameters.Add(p1);
      cmdInsert.Parameters.Add(p2);

      // update 512 rows in one round trip
      cmdInsert.ExecuteNonQuery();
    }

    private void arrayDelete(OracleConnection con)
    {
      // delete the rows that we did not update

      // used to load array values
      int i;

      // sql statement to delete our array values
      string sqlDelete = "delete from array_test where c1 = :p1";

      // create and populate array for column 1 values
      // that we did not update
      int[] c1_vals = new int[512];

      for (i = 512; i < 1024; i++)
      {
        c1_vals[i - 512] = i;
      }

      // create parameter for column 1 values
      OracleParameter p1 = new OracleParameter();
      p1.OracleDbType = OracleDbType.Decimal;
      p1.Value = c1_vals;

      // create the command object
      OracleCommand cmdInsert = new OracleCommand();
      cmdInsert.Connection = con;
      cmdInsert.CommandText = sqlDelete;
      cmdInsert.ArrayBindCount = c1_vals.Length;

      // add the parameters to the collection
      cmdInsert.Parameters.Add(p1);

      // delete 512 rows in one round trip
      cmdInsert.ExecuteNonQuery();
    }
  }
}
