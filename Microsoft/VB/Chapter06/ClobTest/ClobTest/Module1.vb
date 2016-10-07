Imports System
Imports System.Data
Imports System.Text
Imports System.io
Imports System.Data.OracleClient
Module Module1

  Sub Main()
    '// create our standard connection
    Dim connStr As String = "User Id=oranetuser; Password=demo; Data Source=oranet"
    Dim oraConn As OracleConnection = New OracleConnection(connStr)

    oraConn.Open()

    load_file(oraConn)

    display_properties(oraConn)

    manipulate_clob(oraConn)
  End Sub
  Private Sub load_file(ByVal con As OracleConnection)
    Console.WriteLine("Truncating table and loading file...")
    '// ensure the table is empty
    Dim sql As String = "truncate table clob_test"

    Dim cmd As OracleCommand = New OracleCommand(sql, con)

    cmd.ExecuteNonQuery()

    '// build the anonymous block and execute it
    sql = "declare"
    sql += "  /* local variables to hold the lob locators */"
    sql += "  l_clob  clob;"
    sql += "  l_bfile bfile;"
    sql += "begin"
    sql += "  /* this is a method to get the lob locator */"
    sql += "  /* for the lob column in the table */"
    sql += "  /* by inserting an empty_clob and returning */"
    sql += "  /* into the local clob variable, we easily */"
    sql += "  /* acquire the lob locator */"
    sql += "  insert into clob_test (clob_id, clob_data)"
    sql += "  values (1, empty_clob())"
    sql += "  returning clob_data into l_clob;"
    sql += "  /* this is the file we will load */"
    sql += "  l_bfile := bfilename('C_TEMP', 'ORABIN.TXT');"
    sql += "  /* the file must be opened prior to loading */"
    sql += "  dbms_lob.fileopen(l_bfile);"
    sql += "  /* this procedure performs the actual data load */"
    sql += "  /* it does not perform character set conversion */"
    sql += "  /* if character set conversion is required, */"
    sql += "  /* the loadclobfromfile procedure may be used */"
    sql += "  /* however, if you do not need character set */"
    sql += "  /* conversion, this procedure is much simpler */"
    sql += "  dbms_lob.loadfromfile(l_clob, l_bfile, dbms_lob.getlength(l_bfile));"
    sql += "  /* close the bfile after loading it */"
    sql += "  dbms_lob.fileclose(l_bfile);"
    sql += "  /* commit the transaction */"
    sql += "  commit;"
    sql += "end;"

    cmd.CommandText = sql

    cmd.ExecuteNonQuery()

    Console.WriteLine("Table successfully loaded...")
    Console.WriteLine()
  End Sub

  Private Sub display_properties(ByVal con As OracleConnection)
    Console.WriteLine("Retrieving clob and displaying properties...")

    '// this method simply displays the properties
    '// and the values for the clob
    Dim sql As String = "select clob_data from clob_test where clob_id = 1"

    Dim cmd As OracleCommand = New OracleCommand(sql, con)

    Dim dataReader As OracleDataReader = cmd.ExecuteReader()

    '// read the 1 row result
    dataReader.Read()

    '// use typed accessor that does not lock row
    Dim clob As OracleLob = dataReader.GetOracleLob(0)

    '// display each property value
    Console.WriteLine("  CanRead = " + clob.CanRead.ToString())
    Console.WriteLine("  CanSeek = " + clob.CanSeek.ToString())
    Console.WriteLine("  CanWrite = " + clob.CanWrite.ToString())
    Console.WriteLine("  Connection = " + clob.Connection.ConnectionString)
    Console.WriteLine("  IsTemporary = " + clob.IsTemporary.ToString())
    Console.WriteLine("  Length = " + clob.Length.ToString())
    Console.WriteLine("  OptimumChunkSize = " + clob.ChunkSize.ToString())
    Console.WriteLine("  Position = " + clob.Position.ToString())
    Console.WriteLine("  Value = " + clob.Value)

    Console.WriteLine("Completed displaying properties...")
    Console.WriteLine()
  End Sub

  Private Sub manipulate_clob(ByVal con As OracleConnection)
    '// this method performs some clob manipulation
    '// using some of the clob methods we have discussed
    Console.WriteLine("Beginning clob manipulation...")

    Dim sql As String = "select clob_id, clob_data from clob_test where clob_id = 1 for update"

    Dim cmd As OracleCommand = New OracleCommand(sql, con)

    '// begin a transaction since we will be updating
    Dim trans As OracleTransaction = con.BeginTransaction()

    cmd.Transaction = trans

    Dim dataReader As OracleDataReader = cmd.ExecuteReader()

    '// read the single row result
    dataReader.Read()

    '// use typed accessor that locks the row
    Dim clob As OracleLob = dataReader.GetOracleLob(1)

    '// we are done with the reader now, so we can close it
    dataReader.Close()

    '// searching is not available from the ms provider
    '// search for the string "Oracle.DataAccess.dll"
    '// in the clob
    'Dim charArray As Char() = "Oracle.DataAccess.dll".ToCharArray()
    'Dim stringPos As Int64 = clob.Search(charArray, 0, 1)
    'Console.WriteLine("  Found 'Oracle.DataAccess.dll' in position: " + stringPos.ToString())

    '// set the position to the beginning of the
    '// clob
    clob.Seek(0, SeekOrigin.Begin)

    '// read the first 32 bytes of the clob and display it
    Dim unicodeByte(32) As Byte
    clob.Read(unicodeByte, 0, 32)
    Dim clobString As String = Encoding.Unicode.GetString(unicodeByte)
    Console.Write("  Current value: ")
    Console.WriteLine(clobString)

    '// set the position to the beginning of the
    '// clob
    clob.Seek(0, SeekOrigin.Begin)

    '// change the text to uppercase and get byte array
    clobString = clobString.ToUpper()
    unicodeByte = Encoding.Unicode.GetBytes(clobString)
    clob.Write(unicodeByte, 0, unicodeByte.Length)

    '// reposition to the beginning of the clob
    clob.Seek(0, SeekOrigin.Begin)

    '// read the string and display it
    clob.Read(unicodeByte, 0, 32)
    clobString = Encoding.Unicode.GetString(unicodeByte)
    Console.Write("  New value: ")
    Console.WriteLine(clobString)

    '// commit the trans making the changes permanent
    trans.Commit()

    Console.WriteLine("Completed clob manipulation...")
  End Sub
End Module
