Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Module Module1

  Sub Main()
    '// create a connection string using our standard user and
    '// standard tns alias
    Dim c1 As String = "User Id=oranetuser;Password=demo;Data Source=oranet"
    Dim oraConn As OracleConnection = New OracleConnection(c1)

    '// this command will attempt to insert values that are too
    '// large based on the table definition. The first two values
    '// should not be in error and the last two should fail.
    '// even though the first two values are not in error, the
    '// entire insert operation will fail.
    Dim l_sql As String = "insert into exception_test(c) values (:c)"

    '// our test array to use for the insert operation
    Dim testArray() As Integer = {9998, 9999, 10000, 10001}

    '// create a command object and set the values
    '// the ArrayBindCount is a necessary property
    Dim oraCmd As OracleCommand = New OracleCommand

    oraCmd.Connection = oraConn
    oraCmd.CommandText = l_sql
    oraCmd.ArrayBindCount = testArray.Length

    '// create a parameter object to hold our array
    '// and add it to our command object's Parameters
    '// collection
    Dim p1 As OracleParameter = New OracleParameter("c", OracleDbType.Int32)
    p1.Direction = ParameterDirection.Input
    p1.Value = testArray

    oraCmd.Parameters.Add(p1)

    Try
      oraConn.Open()

      '// This should throw an exception
      oraCmd.ExecuteNonQuery()
    Catch ex As OracleException
      Console.WriteLine("Caught OracleException:")
      Console.WriteLine("  DataSource: " + ex.DataSource)
      Console.WriteLine("  Errors Count: " + ex.Errors.Count.ToString())
      Console.WriteLine("  Message: " + ex.Message)
      Console.WriteLine("  Number: " + ex.Number.ToString())
      Console.WriteLine("  Procedure: " + ex.Procedure)
      Console.WriteLine("  Source: " + ex.Source)
      Console.WriteLine()

      '// iterate through the error collection and
      '// display properties for each error object
      '// to the console.
      For i As Integer = 0 To ex.Errors.Count - 1
        Console.WriteLine("ErrorCollection({0}):", i)
        Console.WriteLine("  ArrayBindIndex: " + ex.Errors(i).ArrayBindIndex.ToString())
        Console.WriteLine("  DataSource: " + ex.Errors(i).DataSource)
        Console.WriteLine("  Message: " + ex.Errors(i).Message)
        Console.WriteLine("  Number: " + ex.Errors(i).Number.ToString())
        Console.WriteLine("  Procedure: " + ex.Errors(i).Procedure)
        Console.WriteLine("  Source: " + ex.Errors(i).Source)
        Console.WriteLine()
      Next i
    Finally
      If oraConn.State = ConnectionState.Open Then
        oraConn.Close()
      End If
    End Try

    '// explicitly dispose our objects
    p1.Dispose()
    oraCmd.Dispose()
    oraConn.Dispose()
  End Sub

End Module
