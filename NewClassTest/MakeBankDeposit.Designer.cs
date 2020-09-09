namespace ClassAccessTest
{
    partial class MakeBankDeposit
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
            this.label1 = new System.Windows.Forms.Label();
            this.MakeDeposit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.notes = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.accountnumber = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lastname = new System.Windows.Forms.TextBox();
            this.firstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank Account number";
            // 
            // MakeDeposit
            // 
            this.MakeDeposit.BackColor = System.Drawing.Color.Lime;
            this.MakeDeposit.Enabled = false;
            this.MakeDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MakeDeposit.Location = new System.Drawing.Point(299, 18);
            this.MakeDeposit.Name = "MakeDeposit";
            this.MakeDeposit.Size = new System.Drawing.Size(79, 42);
            this.MakeDeposit.TabIndex = 4;
            this.MakeDeposit.Text = "Make deposit";
            this.MakeDeposit.UseVisualStyleBackColor = false;
            this.MakeDeposit.Click += new System.EventHandler(this.MakeDeposit_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Desktop;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(299, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear data";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Amount to be deposited";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reason for this deposit";
            // 
            // notes
            // 
            this.notes.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.notes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.notes.Location = new System.Drawing.Point(26, 142);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(251, 80);
            this.notes.TabIndex = 3;
            this.notes.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(299, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close Form";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "use : 10500xx";
            // 
            // accountnumber
            // 
            this.accountnumber.Location = new System.Drawing.Point(154, 15);
            this.accountnumber.Name = "accountnumber";
            this.accountnumber.Size = new System.Drawing.Size(47, 20);
            this.accountnumber.TabIndex = 1;
            this.accountnumber.Text = "1050";
            this.accountnumber.Leave += new System.EventHandler(this.accountnumber_Leave_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(154, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(47, 20);
            this.textBox2.TabIndex = 2;
            // 
            // lastname
            // 
            this.lastname.Location = new System.Drawing.Point(154, 66);
            this.lastname.Name = "lastname";
            this.lastname.ReadOnly = true;
            this.lastname.Size = new System.Drawing.Size(123, 20);
            this.lastname.TabIndex = 9;
            // 
            // firstname
            // 
            this.firstname.Location = new System.Drawing.Point(154, 92);
            this.firstname.Name = "firstname";
            this.firstname.ReadOnly = true;
            this.firstname.Size = new System.Drawing.Size(123, 20);
            this.firstname.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Customer Last Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Customer First Name";
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(26, 233);
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(352, 20);
            this.info.TabIndex = 13;
            this.info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MakeBankDeposit
            // 
            this.AcceptButton = this.MakeDeposit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(400, 261);
            this.Controls.Add(this.info);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.accountnumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MakeDeposit);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MakeBankDeposit";
            this.Text = "Make a DEPOSIT";
            this.Load += new System.EventHandler(this.MakeBankDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MakeBankDeposit_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MakeDeposit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox notes;
        private System.Windows.Forms.Button button1;
        private System. Windows. Forms. Label label4;
		private System . Windows . Forms . TextBox accountnumber;
		private System . Windows . Forms . TextBox textBox2;
		private System . Windows . Forms . TextBox lastname;
		private System . Windows . Forms . TextBox firstname;
		private System . Windows . Forms . Label label5;
		private System . Windows . Forms . Label label6;
		private System . Windows . Forms . TextBox info;
	}
}