namespace ClassAccessTest
{
    partial class withdrawl
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
            this.textBox2 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.accountnumber = new System.Windows.Forms.MaskedTextBox();
            this.notes = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.MakeWithdrawl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.firstname = new System.Windows.Forms.TextBox();
            this.lastname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox2.BeepOnError = true;
            this.textBox2.Location = new System.Drawing.Point(162, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(63, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(262, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Close Form";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // accountnumber
            // 
            this.accountnumber.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.accountnumber.BeepOnError = true;
            this.accountnumber.Location = new System.Drawing.Point(162, 10);
            this.accountnumber.Name = "accountnumber";
            this.accountnumber.Size = new System.Drawing.Size(63, 20);
            this.accountnumber.TabIndex = 0;
            this.accountnumber.Text = "1050";
            this.accountnumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.accountnumber.Leave += new System.EventHandler(this.accountnumber_Leave);
            // 
            // notes
            // 
            this.notes.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.notes.Location = new System.Drawing.Point(23, 135);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(229, 80);
            this.notes.TabIndex = 2;
            this.notes.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Reason for  withdrawl";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Amount to withdraw";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(262, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 42);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear Form";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MakeWithdrawl
            // 
            this.MakeWithdrawl.BackColor = System.Drawing.Color.Lime;
            this.MakeWithdrawl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MakeWithdrawl.Location = new System.Drawing.Point(262, 10);
            this.MakeWithdrawl.Name = "MakeWithdrawl";
            this.MakeWithdrawl.Size = new System.Drawing.Size(79, 42);
            this.MakeWithdrawl.TabIndex = 3;
            this.MakeWithdrawl.Text = "Make Withdrawl";
            this.MakeWithdrawl.UseVisualStyleBackColor = false;
            this.MakeWithdrawl.Click += new System.EventHandler(this.MakeWithdrawl_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Account number 10500xx";
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(23, 231);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(318, 20);
            this.info.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Customer First Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Customer Last Name";
            // 
            // firstname
            // 
            this.firstname.Location = new System.Drawing.Point(129, 93);
            this.firstname.Name = "firstname";
            this.firstname.ReadOnly = true;
            this.firstname.Size = new System.Drawing.Size(123, 20);
            this.firstname.TabIndex = 17;
            // 
            // lastname
            // 
            this.lastname.Location = new System.Drawing.Point(129, 65);
            this.lastname.Name = "lastname";
            this.lastname.ReadOnly = true;
            this.lastname.Size = new System.Drawing.Size(123, 20);
            this.lastname.TabIndex = 16;
            // 
            // withdrawl
            // 
            this.AcceptButton = this.MakeWithdrawl;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(353, 270);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.info);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.accountnumber);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MakeWithdrawl);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "withdrawl";
            this.Text = "Bank A/C Withdrawls";
            this.Load += new System.EventHandler(this.withdrawl_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.withdrawl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox accountnumber;
        private System.Windows.Forms.RichTextBox notes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button MakeWithdrawl;
        private System.Windows.Forms.Label label1;
		private System . Windows . Forms . TextBox info;
		private System . Windows . Forms . Label label6;
		private System . Windows . Forms . Label label5;
		private System . Windows . Forms . TextBox firstname;
		private System . Windows . Forms . TextBox lastname;
	}
}