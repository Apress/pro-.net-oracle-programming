Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OracleClient
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
  Friend WithEvents txtTNSAlias As System.Windows.Forms.TextBox
  Friend WithEvents lblTNSAlias As System.Windows.Forms.Label
  Friend WithEvents btnConnect As System.Windows.Forms.Button
  Friend WithEvents txtCurrentPassword As System.Windows.Forms.TextBox
  Friend WithEvents lblCurrentPassword As System.Windows.Forms.Label
  Friend WithEvents txtUserName As System.Windows.Forms.TextBox
  Friend WithEvents lblUserName As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.txtTNSAlias = New System.Windows.Forms.TextBox
    Me.lblTNSAlias = New System.Windows.Forms.Label
    Me.btnConnect = New System.Windows.Forms.Button
    Me.txtCurrentPassword = New System.Windows.Forms.TextBox
    Me.lblCurrentPassword = New System.Windows.Forms.Label
    Me.txtUserName = New System.Windows.Forms.TextBox
    Me.lblUserName = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'txtTNSAlias
    '
    Me.txtTNSAlias.Location = New System.Drawing.Point(191, 86)
    Me.txtTNSAlias.Name = "txtTNSAlias"
    Me.txtTNSAlias.TabIndex = 16
    Me.txtTNSAlias.Text = ""
    '
    'lblTNSAlias
    '
    Me.lblTNSAlias.Location = New System.Drawing.Point(87, 88)
    Me.lblTNSAlias.Name = "lblTNSAlias"
    Me.lblTNSAlias.Size = New System.Drawing.Size(100, 16)
    Me.lblTNSAlias.TabIndex = 15
    Me.lblTNSAlias.Text = "&TNS Alias:"
    Me.lblTNSAlias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'btnConnect
    '
    Me.btnConnect.Location = New System.Drawing.Point(132, 130)
    Me.btnConnect.Name = "btnConnect"
    Me.btnConnect.Size = New System.Drawing.Size(115, 23)
    Me.btnConnect.TabIndex = 17
    Me.btnConnect.Text = "&Connect"
    '
    'txtCurrentPassword
    '
    Me.txtCurrentPassword.Location = New System.Drawing.Point(191, 54)
    Me.txtCurrentPassword.Name = "txtCurrentPassword"
    Me.txtCurrentPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
    Me.txtCurrentPassword.TabIndex = 14
    Me.txtCurrentPassword.Text = ""
    '
    'lblCurrentPassword
    '
    Me.lblCurrentPassword.Location = New System.Drawing.Point(87, 56)
    Me.lblCurrentPassword.Name = "lblCurrentPassword"
    Me.lblCurrentPassword.Size = New System.Drawing.Size(100, 16)
    Me.lblCurrentPassword.TabIndex = 13
    Me.lblCurrentPassword.Text = "Current &Password:"
    Me.lblCurrentPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtUserName
    '
    Me.txtUserName.Location = New System.Drawing.Point(191, 22)
    Me.txtUserName.Name = "txtUserName"
    Me.txtUserName.TabIndex = 12
    Me.txtUserName.Text = ""
    '
    'lblUserName
    '
    Me.lblUserName.Location = New System.Drawing.Point(87, 24)
    Me.lblUserName.Name = "lblUserName"
    Me.lblUserName.Size = New System.Drawing.Size(100, 16)
    Me.lblUserName.TabIndex = 11
    Me.lblUserName.Text = "&User Name:"
    Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(378, 174)
    Me.Controls.Add(Me.txtTNSAlias)
    Me.Controls.Add(Me.lblTNSAlias)
    Me.Controls.Add(Me.btnConnect)
    Me.Controls.Add(Me.txtCurrentPassword)
    Me.Controls.Add(Me.lblCurrentPassword)
    Me.Controls.Add(Me.txtUserName)
    Me.Controls.Add(Me.lblUserName)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Locked Account Sample"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    '// build a connect string based on the user input
    Dim l_connect As String = "User Id=" + txtUserName.Text + ";"
    l_connect += "Password=" + txtCurrentPassword.Text + ";"
    l_connect += "Data Source=" + txtTNSAlias.Text

    Dim oraConn As OracleConnection = New OracleConnection(l_connect)

    Try
      '// attempt to open a connection
      '// this should fail since we have locked the account
      oraConn.Open()
    Catch ex As OracleException
      '// trap the "account is locked" error code
      If ex.Code = 28000 Then
        '// dislay a simple marker to indicate we trapped the error
        MessageBox.Show("Trapped Locked Account", "Locked Account")
      Else
        MessageBox.Show(ex.Message, "Error Occured")
      End If
    Finally
      If oraConn.State = System.Data.ConnectionState.Open Then
        oraConn.Close()
      End If
    End Try
  End Sub
End Class
