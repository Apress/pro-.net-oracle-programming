Imports System
Imports System.Data.OracleClient

Module Module1

  Sub Main()
    Dim connString As String = "User Id=oranetuser;Password=demo;Data Source=oranet"
    Dim oraConnection As OracleConnection = New OracleConnection(connString)

    Try
      oraConnection.Open()

      Console.WriteLine(vbCrLf + "Hello, Oracle Here!" + vbCrLf)
      Console.WriteLine("Connection String: ")
      Console.WriteLine(oraConnection.ConnectionString.ToString() + vbCrLf)
      Console.WriteLine("Current Connection State: ")
      Console.WriteLine(oraConnection.State.ToString() + vbCrLf)
      Console.WriteLine("Oracle Database Server Version: ")
      Console.WriteLine(oraConnection.ServerVersion.ToString())
    Catch ex As Exception
      Console.WriteLine("Error occured: " + ex.Message)
    End Try

    If oraConnection.State = System.Data.ConnectionState.Open Then
      oraConnection.Close()
    End If
  End Sub

End Module
