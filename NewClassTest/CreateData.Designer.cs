namespace ClassAccessTest
{
	partial class CreateData
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
			this.Total = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.Go = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.outputtype = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// Total
			// 
			this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Total.Location = new System.Drawing.Point(278, 28);
			this.Total.Name = "Total";
			this.Total.Size = new System.Drawing.Size(57, 22);
			this.Total.TabIndex = 0;
			this.Total.Text = "50";
			this.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(199, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "How many items do you want to create ?";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(24, 59);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(105, 17);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Comma delimited";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(24, 82);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(89, 17);
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "Tab delimited";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_1);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(24, 105);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(97, 17);
			this.checkBox3.TabIndex = 3;
			this.checkBox3.Text = "Colon delimited";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// Go
			// 
			this.Go.BackColor = System.Drawing.Color.Lime;
			this.Go.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Go.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Go.Location = new System.Drawing.Point(260, 108);
			this.Go.Name = "Go";
			this.Go.Size = new System.Drawing.Size(75, 39);
			this.Go.TabIndex = 6;
			this.Go.Text = "Go";
			this.Go.UseVisualStyleBackColor = false;
			this.Go.Click += new System.EventHandler(this.Go_Click);
			// 
			// Cancel
			// 
			this.Cancel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.Cancel.Location = new System.Drawing.Point(179, 108);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 39);
			this.Cancel.TabIndex = 5;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = false;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(24, 130);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(109, 17);
			this.checkBox4.TabIndex = 4;
			this.checkBox4.Text = "Tilde (~) delimited";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged_1);
			// 
			// outputtype
			// 
			this.outputtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputtype.Location = new System.Drawing.Point(153, 73);
			this.outputtype.Name = "outputtype";
			this.outputtype.Size = new System.Drawing.Size(57, 22);
			this.outputtype.TabIndex = 7;
			this.outputtype.Text = "50";
			this.outputtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.outputtype.Visible = false;
			// 
			// CreateData
			// 
			this.AcceptButton = this.Go;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(363, 168);
			this.Controls.Add(this.outputtype);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Go);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Total);
			this.Name = "CreateData";
			this.Text = "Create Bulk Customer Data";
			this.Load += new System.EventHandler(this.CreateData_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System . Windows . Forms . TextBox Total;
		private System . Windows . Forms . Label label1;
		private System . Windows . Forms . CheckBox checkBox1;
		private System . Windows . Forms . CheckBox checkBox2;
		private System . Windows . Forms . CheckBox checkBox3;
		private System . Windows . Forms . Button Go;
		private System . Windows . Forms . Button Cancel;
		private System . Windows . Forms . CheckBox checkBox4;
		private System . Windows . Forms . TextBox outputtype;
	}
}