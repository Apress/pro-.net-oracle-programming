Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Oracle.DataAccess.Client
Public Class Form1
  Inherits System.Windows.Forms.Form

  Private oraConn As New OracleConnection

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents btnReset As System.Windows.Forms.Button
  Friend WithEvents lblGoalsAgainst As System.Windows.Forms.Label
  Friend WithEvents lblGoalsFor As System.Windows.Forms.Label
  Friend WithEvents lblLosses As System.Windows.Forms.Label
  Friend WithEvents lblDraws As System.Windows.Forms.Label
  Friend WithEvents lblWins As System.Windows.Forms.Label
  Friend WithEvents lblPlayed As System.Windows.Forms.Label
  Friend WithEvents lblPosition As System.Windows.Forms.Label
  Friend WithEvents cbTeams As System.Windows.Forms.ComboBox
  Friend WithEvents lblTeams As System.Windows.Forms.Label
  Friend WithEvents cbTraceLevel As System.Windows.Forms.ComboBox
  Friend WithEvents lblTraceLevel As System.Windows.Forms.Label
  Friend WithEvents btnLookup As System.Windows.Forms.Button
  Friend WithEvents btnLoadTeams As System.Windows.Forms.Button
  Friend WithEvents btnConnect As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.btnReset = New System.Windows.Forms.Button
    Me.lblGoalsAgainst = New System.Windows.Forms.Label
    Me.lblGoalsFor = New System.Windows.Forms.Label
    Me.lblLosses = New System.Windows.Forms.Label
    Me.lblDraws = New System.Windows.Forms.Label
    Me.lblWins = New System.Windows.Forms.Label
    Me.lblPlayed = New System.Windows.Forms.Label
    Me.lblPosition = New System.Windows.Forms.Label
    Me.cbTeams = New System.Windows.Forms.ComboBox
    Me.lblTeams = New System.Windows.Forms.Label
    Me.cbTraceLevel = New System.Windows.Forms.ComboBox
    Me.lblTraceLevel = New System.Windows.Forms.Label
    Me.btnLookup = New System.Windows.Forms.Button
    Me.btnLoadTeams = New System.Windows.Forms.Button
    Me.btnConnect = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'btnReset
    '
    Me.btnReset.Location = New System.Drawing.Point(60, 125)
    Me.btnReset.Name = "btnReset"
    Me.btnReset.TabIndex = 22
    Me.btnReset.Text = "&Reset"
    '
    'lblGoalsAgainst
    '
    Me.lblGoalsAgainst.Location = New System.Drawing.Point(160, 261)
    Me.lblGoalsAgainst.Name = "lblGoalsAgainst"
    Me.lblGoalsAgainst.Size = New System.Drawing.Size(172, 16)
    Me.lblGoalsAgainst.TabIndex = 29
    Me.lblGoalsAgainst.Text = "Goals Against:"
    Me.lblGoalsAgainst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblGoalsFor
    '
    Me.lblGoalsFor.Location = New System.Drawing.Point(160, 233)
    Me.lblGoalsFor.Name = "lblGoalsFor"
    Me.lblGoalsFor.Size = New System.Drawing.Size(172, 16)
    Me.lblGoalsFor.TabIndex = 28
    Me.lblGoalsFor.Text = "Goals For:"
    Me.lblGoalsFor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblLosses
    '
    Me.lblLosses.Location = New System.Drawing.Point(160, 205)
    Me.lblLosses.Name = "lblLosses"
    Me.lblLosses.Size = New System.Drawing.Size(172, 16)
    Me.lblLosses.TabIndex = 27
    Me.lblLosses.Text = "Losses:"
    Me.lblLosses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblDraws
    '
    Me.lblDraws.Location = New System.Drawing.Point(160, 177)
    Me.lblDraws.Name = "lblDraws"
    Me.lblDraws.Size = New System.Drawing.Size(172, 16)
    Me.lblDraws.TabIndex = 26
    Me.lblDraws.Text = "Draws:"
    Me.lblDraws.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblWins
    '
    Me.lblWins.Location = New System.Drawing.Point(160, 149)
    Me.lblWins.Name = "lblWins"
    Me.lblWins.Size = New System.Drawing.Size(172, 16)
    Me.lblWins.TabIndex = 25
    Me.lblWins.Text = "Wins:"
    Me.lblWins.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblPlayed
    '
    Me.lblPlayed.Location = New System.Drawing.Point(160, 121)
    Me.lblPlayed.Name = "lblPlayed"
    Me.lblPlayed.Size = New System.Drawing.Size(172, 16)
    Me.lblPlayed.TabIndex = 24
    Me.lblPlayed.Text = "Played:"
    Me.lblPlayed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblPosition
    '
    Me.lblPosition.Location = New System.Drawing.Point(160, 93)
    Me.lblPosition.Name = "lblPosition"
    Me.lblPosition.Size = New System.Drawing.Size(172, 16)
    Me.lblPosition.TabIndex = 23
    Me.lblPosition.Text = "Position:"
    Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'cbTeams
    '
    Me.cbTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbTeams.Location = New System.Drawing.Point(236, 53)
    Me.cbTeams.Name = "cbTeams"
    Me.cbTeams.Size = New System.Drawing.Size(168, 21)
    Me.cbTeams.TabIndex = 20
    '
    'lblTeams
    '
    Me.lblTeams.Location = New System.Drawing.Point(160, 57)
    Me.lblTeams.Name = "lblTeams"
    Me.lblTeams.Size = New System.Drawing.Size(68, 16)
    Me.lblTeams.TabIndex = 19
    Me.lblTeams.Text = "Tea&ms:"
    Me.lblTeams.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'cbTraceLevel
    '
    Me.cbTraceLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbTraceLevel.Items.AddRange(New Object() {"0", "1", "4", "8", "12"})
    Me.cbTraceLevel.Location = New System.Drawing.Point(236, 17)
    Me.cbTraceLevel.Name = "cbTraceLevel"
    Me.cbTraceLevel.Size = New System.Drawing.Size(56, 21)
    Me.cbTraceLevel.TabIndex = 17
    '
    'lblTraceLevel
    '
    Me.lblTraceLevel.Location = New System.Drawing.Point(160, 21)
    Me.lblTraceLevel.Name = "lblTraceLevel"
    Me.lblTraceLevel.Size = New System.Drawing.Size(68, 16)
    Me.lblTraceLevel.TabIndex = 16
    Me.lblTraceLevel.Text = "&Trace Level:"
    Me.lblTraceLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'btnLookup
    '
    Me.btnLookup.Location = New System.Drawing.Point(60, 89)
    Me.btnLookup.Name = "btnLookup"
    Me.btnLookup.TabIndex = 21
    Me.btnLookup.Text = "Loo&kup"
    '
    'btnLoadTeams
    '
    Me.btnLoadTeams.Location = New System.Drawing.Point(60, 53)
    Me.btnLoadTeams.Name = "btnLoadTeams"
    Me.btnLoadTeams.TabIndex = 18
    Me.btnLoadTeams.Text = "&Load"
    '
    'btnConnect
    '
    Me.btnConnect.Location = New System.Drawing.Point(60, 17)
    Me.btnConnect.Name = "btnConnect"
    Me.btnConnect.TabIndex = 15
    Me.btnConnect.Text = "C&onnect"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(512, 294)
    Me.Controls.Add(Me.btnReset)
    Me.Controls.Add(Me.lblGoalsAgainst)
    Me.Controls.Add(Me.lblGoalsFor)
    Me.Controls.Add(Me.lblLosses)
    Me.Controls.Add(Me.lblDraws)
    Me.Controls.Add(Me.lblWins)
    Me.Controls.Add(Me.lblPlayed)
    Me.Controls.Add(Me.lblPosition)
    Me.Controls.Add(Me.cbTeams)
    Me.Controls.Add(Me.lblTeams)
    Me.Controls.Add(Me.cbTraceLevel)
    Me.Controls.Add(Me.lblTraceLevel)
    Me.Controls.Add(Me.btnLookup)
    Me.Controls.Add(Me.btnLoadTeams)
    Me.Controls.Add(Me.btnConnect)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "SQLTrace Sample"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    cbTraceLevel.SelectedIndex = 0
  End Sub

  Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    '// create our standard connection string
    Dim connString As String = "User Id=oranetuser; Password=demo; Data Source=oranet"

    '// only connect if we are not yet connected
    If oraConn.State <> ConnectionState.Open Then
      Try
        oraConn = New OracleConnection(connString)

        oraConn.Open()

        MessageBox.Show(oraConn.ConnectionString, "Successful Connection")
      Catch ex As Exception
        MessageBox.Show(ex.Message, "Exception Caught")
      End Try
    End If
  End Sub

  Private Sub btnLoadTeams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadTeams.Click
    If oraConn.State = ConnectionState.Open Then
      '// remove any existing items
      cbTeams.Items.Clear()

      '// get list of teams from database
      '// and populate
      Dim sql As String = "select team from league_results order by team"

      Dim cmd As OracleCommand = New OracleCommand(sql, oraConn)

      Dim dataReader As OracleDataReader = cmd.ExecuteReader()

      While dataReader.Read()
        If Not dataReader.IsDBNull(0) Then
          cbTeams.Items.Add(dataReader(0).ToString())
        End If
      End While

      If cbTeams.Items.Count > 0 Then
        cbTeams.SelectedIndex = 0
      End If
    End If
  End Sub

  Private Sub btnLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookup.Click
    If oraConn.State = ConnectionState.Open Then
      Dim traceLevel As String = cbTraceLevel.SelectedItem.ToString()

      Dim traceSQL As String = "alter session set events "

      If traceLevel <> "0" Then
        '// turn on tracing
        traceSQL += "'10046 trace name context forever, level " + traceLevel + "'"
      Else
        '// turn off tracing
        traceSQL += "'10046 trace name context off'"
      End If

      Dim selectSQL As String = "select position, "
      selectSQL += "played, "
      selectSQL += "wins, "
      selectSQL += "draws, "
      selectSQL += "losses, "
      selectSQL += "goals_for, "
      selectSQL += "goals_against "
      selectSQL += "from league_results "
      selectSQL += "where team = :team"

      Dim p_team As OracleParameter = New OracleParameter
      p_team.Size = 32
      p_team.Value = cbTeams.SelectedItem.ToString()

      '// create the oracle command object
      '// and set the trace level
      Dim cmd As OracleCommand = New OracleCommand(traceSQL, oraConn)
      cmd.ExecuteNonQuery()

      '// assign the text for selecting the data
      cmd.CommandText = selectSQL

      '// add the parameter to the collection
      cmd.Parameters.Add(p_team)

      '// get a data reader object
      Dim dataReader As OracleDataReader = cmd.ExecuteReader()

      '// populate labels with data from data reader
      If dataReader.Read() Then
        '// position
        If Not dataReader.IsDBNull(0) Then
          lblPosition.Text = "Position: " + dataReader(0).ToString()
        End If

        '// played
        If Not dataReader.IsDBNull(1) Then
          lblPlayed.Text = "Played: " + dataReader(1).ToString()
        End If

        '// wins
        If Not dataReader.IsDBNull(2) Then
          lblWins.Text = "Wins: " + dataReader(2).ToString()
        End If

        '// draws
        If Not dataReader.IsDBNull(3) Then
          lblDraws.Text = "Draws: " + dataReader(3).ToString()
        End If

        '// losses
        If Not dataReader.IsDBNull(4) Then
          lblLosses.Text = "Losses: " + dataReader(4).ToString()
        End If

        '// goals for
        If Not dataReader.IsDBNull(5) Then
          lblGoalsFor.Text = "Goals For: " + dataReader(5).ToString()
        End If

        '// goals against
        If Not dataReader.IsDBNull(6) Then
          lblGoalsAgainst.Text = "Goals Against: " + dataReader(6).ToString()
        End If
      End If
    End If
  End Sub

  Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
    lblPosition.Text = "Position:"
    lblPlayed.Text = "Played:"
    lblWins.Text = "Wins:"
    lblDraws.Text = "Draws:"
    lblLosses.Text = "Losses:"
    lblGoalsFor.Text = "Goals For:"
    lblGoalsAgainst.Text = "Goals Against:"
  End Sub
End Class
