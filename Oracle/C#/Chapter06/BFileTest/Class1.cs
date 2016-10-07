using System;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace BFileTest
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

      // insert a row into the test table
      theClass.insert_row(oraConn);

      // get the bfile from the database
      // table and display properties / content
      theClass.get_bfile(oraConn);
    }

    private void insert_row(OracleConnection con)
    {
      // this helper inserts a row into the test
      // table (bfile_test)
      // the lob locator points to 'c:\temp\bfile_test.txt'

      // the sql statement to insert a test row
      string sqlText = "insert into bfile_test (file_loc) ";
      sqlText += "values (BFILENAME(:p_dir, :p_file))";

      // the command object associated with the sql statement
      OracleCommand cmd = new OracleCommand(sqlText, con);

      // the parameter objects
      OracleParameter p_dir = new OracleParameter();
      p_dir.Size = 6;
      p_dir.Value = "C_TEMP";

      OracleParameter p_file = new OracleParameter();
      p_file.Size = 14;
      p_file.Value = "bfile_test.txt";

      // add the parameters to the collection
      cmd.Parameters.Add(p_dir);
      cmd.Parameters.Add(p_file);

      // execute the command
      cmd.ExecuteNonQuery();
    }

    private void get_bfile(OracleConnection con)
    {
      // this helper gets the bfile from the database
      // table, displays the property values and
      // writes the content of the file to the console
      string sqlText = "select file_loc from bfile_test";

      // the command object
      OracleCommand cmd = new OracleCommand(sqlText, con);

      // get a data reader for the command object
      OracleDataReader dataReader = cmd.ExecuteReader();

      OracleBFile bfile = null;

      if (dataReader.Read())
      {
        // use the typed accessor to get the bfile
        bfile = dataReader.GetOracleBFile(0);
      }

      // open the file
      try
      {
        bfile.OpenFile();
      }
      catch(OracleException ex)
      {
        Console.WriteLine(ex.ToString());
      }

      // display the property values
      Console.WriteLine("Retrieved bfile from database...");
      Console.WriteLine("  CanRead = " + bfile.CanRead.ToString());
      Console.WriteLine("  CanSeek = " + bfile.CanSeek.ToString());
      Console.WriteLine("  CanWrite = " + bfile.CanWrite.ToString());
      Console.WriteLine("  Connection = " + bfile.Connection.ConnectionString);
      Console.WriteLine("  DirectoryName = " + bfile.DirectoryName.ToString());
      Console.WriteLine("  FileExists = " + bfile.FileExists.ToString());
      Console.WriteLine("  FileName = " + bfile.FileName.ToString());
      Console.WriteLine("  IsEmpty = " + bfile.IsEmpty.ToString());
      Console.WriteLine("  IsOpen = " + bfile.IsOpen.ToString());
      Console.WriteLine("  Length = " + bfile.Length.ToString());
      Console.WriteLine("  Position = " + bfile.Position.ToString());
      Console.WriteLine("  Value = " + bfile.Value.ToString());

      // convert the byte array to a string
      UTF7Encoding utf = new UTF7Encoding();
      Console.WriteLine("  Value = \n" + utf.GetString(bfile.Value));
    }
	}
}
