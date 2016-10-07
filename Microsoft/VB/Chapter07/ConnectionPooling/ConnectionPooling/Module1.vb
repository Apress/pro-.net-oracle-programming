Imports System
Imports System.data
Imports System.Data.OracleClient
Module Module1

  Sub Main()
    '// create a connection string to our standard database
    '// the pooling attribute defaults to "true" so we
    '// do not need to include it to enable pooling
    Dim l_connect As String = "User Id=oranetuser; Password=demo; Data Source=oranet;"

    Dim conn_1 As OracleConnection = New OracleConnection(l_connect)
    conn_1.Open()

    '// pause so we can monitor connection in
    '// SQL*Plus
    Console.WriteLine("Connection 1 created... Hit enter key")
    Console.ReadLine()

    conn_1.Dispose()

    '// pause so we can monitor connection in
    '// SQL*Plus
    Console.WriteLine("Connection 1 disposed... Hit enter key")
    Console.ReadLine()

    Dim conn_2 As OracleConnection = New OracleConnection(l_connect)
    conn_2.Open()

    '// pause so we can monitor connection in
    '// SQL*Plus
    Console.WriteLine("Connection 2 created... Hit enter key")
    Console.ReadLine()

    conn_2.Dispose()

    '// pause so we can monitor connection in
    '// SQL*Plus
    Console.WriteLine("Connection 2 disposed... Hit enter key")
    Console.ReadLine()
  End Sub

End Module
