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
    Console.WriteLine("Truncating table...")
    truncate_table(oraConn)
    Console.WriteLine("Completed truncating table...")
    Console.WriteLine()

    Console.WriteLine("Executing associative insert...")
    associative_insert(oraConn)
    Console.WriteLine("Completed associative insert...")
    Console.WriteLine()

    Console.WriteLine("Executing associative select...")
    associative_select(oraConn)
    Console.WriteLine("Completed associative select...")

    oraConn.Close()

    oraConn.Dispose()
  End Sub
  Private Sub truncate_table(ByVal con As OracleConnection)
    '// a very simple helper method to truncate the
    '// league_results table
    '// since we will be inserting data that would
    '// violate the primary key otherwise

    '// create the command object and set attributes
    Dim cmd As OracleCommand = New OracleCommand("truncate table league_results", con)

    cmd.ExecuteNonQuery()
  End Sub

  Private Sub associative_insert(ByVal con As OracleConnection)
    '// create the command object and set attributes
    Dim cmd As OracleCommand = New OracleCommand("league_associative.bulk_insert", con)
    cmd.CommandType = CommandType.StoredProcedure

    '// create parameter objects for each parameter
    Dim p_position As OracleParameter = New OracleParameter
    Dim p_team As OracleParameter = New OracleParameter
    Dim p_played As OracleParameter = New OracleParameter
    Dim p_wins As OracleParameter = New OracleParameter
    Dim p_draws As OracleParameter = New OracleParameter
    Dim p_losses As OracleParameter = New OracleParameter
    Dim p_goals_for As OracleParameter = New OracleParameter
    Dim p_goals_against As OracleParameter = New OracleParameter

    '// set parameter type for each parameter
    p_position.OracleDbType = OracleDbType.Decimal
    p_team.OracleDbType = OracleDbType.Varchar2
    p_played.OracleDbType = OracleDbType.Decimal
    p_wins.OracleDbType = OracleDbType.Decimal
    p_draws.OracleDbType = OracleDbType.Decimal
    p_losses.OracleDbType = OracleDbType.Decimal
    p_goals_for.OracleDbType = OracleDbType.Decimal
    p_goals_against.OracleDbType = OracleDbType.Decimal

    '// set the collection type for each parameter
    p_position.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_team.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_played.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_wins.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_draws.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_losses.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_goals_for.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_goals_against.CollectionType = OracleCollectionType.PLSQLAssociativeArray

    '// set the parameter values
    p_position.Value = New Decimal() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20}

    p_team.Value = New String() {"Arsenal", "Chelsea", "Manchester United", "Liverpool", "Newcastle United", "Aston Villa", "Charlton Athletic", "Bolton Wanderers", "Fulham", "Birmingham City", "Middlesbrough", "Southampton", "Portsmouth", "Tottenham Hotspur", "Blackburn Rovers", "Manchester City", "Everton", "Leicester City", "Leeds United", "Wolverhampton Wanderers"}

    p_played.Value = New Decimal() {38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38}

    p_wins.Value = New Decimal() {26, 24, 23, 16, 13, 15, 14, 14, 14, 12, 13, 12, 12, 13, 12, 9, 9, 6, 8, 7}

    p_draws.Value = New Decimal() {12, 7, 6, 12, 17, 11, 11, 11, 10, 14, 9, 11, 9, 6, 8, 14, 12, 15, 9, 12}

    p_losses.Value = New Decimal() {0, 7, 9, 10, 8, 12, 13, 12, 14, 12, 16, 15, 17, 19, 18, 15, 17, 17, 21, 19}

    p_goals_for.Value = New Decimal() {73, 67, 64, 55, 52, 48, 51, 48, 52, 43, 44, 44, 47, 47, 51, 55, 45, 48, 40, 38}

    p_goals_against.Value = New Decimal() {26, 30, 35, 37, 40, 44, 51, 56, 46, 48, 52, 45, 54, 57, 59, 54, 57, 65, 79, 77}

    '// set the size for each array
    p_position.Size = 20
    p_team.Size = 20
    p_played.Size = 20
    p_wins.Size = 20
    p_draws.Size = 20
    p_losses.Size = 20
    p_goals_for.Size = 20
    p_goals_against.Size = 20

    '// set array bind size for the team column since it
    '// is a variable size type (varchar2)
    p_team.ArrayBindSize = New Integer() {32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32}

    '// add the parameters to the command object
    cmd.Parameters.Add(p_position)
    cmd.Parameters.Add(p_team)
    cmd.Parameters.Add(p_played)
    cmd.Parameters.Add(p_wins)
    cmd.Parameters.Add(p_draws)
    cmd.Parameters.Add(p_losses)
    cmd.Parameters.Add(p_goals_for)
    cmd.Parameters.Add(p_goals_against)

    '// execute the insert
    cmd.ExecuteNonQuery()
  End Sub

  Private Sub associative_select(ByVal con As OracleConnection)
    '// create the command object and set attributes
    Dim cmd As OracleCommand = New OracleCommand("league_associative.bulk_select", con)
    cmd.CommandType = CommandType.StoredProcedure

    '// create parameter objects for each parameter
    Dim p_position As OracleParameter = New OracleParameter
    Dim p_team As OracleParameter = New OracleParameter
    Dim p_played As OracleParameter = New OracleParameter
    Dim p_wins As OracleParameter = New OracleParameter
    Dim p_draws As OracleParameter = New OracleParameter
    Dim p_losses As OracleParameter = New OracleParameter
    Dim p_goals_for As OracleParameter = New OracleParameter
    Dim p_goals_against As OracleParameter = New OracleParameter

    '// set parameter type for each parameter
    p_position.OracleDbType = OracleDbType.Decimal
    p_team.OracleDbType = OracleDbType.Varchar2
    p_played.OracleDbType = OracleDbType.Decimal
    p_wins.OracleDbType = OracleDbType.Decimal
    p_draws.OracleDbType = OracleDbType.Decimal
    p_losses.OracleDbType = OracleDbType.Decimal
    p_goals_for.OracleDbType = OracleDbType.Decimal
    p_goals_against.OracleDbType = OracleDbType.Decimal

    '// set the collection type for each parameter
    p_position.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_team.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_played.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_wins.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_draws.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_losses.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_goals_for.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    p_goals_against.CollectionType = OracleCollectionType.PLSQLAssociativeArray

    '// set the direct for each parameter
    p_position.Direction = ParameterDirection.Output
    p_team.Direction = ParameterDirection.Output
    p_played.Direction = ParameterDirection.Output
    p_wins.Direction = ParameterDirection.Output
    p_draws.Direction = ParameterDirection.Output
    p_losses.Direction = ParameterDirection.Output
    p_goals_for.Direction = ParameterDirection.Output
    p_goals_against.Direction = ParameterDirection.Output

    '// set the parameter values to null initially
    'p_position.Value = Nothing
    'p_team.Value = Nothing
    'p_played.Value = Nothing
    'p_wins.Value = Nothing
    'p_draws.Value = Nothing
    'p_losses.Value = Nothing
    'p_goals_for.Value = Nothing
    'p_goals_against.Value = Nothing

    '// set the size for each array
    p_position.Size = 20
    p_team.Size = 20
    p_played.Size = 20
    p_wins.Size = 20
    p_draws.Size = 20
    p_losses.Size = 20
    p_goals_for.Size = 20
    p_goals_against.Size = 20

    '// set array bind size for the team column since it
    '// is a variable size type (varchar2)
    p_team.ArrayBindSize = New Integer() {32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32}

    '// add the parameters to the command object
    cmd.Parameters.Add(p_position)
    cmd.Parameters.Add(p_team)
    cmd.Parameters.Add(p_played)
    cmd.Parameters.Add(p_wins)
    cmd.Parameters.Add(p_draws)
    cmd.Parameters.Add(p_losses)
    cmd.Parameters.Add(p_goals_for)
    cmd.Parameters.Add(p_goals_against)

    '// execute the insert
    cmd.ExecuteNonQuery()

    '// display as comma separated list
    '// field_count is used to determine when
    '// we have completed a "line"
    Dim field_count As Integer = 1
    Dim p As OracleParameter
    For i As Integer = 0 To p_position.Size - 1
      For Each p In cmd.Parameters
        If TypeOf p.Value Is OracleDecimal() Then
          Console.Write(Convert.ToString(p.Value(i)))
        End If
        If TypeOf p.Value Is OracleString() Then
          Console.Write(p.Value(i))
        End If

        If field_count < 8 Then
          Console.Write(",")
        Else
          field_count = 0
        End If

        field_count += 1
      Next p
      Console.WriteLine()
    Next i
  End Sub
End Module
