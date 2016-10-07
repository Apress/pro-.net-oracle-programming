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

    '// this command will attempt to gather statistics on a table
    '// that does not exist in our schema.  this will cause an
    '// exception to be thrown.
    Dim l_sql As String = "begin "
    l_sql += "dbms_stats.gather_table_stats("
    l_sql += "ownname=>'ORANETUSER',tabname=>'DOES_NOT_EXIST');"
    l_sql += "end;"

    Dim oraCmd As OracleCommand = New OracleCommand(l_sql, oraConn)

    Try
      oraConn.Open()

      oraCmd.ExecuteNonQuery()
    Catch ex As OracleException
      '// Now that we have an OracleException, we can
      '// get the error object.
      Dim theError As OracleError = ex.Errors(0)

      '// Write the properties to the console as we did
      '// with the OracleException.  The values here will
      '// be remarkably similar to those in the OracleException
      '// sample code.
      Console.WriteLine("OracleError properties:")
      Console.WriteLine("  ArrayBindIndex: " + theError.ArrayBindIndex.ToString())
      Console.WriteLine("  DataSource: " + theError.DataSource)
      Console.WriteLine("  Message: " + theError.Message)
      Console.WriteLine("  Number: " + theError.Number.ToString())
      Console.WriteLine("  Procedure: " + theError.Procedure)
      Console.WriteLine("  Source: " + theError.Source)
      Console.WriteLine()
    Finally
      If oraConn.State = ConnectionState.Open Then
        oraConn.Close()
      End If
    End Try

    oraConn.Dispose()
  End Sub

End Module
