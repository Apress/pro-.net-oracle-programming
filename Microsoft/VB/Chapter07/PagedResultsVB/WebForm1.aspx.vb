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
  Protected WithEvents btnNext As System.Web.UI.WebControls.LinkButton
  Protected WithEvents btnPrevious As System.Web.UI.WebControls.LinkButton

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
    If Not IsPostBack Then
      '// fill grid starting with row 1
      '// and in the "next" direction
      fill_grid(1, 1)

      '// since we just loaded the grid
      '// there are no previous rows
      btnPrevious.Enabled = False
    End If
  End Sub
  Private Sub fill_grid(ByVal start_row As Integer, ByVal direction As Integer)
    '// set the non-inclusive value for the end row
    '// in our range
    Dim end_row As Integer = start_row + dgLeagueResults.PageSize

    '// create connection using the aspnet o/s account
    '// and the default database
    Dim connStr As String = "User Id=/; Integrated Security=true"
    Dim oraConn As OracleConnection = New OracleConnection(connStr)
    oraConn.Open()

    '// the query to retrieve the paged data from the
    '// league_results table owned by oranetuser
    Dim sql As String = "select * "
    sql += "from (select rownum rec_num, a.* "
    sql += "from (select * from oranetuser.league_results order by position) a "
    sql += "where rownum < :end_row) "
    sql += "where rec_num >= :start_row"

    '// create a data adapter
    Dim da As OracleDataAdapter = New OracleDataAdapter(sql, oraConn)

    '// Oracle parameter objects for the
    '// end and start row parameters
    Dim p_end_row As OracleParameter = New OracleParameter
    p_end_row.DbType = DbType.Decimal
    p_end_row.Value = end_row
    p_end_row.ParameterName = "end_row"

    Dim p_start_row As OracleParameter = New OracleParameter
    p_start_row.DbType = DbType.Decimal
    p_start_row.Value = start_row
    p_start_row.ParameterName = "start_row"

    '// add the parameters to the collection
    da.SelectCommand.Parameters.Add(p_end_row)
    da.SelectCommand.Parameters.Add(p_start_row)

    '// create a data set object
    Dim ds As DataSet = New DataSet

    '// fill the data set
    da.Fill(ds)

    '// used to determine if the query returned
    '// any rows from the database
    Dim t As Integer = ds.Tables(0).Rows.Count

    '// direction 1 == next
    If direction = 1 Then
      If t > 0 Then
        '// bind and fill the data grid
        dgLeagueResults.DataSource = ds
        dgLeagueResults.DataBind()

        If btnPrevious.Enabled = False Then
          btnPrevious.Enabled = True
        End If
      Else
        btnNext.Enabled = False
      End If
    Else
      If t > 0 Then
        '// bind and fill the data grid
        dgLeagueResults.DataSource = ds
        dgLeagueResults.DataBind()

        If btnNext.Enabled = False Then
          btnNext.Enabled = True
        End If
      Else
        btnPrevious.Enabled = False
      End If
    End If
  End Sub

  Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
    '// get the number of rows in the grid
    Dim numItems As Integer = dgLeagueResults.Items.Count
    Dim rec_num As Integer = 0

    If numItems > 0 Then
      '// get the record number for the last row in the grid
      rec_num = Convert.ToInt32(dgLeagueResults.Items(numItems - 1).Cells(0).Text)
    End If

    If rec_num > 0 Then
      '// fill the grid with the next range
      fill_grid(rec_num + 1, 1)
    End If
  End Sub

  Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
    '// get the number of rows in the grid
    Dim numItems As Integer = dgLeagueResults.Items.Count
    Dim rec_num As Integer = 0

    If numItems > 0 Then
      '// get the record number for the last row in the grid
      rec_num = Convert.ToInt32(dgLeagueResults.Items(numItems - 1).Cells(0).Text)
    End If

    If rec_num > 0 Then
      '// fill the grid with the previous range
      '// if the number of rows in the grid
      '// is not a multiple of the page size,
      '// adjust the starting point
      If (rec_num Mod dgLeagueResults.PageSize) = 0 Then
        fill_grid(rec_num - (dgLeagueResults.PageSize * 2) + 1, 0)
      Else
        rec_num = rec_num - (rec_num Mod dgLeagueResults.PageSize)
        fill_grid(rec_num - dgLeagueResults.PageSize + 1, 0)
      End If
    End If
  End Sub
End Class
