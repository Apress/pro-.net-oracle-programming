using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

namespace PagedResults
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	/// 
	public class WebForm1 : System.Web.UI.Page
	{
    protected System.Web.UI.WebControls.LinkButton btnPrevious;
    protected System.Web.UI.WebControls.DataGrid dgLeagueResults;
    protected System.Web.UI.WebControls.LinkButton btnNext;

    private void fill_grid(int start_row, int direction)
    {
      // set the non-inclusive value for the end row
      // in our range
      int end_row = start_row + dgLeagueResults.PageSize;

      // create connection using the aspnet o/s account
      // and the default database
      string connStr = "User Id=/; Integrated Security=true";
      OracleConnection oraConn = new OracleConnection(connStr);
      oraConn.Open();

      // the query to retrieve the paged data from the
      // league_results table owned by oranetuser
      string sql = "select * ";
      sql += "from (select rownum rec_num, a.* ";
      sql += "from (select * from oranetuser.league_results order by position) a ";
      sql += "where rownum < :end_row) ";
      sql += "where rec_num >= :start_row";

      // create a data adapter
      OracleDataAdapter da = new OracleDataAdapter(sql, oraConn);

      // Oracle parameter objects for the
      // end and start row parameters
      OracleParameter p_end_row = new OracleParameter();
      p_end_row.DbType = DbType.Decimal;
      p_end_row.Value = end_row;
      p_end_row.ParameterName = "end_row";

      OracleParameter p_start_row = new OracleParameter();
      p_start_row.DbType = DbType.Decimal;
      p_start_row.Value = start_row;
      p_start_row.ParameterName = "start_row";

      // add the parameters to the collection
      da.SelectCommand.Parameters.Add(p_end_row);
      da.SelectCommand.Parameters.Add(p_start_row);

      // create a data set object
      DataSet ds = new DataSet();

      // fill the data set
      da.Fill(ds);

      // used to determine if the query returned
      // any rows from the database
      int t = ds.Tables[0].Rows.Count;

      // direction 1 == next
      if (direction == 1)
      {
        if (t > 0)
        {
          // bind and fill the data grid
          dgLeagueResults.DataSource = ds;
          dgLeagueResults.DataBind();

          if (btnPrevious.Enabled == false)
          {
            btnPrevious.Enabled = true;
          }
        }
        else
        {
          btnNext.Enabled = false;
        }
      }
      else
      {
        if (t > 0)
        {
          // bind and fill the data grid
          dgLeagueResults.DataSource = ds;
          dgLeagueResults.DataBind();

          if (btnNext.Enabled == false)
          {
            btnNext.Enabled = true;
          }
        }
        else
        {
          btnPrevious.Enabled = false;
        }
      }
    }

    private void Page_Load(object sender, System.EventArgs e)
    {
      if (!IsPostBack)
      {
        // fill grid starting with row 1
        // and in the "next" direction
        fill_grid(1,1);

        // since we just loaded the grid
        // there are no previous rows
        btnPrevious.Enabled = false;
      }
    }

    private void btnNext_Click(object sender, System.EventArgs e)
    {
      // get the number of rows in the grid
      int numItems = dgLeagueResults.Items.Count;
      int rec_num = 0;

      if (numItems > 0)
      {
        // get the record number for the last row in the grid
        rec_num = Convert.ToInt32(dgLeagueResults.Items[numItems - 1].Cells[0].Text);
      }

      if (rec_num > 0)
      {
        // fill the grid with the next range
        fill_grid(rec_num + 1,1);
      }
    }

    private void btnPrevious_Click(object sender, System.EventArgs e)
    {
      // get the number of rows in the grid
      int numItems = dgLeagueResults.Items.Count;
      int rec_num = 0;

      if (numItems > 0)
      {
        // get the record number for the last row in the grid
        rec_num = Convert.ToInt32(dgLeagueResults.Items[numItems - 1].Cells[0].Text);
      }

      if (rec_num > 0)
      {
        // fill the grid with the previous range
        // if the number of rows in the grid
        // is not a multiple of the page size,
        // adjust the starting point
        if ((rec_num % dgLeagueResults.PageSize) == 0)
        {
          fill_grid(rec_num - (dgLeagueResults.PageSize * 2) + 1,0);
        }
        else
        {
          rec_num = rec_num - (rec_num % dgLeagueResults.PageSize);
          fill_grid(rec_num - dgLeagueResults.PageSize + 1,0);
        }
      }
    }

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
      this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
      this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
      this.Load += new System.EventHandler(this.Page_Load);

    }
		#endregion
	}
}
