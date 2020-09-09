namespace ClassAccessTest
{
	partial class SortArray
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
			this.Alpha = new System.Windows.Forms.Button();
			this.Contra = new System.Windows.Forms.Button();
			this.Info = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.SLLnormal = new System.Windows.Forms.Button();
			this.SLLreverse = new System.Windows.Forms.Button();
			this.Info2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.close = new System.Windows.Forms.Button();
			this.Custarraynormal = new System.Windows.Forms.Button();
			this.Custarrayreverse = new System.Windows.Forms.Button();
			this.Custarrayinfo = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.Custlistnormal = new System.Windows.Forms.Button();
			this.Custlistreverse = new System.Windows.Forms.Button();
			this.Custllinfo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// Alpha
			// 
			this.Alpha.BackColor = System.Drawing.Color.Silver;
			this.Alpha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Alpha.Location = new System.Drawing.Point(17, 64);
			this.Alpha.Name = "Alpha";
			this.Alpha.Size = new System.Drawing.Size(75, 23);
			this.Alpha.TabIndex = 0;
			this.Alpha.Text = "Normal";
			this.Alpha.UseVisualStyleBackColor = false;
			this.Alpha.Click += new System.EventHandler(this.Alpha_Click_1);
			// 
			// Contra
			// 
			this.Contra.BackColor = System.Drawing.Color.Silver;
			this.Contra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Contra.Location = new System.Drawing.Point(108, 64);
			this.Contra.Name = "Contra";
			this.Contra.Size = new System.Drawing.Size(75, 23);
			this.Contra.TabIndex = 1;
			this.Contra.Text = "Reverse";
			this.Contra.UseVisualStyleBackColor = false;
			this.Contra.Click += new System.EventHandler(this.Contra_Click_1);
			// 
			// Info
			// 
			this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Info.Location = new System.Drawing.Point(17, 29);
			this.Info.Name = "Info";
			this.Info.Size = new System.Drawing.Size(166, 20);
			this.Info.TabIndex = 5;
			this.Info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(49, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Current sort order ";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.Info);
			this.panel1.Controls.Add(this.Contra);
			this.panel1.Controls.Add(this.Alpha);
			this.panel1.Location = new System.Drawing.Point(12, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 103);
			this.panel1.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(57, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Bank - Data Array/List";
			// 
			// SLLnormal
			// 
			this.SLLnormal.BackColor = System.Drawing.Color.Silver;
			this.SLLnormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.SLLnormal.Location = new System.Drawing.Point(17, 64);
			this.SLLnormal.Name = "SLLnormal";
			this.SLLnormal.Size = new System.Drawing.Size(75, 23);
			this.SLLnormal.TabIndex = 2;
			this.SLLnormal.Text = "Normal";
			this.SLLnormal.UseVisualStyleBackColor = false;
			this.SLLnormal.Click += new System.EventHandler(this.SLLnormal_Click);
			// 
			// SLLreverse
			// 
			this.SLLreverse.BackColor = System.Drawing.Color.Silver;
			this.SLLreverse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.SLLreverse.Location = new System.Drawing.Point(108, 64);
			this.SLLreverse.Name = "SLLreverse";
			this.SLLreverse.Size = new System.Drawing.Size(75, 23);
			this.SLLreverse.TabIndex = 3;
			this.SLLreverse.Text = "Reverse";
			this.SLLreverse.UseVisualStyleBackColor = false;
			this.SLLreverse.Click += new System.EventHandler(this.SLLreverse_Click);
			// 
			// Info2
			// 
			this.Info2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Info2.Location = new System.Drawing.Point(17, 29);
			this.Info2.Name = "Info2";
			this.Info2.Size = new System.Drawing.Size(166, 20);
			this.Info2.TabIndex = 5;
			this.Info2.TabStop = false;
			this.Info2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(49, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Current sort order ";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.Info2);
			this.panel2.Controls.Add(this.SLLreverse);
			this.panel2.Controls.Add(this.SLLnormal);
			this.panel2.Location = new System.Drawing.Point(228, 28);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(200, 103);
			this.panel2.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(283, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Bank - Linked List";
			// 
			// close
			// 
			this.close.BackColor = System.Drawing.Color.Silver;
			this.close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.close.Location = new System.Drawing.Point(181, 267);
			this.close.Name = "close";
			this.close.Size = new System.Drawing.Size(75, 23);
			this.close.TabIndex = 8;
			this.close.Text = "Close";
			this.close.UseVisualStyleBackColor = false;
			this.close.Click += new System.EventHandler(this.close_Click_1);
			// 
			// Custarraynormal
			// 
			this.Custarraynormal.BackColor = System.Drawing.Color.Silver;
			this.Custarraynormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Custarraynormal.Location = new System.Drawing.Point(17, 64);
			this.Custarraynormal.Name = "Custarraynormal";
			this.Custarraynormal.Size = new System.Drawing.Size(75, 23);
			this.Custarraynormal.TabIndex = 4;
			this.Custarraynormal.Text = "Normal";
			this.Custarraynormal.UseVisualStyleBackColor = false;
			this.Custarraynormal.Click += new System.EventHandler(this.Custarraynormal_Click);
			// 
			// Custarrayreverse
			// 
			this.Custarrayreverse.BackColor = System.Drawing.Color.Silver;
			this.Custarrayreverse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Custarrayreverse.Location = new System.Drawing.Point(108, 64);
			this.Custarrayreverse.Name = "Custarrayreverse";
			this.Custarrayreverse.Size = new System.Drawing.Size(75, 23);
			this.Custarrayreverse.TabIndex = 5;
			this.Custarrayreverse.Text = "Reverse";
			this.Custarrayreverse.UseVisualStyleBackColor = false;
			this.Custarrayreverse.Click += new System.EventHandler(this.Custarrayreverse_Click_2);
			// 
			// Custarrayinfo
			// 
			this.Custarrayinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Custarrayinfo.Location = new System.Drawing.Point(17, 29);
			this.Custarrayinfo.Name = "Custarrayinfo";
			this.Custarrayinfo.Size = new System.Drawing.Size(166, 20);
			this.Custarrayinfo.TabIndex = 5;
			this.Custarrayinfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(49, 13);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(91, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Current sort order ";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.label8);
			this.panel4.Controls.Add(this.Custarrayinfo);
			this.panel4.Controls.Add(this.Custarrayreverse);
			this.panel4.Controls.Add(this.Custarraynormal);
			this.panel4.Location = new System.Drawing.Point(12, 158);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(200, 103);
			this.panel4.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(42, 152);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(131, 13);
			this.label7.TabIndex = 14;
			this.label7.Text = "Customer - Data Array/List";
			// 
			// Custlistnormal
			// 
			this.Custlistnormal.BackColor = System.Drawing.Color.Silver;
			this.Custlistnormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Custlistnormal.Location = new System.Drawing.Point(17, 64);
			this.Custlistnormal.Name = "Custlistnormal";
			this.Custlistnormal.Size = new System.Drawing.Size(75, 23);
			this.Custlistnormal.TabIndex = 6;
			this.Custlistnormal.Text = "Normal";
			this.Custlistnormal.UseVisualStyleBackColor = false;
			this.Custlistnormal.Click += new System.EventHandler(this.Custlistnormal_Click_1);
			// 
			// Custlistreverse
			// 
			this.Custlistreverse.BackColor = System.Drawing.Color.Silver;
			this.Custlistreverse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Custlistreverse.Location = new System.Drawing.Point(108, 64);
			this.Custlistreverse.Name = "Custlistreverse";
			this.Custlistreverse.Size = new System.Drawing.Size(75, 23);
			this.Custlistreverse.TabIndex = 7;
			this.Custlistreverse.Text = "Reverse";
			this.Custlistreverse.UseVisualStyleBackColor = false;
			this.Custlistreverse.Click += new System.EventHandler(this.Custlistreverse_Click_1);
			// 
			// Custllinfo
			// 
			this.Custllinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Custllinfo.Location = new System.Drawing.Point(17, 29);
			this.Custllinfo.Name = "Custllinfo";
			this.Custllinfo.Size = new System.Drawing.Size(166, 20);
			this.Custllinfo.TabIndex = 5;
			this.Custllinfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(49, 13);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(91, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Current sort order ";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.Custllinfo);
			this.panel3.Controls.Add(this.Custlistreverse);
			this.panel3.Controls.Add(this.Custlistnormal);
			this.panel3.Location = new System.Drawing.Point(228, 158);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(200, 103);
			this.panel3.TabIndex = 15;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(269, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(111, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Customer - Linked List";
			// 
			// SortArray
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(453, 300);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.close);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Name = "SortArray";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sort Bank & Customer data in Arrays & Linked lists";
			this.Load += new System.EventHandler(this.SortArray_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System . Windows . Forms . Button Alpha;
		private System . Windows . Forms . Button Contra;
		private System . Windows . Forms . TextBox Info;
		private System . Windows . Forms . Label label1;
		private System . Windows . Forms . Panel panel1;
		private System . Windows . Forms . Label label2;
		private System . Windows . Forms . Button SLLnormal;
		private System . Windows . Forms . Button SLLreverse;
		private System . Windows . Forms . TextBox Info2;
		private System . Windows . Forms . Label label4;
		private System . Windows . Forms . Panel panel2;
		private System . Windows . Forms . Label label3;
		private System . Windows . Forms . Button close;
		private System . Windows . Forms . Button Custarraynormal;
		private System . Windows . Forms . Button Custarrayreverse;
		private System . Windows . Forms . TextBox Custarrayinfo;
		private System . Windows . Forms . Label label8;
		private System . Windows . Forms . Panel panel4;
		private System . Windows . Forms . Label label7;
		private System . Windows . Forms . Button Custlistnormal;
		private System . Windows . Forms . Button Custlistreverse;
		private System . Windows . Forms . TextBox Custllinfo;
		private System . Windows . Forms . Label label6;
		private System . Windows . Forms . Panel panel3;
		private System . Windows . Forms . Label label5;
	}
}