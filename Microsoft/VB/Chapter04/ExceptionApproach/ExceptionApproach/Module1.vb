Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Data.OracleClient

Module Module1

  Sub Main()
    '// create a connection string using our standard user with
    '// an incorrect password. this will throw an error
    Dim c1 As String = "User Id=oranetuser;Password=badpass;Data Source=oranet"
    Dim conn_1 As OracleConnection = New OracleConnection(c1)

    '// create a connection string using our standard user and
    '// standard tns alias
    Dim c2 As String = "User Id=oranetuser;Password=demo;Data Source=oranet"
    Dim conn_2 As OracleConnection = New OracleConnection(c2)

    Dim exceptionInfo As String = ""

    '// try to open a connection with an incorrect password
    '// this will fail, so log to the Application log
    Try
      conn_1.Open()
    Catch ex As OracleException
      exceptionInfo = "Caught OracleException: " + ex.Message + vbCrLf
      exceptionInfo += "Location: Main method, conn_1.open event" + vbCrLf

      writeAppLog(exceptionInfo)

      Console.WriteLine(exceptionInfo)
    Finally
      If conn_1.State = ConnectionState.Open Then
        conn_1.Close()
      End If
    End Try

    conn_1.Dispose()

    '// try to open a connection with the correct connect
    '// information. this should not fail.
    Try
      conn_2.Open()
    Catch ex As OracleException
      exceptionInfo = "Caught OracleException: " + ex.Message + vbCrLf
      exceptionInfo += "Location: Main method, conn_2.open event" + vbCrLf

      writeAppLog(exceptionInfo)

      Console.WriteLine(exceptionInfo)
    End Try

    '// execute our test if we have an open connection
    If conn_2.State = ConnectionState.Open Then
      '// the column c is defined as number(4), so this
      '// will be an error. insert this into our table
      '// rather than into the Application log.
      Dim l_sql As String = "insert into exception_test(c) values (10001)"
      Dim oraCmd As OracleCommand = New OracleCommand(l_sql, conn_2)

      Try
        oraCmd.ExecuteNonQuery()
      Catch ex As OracleException
        exceptionInfo = "Caught OracleException: " + ex.Message + vbCrLf
        exceptionInfo += "Location: Main method, insert into exception_test event" + vbCrLf
        exceptionInfo += "Connect: " + conn_2.ConnectionString

        writeAppTable(exceptionInfo, conn_2)

        Console.WriteLine(exceptionInfo)
      End Try
    End If

    If conn_2.State = ConnectionState.Open Then
      conn_2.Close()
    End If

    conn_2.Dispose()
  End Sub
  Private Sub writeAppLog(ByVal p_message As String)
    '// Open the Application log on the local machine
    Dim appLog As EventLog = New EventLog("Application")

    '// create our event source if it does not exist
    If Not EventLog.SourceExists("ExceptionApproach") Then
      EventLog.CreateEventSource("ExceptionApproach", "Application")
    End If

    '// set the source as our source
    appLog.Source = "ExceptionApproach"

    '// write entry to application log
    appLog.WriteEntry(p_message, EventLogEntryType.Error)

    '// explicitly close and dispose the appLog      
    appLog.Close()
    appLog.Dispose()
  End Sub

  Private Sub writeAppTable(ByVal p_message As String, ByVal p_conn As OracleConnection)
    '// this is the sql that we will use to insert a
    '// row into the app_exceptions table.
    '// we use a bind variable for the message column.
    '// sysdate and user functions supplied by the database
    '// they get the current date/time and username respectively.
    Dim l_sql As String = "insert into app_exceptions "
    l_sql += "(exception_date, username, exception_message) "
    l_sql += "values (sysdate, user, :1)"

    '// bind the message passed as a parameter
    '// we defined the column in the table as varchar2(512)
    '// so ensure we use a message that is no greater than
    '// 512 bytes in length
    Dim oraParam As OracleParameter = New OracleParameter
    oraParam.DbType = DbType.AnsiString
    oraParam.Direction = ParameterDirection.Input
    oraParam.ParameterName = "1"

    If p_message.Length < 513 Then
      oraParam.Value = p_message
    Else
      oraParam.Value = p_message.Substring(1, 512)
    End If

    '// create the command object, add the bind parameter
    '// and insert.
    Dim oraCmd As OracleCommand = New OracleCommand(l_sql, p_conn)

    oraCmd.Parameters.Add(oraParam)

    oraCmd.ExecuteNonQuery()

    '// explicitly dispose our objects
    oraCmd.Dispose()
  End Sub
End Module
