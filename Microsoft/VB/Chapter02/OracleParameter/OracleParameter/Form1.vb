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
  Friend WithEvents lblLastName As System.Windows.Forms.Label
  Friend WithEvents lblFirstName As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents cbEmpIds As System.Windows.Forms.ComboBox
  Friend WithEvents btnGetIDs As System.Windows.Forms.Button
  Friend WithEvents btnConnect As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
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
    Me.lblLastName = New System.Windows.Forms.Label
    Me.lblFirstName = New System.Windows.Forms.Label
    Me.label1 = New System.Windows.Forms.Label
    Me.cbEmpIds = New System.Windows.Forms.ComboBox
    Me.btnGetIDs = New System.Windows.Forms.Button
    Me.btnConnect = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'btnNoBinds
    '
    Me.btnNoBinds.Location = New System.Drawing.Point(38, 186)
    Me.btnNoBinds.Name = "btnNoBinds"
    Me.btnNoBinds.TabIndex = 22
    Me.btnNoBinds.Text = "No &Binds"
    '
    'btnReset
    '
    Me.btnReset.Location = New System.Drawing.Point(38, 222)
    Me.btnReset.Name = "btnReset"
    Me.btnReset.TabIndex = 23
    Me.btnReset.Text = "&Reset"
    '
    'lblPhoneText
    '
    Me.lblPhoneText.Location = New System.Drawing.Point(370, 110)
    Me.lblPhoneText.Name = "lblPhoneText"
    Me.lblPhoneText.Size = New System.Drawing.Size(128, 16)
    Me.lblPhoneText.TabIndex = 31
    '
    'lblEmailText
    '
    Me.lblEmailText.Location = New System.Drawing.Point(234, 110)
    Me.lblEmailText.Name = "lblEmailText"
    Me.lblEmailText.Size = New System.Drawing.Size(116, 16)
    Me.lblEmailText.TabIndex = 29
    '
    'lblPhone
    '
    Me.lblPhone.Location = New System.Drawing.Point(370, 86)
    Me.lblPhone.Name = "lblPhone"
    Me.lblPhone.Size = New System.Drawing.Size(100, 16)
    Me.lblPhone.TabIndex = 30
    Me.lblPhone.Text = "Phone &Number:"
    '
    'lblEmail
    '
    Me.lblEmail.Location = New System.Drawing.Point(234, 86)
    Me.lblEmail.Name = "lblEmail"
    Me.lblEmail.Size = New System.Drawing.Size(100, 16)
    Me.lblEmail.TabIndex = 28
    Me.lblEmail.Text = "E&mail:"
    '
    'btnLookup2
    '
    Me.btnLookup2.Location = New System.Drawing.Point(38, 150)
    Me.btnLookup2.Name = "btnLookup2"
    Me.btnLookup2.TabIndex = 21
    Me.btnLookup2.Text = "Lookup &2"
    '
    'btnLookup1
    '
    Me.btnLookup1.Location = New System.Drawing.Point(38, 114)
    Me.btnLookup1.Name = "btnLookup1"
    Me.btnLookup1.TabIndex = 20
    Me.btnLookup1.Text = "Lookup &1"
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(370, 22)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(100, 16)
    Me.label5.TabIndex = 26
    Me.label5.Text = "&Last Name:"
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(234, 22)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(100, 16)
    Me.label4.TabIndex = 24
    Me.label4.Text = "&First Name:"
    '
    'lblLastName
    '
    Me.lblLastName.Location = New System.Drawing.Point(370, 46)
    Me.lblLastName.Name = "lblLastName"
    Me.lblLastName.Size = New System.Drawing.Size(128, 16)
    Me.lblLastName.TabIndex = 27
    '
    'lblFirstName
    '
    Me.lblFirstName.Location = New System.Drawing.Point(234, 46)
    Me.lblFirstName.Name = "lblFirstName"
    Me.lblFirstName.Size = New System.Drawing.Size(116, 16)
    Me.lblFirstName.TabIndex = 25
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(150, 22)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(72, 16)
    Me.label1.TabIndex = 18
    Me.label1.Text = "&Employee ID:"
    '
    'cbEmpIds
    '
    Me.cbEmpIds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbEmpIds.Location = New System.Drawing.Point(150, 42)
    Me.cbEmpIds.Name = "cbEmpIds"
    Me.cbEmpIds.Size = New System.Drawing.Size(68, 21)
    Me.cbEmpIds.TabIndex = 19
    '
    'btnGetIDs
    '
    Me.btnGetIDs.Location = New System.Drawing.Point(38, 78)
    Me.btnGetIDs.Name = "btnGetIDs"
    Me.btnGetIDs.TabIndex = 17
    Me.btnGetIDs.Text = "&Get IDs"
    '
    'btnConnect
    '
    Me.btnConnect.Location = New System.Drawing.Point(38, 42)
    Me.btnConnect.Name = "btnConnect"
    Me.btnConnect.TabIndex = 16
    Me.btnConnect.Text = "C&onnect"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(536, 266)
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
    Me.Controls.Add(Me.lblLastName)
    Me.Controls.Add(Me.lblFirstName)
    Me.Controls.Add(Me.label1)
    Me.Controls.Add(Me.cbEmpIds)
    Me.Controls.Add(Me.btnGetIDs)
    Me.Controls.Add(Me.btnConnect)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Oracle Parameter Sample"
    Me.ResumeLayout(False)

  End Sub

