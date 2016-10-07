Imports System
Imports System.Data
Imports System.Data.OracleClient
Module Module1

  Sub Main()
    '// create a connection to the HR schema
    Dim connStr As String = "User Id=hr; Password=demo; Data Source=oranet"
    Dim oraConn As OracleConnection = New OracleConnection(connStr)

    '// the sql statement to get the top 3 salaries
    Dim sql As String = "select * "
    sql += "from  (select department_id, "
    sql += "              dense_rank() over (partition by department_id "
    sql += "                                 order by salary desc) rank, "
    sql += "              first_name || ' ' || last_name EMPLOYEE, "
    sql += "              salary "
    sql += "       from   employees) "
    sql += "where rank <= 3"

    '// open the database connection
    oraConn.Open()

    '// create a command object
    Dim cmd As OracleCommand = New OracleCommand(sql, oraConn)

    '// create a data reader from the command object
    Dim dataReader As OracleDataReader = cmd.ExecuteReader()

    '// the number of fields in the result set
    Dim fieldCount As Integer = dataReader.FieldCount

    '// output a header line
    Console.WriteLine("Department,Rank,Employee,Salary")

    '// for each row in the result set
    '// this is code that we used in chapter 2
    While dataReader.Read()
      For i As Integer = 0 To fieldCount - 1
        If Not dataReader.IsDBNull(i) Then
          Console.Write(dataReader(i).ToString())
        Else
          '// null value
          Console.Write("(null)")
        End If

        If i < fieldCount - 1 Then
          Console.Write(",")
        End If
      Next i
      Console.WriteLine()
    End While


    '// explicitly close and dispose objects
    dataReader.Close()
    dataReader.Dispose()
    cmd.Dispose()
    oraConn.Close()
    oraConn.Dispose()
  End Sub

End Module
