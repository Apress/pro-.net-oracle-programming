Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Module Module1

  Sub Main()
    Dim oraConn As OracleConnection = New OracleConnection
    oraConn.ConnectionString = "User Id=sh; Password=demo; Data Source=oranet"

    Try
      oraConn.Open()

      '// fetch 10 rows per server trip
      doFetchTest(oraConn, 10)

      '// fetch 100 rows per server trip        
      doFetchTest(oraConn, 100)

      '// fetch 1000 rows per server trip        
      doFetchTest(oraConn, 1000)

      '// fetch 10000 rows per server trip
      doFetchTest(oraConn, 10000)

      '// fetch 100000 rows per server trip
      doFetchTest(oraConn, 100000)

      '// fetch 1 row per server trip
      doFetchTest(oraConn, 1)
    Catch ex As Exception
      Console.WriteLine("Exception caught: {0}", ex.Message)
    End Try


    If oraConn.State = ConnectionState.Open Then
      oraConn.Close()
    End If

    oraConn.Dispose()
  End Sub
  Private Sub doFetchTest(ByVal con As OracleConnection, ByVal numRows As Long)
    '// create our command and reader objects to be
    '// used in the test
    Dim cmdFetchTest As OracleCommand = New OracleCommand
    Dim dataReader As OracleDataReader = Nothing

    '// this will hold the time taken and the "i"
    '// will simply be incremented as we read through
    '// the result set
    Dim dtStart As DateTime
    Dim dtEnd As DateTime
    Dim totalSeconds As Double = 0
    Dim i As Long = 0

    '// Set the command object properties
    '// the sales table is a "larger" table so we
    '// will use it to test the fetch size impact
    cmdFetchTest.Connection = con
    cmdFetchTest.CommandText = "select * from sales"

    '// ensure we have an open connection
    If con.State = ConnectionState.Open Then
      dtStart = DateTime.Now

      dataReader = cmdFetchTest.ExecuteReader()

      '// once we have the data reader we can get the
      '// row size from the command object
      '// set the fetch size to the number of rows passed
      '// as a parameter
      dataReader.FetchSize = cmdFetchTest.RowSize * numRows

      '// ensure we actually fetch from the result set
      '// even though this is a sort of "no-op" loop
      While (dataReader.Read())
        i += 1
      End While

      dtEnd = DateTime.Now

      '// calculate the total time take to fetch
      totalSeconds = dtEnd.Subtract(dtStart).TotalSeconds

      dataReader.Close()

      '// display some info about the time take to perform
      '// the operation
      Console.WriteLine("Number of rows per fetch: {0}", numRows.ToString())
      Console.WriteLine("  Fetch time: {0} seconds.", totalSeconds.ToString())
      Console.WriteLine()

      '// explicitly dispose...
      dataReader.Dispose()
      cmdFetchTest.Dispose()
    End If
  End Sub
End Module