#End Region
  Private oraConn As New OracleConnection
  Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    '// create a basic connection string Imports the sample
    '// Oracle HR user
    Dim connString As String = "User Id=hr; Password=demo; Data Source=oranet"

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

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub btnGetIDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetIDs.Click
    '// get the employee id's from the database
    '// we are not using the drop down list control
    '// as a databound control
    Dim cmdEmpId As OracleCommand = New OracleCommand
    cmdEmpId.CommandText = "select employee_id from employees order by employee_id"
    cmdEmpId.Connection = oraConn

    Try
      '// get a data reader
      Dim dataReader As OracleDataReader = cmdEmpId.ExecuteReader()

      '// simply iterate the result set and add
      '// the values to the drop down list
      While (dataReader.Read())
        cbEmpIds.Items.Add(dataReader.GetDecimal(0))
      End While

      dataReader.Dispose()
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Exception Caught")
    Finally
      cmdEmpId.Dispose()
    End Try
  End Sub

  Private Sub btnLookup1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookup1.Click
    Dim selectedItem As Object = cbEmpIds.SelectedItem

    If Not selectedItem Is Nothing Then
      '// get the employee name based on the employee id
      '// we will pass the employee id as a bind variable
      Dim cmdEmpName As OracleCommand = New OracleCommand

      '// the :p_id is our bind variable placeholder
      cmdEmpName.CommandText = "select first_name, last_name from employees where employee_id = :p_id"

      cmdEmpName.Connection = oraConn

      Dim p_id As New System.Data.OracleClient.OracleParameter

      '// here we are setting the DbType
      '// we could set this as DbType as well and
      '// the Oracle provider will infer the correct
      '// DbType
      p_id.DbType = DbType.Decimal
      p_id.Value = Convert.ToDecimal(selectedItem.ToString())
      p_id.ParameterName = "p_id"

      '// add our parameter to the parameter collection
      '// for the command object
      cmdEmpName.Parameters.Add(p_id)

      '// get our data reader
      Dim dataReader As OracleDataReader = cmdEmpName.ExecuteReader()

      '// get the results - our query will only return 1 row
      '// since we are using the primary key
      If dataReader.Read() Then
        lblFirstName.Text = dataReader.GetString(0)
        lblLastName.Text = dataReader.GetString(1)
      End If

      dataReader.Close()

      dataReader.Dispose()
      cmdEmpName.Dispose()
    End If
  End Sub

  Private Sub btnLookup2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookup2.Click
    '// get the employee email and phone based on the
    '// first name and last name
    '// there are no duplicate first name / last name
    '// combinations in the table
    '// we will pass the first name and last name as
    '// bind variables using BindByName
    Dim cmdEmpInfo As OracleCommand = New OracleCommand

    '// the :p_last and :p_first are our bind variable placeholders
    cmdEmpInfo.CommandText = "select email, phone_number from employees where first_name = :p_first and last_name = :p_last"

    cmdEmpInfo.Connection = oraConn

    '// we will use bind by name here
    '// cmdEmpInfo.BindByName = True

    Dim p1 As System.Data.OracleClient.OracleParameter = New System.Data.OracleClient.OracleParameter
    Dim p2 As System.Data.OracleClient.OracleParameter = New System.Data.OracleClient.OracleParameter

    '// the ParameterName value is what is used when
    '// binding by name, not the name of the variable
    '// in the code
    '// notice the ":" is not included as part of the
    '// parameter name
    p1.ParameterName = "p_first"
    p2.ParameterName = "p_last"

    p1.Value = lblFirstName.Text
    p2.Value = lblLastName.Text

    '// add our parameters to the parameter collection
    '// for the command object
    '// we will add them in "reverse" order since we are
    '// binding by name and not position
    cmdEmpInfo.Parameters.Add(p2)
    cmdEmpInfo.Parameters.Add(p1)

    '// get our data reader
    Dim dataReader As OracleDataReader = cmdEmpInfo.ExecuteReader()

    '// get the results - our query will only return 1 row
    '// since we are using known unique values for the first
    '// and last names
    If dataReader.Read() Then
      lblEmailText.Text = dataReader.GetString(0)
      lblPhoneText.Text = dataReader.GetString(1)
    End If

    dataReader.Close()

    dataReader.Dispose()
    cmdEmpInfo.Dispose()
  End Sub

  Private Sub btnNoBinds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoBinds.Click
    '// this illustrates the "traditional" approach
    '// that does not use bind variables

    Dim selectedItem As Object = cbEmpIds.SelectedItem

    If Not selectedItem Is Nothing Then
      Dim cmdNoBinds As OracleCommand = New OracleCommand
      cmdNoBinds.Connection = oraConn
      Dim dataReader As OracleDataReader

      cmdNoBinds.CommandText = "select first_name, last_name from employees where employee_id = " + selectedItem.ToString()

      '// get our data reader
      dataReader = cmdNoBinds.ExecuteReader()

      '// get the results - our query will only return 1 row
      '// since we are using the primary key
      If dataReader.Read() Then
        lblFirstName.Text = dataReader.GetString(0)
        lblLastName.Text = dataReader.GetString(1)
      End If

      dataReader.Close()

      '// get the data that Lookup 2 performed above
      cmdNoBinds.CommandText = "select email, phone_number from employees where first_name = '" + lblFirstName.Text + "' and last_name = '" + lblLastName.Text + "'"

      '// get our data reader
      dataReader = cmdNoBinds.ExecuteReader()

      '// get the results - our query will only return 1 row
      '// since we are using known unique values for the first
      '// and last names
      If dataReader.Read() Then
        lblEmailText.Text = dataReader.GetString(0)
        lblPhoneText.Text = dataReader.GetString(1)
      End If

      dataReader.Close()
      dataReader.Dispose()
      cmdNoBinds.Dispose()
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
