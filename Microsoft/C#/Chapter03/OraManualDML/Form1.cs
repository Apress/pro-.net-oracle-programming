using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OracleClient;

namespace OraManualDML
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtPlayerNum;
    private System.Windows.Forms.TextBox txtLastName;
    private System.Windows.Forms.TextBox txtFirstName;
    private System.Windows.Forms.TextBox txtPosition;
    private System.Windows.Forms.TextBox txtClub;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnLookup;
    private System.Windows.Forms.Button btnInsert;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnDelete;
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.txtPlayerNum = new System.Windows.Forms.TextBox();
      this.txtLastName = new System.Windows.Forms.TextBox();
      this.txtFirstName = new System.Windows.Forms.TextBox();
      this.txtPosition = new System.Windows.Forms.TextBox();
      this.txtClub = new System.Windows.Forms.TextBox();
      this.btnReset = new System.Windows.Forms.Button();
      this.btnLookup = new System.Windows.Forms.Button();
      this.btnInsert = new System.Windows.Forms.Button();
      this.btnUpdate = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
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
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(124, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(84, 16);
      this.label1.TabIndex = 6;
      this.label1.Text = "Player &Number:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(124, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(84, 16);
      this.label2.TabIndex = 8;
      this.label2.Text = "&Last Name:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(124, 76);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(84, 16);
      this.label3.TabIndex = 10;
      this.label3.Text = "&First Name:";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(124, 104);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(84, 16);
      this.label4.TabIndex = 12;
      this.label4.Text = "&Position:";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(124, 132);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(84, 16);
      this.label5.TabIndex = 14;
      this.label5.Text = "&Club:";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtPlayerNum
      // 
      this.txtPlayerNum.Location = new System.Drawing.Point(208, 18);
      this.txtPlayerNum.Name = "txtPlayerNum";
      this.txtPlayerNum.Size = new System.Drawing.Size(160, 20);
      this.txtPlayerNum.TabIndex = 7;
      this.txtPlayerNum.Text = "";
      // 
      // txtLastName
      // 
      this.txtLastName.Location = new System.Drawing.Point(208, 46);
      this.txtLastName.Name = "txtLastName";
      this.txtLastName.Size = new System.Drawing.Size(160, 20);
      this.txtLastName.TabIndex = 9;
      this.txtLastName.Text = "";
      // 
      // txtFirstName
      // 
      this.txtFirstName.Location = new System.Drawing.Point(208, 74);
      this.txtFirstName.Name = "txtFirstName";
      this.txtFirstName.Size = new System.Drawing.Size(160, 20);
      this.txtFirstName.TabIndex = 11;
      this.txtFirstName.Text = "";
      // 
      // txtPosition
      // 
      this.txtPosition.Location = new System.Drawing.Point(208, 102);
      this.txtPosition.Name = "txtPosition";
      this.txtPosition.Size = new System.Drawing.Size(160, 20);
      this.txtPosition.TabIndex = 13;
      this.txtPosition.Text = "";
      // 
      // txtClub
      // 
      this.txtClub.Location = new System.Drawing.Point(208, 130);
      this.txtClub.Name = "txtClub";
      this.txtClub.Size = new System.Drawing.Size(160, 20);
      this.txtClub.TabIndex = 15;
      this.txtClub.Text = "";
      // 
      // btnReset
      // 
      this.btnReset.Location = new System.Drawing.Point(16, 52);
      this.btnReset.Name = "btnReset";
      this.btnReset.TabIndex = 1;
      this.btnReset.Text = "&Reset";
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // btnLookup
      // 
      this.btnLookup.Location = new System.Drawing.Point(16, 88);
      this.btnLookup.Name = "btnLookup";
      this.btnLookup.TabIndex = 2;
      this.btnLookup.Text = "Loo&kup";
      this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
      // 
      // btnInsert
      // 
      this.btnInsert.Location = new System.Drawing.Point(16, 124);
      this.btnInsert.Name = "btnInsert";
      this.btnInsert.TabIndex = 3;
      this.btnInsert.Text = "&Insert";
      this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
      // 
      // btnUpdate
      // 
      this.btnUpdate.Location = new System.Drawing.Point(16, 160);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.TabIndex = 4;
      this.btnUpdate.Text = "&Update";
      this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Location = new System.Drawing.Point(16, 196);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.TabIndex = 5;
      this.btnDelete.Text = "&Delete";
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(418, 236);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnUpdate);
      this.Controls.Add(this.btnInsert);
      this.Controls.Add(this.btnLookup);
      this.Controls.Add(this.btnReset);
      this.Controls.Add(this.txtClub);
      this.Controls.Add(this.txtPosition);
      this.Controls.Add(this.txtFirstName);
      this.Controls.Add(this.txtLastName);
      this.Controls.Add(this.txtPlayerNum);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnConnect);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Manual DML";
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

    public OracleConnection oraConn;

    private void Form1_Load(object sender, System.EventArgs e)
    {
      oraConn = new OracleConnection();
    }

    private void btnConnect_Click(object sender, System.EventArgs e)
    {
      // create a basic connection string using our
      // standard Oracle user
      string connString = "User Id=oranetuser; Password=demo; Data Source=oranet";

      // only connect if we are not yet connected
      // oraConn is a form-level, public field of type
      // OracleConnection
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

    private void btnReset_Click(object sender, System.EventArgs e)
    {
      txtPlayerNum.Text = "";
      txtLastName.Text = "";
      txtFirstName.Text = "";
      txtPosition.Text = "";
      txtClub.Text = "";

      txtPlayerNum.Focus();
    }

    private void btnLookup_Click(object sender, System.EventArgs e)
    {
      // perform this action if we are connected
      if (oraConn.State == ConnectionState.Open)
      {
        // sql statement to look up a player based on
        // the player number
        // we use a bind variable for the player number
        string sqlLookup = "select last_name, ";
        sqlLookup += "first_name, ";
        sqlLookup += "position, ";
        sqlLookup += "club ";
        sqlLookup += "from squad ";
        sqlLookup += "where player_num = :player_num";

        // create our command object and set properties
        OracleCommand cmdLookup = new OracleCommand();
        cmdLookup.CommandText = sqlLookup;
        cmdLookup.Connection = oraConn;

        // create our parameter object for the player number
        // in our sample we are assuming a number is
        // entered in the player number text box
        OracleParameter pPlayerNum = new OracleParameter();
        pPlayerNum.DbType = DbType.Decimal;
        pPlayerNum.Value = Convert.ToDecimal(txtPlayerNum.Text);
        pPlayerNum.ParameterName = "player_num";

        // add the parameter to the collection
        cmdLookup.Parameters.Add(pPlayerNum);

        // execute the sql statement and populate the text
        // boxes if a record is returned
        OracleDataReader dataReader = cmdLookup.ExecuteReader();

        if (dataReader.Read())
        {
          txtLastName.Text = dataReader.GetString(0);
          txtFirstName.Text = dataReader.GetString(1);
          txtPosition.Text = dataReader.GetString(2);
          txtClub.Text = dataReader.GetString(3);
        }
        else
        {
          MessageBox.Show("No record for Player Number Found" , "No Record Found");
        }

        // explictly close and dispose our objects
        dataReader.Close();
        dataReader.Dispose();
        cmdLookup.Dispose();
      }
    }

    private void btnInsert_Click(object sender, System.EventArgs e)
    {
      // perform this action if we are connected
      if (oraConn.State == ConnectionState.Open)
      {
        // sql statement to insert a new record using binds
        string sqlInsert = "insert into squad ";
        sqlInsert += "(player_num, last_name, first_name, position, club) ";
        sqlInsert += "values (:p_num, :p_last, :p_first, :p_pos, :p_club)";

        // create our command object and set properties
        OracleCommand cmdInsert = new OracleCommand();
        cmdInsert.CommandText = sqlInsert;
        cmdInsert.Connection = oraConn;

        // create our parameter object for the player number
        // in our sample we are assuming a number is
        // entered in the player number text box
        OracleParameter pPlayerNum = new OracleParameter();
        pPlayerNum.DbType = DbType.Decimal;
        pPlayerNum.Value = Convert.ToDecimal(txtPlayerNum.Text);
        pPlayerNum.ParameterName = "p_num";

        // create our parameter object for the last name
        // in our sample we are assuming text is
        // entered in the last name text box
        OracleParameter pLastName = new OracleParameter();
        pLastName.Value = txtLastName.Text;
        pLastName.ParameterName = "p_last";

        // create our parameter object for the first name
        // in our sample we are assuming text is
        // entered in the first name text box
        OracleParameter pFirstName = new OracleParameter();
        pFirstName.Value = txtFirstName.Text;
        pFirstName.ParameterName = "p_first";

        // create our parameter object for the position
        // in our sample we are assuming text is
        // entered in the position text box
        OracleParameter pPosition = new OracleParameter();
        pPosition.Value = txtPosition.Text;
        pPosition.ParameterName = "p_pos";
  
        // create our parameter object for the club
        // in our sample we are assuming text is
        // entered in the club text box
        OracleParameter pClub = new OracleParameter();
        pClub.Value = txtClub.Text;
        pClub.ParameterName = "p_club";

        // add the parameters to the collection
        cmdInsert.Parameters.Add(pPlayerNum);
        cmdInsert.Parameters.Add(pLastName);
        cmdInsert.Parameters.Add(pFirstName);
        cmdInsert.Parameters.Add(pPosition);
        cmdInsert.Parameters.Add(pClub);

        // execute the insert statement
        cmdInsert.ExecuteNonQuery();

        MessageBox.Show("Record Inserted Successfully" , "Record Inserted");

        // reset the form
        btnReset_Click(sender, e);

        cmdInsert.Dispose();
      }
    }

    private void btnUpdate_Click(object sender, System.EventArgs e)
    {
      // perform this action if we are connected
      if (oraConn.State == ConnectionState.Open)
      {
        // sql statement to update a record using binds
        string sqlUpdate = "update squad ";
        sqlUpdate += "set last_name = :p_last, ";
        sqlUpdate += "first_name = :p_first, ";
        sqlUpdate += "position = :p_pos, ";
        sqlUpdate += "club = :p_club " ;
        sqlUpdate += "where player_num = :p_num";

        // create our command object and set properties
        OracleCommand cmdUpdate = new OracleCommand();
        cmdUpdate.CommandText = sqlUpdate;
        cmdUpdate.Connection = oraConn;

        // create our parameter object for the player number
        // in our sample we are assuming a number is
        // entered in the player number text box
        OracleParameter pPlayerNum = new OracleParameter();
        pPlayerNum.DbType = DbType.Decimal;
        pPlayerNum.Value = Convert.ToDecimal(txtPlayerNum.Text);
        pPlayerNum.ParameterName = "p_num";

        // create our parameter object for the last name
        // in our sample we are assuming text is
        // entered in the last name text box
        OracleParameter pLastName = new OracleParameter();
        pLastName.Value = txtLastName.Text;
        pLastName.ParameterName = "p_last";

        // create our parameter object for the first name
        // in our sample we are assuming text is
        // entered in the first name text box
        OracleParameter pFirstName = new OracleParameter();
        pFirstName.Value = txtFirstName.Text;
        pFirstName.ParameterName = "p_first";

        // create our parameter object for the position
        // in our sample we are assuming text is
        // entered in the position text box
        OracleParameter pPosition = new OracleParameter();
        pPosition.Value = txtPosition.Text;
        pPosition.ParameterName = "p_pos";
  
        // create our parameter object for the club
        // in our sample we are assuming text is
        // entered in the club text box
        OracleParameter pClub = new OracleParameter();
        pClub.Value = txtClub.Text;
        pClub.ParameterName = "p_club";

        // add the parameters to the collection
        cmdUpdate.Parameters.Add(pLastName);
        cmdUpdate.Parameters.Add(pFirstName);
        cmdUpdate.Parameters.Add(pPosition);
        cmdUpdate.Parameters.Add(pClub);
        cmdUpdate.Parameters.Add(pPlayerNum);

        // execute the update statement
        cmdUpdate.ExecuteNonQuery();

        MessageBox.Show("Record Updated Successfully" , "Record Updated");

        // reset the form
        btnReset_Click(sender, e);

        // explictly dispose our objects
        cmdUpdate.Dispose();
      }    
    }

    private void btnDelete_Click(object sender, System.EventArgs e)
    {
      // perform this action if we are connected
      if (oraConn.State == ConnectionState.Open)
      {
        // sql statement to delete a record using a bind
        string sqlDelete = "delete from squad where player_num = :p_num";

        // create our command object and set properties
        OracleCommand cmdDelete = new OracleCommand();
        cmdDelete.CommandText = sqlDelete;
        cmdDelete.Connection = oraConn;

        // create our parameter object for the player number
        // in our sample we are assuming a number is
        // entered in the player number text box
        OracleParameter pPlayerNum = new OracleParameter();
        pPlayerNum.DbType = DbType.Decimal;
        pPlayerNum.Value = Convert.ToDecimal(txtPlayerNum.Text);
        pPlayerNum.ParameterName = "p_num";

        // add the parameters to the collection
        cmdDelete.Parameters.Add(pPlayerNum);

        // execute the delete statement
        cmdDelete.ExecuteNonQuery();

        MessageBox.Show("Record Deleted Successfully" , "Record Deleted");

        // reset the form
        btnReset_Click(sender, e);

        // explictly dispose our objects
        cmdDelete.Dispose();
      }
    }
  }
}
