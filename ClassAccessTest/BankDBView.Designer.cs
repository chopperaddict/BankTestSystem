namespace ClassAccessTest
{
	partial class BankDBView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if ( disposing && (components != null) )
			{
				components.Dispose ( );
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankDBView));
			this.BankGridView = new System.Windows.Forms.DataGridView();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bankACNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.custACNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.balanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.InterestRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.openDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.closeDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bankDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.bankDataSet = new ClassAccessTest.BankDataSet();
			this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.bankAccountTableAdapter = new ClassAccessTest.BankDataSetTableAdapters.BankAccountTableAdapter();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.custno = new System.Windows.Forms.TextBox();
			this.bankno = new System.Windows.Forms.TextBox();
			this.balance = new System.Windows.Forms.TextBox();
			this.interest = new System.Windows.Forms.TextBox();
			this.reloadsql = new System.Windows.Forms.Button();
			this.dbCount = new System.Windows.Forms.TextBox();
			this.info = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			((System.ComponentModel.ISupportInitialize)(this.BankGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bankDataSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bankDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
			this.bindingNavigator1.SuspendLayout();
			this.SuspendLayout();
			// 
			// BankGridView
			// 
			this.BankGridView.AllowDrop = true;
			this.BankGridView.AllowUserToOrderColumns = true;
			this.BankGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BankGridView.AutoGenerateColumns = false;
			this.BankGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.BankGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.BankGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.BankGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.BankGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.statusDataGridViewTextBoxColumn,
            this.bankACNumberDataGridViewTextBoxColumn,
            this.custACNumberDataGridViewTextBoxColumn,
            this.balanceDataGridViewTextBoxColumn,
            this.InterestRate,
            this.openDateDataGridViewTextBoxColumn,
            this.closeDateDataGridViewTextBoxColumn});
			this.BankGridView.DataMember = "BankAccount";
			this.BankGridView.DataSource = this.bankDataSetBindingSource;
			this.BankGridView.Location = new System.Drawing.Point(22, 125);
			this.BankGridView.Margin = new System.Windows.Forms.Padding(60);
			this.BankGridView.Name = "BankGridView";
			this.BankGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.BankGridView.Size = new System.Drawing.Size(539, 303);
			this.BankGridView.TabIndex = 0;
			this.BankGridView.TabStop = false;
