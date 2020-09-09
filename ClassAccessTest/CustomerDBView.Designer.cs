namespace ClassAccessTest
{
	partial class CustDataView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustDataView));
			this.CustGridView = new System.Windows.Forms.DataGridView();
			this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ian1DataSet = new ClassAccessTest.CustDataSet();
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
			this.SaveButton = new System.Windows.Forms.Button();
			this.ClearButton = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.customerTableAdapter = new ClassAccessTest.ian1DataSetTableAdapters.CustomerTableAdapter();
			this.info = new System.Windows.Forms.TextBox();
			this.exit = new System.Windows.Forms.Button();
			this.reload = new System.Windows.Forms.Button();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.customerNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mobileNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.address1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.address2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.townDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.postcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dOBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fullFileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			((System.ComponentModel.ISupportInitialize)(this.CustGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ian1DataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
			this.bindingNavigator1.SuspendLayout();
			this.SuspendLayout();
			// 
			// CustGridView
			// 
			this.CustGridView.AllowUserToOrderColumns = true;
			this.CustGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CustGridView.AutoGenerateColumns = false;
			this.CustGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.CustGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.CustGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.CustGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.CustGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.customerNumberDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn,
            this.mobileNumberDataGridViewTextBoxColumn,
            this.address1DataGridViewTextBoxColumn,
            this.address2DataGridViewTextBoxColumn,
            this.townDataGridViewTextBoxColumn,
            this.countyDataGridViewTextBoxColumn,
            this.postcodeDataGridViewTextBoxColumn,
            this.dOBDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.fullFileNameDataGridViewTextBoxColumn});
			this.CustGridView.DataSource = this.customerBindingSource;
			this.CustGridView.Location = new System.Drawing.Point(16, 124);
			this.CustGridView.Margin = new System.Windows.Forms.Padding(60);
			this.CustGridView.Name = "CustGridView";
			this.CustGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.CustGridView.Size = new System.Drawing.Size(772, 388);
			this.CustGridView.TabIndex = 0;
			this.CustGridView.TabStop = false;
			// 
			// customerBindingSource
			// 
			this.customerBindingSource.DataMember = "Customer";
			this.customerBindingSource.DataSource = this.ian1DataSet;
			// 
			// ian1DataSet
			// 
			this.ian1DataSet.DataSetName = "ian1DataSet";
			this.ian1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// bindingNavigator1
			// 
			this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
			this.bindingNavigator1.AllowItemReorder = true;
			this.bindingNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bindingNavigator1.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.bindingNavigator1.BindingSource = this.customerBindingSource;
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
            this.bindingNavigatorDeleteItem,
            this.toolStripComboBox1});
			this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
			this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bindingNavigator1.Name = "bindingNavigator1";
			this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
			this.bindingNavigator1.Size = new System.Drawing.Size(550, 25);
			this.bindingNavigator1.TabIndex = 1;
			this.bindingNavigator1.Text = "bindingNavigator1";
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
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
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(200, 23);
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
			// SaveButton
			// 
			this.SaveButton.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.SaveButton.FlatAppearance.BorderSize = 2;
			this.SaveButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
			this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.SaveButton.Location = new System.Drawing.Point(703, 26);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(85, 36);
			this.SaveButton.TabIndex = 2;
			this.SaveButton.Text = "Save Changes";
			this.SaveButton.UseVisualStyleBackColor = false;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// ClearButton
			// 
			this.ClearButton.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.ClearButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.ClearButton.FlatAppearance.BorderSize = 2;
			this.ClearButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
			this.ClearButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.ClearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClearButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClearButton.Location = new System.Drawing.Point(612, 26);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(85, 36);
			this.ClearButton.TabIndex = 3;
			this.ClearButton.Text = "Clear List";
			this.ClearButton.UseVisualStyleBackColor = false;
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.RoyalBlue;
			this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "FirstName", true));
			this.textBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.textBox1.Location = new System.Drawing.Point(80, 41);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 4;
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.RoyalBlue;
			this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "LastName", true));
			this.textBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.textBox2.Location = new System.Drawing.Point(80, 78);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 5;
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.Color.RoyalBlue;
			this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "PhoneNumber", true));
			this.textBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.textBox3.Location = new System.Drawing.Point(231, 41);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 6;
			// 
			// textBox4
			// 
			this.textBox4.BackColor = System.Drawing.Color.RoyalBlue;
			this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "DOB", true));
			this.textBox4.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.textBox4.Location = new System.Drawing.Point(231, 78);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "First Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Last Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(186, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "DoB";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(186, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Phone";
			// 
			// customerTableAdapter
			// 
			this.customerTableAdapter.ClearBeforeFill = true;
			// 
			// info
			// 
			this.info.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.info.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.info.Location = new System.Drawing.Point(0, 526);
			this.info.Margin = new System.Windows.Forms.Padding(60);
			this.info.Name = "info";
			this.info.Size = new System.Drawing.Size(800, 20);
			this.info.TabIndex = 12;
			this.info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// exit
			// 
			this.exit.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.exit.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.exit.FlatAppearance.BorderSize = 2;
			this.exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
			this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.exit.Location = new System.Drawing.Point(703, 66);
			this.exit.Name = "exit";
			this.exit.Size = new System.Drawing.Size(85, 36);
			this.exit.TabIndex = 13;
			this.exit.Text = "Exit";
			this.exit.UseVisualStyleBackColor = false;
			this.exit.Click += new System.EventHandler(this.exit_Click);
			// 
			// reload
			// 
			this.reload.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.reload.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.reload.FlatAppearance.BorderSize = 2;
			this.reload.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
			this.reload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.reload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.reload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.reload.Location = new System.Drawing.Point(612, 66);
			this.reload.Name = "reload";
			this.reload.Size = new System.Drawing.Size(85, 36);
			this.reload.TabIndex = 14;
			this.reload.Text = "Reload";
			this.reload.UseVisualStyleBackColor = false;
			this.reload.Click += new System.EventHandler(this.reload_Click);
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn.FillWeight = 20F;
			this.idDataGridViewTextBoxColumn.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.ReadOnly = true;
			this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.idDataGridViewTextBoxColumn.Width = 41;
			// 
			// customerNumberDataGridViewTextBoxColumn
			// 
			this.customerNumberDataGridViewTextBoxColumn.DataPropertyName = "CustomerNumber";
			this.customerNumberDataGridViewTextBoxColumn.HeaderText = "CustomerNumber";
			this.customerNumberDataGridViewTextBoxColumn.Name = "customerNumberDataGridViewTextBoxColumn";
			this.customerNumberDataGridViewTextBoxColumn.Width = 113;
			// 
			// firstNameDataGridViewTextBoxColumn
			// 
			this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
			this.firstNameDataGridViewTextBoxColumn.HeaderText = "Christian Name";
			this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
			this.firstNameDataGridViewTextBoxColumn.Width = 95;
			// 
			// lastNameDataGridViewTextBoxColumn
			// 
			this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
			this.lastNameDataGridViewTextBoxColumn.HeaderText = "Surname";
			this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
			this.lastNameDataGridViewTextBoxColumn.Width = 74;
			// 
			// phoneNumberDataGridViewTextBoxColumn
			// 
			this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
			this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "Land Line";
			this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
			this.phoneNumberDataGridViewTextBoxColumn.Width = 73;
			// 
			// mobileNumberDataGridViewTextBoxColumn
			// 
			this.mobileNumberDataGridViewTextBoxColumn.DataPropertyName = "MobileNumber";
			this.mobileNumberDataGridViewTextBoxColumn.HeaderText = "Cell Phone";
			this.mobileNumberDataGridViewTextBoxColumn.Name = "mobileNumberDataGridViewTextBoxColumn";
			this.mobileNumberDataGridViewTextBoxColumn.Width = 77;
			// 
			// address1DataGridViewTextBoxColumn
			// 
			this.address1DataGridViewTextBoxColumn.DataPropertyName = "Address1";
			this.address1DataGridViewTextBoxColumn.HeaderText = "Address1";
			this.address1DataGridViewTextBoxColumn.Name = "address1DataGridViewTextBoxColumn";
			this.address1DataGridViewTextBoxColumn.Width = 76;
			// 
			// address2DataGridViewTextBoxColumn
			// 
			this.address2DataGridViewTextBoxColumn.DataPropertyName = "Address2";
			this.address2DataGridViewTextBoxColumn.HeaderText = "Address2";
			this.address2DataGridViewTextBoxColumn.Name = "address2DataGridViewTextBoxColumn";
			this.address2DataGridViewTextBoxColumn.Width = 76;
			// 
			// townDataGridViewTextBoxColumn
			// 
			this.townDataGridViewTextBoxColumn.DataPropertyName = "Town";
			this.townDataGridViewTextBoxColumn.HeaderText = "Town";
			this.townDataGridViewTextBoxColumn.Name = "townDataGridViewTextBoxColumn";
			this.townDataGridViewTextBoxColumn.Width = 59;
			// 
			// countyDataGridViewTextBoxColumn
			// 
			this.countyDataGridViewTextBoxColumn.DataPropertyName = "County";
			this.countyDataGridViewTextBoxColumn.HeaderText = "County";
			this.countyDataGridViewTextBoxColumn.Name = "countyDataGridViewTextBoxColumn";
			this.countyDataGridViewTextBoxColumn.Width = 65;
			// 
			// postcodeDataGridViewTextBoxColumn
			// 
			this.postcodeDataGridViewTextBoxColumn.DataPropertyName = "Postcode";
			this.postcodeDataGridViewTextBoxColumn.HeaderText = "Postcode";
			this.postcodeDataGridViewTextBoxColumn.Name = "postcodeDataGridViewTextBoxColumn";
			this.postcodeDataGridViewTextBoxColumn.Width = 77;
			// 
			// dOBDataGridViewTextBoxColumn
			// 
			this.dOBDataGridViewTextBoxColumn.DataPropertyName = "DOB";
			this.dOBDataGridViewTextBoxColumn.HeaderText = "DOB";
			this.dOBDataGridViewTextBoxColumn.Name = "dOBDataGridViewTextBoxColumn";
			this.dOBDataGridViewTextBoxColumn.Width = 55;
			// 
			// fileNameDataGridViewTextBoxColumn
			// 
			this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
			this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
			this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
			this.fileNameDataGridViewTextBoxColumn.Width = 76;
			// 
			// fullFileNameDataGridViewTextBoxColumn
			// 
			this.fullFileNameDataGridViewTextBoxColumn.DataPropertyName = "FullFileName";
			this.fullFileNameDataGridViewTextBoxColumn.HeaderText = "FullFileName";
			this.fullFileNameDataGridViewTextBoxColumn.Name = "fullFileNameDataGridViewTextBoxColumn";
			this.fullFileNameDataGridViewTextBoxColumn.Width = 92;
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
			// 
			// CustDataView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(800, 546);
			this.Controls.Add(this.reload);
			this.Controls.Add(this.exit);
			this.Controls.Add(this.info);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.ClearButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.bindingNavigator1);
			this.Controls.Add(this.CustGridView);
			this.Name = "CustDataView";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Customers SQL DB Viewer";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.CustGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ian1DataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
			this.bindingNavigator1.ResumeLayout(false);
			this.bindingNavigator1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView CustGridView;
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
		private CustDataSet ian1DataSet;
		private System.Windows.Forms.BindingSource customerBindingSource;
		private ian1DataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox info;
		private System.Windows.Forms.Button exit;
		private System.Windows.Forms.Button reload;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn customerNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn mobileNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn address1DataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn address2DataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn townDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countyDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn postcodeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dOBDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fullFileNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
	}
}