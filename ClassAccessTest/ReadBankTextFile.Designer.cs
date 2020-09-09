namespace ClassAccessTest
{
    partial class ReadBankTextFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System. ComponentModel. IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components. Dispose ( );
            }
            base. Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
			this.label4 = new System.Windows.Forms.Label();
			this.exit = new System.Windows.Forms.Button();
			this.notes = new System.Windows.Forms.RichTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.clearform = new System.Windows.Forms.Button();
			this.FindFile = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.status = new System.Windows.Forms.TextBox();
			this.OpenDate = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.Interest = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.AccountBalance = new System.Windows.Forms.TextBox();
			this.AccountType = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.rewrite = new System.Windows.Forms.Button();
			this.custno = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.AccountNumber = new System.Windows.Forms.ComboBox();
			this.info = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.CausesValidation = false;
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(193, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 20);
			this.label4.TabIndex = 16;
			this.label4.Text = "Select Bank A/C";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label4.UseCompatibleTextRendering = true;
			// 
			// exit
			// 
			this.exit.BackColor = System.Drawing.Color.Cyan;
			this.exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.exit.Location = new System.Drawing.Point(498, 208);
			this.exit.Name = "exit";
			this.exit.Size = new System.Drawing.Size(113, 42);
			this.exit.TabIndex = 14;
			this.exit.Text = "Close Form (Esc)";
			this.exit.UseVisualStyleBackColor = false;
			this.exit.Click += new System.EventHandler(this.exit_Click);
			// 
			// notes
			// 
			this.notes.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.notes.Location = new System.Drawing.Point(12, 66);
			this.notes.Name = "notes";
			this.notes.Size = new System.Drawing.Size(472, 117);
			this.notes.TabIndex = 10;
			this.notes.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(12, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(155, 17);
			this.label3.TabIndex = 15;
			this.label3.Text = "Raw File contents of Bank A/c";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.UseCompatibleTextRendering = true;
			// 
			// clearform
			// 
			this.clearform.BackColor = System.Drawing.SystemColors.Desktop;
			this.clearform.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.clearform.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.clearform.Location = new System.Drawing.Point(498, 154);
			this.clearform.Name = "clearform";
			this.clearform.Size = new System.Drawing.Size(113, 42);
			this.clearform.TabIndex = 13;
			this.clearform.Text = "&Clear All Data fields";
			this.clearform.UseVisualStyleBackColor = false;
			this.clearform.Click += new System.EventHandler(this.clearform_Click_1);
			// 
			// FindFile
			// 
			this.FindFile.BackColor = System.Drawing.Color.Lime;
			this.FindFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.FindFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FindFile.Location = new System.Drawing.Point(498, 12);
			this.FindFile.Name = "FindFile";
			this.FindFile.Size = new System.Drawing.Size(113, 63);
			this.FindFile.TabIndex = 11;
			this.FindFile.Text = "Load && Display Bank A/C   (Enter)";
			this.FindFile.UseVisualStyleBackColor = false;
			this.FindFile.Click += new System.EventHandler(this.FindFile_Click_1);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Location = new System.Drawing.Point(16, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(162, 34);
			this.label1.TabIndex = 8;
			this.label1.Text = "All changes made and saved will be permanent changes...";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.UseCompatibleTextRendering = true;
			// 
			// label5
			// 
			this.label5.CausesValidation = false;
			this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label5.Location = new System.Drawing.Point(367, 201);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 20);
			this.label5.TabIndex = 86;
			this.label5.Text = "A/C Status";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label5.UseCompatibleTextRendering = true;
			// 
			// status
			// 
			this.status.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.status.Enabled = false;
			this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.status.Location = new System.Drawing.Point(366, 225);
			this.status.MaxLength = 10;
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(91, 22);
			this.status.TabIndex = 85;
			this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// OpenDate
			// 
			this.OpenDate.Enabled = false;
			this.OpenDate.Location = new System.Drawing.Point(40, 251);
			this.OpenDate.Name = "OpenDate";
			this.OpenDate.Size = new System.Drawing.Size(89, 20);
			this.OpenDate.TabIndex = 78;
			this.OpenDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label12
			// 
			this.label12.CausesValidation = false;
			this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label12.Location = new System.Drawing.Point(41, 232);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(88, 15);
			this.label12.TabIndex = 82;
			this.label12.Text = "Date A/c Opened";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label12.UseCompatibleTextRendering = true;
			// 
			// Interest
			// 
			this.Interest.HideSelection = false;
			this.Interest.Location = new System.Drawing.Point(228, 251);
			this.Interest.Name = "Interest";
			this.Interest.Size = new System.Drawing.Size(53, 20);
			this.Interest.TabIndex = 79;
			this.Interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label11
			// 
			this.label11.CausesValidation = false;
			this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label11.Location = new System.Drawing.Point(215, 231);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 17);
			this.label11.TabIndex = 84;
			this.label11.Text = "Interest Rate %";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label11.UseCompatibleTextRendering = true;
			// 
			// label13
			// 
			this.label13.CausesValidation = false;
			this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label13.Location = new System.Drawing.Point(215, 187);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(88, 15);
			this.label13.TabIndex = 83;
			this.label13.Text = "Current Balance";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label13.UseCompatibleTextRendering = true;
			// 
			// AccountBalance
			// 
			this.AccountBalance.HideSelection = false;
			this.AccountBalance.Location = new System.Drawing.Point(224, 205);
			this.AccountBalance.MaxLength = 10;
			this.AccountBalance.Name = "AccountBalance";
			this.AccountBalance.Size = new System.Drawing.Size(62, 20);
			this.AccountBalance.TabIndex = 77;
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
			this.AccountType.Location = new System.Drawing.Point(38, 205);
			this.AccountType.MaxDropDownItems = 4;
			this.AccountType.Name = "AccountType";
			this.AccountType.Size = new System.Drawing.Size(90, 21);
			this.AccountType.TabIndex = 80;
			// 
			// label14
			// 
			this.label14.CausesValidation = false;
			this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label14.Location = new System.Drawing.Point(38, 186);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(91, 15);
			this.label14.TabIndex = 81;
			this.label14.Text = "A/C Type";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label14.UseCompatibleTextRendering = true;
			// 
			// rewrite
			// 
			this.rewrite.BackColor = System.Drawing.Color.LightCoral;
			this.rewrite.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.rewrite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rewrite.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.rewrite.Location = new System.Drawing.Point(498, 84);
			this.rewrite.Name = "rewrite";
			this.rewrite.Size = new System.Drawing.Size(113, 61);
			this.rewrite.TabIndex = 87;
			this.rewrite.Text = "&Update Customer Record globally ?";
			this.rewrite.UseVisualStyleBackColor = false;
			this.rewrite.Click += new System.EventHandler(this.rewrite_Click);
			// 
			// custno
			// 
			this.custno.Enabled = false;
			this.custno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.custno.Location = new System.Drawing.Point(366, 32);
			this.custno.Name = "custno";
			this.custno.Size = new System.Drawing.Size(101, 22);
			this.custno.TabIndex = 88;
			this.custno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.CausesValidation = false;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label2.Location = new System.Drawing.Point(359, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 16);
			this.label2.TabIndex = 89;
			this.label2.Text = "Owned by Customer #";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.UseCompatibleTextRendering = true;
			// 
			// AccountNumber
			// 
			this.AccountNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AccountNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.AccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AccountNumber.ForeColor = System.Drawing.Color.Blue;
			this.AccountNumber.Location = new System.Drawing.Point(192, 32);
			this.AccountNumber.MaxDropDownItems = 6;
			this.AccountNumber.Name = "AccountNumber";
			this.AccountNumber.Size = new System.Drawing.Size(89, 24);
			this.AccountNumber.Sorted = true;
			this.AccountNumber.TabIndex = 1;
			this.AccountNumber.DropDownClosed += new System.EventHandler(this.AccountNumber_DropDownClosed);
			// 
			// info
			// 
			this.info.ForeColor = System.Drawing.Color.Red;
			this.info.Location = new System.Drawing.Point(12, 277);
			this.info.Name = "info";
			this.info.ReadOnly = true;
			this.info.Size = new System.Drawing.Size(599, 20);
			this.info.TabIndex = 90;
			this.info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ReadBankTextFile
			// 
			this.AcceptButton = this.FindFile;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.CancelButton = this.exit;
			this.ClientSize = new System.Drawing.Size(623, 304);
			this.Controls.Add(this.info);
			this.Controls.Add(this.AccountNumber);
			this.Controls.Add(this.custno);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rewrite);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.status);
			this.Controls.Add(this.OpenDate);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.Interest);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.AccountBalance);
			this.Controls.Add(this.AccountType);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.exit);
			this.Controls.Add(this.notes);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.clearform);
			this.Controls.Add(this.FindFile);
			this.Controls.Add(this.label1);
			this.Name = "ReadBankTextFile";
			this.Text = "ReadBankTextFile";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System. Windows. Forms. Label label4;
        private System. Windows. Forms. Button exit;
        private System. Windows. Forms. RichTextBox notes;
        private System. Windows. Forms. Label label3;
        private System. Windows. Forms. Button clearform;
        private System. Windows. Forms. Button FindFile;
        private System. Windows. Forms. Label label1;
        private System. Windows. Forms. Label label5;
        private System. Windows. Forms. TextBox status;
        private System. Windows. Forms. TextBox OpenDate;
        private System. Windows. Forms. Label label12;
        private System. Windows. Forms. TextBox Interest;
        private System. Windows. Forms. Label label11;
        private System. Windows. Forms. Label label13;
        private System. Windows. Forms. TextBox AccountBalance;
        private System. Windows. Forms. ComboBox AccountType;
        private System. Windows. Forms. Label label14;
        private System. Windows. Forms. Button rewrite;
        private System. Windows. Forms. TextBox custno;
        private System. Windows. Forms. Label label2;
        private System. Windows. Forms. ComboBox AccountNumber;
        private System. Windows. Forms. TextBox info;
    }
}