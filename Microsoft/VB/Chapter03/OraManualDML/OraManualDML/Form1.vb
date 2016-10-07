Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OracleClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  Public oraConn As OracleConnection = New OracleConnection

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
  Friend WithEvents btnDelete As System.Windows.Forms.Button
  Friend WithEvents btnUpdate As System.Windows.Forms.Button
  Friend WithEvents btnInsert As System.Windows.Forms.Button
  Friend WithEvents btnLookup As System.Windows.Forms.Button
  Friend WithEvents btnReset As System.Windows.Forms.Button
  Friend WithEvents txtClub As System.Windows.Forms.TextBox
  Friend WithEvents txtPosition As System.Windows.Forms.TextBox
  Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
  Friend WithEvents txtLastName As System.Windows.Forms.TextBox
  Friend WithEvents txtPlayerNum As System.Windows.Forms.TextBox
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents btnConnect As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.btnDelete = New System.Windows.Forms.Button
    Me.btnUpdate = New System.Windows.Forms.Button
    Me.btnInsert = New System.Windows.Forms.Button
    Me.btnLookup = New System.Windows.Forms.Button
    Me.btnReset = New System.Windows.Forms.Button
    Me.txtClub = New System.Windows.Forms.TextBox
    Me.txtPosition = New System.Windows.Forms.TextBox
    Me.txtFirstName = New System.Windows.Forms.TextBox
    Me.txtLastName = New System.Windows.Forms.TextBox
    Me.txtPlayerNum = New System.Windows.Forms.TextBox
    Me.label5 = New System.Windows.Forms.Label
    Me.label4 = New System.Windows.Forms.Label
    Me.label3 = New System.Windows.Forms.Label
    Me.label2 = New System.Windows.Forms.Label
    Me.label1 = New System.Windows.Forms.Label
    Me.btnConnect = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'btnDelete
    '
    Me.btnDelete.Location = New System.Drawing.Point(33, 197)
    Me.btnDelete.Name = "btnDelete"
    Me.btnDelete.TabIndex = 21
    Me.btnDelete.Text = "&Delete"
    '
    'btnUpdate
    '
    Me.btnUpdate.Location = New System.Drawing.Point(33, 161)
    Me.btnUpdate.Name = "btnUpdate"
    Me.btnUpdate.TabIndex = 20
    Me.btnUpdate.Text = "&Update"
    '
    'btnInsert
    '
    Me.btnInsert.Location = New System.Drawing.Point(33, 125)
    Me.btnInsert.Name = "btnInsert"
    Me.btnInsert.TabIndex = 19
    Me.btnInsert.Text = "&Insert"
    '
    'btnLookup
    '
    Me.btnLookup.Location = New System.Drawing.Point(33, 89)
    Me.btnLookup.Name = "btnLookup"
    Me.btnLookup.TabIndex = 18
    Me.btnLookup.Text = "Loo&kup"
    '
    'btnReset
    '
    Me.btnReset.Location = New System.Drawing.Point(33, 53)
    Me.btnReset.Name = "btnReset"
    Me.btnReset.TabIndex = 17
    Me.btnReset.Text = "&Reset"
    '
    'txtClub
    '
    Me.txtClub.Location = New System.Drawing.Point(225, 131)
    Me.txtClub.Name = "txtClub"
    Me.txtClub.Size = New System.Drawing.Size(160, 20)
    Me.txtClub.TabIndex = 31
    Me.txtClub.Text = ""
    '
    'txtPosition
    '
    Me.txtPosition.Location = New System.Drawing.Point(225, 103)
    Me.txtPosition.Name = "txtPosition"
    Me.txtPosition.Size = New System.Drawing.Size(160, 20)
    Me.txtPosition.TabIndex = 29
    Me.txtPosition.Text = ""
    '
    'txtFirstName
    '
    Me.txtFirstName.Location = New System.Drawing.Point(225, 75)
    Me.txtFirstName.Name = "txtFirstName"
    Me.txtFirstName.Size = New System.Drawing.Size(160, 20)
    Me.txtFirstName.TabIndex = 27
    Me.txtFirstName.Text = ""
    '
    'txtLastName
    '
    Me.txtLastName.Location = New System.Drawing.Point(225, 47)
    Me.txtLastName.Name = "txtLastName"
    Me.txtLastName.Size = New System.Drawing.Size(160, 20)
    Me.txtLastName.TabIndex = 25
    Me.txtLastName.Text = ""
    '
    'txtPlayerNum
    '
    Me.txtPlayerNum.Location = New System.Drawing.Point(225, 19)
    Me.txtPlayerNum.Name = "txtPlayerNum"
    Me.txtPlayerNum.Size = New System.Drawing.Size(160, 20)
    Me.txtPlayerNum.TabIndex = 23
    Me.txtPlayerNum.Text = ""
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(141, 133)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(84, 16)
    Me.label5.TabIndex = 30
    Me.label5.Text = "&Club:"
    Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(141, 105)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(84, 16)
    Me.label4.TabIndex = 28
    Me.label4.Text = "&Position:"
    Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(141, 77)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(84, 16)
    Me.label3.TabIndex = 26
    Me.label3.Text = "&First Name:"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(141, 49)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(84, 16)
    Me.label2.TabIndex = 24
    Me.label2.Text = "&Last Name:"
    Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(141, 21)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(84, 16)
    Me.label1.TabIndex = 22
    Me.label1.Text = "Player &Number:"
    Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'btnConnect
    '
    Me.btnConnect.Location = New System.Drawing.Point(33, 17)
    Me.btnConnect.Name = "btnConnect"
    Me.btnConnect.TabIndex = 16
    Me.btnConnect.Text = "C&onnect"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(418, 236)
    Me.Controls.Add(Me.btnDelete)
    Me.Controls.Add(Me.btnUpdate)
    Me.Controls.Add(Me.btnInsert)
    Me.Controls.Add(Me.btnLookup)
    Me.Controls.Add(Me.btnReset)
    Me.Controls.Add(Me.txtClub)
    Me.Controls.Add(Me.txtPosition)
    Me.Controls.Add(Me.txtFirstName)
    Me.Controls.Add(Me.txtLastName)
    Me.Controls.Add(Me.txtPlayerNum)
    Me.Controls.Add(Me.label5)
    Me.Controls.Add(Me.label4)
    Me.Controls.Add(Me.label3)
    Me.Controls.Add(Me.label2)
    Me.Controls.Add(Me.label1)
    Me.Controls.Add(Me.btnConnect)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Manual DML"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    '// create a basic connection string using our
    '// standard Oracle user
    Dim connString As String = "User Id=oranetuser; Password=demo; Data Source=oranet"

    '// only connect if we are not yet connected
    '// oraConn is a form-level, public field of type
    '// OracleConnection
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

  Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
    txtPlayerNum.Text = ""
    txtLastName.Text = ""
    txtFirstName.Text = ""
    txtPosition.Text = ""
    txtClub.Text = ""

    txtPlayerNum.Focus()
  End Sub

  Private Sub btnLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookup.Click
    '// perform this action if we are connected
    If oraConn.State = ConnectionState.Open Then
      '// sql statement to look up a player based on
      '// the player number
      '// we use a bind variable for the player number
      Dim sqlLookup As String = "select last_name, "
      sqlLookup += "first_name, "
      sqlLookup += "position, "
      sqlLookup += "club "
      sqlLookup += "from squad "
      sqlLookup += "where player_num = :player_num"

      '// create our command object and set properties
      Dim cmdLookup As OracleCommand = New OracleCommand
      cmdLookup.CommandText = sqlLookup
      cmdLookup.Connection = oraConn

      '// create our parameter object for the player number
      '// in our sample we are assuming a number is
      '// entered in the player number text box
      Dim pPlayerNum As OracleParameter = New OracleParameter
      pPlayerNum.DbType = DbType.Decimal
      pPlayerNum.Value = Convert.ToDecimal(txtPlayerNum.Text)
      pPlayerNum.ParameterName = "player_num"

      '// add the parameter to the collection
      cmdLookup.Parameters.Add(pPlayerNum)

      '// execute the sql statement and populate the text
      '// boxes if a record is returned
      Dim dataReader As OracleDataReader = cmdLookup.ExecuteReader()

      If dataReader.Read() Then
        txtLastName.Text = dataReader.GetString(0)
        txtFirstName.Text = dataReader.GetString(1)
        txtPosition.Text = dataReader.GetString(2)
        txtClub.Text = dataReader.GetString(3)
      Else
        MessageBox.Show("No record for Player Number Found", "No Record Found")
      End If

      '// explictly close and dispose our objects
      dataReader.Close()
      dataReader.Dispose()
      cmdLookup.Dispose()
    End If
  End Sub

  Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
    '// perform this action if we are connected
    If oraConn.State = ConnectionState.Open Then
      '// sql statement to insert a new record using binds
      Dim sqlInsert As String = "insert into squad "
      sqlInsert += "(player_num, last_name, first_name, position, club) "
      sqlInsert += "values (:p_num, :p_last, :p_first, :p_pos, :p_club)"

      '// create our command object and set properties
      Dim cmdInsert As OracleCommand = New OracleCommand
      cmdInsert.CommandText = sqlInsert
      cmdInsert.Connection = oraConn

      '// create our parameter object for the player number
      '// in our sample we are assuming a number is
      '// entered in the player number text box
      Dim pPlayerNum As OracleParameter = New OracleParameter
      pPlayerNum.DbType = DbType.Decimal
      pPlayerNum.Value = Convert.ToDecimal(txtPlayerNum.Text)

      '// create our parameter object for the last name
      '// in our sample we are assuming text is
      '// entered in the last name text box
      Dim pLastName As OracleParameter = New OracleParameter
      pLastName.Value = txtLastName.Text

      '// create our parameter object for the first name
      '// in our sample we are assuming text is
      '// entered in the first name text box
      Dim pFirstName As OracleParameter = New OracleParameter
      pFirstName.Value = txtFirstName.Text

      '// create our parameter object for the position
      '// in our sample we are assuming text is
      '// entered in the position text box
      Dim pPosition As OracleParameter = New OracleParameter
      pPosition.Value = txtPosition.Text

      '// create our parameter object for the club
      '// in our sample we are assuming text is
      '// entered in the club text box
      Dim pClub As OracleParameter = New OracleParameter
      pClub.Value = txtClub.Text

      pPlayerNum.ParameterName = "p_num"
      pLastName.ParameterName = "p_last"
      pFirstName.ParameterName = "p_first"
      pPosition.ParameterName = "p_pos"
      pClub.ParameterName = "p_club"

      '// add the parameters to the collection
      cmdInsert.Parameters.Add(pPlayerNum)
      cmdInsert.Parameters.Add(pLastName)
      cmdInsert.Parameters.Add(pFirstName)
      cmdInsert.Parameters.Add(pPosition)
      cmdInsert.Parameters.Add(pClub)

      '// execute the insert statement
      cmdInsert.ExecuteNonQuery()

      MessageBox.Show("Record Inserted Successfully", "Record Inserted")

      '// reset the form
      btnReset_Click(sender, e)

      '// explictly dispose our objects
      cmdInsert.Dispose()
    End If
  End Sub

  Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
    '// perform this action if we are connected
    If oraConn.State = ConnectionState.Open Then
      '// sql statement to update a record using binds
      Dim sqlUpdate As String = "update squad "
      sqlUpdate += "set last_name = :p_last, "
      sqlUpdate += "first_name = :p_first, "
      sqlUpdate += "position = :p_pos, "
      sqlUpdate += "club = :p_club "
      sqlUpdate += "where player_num = :p_num"

      '// create our command object and set properties
      Dim cmdUpdate As OracleCommand = New OracleCommand
      cmdUpdate.CommandText = sqlUpdate
      cmdUpdate.Connection = oraConn

      '// create our parameter object for the player number
      '// in our sample we are assuming a number is
      '// entered in the player number text box
      Dim pPlayerNum As OracleParameter = New OracleParameter
      pPlayerNum.DbType = DbType.Decimal
      pPlayerNum.Value = Convert.ToDecimal(txtPlayerNum.Text)

      '// create our parameter object for the last name
      '// in our sample we are assuming text is
      '// entered in the last name text box
      Dim pLastName As OracleParameter = New OracleParameter
      pLastName.Value = txtLastName.Text

      '// create our parameter object for the first name
      '// in our sample we are assuming text is
      '// entered in the first name text box
      Dim pFirstName As OracleParameter = New OracleParameter
      pFirstName.Value = txtFirstName.Text

      '// create our parameter object for the position
      '// in our sample we are assuming text is
      '// entered in the position text box
      Dim pPosition As OracleParameter = New OracleParameter
      pPosition.Value = txtPosition.Text

      '// create our parameter object for the club
      '// in our sample we are assuming text is
      '// entered in the club text box
      Dim pClub As OracleParameter = New OracleParameter
      pClub.Value = txtClub.Text

      pPlayerNum.ParameterName = "p_num"
      pLastName.ParameterName = "p_last"
      pFirstName.ParameterName = "p_first"
      pPosition.ParameterName = "p_pos"
      pClub.ParameterName = "p_club"

      '// add the parameters to the collection
      cmdUpdate.Parameters.Add(pLastName)
      cmdUpdate.Parameters.Add(pFirstName)
      cmdUpdate.Parameters.Add(pPosition)
      cmdUpdate.Parameters.Add(pClub)
      cmdUpdate.Parameters.Add(pPlayerNum)

      '// execute the update statement
      cmdUpdate.ExecuteNonQuery()

      MessageBox.Show("Record Updated Successfully", "Record Updated")

      '// reset the form
      btnReset_Click(sender, e)

      '// explictly dispose our objects
      cmdUpdate.Dispose()
    End If
  End Sub

  Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    '// perform this action if we are connected
    If oraConn.State = ConnectionState.Open Then
      '// sql statement to delete a record using a bind
      Dim sqlDelete As String = "delete from squad where player_num = :p_num"

      '// create our command object and set properties
      Dim cmdDelete As OracleCommand = New OracleCommand
      cmdDelete.CommandText = sqlDelete
      cmdDelete.Connection = oraConn

      '// create our parameter object for the player number
      '// in our sample we are assuming a number is
      '// entered in the player number text box
      Dim pPlayerNum As OracleParameter = New OracleParameter
      pPlayerNum.DbType = DbType.Decimal
      pPlayerNum.Value = Convert.ToDecimal(txtPlayerNum.Text)
      pPlayerNum.ParameterName = "p_num"

      '// add the parameters to the collection
      cmdDelete.Parameters.Add(pPlayerNum)

      '// execute the delete statement
      cmdDelete.ExecuteNonQuery()

      MessageBox.Show("Record Deleted Successfully", "Record Deleted")

      '// reset the form
      btnReset_Click(sender, e)

      '// explictly dispose our objects
      cmdDelete.Dispose()
    End If
  End Sub
End Class
