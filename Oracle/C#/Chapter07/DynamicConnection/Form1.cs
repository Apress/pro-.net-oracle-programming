using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Oracle.DataAccess.Client;

namespace DynamicConnection
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Label lblUserName;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.Label lblHost;
    private System.Windows.Forms.Label lblPort;
    private System.Windows.Forms.Label lblServiceName;
    private System.Windows.Forms.TextBox txtUserName;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.TextBox txtHost;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.TextBox txtServiceName;
    private System.Windows.Forms.Button btnConnect;
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
      this.lblUserName = new System.Windows.Forms.Label();
      this.lblPassword = new System.Windows.Forms.Label();
      this.lblHost = new System.Windows.Forms.Label();
      this.lblPort = new System.Windows.Forms.Label();
      this.lblServiceName = new System.Windows.Forms.Label();
      this.txtUserName = new System.Windows.Forms.TextBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.txtHost = new System.Windows.Forms.TextBox();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.txtServiceName = new System.Windows.Forms.TextBox();
      this.btnConnect = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblUserName
      // 
      this.lblUserName.Location = new System.Drawing.Point(60, 23);
      this.lblUserName.Name = "lblUserName";
      this.lblUserName.Size = new System.Drawing.Size(80, 16);
      this.lblUserName.TabIndex = 0;
      this.lblUserName.Text = "User &Name:";
      this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblPassword
      // 
      this.lblPassword.Location = new System.Drawing.Point(60, 58);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(80, 16);
      this.lblPassword.TabIndex = 2;
      this.lblPassword.Text = "&Password:";
      this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblHost
      // 
      this.lblHost.Location = new System.Drawing.Point(60, 88);
      this.lblHost.Name = "lblHost";
      this.lblHost.Size = new System.Drawing.Size(80, 16);
      this.lblHost.TabIndex = 4;
      this.lblHost.Text = "&Host:";
      this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblPort
      // 
      this.lblPort.Location = new System.Drawing.Point(60, 120);
      this.lblPort.Name = "lblPort";
      this.lblPort.Size = new System.Drawing.Size(80, 16);
      this.lblPort.TabIndex = 6;
      this.lblPort.Text = "P&ort:";
      this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblServiceName
      // 
      this.lblServiceName.Location = new System.Drawing.Point(60, 152);
      this.lblServiceName.Name = "lblServiceName";
      this.lblServiceName.Size = new System.Drawing.Size(80, 16);
      this.lblServiceName.TabIndex = 8;
      this.lblServiceName.Text = "S&ervice Name:";
      this.lblServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtUserName
      // 
      this.txtUserName.Location = new System.Drawing.Point(144, 21);
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.TabIndex = 1;
      this.txtUserName.Text = "";
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(144, 56);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.TabIndex = 3;
      this.txtPassword.Text = "";
      // 
      // txtHost
      // 
      this.txtHost.Location = new System.Drawing.Point(144, 88);
      this.txtHost.Name = "txtHost";
      this.txtHost.TabIndex = 5;
      this.txtHost.Text = "";
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(144, 120);
      this.txtPort.Name = "txtPort";
      this.txtPort.TabIndex = 7;
      this.txtPort.Text = "";
      // 
      // txtServiceName
      // 
      this.txtServiceName.Location = new System.Drawing.Point(144, 152);
      this.txtServiceName.Name = "txtServiceName";
      this.txtServiceName.TabIndex = 9;
      this.txtServiceName.Text = "";
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(124, 200);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.TabIndex = 10;
      this.btnConnect.Text = "&Connect";
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(322, 248);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.txtServiceName);
      this.Controls.Add(this.txtPort);
      this.Controls.Add(this.txtHost);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.txtUserName);
      this.Controls.Add(this.lblServiceName);
      this.Controls.Add(this.lblPort);
      this.Controls.Add(this.lblHost);
      this.Controls.Add(this.lblPassword);
      this.Controls.Add(this.lblUserName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Name = "Form1";
      this.Text = "TNSNames-less Connection Example";
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

    private void doDynamicConnection(
      string p_user,
      string p_password,
      string p_host,
      string p_port,
      string p_service_name)
    {
      // build a tns connection string based on the inputs
      string l_data_source = "(DESCRIPTION=(ADDRESS_LIST=" +
        "(ADDRESS=(PROTOCOL=tcp)(HOST=" + p_host + ")" + 
        "(PORT=" + p_port + ")))" + 
        "(CONNECT_DATA=(SERVICE_NAME=" + p_service_name + ")))";

      // create the .NET provider connect string
      string l_connect_string = "User Id=" + p_user + ";" +
        "Password=" + p_password + ";" +
        "Data Source=" + l_data_source;

      // attempt to connect to the database
      OracleConnection oraConn = new OracleConnection(l_connect_string);

      try
      {
        oraConn.Open();

        // dislay a simple message box with our data source string
        MessageBox.Show(
          "Connected to data source: \n" + oraConn.DataSource,
          "Dynamic Connection Sample");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message,"Error Occured");
      }
      finally
      {
        if (oraConn.State == System.Data.ConnectionState.Open)
        {
          oraConn.Close();
        }
      }
    }

    private void btnConnect_Click(object sender, System.EventArgs e)
    {
      doDynamicConnection(
        txtUserName.Text,
        txtPassword.Text,
        txtHost.Text,
        txtPort.Text,
        txtServiceName.Text);    
    }
  }
}
