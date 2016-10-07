Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Module Module1

  Sub Main()
    '// our "default" database connection string
    Dim conn_1 As String = "User Id=/"

    '// our "tns alias" database connection string
    Dim conn_2 As String = "User Id=/; Data Source=oranet"

    '// our "who am i?" query
    Dim l_sql As String = "select a.username, b.global_name database from user_users a, global_name b"

    Console.WriteLine("Using the default database...")
    authenticationTest(conn_1, l_sql)

    Console.WriteLine("Using the tns alias...")
    authenticationTest(conn_2, l_sql)
  End Sub
  Private Sub authenticationTest(ByVal p_connect As String, ByVal p_sql As String)
    '// a simple little helper method
    '// gets a connection, executes the sql statement,
    '// and prints the results to the console
    Dim oraCmd As OracleCommand
    Dim oraReader As OracleDataReader

    Dim oraConn As OracleConnection = New OracleConnection(p_connect)

    Try
      oraConn.Open()

      oraCmd = New OracleCommand(p_sql, oraConn)

      oraReader = oraCmd.ExecuteReader()

      While oraReader.Read()
        Console.WriteLine("User: ")
        Console.WriteLine("  " + oraReader.GetString(0))
        Console.WriteLine("Database: ")
        Console.WriteLine("  " + oraReader.GetString(1) + vbCrLf)
      End While
    Catch ex As Exception
      Console.WriteLine("Error occured: " + ex.Message)
    Finally
      If oraConn.State = System.Data.ConnectionState.Open Then
        oraConn.Close()
      End If
    End Try
  End Sub
End Module

