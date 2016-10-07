using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Oracle.DataAccess.Client;

namespace OraParameter
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
      this.Text = "Oracle Parameter Sample";
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

    private OracleConnection oraConn;

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

    private void btnGetIDs_Click(object sender, System.EventArgs e)
    {
      // get the employee id's from the database
      // we are not using the drop down list control
      // as a databound control
      OracleCommand cmdEmpId = new OracleCommand();
      cmdEmpId.CommandText = "select employee_id from employees order by employee_id";
      cmdEmpId.Connection = oraConn;

      try
      {
        // get a data reader
        OracleDataReader dataReader = cmdEmpId.ExecuteReader();

        // simply iterate the result set and add
        // the values to the drop down list
        while (dataReader.Read())
        {
          cbEmpIds.Items.Add(dataReader.GetOracleDecimal(0));
        }

        dataReader.Dispose();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message,"Exception Caught");
      }
      finally
      {
        cmdEmpId.Dispose();
      }
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
      oraConn = new OracleConnection();
    }

    private void btnLookup1_Click(object sender, System.EventArgs e)
    {
      object selectedItem = cbEmpIds.SelectedItem;

      if (selectedItem != null)
      {
        // get the employee name based on the employee id
        // we will pass the employee id as a bind variable
        OracleCommand cmdEmpName = new OracleCommand();

        // the :p_id is our bind variable placeholder
        cmdEmpName.CommandText = "select first_name, last_name from employees where employee_id = :p_id";
    
        cmdEmpName.Connection = oraConn;

        OracleParameter p_id = new OracleParameter();

        // here we are setting the OracleDbType
        // we could set this as DbType as well and
        // the Oracle provider will infer the correct
        // OracleDbType
        p_id.OracleDbType = OracleDbType.Decimal;
        p_id.Value = Convert.ToDecimal(selectedItem.ToString());

        // add our parameter to the parameter collection
        // for the command object
        cmdEmpName.Parameters.Add(p_id);

        // get our data reader
        OracleDataReader dataReader = cmdEmpName.ExecuteReader();

        // get the results - our query will only return 1 row
        // since we are using the primary key
        if (dataReader.Read())
        {
          lblFirstName.Text = dataReader.GetString(0);
          lblLastName.Text = dataReader.GetString(1);
        }

        dataReader.Close();

        p_id.Dispose();
        dataReader.Dispose();
        cmdEmpName.Dispose();
      }    
    }

    private void btnLookup2_Click(object sender, System.EventArgs e)
    {
      // get the employee email and phone based on the
      // first name and last name
      // there are no duplicate first name / last name
      // combinations in the table
      // we will pass the first name and last name as
      // bind variables using BindByName
      OracleCommand cmdEmpInfo = new OracleCommand();

      // the :p_last and :p_first are our bind variable placeholders
      cmdEmpInfo.CommandText = "select email, phone_number from employees where first_name = :p_first and last_name = :p_last";
  
      cmdEmpInfo.Connection = oraConn;

      // we will use bind by name here
      cmdEmpInfo.BindByName = true;

      OracleParameter p1 = new OracleParameter();
      OracleParameter p2 = new OracleParameter();

      // the ParameterName value is what is used when
      // binding by name, not the name of the variable
      // in the code
      // notice the ":" is not included as part of the
      // parameter name
      p1.ParameterName = "p_first";
      p2.ParameterName = "p_last";

      p1.Value = lblFirstName.Text;
      p2.Value = lblLastName.Text;

      // add our parameters to the parameter collection
      // for the command object
      // we will add them in "reverse" order since we are
      // binding by name and not position
      cmdEmpInfo.Parameters.Add(p2);
      cmdEmpInfo.Parameters.Add(p1);

      // get our data reader
      OracleDataReader dataReader = cmdEmpInfo.ExecuteReader();

      // get the results - our query will only return 1 row
      // since we are using known unique values for the first
      // and last names
      if (dataReader.Read())
      {
        lblEmailText.Text = dataReader.GetString(0);
        lblPhoneText.Text = dataReader.GetString(1);
      }

      dataReader.Close();

      p1.Dispose();
      p2.Dispose();
      dataReader.Dispose();
      cmdEmpInfo.Dispose();
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
        OracleCommand cmdNoBinds = new OracleCommand();
        cmdNoBinds.Connection = oraConn;
        OracleDataReader dataReader;

        cmdNoBinds.CommandText = "select first_name, last_name from employees where employee_id = " + selectedItem.ToString();

        // get our data reader
        dataReader = cmdNoBinds.ExecuteReader();

        // get the results - our query will only return 1 row
        // since we are using the primary key
        if (dataReader.Read())
        {
          lblFirstName.Text = dataReader.GetString(0);
          lblLastName.Text = dataReader.GetString(1);
        }

        dataReader.Close();

        // get the data that Lookup 2 performed above
        cmdNoBinds.CommandText = "select email, phone_number from employees where first_name = '" + lblFirstName.Text + "' and last_name = '" + lblLastName.Text +"'";

        // get our data reader
        dataReader = cmdNoBinds.ExecuteReader();

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
        cmdNoBinds.Dispose();
      }
    }
  }
}
