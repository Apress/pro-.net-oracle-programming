using System;
using System.Data;
using System.Data.OracleClient;

namespace GetEmployees
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
      // create and open a connection object
      string connstr = "User Id=scott; Password=tiger; Data Source=oranet";
      OracleConnection con = new OracleConnection(connstr);
      con.Open();

      // the sql statement to retrieve the data from the tables
      string sql = "select a.empno, a.ename, a.job, b.dname ";
      sql += "from emp a, dept b ";
      sql += "where a.deptno = b.deptno ";
      sql += "order by a.empno";

      // create the command object
      OracleCommand cmd = new OracleCommand(sql, con);

      // execute the command and get a data reader
      OracleDataReader dr = cmd.ExecuteReader();

      // display the results to the console window
      // use a tab character between the columns
      while (dr.Read())
      {
        Console.Write(dr[0].ToString() + "\t");
        Console.Write(dr[1].ToString() + "\t");
        Console.Write(dr[2].ToString() + "\t");
        Console.WriteLine(dr[3].ToString());
      }

      // close and dispose the objects
      dr.Close();
      dr.Dispose();
      cmd.Dispose();
      con.Close();
      con.Dispose();
    }
	}
}
