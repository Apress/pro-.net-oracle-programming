Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Module Module1

  Sub Main()
    '// our standard connect string
    Dim connStr As String = "User Id=oranetuser; Password=demo; Data Source=oranet"

    '// create the connection
    Dim oraConn As OracleConnection = New OracleConnection(connStr)

    '// open the connection to the database
    oraConn.Open()

    '// call helper method to illustrate rolling back
    testRollback(oraConn)

    '// call helper method to illustrate committing
    testCommit(oraConn)

    '// call helper method to illustrate multiple actions
    testMultiple(oraConn)

    '// explicitly close the connection
    oraConn.Close()

    '// explicitly dispose the connection object
    oraConn.Dispose()
  End Sub
  Private Sub testRollback(ByVal con As OracleConnection)
    '// sql statement to add :amount units to the balance
    '// for acct_id :acct_id
    Dim sqlUpdate As String = "update trans_test "
    sqlUpdate += "set balance = balance + :amount "
    sqlUpdate += "where acct_id = :acct_id"

    '// sql statement to verify that our session can "see"
    '// the updated data
    Dim sqlSelect As String = "select acct_id, balance "
    sqlSelect += "from trans_test "
    sqlSelect += "where acct_id = :acct_id"

    '// create parameter for balance
    Dim amount As OracleParameter = New OracleParameter
    amount.OracleDbType = OracleDbType.Decimal
    amount.Precision = 12
    amount.Scale = 2
    amount.Value = 500

    '// create parameter for acct_id
    Dim acct_id As OracleParameter = New OracleParameter
    acct_id.OracleDbType = OracleDbType.Decimal
    acct_id.Precision = 2
    acct_id.Value = 2

    '// create the command object for the update
    Dim cmdUpdate As OracleCommand = New OracleCommand
    cmdUpdate.Connection = con
    cmdUpdate.CommandText = sqlUpdate

    '// add the parameters to the collection
    cmdUpdate.Parameters.Add(amount)
    cmdUpdate.Parameters.Add(acct_id)

    '// Explicitly begin a transaction
    Dim trans As OracleTransaction = con.BeginTransaction()

    '// update the balance, but will not automatically commit
    cmdUpdate.ExecuteNonQuery()

    '// at this point the update has actually happened
    '// in the database and will be visible to our session only
    '// we will illustrate how we can see this from our session
    '// but not from another session
    Dim cmdSelect As OracleCommand = New OracleCommand
    cmdSelect.Connection = con
    cmdSelect.CommandText = sqlSelect

    '// create parameter for acct_id
    '// can't reuse the parameter from above
    '// because it still belongs to the parameter
    '// collection for the update command object
    Dim acct_id2 As OracleParameter = New OracleParameter
    acct_id2.OracleDbType = OracleDbType.Decimal
    acct_id2.Precision = 2
    acct_id2.Value = 2

    '// add the parameters to the collection
    cmdSelect.Parameters.Add(acct_id2)

    '// get a data reader from the command object
    Dim reader As OracleDataReader = cmdSelect.ExecuteReader()

    '// display the acct_id and balance
    '// balance should be 1500 for acct_id 2
    If reader.Read() Then
      Console.WriteLine("Update has taken place, but not been committed...")
      Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString())
      Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString())
      Console.WriteLine("Examine in SQL*Plus...")
      Console.ReadLine()
    End If

    '// at this point we have verified that the update did
    '// take place, however it has not been committed.
    '// we will rollback the transaction to prevent it from
    '// being committed.
    trans.Rollback()

    '// close the reader before reusing
    reader.Close()

    '// get the reader again
    reader = cmdSelect.ExecuteReader()

    '// display the acct_id and balance
    '// balance should now be 1000 for acct_id 2
    '// since we rolled back the transaction
    If reader.Read() Then
      Console.WriteLine()
      Console.WriteLine("Update has taken place, and rolled back...")
      Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString())
      Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString())
      Console.WriteLine("Examine in SQL*Plus...")
      Console.ReadLine()
    End If
  End Sub

  Private Sub testCommit(ByVal con As OracleConnection)
    '// sql statement to add :amount units to the balance
    '// for acct_id :acct_id
    Dim sqlUpdate As String = "update trans_test "
    sqlUpdate += "set balance = balance + :amount "
    sqlUpdate += "where acct_id = :acct_id"

    '// sql statement to verify that our session can "see"
    '// the updated data
    Dim sqlSelect As String = "select acct_id, balance "
    sqlSelect += "from trans_test "
    sqlSelect += "where acct_id = :acct_id"

    '// create parameter for balance
    Dim amount As OracleParameter = New OracleParameter
    amount.OracleDbType = OracleDbType.Decimal
    amount.Precision = 12
    amount.Scale = 2
    amount.Value = 500

    '// create parameter for acct_id
    Dim acct_id As OracleParameter = New OracleParameter
    acct_id.OracleDbType = OracleDbType.Decimal
    acct_id.Precision = 2
    acct_id.Value = 2

    '// create the command object for the update
    Dim cmdUpdate As OracleCommand = New OracleCommand
    cmdUpdate.Connection = con
    cmdUpdate.CommandText = sqlUpdate

    '// add the parameters to the collection
    cmdUpdate.Parameters.Add(amount)
    cmdUpdate.Parameters.Add(acct_id)

    '// Explicitly begin a transaction
    Dim trans As OracleTransaction = con.BeginTransaction()

    '// update the balance, but will not automatically commit
    cmdUpdate.ExecuteNonQuery()

    '// at this point the update has actually happened
    '// in the database and will be visible to our session only
    '// we will illustrate how we can see this from our session
    '// but not from another session
    Dim cmdSelect As OracleCommand = New OracleCommand
    cmdSelect.Connection = con
    cmdSelect.CommandText = sqlSelect

    '// create parameter for acct_id
    '// can't reuse the parameter from above
    '// because it still belongs to the parameter
    '// collection for the update command object
    Dim acct_id2 As OracleParameter = New OracleParameter
    acct_id2.OracleDbType = OracleDbType.Decimal
    acct_id2.Precision = 2
    acct_id2.Value = 2

    '// add the parameters to the collection
    cmdSelect.Parameters.Add(acct_id2)

    '// get a data reader from the command object
    Dim reader As OracleDataReader = cmdSelect.ExecuteReader()

    '// display the acct_id and balance
    '// balance should be 1500 for acct_id 2
    If reader.Read() Then
      Console.WriteLine()
      Console.WriteLine("Update has taken place, but not been committed...")
      Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString())
      Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString())
    End If

    '// at this point we have verified that the update did
    '// take place, however it has not been committed.
    '// we will commit the transaction making it "permanent"
    trans.Commit()

    '// close the reader before reusing
    reader.Close()

    '// get the reader again
    reader = cmdSelect.ExecuteReader()

    '// display the acct_id and balance
    '// balance should still be 1500 for acct_id 2
    '// since we committed the transaction
    If reader.Read() Then
      Console.WriteLine()
      Console.WriteLine("Update has taken place, and been committed...")
      Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString())
      Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString())
      Console.WriteLine()
      Console.WriteLine("Examine in SQL*Plus...")
      Console.ReadLine()
    End If
  End Sub

  Private Sub testMultiple(ByVal con As OracleConnection)
    '// sql statement to add :amount units to the balance
    '// for acct_id :acct_id
    '// :amount may be a negative number
    Dim sqlUpdate As String = "update trans_test "
    sqlUpdate += "set balance = balance + :amount "
    sqlUpdate += "where acct_id = :acct_id"

    '// sql statement to verify that our session can "see"
    '// the updated data
    Dim sqlSelect As String = "select acct_id, balance "
    sqlSelect += "from trans_test "
    sqlSelect += "where acct_id = :acct_id"

    '// create parameter for amount/balance
    Dim amount As OracleParameter = New OracleParameter
    amount.OracleDbType = OracleDbType.Decimal
    amount.Precision = 12
    amount.Scale = 2
    amount.Value = -5000

    '// create parameter for acct_id
    Dim acct_id As OracleParameter = New OracleParameter
    acct_id.OracleDbType = OracleDbType.Decimal
    acct_id.Precision = 2
    acct_id.Value = 1

    '// create second parameter for acct_id
    Dim acct_id2 As OracleParameter = New OracleParameter
    acct_id2.OracleDbType = OracleDbType.Decimal
    acct_id2.Precision = 2
    acct_id2.Value = 1

    '// create the command object for the update
    Dim cmdUpdate As OracleCommand = New OracleCommand
    cmdUpdate.Connection = con
    cmdUpdate.CommandText = sqlUpdate

    '// add the parameters to the collection
    cmdUpdate.Parameters.Add(amount)
    cmdUpdate.Parameters.Add(acct_id)

    '// Explicitly begin a transaction
    Dim trans As OracleTransaction = con.BeginTransaction()

    '// update the balance, but will not automatically commit
    cmdUpdate.ExecuteNonQuery()

    '// at this point the update has actually happened
    '// in the database and will be visible to our session only
    Dim cmdSelect As OracleCommand = New OracleCommand
    cmdSelect.Connection = con
    cmdSelect.CommandText = sqlSelect

    '// add the parameters to the collection
    cmdSelect.Parameters.Add(acct_id2)

    '// get a data reader from the command object
    Dim reader As OracleDataReader = cmdSelect.ExecuteReader()

    '// display the acct_id and balance
    '// balance should be 5000 for acct_id 1
    If reader.Read() Then
      Console.WriteLine()
      Console.WriteLine("Update has taken place, but not been committed...")
      Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString())
      Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString())
    End If

    '// execute the update again
    '// this will cause the balance to become negative
    '// a business rule would be needed to determine if
    '// this is acceptable
    '// the end result of the 3 actions is a positive number
    amount.Value = -7000
    cmdUpdate.ExecuteNonQuery()

    '// close the reader before reusing
    reader.Close()

    '// get the reader again
    reader = cmdSelect.ExecuteReader()

    '// display the acct_id and balance
    '// balance should be -2000 for acct_id 1
    If reader.Read() Then
      Console.WriteLine()
      Console.WriteLine("Update has taken place, but not been committed...")
      Console.WriteLine("The balance has become negative, but the transaction")
      Console.WriteLine("has not been committed so this may be acceptable")
      Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString())
      Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString())
    End If

    '// execute the update again
    amount.Value = 3000
    cmdUpdate.ExecuteNonQuery()

    '// we will commit the transaction making it "permanent"
    trans.Commit()

    '// close the reader before reusing
    reader.Close()

    '// get the reader again
    reader = cmdSelect.ExecuteReader()

    '// display the acct_id and balance
    '// balance should be 1000 for acct_id 1
    If reader.Read() Then
      Console.WriteLine()
      Console.WriteLine("Update has taken place, and been committed...")
      Console.WriteLine("Acct ID: " + reader.GetDecimal(0).ToString())
      Console.WriteLine("Balance: " + reader.GetDecimal(1).ToString())
    End If
  End Sub
End Module
