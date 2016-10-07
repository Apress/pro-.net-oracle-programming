Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Module Module1

  Sub Main()
    '// Use the default database by omitting the Data Source connect
    '// string attribute.
    Dim connString As String = "User Id=oranetuser;Password=demo"
    Dim oraConn As OracleConnection = New OracleConnection(connString)

    Try
      oraConn.Open()

      Console.WriteLine("\nHello, Default Oracle Database Here!" + vbCrLf)
      Console.WriteLine("Connection String: ")
      Console.WriteLine(oraConn.ConnectionString.ToString() + vbCrLf)
      Console.WriteLine("Current Connection State: ")
      Console.WriteLine(oraConn.State.ToString() + vbCrLf)
      Console.WriteLine("Oracle Database Server Version: ")
      Console.WriteLine(oraConn.ServerVersion.ToString())
    Catch ex As Exception
      Console.WriteLine("Error occured: " + ex.Message)
    Finally
      If oraConn.State = System.Data.ConnectionState.Open Then
        oraConn.Close()
      End If
    End Try
  End Sub

End Module
