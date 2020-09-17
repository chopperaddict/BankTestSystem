namespace ClassAccessTest
{
	partial class SqlDataView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if (disposing && (components != null))
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
			this.components = new System.ComponentModel.Container();
			this.SQLdataGridView = new System.Windows.Forms.DataGridView();
			this.delegatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.delegatesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.SQLdataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.delegatesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.delegatesBindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// SQLdataGridView
			// 
			this.SQLdataGridView.AllowUserToOrderColumns = true;
			this.SQLdataGridView.AutoGenerateColumns = false;
			this.SQLdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.SQLdataGridView.DataSource = this.delegatesBindingSource1;
			this.SQLdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SQLdataGridView.Location = new System.Drawing.Point(0, 0);
			this.SQLdataGridView.Name = "SQLdataGridView";
			this.SQLdataGridView.Size = new System.Drawing.Size(800, 450);
			this.SQLdataGridView.TabIndex = 0;
			this.SQLdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// delegatesBindingSource
			// 
			this.delegatesBindingSource.DataSource = typeof(ClassAccessTest.delegates.delegates);
			// 
			// delegatesBindingSource1
			// 
			this.delegatesBindingSource1.DataSource = typeof(ClassAccessTest.delegates.delegates);
			// 
			// SqlDataView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.SQLdataGridView);
			this.Name = "SqlDataView";
			this.Text = "SqlDataView";
			((System.ComponentModel.ISupportInitialize)(this.SQLdataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.delegatesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.delegatesBindingSource1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System . Windows . Forms . DataGridView SQLdataGridView;
		private System . Windows . Forms . BindingSource delegatesBindingSource;
		private System . Windows . Forms . BindingSource delegatesBindingSource1;
	}
}