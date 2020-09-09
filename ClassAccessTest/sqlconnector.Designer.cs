namespace ClassAccessTest
{
	partial class sqlconnector
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if ( disposing && (components != null) )
			{
				components.Dispose ( );
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.sqlConnect = new System.Windows.Forms.Button();
			this.sqlDisconnect = new System.Windows.Forms.Button();
			this.info = new System.Windows.Forms.TextBox();
			this.connstring = new System.Windows.Forms.TextBox();
			this.ReadBankDB = new System.Windows.Forms.Button();
			this.clear = new System.Windows.Forms.Button();
			this.WriteCSVtoCust = new System.Windows.Forms.Button();
			this.WriteTestdatatoBank = new System.Windows.Forms.Button();
			this.ReadCustDB = new System.Windows.Forms.Button();
			this.RecordCount = new System.Windows.Forms.TextBox();
			this.SQLcommand = new System.Windows.Forms.RichTextBox();
			this.WriteCSVtoBank = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.exit = new System.Windows.Forms.Button();
			this.sqlLineCommands = new System.Windows.Forms.ListBox();
			this.ProcessSQL = new System.Windows.Forms.Button();
			this.pastedata = new System.Windows.Forms.TextBox();
			this.MathCommands = new System.Windows.Forms.ListBox();
			this.schemas = new System.Windows.Forms.Button();
			this.Data = new System.Windows.Forms.RichTextBox();
			this.sqlcommandslist = new System.Windows.Forms.ListBox();
			this.MathsValues = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// sqlConnect
			// 
			this.sqlConnect.BackColor = System.Drawing.Color.Gold;
			this.sqlConnect.ForeColor = System.Drawing.Color.Red;
			this.sqlConnect.Location = new System.Drawing.Point(10, 135);
			this.sqlConnect.Name = "sqlConnect";
			this.sqlConnect.Size = new System.Drawing.Size(96, 39);
			this.sqlConnect.TabIndex = 0;
			this.sqlConnect.Text = "Connect";
			this.sqlConnect.UseVisualStyleBackColor = false;
			this.sqlConnect.Click += new System.EventHandler(this.sqlConnect_Click);
			// 
			// sqlDisconnect
			// 
			this.sqlDisconnect.BackColor = System.Drawing.Color.Chartreuse;
			this.sqlDisconnect.Location = new System.Drawing.Point(10, 174);
			this.sqlDisconnect.Name = "sqlDisconnect";
			this.sqlDisconnect.Size = new System.Drawing.Size(96, 39);
			this.sqlDisconnect.TabIndex = 1;
			this.sqlDisconnect.Text = "Disconnect";
			this.sqlDisconnect.UseVisualStyleBackColor = false;
			// 
			// info
			// 
			this.info.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.info.ForeColor = System.Drawing.Color.Red;
			this.info.Location = new System.Drawing.Point(10, 528);
			this.info.Name = "info";
			this.info.Size = new System.Drawing.Size(816, 20);
			this.info.TabIndex = 2;
			this.info.TabStop = false;
			this.info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// connstring
			// 
			this.connstring.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.connstring.Location = new System.Drawing.Point(10, 4);
			this.connstring.Name = "connstring";
			this.connstring.Size = new System.Drawing.Size(816, 20);
			this.connstring.TabIndex = 3;
			this.connstring.TabStop = false;
			this.connstring.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ReadBankDB
			// 
			this.ReadBankDB.BackColor = System.Drawing.Color.Gold;
			this.ReadBankDB.ForeColor = System.Drawing.Color.Black;
			this.ReadBankDB.Location = new System.Drawing.Point(10, 95);
			this.ReadBankDB.Name = "ReadBankDB";
			this.ReadBankDB.Size = new System.Drawing.Size(96, 39);
			this.ReadBankDB.TabIndex = 5;
			this.ReadBankDB.Text = "Read Bank Account Db";
			this.ReadBankDB.UseVisualStyleBackColor = false;
			this.ReadBankDB.Click += new System.EventHandler(this.ReadBankDB_Click_1);
			// 
			// clear
			// 
			this.clear.BackColor = System.Drawing.Color.Gold;
			this.clear.ForeColor = System.Drawing.Color.Black;
			this.clear.Location = new System.Drawing.Point(732, 151);
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(96, 40);
			this.clear.TabIndex = 6;
			this.clear.Text = "Clear List";
			this.clear.UseVisualStyleBackColor = false;
			this.clear.Click += new System.EventHandler(this.clear_Click_1);
			// 
			// WriteCSVtoCust
			// 
			this.WriteCSVtoCust.BackColor = System.Drawing.Color.Gold;
			this.WriteCSVtoCust.ForeColor = System.Drawing.Color.Black;
			this.WriteCSVtoCust.Location = new System.Drawing.Point(730, 30);
			this.WriteCSVtoCust.Name = "WriteCSVtoCust";
			this.WriteCSVtoCust.Size = new System.Drawing.Size(96, 40);
			this.WriteCSVtoCust.TabIndex = 8;
			this.WriteCSVtoCust.Text = "Write Bulk Data to Customer Db";
			this.WriteCSVtoCust.UseVisualStyleBackColor = false;
			// 
			// WriteTestdatatoBank
			// 
			this.WriteTestdatatoBank.BackColor = System.Drawing.Color.Gold;
			this.WriteTestdatatoBank.ForeColor = System.Drawing.Color.Black;
			this.WriteTestdatatoBank.Location = new System.Drawing.Point(10, 215);
			this.WriteTestdatatoBank.Name = "WriteTestdatatoBank";
			this.WriteTestdatatoBank.Size = new System.Drawing.Size(96, 45);
			this.WriteTestdatatoBank.TabIndex = 9;
			this.WriteTestdatatoBank.Text = "Action your SQL VvV command ";
			this.WriteTestdatatoBank.UseVisualStyleBackColor = false;
			this.WriteTestdatatoBank.Click += new System.EventHandler(this.WriteTestdatatoBank_Click);
			// 
			// ReadCustDB
			// 
			this.ReadCustDB.BackColor = System.Drawing.Color.Gold;
			this.ReadCustDB.ForeColor = System.Drawing.Color.Black;
			this.ReadCustDB.Location = new System.Drawing.Point(10, 56);
			this.ReadCustDB.Name = "ReadCustDB";
			this.ReadCustDB.Size = new System.Drawing.Size(96, 39);
			this.ReadCustDB.TabIndex = 10;
			this.ReadCustDB.Text = "Read Customer Account Db";
			this.ReadCustDB.UseVisualStyleBackColor = false;
			this.ReadCustDB.Click += new System.EventHandler(this.ReadCustDB_Click);
			// 
			// RecordCount
			// 
			this.RecordCount.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.RecordCount.Location = new System.Drawing.Point(10, 28);
			this.RecordCount.Name = "RecordCount";
			this.RecordCount.Size = new System.Drawing.Size(86, 20);
			this.RecordCount.TabIndex = 12;
			this.RecordCount.TabStop = false;
			this.RecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SQLcommand
			// 
			this.SQLcommand.AcceptsTab = true;
			this.SQLcommand.AutoWordSelection = true;
			this.SQLcommand.BackColor = System.Drawing.SystemColors.InfoText;
			this.SQLcommand.DetectUrls = false;
			this.SQLcommand.EnableAutoDragDrop = true;
			this.SQLcommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SQLcommand.ForeColor = System.Drawing.SystemColors.Info;
			this.SQLcommand.HideSelection = false;
			this.SQLcommand.Location = new System.Drawing.Point(10, 384);
			this.SQLcommand.Name = "SQLcommand";
			this.SQLcommand.ShortcutsEnabled = false;
			this.SQLcommand.ShowSelectionMargin = true;
			this.SQLcommand.Size = new System.Drawing.Size(458, 138);
			this.SQLcommand.TabIndex = 14;
			this.SQLcommand.Text = "Type your SQL enquiry here....";
			this.SQLcommand.Enter += new System.EventHandler(this.SQLcommand_Enter);
			// 
			// WriteCSVtoBank
			// 
			this.WriteCSVtoBank.BackColor = System.Drawing.Color.Gold;
			this.WriteCSVtoBank.ForeColor = System.Drawing.Color.Black;
			this.WriteCSVtoBank.Location = new System.Drawing.Point(730, 70);
			this.WriteCSVtoBank.Name = "WriteCSVtoBank";
			this.WriteCSVtoBank.Size = new System.Drawing.Size(96, 40);
			this.WriteCSVtoBank.TabIndex = 16;
			this.WriteCSVtoBank.Text = "Write Bulk Data to Bank Db";
			this.WriteCSVtoBank.UseVisualStyleBackColor = false;
			this.WriteCSVtoBank.Click += new System.EventHandler(this.WriteCSVtoBank_Click_1);
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Items.AddRange(new object[] {
            "[DOUBLE CLICK ON ANY SELECTION]",
            "[to add it to your SQL statement]",
            "Select ",
            "Select TOP 100 ",
            "Select TOP 100 ",
            "Select TOP 100 ",
            "Update Customer ( ",
            "Update BankAccount ( ",
            "Update SecondaryCustAccounts ( ",
            "Insert into Customer ( ",
            "Insert into BankAccount ( ",
            "Insert into SecondaryCustAccounts ( ",
            "",
            "[Add this to END of Enquiry]",
            "[after the fields SELECTED]",
            " from Customer ",
            " from BankAccount ",
            " SecondaryCustAccounts ",
            "",
            "",
            "Values ( ",
            "",
            "[CUSTOMER FIELDS]",
            "CustomerNumber, ",
            "FirstName, ",
            "LastName, ",
            "PhoneNumber, ",
            "MobileNumber, ",
            "Address1, ",
            "Address2, ",
            "Town, ",
            "County, ",
            "PostCode, ",
            "DOB , ",
            "FileName, ",
            "FullFileName, ",
            "SecAccounts, ",
            "",
            "[BANKACCOUNT FIELDS]",
            "BankACNumber, ",
            "CustACNumber, ",
            "AccountType, ",
            "Balance, ",
            "OpenDate, ",
            "CloseDate, ",
            "InterestRate, ",
            "Status, ",
            "",
            "[SECONDARYCUSTACCOUNTS]",
            "AccountType,  ",
            "AccountNum,  ",
            "",
            "[Select Function for (Value data entry eg : DOB)]",
            "[ in correct sequence ]",
            "GetCustNumber",
            "GetBankNumber",
            "GetCustFileName",
            "GetBankFileName",
            "GetCustFullFileName",
            "GetBankFullFileName",
            "GetRandomSQLdate"});
			this.listBox1.Location = new System.Drawing.Point(10, 277);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(458, 100);
			this.listBox1.TabIndex = 17;
			this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
			// 
			// exit
			// 
			this.exit.BackColor = System.Drawing.Color.LightSalmon;
			this.exit.Location = new System.Drawing.Point(732, 233);
			this.exit.Name = "exit";
			this.exit.Size = new System.Drawing.Size(96, 40);
			this.exit.TabIndex = 18;
			this.exit.Text = "Exit";
			this.exit.UseVisualStyleBackColor = false;
			this.exit.Click += new System.EventHandler(this.exit_Click);
			// 
			// sqlLineCommands
			// 
			this.sqlLineCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sqlLineCommands.FormattingEnabled = true;
			this.sqlLineCommands.ItemHeight = 16;
			this.sqlLineCommands.Items.AddRange(new object[] {
            "[DOUBLE CLICK ON ANY SELECTION]",
            "[Enter items one per line]",
            "Select ",
            "Select * from Customer",
            "Select * from BankAccount ",
            "Select TOP 100 from Customer",
            "Select TOP 100 from BankAccount",
            "Insert into Customer ( ",
            "Insert into BankAccount ( ",
            "Insert into SecondaryCustAccounts ( ",
            "Update Customer ( ",
            "Update BankAccount ( ",
            "Update SecondaryCustAccounts ( ",
            "",
            "[ Add at end of your ENQUIRY (only)",
            "from BankAccount ",
            "from Customer  ",
            "from SecondaryCustAccounts ",
            "",
            "[CUSTOMER FIELDS]",
            "CustomerNumber, ",
            "FirstName, ",
            "LastName, ",
            "PhoneNumber, ",
            "MobileNumber, ",
            "Address1, ",
            "Address2, ",
            "Town, ",
            "County, ",
            "PostCode, ",
            "DOB, ",
            "FileName, ",
            "FullFileName, ",
            "SecAccounts, ",
            "",
            "[BANKACCOUNT FIELDS]",
            "BankACNumber, ",
            "CustACNumber, ",
            "AccountType, ",
            "Balance, ",
            "OpenDate, ",
            "CloseDate, ",
            "InterestRate, ",
            "Status, ",
            "",
            "[SECONDARYCUSTACCOUNTS]",
            "AccountType, ",
            "AccountNum, ",
            "",
            "(ONLY Add if you are Updating or indserting data)",
            "Values ( ",
            "",
            "",
            "[Select Function() for (Value data entry eg : DOB = GetRandomSQLDate)]",
            "[ in correct sequence ]",
            "GetRandomSQLdate",
            "GetCustNumber",
            "GetBankNumber",
            "GetCustFileName",
            "GetBankFileName",
            "GetCustFullFileName",
            "GetBankFullFileName"});
			this.sqlLineCommands.Location = new System.Drawing.Point(474, 279);
			this.sqlLineCommands.Name = "sqlLineCommands";
			this.sqlLineCommands.Size = new System.Drawing.Size(352, 100);
			this.sqlLineCommands.TabIndex = 20;
			// 
			// ProcessSQL
			// 
			this.ProcessSQL.BackColor = System.Drawing.Color.Gold;
			this.ProcessSQL.ForeColor = System.Drawing.Color.Black;
			this.ProcessSQL.Location = new System.Drawing.Point(732, 191);
			this.ProcessSQL.Name = "ProcessSQL";
			this.ProcessSQL.Size = new System.Drawing.Size(96, 40);
			this.ProcessSQL.TabIndex = 21;
			this.ProcessSQL.Text = "Process SQL VvV commands ";
			this.ProcessSQL.UseVisualStyleBackColor = false;
			this.ProcessSQL.Click += new System.EventHandler(this.ProcessSQLCommand_Click);
			// 
			// pastedata
			// 
			this.pastedata.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.pastedata.Location = new System.Drawing.Point(112, 75);
			this.pastedata.Name = "pastedata";
			this.pastedata.Size = new System.Drawing.Size(86, 20);
			this.pastedata.TabIndex = 22;
			this.pastedata.TabStop = false;
			this.pastedata.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.pastedata.Visible = false;
			// 
			// MathCommands
			// 
			this.MathCommands.BackColor = System.Drawing.SystemColors.MenuText;
			this.MathCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MathCommands.ForeColor = System.Drawing.SystemColors.Info;
			this.MathCommands.FormattingEnabled = true;
			this.MathCommands.ItemHeight = 16;
			this.MathCommands.Location = new System.Drawing.Point(476, 386);
			this.MathCommands.Name = "MathCommands";
			this.MathCommands.Size = new System.Drawing.Size(352, 132);
			this.MathCommands.TabIndex = 23;
			this.MathCommands.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MathCommands_KeyDown);
			// 
			// schemas
			// 
			this.schemas.BackColor = System.Drawing.Color.Gold;
			this.schemas.ForeColor = System.Drawing.Color.Black;
			this.schemas.Location = new System.Drawing.Point(730, 110);
			this.schemas.Name = "schemas";
			this.schemas.Size = new System.Drawing.Size(96, 40);
			this.schemas.TabIndex = 24;
			this.schemas.Text = "List Db Schemas";
			this.schemas.UseVisualStyleBackColor = false;
			this.schemas.Click += new System.EventHandler(this.schemas_Click);
			// 
			// Data
			// 
			this.Data.AcceptsTab = true;
			this.Data.AutoWordSelection = true;
			this.Data.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.Data.DetectUrls = false;
			this.Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Data.ForeColor = System.Drawing.Color.Navy;
			this.Data.Location = new System.Drawing.Point(112, 30);
			this.Data.Name = "Data";
			this.Data.Size = new System.Drawing.Size(612, 243);
			this.Data.TabIndex = 25;
			this.Data.Text = "SQL result in Text Format...";
			this.Data.TextChanged += new System.EventHandler(this.Data_TextChanged);
			// 
			// sqlcommandslist
			// 
			this.sqlcommandslist.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.sqlcommandslist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sqlcommandslist.HorizontalScrollbar = true;
			this.sqlcommandslist.IntegralHeight = false;
			this.sqlcommandslist.ItemHeight = 16;
			this.sqlcommandslist.Items.AddRange(new object[] {
            "[DOUBLE CLICK ON ANY SELECTION]",
            "[Enter items one per line]",
            "Select ",
            "Select TOP 100 ",
            "Select TOP 100 ",
            "Insert into Customer ( ",
            "Insert into BankAccount ( ",
            "Insert into SecondaryCustAccounts ( ",
            "Update Customer ( ",
            "Update BankAccount ( ",
            "Update SecondaryCustAccounts ( ",
            "Alter Customer ( ",
            "Alter BankAccount ( ",
            "Alter SecondaryCustAccounts ( ",
            "",
            "[CUSTOMER FIELDS]",
            "CustomerNumber",
            "FirstName",
            "LastName",
            "PhoneNumber",
            "MobileNumber",
            "Address1",
            "Address2",
            "Town",
            "County",
            "PostCode",
            "DOB",
            "FileName",
            "FullFileName,",
            "SecAccounts",
            "",
            "[BANKACCOUNT FIELDS]",
            "BankACNumber",
            "CustACNumber",
            "AccountType",
            "Balance",
            "OpenDate",
            "CloseDate",
            "InterestRate",
            "Status",
            "",
            "[SECONDARYCUSTACCOUNTS]",
            "AccountType",
            "AccountNum",
            "",
            "(ONLY Add this if you are Updating or inserting new data)",
            "& only AFTER you have entered ALL the fields to be displayed",
            "",
            "Values ( ",
            "",
            "These functions are ONLY to be used when ADDING or UPDATING data",
            "[Select Function() for (Value data entry eg : DOB = GetRandomSQLDate)]",
            "[ in correct sequence ]",
            "GetRandomSQLdate",
            "GetCustNumber",
            "GetBankNumber",
            "GetCustFileName",
            "GetBankFileName",
            "GetCustFullFileName",
            "GetBankFullFileName",
            "",
            "[ Add at the VERY END end of your ENQUIRY (\'SELECT\' only)",
            "from BankAccount ",
            "from Customer  ",
            "from SecondaryCustAccounts ",
            ""});
			this.sqlcommandslist.Location = new System.Drawing.Point(474, 280);
			this.sqlcommandslist.Name = "sqlcommandslist";
			this.sqlcommandslist.Size = new System.Drawing.Size(354, 100);
			this.sqlcommandslist.TabIndex = 26;
			this.sqlcommandslist.SelectedIndexChanged += new System.EventHandler(this.sqlcommandslist_SelectedIndexChanged);
			this.sqlcommandslist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sqlcommandslist_MouseDoubleClick_1);
			// 
			// MathsValues
			// 
			this.MathsValues.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.MathsValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MathsValues.HorizontalScrollbar = true;
			this.MathsValues.IntegralHeight = false;
			this.MathsValues.ItemHeight = 16;
			this.MathsValues.Items.AddRange(new object[] {
            "-1",
            "-1",
            "1",
            "1",
            "1",
            "2",
            "2",
            "2",
            "3",
            "3",
            "3",
            "4",
            "4",
            "4",
            "-1",
            "-1",
            "5",
            "5",
            "5",
            "5",
            "5",
            "5",
            "5",
            "5",
            "5",
            "5",
            "5",
            "5",
            "5",
            "5",
            "-1",
            "-1",
            "6",
            "6",
            "6",
            "6",
            "6",
            "6",
            "6",
            "6",
            "-1",
            "-1",
            "7",
            "7",
            "-1",
            "-1",
            "-1",
            "-1",
            "8",
            "-1",
            "-1",
            "-1",
            "-1",
            "9",
            "9",
            "9",
            "9",
            "9",
            "9",
            "9",
            "-1",
            "-1",
            "10",
            "10",
            "10",
            "99",
            "99"});
			this.MathsValues.Location = new System.Drawing.Point(394, 279);
			this.MathsValues.Name = "MathsValues";
			this.MathsValues.Size = new System.Drawing.Size(74, 100);
			this.MathsValues.TabIndex = 27;
			this.MathsValues.Visible = false;
			// 
			// sqlconnector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(840, 560);
			this.Controls.Add(this.MathsValues);
			this.Controls.Add(this.sqlcommandslist);
			this.Controls.Add(this.Data);
			this.Controls.Add(this.schemas);
			this.Controls.Add(this.MathCommands);
			this.Controls.Add(this.pastedata);
			this.Controls.Add(this.ProcessSQL);
			this.Controls.Add(this.sqlLineCommands);
			this.Controls.Add(this.exit);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.WriteCSVtoBank);
			this.Controls.Add(this.SQLcommand);
			this.Controls.Add(this.RecordCount);
			this.Controls.Add(this.ReadCustDB);
			this.Controls.Add(this.WriteTestdatatoBank);
			this.Controls.Add(this.WriteCSVtoCust);
			this.Controls.Add(this.clear);
			this.Controls.Add(this.ReadBankDB);
			this.Controls.Add(this.connstring);
			this.Controls.Add(this.info);
			this.Controls.Add(this.sqlDisconnect);
			this.Controls.Add(this.sqlConnect);
			this.Name = "sqlconnector";
			this.Text = "SQL Connection";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button sqlConnect;
		private System.Windows.Forms.Button sqlDisconnect;
		private System.Windows.Forms.TextBox info;
		private System.Windows.Forms.TextBox connstring;
		private System.Windows.Forms.Button ReadBankDB;
		private System.Windows.Forms.Button clear;
		//		private System.Windows.Forms.Button Close;
		private System.Windows.Forms.Button WriteCSVtoCust;
		private System.Windows.Forms.Button WriteTestdatatoBank;
		private System.Windows.Forms.Button ReadCustDB;
		private System.Windows.Forms.TextBox RecordCount;
		private System.Windows.Forms.RichTextBox SQLcommand;
		private System.Windows.Forms.Button WriteCSVtoBank;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button exit;
		private System.Windows.Forms.Button ProcessSQL;
		private System.Windows.Forms.TextBox pastedata;
		private System.Windows.Forms.ListBox MathCommands;
		private System.Windows.Forms.ListBox sqlLineCommands;
		//		public static System.Windows.Forms.RichTextBox data;
		//		private ian1CustDataSet ian1DataSet;
		private System.Windows.Forms.BindingSource customerBindingSource;
		//		private ian1BankDataSet ian1DataSet;
//		private System.Windows.Forms.BindingSource bankBindingSource;
		//		private ian1BankDataSet ian1DataSet1;
/*		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn customerNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn mobileNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn address1DataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn address2DataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn townDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countyDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn postcodeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dOBDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fullFileNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn secAccountsDataGridViewTextBoxColumn;
		//		private System.Windows.Forms.DataGridView dgBankView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
		private ian1DataSet ian1DataSet;
		private System.Windows.Forms.BindingSource customerBindingSource1;
		private ian1DataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
		public static System.Windows.Forms.TextBox data;
/*		private System.Windows.Forms.TextBox Data;
		private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn me;
		private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
		private System.Windows.Forms.DataGridView dgCustView;
		private System.Windows.Forms.TextBox dgView;
*/		private System.Windows.Forms.Button schemas;
		private System.Windows.Forms.RichTextBox Data;
		private System.Windows.Forms.ListBox sqlcommandslist;
		private System.Windows.Forms.ListBox MathsValues;
		//		private System.Windows.Forms.BindingSource bankBindingSource;
	}
}