//			this.BankGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BankGridView_CellContentClick);
			// 
			// Id
			// 
			this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.Id.DataPropertyName = "Id";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red;
			dataGridViewCellStyle6.Format = "N0";
			dataGridViewCellStyle6.NullValue = null;
			dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Id.DefaultCellStyle = dataGridViewCellStyle6;
			this.Id.FillWeight = 5F;
			this.Id.HeaderText = "Id";
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Id.Width = 41;
			// 
			// statusDataGridViewTextBoxColumn
			// 
			this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
			this.statusDataGridViewTextBoxColumn.FillWeight = 50F;
			this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
			this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
			this.statusDataGridViewTextBoxColumn.Width = 62;
			// 
			// bankACNumberDataGridViewTextBoxColumn
			// 
			this.bankACNumberDataGridViewTextBoxColumn.DataPropertyName = "BankACNumber";
			this.bankACNumberDataGridViewTextBoxColumn.HeaderText = "Bank A/C #";
			this.bankACNumberDataGridViewTextBoxColumn.MinimumWidth = 25;
			this.bankACNumberDataGridViewTextBoxColumn.Name = "bankACNumberDataGridViewTextBoxColumn";
			this.bankACNumberDataGridViewTextBoxColumn.Width = 76;
			// 
			// custACNumberDataGridViewTextBoxColumn
			// 
			this.custACNumberDataGridViewTextBoxColumn.DataPropertyName = "CustACNumber";
			this.custACNumberDataGridViewTextBoxColumn.HeaderText = "Customer A/C #";
			this.custACNumberDataGridViewTextBoxColumn.Name = "custACNumberDataGridViewTextBoxColumn";
			this.custACNumberDataGridViewTextBoxColumn.Width = 90;
			// 
			// balanceDataGridViewTextBoxColumn
			// 
			this.balanceDataGridViewTextBoxColumn.DataPropertyName = "Balance";
			this.balanceDataGridViewTextBoxColumn.HeaderText = "Balance £";
			this.balanceDataGridViewTextBoxColumn.Name = "balanceDataGridViewTextBoxColumn";
			this.balanceDataGridViewTextBoxColumn.Width = 74;
			// 
			// InterestRate
			// 
			this.InterestRate.DataPropertyName = "InterestRate";
			this.InterestRate.HeaderText = "Interest %";
			this.InterestRate.Name = "InterestRate";
			this.InterestRate.Width = 72;
			// 
			// openDateDataGridViewTextBoxColumn
			// 
			this.openDateDataGridViewTextBoxColumn.DataPropertyName = "OpenDate";
			this.openDateDataGridViewTextBoxColumn.HeaderText = "OpenDate";
			this.openDateDataGridViewTextBoxColumn.Name = "openDateDataGridViewTextBoxColumn";
			this.openDateDataGridViewTextBoxColumn.Width = 81;
			// 
			// closeDateDataGridViewTextBoxColumn
			// 
			this.closeDateDataGridViewTextBoxColumn.DataPropertyName = "CloseDate";
			this.closeDateDataGridViewTextBoxColumn.HeaderText = "CloseDate";
			this.closeDateDataGridViewTextBoxColumn.Name = "closeDateDataGridViewTextBoxColumn";
			this.closeDateDataGridViewTextBoxColumn.Width = 81;
			// 
			// bankDataSetBindingSource
			// 
			this.bankDataSetBindingSource.DataSource = this.bankDataSet;
			this.bankDataSetBindingSource.Position = 0;
			// 
			// bankDataSet
			// 
			this.bankDataSet.DataSetName = "BankDataSet";
			this.bankDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// bankAccountBindingSource
			// 
			this.bankAccountBindingSource.DataMember = "BankAccount";
			this.bankAccountBindingSource.DataSource = this.bankDataSet;
			// 
			// bankAccountTableAdapter
			// 
			this.bankAccountTableAdapter.ClearBeforeFill = true;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.button1.FlatAppearance.BorderSize = 2;
			this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(486, 36);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 34);
			this.button1.TabIndex = 1;
			this.button1.Text = "Clear";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.button2.FlatAppearance.BorderSize = 2;
			this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
			this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(405, 75);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 34);
			this.button2.TabIndex = 2;
			this.button2.Text = "Save";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.button3.FlatAppearance.BorderSize = 2;
			this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
			this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(486, 75);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 34);
			this.button3.TabIndex = 3;
			this.button3.Text = "Exit";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// bindingNavigator1
			// 
			this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
			this.bindingNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bindingNavigator1.BindingSource = this.bankAccountBindingSource;
			this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
			this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
			this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
			this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.toolStripComboBox1,
            this.bindingNavigatorDeleteItem});
			this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
			this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bindingNavigator1.Name = "bindingNavigator1";
			this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
			this.bindingNavigator1.Size = new System.Drawing.Size(335, 27);
			this.bindingNavigator1.TabIndex = 4;
			this.bindingNavigator1.Text = "bindingNavigator1";
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 24);
			this.bindingNavigatorAddNewItem.Text = "Add new";
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
			this.bindingNavigatorCountItem.Text = "of {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
			// 
			// bindingNavigatorDeleteItem
			// 
			this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
			this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
			this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorDeleteItem.Text = "Delete";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem.Text = "Move first";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem.Text = "Move previous";
			// 
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "Position";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.ToolTipText = "Current position";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem.Text = "Move next";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem.Text = "Move last";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Customer #";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Bank Account #";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(226, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Balance £";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(226, 85);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Interest %";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// custno
			// 
			this.custno.BackColor = System.Drawing.Color.RoyalBlue;
			this.custno.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "CustACNumber", true));
			this.custno.ForeColor = System.Drawing.SystemColors.InactiveBorder;
			this.custno.Location = new System.Drawing.Point(110, 43);
			this.custno.Name = "custno";
			this.custno.Size = new System.Drawing.Size(100, 20);
			this.custno.TabIndex = 9;
			this.custno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// bankno
			// 
			this.bankno.BackColor = System.Drawing.Color.RoyalBlue;
			this.bankno.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "BankACNumber", true));
			this.bankno.ForeColor = System.Drawing.SystemColors.InactiveBorder;
			this.bankno.Location = new System.Drawing.Point(110, 82);
			this.bankno.Name = "bankno";
			this.bankno.Size = new System.Drawing.Size(100, 20);
			this.bankno.TabIndex = 10;
			this.bankno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// balance
			// 
			this.balance.BackColor = System.Drawing.Color.RoyalBlue;
			this.balance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true));
			this.balance.ForeColor = System.Drawing.SystemColors.InactiveBorder;
			this.balance.Location = new System.Drawing.Point(287, 43);
			this.balance.Name = "balance";
			this.balance.Size = new System.Drawing.Size(51, 20);
			this.balance.TabIndex = 11;
			this.balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// interest
			// 
			this.interest.BackColor = System.Drawing.Color.RoyalBlue;
			this.interest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "InterestRate", true));
			this.interest.ForeColor = System.Drawing.SystemColors.InactiveBorder;
			this.interest.Location = new System.Drawing.Point(287, 82);
			this.interest.Name = "interest";
			this.interest.Size = new System.Drawing.Size(51, 20);
			this.interest.TabIndex = 12;
			this.interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// reloadsql
			// 
			this.reloadsql.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.reloadsql.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.reloadsql.FlatAppearance.BorderSize = 2;
			this.reloadsql.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
			this.reloadsql.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.reloadsql.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.reloadsql.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.reloadsql.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.reloadsql.Location = new System.Drawing.Point(405, 35);
			this.reloadsql.Name = "reloadsql";
			this.reloadsql.Size = new System.Drawing.Size(75, 34);
			this.reloadsql.TabIndex = 13;
			this.reloadsql.Text = "ReLoad";
			this.reloadsql.UseVisualStyleBackColor = false;
			this.reloadsql.Click += new System.EventHandler(this.loadSQLData_Click);
			// 
			// dbCount
			// 
			this.dbCount.BackColor = System.Drawing.Color.Crimson;
			this.dbCount.ForeColor = System.Drawing.SystemColors.Info;
			this.dbCount.HideSelection = false;
			this.dbCount.Location = new System.Drawing.Point(486, 5);
			this.dbCount.Name = "dbCount";
			this.dbCount.Size = new System.Drawing.Size(51, 20);
			this.dbCount.TabIndex = 14;
			this.dbCount.Text = "200";
			this.dbCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// info
			// 
			this.info.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.info.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.info.Location = new System.Drawing.Point(0, 439);
			this.info.Margin = new System.Windows.Forms.Padding(60);
			this.info.Name = "info";
			this.info.Size = new System.Drawing.Size(584, 20);
			this.info.TabIndex = 15;
			this.info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(376, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "# of Records to load";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
			// 
			// BankDBView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(584, 459);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.info);
			this.Controls.Add(this.dbCount);
			this.Controls.Add(this.reloadsql);
			this.Controls.Add(this.interest);
			this.Controls.Add(this.balance);
			this.Controls.Add(this.bankno);
			this.Controls.Add(this.custno);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bindingNavigator1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.BankGridView);
			this.Name = "BankDBView";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Bank SQL DB Viewer";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.BankDBView_Load);
			((System.ComponentModel.ISupportInitialize)(this.BankGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bankDataSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bankDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
			this.bindingNavigator1.ResumeLayout(false);
			this.bindingNavigator1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView BankGridView;
		private BankDataSet bankDataSet;
		private System.Windows.Forms.BindingSource bankAccountBindingSource;
		private BankDataSetTableAdapters.BankAccountTableAdapter bankAccountTableAdapter;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.BindingNavigator bindingNavigator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox custno;
		private System.Windows.Forms.TextBox bankno;
		private System.Windows.Forms.TextBox balance;
		private System.Windows.Forms.TextBox interest;
		private System.Windows.Forms.Button reloadsql;
		private System.Windows.Forms.TextBox dbCount;
		private System.Windows.Forms.TextBox info;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.BindingSource bankDataSetBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn bankACNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn custACNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn balanceDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn InterestRate;
		private System.Windows.Forms.DataGridViewTextBoxColumn openDateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn closeDateDataGridViewTextBoxColumn;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
	}
}