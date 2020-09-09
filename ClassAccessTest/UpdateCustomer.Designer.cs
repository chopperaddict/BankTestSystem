namespace ClassAccessTest
{
    partial class UpdateCustomer
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AccountType = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.OpenDate = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Interest = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.AccountBalance = new System.Windows.Forms.TextBox();
            this.actype4 = new System.Windows.Forms.Button();
            this.actype3 = new System.Windows.Forms.Button();
            this.actype1 = new System.Windows.Forms.Button();
            this.actype2 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.accountno = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.findCust = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.TextBox();
            this.month = new System.Windows.Forms.TextBox();
            this.day = new System.Windows.Forms.TextBox();
            this.clear = new System.Windows.Forms.Button();
            this.dob = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
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
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightCoral;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.actype4);
            this.groupBox1.Controls.Add(this.actype3);
            this.groupBox1.Controls.Add(this.actype1);
            this.groupBox1.Controls.Add(this.actype2);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.accountno);
            this.groupBox1.Location = new System.Drawing.Point(-2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 151);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Type Information (Non Editable)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AccountType);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.OpenDate);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Location = new System.Drawing.Point(7, 43);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(186, 95);
            this.groupBox4.TabIndex = 82;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fixed Items";
            // 
            // AccountType
            // 
            this.AccountType.AutoCompleteCustomSource.AddRange(new string[] {
            "Normal - 1",
            "Savings - 2",
            "Deposit - 3\t",
            "Business - 4"});
            this.AccountType.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AccountType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AccountType.IntegralHeight = false;
            this.AccountType.Items.AddRange(new object[] {
            "1- Normal",
            "2- Savings",
            "3 - Deposit",
            "4 - Business",
            "                     "});
            this.AccountType.Location = new System.Drawing.Point(86, 19);
            this.AccountType.MaxDropDownItems = 1;
            this.AccountType.Name = "AccountType";
            this.AccountType.Size = new System.Drawing.Size(90, 21);
            this.AccountType.TabIndex = 61;
            this.AccountType.TabStop = false;
            // 
            // label20
            // 
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(6, 55);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 30);
            this.label20.TabIndex = 64;
            this.label20.Text = "Date Account was Opened";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenDate
            // 
            this.OpenDate.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.OpenDate.Enabled = false;
            this.OpenDate.Location = new System.Drawing.Point(86, 61);
            this.OpenDate.Name = "OpenDate";
            this.OpenDate.Size = new System.Drawing.Size(91, 20);
            this.OpenDate.TabIndex = 62;
            this.OpenDate.TabStop = false;
            this.OpenDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(7, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 29);
            this.label21.TabIndex = 63;
            this.label21.Text = "Type of this Account";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Interest);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.AccountBalance);
            this.groupBox3.Location = new System.Drawing.Point(199, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(107, 128);
            this.groupBox3.TabIndex = 81;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Editable Items";
            // 
            // Interest
            // 
            this.Interest.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Interest.Location = new System.Drawing.Point(24, 84);
            this.Interest.MaxLength = 5;
            this.Interest.Name = "Interest";
            this.Interest.Size = new System.Drawing.Size(53, 20);
            this.Interest.TabIndex = 57;
            this.Interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Interest.TextChanged += new System.EventHandler(this.Interest_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(13, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 15);
            this.label11.TabIndex = 60;
            this.label11.Text = "Interest Rate %";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(11, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 15);
            this.label13.TabIndex = 59;
            this.label13.Text = "Current Balance";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountBalance
            // 
            this.AccountBalance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AccountBalance.Location = new System.Drawing.Point(20, 39);
            this.AccountBalance.MaxLength = 10;
            this.AccountBalance.Name = "AccountBalance";
            this.AccountBalance.Size = new System.Drawing.Size(62, 20);
            this.AccountBalance.TabIndex = 58;
            this.AccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AccountBalance.TextChanged += new System.EventHandler(this.AccountBalance_TextChanged);
            // 
            // actype4
            // 
            this.actype4.BackColor = System.Drawing.Color.Silver;
            this.actype4.Enabled = false;
            this.actype4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.actype4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actype4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.actype4.Location = new System.Drawing.Point(416, 86);
            this.actype4.Name = "actype4";
            this.actype4.Size = new System.Drawing.Size(77, 54);
            this.actype4.TabIndex = 80;
            this.actype4.Text = "Business - 4";
            this.actype4.UseVisualStyleBackColor = true;
            this.actype4.Click += new System.EventHandler(this.actype4_Click);
            // 
            // actype3
            // 
            this.actype3.BackColor = System.Drawing.Color.Silver;
            this.actype3.Enabled = false;
            this.actype3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.actype3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actype3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.actype3.Location = new System.Drawing.Point(319, 86);
            this.actype3.Name = "actype3";
            this.actype3.Size = new System.Drawing.Size(77, 54);
            this.actype3.TabIndex = 79;
            this.actype3.Text = "Deposit - 3";
            this.actype3.UseVisualStyleBackColor = true;
            this.actype3.Click += new System.EventHandler(this.actype3_Click);
            // 
            // actype1
            // 
            this.actype1.BackColor = System.Drawing.Color.Silver;
            this.actype1.Enabled = false;
            this.actype1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.actype1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actype1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.actype1.Location = new System.Drawing.Point(319, 14);
            this.actype1.Name = "actype1";
            this.actype1.Size = new System.Drawing.Size(77, 54);
            this.actype1.TabIndex = 77;
            this.actype1.Text = "Normal - 1";
            this.actype1.UseVisualStyleBackColor = true;
            this.actype1.Click += new System.EventHandler(this.actype1_Click);
            // 
            // actype2
            // 
            this.actype2.BackColor = System.Drawing.Color.Silver;
            this.actype2.Enabled = false;
            this.actype2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.actype2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actype2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.actype2.Location = new System.Drawing.Point(416, 14);
            this.actype2.Name = "actype2";
            this.actype2.Size = new System.Drawing.Size(77, 54);
            this.actype2.TabIndex = 78;
            this.actype2.Text = "Savings - 2";
            this.actype2.UseVisualStyleBackColor = true;
            this.actype2.Click += new System.EventHandler(this.actype2_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(14, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 15);
            this.label19.TabIndex = 58;
            this.label19.Text = "Account # 1234....";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // accountno
            // 
            this.accountno.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.accountno.Location = new System.Drawing.Point(131, 17);
            this.accountno.MaxLength = 10;
            this.accountno.Name = "accountno";
            this.accountno.Size = new System.Drawing.Size(52, 20);
            this.accountno.TabIndex = 0;
            this.accountno.Text = "12345";
            this.accountno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.findCust);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.year);
            this.groupBox2.Controls.Add(this.month);
            this.groupBox2.Controls.Add(this.day);
            this.groupBox2.Controls.Add(this.clear);
            this.groupBox2.Controls.Add(this.dob);
            this.groupBox2.Controls.Add(this.Exit);
            this.groupBox2.Controls.Add(this.info);
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
            this.groupBox2.Location = new System.Drawing.Point(-2, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 298);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Information (Editable where enabled)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox4);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Location = new System.Drawing.Point(186, 183);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(319, 72);
            this.groupBox5.TabIndex = 92;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Associated Accounts";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(247, 20);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(68, 17);
            this.checkBox4.TabIndex = 99;
            this.checkBox4.TabStop = false;
            this.checkBox4.Text = "Business";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(176, 20);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(62, 17);
            this.checkBox3.TabIndex = 98;
            this.checkBox3.TabStop = false;
            this.checkBox3.Text = "Deposit";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(94, 20);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(64, 17);
            this.checkBox2.TabIndex = 97;
            this.checkBox2.TabStop = false;
            this.checkBox2.Text = "Savings";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 96;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Normal";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.AllowDrop = true;
            this.textBox3.Location = new System.Drawing.Point(176, 40);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(51, 20);
            this.textBox3.TabIndex = 95;
            this.textBox3.TabStop = false;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.AllowDrop = true;
            this.textBox2.Location = new System.Drawing.Point(95, 40);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 20);
            this.textBox2.TabIndex = 94;
            this.textBox2.TabStop = false;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(15, 40);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 20);
            this.textBox1.TabIndex = 93;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(248, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(51, 20);
            this.textBox4.TabIndex = 92;
            this.textBox4.TabStop = false;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // findCust
            // 
            this.findCust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.findCust.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.findCust.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.findCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findCust.Location = new System.Drawing.Point(10, 103);
            this.findCust.Name = "findCust";
            this.findCust.Size = new System.Drawing.Size(81, 73);
            this.findCust.TabIndex = 11;
            this.findCust.Text = "Find Customer";
            this.findCust.UseVisualStyleBackColor = false;
            this.findCust.Click += new System.EventHandler(this.findCust_Click_1);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(447, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 13);
            this.label18.TabIndex = 71;
            this.label18.Text = "/";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(395, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(12, 13);
            this.label17.TabIndex = 70;
            this.label17.Text = "/";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(362, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 69;
            this.label16.Text = "Day";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(408, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 68;
            this.label15.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 25);
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
            this.year.Enabled = false;
            this.year.Location = new System.Drawing.Point(457, 38);
            this.year.MaxLength = 4;
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(49, 20);
            this.year.TabIndex = 7;
            this.year.TabStop = false;
            this.year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.year.TextChanged += new System.EventHandler(this.year_TextChanged);
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
            this.month.Enabled = false;
            this.month.Location = new System.Drawing.Point(407, 38);
            this.month.MaxLength = 2;
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(37, 20);
            this.month.TabIndex = 6;
            this.month.TabStop = false;
            this.month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.month.TextChanged += new System.EventHandler(this.month_TextChanged);
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
            this.day.Enabled = false;
            this.day.Location = new System.Drawing.Point(357, 38);
            this.day.MaxLength = 2;
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(37, 20);
            this.day.TabIndex = 5;
            this.day.TabStop = false;
            this.day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.day.TextChanged += new System.EventHandler(this.day_TextChanged);
            this.day.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.day_KeyPress);
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.clear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.Location = new System.Drawing.Point(10, 184);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(81, 73);
            this.clear.TabIndex = 13;
            this.clear.Text = "Clear all    entries";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click_1);
            // 
            // dob
            // 
            this.dob.AutoSize = true;
            this.dob.Location = new System.Drawing.Point(393, 11);
            this.dob.Name = "dob";
            this.dob.Size = new System.Drawing.Size(66, 13);
            this.dob.TabIndex = 64;
            this.dob.Text = "Date of Birth";
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Exit.Location = new System.Drawing.Point(97, 104);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(81, 73);
            this.Exit.TabIndex = 14;
            this.Exit.Text = "Close/No changes saved";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click_2);
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.White;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.ForeColor = System.Drawing.Color.Red;
            this.info.Location = new System.Drawing.Point(14, 264);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(492, 23);
            this.info.TabIndex = 62;
            this.info.Text = "Please enter the account number of the  Customer you want to update...";
            this.info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mob
            // 
            this.mob.Location = new System.Drawing.Point(357, 157);
            this.mob.MaxLength = 20;
            this.mob.Name = "mob";
            this.mob.Size = new System.Drawing.Size(149, 20);
            this.mob.TabIndex = 10;
            this.mob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mob.TextChanged += new System.EventHandler(this.mob_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(396, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Mobile";
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(186, 157);
            this.tel.MaxLength = 20;
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(147, 20);
            this.tel.TabIndex = 9;
            this.tel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tel.TextChanged += new System.EventHandler(this.tel_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(222, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Telephone";
            // 
            // pcode
            // 
            this.pcode.Location = new System.Drawing.Point(357, 116);
            this.pcode.MaxLength = 8;
            this.pcode.Name = "pcode";
            this.pcode.Size = new System.Drawing.Size(149, 20);
            this.pcode.TabIndex = 8;
            this.pcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pcode.TextChanged += new System.EventHandler(this.pcode_TextChanged);
            // 
            // county
            // 
            this.county.Location = new System.Drawing.Point(184, 116);
            this.county.MaxLength = 25;
            this.county.Name = "county";
            this.county.Size = new System.Drawing.Size(149, 20);
            this.county.TabIndex = 7;
            this.county.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.county.TextChanged += new System.EventHandler(this.county_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(391, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Postcode";
            // 
            // town
            // 
            this.town.Location = new System.Drawing.Point(357, 78);
            this.town.MaxLength = 25;
            this.town.Name = "town";
            this.town.Size = new System.Drawing.Size(149, 20);
            this.town.TabIndex = 6;
            this.town.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.town.TextChanged += new System.EventHandler(this.town_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "County";
            // 
            // addr2
            // 
            this.addr2.Location = new System.Drawing.Point(186, 79);
            this.addr2.MaxLength = 25;
            this.addr2.Name = "addr2";
            this.addr2.Size = new System.Drawing.Size(149, 20);
            this.addr2.TabIndex = 5;
            this.addr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.addr2.TextChanged += new System.EventHandler(this.addr2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Town";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Address 2";
            // 
            // addr1
            // 
            this.addr1.Location = new System.Drawing.Point(10, 78);
            this.addr1.MaxLength = 25;
            this.addr1.Name = "addr1";
            this.addr1.Size = new System.Drawing.Size(149, 20);
            this.addr1.TabIndex = 4;
            this.addr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.addr1.TextChanged += new System.EventHandler(this.addr1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Address 1";
            // 
            // lname
            // 
            this.lname.Location = new System.Drawing.Point(186, 38);
            this.lname.MaxLength = 25;
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(149, 20);
            this.lname.TabIndex = 3;
            this.lname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lname.TextChanged += new System.EventHandler(this.lname_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "First Name";
            // 
            // fname
            // 
            this.fname.AccessibleName = "t1";
            this.fname.Location = new System.Drawing.Point(10, 38);
            this.fname.MaxLength = 25;
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(149, 20);
            this.fname.TabIndex = 2;
            this.fname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fname.TextChanged += new System.EventHandler(this.fname_TextChanged);
            // 
            // SaveCustButton
            // 
            this.SaveCustButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.SaveCustButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCustButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SaveCustButton.Location = new System.Drawing.Point(97, 183);
            this.SaveCustButton.Name = "SaveCustButton";
            this.SaveCustButton.Size = new System.Drawing.Size(81, 73);
            this.SaveCustButton.TabIndex = 12;
            this.SaveCustButton.Text = "Update Customer details";
            this.SaveCustButton.UseVisualStyleBackColor = false;
            this.SaveCustButton.Click += new System.EventHandler(this.SaveCustButton_Click);
            // 
            // UpdateCustomer
            // 
            this.AcceptButton = this.findCust;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Exit;
            this.ClientSize = new System.Drawing.Size(512, 455);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateCustomer";
            this.Text = "Update Existing Customer Information";
            this.Load += new System.EventHandler(this.UpdateCustomer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox accountno;
		  private System.Windows.Forms.Button actype4;
		  private System.Windows.Forms.Button actype3;
		  private System.Windows.Forms.Button actype2;
		  private System.Windows.Forms.Button actype1;
		  private System.Windows.Forms.GroupBox groupBox2;
		  private System.Windows.Forms.Button findCust;
		  private System.Windows.Forms.Label label18;
		  private System.Windows.Forms.Label label17;
		  private System.Windows.Forms.Label label16;
		  private System.Windows.Forms.Label label15;
		  private System.Windows.Forms.Label label3;
		  private System.Windows.Forms.TextBox year;
		  private System.Windows.Forms.TextBox month;
		  private System.Windows.Forms.TextBox day;
		  private System.Windows.Forms.Button clear;
		  private System.Windows.Forms.Label dob;
		  private System.Windows.Forms.Button Exit;
		  private System.Windows.Forms.Label info;
		  private System.Windows.Forms.TextBox mob;
		  private System.Windows.Forms.Label label10;
		  private System.Windows.Forms.TextBox tel;
		  private System.Windows.Forms.Label label9;
		  private System.Windows.Forms.TextBox pcode;
		  private System.Windows.Forms.TextBox county;
		  private System.Windows.Forms.Label label8;
		  private System.Windows.Forms.TextBox town;
		  private System.Windows.Forms.Label label7;
		  private System.Windows.Forms.TextBox addr2;
		  private System.Windows.Forms.Label label6;
		  private System.Windows.Forms.Label label5;
		  private System.Windows.Forms.TextBox addr1;
		  private System.Windows.Forms.Label label4;
		  private System.Windows.Forms.TextBox lname;
		  private System.Windows.Forms.Label label2;
		  private System.Windows.Forms.Label label1;
		  private System.Windows.Forms.TextBox fname;
		  private System.Windows.Forms.Button SaveCustButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Interest;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox AccountBalance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox AccountType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox OpenDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
    }
}