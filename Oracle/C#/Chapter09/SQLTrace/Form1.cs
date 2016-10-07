using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Oracle.DataAccess.Client;

namespace SQLTrace
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public Form1()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if (components != null) 
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnConnect = new System.Windows.Forms.Button();
      this.btnLoadTeams = new System.Windows.Forms.Button();
      this.btnLookup = new System.Windows.Forms.Button();
      this.lblTraceLevel = new System.Windows.Forms.Label();
      this.cbTraceLevel = new System.Windows.Forms.ComboBox();
      this.lblTeams = new System.Windows.Forms.Label();
      this.cbTeams = new System.Windows.Forms.ComboBox();
      this.lblPosition = new System.Windows.Forms.Label();
      this.lblPlayed = new System.Windows.Forms.Label();
      this.lblWins = new System.Windows.Forms.Label();
      this.lblDraws = new System.Windows.Forms.Label();
      this.lblLosses = new System.Windows.Forms.Label();
      this.lblGoalsFor = new System.Windows.Forms.Label();
      this.lblGoalsAgainst = new System.Windows.Forms.Label();
      this.btnReset = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(16, 16);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.TabIndex = 0;
      this.btnConnect.Text = "C&onnect";
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // btnLoadTeams
      // 
      this.btnLoadTeams.Location = new System.Drawing.Point(16, 52);
      this.btnLoadTeams.Name = "btnLoadTeams";
      this.btnLoadTeams.TabIndex = 3;
      this.btnLoadTeams.Text = "&Load";
      this.btnLoadTeams.Click += new System.EventHandler(this.btnLoadTeams_Click);
      // 
      // btnLookup
      // 
      this.btnLookup.Location = new System.Drawing.Point(16, 88);
      this.btnLookup.Name = "btnLookup";
      this.btnLookup.TabIndex = 6;
      this.btnLookup.Text = "Loo&kup";
      this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
      // 
      // lblTraceLevel
      // 
      this.lblTraceLevel.Location = new System.Drawing.Point(116, 20);
      this.lblTraceLevel.Name = "lblTraceLevel";
      this.lblTraceLevel.Size = new System.Drawing.Size(68, 16);
      this.lblTraceLevel.TabIndex = 1;
      this.lblTraceLevel.Text = "&Trace Level:";
      this.lblTraceLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbTraceLevel
      // 
      this.cbTraceLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTraceLevel.Items.AddRange(new object[] {
                                                      "0",
                                                      "1",
                                                      "4",
                                                      "8",
                                                      "12"});
      this.cbTraceLevel.Location = new System.Drawing.Point(192, 16);
      this.cbTraceLevel.Name = "cbTraceLevel";
      this.cbTraceLevel.Size = new System.Drawing.Size(56, 21);
      this.cbTraceLevel.TabIndex = 2;
      // 
      // lblTeams
      // 
      this.lblTeams.Location = new System.Drawing.Point(116, 56);
      this.lblTeams.Name = "lblTeams";
      this.lblTeams.Size = new System.Drawing.Size(68, 16);
      this.lblTeams.TabIndex = 4;
      this.lblTeams.Text = "Tea&ms:";
      this.lblTeams.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbTeams
      // 
      this.cbTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTeams.Location = new System.Drawing.Point(192, 52);
      this.cbTeams.Name = "cbTeams";
      this.cbTeams.Size = new System.Drawing.Size(168, 21);
      this.cbTeams.TabIndex = 5;
      // 
      // lblPosition
      // 
      this.lblPosition.Location = new System.Drawing.Point(116, 92);
      this.lblPosition.Name = "lblPosition";
      this.lblPosition.Size = new System.Drawing.Size(172, 16);
      this.lblPosition.TabIndex = 8;
      this.lblPosition.Text = "Position:";
      this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblPlayed
      // 
      this.lblPlayed.Location = new System.Drawing.Point(116, 120);
      this.lblPlayed.Name = "lblPlayed";
      this.lblPlayed.Size = new System.Drawing.Size(172, 16);
      this.lblPlayed.TabIndex = 9;
      this.lblPlayed.Text = "Played:";
      this.lblPlayed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblWins
      // 
      this.lblWins.Location = new System.Drawing.Point(116, 148);
      this.lblWins.Name = "lblWins";
      this.lblWins.Size = new System.Drawing.Size(172, 16);
      this.lblWins.TabIndex = 10;
      this.lblWins.Text = "Wins:";
      this.lblWins.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblDraws
      // 
      this.lblDraws.Location = new System.Drawing.Point(116, 176);
      this.lblDraws.Name = "lblDraws";
      this.lblDraws.Size = new System.Drawing.Size(172, 16);
      this.lblDraws.TabIndex = 11;
      this.lblDraws.Text = "Draws:";
      this.lblDraws.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblLosses
      // 
      this.lblLosses.Location = new System.Drawing.Point(116, 204);
      this.lblLosses.Name = "lblLosses";
      this.lblLosses.Size = new System.Drawing.Size(172, 16);
      this.lblLosses.TabIndex = 12;
      this.lblLosses.Text = "Losses:";
      this.lblLosses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblGoalsFor
      // 
      this.lblGoalsFor.Location = new System.Drawing.Point(116, 232);
      this.lblGoalsFor.Name = "lblGoalsFor";
      this.lblGoalsFor.Size = new System.Drawing.Size(172, 16);
      this.lblGoalsFor.TabIndex = 13;
      this.lblGoalsFor.Text = "Goals For:";
      this.lblGoalsFor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblGoalsAgainst
      // 
      this.lblGoalsAgainst.Location = new System.Drawing.Point(116, 260);
      this.lblGoalsAgainst.Name = "lblGoalsAgainst";
      this.lblGoalsAgainst.Size = new System.Drawing.Size(172, 16);
      this.lblGoalsAgainst.TabIndex = 14;
      this.lblGoalsAgainst.Text = "Goals Against:";
      this.lblGoalsAgainst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnReset
      // 
      this.btnReset.Location = new System.Drawing.Point(16, 124);
      this.btnReset.Name = "btnReset";
      this.btnReset.TabIndex = 7;
      this.btnReset.Text = "&Reset";
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(514, 296);
      this.Controls.Add(this.btnReset);
      this.Controls.Add(this.lblGoalsAgainst);
      this.Controls.Add(this.lblGoalsFor);
      this.Controls.Add(this.lblLosses);
      this.Controls.Add(this.lblDraws);
      this.Controls.Add(this.lblWins);
      this.Controls.Add(this.lblPlayed);
      this.Controls.Add(this.lblPosition);
      this.Controls.Add(this.cbTeams);
      this.Controls.Add(this.lblTeams);
      this.Controls.Add(this.cbTraceLevel);
      this.Controls.Add(this.lblTraceLevel);
      this.Controls.Add(this.btnLookup);
      this.Controls.Add(this.btnLoadTeams);
      this.Controls.Add(this.btnConnect);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "SQLTrace Sample";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() 
    {
      Application.Run(new Form1());
    }

    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Button btnLoadTeams;
    private System.Windows.Forms.Button btnLookup;
    private System.Windows.Forms.ComboBox cbTraceLevel;
    private System.Windows.Forms.ComboBox cbTeams;
    private System.Windows.Forms.Label lblPosition;
    private System.Windows.Forms.Label lblPlayed;
    private System.Windows.Forms.Label lblWins;
    private System.Windows.Forms.Label lblDraws;
    private System.Windows.Forms.Label lblLosses;
    private System.Windows.Forms.Label lblGoalsFor;
    private System.Windows.Forms.Label lblGoalsAgainst;
    private System.Windows.Forms.Label lblTraceLevel;
    private System.Windows.Forms.Label lblTeams;
    private System.Windows.Forms.Button btnReset;

    private OracleConnection oraConn;

    private void Form1_Load(object sender, System.EventArgs e)
    {
      oraConn = new OracleConnection();
      cbTraceLevel.SelectedIndex = 0;
    }

    private void btnConnect_Click(object sender, System.EventArgs e)
    {
      // create our standard connection string
      string connString = "User Id=oranetuser; Password=demo; Data Source=oranet";

      // only connect if we are not yet connected
      if (oraConn.State != ConnectionState.Open)
      {
        try
        {
          oraConn = new OracleConnection(connString);

          oraConn.Open();

          MessageBox.Show(oraConn.ConnectionString, "Successful Connection");
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message,"Exception Caught");
        }
      }
    }

    private void btnLoadTeams_Click(object sender, System.EventArgs e)
    {
      if (oraConn.State == ConnectionState.Open)
      {
        // remove any existing items
        cbTeams.Items.Clear();

        // get list of teams from database
        // and populate
        string sql = "select team from league_results order by team";

        OracleCommand cmd = new OracleCommand(sql, oraConn);

        OracleDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read())
        {
          if (!dataReader.IsDBNull(0))
          {
            cbTeams.Items.Add(dataReader[0].ToString());
          }
        }

        if (cbTeams.Items.Count > 0)
        {
          cbTeams.SelectedIndex = 0;
        }
      }
    }

    private void btnLookup_Click(object sender, System.EventArgs e)
    {
      if (oraConn.State == ConnectionState.Open)
      {
        string traceLevel = cbTraceLevel.SelectedItem.ToString();
        
        string traceSQL = "alter session set events ";

        if (traceLevel != "0")
        {
          // turn on tracing
          traceSQL += "'10046 trace name context forever, level " + traceLevel + "'";
        }
        else
        {
          // turn off tracing
          traceSQL += "'10046 trace name context off'";
        }

        string selectSQL = "select position, ";
        selectSQL += "played, ";
        selectSQL += "wins, ";
        selectSQL += "draws, ";
        selectSQL += "losses, ";
        selectSQL += "goals_for, ";
        selectSQL += "goals_against ";
        selectSQL += "from league_results ";
        selectSQL += "where team = :team";

        OracleParameter p_team = new OracleParameter();
        p_team.Size = 32;
        p_team.Value = cbTeams.SelectedItem.ToString();

        // create the oracle command object
        // and set the trace level
        OracleCommand cmd = new OracleCommand(traceSQL, oraConn);
        cmd.ExecuteNonQuery();

        // assign the text for selecting the data
        cmd.CommandText = selectSQL;
        
        // add the parameter to the collection
        cmd.Parameters.Add(p_team);

        // get a data reader object
        OracleDataReader dataReader = cmd.ExecuteReader();

        // populate labels with data from data reader
        if (dataReader.Read())
        {
          // position
          if (!dataReader.IsDBNull(0))
          {
            lblPosition.Text = "Position: " + dataReader[0].ToString();
          }

          // played
          if (!dataReader.IsDBNull(1))
          {
            lblPlayed.Text = "Played: " + dataReader[1].ToString();
          }

          // wins
          if (!dataReader.IsDBNull(2))
          {
            lblWins.Text = "Wins: " + dataReader[2].ToString();
          }

          // draws
          if (!dataReader.IsDBNull(3))
          {
            lblDraws.Text = "Draws: " + dataReader[3].ToString();
          }

          // losses
          if (!dataReader.IsDBNull(4))
          {
            lblLosses.Text = "Losses: " + dataReader[4].ToString();
          }

          // goals for
          if (!dataReader.IsDBNull(5))
          {
            lblGoalsFor.Text = "Goals For: " + dataReader[5].ToString();
          }

          // goals against
          if (!dataReader.IsDBNull(6))
          {
            lblGoalsAgainst.Text = "Goals Against: " + dataReader[6].ToString();
          }
        }
      }
    }

    private void btnReset_Click(object sender, System.EventArgs e)
    {
      lblPosition.Text = "Position:";
      lblPlayed.Text = "Played:";
      lblWins.Text = "Wins:";
      lblDraws.Text = "Draws:";
      lblLosses.Text = "Losses:";
      lblGoalsFor.Text = "Goals For:";
      lblGoalsAgainst.Text = "Goals Against:";
    }
  }
}
