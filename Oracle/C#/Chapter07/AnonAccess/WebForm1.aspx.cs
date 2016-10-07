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
using Oracle.DataAccess.Client;

namespace AnonAccess
{
  /// <summary>
  /// Summary description for WebForm1.
  /// </summary>
  public class WebForm1 : System.Web.UI.Page
  {
    protected System.Web.UI.WebControls.Button btnPopulate;
    protected System.Web.UI.WebControls.DataGrid dgLeagueResults;
  
    private void Page_Load(object sender, System.EventArgs e)
    {
      // Put user code to initialize the page here
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
      this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
      this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    private void btnPopulate_Click(object sender, System.EventArgs e)
    {
      // create connection using the aspnet o/s account
      // and the default database
      string connStr = "User Id=/";
      OracleConnection oraConn = new OracleConnection(connStr);
      oraConn.Open();

      // the query to retrieve the data from the
      // league_results table owned by oranetuser
      string sql = "select * from oranetuser.league_results order by position";

      // create a data adapter
      OracleDataAdapter da = new OracleDataAdapter(sql, oraConn);

      // create a data set object
      DataSet ds = new DataSet();

      // fill the data set
      da.Fill(ds);

      // bind and fill the data grid
      dgLeagueResults.DataSource = ds;
      dgLeagueResults.DataBind();
    }
  }
}
