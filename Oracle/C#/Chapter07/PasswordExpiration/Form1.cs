using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Oracle.DataAccess.Client;

namespace PasswordExpiration
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
    private System.Windows.Forms.Label lblNewPassword;
    private System.Windows.Forms.TextBox txtNewPassword;
    private System.Windows.Forms.Label lblConfirmPassword;
    private System.Windows.Forms.TextBox txtConfirmPassword;
    private System.Windows.Forms.Button btnChangePassword;
    private System.Windows.Forms.TextBox txtTNSAlias;
    private System.Windows.Forms.Label lblTNSAlias;
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
      this.lblNewPassword = new System.Windows.Forms.Label();
      this.txtNewPassword = new System.Windows.Forms.TextBox();
      this.lblConfirmPassword = new System.Windows.Forms.Label();
      this.txtConfirmPassword = new System.Windows.Forms.TextBox();
      this.btnChangePassword = new System.Windows.Forms.Button();
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
      // lblNewPassword
      // 
      this.lblNewPassword.Location = new System.Drawing.Point(88, 122);
      this.lblNewPassword.Name = "lblNewPassword";
      this.lblNewPassword.Size = new System.Drawing.Size(100, 16);
      this.lblNewPassword.TabIndex = 6;
      this.lblNewPassword.Text = "&New Password:";
      this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtNewPassword
      // 
      this.txtNewPassword.Location = new System.Drawing.Point(192, 120);
      this.txtNewPassword.Name = "txtNewPassword";
      this.txtNewPassword.PasswordChar = '*';
      this.txtNewPassword.TabIndex = 7;
      this.txtNewPassword.Text = "";
      // 
      // lblConfirmPassword
      // 
      this.lblConfirmPassword.Location = new System.Drawing.Point(88, 154);
      this.lblConfirmPassword.Name = "lblConfirmPassword";
      this.lblConfirmPassword.Size = new System.Drawing.Size(100, 16);
      this.lblConfirmPassword.TabIndex = 8;
      this.lblConfirmPassword.Text = "&Confirm Password:";
      this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtConfirmPassword
      // 
      this.txtConfirmPassword.Location = new System.Drawing.Point(192, 152);
      this.txtConfirmPassword.Name = "txtConfirmPassword";
      this.txtConfirmPassword.PasswordChar = '*';
      this.txtConfirmPassword.TabIndex = 9;
      this.txtConfirmPassword.Text = "";
      // 
      // btnChangePassword
      // 
      this.btnChangePassword.Location = new System.Drawing.Point(133, 208);
      this.btnChangePassword.Name = "btnChangePassword";
      this.btnChangePassword.Size = new System.Drawing.Size(115, 23);
      this.btnChangePassword.TabIndex = 10;
      this.btnChangePassword.Text = "Chan&ge Password";
      this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
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
      this.ClientSize = new System.Drawing.Size(380, 256);
      this.Controls.Add(this.txtTNSAlias);
      this.Controls.Add(this.lblTNSAlias);
      this.Controls.Add(this.btnChangePassword);
      this.Controls.Add(this.txtConfirmPassword);
      this.Controls.Add(this.lblConfirmPassword);
      this.Controls.Add(this.txtNewPassword);
      this.Controls.Add(this.lblNewPassword);
      this.Controls.Add(this.txtCurrentPassword);
      this.Controls.Add(this.lblCurrentPassword);
      this.Controls.Add(this.txtUserName);
      this.Controls.Add(this.lblUserName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "Form1";
      this.Text = "Expired Password Sample";
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

    private void btnChangePassword_Click(object sender, System.EventArgs e)
    {
      // display a simple message if the "new" and
      // the "confirm" passwords do not match
      if (txtNewPassword.Text != txtConfirmPassword.Text)
      {
        MessageBox.Show("New passwords do not match.", "Password Mismatch");

        return;
      }

      // build a connect string based on the user input
      string l_connect = "User Id=" + txtUserName.Text + ";" +
        "Password=" + txtCurrentPassword.Text + ";" +
        "Data Source=" + txtTNSAlias.Text;

      OracleConnection oraConn = new OracleConnection(l_connect);

      try
      {
        // attempt to open a connection
        // this should fail since we have expired the password
        oraConn.Open();
      }
      catch (OracleException ex)
      {
        // trap the "password is expired" error code
        if (ex.Number == 28001)
        {
          // dislay a simple marker indicate we trapped the error
          MessageBox.Show("Trapped Expired Password", "Expired Password");

          // this method changes the expired password
          oraConn.OpenWithNewPassword(txtNewPassword.Text);

          // display a simple marker to indicate password changed
          MessageBox.Show("Changed Expired Password", "Expired Password");
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
