using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class BankDBView : Form
	{
		private bool dirty = false;
		private bool UseThreads = false;
		//private SqlDataAdapter dataAdapter = new SqlDataAdapter ( );
		public BankDBView ( )
		{
			InitializeComponent ( );
		}
/*
		private async Task <LoadData> BankGridLoadAsync ( )
		{
			Task<Task> tsx = new Task<Task>(LoadBankData);
			return Task(tsx);
		}

		async Task<string> LoadBankData()
		{
			BankGridView.DataSource = bankAccountBindingSource;
			bankAccountTableAdapter.Fill (bankDataSet.BankAccount);
			Task tsk = Task.CompletedTask;
		}
*/
		private void BankDBView_Load (object sender, EventArgs e)
		//==============================================================================
		{
			this.Show ( );
			info.Text = "Please wait, loading all Bank Account's data from SQL Database...";
			if ( !UseThreads )
			{
				// TODO: This line of code loads data into the 'bankDataSet.BankAccount' table. You can move, or remove it, as needed.
				//				var launchthread = new Thread (( ) => {
				//					bankAccountTableAdapter.Fill (bankDataSet.BankAccount);
				//				});
				BankGridView.DataSource = bankAccountBindingSource;
				bankAccountTableAdapter.Fill (bankDataSet.BankAccount);
				//				launchthread.Start ( );
			}
			else
			{
				// threading method ?
				// Bind the DataGridView to the BindingSource
				// and load the data from the database.
				//	BankGridView.DataSource = bankAccountBindingSource;
				//			this.customerTableAdapter.Fill (this.ian1DataSet.Customer);
				Cursor = Cursors.WaitCursor;
				info.Text = "Loading ALL Bank Accounts from SQL Database - Please wait ...";
				Task.Run ((( ) => RunBankLoadThread ( )));
				Cursor = Cursors.Default;
				GetData ("Select from BankAccount");
			}
		}

		private void RunBankLoadThread ( )
		//==============================================================================
		{
			// This loads the Bank data very well
			this.UseThreads = true;
			//make sure we have our data binding sorted out
			BankGridView.DataSource = bankAccountBindingSource;
			bankAccountTableAdapter.Fill (bankDataSet.BankAccount);
			info.Text = "ALL Customer Accounts have been loaded from SQL Database ...";
		}

		private void loadSQLData_Click (object sender, EventArgs e)
		//==============================================================================
		{
			// This loads the Bank data very well
			this.UseThreads = true;
			BankGridView.DataSource = bankAccountBindingSource;
			bankAccountTableAdapter.Fill (bankDataSet.BankAccount);

			/*			info.Text = "ALL Customer Accounts have been loaded from SQL Database ...";
						var ds = bankAccountBindingSource.DataSource;
			//			bankAccountTableAdapter.Fill (bankDataSet.BankAccount);
						info.Text = "ALL Customer Accounts have been loaded from SQL Database ...";
						//			BankGridView.VirtualMode = false;
						string cmd = "";
						if ( dbCount.Text == "" )
							cmd = "select * from BankAccount";
						else
							cmd = "select " + dbCount.Text + " from BankAccount";
						GetData (cmd);
						//			BankGridView.VirtualMode = true;
			*/
		}
		private void reloadsql_Click (object sender, EventArgs e)
		//==============================================================================
		{
			// This loads the Bank data very well
			this.UseThreads = true;
			// This refills it with data from the Db
			// once it's DataSource is reset (after a clear)
			BankGridView.DataSource = bankAccountBindingSource;
			bankAccountTableAdapter.Fill (bankDataSet.BankAccount);
			info.Text = "ALL Customer Accounts have been loaded from SQL Database ...";
		}

		private void button3_Click (object sender, EventArgs e)
		//==============================================================================
		{
			if ( dirty )
			{
				DialogResult dr = new DialogResult ( );
				dr = MessageBox.Show ("You have unsaved changes ? \r\nAre you sure you want to exit without savings them ?", "Database Security System", MessageBoxButtons.OKCancel);
				if ( dr == DialogResult.Cancel )
					return;
			}
			Close ( );
		}

		private void ClearGridView ( )
			//==============================================================================
		{
			if ( this.InvokeRequired ) _ = this.Invoke (new Action (this.ClearGridView));{
				BankGridView.DataSource = null;
				BankGridView.Rows.Clear ( );
				BankGridView.Refresh ( );
				// Reset data bindings
			}
		}

		private void button1_Click(object sender, EventArgs e)
			//==============================================================================
		{ /// Clear the dataview
			// This clears the entire table of Bank data very well

			ClearGridView();
		}

		/*

		{
				this.UseThreads = true; // Not sure if this helps at all ?
										// This clears the GridView very well
				info.Text = "Clearing all data from the SQL Database Viewer...";
				this.UseThreads = true;
				BankGridView.DataSource = null;
				BankGridView.Rows.Clear ( );
				info.Text = "All data cleared from the SQL Database Viewer...";


		//			ClearGridView ( );
		// the rest is teting.
		//dataAdapter.Fill (table);
		/*
					bankAccountTableAdapter.ClearBeforeFill = true;
					SqlDataAdapter dataAdapter = new SqlDataAdapter ( );
					DataTable table = new DataTable ( );
		//			dataAdapter.Fill (table);
		//			BankDataSet.BankAccountDataTable bds = new BankDataSet.BankAccountDataTable();
		//			DataTableReader dataTablereader = bds.CreateDataReader();
		//			bankAccountTableAdapter.Fill (null);
					info.Text = "ALL Customer Accounts have been loaded from SQL Database ...";
					// this  is thre Object (BankAccount in this case)
					string datamember = this.BankGridView.DataMember;
					// This is the current binding source
					object datasource = this.BankGridView.DataSource;
					// total rows in the table
					int rowcount = this.BankGridView.RowCount;
					//nothing useful
					string rowsstr = this.BankGridView.Rows.ToString();
*/

		private void GetData (string selectCommand)
		//==============================================================================
		{
			/*			await Task.Run ((( ) => RunBankLoadThread ( )));
						Cursor = Cursors.Default;
						return;
			*/
			try
			{
				Cursor = Cursors.WaitCursor;
				// Specify a connection string. Replace the given value with a 
				// valid connection string for a Northwind SQL Server sample
				// database accessible to your system.
				string ConnectionString = @"Data Source = DINO-PC\SQLEXPRESS; Initial Catalog = ian1; Integrated Security = True";

				//					"Integrated Security=SSPI;" +
				//					"Initial Catalog= Test ;Data Source=localhost";

				// Create a new data adapter based on the specified query.
				SqlDataAdapter dataAdapter = new SqlDataAdapter ( );
				dataAdapter = new SqlDataAdapter (selectCommand, ConnectionString);

				// Create a command builder to generate SQL update, insert, and
				// delete commands based on selectCommand. These are used to
				// update the database.
				SqlCommandBuilder commandBuilder = new SqlCommandBuilder (dataAdapter);

				// Populate a new data table and bind it to the BindingSource.
				DataTable table = new DataTable ( );
				table.Locale = System.Globalization.CultureInfo.InvariantCulture;
				this.bankAccountBindingSource.DataSource = table;
				dataAdapter.Fill (table);

				// Resize the DataGridView columns to fit the newly loaded content.
				this.BankGridView.AutoResizeColumns (DataGridViewAutoSizeColumnsMode.AllCells);
				Cursor = Cursors.Default;
			}
			catch ( SqlException ex )
			{
				Cursor = Cursors.Default;
				MessageBox.Show (ex.Message);
			}
		}


	}
}
