Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Module Module1

  Sub Main()
    '// create a connection object
    Dim connstr As String = "User Id=scott; Password=tiger; Data Source=oranet"
    Dim con As OracleConnection = New OracleConnection

    '// set the connection string
    con.ConnectionString = connstr

    '// display the ConnectionString property to the console
    '// this will show the password
    Console.WriteLine("Connection String 1: {0}", con.ConnectionString)

    '// open the connection
    con.Open()

    '// display the ConnectionString property to the console
    '// this will not show the password
    Console.WriteLine("Connection String 2: {0}", con.ConnectionString)

    '// close the connection
    con.Close()

    '// display the ConnectionString property to the console
    '// this will not show the password
    Console.WriteLine("Connection String 3: {0}", con.ConnectionString)

    '// clean up the connection object
    con.Dispose()
  End Sub

End Module
