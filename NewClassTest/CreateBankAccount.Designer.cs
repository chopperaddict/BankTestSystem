namespace ClassAccessTest
{
	partial class CreateBankAccount
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System . ComponentModel . IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components . Dispose ( );
			}
			base . Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
            this.OpenDate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Interest = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.AccountBalance = new System.Windows.Forms.TextBox();
            this.AccountType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AccountNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CreateAccount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenDate
            // 
            this.OpenDate.Enabled = false;
            this.OpenDate.Location = new System.Drawing.Point(140, 32);
            this.OpenDate.Name = "OpenDate";
            this.OpenDate.ReadOnly = true;
            this.OpenDate.Size = new System.Drawing.Size(89, 20);
            this.OpenDate.TabIndex = 89;
            this.OpenDate.TabStop = false;
            this.OpenDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.CausesValidation = false;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(141, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 15);
            this.label12.TabIndex = 93;
            this.label12.Text = "Date A/c Opened";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.UseCompatibleTextRendering = true;
            // 
            // Interest
            // 
            this.Interest.HideSelection = false;
            this.Interest.Location = new System.Drawing.Point(33, 122);
            this.Interest.Name = "Interest";
            this.Interest.Size = new System.Drawing.Size(53, 20);
            this.Interest.TabIndex = 3;
            this.Interest.Text = "3.47";
            this.Interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Interest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Interest_KeyPress);
            // 
            // label11
            // 
            this.label11.CausesValidation = false;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(20, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 17);
            this.label11.TabIndex = 95;
            this.label11.Text = "Interest Rate %";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.UseCompatibleTextRendering = true;
            // 
            // label13
            // 
            this.label13.CausesValidation = false;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(20, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 15);
            this.label13.TabIndex = 94;
            this.label13.Text = "Current Balance";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.UseCompatibleTextRendering = true;
            // 
            // AccountBalance
            // 
            this.AccountBalance.HideSelection = false;
            this.AccountBalance.Location = new System.Drawing.Point(29, 74);
            this.AccountBalance.MaxLength = 10;
            this.AccountBalance.Name = "AccountBalance";
            this.AccountBalance.Size = new System.Drawing.Size(62, 20);
            this.AccountBalance.TabIndex = 2;
            this.AccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AccountBalance.TextChanged += new System.EventHandler(this.AccountBalance_TextChanged);
            this.AccountBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccountBalance_KeyPress);
            // 
            // AccountType
            // 
            this.AccountType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AccountType.Items.AddRange(new object[] {
            "1- Normal",
            "2- Savings",
            "3 - Deposit",
            "4 - Business"});
            this.AccountType.Location = new System.Drawing.Point(17, 31);
            this.AccountType.MaxDropDownItems = 4;
            this.AccountType.Name = "AccountType";
            this.AccountType.Size = new System.Drawing.Size(90, 21);
            this.AccountType.TabIndex = 1;
            this.AccountType.SelectedIndexChanged += new System.EventHandler(this.AccountType_SelectedIndexChanged);
            this.AccountType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccountType_KeyPress);
            // 
            // label14
            // 
            this.label14.CausesValidation = false;
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(17, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 15);
            this.label14.TabIndex = 92;
            this.label14.Text = "Select A/C Type";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.AccountNumber);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(127, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 81);
            this.panel1.TabIndex = 99;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // AccountNumber
            // 
            this.AccountNumber.HideSelection = false;
            this.AccountNumber.Location = new System.Drawing.Point(22, 37);
            this.AccountNumber.MaxLength = 10;
            this.AccountNumber.Name = "AccountNumber";
            this.AccountNumber.Size = new System.Drawing.Size(62, 20);
            this.AccountNumber.TabIndex = 100;
            this.AccountNumber.TabStop = false;
            this.AccountNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.CausesValidation = false;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 99;
            this.label5.Text = "New Account #";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // CreateAccount
            // 
            this.CreateAccount.BackColor = System.Drawing.Color.Lime;
            this.CreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccount.Location = new System.Drawing.Point(261, 65);
            this.CreateAccount.Name = "CreateAccount";
            this.CreateAccount.Size = new System.Drawing.Size(113, 63);
            this.CreateAccount.TabIndex = 4;
            this.CreateAccount.Text = "Create Solo Bank Account";
            this.CreateAccount.UseVisualStyleBackColor = false;
            this.CreateAccount.Click += new System.EventHandler(this.CreateAccount_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(261, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 72);
            this.button1.TabIndex = 5;
            this.button1.Text = "Close/Exit Form";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(17, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 72);
            this.panel2.TabIndex = 101;
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Location = new System.Drawing.Point(63, 35);
            this.comboBox1.MaxDropDownItems = 4;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(90, 21);
            this.comboBox1.TabIndex = 94;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.CausesValidation = false;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 15);
            this.label1.TabIndex = 93;
            this.label1.Text = "Select Customer A/c to own this A/c";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // info
            // 
            this.info.Enabled = false;
            this.info.ForeColor = System.Drawing.Color.Red;
            this.info.Location = new System.Drawing.Point(17, 234);
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(357, 20);
            this.info.TabIndex = 102;
            this.info.TabStop = false;
            this.info.Text = "Ensure a Customer A/c is selected before Creating new Bank Account";
            this.info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CreateBankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(386, 264);
            this.Controls.Add(this.info);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CreateAccount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OpenDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Interest);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.AccountBalance);
            this.Controls.Add(this.AccountType);
            this.Controls.Add(this.label14);
            this.Name = "CreateBankAccount";
            this.Text = "Create solo Bank Account";
            this.Load += new System.EventHandler(this.CreateBankAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System . Windows . Forms . TextBox OpenDate;
		private System . Windows . Forms . Label label12;
		private System . Windows . Forms . TextBox Interest;
		private System . Windows . Forms . Label label11;
		private System . Windows . Forms . Label label13;
		private System . Windows . Forms . TextBox AccountBalance;
		private System . Windows . Forms . ComboBox AccountType;
		private System . Windows . Forms . Label label14;
		private System . Windows . Forms . Panel panel1;
		private System . Windows . Forms . TextBox AccountNumber;
		private System . Windows . Forms . Label label5;
		private System . Windows . Forms . Button CreateAccount;
		private System . Windows . Forms . Button button1;
		private System . Windows . Forms . Panel panel2;
		private System . Windows . Forms . Label label1;
		private System . Windows . Forms . ComboBox comboBox1;
		private System . Windows . Forms . TextBox info;
	}
}