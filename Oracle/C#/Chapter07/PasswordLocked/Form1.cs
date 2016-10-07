using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Oracle.DataAccess.Client;

namespace PasswordLocked
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Label lblUserName;
    private System.Windows.Forms.TextBox txtUserName;
    private System.Windows.Forms.Label lblCurrentPassword;
    private System.Windows.Forms.TextBox txtCurrentPassword;
    private System.Windows.Forms.TextBox txtTNSAlias;
    private System.Windows.Forms.Label lblTNSAlias;
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
      this.txtUserName = new System.Windows.Forms.TextBox();
      this.lblCurrentPassword = new System.Windows.Forms.Label();
      this.txtCurrentPassword = new System.Windows.Forms.TextBox();
      this.btnConnect = new System.Windows.Forms.Button();
      this.txtTNSAlias = new System.Windows.Forms.TextBox();
      this.lblTNSAlias = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblUserName
      // 
      this.lblUserName.Location = new System.Drawing.Point(88, 26);
      this.lblUserName.Name = "lblUserName";
      this.lblUserName.Size = new System.Drawing.Size(100, 16);
      this.lblUserName.TabIndex = 0;
      this.lblUserName.Text = "&User Name:";
      this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtUserName
      // 
      this.txtUserName.Location = new System.Drawing.Point(192, 24);
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.TabIndex = 1;
      this.txtUserName.Text = "";
      // 
      // lblCurrentPassword
      // 
      this.lblCurrentPassword.Location = new System.Drawing.Point(88, 58);
      this.lblCurrentPassword.Name = "lblCurrentPassword";
      this.lblCurrentPassword.Size = new System.Drawing.Size(100, 16);
      this.lblCurrentPassword.TabIndex = 2;
      this.lblCurrentPassword.Text = "Current &Password:";
      this.lblCurrentPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtCurrentPassword
      // 
      this.txtCurrentPassword.Location = new System.Drawing.Point(192, 56);
      this.txtCurrentPassword.Name = "txtCurrentPassword";
      this.txtCurrentPassword.PasswordChar = '*';
      this.txtCurrentPassword.TabIndex = 3;
      this.txtCurrentPassword.Text = "";
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(133, 132);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(115, 23);
      this.btnConnect.TabIndex = 10;
      this.btnConnect.Text = "&Connect";
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // txtTNSAlias
      // 
      this.txtTNSAlias.Location = new System.Drawing.Point(192, 88);
      this.txtTNSAlias.Name = "txtTNSAlias";
      this.txtTNSAlias.TabIndex = 5;
      this.txtTNSAlias.Text = "";
      // 
      // lblTNSAlias
      // 
      this.lblTNSAlias.Location = new System.Drawing.Point(88, 90);
      this.lblTNSAlias.Name = "lblTNSAlias";
      this.lblTNSAlias.Size = new System.Drawing.Size(100, 16);
      this.lblTNSAlias.TabIndex = 4;
      this.lblTNSAlias.Text = "&TNS Alias:";
      this.lblTNSAlias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(380, 176);
      this.Controls.Add(this.txtTNSAlias);
      this.Controls.Add(this.lblTNSAlias);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.txtCurrentPassword);
      this.Controls.Add(this.lblCurrentPassword);
      this.Controls.Add(this.txtUserName);
      this.Controls.Add(this.lblUserName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "Form1";
      this.Text = "Locked Account Sample";
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
      // build a connect string based on the user input
      string l_connect = "User Id=" + txtUserName.Text + ";" +
        "Password=" + txtCurrentPassword.Text + ";" +
        "Data Source=" + txtTNSAlias.Text;

      OracleConnection oraConn = new OracleConnection(l_connect);

      try
      {
        // attempt to open a connection
        // this should fail since we have locked the account
        oraConn.Open();
      }
      catch (OracleException ex)
      {
        // trap the "account is locked" error code
        if (ex.Number == 28000)
        {
          // dislay a simple marker to indicate we trapped the error
          MessageBox.Show("Trapped Locked Account", "Locked Account");
        }
        else
        {
          MessageBox.Show(ex.Message, "Error Occured");
        }
      }
      finally
      {
        if (oraConn.State == System.Data.ConnectionState.Open)
        {
          oraConn.Close();
        }
      }
    }
  }
}
