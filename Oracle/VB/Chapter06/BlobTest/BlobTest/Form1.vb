Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
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
  Friend WithEvents btnClear As System.Windows.Forms.Button
  Friend WithEvents pictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents btnDisplay As System.Windows.Forms.Button
  Friend WithEvents btnLoad As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.btnClear = New System.Windows.Forms.Button
    Me.pictureBox1 = New System.Windows.Forms.PictureBox
    Me.btnDisplay = New System.Windows.Forms.Button
    Me.btnLoad = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'btnClear
    '
    Me.btnClear.Location = New System.Drawing.Point(12, 90)
    Me.btnClear.Name = "btnClear"
    Me.btnClear.TabIndex = 5
    Me.btnClear.Text = "&Clear"
    '
    'pictureBox1
    '
    Me.pictureBox1.BackColor = System.Drawing.Color.White
    Me.pictureBox1.Location = New System.Drawing.Point(104, 18)
    Me.pictureBox1.Name = "pictureBox1"
    Me.pictureBox1.Size = New System.Drawing.Size(760, 476)
    Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.pictureBox1.TabIndex = 6
    Me.pictureBox1.TabStop = False
    '
    'btnDisplay
    '
    Me.btnDisplay.Location = New System.Drawing.Point(12, 54)
    Me.btnDisplay.Name = "btnDisplay"
    Me.btnDisplay.TabIndex = 4
    Me.btnDisplay.Text = "&Display"
    '
    'btnLoad
    '
    Me.btnLoad.Location = New System.Drawing.Point(12, 18)
    Me.btnLoad.Name = "btnLoad"
    Me.btnLoad.TabIndex = 3
    Me.btnLoad.Text = "&Load File"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(952, 512)
    Me.Controls.Add(Me.btnClear)
    Me.Controls.Add(Me.pictureBox1)
    Me.Controls.Add(Me.btnDisplay)
    Me.Controls.Add(Me.btnLoad)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "BLOB Sample"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    '// create our standard connection
    Dim connStr As String = "User Id=oranetuser; Password=demo; Data Source=oranet"
    Dim con As OracleConnection = New OracleConnection(connStr)

    con.Open()

    MessageBox.Show("Truncating table...", "BLOB Sample")

    '// ensure the table is empty
    Dim sql As String = "truncate table blob_test"

    Dim cmd As OracleCommand = New OracleCommand(sql, con)

    cmd.ExecuteNonQuery()

    MessageBox.Show("Table truncated.", "BLOB Sample")

    MessageBox.Show("Loading table...", "BLOB Sample")

    '// build the anonymous block and execute it
    sql = "declare"
    sql += "  /* local variables to hold the lob locators */"
    sql += "  l_blob  blob;"
    sql += "  l_bfile bfile;"
    sql += "begin"
    sql += "  /* this is a method to get the lob locator */"
    sql += "  /* for the lob column in the table */"
    sql += "  /* by inserting an empty_clob and returning */"
    sql += "  /* into the local clob variable, we easily */"
    sql += "  /* acquire the lob locator */"
    sql += "  insert into blob_test (blob_id, blob_data)"
    sql += "  values (1, empty_blob())"
    sql += "  returning blob_data into l_blob;"
    sql += "  /* this is the file we will load */"
    sql += "  l_bfile := bfilename('C_TEMP', 'APRESS_WEBSITE.TIF');"
    sql += "  /* the file must be opened prior to loading */"
    sql += "  dbms_lob.fileopen(l_bfile);"
    sql += "  /* this procedure performs the actual data load */"
    sql += "  dbms_lob.loadfromfile(l_blob, l_bfile, dbms_lob.getlength(l_bfile));"
    sql += "  /* close the bfile after loading it */"
    sql += "  dbms_lob.fileclose(l_bfile);"
    sql += "  /* commit the transaction */"
    sql += "  commit;"
    sql += "end;"

    cmd.CommandText = sql

    cmd.ExecuteNonQuery()

    MessageBox.Show("Table loaded.", "BLOB Sample")
  End Sub

  Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
    '// create our standard connection
    Dim connStr As String = "User Id=oranetuser; Password=demo; Data Source=oranet"
    Dim con As OracleConnection = New OracleConnection(connStr)

    con.Open()

    Dim sql As String = "select blob_data from blob_test where blob_id = 1"

    Dim cmd As OracleCommand = New OracleCommand(sql, con)

    Dim dataReader As OracleDataReader = cmd.ExecuteReader()

    '// read the single row result
    dataReader.Read()

    '// use typed accessor to retrieve the blob
    Dim blob As OracleBlob = dataReader.GetOracleBlob(0)

    '// we are done with the reader now, so we can close it
    dataReader.Close()

    '// create a memory stream from the blob
    Dim ms As MemoryStream = New MemoryStream(blob.Value)

    '// set the image property equal to a bitmap
    '// created from the memory stream
    pictureBox1.Image = New Bitmap(ms)
  End Sub

  Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
    '// simply set the image property to null
    '// to 'clear' the picture box control
    pictureBox1.Image = Nothing
  End Sub
End Class
