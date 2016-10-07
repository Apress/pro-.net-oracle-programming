using System;
using System.Data;
using System.Data.OracleClient;

namespace OraTransaction
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

      // call helper method to illustrate rolling back
      theClass.testRollback(oraConn);

      // call helper method to illustrate committing
      theClass.testCommit(oraConn);

      // call helper method to illustrate multiple actions
      theClass.testMultiple(oraConn);

      // explicitly close the connection
      oraConn.Close();

      // explicitly dispose the connection object
      oraConn.Dispose();
    }

    private void testRollback(OracleConnection con)
    {
      // sql statement to add :amount units to the balance
      // for acct_id :acct_id
      string sqlUpdate = "update trans_test ";
      sqlUpdate += "set balance = balance + :amount ";
      sqlUpdate += "where acct_id = :acct_id";

      // sql statement to verify that our session can "see"
      // the updated data
      string sqlSelect = "select acct_id, balance ";
      sqlSelect += "from trans_test ";
      sqlSelect += "where acct_id = :acct_id";

      // create parameter for balance
      OracleParameter amount = new OracleParameter();
      amount.DbType = DbType.Decimal;
      amount.Precision = 12;
      amount.Scale = 2;
      amount.Value = 500;
      amount.ParameterName = "amount";

      // create parameter for acct_id
      OracleParameter acct_id = new OracleParameter();
      acct_id.DbType = DbType.Decimal;
      acct_id.Precision = 2;
      acct_id.Value = 2;
      acct_id.ParameterName = "acct_id";

      // create the command object for the update
      OracleCommand cmdUpdate = new OracleCommand();
      cmdUpdate.Connection = con;
      cmdUpdate.CommandText = sqlUpdate;

      // add the parameters to the collection
      cmdUpdate.Parameters.Add(amount);
      cmdUpdate.Parameters.Add(acct_id);

      // Explicitly begin a transaction
      OracleTransaction trans = con.BeginTransaction();
      cmdUpdate.Transaction = trans;

      // update the balance, but will not automatically commit
      cmdUpdate.ExecuteNonQuery();

      // at this point the update has actually happened
      // in the database and will be visible to our session only
      // we will illustrate how we can see this from our session
      // but not from another session
      OracleCommand cmdSelect = new OracleCommand();
      cmdSelect.Connection = con;
      cmdSelect.CommandText = sqlSelect;
      cmdSelect.Transaction = trans;

      // create parameter for acct_id
      // can't reuse the parameter from above
      // because it still belongs to the parameter
      // collection for the update command object
      OracleParameter acct_id2 = new OracleParameter();
      acct_id2.DbType = DbType.Decimal;
      acct_id2.Precision = 2;
      acct_id2.Value = 2;
      acct_id2.ParameterName = "acct_id";

      // add the parameters to the collection
      cmdSelect.Parameters.Add(acct_id2);

      // get a data reader from the command object
      OracleDataReader reader = cmdSelect.ExecuteReader();

      // display the acct_id and balance
      // balance should be 1500 for acct_id 2
      if (reader.Read())
      {
        Console.WriteLine("Update has taken place, but not been committed...");
        Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString());
        Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString());
        Console.WriteLine("Examine in SQL*Plus...");
        Console.ReadLine();
      }

      // at this point we have verified that the update did
      // take place, however it has not been committed.
      // we will rollback the transaction to prevent it from
      // being committed.
      trans.Rollback();

      // close the reader before reusing
      reader.Close();

      // get the reader again
      reader = cmdSelect.ExecuteReader();

      // display the acct_id and balance
      // balance should now be 1000 for acct_id 2
      // since we rolled back the transaction
      if (reader.Read())
      {
        Console.WriteLine();
        Console.WriteLine("Update has taken place, and rolled back...");
        Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString());
        Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString());
        Console.WriteLine("Examine in SQL*Plus...");
        Console.ReadLine();
      }
    }

    private void testCommit(OracleConnection con)
    {
      // sql statement to add :amount units to the balance
      // for acct_id :acct_id
      string sqlUpdate = "update trans_test ";
      sqlUpdate += "set balance = balance + :amount ";
      sqlUpdate += "where acct_id = :acct_id";

      // sql statement to verify that our session can "see"
      // the updated data
      string sqlSelect = "select acct_id, balance ";
      sqlSelect += "from trans_test ";
      sqlSelect += "where acct_id = :acct_id";

      // create parameter for balance
      OracleParameter amount = new OracleParameter();
      amount.DbType = DbType.Decimal;
      amount.Precision = 12;
      amount.Scale = 2;
      amount.Value = 500;
      amount.ParameterName = "amount";

      // create parameter for acct_id
      OracleParameter acct_id = new OracleParameter();
      acct_id.DbType = DbType.Decimal;
      acct_id.Precision = 2;
      acct_id.Value = 2;
      acct_id.ParameterName = "acct_id";

      // create the command object for the update
      OracleCommand cmdUpdate = new OracleCommand();
      cmdUpdate.Connection = con;
      cmdUpdate.CommandText = sqlUpdate;

      // add the parameters to the collection
      cmdUpdate.Parameters.Add(amount);
      cmdUpdate.Parameters.Add(acct_id);

      // Explicitly begin a transaction
      OracleTransaction trans = con.BeginTransaction();
      cmdUpdate.Transaction = trans;

      // update the balance, but will not automatically commit
      cmdUpdate.ExecuteNonQuery();

      // at this point the update has actually happened
      // in the database and will be visible to our session only
      // we will illustrate how we can see this from our session
      // but not from another session
      OracleCommand cmdSelect = new OracleCommand();
      cmdSelect.Connection = con;
      cmdSelect.CommandText = sqlSelect;
      cmdSelect.Transaction = trans;

      // create parameter for acct_id
      // can't reuse the parameter from above
      // because it still belongs to the parameter
      // collection for the update command object
      OracleParameter acct_id2 = new OracleParameter();
      acct_id2.DbType = DbType.Decimal;
      acct_id2.Precision = 2;
      acct_id2.Value = 2;
      acct_id2.ParameterName = "acct_id";

      // add the parameters to the collection
      cmdSelect.Parameters.Add(acct_id2);

      // get a data reader from the command object
      OracleDataReader reader = cmdSelect.ExecuteReader();

      // display the acct_id and balance
      // balance should be 1500 for acct_id 2
      if (reader.Read())
      {
        Console.WriteLine();
        Console.WriteLine("Update has taken place, but not been committed...");
        Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString());
        Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString());
      }

      // at this point we have verified that the update did
      // take place, however it has not been committed.
      // we will commit the transaction making it "permanent"
      trans.Commit();

      // close the reader before reusing
      reader.Close();

      // get the reader again
      reader = cmdSelect.ExecuteReader();

      // display the acct_id and balance
      // balance should still be 1500 for acct_id 2
      // since we committed the transaction
      if (reader.Read())
      {
        Console.WriteLine();
        Console.WriteLine("Update has taken place, and been committed...");
        Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString());
        Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString());
        Console.WriteLine();
        Console.WriteLine("Examine in SQL*Plus...");
        Console.ReadLine();
      }
    }

    private void testMultiple(OracleConnection con)
    {
      // sql statement to add :amount units to the balance
      // for acct_id :acct_id
      // :amount may be a negative number
      string sqlUpdate = "update trans_test ";
      sqlUpdate += "set balance = balance + :amount ";
      sqlUpdate += "where acct_id = :acct_id";

      // sql statement to verify that our session can "see"
      // the updated data
      string sqlSelect = "select acct_id, balance ";
      sqlSelect += "from trans_test ";
      sqlSelect += "where acct_id = :acct_id";

      // create parameter for amount/balance
      OracleParameter amount = new OracleParameter();
      amount.DbType = DbType.Decimal;
      amount.Precision = 12;
      amount.Scale = 2;
      amount.Value = -5000;
      amount.ParameterName = "amount";

      // create parameter for acct_id
      OracleParameter acct_id = new OracleParameter();
      acct_id.DbType = DbType.Decimal;
      acct_id.Precision = 2;
      acct_id.Value = 1;
      acct_id.ParameterName = "acct_id";

      // create second parameter for acct_id
      OracleParameter acct_id2 = new OracleParameter();
      acct_id2.DbType = DbType.Decimal;
      acct_id2.Precision = 2;
      acct_id2.Value = 1;
      acct_id2.ParameterName = "acct_id";

      // create the command object for the update
      OracleCommand cmdUpdate = new OracleCommand();
      cmdUpdate.Connection = con;
      cmdUpdate.CommandText = sqlUpdate;

      // add the parameters to the collection
      cmdUpdate.Parameters.Add(amount);
      cmdUpdate.Parameters.Add(acct_id);

      // Explicitly begin a transaction
      OracleTransaction trans = con.BeginTransaction();
      cmdUpdate.Transaction = trans;

      // update the balance, but will not automatically commit
      cmdUpdate.ExecuteNonQuery();

      // at this point the update has actually happened
      // in the database and will be visible to our session only
      OracleCommand cmdSelect = new OracleCommand();
      cmdSelect.Connection = con;
      cmdSelect.CommandText = sqlSelect;
      cmdSelect.Transaction = trans;

      // add the parameters to the collection
      cmdSelect.Parameters.Add(acct_id2);

      // get a data reader from the command object
      OracleDataReader reader = cmdSelect.ExecuteReader();

      // display the acct_id and balance
      // balance should be 5000 for acct_id 1
      if (reader.Read())
      {
        Console.WriteLine();
        Console.WriteLine("Update has taken place, but not been committed...");
        Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString());
        Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString());
      }

      // execute the update again
      // this will cause the balance to become negative
      // a business rule would be needed to determine if
      // this is acceptable
      // the end result of the 3 actions is a positive number
      amount.Value = -7000;
      cmdUpdate.ExecuteNonQuery();

      // close the reader before reusing
      reader.Close();

      // get the reader again
      reader = cmdSelect.ExecuteReader();

      // display the acct_id and balance
      // balance should be -2000 for acct_id 1
      if (reader.Read())
      {
        Console.WriteLine();
        Console.WriteLine("Update has taken place, but not been committed...");
        Console.WriteLine("The balance has become negative, but the transaction");
        Console.WriteLine("has not been committed so this may be acceptable");
        Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString());
        Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString());
      }

      // execute the update again
      amount.Value = 3000;
      cmdUpdate.ExecuteNonQuery();

      // we will commit the transaction making it "permanent"
      trans.Commit();

      // close the reader before reusing
      reader.Close();

      // get the reader again
      reader = cmdSelect.ExecuteReader();

      // display the acct_id and balance
      // balance should be 1000 for acct_id 1
      if (reader.Read())
      {
        Console.WriteLine();
        Console.WriteLine("Update has taken place, and been committed...");
        Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString());
        Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString());
      }
    }
  }
}
