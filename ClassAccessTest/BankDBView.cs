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
		private bool UseThreads = true;
		//private SqlDataAdapter dataAdapter = new SqlDataAdapter ( );
		public BankDBView ( )
		{
			InitializeComponent ( );
		}

		private async void BankDBView_Load (object sender, EventArgs e)
		//==============================================================================
		{
			info.Text = "Please wait, loading all Bank Account's data from SQL Database...";
			if (UseThreads )
			{
				// Callng an async Function FillGridView() just above here
				System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch ( );
				sw.Start ( );
				//				Task t = Task.Factory.StartNew (Action);
				//			await t.Start(FillGridView (t));
				var LoadSql = FillGridView (3);
				sw.Stop();
				info.Text = ($"Time taken to load SQL data was {sw.Elapsed} milliSeconds");
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
//				GetData ("Select from BankAccount");
			}
		}

		private void RunBankLoadThread ( )
		//==============================================================================
		{
			// This loads the Bank data very well
			//			this.UseThreads = true;
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch ( );
			sw.Start ( );
			//make sure we have our data binding sorted out
			BankGridView.DataSource = bankAccountBindingSource;
			bankAccountTableAdapter.Fill (bankDataSet.BankAccount);
			sw.Stop();
			info.Text = $"ALL Customer Accounts have been loaded in {sw.Elapsed} milliseconds from SQL Database ...";
		}

		private async Task<string> FillGridView (int slices)
		{
			BankGridView.DataSource = bankAccountBindingSource;
			bankAccountTableAdapter.Fill (bankDataSet.BankAccount);
			return "DBType";
		}

		private async void loadSQLData_Click (object sender, EventArgs e)
		//==============================================================================
		{
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch ( );
			sw.Start ( );
			var LoadSql = FillGridView (3);
			sw.Stop ( );
			info.Text = $"ALL Customer Accounts have been loaded in {sw.Elapsed} milliseconds from SQL Database ...";
			// This loads the Bank data very well - Fn is above
			//			Task finishedTask = Task.WhenAny (LoadSql);
			return;
//			this.UseThreads = true;
			/*
			BankGridView.DataSource = bankAccountBindingSource;
			bankAccountTableAdapter.Fill (bankDataSet.BankAccount);
			   */
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
			if ( this.InvokeRequired ) _ = this.Invoke (new Action (this.ClearGridView));
			{
				BankGridView.DataSource = null;
				BankGridView.Rows.Clear ( );
				BankGridView.Refresh ( );
				// Reset data bindings
			}
		}

		private void button1_Click (object sender, EventArgs e)
		//==============================================================================
		{ /// Clear the dataview
			// This clears the entire table of Bank data very well	   
			ClearGridView ( );
		}

		/*
	`			BankGridView.DataSource = null;
				BankGridView.Rows.Clear ( );
				info.Text = "All data cleared from the SQL Database Viewer...";


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
/*			try
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
*/		}

		}
}
