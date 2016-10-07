Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Module Module1

  Sub Main(ByVal CmdArgs() As String)
    If CmdArgs.Length <> 4 Then
      Console.WriteLine("Incorrect number of command line parameters.")

      Return
    End If

    '// Build a connect string based on the command line parameters
    Dim connString As String = "User Id=" + CmdArgs(0).ToString() + ";"
    connString += "Password=" + CmdArgs(1).ToString() + ";"
    connString += "Data Source=" + CmdArgs(2).ToString()

    Dim oraConn As OracleConnection = New OracleConnection
    oraConn.ConnectionString = connString

    '// build the sql statement based on the command line parameter
    Dim sqlStatement As String = "select * from " + CmdArgs(3).ToString()

    '// the number of fields in the result set
    Dim fieldCount As Integer = 0

    '// used in our counter loops
    Dim i As Integer = 0

    Try
      oraConn.Open()
    Catch ex As Exception
      Console.WriteLine("Exception caught {0}", ex.Message)
    End Try

    If oraConn.State = ConnectionState.Open Then
      Try
        '// create the command object
        Dim cmdSQL As OracleCommand = New OracleCommand(sqlStatement, oraConn)

        '// get a data reader
        Dim dataReader As OracleDataReader = cmdSQL.ExecuteReader()

        '// the number of fields in the result set
        fieldCount = dataReader.FieldCount

        '// output a comma separated header
        For i = 0 To fieldCount
          Console.Write(dataReader.GetName(i))

          If i < (fieldCount - 1) Then
            Console.Write(",")
          End If
        Next i

        Console.WriteLine()

        '// output a comma separated "line" of data
        While (dataReader.Read())
          For i = 0 To fieldCount
            '// check if the data is null or not
            If Not dataReader.IsDBNull(i) Then
              '// not null, so write value
              '// we use the "item" method by
              '// specifying the index rather than
              '// using a typed accessor
              Console.Write(dataReader(i).ToString())
            Else
              '// null value
              Console.Write("(null)")

              If i < (fieldCount - 1) Then
                Console.Write(",")
              End If

              Console.WriteLine()
            End If
          Next i
        End While
      Catch ex As Exception
        Console.WriteLine("Exception caught {0}", ex.Message)
      End Try
    End If

    If oraConn.State = ConnectionState.Open Then
      oraConn.Close()
    End If

    oraConn.Dispose()
  End Sub

End Module
