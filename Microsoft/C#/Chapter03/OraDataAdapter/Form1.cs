using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OracleClient;

namespace OraDataAdapter01
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
      this.btnClear = new System.Windows.Forms.Button();
      this.btnLoad = new System.Windows.Forms.Button();
      this.dgSquad = new System.Windows.Forms.DataGrid();
      this.btnUpdate = new System.Windows.Forms.Button();
      this.btnBind = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgSquad)).BeginInit();
      this.SuspendLayout();
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(16, 12);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.TabIndex = 0;
      this.btnConnect.Text = "C&onnect";
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(16, 84);
      this.btnClear.Name = "btnClear";
      this.btnClear.TabIndex = 2;
      this.btnClear.Text = "&Clear Grid";
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnLoad
      // 
      this.btnLoad.Location = new System.Drawing.Point(16, 120);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.TabIndex = 3;
      this.btnLoad.Text = "&Load Grid";
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // dgSquad
      // 
      this.dgSquad.DataMember = "";
      this.dgSquad.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dgSquad.Location = new System.Drawing.Point(108, 12);
      this.dgSquad.Name = "dgSquad";
      this.dgSquad.Size = new System.Drawing.Size(476, 244);
      this.dgSquad.TabIndex = 5;
      // 
      // btnUpdate
      // 
      this.btnUpdate.Location = new System.Drawing.Point(16, 156);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.TabIndex = 4;
      this.btnUpdate.Text = "U&pdate";
      this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
      // 
      // btnBind
      // 
      this.btnBind.Location = new System.Drawing.Point(16, 48);
      this.btnBind.Name = "btnBind";
      this.btnBind.TabIndex = 1;
      this.btnBind.Text = "&Bind";
      this.btnBind.Click += new System.EventHandler(this.btnBind_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(594, 266);
      this.Controls.Add(this.btnBind);
      this.Controls.Add(this.btnUpdate);
      this.Controls.Add(this.dgSquad);
      this.Controls.Add(this.btnLoad);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.btnConnect);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "OracleDataAdapter Sample";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgSquad)).EndInit();
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
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.DataGrid dgSquad;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnBind;

    public OracleConnection oraConn;
    public OracleDataAdapter oraAdapter;
    public OracleCommandBuilder oraBuilder;
    public DataSet dsSquad;

    private void btnConnect_Click(object sender, System.EventArgs e)
    {
      // create a basic connection string using our
      // standard Oracle user
      string connString = "User Id=oranetuser; Password=demo; Data Source=oranet";

      // only connect if we are not yet connected
      if (oraConn.State != ConnectionState.Open)
      {
        try
        {
          oraConn.ConnectionString = connString;

          oraConn.Open();

          MessageBox.Show(oraConn.ConnectionString, "Successful Connection");
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message,"Exception Caught");
        }
      }    
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
      oraConn = new OracleConnection();
    }

    private void btnBind_Click(object sender, System.EventArgs e)
    {
      if (oraConn.State == ConnectionState.Open)
      {
        string strSelect = "select player_num, ";
        strSelect += "last_name, ";
        strSelect += "first_name, ";
        strSelect += "position, ";
        strSelect += "club ";
        strSelect += "from squad ";
        strSelect += "order by player_num";

        oraAdapter = new OracleDataAdapter(strSelect, oraConn);

        oraBuilder = new OracleCommandBuilder(oraAdapter);

        dsSquad = new DataSet("dsSquad");

        oraAdapter.Fill(dsSquad,"SQUAD");

        dgSquad.SetDataBinding(dsSquad,"SQUAD");

        btnBind.Enabled = false;
      }
    }

    private void btnClear_Click(object sender, System.EventArgs e)
    {
      dsSquad.Clear();
      dgSquad.SetDataBinding(null,null);
    }

    private void btnLoad_Click(object sender, System.EventArgs e)
    {
      btnClear_Click(sender, e);

      oraAdapter.Fill(dsSquad,"SQUAD");

      dgSquad.SetDataBinding(dsSquad,"SQUAD");      
    }

    private void btnUpdate_Click(object sender, System.EventArgs e)
    {
      oraAdapter.Update(dsSquad,"SQUAD");
    }
  }
}
