using System;
using System.Data;
using System.Data.OracleClient;

namespace Sequence
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
      // used for accessing the helper methods
      Class1 theClass = new Class1();

      // create our standard connection
      string connStr = "User Id=oranetuser; Password=demo; Data Source=oranet";
      OracleConnection oraConn = new OracleConnection(connStr);

      oraConn.Open();

      theClass.insert_trigger(oraConn);

      theClass.insert_notrigger(oraConn);
    }

    private void insert_trigger(OracleConnection con)
    {
      // this method will insert rows using the trigger
      // to get the values from the sequence
      
      // the sql statement to insert a row
      string sqlText = "insert into environment (env_desc) ";
      sqlText += "values (:p1)";

      // the command object associated with the sql statement
      OracleCommand cmd = new OracleCommand(sqlText, con);

      // the parameter objects
      OracleParameter p1 = new OracleParameter();
      p1.Size = 32;
      p1.Value = "PROD";

      // add the parameter to the collection
      cmd.Parameters.Add(p1);
      
      // execute the command
      cmd.ExecuteNonQuery();

      // insert a row for stage
      p1.Value = "STAGE";
      cmd.ExecuteNonQuery();

      // insert a row for train
      p1.Value = "TRAIN";
      cmd.ExecuteNonQuery();

      // insert a row for test
      p1.Value = "TEST";
      cmd.ExecuteNonQuery();
    }

    private void insert_notrigger(OracleConnection con)
    {
      // this method will insert rows using sql
      // to get the values from the sequence

      // the sql statement to insert a row
      string sqlText = "insert into environment (env_id, env_desc) ";
      sqlText += "values (env_seq.nextval, :p1)";

      // the command object associated with the sql statement
      OracleCommand cmd = new OracleCommand(sqlText, con);

      // the parameter objects
      OracleParameter p1 = new OracleParameter();
      p1.Size = 32;
      p1.Value = "DEV";

      // add the parameter to the collection
      cmd.Parameters.Add(p1);
      
      // execute the command
      cmd.ExecuteNonQuery();

      // insert a row for sandbox
      p1.Value = "SAND";
      cmd.ExecuteNonQuery();

      // insert a row for evaluation
      p1.Value = "EVAL";
      cmd.ExecuteNonQuery();

      // insert a row for disaster recovery
      p1.Value = "DR";
      cmd.ExecuteNonQuery();
    }
	}
}
