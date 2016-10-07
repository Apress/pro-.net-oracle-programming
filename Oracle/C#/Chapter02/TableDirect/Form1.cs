using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Oracle.DataAccess.Client;

namespace Tying3
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Button btnRetrieve;
    private System.Windows.Forms.ListBox listJobs;
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
      this.btnRetrieve = new System.Windows.Forms.Button();
      this.listJobs = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(12, 28);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.TabIndex = 0;
      this.btnConnect.Text = "C&onnect";
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // btnRetrieve
      // 
      this.btnRetrieve.Location = new System.Drawing.Point(12, 64);
      this.btnRetrieve.Name = "btnRetrieve";
      this.btnRetrieve.TabIndex = 1;
      this.btnRetrieve.Text = "&Retrieve";
      this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
      // 
      // listJobs
      // 
      this.listJobs.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.listJobs.ItemHeight = 15;
      this.listJobs.Location = new System.Drawing.Point(100, 28);
      this.listJobs.Name = "listJobs";
      this.listJobs.Size = new System.Drawing.Size(524, 244);
      this.listJobs.TabIndex = 2;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(634, 284);
      this.Controls.Add(this.listJobs);
      this.Controls.Add(this.btnRetrieve);
      this.Controls.Add(this.btnConnect);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "TableDirect Sample";
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

    private void btnConnect_Click(object sender, System.EventArgs e)
    {
      // create a basic connection string using the sample
      // Oracle HR user
      string connString = "User Id=hr; Password=demo; Data Source=oranet";

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

    private OracleConnection oraConn;

    private void Form1_Load(object sender, System.EventArgs e)
    {
      oraConn = new OracleConnection();
    }

    private void btnRetrieve_Click(object sender, System.EventArgs e)
    {
      // create an OracleCommand object
      // we will use the TableDirect method
      // and the JOBS table
      OracleCommand cmdEmployees = new OracleCommand();
      cmdEmployees.Connection = oraConn;
      cmdEmployees.CommandType = CommandType.TableDirect;
      cmdEmployees.CommandText = "JOBS";

      // build a string that will make the header row
      // in the list box
      string headText = "Job".PadRight(12);
      headText += "Title".PadRight(37);
      headText += "Min Salary".PadRight(12);
      headText += "Max Salary".PadRight(12);

      // build a string that will separate the heading
      // row from the data
      string headSep = "==========  ";
      headSep += "===================================  ";
      headSep += "==========  ";
      headSep += "==========  ";

      if (oraConn.State == ConnectionState.Open)
      {
        try
        {
          // get a data reader
          OracleDataReader dataReader = cmdEmployees.ExecuteReader();

          // add the heading and separator
          listJobs.Items.Add(headText);
          listJobs.Items.Add(headSep);

          // this string will represent our lines of data
          string textLine = "";

          // loop through the data reader
          // build a "line" of data
          // and add it to the list box
          while (dataReader.Read())
          {
            textLine = dataReader.GetString(0).PadRight(12);
            textLine += dataReader.GetString(1).PadRight(37);
            textLine += dataReader.GetDecimal(2).ToString().PadRight(12);
            textLine += dataReader.GetDecimal(3).ToString().PadRight(12);

            listJobs.Items.Add(textLine);
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message,"Exception Caught");
        }
      }

      cmdEmployees.Dispose();
    }
  }
}
