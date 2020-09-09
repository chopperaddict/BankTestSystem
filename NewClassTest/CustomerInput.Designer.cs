namespace ClassAccessTest
{
    partial class CustomerInput
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
			this.label19 = new System.Windows.Forms.Label();
			this.AccountNo = new System.Windows.Forms.TextBox();
			this.AccountType = new System.Windows.Forms.ComboBox();
			this.Interest = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.OpenDate = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.AccountBalance = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.year = new System.Windows.Forms.TextBox();
			this.month = new System.Windows.Forms.TextBox();
			this.day = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.dob = new System.Windows.Forms.Label();
			this.Exit = new System.Windows.Forms.Button();
			this.WinInfo = new System.Windows.Forms.Label();
			this.mob = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tel = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.pcode = new System.Windows.Forms.TextBox();
			this.county = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.town = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.addr2 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.addr1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lname = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.fname = new System.Windows.Forms.TextBox();
			this.SaveCustButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.LightCoral;
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.AccountNo);
			this.groupBox1.Controls.Add(this.AccountType);
			this.groupBox1.Controls.Add(this.Interest);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.OpenDate);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.AccountBalance);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Location = new System.Drawing.Point(11, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(511, 102);
			this.groupBox1.TabIndex = 50;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Account Type Information";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(12, 22);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(57, 13);
			this.label19.TabIndex = 58;
			this.label19.Text = "Account #";
			// 
			// AccountNo
			// 
			this.AccountNo.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.AccountNo.Enabled = false;
			this.AccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AccountNo.Location = new System.Drawing.Point(79, 19);
			this.AccountNo.MaxLength = 10;
			this.AccountNo.Name = "AccountNo";
			this.AccountNo.Size = new System.Drawing.Size(91, 21);
			this.AccountNo.TabIndex = 57;
			this.AccountNo.TabStop = false;
			this.AccountNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// AccountType
			// 
			this.AccountType.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.AccountType.Items.AddRange(new object[] {
            "1- Normal",
            "2- Savings",
            "3 - Deposit",
            "4 - Business"});
			this.AccountType.Location = new System.Drawing.Point(296, 19);
			this.AccountType.MaxDropDownItems = 4;
			this.AccountType.Name = "AccountType";
			this.AccountType.Size = new System.Drawing.Size(90, 21);
			this.AccountType.TabIndex = 0;
			this.AccountType.SelectedIndexChanged += new System.EventHandler(this.AccountType_SelectedIndexChanged);
			// 
			// Interest
			// 
			this.Interest.Enabled = false;
			this.Interest.HideSelection = false;
			this.Interest.Location = new System.Drawing.Point(230, 72);
			this.Interest.Name = "Interest";
			this.Interest.Size = new System.Drawing.Size(53, 20);
			this.Interest.TabIndex = 2;
			this.Interest.TabStop = false;
			this.Interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label11.Location = new System.Drawing.Point(218, 54);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(81, 15);
			this.label11.TabIndex = 56;
			this.label11.Text = "Interest Rate %";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label12.Location = new System.Drawing.Point(382, 54);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(73, 15);
			this.label12.TabIndex = 55;
			this.label12.Text = "Date Opened";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// OpenDate
			// 
			this.OpenDate.Enabled = false;
			this.OpenDate.Location = new System.Drawing.Point(375, 72);
			this.OpenDate.Name = "OpenDate";
			this.OpenDate.Size = new System.Drawing.Size(91, 20);
			this.OpenDate.TabIndex = 3;
			this.OpenDate.TabStop = false;
			this.OpenDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label13.Location = new System.Drawing.Point(74, 52);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(75, 15);
			this.label13.TabIndex = 54;
			this.label13.Text = "Initial Balance";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AccountBalance
			// 
			this.AccountBalance.HideSelection = false;
			this.AccountBalance.Location = new System.Drawing.Point(79, 72);
			this.AccountBalance.MaxLength = 10;
			this.AccountBalance.Name = "AccountBalance";
			this.AccountBalance.Size = new System.Drawing.Size(62, 20);
			this.AccountBalance.TabIndex = 1;
			this.AccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(226, 24);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(53, 13);
			this.label14.TabIndex = 52;
			this.label14.Text = "A/C Type";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.groupBox2.Controls.Add(this.label18);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.year);
			this.groupBox2.Controls.Add(this.month);
			this.groupBox2.Controls.Add(this.day);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.dob);
			this.groupBox2.Controls.Add(this.Exit);
			this.groupBox2.Controls.Add(this.WinInfo);
			this.groupBox2.Controls.Add(this.mob);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.tel);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.pcode);
			this.groupBox2.Controls.Add(this.county);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.town);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.addr2);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.addr1);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.lname);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.fname);
			this.groupBox2.Controls.Add(this.SaveCustButton);
			this.groupBox2.Location = new System.Drawing.Point(12, 115);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(510, 233);
			this.groupBox2.TabIndex = 52;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Customer Information";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(438, 41);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(12, 13);
			this.label18.TabIndex = 71;
			this.label18.Text = "/";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(386, 41);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(12, 13);
			this.label17.TabIndex = 70;
			this.label17.Text = "/";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(353, 24);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(26, 13);
			this.label16.TabIndex = 69;
			this.label16.Text = "Day";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(399, 24);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(37, 13);
			this.label15.TabIndex = 68;
			this.label15.Text = "Month";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(453, 25);
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
			this.year.Location = new System.Drawing.Point(448, 38);
			this.year.MaxLength = 4;
			this.year.Name = "year";
			this.year.Size = new System.Drawing.Size(49, 20);
			this.year.TabIndex = 6;
			this.year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.year.KeyDown += new System.Windows.Forms.KeyEventHandler(this.year_KeyDown);
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
			this.month.Location = new System.Drawing.Point(398, 38);
			this.month.MaxLength = 2;
			this.month.Name = "month";
			this.month.Size = new System.Drawing.Size(37, 20);
			this.month.TabIndex = 5;
			this.month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.month.TextChanged += new System.EventHandler(this.month_TextChanged);
			this.month.KeyDown += new System.Windows.Forms.KeyEventHandler(this.month_KeyDown);
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
			this.day.Location = new System.Drawing.Point(348, 38);
			this.day.MaxLength = 2;
			this.day.Name = "day";
			this.day.Size = new System.Drawing.Size(37, 20);
			this.day.TabIndex = 4;
			this.day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.day.KeyDown += new System.Windows.Forms.KeyEventHandler(this.day_KeyDown);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(285, 140);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 46);
			this.button1.TabIndex = 15;
			this.button1.Text = "Clear all    entries";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dob
			// 
			this.dob.AutoSize = true;
			this.dob.Location = new System.Drawing.Point(402, 12);
			this.dob.Name = "dob";
			this.dob.Size = new System.Drawing.Size(30, 13);
			this.dob.TabIndex = 64;
			this.dob.Text = "DOB";
			// 
			// Exit
			// 
			this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Exit.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.Exit.Location = new System.Drawing.Point(387, 140);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(110, 46);
			this.Exit.TabIndex = 16;
			this.Exit.Text = "Close Form";
			this.Exit.UseVisualStyleBackColor = false;
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// WinInfo
			// 
			this.WinInfo.BackColor = System.Drawing.Color.White;
			this.WinInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WinInfo.ForeColor = System.Drawing.Color.Red;
			this.WinInfo.Location = new System.Drawing.Point(14, 196);
			this.WinInfo.Name = "WinInfo";
			this.WinInfo.Size = new System.Drawing.Size(483, 23);
			this.WinInfo.TabIndex = 62;
			this.WinInfo.Text = " ";
			this.WinInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mob
			// 
			this.mob.HideSelection = false;
			this.mob.Location = new System.Drawing.Point(14, 158);
			this.mob.MaxLength = 20;
			this.mob.Name = "mob";
			this.mob.Size = new System.Drawing.Size(149, 20);
			this.mob.TabIndex = 13;
			this.mob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(51, 142);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(38, 13);
			this.label10.TabIndex = 60;
			this.label10.Text = "Mobile";
			// 
			// tel
			// 
			this.tel.HideSelection = false;
			this.tel.Location = new System.Drawing.Point(350, 114);
			this.tel.MaxLength = 20;
			this.tel.Name = "tel";
			this.tel.Size = new System.Drawing.Size(147, 20);
			this.tel.TabIndex = 12;
			this.tel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(384, 97);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(58, 13);
			this.label9.TabIndex = 59;
			this.label9.Text = "Telephone";
			// 
			// pcode
			// 
			this.pcode.HideSelection = false;
			this.pcode.Location = new System.Drawing.Point(182, 114);
			this.pcode.MaxLength = 8;
			this.pcode.Name = "pcode";
			this.pcode.Size = new System.Drawing.Size(149, 20);
			this.pcode.TabIndex = 11;
			this.pcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// county
			// 
			this.county.HideSelection = false;
			this.county.Location = new System.Drawing.Point(14, 114);
			this.county.MaxLength = 25;
			this.county.Name = "county";
			this.county.Size = new System.Drawing.Size(149, 20);
			this.county.TabIndex = 10;
			this.county.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(216, 99);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(52, 13);
			this.label8.TabIndex = 58;
			this.label8.Text = "Postcode";
			// 
			// town
			// 
			this.town.HideSelection = false;
			this.town.Location = new System.Drawing.Point(348, 79);
			this.town.MaxLength = 25;
			this.town.Name = "town";
			this.town.Size = new System.Drawing.Size(149, 20);
			this.town.TabIndex = 9;
			this.town.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(62, 97);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 13);
			this.label7.TabIndex = 57;
			this.label7.Text = "County";
			// 
			// addr2
			// 
			this.addr2.HideSelection = false;
			this.addr2.Location = new System.Drawing.Point(182, 79);
			this.addr2.MaxLength = 25;
			this.addr2.Name = "addr2";
			this.addr2.Size = new System.Drawing.Size(149, 20);
			this.addr2.TabIndex = 8;
			this.addr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(388, 62);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 56;
			this.label6.Text = "Town";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(226, 60);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 13);
			this.label5.TabIndex = 54;
			this.label5.Text = "Address 2";
			// 
			// addr1
			// 
			this.addr1.HideSelection = false;
			this.addr1.Location = new System.Drawing.Point(14, 79);
			this.addr1.MaxLength = 25;
			this.addr1.Name = "addr1";
			this.addr1.Size = new System.Drawing.Size(149, 20);
			this.addr1.TabIndex = 7;
			this.addr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(48, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 51;
			this.label4.Text = "Address 1";
			// 
			// lname
			// 
			this.lname.HideSelection = false;
			this.lname.Location = new System.Drawing.Point(182, 38);
			this.lname.MaxLength = 25;
			this.lname.Name = "lname";
			this.lname.Size = new System.Drawing.Size(149, 20);
			this.lname.TabIndex = 3;
			this.lname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(220, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 45;
			this.label2.Text = "Last Name";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 44;
			this.label1.Text = "First Name";
			// 
			// fname
			// 
			this.fname.AccessibleName = "t1";
			this.fname.HideSelection = false;
			this.fname.Location = new System.Drawing.Point(14, 38);
			this.fname.MaxLength = 25;
			this.fname.Name = "fname";
			this.fname.Size = new System.Drawing.Size(149, 20);
			this.fname.TabIndex = 2;
			this.fname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SaveCustButton
			// 
			this.SaveCustButton.BackColor = System.Drawing.Color.Yellow;
			this.SaveCustButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.SaveCustButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveCustButton.Location = new System.Drawing.Point(182, 140);
			this.SaveCustButton.Name = "SaveCustButton";
			this.SaveCustButton.Size = new System.Drawing.Size(86, 46);
			this.SaveCustButton.TabIndex = 14;
			this.SaveCustButton.Text = "Create new Customer";
			this.SaveCustButton.UseVisualStyleBackColor = false;
			this.SaveCustButton.Click += new System.EventHandler(this.SaveCustButton_Click_1);
			// 
			// CustomerInput
			// 
			this.AcceptButton = this.SaveCustButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.CancelButton = this.Exit;
			this.ClientSize = new System.Drawing.Size(534, 350);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomerInput";
			this.Text = "Create New Customer Bank Account";
			this.Load += new System.EventHandler(this.CustomerInput_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Interest;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox OpenDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox AccountBalance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox mob;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox pcode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addr1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.Button SaveCustButton;
        private System.Windows.Forms.Label WinInfo;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ComboBox AccountType;
        private System.Windows.Forms.Label dob;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox year;
        private System.Windows.Forms.TextBox month;
        private System.Windows.Forms.TextBox day;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.TextBox county;
        private System.Windows.Forms.TextBox town;
        private System.Windows.Forms.TextBox addr2;
            private System.Windows.Forms.Label label19;
            private System.Windows.Forms.TextBox AccountNo;
	 }
}