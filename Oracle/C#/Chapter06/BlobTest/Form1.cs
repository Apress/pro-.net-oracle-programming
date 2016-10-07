using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace BlobTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Button btnDisplay;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button btnClear;
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
      this.btnLoad = new System.Windows.Forms.Button();
      this.btnDisplay = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btnClear = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnLoad
      // 
      this.btnLoad.Location = new System.Drawing.Point(12, 16);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.TabIndex = 0;
      this.btnLoad.Text = "&Load File";
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // btnDisplay
      // 
      this.btnDisplay.Location = new System.Drawing.Point(12, 52);
      this.btnDisplay.Name = "btnDisplay";
      this.btnDisplay.TabIndex = 1;
      this.btnDisplay.Text = "&Display";
      this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.White;
      this.pictureBox1.Location = new System.Drawing.Point(104, 16);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(760, 476);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(12, 88);
      this.btnClear.Name = "btnClear";
      this.btnClear.TabIndex = 2;
      this.btnClear.Text = "&Clear";
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(950, 510);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.btnDisplay);
      this.Controls.Add(this.btnLoad);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "BLOB Sample";
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

    private void btnLoad_Click(object sender, System.EventArgs e)
    {
      // create our standard connection
      string connStr = "User Id=oranetuser; Password=demo; Data Source=oranet";
      OracleConnection con = new OracleConnection(connStr);

      con.Open();

      MessageBox.Show("Truncating table...", "BLOB Sample");

      // ensure the table is empty
      string sql = "truncate table blob_test";

      OracleCommand cmd = new OracleCommand(sql, con);

      cmd.ExecuteNonQuery();

      MessageBox.Show("Table truncated.", "BLOB Sample");

      MessageBox.Show("Loading table...", "BLOB Sample");

      // build the anonymous block and execute it
      sql = "declare";
      sql += "  /* local variables to hold the lob locators */";
      sql += "  l_blob  blob;";
      sql += "  l_bfile bfile;";
      sql += "begin";
      sql += "  /* this is a method to get the lob locator */";
      sql += "  /* for the lob column in the table */";
      sql += "  /* by inserting an empty_clob and returning */";
      sql += "  /* into the local clob variable, we easily */";
      sql += "  /* acquire the lob locator */";
      sql += "  insert into blob_test (blob_id, blob_data)";
      sql += "  values (1, empty_blob())";
      sql += "  returning blob_data into l_blob;";
      sql += "  /* this is the file we will load */";
      sql += "  l_bfile := bfilename('C_TEMP', 'APRESS_WEBSITE.TIF');";
      sql += "  /* the file must be opened prior to loading */";
      sql += "  dbms_lob.fileopen(l_bfile);";
      sql += "  /* this procedure performs the actual data load */";
      sql += "  dbms_lob.loadfromfile(l_blob, l_bfile, dbms_lob.getlength(l_bfile));";
      sql += "  /* close the bfile after loading it */";
      sql += "  dbms_lob.fileclose(l_bfile);";
      sql += "  /* commit the transaction */";
      sql += "  commit;";
      sql += "end;";

      cmd.CommandText = sql;

      cmd.ExecuteNonQuery();

      MessageBox.Show("Table loaded.", "BLOB Sample");
    }

    private void btnClear_Click(object sender, System.EventArgs e)
    {
      // simply set the image property to null
      // to 'clear' the picture box control
      pictureBox1.Image = null;
    }

    private void btnDisplay_Click(object sender, System.EventArgs e)
    {
      // create our standard connection
      string connStr = "User Id=oranetuser; Password=demo; Data Source=oranet";
      OracleConnection con = new OracleConnection(connStr);

      con.Open();

      string sql = "select blob_data from blob_test where blob_id = 1";

      OracleCommand cmd = new OracleCommand(sql, con);

      OracleDataReader dataReader = cmd.ExecuteReader();

      // read the single row result
      dataReader.Read();

      // use typed accessor to retrieve the blob
      OracleBlob blob = dataReader.GetOracleBlob(0);

      // we are done with the reader now, so we can close it
      dataReader.Close();

      // create a memory stream from the blob
      MemoryStream ms = new MemoryStream(blob.Value);

      // set the image property equal to a bitmap
      // created from the memory stream
      pictureBox1.Image = new Bitmap(ms);
    }
	}
}
