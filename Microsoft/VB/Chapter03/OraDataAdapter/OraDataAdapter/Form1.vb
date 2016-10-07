Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OracleClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  Public oraConn As New OracleConnection
  Public oraAdapter As New OracleDataAdapter
  Public oraBuilder As New OracleCommandBuilder
  Public dsSquad As New DataSet

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
  Friend WithEvents btnBind As System.Windows.Forms.Button
  Friend WithEvents btnUpdate As System.Windows.Forms.Button
  Friend WithEvents dgSquad As System.Windows.Forms.DataGrid
  Friend WithEvents btnLoad As System.Windows.Forms.Button
  Friend WithEvents btnClear As System.Windows.Forms.Button
  Friend WithEvents btnConnect As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.btnBind = New System.Windows.Forms.Button
    Me.btnUpdate = New System.Windows.Forms.Button
    Me.dgSquad = New System.Windows.Forms.DataGrid
    Me.btnLoad = New System.Windows.Forms.Button
    Me.btnClear = New System.Windows.Forms.Button
    Me.btnConnect = New System.Windows.Forms.Button
    CType(Me.dgSquad, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btnBind
    '
    Me.btnBind.Location = New System.Drawing.Point(14, 48)
    Me.btnBind.Name = "btnBind"
    Me.btnBind.TabIndex = 7
    Me.btnBind.Text = "&Bind"
    '
    'btnUpdate
    '
    Me.btnUpdate.Location = New System.Drawing.Point(14, 156)
    Me.btnUpdate.Name = "btnUpdate"
    Me.btnUpdate.TabIndex = 10
    Me.btnUpdate.Text = "U&pdate"
    '
    'dgSquad
    '
    Me.dgSquad.DataMember = ""
    Me.dgSquad.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgSquad.Location = New System.Drawing.Point(106, 12)
    Me.dgSquad.Name = "dgSquad"
    Me.dgSquad.Size = New System.Drawing.Size(476, 244)
    Me.dgSquad.TabIndex = 11
    '
    'btnLoad
    '
    Me.btnLoad.Location = New System.Drawing.Point(14, 120)
    Me.btnLoad.Name = "btnLoad"
    Me.btnLoad.TabIndex = 9
    Me.btnLoad.Text = "&Load Grid"
    '
    'btnClear
    '
    Me.btnClear.Location = New System.Drawing.Point(14, 84)
    Me.btnClear.Name = "btnClear"
    Me.btnClear.TabIndex = 8
    Me.btnClear.Text = "&Clear Grid"
    '
    'btnConnect
    '
    Me.btnConnect.Location = New System.Drawing.Point(14, 12)
    Me.btnConnect.Name = "btnConnect"
    Me.btnConnect.TabIndex = 6
    Me.btnConnect.Text = "C&onnect"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(596, 268)
    Me.Controls.Add(Me.btnBind)
    Me.Controls.Add(Me.btnUpdate)
    Me.Controls.Add(Me.dgSquad)
    Me.Controls.Add(Me.btnLoad)
    Me.Controls.Add(Me.btnClear)
    Me.Controls.Add(Me.btnConnect)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Oracle DataAdapter Sample"
    CType(Me.dgSquad, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    '// create a basic connection string using our
    '// standard Oracle user
    Dim connString As String = "User Id=oranetuser; Password=demo; Data Source=oranet"

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

  Private Sub btnBind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBind.Click
    If oraConn.State = ConnectionState.Open Then
      Dim strSelect As String = "select player_num, "
      strSelect += "last_name, "
      strSelect += "first_name, "
      strSelect += "position, "
      strSelect += "club "
      strSelect += "from squad "
      strSelect += "order by player_num"

      oraAdapter = New OracleDataAdapter(strSelect, oraConn)

      oraBuilder = New OracleCommandBuilder(oraAdapter)

      dsSquad = New DataSet("dsSquad")

      oraAdapter.Fill(dsSquad, "SQUAD")

      dgSquad.SetDataBinding(dsSquad, "SQUAD")

      btnBind.Enabled = False
    End If
  End Sub

  Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
    dsSquad.Clear()
    dgSquad.SetDataBinding(Nothing, Nothing)
  End Sub

  Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    btnClear_Click(sender, e)

    oraAdapter.Fill(dsSquad, "SQUAD")

    dgSquad.SetDataBinding(dsSquad, "SQUAD")
  End Sub

  Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
    oraAdapter.Update(dsSquad, "SQUAD")
  End Sub
End Class
