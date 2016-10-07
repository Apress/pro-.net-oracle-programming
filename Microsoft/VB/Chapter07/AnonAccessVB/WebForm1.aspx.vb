Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Data.OracleClient
Public Class WebForm1
  Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents dgLeagueResults As System.Web.UI.WebControls.DataGrid
  Protected WithEvents btnPopulate As System.Web.UI.WebControls.Button

  'NOTE: The following placeholder declaration is required by the Web Form Designer.
  'Do not delete or move it.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Put user code to initialize the page here
  End Sub

  Private Sub btnPopulate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPopulate.Click
    '// create connection using the aspnet o/s account
    '// and the default database
    Dim connStr As String = "User Id=/; Integrated Security=true"
    Dim oraConn As OracleConnection = New OracleConnection(connStr)
    oraConn.Open()

    '// the query to retrieve the data from the
    '// league_results table owned by oranetuser
    Dim sql As String = "select * from oranetuser.league_results order by position"

    '// create a data adapter
    Dim da As OracleDataAdapter = New OracleDataAdapter(sql, oraConn)

    '// create a data set object
    Dim ds As DataSet = New DataSet

    '// fill the data set
    da.Fill(ds)

    '// bind and fill the data grid
    dgLeagueResults.DataSource = ds
    dgLeagueResults.DataBind()
  End Sub
End Class
