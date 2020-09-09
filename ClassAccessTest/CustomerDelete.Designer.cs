namespace ClassAccessTest
{
    partial class CustomerDelete
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
            this.AccountNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.findaccount = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.command = new System.Windows.Forms.TextBox();
            this.filename = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bankno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccountNumber
            // 
            this.AccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.AccountNumber.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.AccountNumber.HideSelection = false;
            this.AccountNumber.Location = new System.Drawing.Point(187, 8);
            this.AccountNumber.MaxLength = 10;
            this.AccountNumber.Name = "AccountNumber";
            this.AccountNumber.Size = new System.Drawing.Size(105, 20);
            this.AccountNumber.TabIndex = 0;
            this.AccountNumber.Text = "1234";
            this.AccountNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AccountNumber.Leave += new System.EventHandler(this.AccountNumber_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Number";
            // 
            // findaccount
            // 
            this.findaccount.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.findaccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findaccount.Location = new System.Drawing.Point(9, 197);
            this.findaccount.Name = "findaccount";
            this.findaccount.Size = new System.Drawing.Size(87, 37);
            this.findaccount.TabIndex = 4;
            this.findaccount.Text = "Find A/c";
            this.findaccount.UseVisualStyleBackColor = false;
            this.findaccount.Click += new System.EventHandler(this.findaccount_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Red;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.ForeColor = System.Drawing.Color.Yellow;
            this.DeleteButton.Location = new System.Drawing.Point(205, 197);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(87, 37);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Delete Account";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.BackColor = System.Drawing.Color.Silver;
            this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Cancelbutton.Location = new System.Drawing.Point(107, 197);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(87, 37);
            this.Cancelbutton.TabIndex = 3;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = false;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            this.Cancelbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cancelbutton_MouseDown);
            // 
            // command
            // 
            this.command.BackColor = System.Drawing.Color.Silver;
            this.command.Location = new System.Drawing.Point(9, 144);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(283, 20);
            this.command.TabIndex = 7;
            this.command.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // filename
            // 
            this.filename.BackColor = System.Drawing.Color.White;
            this.filename.Location = new System.Drawing.Point(9, 1);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(75, 20);
            this.filename.TabIndex = 9;
            this.filename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.filename.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bankno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FirstName);
            this.groupBox1.Location = new System.Drawing.Point(9, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 90);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // bankno
            // 
            this.bankno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.bankno.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bankno.HideSelection = false;
            this.bankno.Location = new System.Drawing.Point(69, -14);
            this.bankno.MaxLength = 10;
            this.bankno.Name = "bankno";
            this.bankno.Size = new System.Drawing.Size(105, 20);
            this.bankno.TabIndex = 14;
            this.bankno.Text = "1234";
            this.bankno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bankno.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Account Lastname";
            // 
            // LastName
            // 
            this.LastName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.LastName.Enabled = false;
            this.LastName.Location = new System.Drawing.Point(132, 60);
            this.LastName.MaxLength = 25;
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(105, 20);
            this.LastName.TabIndex = 8;
            this.LastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Account Firstname";
            // 
            // FirstName
            // 
            this.FirstName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.FirstName.Enabled = false;
            this.FirstName.Location = new System.Drawing.Point(132, 23);
            this.FirstName.MaxLength = 25;
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(105, 20);
            this.FirstName.TabIndex = 7;
            this.FirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "# = 1234xxx";
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.info.Location = new System.Drawing.Point(9, 170);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(283, 20);
            this.info.TabIndex = 13;
            this.info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Customer A/c #";
            // 
            // CustomerDelete
            // 
            this.AcceptButton = this.findaccount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.Cancelbutton;
            this.ClientSize = new System.Drawing.Size(304, 238);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.info);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.command);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.findaccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AccountNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerDelete";
            this.Text = "Delete a Customer";
            this.Load += new System.EventHandler(this.CustomerDelete_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AccountNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button findaccount;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.TextBox filename;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox command;
        public System.Windows.Forms.TextBox LastName;
        public System.Windows.Forms.TextBox FirstName;
        public System.Windows.Forms.TextBox info;
        private System.Windows.Forms.TextBox bankno;
        private System.Windows.Forms.Label label5;
    }
}