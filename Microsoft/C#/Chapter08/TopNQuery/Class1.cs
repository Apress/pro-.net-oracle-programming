using System;
using System.Data;
using System.Data.OracleClient;

namespace TopNQuery
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
      // create a connection to the HR schema
      string connStr = "User Id=hr; Password=demo; Data Source=oranet";
      OracleConnection oraConn = new OracleConnection(connStr);
      
      // the sql statement to get the top 3 salaries
      string sql = "select * ";
              sql += "from  (select department_id, ";
              sql += "              dense_rank() over (partition by department_id ";
              sql += "                                 order by salary desc) rank, ";
              sql += "              first_name || ' ' || last_name EMPLOYEE, ";
              sql += "              salary ";
              sql += "       from   employees) ";
              sql += "where rank <= 3";

      // open the database connection
      oraConn.Open();

      // create a command object
      OracleCommand cmd = new OracleCommand(sql, oraConn);

      // create a data reader from the command object
      OracleDataReader dataReader = cmd.ExecuteReader();

      // the number of fields in the result set
      int fieldCount = dataReader.FieldCount;

      // output a header line
      Console.WriteLine("Department,Rank,Employee,Salary");

      // for each row in the result set
      // this is code that we used in chapter 2
      while (dataReader.Read())
      {
        for (int i = 0; i < fieldCount; i++)
        {
          if (!dataReader.IsDBNull(i))
          {
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

      // explicitly close and dispose objects
      dataReader.Close();
      dataReader.Dispose();
      cmd.Dispose();
      oraConn.Close();
      oraConn.Dispose();
    }
	}
}
