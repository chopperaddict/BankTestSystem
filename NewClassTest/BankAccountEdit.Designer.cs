namespace ClassAccessTest
{
	 partial class BankAccountEdit
	 {
		  /// <summary>
		  /// Required designer variable.
		  /// </summary>
		  private System.ComponentModel.IContainer components = null;

		  /// <summary>
		  /// Clean up any resources being used.
		  /// </summary>
		  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		  protected override void Dispose(bool disposing)
		  {
			   if (disposing && (components != null))
			   {
					components.Dispose();
			   }
			   base.Dispose(disposing);
		  }

		  #region Windows Form Designer generated code

		  /// <summary>
		  /// Required method for Designer support - do not modify
		  /// the contents of this method with the code editor.
		  /// </summary>
		  private void InitializeComponent()
		  {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.status = new System.Windows.Forms.TextBox();
			this.findbank = new System.Windows.Forms.Button();
			this.allbankaccounts = new System.Windows.Forms.ListBox();
			this.label24 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.OpenDate = new System.Windows.Forms.TextBox();
			this.AccountNo = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Custno = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.mobile = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.phone = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.postcode = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.county = new System.Windows.Forms.TextBox();
			this.town = new System.Windows.Forms.TextBox();
			this.addr2 = new System.Windows.Forms.TextBox();
			this.addr1 = new System.Windows.Forms.TextBox();
			this.Info = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.year = new System.Windows.Forms.TextBox();
			this.month = new System.Windows.Forms.TextBox();
			this.day = new System.Windows.Forms.TextBox();
			this.dob = new System.Windows.Forms.Label();
			this.lname = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.fname = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.SaveBankButton = new System.Windows.Forms.Button();
			this.Interest = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.AccountBalance = new System.Windows.Forms.TextBox();
			this.AccountType = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.LightCoral;
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.status);
			this.groupBox1.Controls.Add(this.findbank);
			this.groupBox1.Controls.Add(this.allbankaccounts);
			this.groupBox1.Controls.Add(this.label24);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.label23);
			this.groupBox1.Controls.Add(this.OpenDate);
			this.groupBox1.Controls.Add(this.AccountNo);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Location = new System.Drawing.Point(1, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(403, 148);
			this.groupBox1.TabIndex = 53;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bank Account to Edit";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(298, 87);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 76;
			this.label5.Text = "A/C Status";
			// 
			// status
			// 
			this.status.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.status.Enabled = false;
			this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.status.Location = new System.Drawing.Point(283, 105);
			this.status.MaxLength = 10;
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(91, 21);
			this.status.TabIndex = 75;
			this.status.Text = "Active";
			this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// findbank
			// 
			this.findbank.BackColor = System.Drawing.SystemColors.Desktop;
			this.findbank.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.findbank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.findbank.Location = new System.Drawing.Point(25, 88);
			this.findbank.Name = "findbank";
			this.findbank.Size = new System.Drawing.Size(89, 46);
			this.findbank.TabIndex = 1;
			this.findbank.Text = "Find  Bank Account";
			this.findbank.UseVisualStyleBackColor = false;
			this.findbank.Click += new System.EventHandler(this.findbank_Click_1);
			// 
			// allbankaccounts
			// 
			this.allbankaccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.allbankaccounts.IntegralHeight = false;
			this.allbankaccounts.ItemHeight = 16;
			this.allbankaccounts.Location = new System.Drawing.Point(160, 52);
			this.allbankaccounts.MultiColumn = true;
			this.allbankaccounts.Name = "allbankaccounts";
			this.allbankaccounts.Size = new System.Drawing.Size(86, 76);
			this.allbankaccounts.TabIndex = 73;
			this.allbankaccounts.SelectedIndexChanged += new System.EventHandler(this.allbankaccounts_SelectedIndexChanged);
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(31, 23);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(70, 13);
			this.label24.TabIndex = 59;
			this.label24.Text = "Enter Bank #";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(22, 65);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(96, 13);
			this.label22.TabIndex = 68;
			this.label22.Text = "Bank # > 1050000";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(134, 10);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(130, 39);
			this.label23.TabIndex = 72;
			this.label23.Text = "All Bank A/c\'s for this Customer";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// OpenDate
			// 
			this.OpenDate.Enabled = false;
			this.OpenDate.Location = new System.Drawing.Point(283, 52);
			this.OpenDate.Name = "OpenDate";
			this.OpenDate.Size = new System.Drawing.Size(91, 20);
			this.OpenDate.TabIndex = 4;
			this.OpenDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// AccountNo
			// 
			this.AccountNo.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.AccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.AccountNo.Enabled = false;
			this.AccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AccountNo.Location = new System.Drawing.Point(23, 39);
			this.AccountNo.MaxLength = 10;
			this.AccountNo.Name = "AccountNo";
			this.AccountNo.Size = new System.Drawing.Size(91, 21);
			this.AccountNo.TabIndex = 0;
			this.AccountNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label12.Location = new System.Drawing.Point(281, 29);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(94, 15);
			this.label12.TabIndex = 55;
			this.label12.Text = "Date A/c Opened";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.groupBox2.Controls.Add(this.Custno);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label21);
			this.groupBox2.Controls.Add(this.mobile);
			this.groupBox2.Controls.Add(this.label20);
			this.groupBox2.Controls.Add(this.phone);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.postcode);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.county);
			this.groupBox2.Controls.Add(this.town);
			this.groupBox2.Controls.Add(this.addr2);
			this.groupBox2.Controls.Add(this.addr1);
			this.groupBox2.Controls.Add(this.Info);
			this.groupBox2.Controls.Add(this.label18);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.year);
			this.groupBox2.Controls.Add(this.month);
			this.groupBox2.Controls.Add(this.day);
			this.groupBox2.Controls.Add(this.dob);
			this.groupBox2.Controls.Add(this.lname);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.fname);
			this.groupBox2.Location = new System.Drawing.Point(404, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(401, 301);
			this.groupBox2.TabIndex = 57;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Customer Information";
			// 
			// Custno
			// 
			this.Custno.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.Custno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Custno.Enabled = false;
			this.Custno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Custno.Location = new System.Drawing.Point(149, 17);
			this.Custno.MaxLength = 10;
			this.Custno.Name = "Custno";
			this.Custno.Size = new System.Drawing.Size(91, 21);
			this.Custno.TabIndex = 71;
			this.Custno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(82, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 72;
			this.label4.Text = "Customer #";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(266, 208);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(48, 13);
			this.label21.TabIndex = 89;
			this.label21.Text = "Mobile #";
			// 
			// mobile
			// 
			this.mobile.Location = new System.Drawing.Point(218, 224);
			this.mobile.Name = "mobile";
			this.mobile.Size = new System.Drawing.Size(163, 20);
			this.mobile.TabIndex = 16;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(69, 208);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(48, 13);
			this.label20.TabIndex = 87;
			this.label20.Text = "Phone #";
			// 
			// phone
			// 
			this.phone.Location = new System.Drawing.Point(21, 224);
			this.phone.Name = "phone";
			this.phone.Size = new System.Drawing.Size(163, 20);
			this.phone.TabIndex = 15;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(69, 165);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(52, 13);
			this.label10.TabIndex = 85;
			this.label10.Text = "Postcode";
			// 
			// postcode
			// 
			this.postcode.Location = new System.Drawing.Point(21, 181);
			this.postcode.Name = "postcode";
			this.postcode.Size = new System.Drawing.Size(163, 20);
			this.postcode.TabIndex = 11;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(266, 125);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 13);
			this.label9.TabIndex = 83;
			this.label9.Text = "County";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(72, 124);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(34, 13);
			this.label8.TabIndex = 82;
			this.label8.Text = "Town";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(266, 87);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 13);
			this.label7.TabIndex = 81;
			this.label7.Text = "Address 2";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(62, 86);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(54, 13);
			this.label6.TabIndex = 80;
			this.label6.Text = "Address 1";
			// 
			// county
			// 
			this.county.Location = new System.Drawing.Point(218, 141);
			this.county.Name = "county";
			this.county.Size = new System.Drawing.Size(163, 20);
			this.county.TabIndex = 10;
			// 
			// town
			// 
			this.town.Location = new System.Drawing.Point(21, 141);
			this.town.Name = "town";
			this.town.Size = new System.Drawing.Size(163, 20);
			this.town.TabIndex = 9;
			// 
			// addr2
			// 
			this.addr2.Location = new System.Drawing.Point(218, 101);
			this.addr2.Name = "addr2";
			this.addr2.Size = new System.Drawing.Size(163, 20);
			this.addr2.TabIndex = 8;
			// 
			// addr1
			// 
			this.addr1.Location = new System.Drawing.Point(21, 101);
			this.addr1.Name = "addr1";
			this.addr1.Size = new System.Drawing.Size(163, 20);
			this.addr1.TabIndex = 7;
			// 
			// Info
			// 
			this.Info.BackColor = System.Drawing.Color.White;
			this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Info.ForeColor = System.Drawing.Color.Red;
			this.Info.Location = new System.Drawing.Point(18, 263);
			this.Info.Name = "Info";
			this.Info.Size = new System.Drawing.Size(363, 23);
			this.Info.TabIndex = 75;
			this.Info.Text = " ";
			this.Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(322, 181);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(12, 13);
			this.label18.TabIndex = 71;
			this.label18.Text = "/";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(270, 181);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(12, 13);
			this.label17.TabIndex = 70;
			this.label17.Text = "/";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(237, 164);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(26, 13);
			this.label16.TabIndex = 69;
			this.label16.Text = "Day";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(283, 164);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(37, 13);
			this.label15.TabIndex = 68;
			this.label15.Text = "Month";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(337, 165);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 67;
			this.label3.Text = "Year";
			// 
			// year
			// 
			this.year.AutoCompleteCustomSource.AddRange(new string[] {
            "2000"});
			this.year.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.year.HideSelection = false;
			this.year.Location = new System.Drawing.Point(332, 178);
			this.year.MaxLength = 4;
			this.year.Name = "year";
			this.year.Size = new System.Drawing.Size(49, 20);
			this.year.TabIndex = 14;
			this.year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// month
			// 
			this.month.AutoCompleteCustomSource.AddRange(new string[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
			this.month.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.month.HideSelection = false;
			this.month.Location = new System.Drawing.Point(282, 178);
			this.month.MaxLength = 2;
			this.month.Name = "month";
			this.month.Size = new System.Drawing.Size(37, 20);
			this.month.TabIndex = 13;
			this.month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// day
			// 
			this.day.AutoCompleteCustomSource.AddRange(new string[] {
            "01",
            "01",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
			this.day.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.day.HideSelection = false;
			this.day.Location = new System.Drawing.Point(232, 178);
			this.day.MaxLength = 2;
			this.day.Name = "day";
			this.day.Size = new System.Drawing.Size(37, 20);
			this.day.TabIndex = 12;
			this.day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// dob
			// 
			this.dob.AutoSize = true;
			this.dob.Location = new System.Drawing.Point(199, 181);
			this.dob.Name = "dob";
			this.dob.Size = new System.Drawing.Size(30, 13);
			this.dob.TabIndex = 64;
			this.dob.Text = "DOB";
			// 
			// lname
			// 
			this.lname.HideSelection = false;
			this.lname.Location = new System.Drawing.Point(218, 64);
			this.lname.MaxLength = 25;
			this.lname.Name = "lname";
			this.lname.Size = new System.Drawing.Size(163, 20);
			this.lname.TabIndex = 6;
			this.lname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(256, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 45;
			this.label2.Text = "Last Name";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(57, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 44;
			this.label1.Text = "First Name";
			// 
			// fname
			// 
			this.fname.AccessibleName = "t1";
			this.fname.HideSelection = false;
			this.fname.Location = new System.Drawing.Point(21, 64);
			this.fname.MaxLength = 25;
			this.fname.Name = "fname";
			this.fname.Size = new System.Drawing.Size(163, 20);
			this.fname.TabIndex = 5;
			this.fname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Controls.Add(this.Exit);
			this.groupBox3.Controls.Add(this.SaveBankButton);
			this.groupBox3.Controls.Add(this.Interest);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.AccountBalance);
			this.groupBox3.Controls.Add(this.AccountType);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Location = new System.Drawing.Point(2, 154);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(402, 150);
			this.groupBox3.TabIndex = 69;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Changeable Items for this Bank account";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(308, 14);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 46);
			this.button1.TabIndex = 17;
			this.button1.Text = "Clear Form";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// Exit
			// 
			this.Exit.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Exit.Location = new System.Drawing.Point(308, 66);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(88, 46);
			this.Exit.TabIndex = 19;
			this.Exit.Text = "Close Form";
			this.Exit.UseVisualStyleBackColor = false;
			this.Exit.Click += new System.EventHandler(this.Exit_Click_1);
			// 
			// SaveBankButton
			// 
			this.SaveBankButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.SaveBankButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.SaveBankButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveBankButton.Location = new System.Drawing.Point(205, 66);
			this.SaveBankButton.Name = "SaveBankButton";
			this.SaveBankButton.Size = new System.Drawing.Size(88, 46);
			this.SaveBankButton.TabIndex = 18;
			this.SaveBankButton.Text = "Save All Details";
			this.SaveBankButton.UseVisualStyleBackColor = false;
			this.SaveBankButton.Click += new System.EventHandler(this.SaveBankButton_Click);
			// 
			// Interest
			// 
			this.Interest.Enabled = false;
			this.Interest.HideSelection = false;
			this.Interest.Location = new System.Drawing.Point(119, 89);
			this.Interest.Name = "Interest";
			this.Interest.Size = new System.Drawing.Size(53, 20);
			this.Interest.TabIndex = 4;
			this.Interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label11.Location = new System.Drawing.Point(108, 66);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(81, 15);
			this.label11.TabIndex = 58;
			this.label11.Text = "Interest Rate %";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label13.Location = new System.Drawing.Point(7, 66);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(85, 15);
			this.label13.TabIndex = 56;
			this.label13.Text = "Current Balance";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AccountBalance
			// 
			this.AccountBalance.HideSelection = false;
			this.AccountBalance.Location = new System.Drawing.Point(20, 89);
			this.AccountBalance.MaxLength = 10;
			this.AccountBalance.Name = "AccountBalance";
			this.AccountBalance.Size = new System.Drawing.Size(62, 20);
			this.AccountBalance.TabIndex = 3;
			this.AccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// AccountType
			// 
			this.AccountType.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.AccountType.Items.AddRange(new object[] {
            "1- Normal",
            "2- Savings",
            "3 - Deposit",
            "4 - Business"});
			this.AccountType.Location = new System.Drawing.Point(82, 29);
			this.AccountType.MaxDropDownItems = 4;
			this.AccountType.Name = "AccountType";
			this.AccountType.Size = new System.Drawing.Size(90, 21);
			this.AccountType.TabIndex = 53;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(12, 34);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(53, 13);
			this.label14.TabIndex = 54;
			this.label14.Text = "A/C Type";
			// 
			// BankAccountEdit
			// 
			this.AcceptButton = this.findbank;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Exit;
			this.ClientSize = new System.Drawing.Size(805, 306);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.HelpButton = true;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BankAccountEdit";
			this.Text = "Edit any Bank Account (Destructive)";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		  }

		  #endregion
		  private System.Windows.Forms.GroupBox groupBox1;
		  private System.Windows.Forms.TextBox AccountNo;
		  private System.Windows.Forms.Label label12;
		  private System.Windows.Forms.TextBox OpenDate;
		  private System.Windows.Forms.GroupBox groupBox2;
		  private System.Windows.Forms.Label Info;
		  private System.Windows.Forms.Label label18;
		  private System.Windows.Forms.Label label17;
		  private System.Windows.Forms.Label label16;
		  private System.Windows.Forms.Label label15;
		  private System.Windows.Forms.Label label3;
		  private System.Windows.Forms.TextBox year;
		  private System.Windows.Forms.TextBox month;
		  private System.Windows.Forms.TextBox day;
		  private System.Windows.Forms.Label dob;
		  private System.Windows.Forms.TextBox lname;
		  private System.Windows.Forms.Label label2;
		  private System.Windows.Forms.Label label1;
		  private System.Windows.Forms.TextBox fname;
        private System. Windows. Forms. Label label21;
        private System. Windows. Forms. TextBox mobile;
        private System. Windows. Forms. Label label20;
        private System. Windows. Forms. TextBox phone;
        private System. Windows. Forms. Label label10;
        private System. Windows. Forms. TextBox postcode;
        private System. Windows. Forms. Label label9;
        private System. Windows. Forms. Label label8;
        private System. Windows. Forms. Label label7;
        private System. Windows. Forms. Label label6;
        private System. Windows. Forms. TextBox county;
        private System. Windows. Forms. TextBox town;
        private System. Windows. Forms. TextBox addr2;
        private System. Windows. Forms. TextBox addr1;
        private System. Windows. Forms. Label label22;
        private System. Windows. Forms. Label label23;
        private System. Windows. Forms. Label label24;
        private System. Windows. Forms. GroupBox groupBox3;
        private System. Windows. Forms. Button button1;
        private System. Windows. Forms. Button Exit;
        private System. Windows. Forms. Button SaveBankButton;
        private System. Windows. Forms. TextBox Interest;
        private System. Windows. Forms. Label label11;
        private System. Windows. Forms. Label label13;
        private System. Windows. Forms. TextBox AccountBalance;
        private System. Windows. Forms. ComboBox AccountType;
        private System. Windows. Forms. Label label14;
        private System. Windows. Forms. ListBox allbankaccounts;
        private System. Windows. Forms. Label label5;
        private System. Windows. Forms. TextBox status;
        private System. Windows. Forms. Button findbank;
        private System. Windows. Forms. TextBox Custno;
        private System. Windows. Forms. Label label4;
    }
}