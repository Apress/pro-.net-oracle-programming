using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OracleClient;

namespace Tying2
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Button btnGetIDs;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbEmpIds;
    private System.Windows.Forms.Label lblFirstName;
    private System.Windows.Forms.Label lblLastName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnLookup1;
    private System.Windows.Forms.Button btnLookup2;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.Label lblPhone;
    private System.Windows.Forms.Label lblEmailText;
    private System.Windows.Forms.Label lblPhoneText;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnNoBinds;
    private System.Data.OracleClient.OracleConnection oraConn;
    private System.Data.OracleClient.OracleCommand cmdGetIDs;
    private System.Data.OracleClient.OracleCommand cmdLookup1;
    private System.Data.OracleClient.OracleCommand cmdLookup2;
    private System.Data.OracleClient.OracleCommand cmdNoBinds1;
    private System.Data.OracleClient.OracleCommand cmdNoBinds2;
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
      this.btnGetIDs = new System.Windows.Forms.Button();
      this.cbEmpIds = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.lblFirstName = new System.Windows.Forms.Label();
      this.lblLastName = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.btnLookup1 = new System.Windows.Forms.Button();
      this.btnLookup2 = new System.Windows.Forms.Button();
      this.lblEmail = new System.Windows.Forms.Label();
      this.lblPhone = new System.Windows.Forms.Label();
      this.lblEmailText = new System.Windows.Forms.Label();
      this.lblPhoneText = new System.Windows.Forms.Label();
      this.btnReset = new System.Windows.Forms.Button();
      this.btnNoBinds = new System.Windows.Forms.Button();
      this.oraConn = new System.Data.OracleClient.OracleConnection();
      this.cmdGetIDs = new System.Data.OracleClient.OracleCommand();
      this.cmdLookup1 = new System.Data.OracleClient.OracleCommand();
      this.cmdLookup2 = new System.Data.OracleClient.OracleCommand();
      this.cmdNoBinds1 = new System.Data.OracleClient.OracleCommand();
      this.cmdNoBinds2 = new System.Data.OracleClient.OracleCommand();
      this.SuspendLayout();
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(32, 44);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.TabIndex = 0;
      this.btnConnect.Text = "C&onnect";
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // btnGetIDs
      // 
      this.btnGetIDs.Location = new System.Drawing.Point(32, 80);
      this.btnGetIDs.Name = "btnGetIDs";
      this.btnGetIDs.TabIndex = 1;
      this.btnGetIDs.Text = "&Get IDs";
      this.btnGetIDs.Click += new System.EventHandler(this.btnGetIDs_Click);
      // 
      // cbEmpIds
      // 
      this.cbEmpIds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbEmpIds.Location = new System.Drawing.Point(144, 44);
      this.cbEmpIds.Name = "cbEmpIds";
      this.cbEmpIds.Size = new System.Drawing.Size(68, 21);
      this.cbEmpIds.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(144, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 16);
      this.label1.TabIndex = 2;
      this.label1.Text = "&Employee ID:";
      // 
      // lblFirstName
      // 
      this.lblFirstName.Location = new System.Drawing.Point(228, 48);
      this.lblFirstName.Name = "lblFirstName";
      this.lblFirstName.Size = new System.Drawing.Size(116, 16);
      this.lblFirstName.TabIndex = 9;
      // 
      // lblLastName
      // 
      this.lblLastName.Location = new System.Drawing.Point(364, 48);
      this.lblLastName.Name = "lblLastName";
      this.lblLastName.Size = new System.Drawing.Size(128, 16);
      this.lblLastName.TabIndex = 11;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(228, 24);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(100, 16);
      this.label4.TabIndex = 8;
      this.label4.Text = "&First Name:";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(364, 24);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(100, 16);
      this.label5.TabIndex = 10;
      this.label5.Text = "&Last Name:";
      // 
      // btnLookup1
      // 
      this.btnLookup1.Location = new System.Drawing.Point(32, 116);
      this.btnLookup1.Name = "btnLookup1";
      this.btnLookup1.TabIndex = 4;
      this.btnLookup1.Text = "Lookup &1";
      this.btnLookup1.Click += new System.EventHandler(this.btnLookup1_Click);
      // 
      // btnLookup2
      // 
      this.btnLookup2.Location = new System.Drawing.Point(32, 152);
      this.btnLookup2.Name = "btnLookup2";
      this.btnLookup2.TabIndex = 5;
      this.btnLookup2.Text = "Lookup &2";
      this.btnLookup2.Click += new System.EventHandler(this.btnLookup2_Click);
      // 
      // lblEmail
      // 
      this.lblEmail.Location = new System.Drawing.Point(228, 88);
      this.lblEmail.Name = "lblEmail";
      this.lblEmail.Size = new System.Drawing.Size(100, 16);
      this.lblEmail.TabIndex = 12;
      this.lblEmail.Text = "E&mail:";
      // 
      // lblPhone
      // 
      this.lblPhone.Location = new System.Drawing.Point(364, 88);
      this.lblPhone.Name = "lblPhone";
      this.lblPhone.Size = new System.Drawing.Size(100, 16);
      this.lblPhone.TabIndex = 14;
      this.lblPhone.Text = "Phone &Number:";
      // 
      // lblEmailText
      // 
      this.lblEmailText.Location = new System.Drawing.Point(228, 112);
      this.lblEmailText.Name = "lblEmailText";
      this.lblEmailText.Size = new System.Drawing.Size(116, 16);
      this.lblEmailText.TabIndex = 13;
      // 
      // lblPhoneText
      // 
      this.lblPhoneText.Location = new System.Drawing.Point(364, 112);
      this.lblPhoneText.Name = "lblPhoneText";
      this.lblPhoneText.Size = new System.Drawing.Size(128, 16);
      this.lblPhoneText.TabIndex = 15;
      // 
      // btnReset
      // 
      this.btnReset.Location = new System.Drawing.Point(32, 224);
      this.btnReset.Name = "btnReset";
      this.btnReset.TabIndex = 7;
      this.btnReset.Text = "&Reset";
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // btnNoBinds
      // 
      this.btnNoBinds.Location = new System.Drawing.Point(32, 188);
      this.btnNoBinds.Name = "btnNoBinds";
      this.btnNoBinds.TabIndex = 6;
      this.btnNoBinds.Text = "No &Binds";
      this.btnNoBinds.Click += new System.EventHandler(this.btnNoBinds_Click);
      // 
      // oraConn
      // 
      this.oraConn.ConnectionString = "user id=hr;data source=oranet;password=demo";
      // 
      // cmdGetIDs
      // 
      this.cmdGetIDs.CommandText = "SELECT EMPLOYEE_ID FROM EMPLOYEES ORDER BY EMPLOYEE_ID";
      this.cmdGetIDs.Connection = this.oraConn;
      // 
      // cmdLookup1
      // 
      this.cmdLookup1.CommandText = "SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES WHERE (EMPLOYEE_ID = :p_id)";
      this.cmdLookup1.Connection = this.oraConn;
      this.cmdLookup1.Parameters.Add(new System.Data.OracleClient.OracleParameter(":p_id", System.Data.OracleClient.OracleType.Number, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(6)), ((System.Byte)(0)), "EMPLOYEE_ID", System.Data.DataRowVersion.Current, null));
      // 
      // cmdLookup2
      // 
      this.cmdLookup2.CommandText = "SELECT EMAIL, PHONE_NUMBER FROM EMPLOYEES WHERE (FIRST_NAME = :p_first) AND (LAST" +
        "_NAME = :p_last)";
      this.cmdLookup2.Connection = this.oraConn;
      this.cmdLookup2.Parameters.Add(new System.Data.OracleClient.OracleParameter(":p_first", System.Data.OracleClient.OracleType.VarChar, 20, "FIRST_NAME"));
      this.cmdLookup2.Parameters.Add(new System.Data.OracleClient.OracleParameter(":p_last", System.Data.OracleClient.OracleType.VarChar, 25, "LAST_NAME"));
      // 
      // cmdNoBinds1
      // 
      this.cmdNoBinds1.Connection = this.oraConn;
      // 
      // cmdNoBinds2
      // 
      this.cmdNoBinds2.Connection = this.oraConn;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(534, 264);
      this.Controls.Add(this.btnNoBinds);
      this.Controls.Add(this.btnReset);
      this.Controls.Add(this.lblPhoneText);
      this.Controls.Add(this.lblEmailText);
      this.Controls.Add(this.lblPhone);
      this.Controls.Add(this.lblEmail);
      this.Controls.Add(this.btnLookup2);
      this.Controls.Add(this.btnLookup1);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.lblLastName);
      this.Controls.Add(this.lblFirstName);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cbEmpIds);
      this.Controls.Add(this.btnGetIDs);
      this.Controls.Add(this.btnConnect);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "MSProvider Sample";
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
      if (oraConn.State != ConnectionState.Open)
      {
        try
        {
          oraConn.Open();

          MessageBox.Show(oraConn.ConnectionString, "Successful Connection");
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message,"Exception Caught");
        }
      }
    }

    private void btnGetIDs_Click(object sender, System.EventArgs e)
    {
      try
      {
        // get a data reader
        OracleDataReader dataReader = cmdGetIDs.ExecuteReader();

        // simply iterate the result set and add
        // the values to the drop down list
        while (dataReader.Read())
        {
          cbEmpIds.Items.Add(dataReader.GetDecimal(0));
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message,"Exception Caught");
      }
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
    }

    private void btnLookup1_Click(object sender, System.EventArgs e)
    {
      object selectedItem = cbEmpIds.SelectedItem;

      if (selectedItem != null)
      {
        // we need to set the parameter value
        cmdLookup1.Parameters[0].Value = Convert.ToDecimal(selectedItem.ToString());

        // get our data reader
        OracleDataReader dataReader = cmdLookup1.ExecuteReader();

        // get the results - our query will only return 1 row
        // since we are using the primary key
        if (dataReader.Read())
        {
          lblFirstName.Text = dataReader.GetString(0);
          lblLastName.Text = dataReader.GetString(1);
        }

        dataReader.Close();
        dataReader.Dispose();
      }
    }

    private void btnLookup2_Click(object sender, System.EventArgs e)
    {
      // we need to bind in order since the Microsoft driver
      // does not support the BindByName property
      cmdLookup2.Parameters[0].Value = lblFirstName.Text;
      cmdLookup2.Parameters[1].Value = lblLastName.Text;

      // get our data reader
      OracleDataReader dataReader = cmdLookup2.ExecuteReader();

      // get the results - our query will only return 1 row
      // since we are using known unique values for the first
      // and last names
      if (dataReader.Read())
      {
        lblEmailText.Text = dataReader.GetString(0);
        lblPhoneText.Text = dataReader.GetString(1);
      }

      dataReader.Close();

      dataReader.Dispose();
    }

    private void btnReset_Click(object sender, System.EventArgs e)
    {
      cbEmpIds.SelectedIndex = -1;
      lblFirstName.Text = "";
      lblLastName.Text = "";
      lblEmailText.Text = "";
      lblPhoneText.Text = "";
    }

    private void btnNoBinds_Click(object sender, System.EventArgs e)
    {
      // this illustrates the "traditional" approach
      // that does not use bind variables

      object selectedItem = cbEmpIds.SelectedItem;

      if (selectedItem != null)
      {
        OracleDataReader dataReader;

        // we must build our command text string
        // since we are concatenating values at runtime
        cmdNoBinds1.CommandText = "select first_name, last_name from employees where employee_id = " + selectedItem.ToString();

        // get our data reader
        dataReader = cmdNoBinds1.ExecuteReader();

        // get the results - our query will only return 1 row
        // since we are using the primary key
        if (dataReader.Read())
        {
          lblFirstName.Text = dataReader.GetString(0);
          lblLastName.Text = dataReader.GetString(1);
        }

        dataReader.Close();

        // get the data that Lookup 2 performed above
        // again, we must build the string here in code
        // rather than in the design environment
        cmdNoBinds2.CommandText = "select email, phone_number from employees where first_name = '" + lblFirstName.Text + "' and last_name = '" + lblLastName.Text +"'";

        // get our data reader
        dataReader = cmdNoBinds2.ExecuteReader();

        // get the results - our query will only return 1 row
        // since we are using known unique values for the first
        // and last names
        if (dataReader.Read())
        {
          lblEmailText.Text = dataReader.GetString(0);
          lblPhoneText.Text = dataReader.GetString(1);
        }

        dataReader.Close();
        dataReader.Dispose();
      }
    }
  }
}
