Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OracleClient

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
  Friend WithEvents listJobs As System.Windows.Forms.ListBox
  Friend WithEvents btnRetrieve As System.Windows.Forms.Button
  Friend WithEvents btnConnect As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.listJobs = New System.Windows.Forms.ListBox
    Me.btnRetrieve = New System.Windows.Forms.Button
    Me.btnConnect = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'listJobs
    '
    Me.listJobs.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.listJobs.ItemHeight = 15
    Me.listJobs.Location = New System.Drawing.Point(100, 21)
    Me.listJobs.Name = "listJobs"
    Me.listJobs.Size = New System.Drawing.Size(524, 244)
    Me.listJobs.TabIndex = 5
    '
    'btnRetrieve
    '
    Me.btnRetrieve.Location = New System.Drawing.Point(12, 57)
    Me.btnRetrieve.Name = "btnRetrieve"
    Me.btnRetrieve.TabIndex = 4
    Me.btnRetrieve.Text = "&Retrieve"
    '
    'btnConnect
    '
    Me.btnConnect.Location = New System.Drawing.Point(12, 21)
    Me.btnConnect.Name = "btnConnect"
    Me.btnConnect.TabIndex = 3
    Me.btnConnect.Text = "C&onnect"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(636, 286)
    Me.Controls.Add(Me.listJobs)
    Me.Controls.Add(Me.btnRetrieve)
    Me.Controls.Add(Me.btnConnect)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "TableDirect Sample"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    '// create a basic connection string using the sample
    '// Oracle HR user
    Dim connString As String = "User Id=hr; Password=demo; Data Source=oranet"

    '// only connect if we are not yet connected
    If oraConn.State <> ConnectionState.Open Then
      Try
        oraConn.ConnectionString = connString

        oraConn.Open()

        MessageBox.Show(oraConn.ConnectionString, "Successful Connection")
      Catch ex As Exception
        MessageBox.Show(ex.Message, "Exception Caught")
      End Try
    End If
  End Sub

  Private Sub btnRetrieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieve.Click
    '// create an OracleCommand object
    '// we will use the TableDirect method
    '// and the JOBS table
    Dim cmdEmployees As OracleCommand = New OracleCommand
    cmdEmployees.Connection = oraConn
    '// ms provider does not support tabledirect
    '// so issue a simple select * which is the equivalent
    cmdEmployees.CommandType = CommandType.Text
    cmdEmployees.CommandText = "SELECT * FROM JOBS"

    '// build a string that will make the header row
    '// in the list box
    Dim headText As String = "Job".PadRight(12)
    headText += "Title".PadRight(37)
    headText += "Min Salary".PadRight(12)
    headText += "Max Salary".PadRight(12)

    '// build a string that will separate the heading
    '// row from the data
    Dim headSep As String = "==========  "
    headSep += "===================================  "
    headSep += "==========  "
    headSep += "==========  "

    If oraConn.State = ConnectionState.Open Then
      Try
        '// get a data reader
        Dim dataReader As OracleDataReader = cmdEmployees.ExecuteReader()

        '// add the heading and separator
        listJobs.Items.Add(headText)
        listJobs.Items.Add(headSep)

        '// this string will represent our lines of data
        Dim textLine As String = ""

        '// loop through the data reader
        '// build a "line" of data
        '// and add it to the list box
        While dataReader.Read()
          textLine = dataReader.GetString(0).PadRight(12)
          textLine += dataReader.GetString(1).PadRight(37)
          textLine += dataReader.GetDecimal(2).ToString().PadRight(12)
          textLine += dataReader.GetDecimal(3).ToString().PadRight(12)

          listJobs.Items.Add(textLine)
        End While
      Catch ex As Exception
        MessageBox.Show(ex.Message, "Exception Caught")
      End Try
    End If

    cmdEmployees.Dispose()
  End Sub
End Class
