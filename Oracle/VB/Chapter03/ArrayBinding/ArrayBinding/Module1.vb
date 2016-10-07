Imports System
Imports System.Data
Imports Oracle.DataAccess.Client

Module Module1

  Sub Main()
    '// our standard connect string
    Dim connStr As String = "User Id=oranetuser; Password=demo; Data Source=oranet"

    '// create the connection
    Dim oraConn As OracleConnection = New OracleConnection(connStr)

    '// open the connection to the database
    oraConn.Open()

    '// call our helper method to insert using array binding
    arrayInsert(oraConn)

    '// call our helper method to update using array binding
    arrayUpdate(oraConn)

    '// call our helper method to delete using array binding
    arrayDelete(oraConn)

    '// explicitly close the connection
    oraConn.Close()

    '// explicitly dispose the connection object
    oraConn.Dispose()
  End Sub

  Private Sub arrayInsert(ByVal con As OracleConnection)
    '// used to load array values
    Dim i As Integer

    '// sql statement to insert our array values
    Dim sqlInsert As String = "insert into array_test (c1, c2, c3) "
    sqlInsert += "values (:c1, :c2, :c3)"

    '// create and populate array for column 1
    Dim c1_vals(1024) As Integer

    For i = 0 To 1023
      c1_vals(i) = i
    Next i

    '// create and populate array for column 2
    Dim c2_vals(1024) As String

    For i = 0 To 1023
      c2_vals(i) = "Column 2 Row " + i.ToString()
    Next i

    '// create and populate array for column 3
    Dim c3_vals(1024) As String

    For i = 0 To 1023
      c3_vals(i) = "Column 3 Row " + i.ToString()
    Next i

    '// create parameter for column 1
    Dim c1 As OracleParameter = New OracleParameter
    c1.OracleDbType = OracleDbType.Decimal
    c1.Value = c1_vals

    '// create parameter for column 2
    Dim c2 As OracleParameter = New OracleParameter
    c2.OracleDbType = OracleDbType.Varchar2
    c2.Value = c2_vals

    '// create parameter for column 3
    Dim c3 As OracleParameter = New OracleParameter
    c3.OracleDbType = OracleDbType.Varchar2
    c3.Value = c3_vals

    '// create the command object
    Dim cmdInsert As OracleCommand = New OracleCommand
    cmdInsert.Connection = con
    cmdInsert.CommandText = sqlInsert
    cmdInsert.ArrayBindCount = c1_vals.Length

    '// add the parameters to the collection
    cmdInsert.Parameters.Add(c1)
    cmdInsert.Parameters.Add(c2)
    cmdInsert.Parameters.Add(c3)

    '// insert all 1024 rows in one round trip
    cmdInsert.ExecuteNonQuery()
  End Sub

  Private Sub arrayUpdate(ByVal con As OracleConnection)
    '// we will update the "lower" 512 rows in the array_test table

    '// used to load array values
    Dim i As Integer

    '// sql statement to update our array values
    Dim sqlUpdate As String = "update array_test set c1 = :p1 where c1 = :p2"

    '// create and populate array for new column 1 values
    Dim c1_new(512) As Integer

    For i = 0 To 511
      c1_new(i) = i + 2000
    Next i

    '// create and populate array for existing column 2 values
    Dim c1_old(512) As Integer

    For i = 0 To 511
      c1_old(i) = i
    Next i

    '// create parameter for new column 1 values
    Dim p1 As OracleParameter = New OracleParameter
    p1.OracleDbType = OracleDbType.Decimal
    p1.Value = c1_new

    '// create parameter for old column 1 values
    Dim p2 As OracleParameter = New OracleParameter
    p2.OracleDbType = OracleDbType.Decimal
    p2.Value = c1_old

    '// create the command object
    Dim cmdInsert As OracleCommand = New OracleCommand
    cmdInsert.Connection = con
    cmdInsert.CommandText = sqlUpdate
    cmdInsert.ArrayBindCount = c1_new.Length

    '// add the parameters to the collection
    cmdInsert.Parameters.Add(p1)
    cmdInsert.Parameters.Add(p2)

    '// update 512 rows in one round trip
    cmdInsert.ExecuteNonQuery()
  End Sub

  Private Sub arrayDelete(ByVal con As OracleConnection)
    '// delete the rows that we did not update

    '// used to load array values
    Dim i As Integer

    '// sql statement to delete our array values
    Dim sqlDelete As String = "delete from array_test where c1 = :p1"

    '// create and populate array for column 1 values
    '// that we did not update
    Dim c1_vals(512) As Integer

    For i = 512 To 1023
      c1_vals(i - 512) = i
    Next i

    '// create parameter for column 1 values
    Dim p1 As OracleParameter = New OracleParameter
    p1.OracleDbType = OracleDbType.Decimal
    p1.Value = c1_vals

    '// create the command object
    Dim cmdInsert As OracleCommand = New OracleCommand
    cmdInsert.Connection = con
    cmdInsert.CommandText = sqlDelete
    cmdInsert.ArrayBindCount = c1_vals.Length

    '// add the parameters to the collection
    cmdInsert.Parameters.Add(p1)

    '// delete 512 rows in one round trip
    cmdInsert.ExecuteNonQuery()
  End Sub
End Module
