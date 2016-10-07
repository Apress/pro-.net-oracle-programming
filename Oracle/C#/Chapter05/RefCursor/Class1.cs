using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace RefCursor
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
      // for using our helpers
      Class1 theClass = new Class1();

      // create our standard connection
      string connStr = "User Id=oranetuser; Password=demo; Data Source=oranet";
      OracleConnection oraConn = new OracleConnection(connStr);

      oraConn.Open();

      // call the helper methods
      Console.WriteLine("Invoking ref cursor function...");
      theClass.call_function(oraConn);

      Console.WriteLine("Invoking ref cursor procedure...");
      theClass.call_procedure(oraConn);

      oraConn.Close();

      oraConn.Dispose();
    }

    private void call_function(OracleConnection con)
    {
      // create the command object and set attributes
      OracleCommand cmd = new OracleCommand("league_rc.get_table", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // create parameter object for the cursor
      OracleParameter p_refcursor = new OracleParameter();
  
      // this is vital to set when using ref cursors
      p_refcursor.OracleDbType = OracleDbType.RefCursor;
      p_refcursor.Direction = ParameterDirection.ReturnValue;

      cmd.Parameters.Add(p_refcursor);

      OracleDataReader reader = cmd.ExecuteReader();

      while (reader.Read())
      {
        Console.Write(reader.GetDecimal(0).ToString() + ",");
        Console.Write(reader.GetString(1) + ",");
        Console.Write(reader.GetDecimal(2).ToString() + ",");
        Console.Write(reader.GetDecimal(3).ToString() + ",");
        Console.Write(reader.GetDecimal(4).ToString() + ",");
        Console.Write(reader.GetDecimal(5).ToString() + ",");
        Console.Write(reader.GetDecimal(6).ToString() + ",");
        Console.WriteLine(reader.GetDecimal(7).ToString());
      }

      Console.WriteLine();

      reader.Close();
      reader.Dispose();
      p_refcursor.Dispose();
      cmd.Dispose();
    }

    private void call_procedure(OracleConnection con)
    {
      // create the command object and set attributes
      OracleCommand cmd = new OracleCommand("league_rc.get_table", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // create parameter object for the cursor
      OracleParameter p_refcursor = new OracleParameter();
  
      // this is vital to set when using ref cursors
      p_refcursor.OracleDbType = OracleDbType.RefCursor;
      p_refcursor.Direction = ParameterDirection.Output;

      cmd.Parameters.Add(p_refcursor);

      OracleDataReader reader = cmd.ExecuteReader();

      while (reader.Read())
      {
        Console.Write(reader.GetDecimal(0).ToString() + ",");
        Console.Write(reader.GetString(1) + ",");
        Console.Write(reader.GetDecimal(2).ToString() + ",");
        Console.Write(reader.GetDecimal(3).ToString() + ",");
        Console.Write(reader.GetDecimal(4).ToString() + ",");
        Console.Write(reader.GetDecimal(5).ToString() + ",");
        Console.Write(reader.GetDecimal(6).ToString() + ",");
        Console.WriteLine(reader.GetDecimal(7).ToString());
      }

      Console.WriteLine();

      reader.Close();
      reader.Dispose();
      p_refcursor.Dispose();
      cmd.Dispose();
    }
  }
}
