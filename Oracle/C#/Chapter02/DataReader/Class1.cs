using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace DataReader
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
      if (args.Length != 4)
      {
        Console.WriteLine("Incorrect number of command line parameters.");

        return;
      }

      // Build a connect string based on the command line parameters
      string connString = "User Id=" + args[0].ToString() + ";";
      connString += "Password=" + args[1].ToString() + ";";
      connString += "Data Source=" + args[2].ToString();

      OracleConnection oraConn = new OracleConnection();
      oraConn.ConnectionString = connString;

      // build the sql statement based on the command line parameter
      string sqlStatement = "select * from " + args[3].ToString();

      // the number of fields in the result set
      int fieldCount = 0;

      // used in our counter loops
      int i = 0;

      try
      {
        oraConn.Open();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Exception caught {0}", ex.Message);
      }

      if (oraConn.State == ConnectionState.Open)
      {
        try
        {
          // create the command object
          OracleCommand cmdSQL = new OracleCommand(sqlStatement,oraConn);

          // get a data reader
          OracleDataReader dataReader = cmdSQL.ExecuteReader();

          // the number of fields in the result set
          fieldCount = dataReader.FieldCount;

          // output a comma separated header
          for (i = 0; i < fieldCount; i++)
          {
            Console.Write(dataReader.GetName(i));

            if (i < fieldCount - 1)
            {
              Console.Write(",");
            }
          }

          Console.WriteLine();

          // output a comma separated "line" of data
          while (dataReader.Read())
          {
            for (i = 0; i < fieldCount; i++)
            {
              // check if the data is null or not
              if (!dataReader.IsDBNull(i))
              {
                // not null, so write value
                // we use the "item" method by
                // specifying the index rather than
                // using a typed accessor
                Console.Write(dataReader[i].ToString());
              }
              else
              {
                // null value
                Console.Write("(null)");
              }

              if (i < fieldCount - 1)
              {
                Console.Write(",");
              }
            }

            Console.WriteLine();
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine("Exception caught {0}", ex.Message);
        }
      }

      if (oraConn.State == ConnectionState.Open)
      {
        oraConn.Close();
      }

      oraConn.Dispose();
    }
  }
}
