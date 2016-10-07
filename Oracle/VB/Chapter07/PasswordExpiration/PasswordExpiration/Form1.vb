Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Oracle.DataAccess.Client
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
  Friend WithEvents btnChangePassword As System.Windows.Forms.Button
  Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
  Friend WithEvents lblConfirmPassword As System.Windows.Forms.Label
  Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
  Friend WithEvents lblNewPassword As System.Windows.Forms.Label
  Friend WithEvents txtCurrentPassword As System.Windows.Forms.TextBox
  Friend WithEvents lblCurrentPassword As System.Windows.Forms.Label
  Friend WithEvents txtUserName As System.Windows.Forms.TextBox
  Friend WithEvents lblUserName As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.txtTNSAlias = New System.Windows.Forms.TextBox
    Me.lblTNSAlias = New System.Windows.Forms.Label
    Me.btnChangePassword = New System.Windows.Forms.Button
    Me.txtConfirmPassword = New System.Windows.Forms.TextBox
    Me.lblConfirmPassword = New System.Windows.Forms.Label
    Me.txtNewPassword = New System.Windows.Forms.TextBox
    Me.lblNewPassword = New System.Windows.Forms.Label
    Me.txtCurrentPassword = New System.Windows.Forms.TextBox
    Me.lblCurrentPassword = New System.Windows.Forms.Label
    Me.txtUserName = New System.Windows.Forms.TextBox
    Me.lblUserName = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'txtTNSAlias
    '
    Me.txtTNSAlias.Location = New System.Drawing.Point(148, 94)
    Me.txtTNSAlias.Name = "txtTNSAlias"
    Me.txtTNSAlias.TabIndex = 16
    Me.txtTNSAlias.Text = ""
    '
    'lblTNSAlias
    '
    Me.lblTNSAlias.Location = New System.Drawing.Point(44, 96)
    Me.lblTNSAlias.Name = "lblTNSAlias"
    Me.lblTNSAlias.Size = New System.Drawing.Size(100, 16)
    Me.lblTNSAlias.TabIndex = 15
    Me.lblTNSAlias.Text = "&TNS Alias:"
    Me.lblTNSAlias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'btnChangePassword
    '
    Me.btnChangePassword.Location = New System.Drawing.Point(89, 214)
    Me.btnChangePassword.Name = "btnChangePassword"
    Me.btnChangePassword.Size = New System.Drawing.Size(115, 23)
    Me.btnChangePassword.TabIndex = 21
    Me.btnChangePassword.Text = "Chan&ge Password"
    '
    'txtConfirmPassword
    '
    Me.txtConfirmPassword.Location = New System.Drawing.Point(148, 158)
    Me.txtConfirmPassword.Name = "txtConfirmPassword"
    Me.txtConfirmPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
    Me.txtConfirmPassword.TabIndex = 20
    Me.txtConfirmPassword.Text = ""
    '
    'lblConfirmPassword
    '
    Me.lblConfirmPassword.Location = New System.Drawing.Point(44, 160)
    Me.lblConfirmPassword.Name = "lblConfirmPassword"
    Me.lblConfirmPassword.Size = New System.Drawing.Size(100, 16)
    Me.lblConfirmPassword.TabIndex = 19
    Me.lblConfirmPassword.Text = "&Confirm Password:"
    Me.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtNewPassword
    '
    Me.txtNewPassword.Location = New System.Drawing.Point(148, 126)
    Me.txtNewPassword.Name = "txtNewPassword"
    Me.txtNewPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
    Me.txtNewPassword.TabIndex = 18
    Me.txtNewPassword.Text = ""
    '
    'lblNewPassword
    '
    Me.lblNewPassword.Location = New System.Drawing.Point(44, 128)
    Me.lblNewPassword.Name = "lblNewPassword"
    Me.lblNewPassword.Size = New System.Drawing.Size(100, 16)
    Me.lblNewPassword.TabIndex = 17
    Me.lblNewPassword.Text = "&New Password:"
    Me.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtCurrentPassword
    '
    Me.txtCurrentPassword.Location = New System.Drawing.Point(148, 62)
    Me.txtCurrentPassword.Name = "txtCurrentPassword"
    Me.txtCurrentPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
    Me.txtCurrentPassword.TabIndex = 14
    Me.txtCurrentPassword.Text = ""
    '
    'lblCurrentPassword
    '
    Me.lblCurrentPassword.Location = New System.Drawing.Point(44, 64)
    Me.lblCurrentPassword.Name = "lblCurrentPassword"
    Me.lblCurrentPassword.Size = New System.Drawing.Size(100, 16)
    Me.lblCurrentPassword.TabIndex = 13
    Me.lblCurrentPassword.Text = "Current &Password:"
    Me.lblCurrentPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtUserName
    '
    Me.txtUserName.Location = New System.Drawing.Point(148, 30)
    Me.txtUserName.Name = "txtUserName"
    Me.txtUserName.TabIndex = 12
    Me.txtUserName.Text = ""
    '
    'lblUserName
    '
    Me.lblUserName.Location = New System.Drawing.Point(44, 32)
    Me.lblUserName.Name = "lblUserName"
    Me.lblUserName.Size = New System.Drawing.Size(100, 16)
    Me.lblUserName.TabIndex = 11
    Me.lblUserName.Text = "&User Name:"
    Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 266)
    Me.Controls.Add(Me.txtTNSAlias)
    Me.Controls.Add(Me.lblTNSAlias)
    Me.Controls.Add(Me.btnChangePassword)
    Me.Controls.Add(Me.txtConfirmPassword)
    Me.Controls.Add(Me.lblConfirmPassword)
    Me.Controls.Add(Me.txtNewPassword)
    Me.Controls.Add(Me.lblNewPassword)
    Me.Controls.Add(Me.txtCurrentPassword)
    Me.Controls.Add(Me.lblCurrentPassword)
    Me.Controls.Add(Me.txtUserName)
    Me.Controls.Add(Me.lblUserName)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Expired Password Sample"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
    '// display a simple message if the "new" and
    '// the "confirm" passwords do not match
    If txtNewPassword.Text <> txtConfirmPassword.Text Then
      MessageBox.Show("New passwords do not match.", "Password Mismatch")

      Return

      '// build a connect string based on the user input
      Dim l_connect As String = "User Id=" + txtUserName.Text + ";"
      l_connect += "Password=" + txtCurrentPassword.Text + ";"
      l_connect += "Data Source=" + txtTNSAlias.Text

      Dim oraConn As OracleConnection = New OracleConnection(l_connect)

      Try
        '// attempt to open a connection
        '// this should fail since we have expired the password
        oraConn.Open()
      Catch ex As OracleException
        '// trap the "password is expired" error code
        If ex.Number = 28001 Then
          '// dislay a simple marker indicate we trapped the error
          MessageBox.Show("Trapped Expired Password", "Expired Password")

          '// this method changes the expired password
          oraConn.OpenWithNewPassword(txtNewPassword.Text)

          '// display a simple marker to indicate password changed
          MessageBox.Show("Changed Expired Password", "Expired Password")
        Else
          MessageBox.Show(ex.Message, "Error Occured")
        End If
      Finally
        If oraConn.State = System.Data.ConnectionState.Open Then
          oraConn.Close()
        End If
      End Try
    End If
  End Sub
End Class
