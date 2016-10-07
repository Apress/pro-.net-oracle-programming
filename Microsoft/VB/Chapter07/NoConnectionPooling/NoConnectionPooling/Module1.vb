Imports System
Imports System.Data
Imports System.Data.OracleClient
Module Module1

  Sub Main()
    '// create a connection string to our standard database
    '// the pooling=false attribute disables connection pooling
    Dim l_connect As String = "User Id=oranetuser; Password=demo; Data Source=oranet; pooling=false"

    Dim conn_1 As OracleConnection = New OracleConnection(l_connect)
    conn_1.Open()

    '// pause so we can monitor connection in
    '// SQL*Plus
    Console.WriteLine("Connection 1 created... Examine in SQL*Plus")
    Console.ReadLine()

    conn_1.Dispose()

    '// pause so we can monitor connection in
    '// SQL*Plus
    Console.WriteLine("Connection 1 disposed... Examine in SQL*Plus")
    Console.ReadLine()

    Dim conn_2 As OracleConnection = New OracleConnection(l_connect)
    conn_2.Open()

    '// pause so we can monitor connection in
    '// SQL*Plus
    Console.WriteLine("Connection 2 created... Examine in SQL*Plus")
    Console.ReadLine()

    conn_2.Dispose()

    '// pause so we can monitor connection in
    '// SQL*Plus
    Console.WriteLine("Connection 2 disposed... Examine in SQL*Plus")
    Console.ReadLine()
  End Sub

End Module
