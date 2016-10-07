Imports System
Imports System.Text
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Module Module1

  Sub Main()
    '// create our standard connection
    Dim connStr As String = "User Id=oranetuser; Password=demo; Data Source=oranet"
    Dim oraConn As OracleConnection = New OracleConnection(connStr)

    oraConn.Open()

    '// insert a row into the test table
    insert_row(oraConn)

    '// get the bfile from the database
    '// table and display properties / content
    get_bfile(oraConn)
  End Sub
  Private Sub insert_row(ByVal con As OracleConnection)
    '// this helper inserts a row into the test
    '// table (bfile_test)
    '// the lob locator points to 'c:\temp\bfile_test.txt'

    '// the sql statement to insert a test row
    Dim sqlText As String = "insert into bfile_test (file_loc) "
    sqlText += "values (BFILENAME(:p_dir, :p_file))"

    '// the command object associated with the sql statement
    Dim cmd As OracleCommand = New OracleCommand(sqlText, con)

    '// the parameter objects
    Dim p_dir As OracleParameter = New OracleParameter
    p_dir.Size = 6
    p_dir.Value = "C_TEMP"

    Dim p_file As OracleParameter = New OracleParameter
    p_file.Size = 14
    p_file.Value = "bfile_test.txt"

    '// add the parameters to the collection
    cmd.Parameters.Add(p_dir)
    cmd.Parameters.Add(p_file)

    '// execute the command
    cmd.ExecuteNonQuery()
  End Sub

  Private Sub get_bfile(ByVal con As OracleConnection)
    '// this helper gets the bfile from the database
    '// table, displays the property values and
    '// writes the content of the file to the console
    Dim sqlText As String = "select file_loc from bfile_test"

    '// the command object
    Dim cmd As OracleCommand = New OracleCommand(sqlText, con)

    '// get a data reader for the command object
    Dim dataReader As OracleDataReader = cmd.ExecuteReader()

    Dim bfile As OracleBFile

    If dataReader.Read() Then
      '// use the typed accessor to get the bfile
      bfile = dataReader.GetOracleBFile(0)
    End If

    '// open the file
    Try
      bfile.OpenFile()
    Catch ex As OracleException
      Console.WriteLine(ex.ToString())
    End Try

    '// display the property values
    Console.WriteLine("Retrieved bfile from database...")
    Console.WriteLine("  CanRead = " + bfile.CanRead.ToString())
    Console.WriteLine("  CanSeek = " + bfile.CanSeek.ToString())
    Console.WriteLine("  CanWrite = " + bfile.CanWrite.ToString())
    Console.WriteLine("  Connection = " + bfile.Connection.ConnectionString)
    Console.WriteLine("  DirectoryName = " + bfile.DirectoryName.ToString())
    Console.WriteLine("  FileExists = " + bfile.FileExists.ToString())
    Console.WriteLine("  FileName = " + bfile.FileName.ToString())
    Console.WriteLine("  IsEmpty = " + bfile.IsEmpty.ToString())
    Console.WriteLine("  IsOpen = " + bfile.IsOpen.ToString())
    Console.WriteLine("  Length = " + bfile.Length.ToString())
    Console.WriteLine("  Position = " + bfile.Position.ToString())
    Console.WriteLine("  Value = " + bfile.Value.ToString())

    '// convert the byte array to a string
    Dim utf As UTF7Encoding = New UTF7Encoding
    Console.WriteLine("  Value = \n" + utf.GetString(bfile.Value))
  End Sub
End Module
