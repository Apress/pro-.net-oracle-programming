Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Module Module1

  Sub Main()
    '// create our standard connection
    Dim connStr As String = "User Id=oranetuser; Password=demo; Data Source=oranet"
    Dim oraConn As OracleConnection = New OracleConnection(connStr)

    oraConn.Open()

    '// call the helper methods
    Console.WriteLine("Invoking ref cursor function...")
    call_function(oraConn)

    Console.WriteLine("Invoking ref cursor procedure...")
    call_procedure(oraConn)

    oraConn.Close()

    oraConn.Dispose()
  End Sub
  Private Sub call_function(ByVal con As OracleConnection)
    '// create the command object and set attributes
    Dim cmd As OracleCommand = New OracleCommand("league_rc.get_table", con)
    cmd.CommandType = CommandType.StoredProcedure

    '// create parameter object for the cursor
    Dim p_refcursor As OracleParameter = New OracleParameter

    '// this is vital to set when using ref cursors
    p_refcursor.OracleDbType = OracleDbType.RefCursor
    p_refcursor.Direction = ParameterDirection.ReturnValue

    cmd.Parameters.Add(p_refcursor)

    Dim reader As OracleDataReader = cmd.ExecuteReader()

    While reader.Read()
      Console.Write(reader.GetDecimal(0).ToString() + ",")
      Console.Write(reader.GetString(1) + ",")
      Console.Write(reader.GetDecimal(2).ToString() + ",")
      Console.Write(reader.GetDecimal(3).ToString() + ",")
      Console.Write(reader.GetDecimal(4).ToString() + ",")
      Console.Write(reader.GetDecimal(5).ToString() + ",")
      Console.Write(reader.GetDecimal(6).ToString() + ",")
      Console.WriteLine(reader.GetDecimal(7).ToString())
    End While

    Console.WriteLine()

    reader.Close()
    reader.Dispose()
    p_refcursor.Dispose()
    cmd.Dispose()
  End Sub

  Private Sub call_procedure(ByVal con As OracleConnection)
    '// create the command object and set attributes
    Dim cmd As OracleCommand = New OracleCommand("league_rc.get_table", con)
    cmd.CommandType = CommandType.StoredProcedure

    '// create parameter object for the cursor
    Dim p_refcursor As OracleParameter = New OracleParameter

    '// this is vital to set when using ref cursors
    p_refcursor.OracleDbType = OracleDbType.RefCursor
    p_refcursor.Direction = ParameterDirection.Output

    cmd.Parameters.Add(p_refcursor)

    Dim reader As OracleDataReader = cmd.ExecuteReader()

    While reader.Read()
      Console.Write(reader.GetDecimal(0).ToString() + ",")
      Console.Write(reader.GetString(1) + ",")
      Console.Write(reader.GetDecimal(2).ToString() + ",")
      Console.Write(reader.GetDecimal(3).ToString() + ",")
      Console.Write(reader.GetDecimal(4).ToString() + ",")
      Console.Write(reader.GetDecimal(5).ToString() + ",")
      Console.Write(reader.GetDecimal(6).ToString() + ",")
      Console.WriteLine(reader.GetDecimal(7).ToString())
    End While

    Console.WriteLine()

    reader.Close()
    reader.Dispose()
    p_refcursor.Dispose()
    cmd.Dispose()
  End Sub
End Module
