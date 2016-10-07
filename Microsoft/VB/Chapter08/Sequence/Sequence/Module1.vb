Imports System
Imports System.Data
Imports System.Data.OracleClient
Module Module1

  Sub Main()
    '// create our standard connection
    Dim connStr As String = "User Id=oranetuser; Password=demo; Data Source=oranet"
    Dim oraConn As OracleConnection = New OracleConnection(connStr)

    oraConn.Open()

    insert_trigger(oraConn)

    insert_notrigger(oraConn)
  End Sub
  Private Sub insert_trigger(ByVal con As OracleConnection)
    '// this method will insert rows using the trigger
    '// to get the values from the sequence

    '// the sql statement to insert a row
    Dim sqlText As String = "insert into environment (env_desc) values (:p1)"

    '// the command object associated with the sql statement
    Dim cmd As OracleCommand = New OracleCommand(sqlText, con)

    '// the parameter objects
    Dim p1 As OracleParameter = New OracleParameter
    p1.Size = 32
    p1.Value = "PROD"

    '// add the parameter to the collection
    cmd.Parameters.Add(p1)

    '// execute the command
    cmd.ExecuteNonQuery()

    '// insert a row for stage
    p1.Value = "STAGE"
    cmd.ExecuteNonQuery()

    '// insert a row for train
    p1.Value = "TRAIN"
    cmd.ExecuteNonQuery()

    '// insert a row for test
    p1.Value = "TEST"
    cmd.ExecuteNonQuery()
  End Sub

  Private Sub insert_notrigger(ByVal con As OracleConnection)
    '// this method will insert rows using sql
    '// to get the values from the sequence

    '// the sql statement to insert a row
    Dim sqlText As String = "insert into environment (env_id, env_desc) values (env_seq.nextval, :p1)"

    '// the command object associated with the sql statement
    Dim cmd As OracleCommand = New OracleCommand(sqlText, con)

    '// the parameter objects
    Dim p1 As OracleParameter = New OracleParameter
    p1.Size = 32
    p1.Value = "DEV"

    '// add the parameter to the collection
    cmd.Parameters.Add(p1)

    '// execute the command
    cmd.ExecuteNonQuery()

    '// insert a row for sandbox
    p1.Value = "SAND"
    cmd.ExecuteNonQuery()

    '// insert a row for evaluation
    p1.Value = "EVAL"
    cmd.ExecuteNonQuery()

    '// insert a row for disaster recovery
    p1.Value = "DR"
    cmd.ExecuteNonQuery()
  End Sub
End Module
