Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Module Module1

  Sub Main()
    oraException1()
    oraException2()
    oraException3()
  End Sub
  Private Sub oraException1()
    '// create a connection string with an incorrect password
    '// this is so an exception is thrown when the connection
    '// is opened
    Dim c1 As String = "User Id=oranetuser;Password=badpass;Data Source=oranet"
    Dim oraConn As OracleConnection = New OracleConnection(c1)

    Try
      '// This will throw an exception since we have
      '// used an incorrect password
      oraConn.Open()
    Catch ex As OracleException
      '// Write the properties to the console
      Console.WriteLine("Caught OracleException #1:")
      Console.WriteLine("  DataSource: " + ex.DataSource)
      Console.WriteLine("  Errors Count: " + ex.Errors.Count.ToString())
      Console.WriteLine("  Message: " + ex.Message)
      Console.WriteLine("  Number: " + ex.Number.ToString())
      Console.WriteLine("  Procedure: " + ex.Procedure)
      Console.WriteLine("  Source: " + ex.Source)
      Console.WriteLine()
    Finally
      If oraConn.State = ConnectionState.Open Then
        oraConn.Close()
      End If
    End Try

    oraConn.Dispose()
  End Sub

  Private Sub oraException2()
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
      '// Write the properties to the console
      Console.WriteLine("Caught OracleException #2:")
      Console.WriteLine("  DataSource: " + ex.DataSource)
      Console.WriteLine("  Errors Count: " + ex.Errors.Count.ToString())
      Console.WriteLine("  Message: " + ex.Message)
      Console.WriteLine("  Number: " + ex.Number.ToString())
      Console.WriteLine("  Procedure: " + ex.Procedure)
      Console.WriteLine("  Source: " + ex.Source)
      Console.WriteLine()
    Finally
      If oraConn.State = ConnectionState.Open Then
        oraConn.Close()
      End If
    End Try

    oraConn.Dispose()
  End Sub

  Private Sub oraException3()
    '// create a connection string using our standard user and
    '// standard tns alias
    Dim c1 As String = "User Id=oranetuser;Password=demo;Data Source=oranet"
    Dim oraConn As OracleConnection = New OracleConnection(c1)

    '// attempt to update the exception_test table.
    '// this update will 'fail' since there are no values
    '// in the table.
    Dim l_sql As String = "update exception_test set c=1 where c=0"

    Dim oraCmd As OracleCommand = New OracleCommand(l_sql, oraConn)

    Try
      oraConn.Open()

      oraCmd.ExecuteNonQuery()
    Catch ex As OracleException
      '// Write the properties to the console
      Console.WriteLine("Caught OracleException #3:")
      Console.WriteLine("  DataSource: " + ex.DataSource)
      Console.WriteLine("  Errors Count: " + ex.Errors.Count.ToString())
      Console.WriteLine("  Message: " + ex.Message)
      Console.WriteLine("  Number: " + ex.Number.ToString())
      Console.WriteLine("  Procedure: " + ex.Procedure)
      Console.WriteLine("  Source: " + ex.Source)
      Console.WriteLine()
    Finally
      If oraConn.State = ConnectionState.Open Then
        oraConn.Close()
      End If
    End Try

    oraConn.Dispose()
  End Sub
End Module
