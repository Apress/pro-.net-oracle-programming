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
  Friend WithEvents btnConnect As System.Windows.Forms.Button
  Friend WithEvents lblLastName As System.Windows.Forms.Label
  Friend WithEvents lblFirstName As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents cbEmpIds As System.Windows.Forms.ComboBox
  Friend WithEvents btnGetIDs As System.Windows.Forms.Button
  Friend WithEvents btnNoBinds As System.Windows.Forms.Button
  Friend WithEvents btnReset As System.Windows.Forms.Button
  Friend WithEvents lblPhoneText As System.Windows.Forms.Label
  Friend WithEvents lblEmailText As System.Windows.Forms.Label
  Friend WithEvents lblPhone As System.Windows.Forms.Label
  Friend WithEvents lblEmail As System.Windows.Forms.Label
  Friend WithEvents btnLookup2 As System.Windows.Forms.Button
  Friend WithEvents btnLookup1 As System.Windows.Forms.Button
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents cmdLookup2 As System.Data.OracleClient.OracleCommand
  Friend WithEvents oraConn As System.Data.OracleClient.OracleConnection
  Friend WithEvents cmdNoBinds1 As System.Data.OracleClient.OracleCommand
  Friend WithEvents cmdNoBinds2 As System.Data.OracleClient.OracleCommand
  Friend WithEvents cmdLookup1 As System.Data.OracleClient.OracleCommand
  Friend WithEvents cmdGetIDs As System.Data.OracleClient.OracleCommand
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.btnConnect = New System.Windows.Forms.Button
    Me.lblLastName = New System.Windows.Forms.Label
    Me.lblFirstName = New System.Windows.Forms.Label
    Me.label1 = New System.Windows.Forms.Label
    Me.cbEmpIds = New System.Windows.Forms.ComboBox
    Me.btnGetIDs = New System.Windows.Forms.Button
    Me.btnNoBinds = New System.Windows.Forms.Button
    Me.btnReset = New System.Windows.Forms.Button
    Me.lblPhoneText = New System.Windows.Forms.Label
    Me.lblEmailText = New System.Windows.Forms.Label
    Me.lblPhone = New System.Windows.Forms.Label
    Me.lblEmail = New System.Windows.Forms.Label
    Me.btnLookup2 = New System.Windows.Forms.Button
    Me.btnLookup1 = New System.Windows.Forms.Button
    Me.label5 = New System.Windows.Forms.Label
    Me.label4 = New System.Windows.Forms.Label
    Me.cmdLookup2 = New System.Data.OracleClient.OracleCommand
    Me.oraConn = New System.Data.OracleClient.OracleConnection
    Me.cmdNoBinds1 = New System.Data.OracleClient.OracleCommand
    Me.cmdNoBinds2 = New System.Data.OracleClient.OracleCommand
    Me.cmdLookup1 = New System.Data.OracleClient.OracleCommand
    Me.cmdGetIDs = New System.Data.OracleClient.OracleCommand
    Me.SuspendLayout()
    '
    'btnConnect
    '
    Me.btnConnect.Location = New System.Drawing.Point(37, 41)
    Me.btnConnect.Name = "btnConnect"
    Me.btnConnect.TabIndex = 16
    Me.btnConnect.Text = "C&onnect"
    '
    'lblLastName
    '
    Me.lblLastName.Location = New System.Drawing.Point(369, 45)
    Me.lblLastName.Name = "lblLastName"
    Me.lblLastName.Size = New System.Drawing.Size(128, 16)
    Me.lblLastName.TabIndex = 27
    '
    'lblFirstName
    '
    Me.lblFirstName.Location = New System.Drawing.Point(233, 45)
    Me.lblFirstName.Name = "lblFirstName"
    Me.lblFirstName.Size = New System.Drawing.Size(116, 16)
    Me.lblFirstName.TabIndex = 25
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(149, 21)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(72, 16)
    Me.label1.TabIndex = 18
    Me.label1.Text = "&Employee ID:"
    '
    'cbEmpIds
    '
    Me.cbEmpIds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbEmpIds.Location = New System.Drawing.Point(149, 41)
    Me.cbEmpIds.Name = "cbEmpIds"
    Me.cbEmpIds.Size = New System.Drawing.Size(68, 21)
    Me.cbEmpIds.TabIndex = 19
    '
    'btnGetIDs
    '
    Me.btnGetIDs.Location = New System.Drawing.Point(37, 77)
    Me.btnGetIDs.Name = "btnGetIDs"
    Me.btnGetIDs.TabIndex = 17
    Me.btnGetIDs.Text = "&Get IDs"
    '
    'btnNoBinds
    '
    Me.btnNoBinds.Location = New System.Drawing.Point(37, 185)
    Me.btnNoBinds.Name = "btnNoBinds"
    Me.btnNoBinds.TabIndex = 22
    Me.btnNoBinds.Text = "No &Binds"
    '
    'btnReset
    '
    Me.btnReset.Location = New System.Drawing.Point(37, 221)
    Me.btnReset.Name = "btnReset"
    Me.btnReset.TabIndex = 23
    Me.btnReset.Text = "&Reset"
    '
    'lblPhoneText
    '
    Me.lblPhoneText.Location = New System.Drawing.Point(369, 109)
    Me.lblPhoneText.Name = "lblPhoneText"
    Me.lblPhoneText.Size = New System.Drawing.Size(128, 16)
    Me.lblPhoneText.TabIndex = 31
    '
    'lblEmailText
    '
    Me.lblEmailText.Location = New System.Drawing.Point(233, 109)
    Me.lblEmailText.Name = "lblEmailText"
    Me.lblEmailText.Size = New System.Drawing.Size(116, 16)
    Me.lblEmailText.TabIndex = 29
    '
    'lblPhone
    '
    Me.lblPhone.Location = New System.Drawing.Point(369, 85)
    Me.lblPhone.Name = "lblPhone"
    Me.lblPhone.Size = New System.Drawing.Size(100, 16)
    Me.lblPhone.TabIndex = 30
    Me.lblPhone.Text = "Phone &Number:"
    '
    'lblEmail
    '
    Me.lblEmail.Location = New System.Drawing.Point(233, 85)
    Me.lblEmail.Name = "lblEmail"
    Me.lblEmail.Size = New System.Drawing.Size(100, 16)
    Me.lblEmail.TabIndex = 28
    Me.lblEmail.Text = "E&mail:"
    '
    'btnLookup2
    '
    Me.btnLookup2.Location = New System.Drawing.Point(37, 149)
    Me.btnLookup2.Name = "btnLookup2"
    Me.btnLookup2.TabIndex = 21
    Me.btnLookup2.Text = "Lookup &2"
    '
    'btnLookup1
    '
    Me.btnLookup1.Location = New System.Drawing.Point(37, 113)
    Me.btnLookup1.Name = "btnLookup1"
    Me.btnLookup1.TabIndex = 20
    Me.btnLookup1.Text = "Lookup &1"
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(369, 21)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(100, 16)
    Me.label5.TabIndex = 26
    Me.label5.Text = "&Last Name:"
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(233, 21)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(100, 16)
    Me.label4.TabIndex = 24
    Me.label4.Text = "&First Name:"
    '
    'cmdLookup2
    '
    Me.cmdLookup2.CommandText = "SELECT EMAIL, PHONE_NUMBER FROM EMPLOYEES WHERE (FIRST_NAME = :p_first) AND (LAST" & _
    "_NAME = :p_last)"
    Me.cmdLookup2.Connection = Me.oraConn
    Me.cmdLookup2.Parameters.Add(New System.Data.OracleClient.OracleParameter(":p_first", System.Data.OracleClient.OracleType.VarChar, 20, "FIRST_NAME"))
    Me.cmdLookup2.Parameters.Add(New System.Data.OracleClient.OracleParameter(":p_last", System.Data.OracleClient.OracleType.VarChar, 25, "LAST_NAME"))
    '
    'oraConn
    '
    Me.oraConn.ConnectionString = "user id=hr;data source=oranet;password=demo"
    '
    'cmdNoBinds1
    '
    Me.cmdNoBinds1.Connection = Me.oraConn
    '
    'cmdNoBinds2
    '
    Me.cmdNoBinds2.Connection = Me.oraConn
    '
    'cmdLookup1
    '
    Me.cmdLookup1.CommandText = "SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES WHERE (EMPLOYEE_ID = :p_id)"
    Me.cmdLookup1.Connection = Me.oraConn
    Me.cmdLookup1.Parameters.Add(New System.Data.OracleClient.OracleParameter(":p_id", System.Data.OracleClient.OracleType.Number, 0, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "EMPLOYEE_ID", System.Data.DataRowVersion.Current, Nothing))
    '
    'cmdGetIDs
    '
    Me.cmdGetIDs.CommandText = "SELECT EMPLOYEE_ID FROM EMPLOYEES ORDER BY EMPLOYEE_ID"
    Me.cmdGetIDs.Connection = Me.oraConn
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(534, 264)
    Me.Controls.Add(Me.btnConnect)
    Me.Controls.Add(Me.lblLastName)
    Me.Controls.Add(Me.lblFirstName)
    Me.Controls.Add(Me.label1)
    Me.Controls.Add(Me.cbEmpIds)
    Me.Controls.Add(Me.btnGetIDs)
    Me.Controls.Add(Me.btnNoBinds)
    Me.Controls.Add(Me.btnReset)
    Me.Controls.Add(Me.lblPhoneText)
    Me.Controls.Add(Me.lblEmailText)
    Me.Controls.Add(Me.lblPhone)
    Me.Controls.Add(Me.lblEmail)
    Me.Controls.Add(Me.btnLookup2)
    Me.Controls.Add(Me.btnLookup1)
    Me.Controls.Add(Me.label5)
    Me.Controls.Add(Me.label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "MSProvider Sample"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    If oraConn.State <> ConnectionState.Open Then
      Try
        oraConn.Open()

        MessageBox.Show(oraConn.ConnectionString, "Successful Connection")
      Catch ex As Exception
        MessageBox.Show(ex.Message, "Exception Caught")
      End Try
    End If
  End Sub

  Private Sub btnGetIDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetIDs.Click
    Try
      '// get a data reader
      Dim dataReader As OracleDataReader = cmdGetIDs.ExecuteReader()

      '// simply iterate the result set and add
      '// the values to the drop down list
      While dataReader.Read()
        cbEmpIds.Items.Add(dataReader.GetDecimal(0))
      End While
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Exception Caught")
    End Try
  End Sub

  Private Sub btnLookup1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookup1.Click
    Dim selectedItem As Object = cbEmpIds.SelectedItem

    If Not selectedItem Is Nothing Then
      '// we need to set the parameter value
      cmdLookup1.Parameters(0).Value = Convert.ToDecimal(selectedItem.ToString())

      '// get our data reader
      Dim dataReader As OracleDataReader = cmdLookup1.ExecuteReader()

      '// get the results - our query will only return 1 row
      '// since we are using the primary key
      If dataReader.Read() Then
        lblFirstName.Text = dataReader.GetString(0)
        lblLastName.Text = dataReader.GetString(1)
      End If

      dataReader.Close()
      dataReader.Dispose()
    End If
  End Sub

  Private Sub btnLookup2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookup2.Click
    '// we need to bind in order since the Microsoft driver
    '// does not support the BindByName property
    cmdLookup2.Parameters(0).Value = lblFirstName.Text
    cmdLookup2.Parameters(1).Value = lblLastName.Text

    '// get our data reader
    Dim dataReader As OracleDataReader = cmdLookup2.ExecuteReader()

    '// get the results - our query will only return 1 row
    '// since we are using known unique values for the first
    '// and last names
    If dataReader.Read() Then
      lblEmailText.Text = dataReader.GetString(0)
      lblPhoneText.Text = dataReader.GetString(1)
    End If

    dataReader.Close()

    dataReader.Dispose()
  End Sub

  Private Sub btnNoBinds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoBinds.Click
    '// this illustrates the "traditional" approach
    '// that does not use bind variables

    Dim selectedItem As Object = cbEmpIds.SelectedItem

    If Not selectedItem Is Nothing Then
      Dim dataReader As OracleDataReader

      '// we must build our command text string
      '// since we are concatenating values at runtime
      cmdNoBinds1.CommandText = "select first_name, last_name from employees where employee_id = " + selectedItem.ToString()

      '// get our data reader
      dataReader = cmdNoBinds1.ExecuteReader()

      '// get the results - our query will only return 1 row
      '// since we are using the primary key
      If dataReader.Read() Then
        lblFirstName.Text = dataReader.GetString(0)
        lblLastName.Text = dataReader.GetString(1)
      End If

      dataReader.Close()

      '// get the data that Lookup 2 performed above
      '// again, we must build the string here in code
      '// rather than in the design environment
      cmdNoBinds2.CommandText = "select email, phone_number from employees where first_name = '" + lblFirstName.Text + "' and last_name = '" + lblLastName.Text + "'"

      '// get our data reader
      dataReader = cmdNoBinds2.ExecuteReader()

      '// get the results - our query will only return 1 row
      '// since we are using known unique values for the first
      '// and last names
      If dataReader.Read() Then
        lblEmailText.Text = dataReader.GetString(0)
        lblPhoneText.Text = dataReader.GetString(1)
      End If

      dataReader.Close()
      dataReader.Dispose()
    End If
  End Sub

  Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
    cbEmpIds.SelectedIndex = -1
    lblFirstName.Text = ""
    lblLastName.Text = ""
    lblEmailText.Text = ""
    lblPhoneText.Text = ""
  End Sub
End Class
