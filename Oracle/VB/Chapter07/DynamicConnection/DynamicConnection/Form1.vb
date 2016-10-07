Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form1
  Inherits System.Windows.Forms.Form

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
  Friend WithEvents btnConnect As System.Windows.Forms.Button
  Friend WithEvents txtServiceName As System.Windows.Forms.TextBox
  Friend WithEvents txtPort As System.Windows.Forms.TextBox
  Friend WithEvents txtHost As System.Windows.Forms.TextBox
  Friend WithEvents txtPassword As System.Windows.Forms.TextBox
  Friend WithEvents txtUserName As System.Windows.Forms.TextBox
  Friend WithEvents lblServiceName As System.Windows.Forms.Label
  Friend WithEvents lblPort As System.Windows.Forms.Label
  Friend WithEvents lblHost As System.Windows.Forms.Label
  Friend WithEvents lblPassword As System.Windows.Forms.Label
  Friend WithEvents lblUserName As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.btnConnect = New System.Windows.Forms.Button
    Me.txtServiceName = New System.Windows.Forms.TextBox
    Me.txtPort = New System.Windows.Forms.TextBox
    Me.txtHost = New System.Windows.Forms.TextBox
    Me.txtPassword = New System.Windows.Forms.TextBox
    Me.txtUserName = New System.Windows.Forms.TextBox
    Me.lblServiceName = New System.Windows.Forms.Label
    Me.lblPort = New System.Windows.Forms.Label
    Me.lblHost = New System.Windows.Forms.Label
    Me.lblPassword = New System.Windows.Forms.Label
    Me.lblUserName = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'btnConnect
    '
    Me.btnConnect.Location = New System.Drawing.Point(116, 211)
    Me.btnConnect.Name = "btnConnect"
    Me.btnConnect.TabIndex = 21
    Me.btnConnect.Text = "&Connect"
    '
    'txtServiceName
    '
    Me.txtServiceName.Location = New System.Drawing.Point(136, 163)
    Me.txtServiceName.Name = "txtServiceName"
    Me.txtServiceName.TabIndex = 20
    Me.txtServiceName.Text = ""
    '
    'txtPort
    '
    Me.txtPort.Location = New System.Drawing.Point(136, 131)
    Me.txtPort.Name = "txtPort"
    Me.txtPort.TabIndex = 18
    Me.txtPort.Text = ""
    '
    'txtHost
    '
    Me.txtHost.Location = New System.Drawing.Point(136, 99)
    Me.txtHost.Name = "txtHost"
    Me.txtHost.TabIndex = 16
    Me.txtHost.Text = ""
    '
    'txtPassword
    '
    Me.txtPassword.Location = New System.Drawing.Point(136, 67)
    Me.txtPassword.Name = "txtPassword"
    Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
    Me.txtPassword.TabIndex = 14
    Me.txtPassword.Text = ""
    '
    'txtUserName
    '
    Me.txtUserName.Location = New System.Drawing.Point(136, 32)
    Me.txtUserName.Name = "txtUserName"
    Me.txtUserName.TabIndex = 12
    Me.txtUserName.Text = ""
    '
    'lblServiceName
    '
    Me.lblServiceName.Location = New System.Drawing.Point(52, 163)
    Me.lblServiceName.Name = "lblServiceName"
    Me.lblServiceName.Size = New System.Drawing.Size(80, 16)
    Me.lblServiceName.TabIndex = 19
    Me.lblServiceName.Text = "S&ervice Name:"
    Me.lblServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblPort
    '
    Me.lblPort.Location = New System.Drawing.Point(52, 131)
    Me.lblPort.Name = "lblPort"
    Me.lblPort.Size = New System.Drawing.Size(80, 16)
    Me.lblPort.TabIndex = 17
    Me.lblPort.Text = "P&ort:"
    Me.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblHost
    '
    Me.lblHost.Location = New System.Drawing.Point(52, 99)
    Me.lblHost.Name = "lblHost"
    Me.lblHost.Size = New System.Drawing.Size(80, 16)
    Me.lblHost.TabIndex = 15
    Me.lblHost.Text = "&Host:"
    Me.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblPassword
    '
    Me.lblPassword.Location = New System.Drawing.Point(52, 69)
    Me.lblPassword.Name = "lblPassword"
    Me.lblPassword.Size = New System.Drawing.Size(80, 16)
    Me.lblPassword.TabIndex = 13
    Me.lblPassword.Text = "&Password:"
    Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblUserName
    '
    Me.lblUserName.Location = New System.Drawing.Point(52, 34)
    Me.lblUserName.Name = "lblUserName"
    Me.lblUserName.Size = New System.Drawing.Size(80, 16)
    Me.lblUserName.TabIndex = 11
    Me.lblUserName.Text = "User &Name:"
    Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 266)
    Me.Controls.Add(Me.btnConnect)
    Me.Controls.Add(Me.txtServiceName)
    Me.Controls.Add(Me.txtPort)
    Me.Controls.Add(Me.txtHost)
    Me.Controls.Add(Me.txtPassword)
    Me.Controls.Add(Me.txtUserName)
    Me.Controls.Add(Me.lblServiceName)
    Me.Controls.Add(Me.lblPort)
    Me.Controls.Add(Me.lblHost)
    Me.Controls.Add(Me.lblPassword)
    Me.Controls.Add(Me.lblUserName)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "TNSNames-less Connection Example"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    doDynamicConnection(txtUserName.Text, txtPassword.Text, txtHost.Text, txtPort.Text, txtServiceName.Text)
  End Sub

  Private Sub doDynamicConnection(ByVal p_user As String, ByVal p_password As String, ByVal p_host As String, ByVal p_port As String, ByVal p_service_name As String)
    '// build a tns connection string based on the inputs
    Dim l_data_source As String = "(DESCRIPTION=(ADDRESS_LIST="
    l_data_source += "(ADDRESS=(PROTOCOL=tcp)(HOST=" + p_host + ")"
    l_data_source += "(PORT=" + p_port + ")))"
    l_data_source += "(CONNECT_DATA=(SERVICE_NAME=" + p_service_name + ")))"

    '// create the .NET provider connect string
    Dim l_connect_string As String = "User Id=" + p_user + ";"
    l_connect_string += "Password=" + p_password + ";"
    l_connect_string += "Data Source=" + l_data_source

    '// attempt to connect to the database
    Dim oraConn As OracleConnection = New OracleConnection(l_connect_string)

    Try
      oraConn.Open()

      '// dislay a simple message box with our data source string
      MessageBox.Show("Connected to data source: " + vbCrLf + oraConn.DataSource, "Dynamic Connection Sample")
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Error Occured")
    Finally
      If oraConn.State = System.Data.ConnectionState.Open Then
        oraConn.Close()
      End If
    End Try
  End Sub
End Class
