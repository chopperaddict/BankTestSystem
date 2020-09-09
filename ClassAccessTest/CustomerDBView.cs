using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class CustDataView : Form
	{
		public CustDataView ( )
		{
			InitializeComponent ( );
		}

		private void Form1_Load (object sender, EventArgs e)
		{
			Show();
			info.Text = "Please wait, loading all Customer's data from SQL Database...";
			CustGridView.DataSource = customerBindingSource;

			// TODO: This line of code loads data into the 'ian1DataSet.Customer' table. You can move, or remove it, as needed.
			customerTableAdapter.Fill (ian1DataSet.Customer);
			info.Text = "ALL Customer Accounts have been loaded from SQL Database ...";
		}

		private void SaveButton_Click (object sender, EventArgs e)
		{
			// save data to a different format ???
		}

		private void exit_Click (object sender, EventArgs e)
		{
			Close ( );
		}

		private void ClearGridView ( )
			//==============================================================================
		{
			if ( this.InvokeRequired ) _ = this.Invoke (new Action (this.ClearGridView));
			{
				CustGridView.DataSource = null;
				CustGridView.Rows.Clear ( );
				CustGridView.Refresh ( );
				// Reset the data bindings for the gridview
			}
		}

		private void ClearButton_Click (object sender, EventArgs e)
		{
			info.Text = "Customer Accounts are being removed from SQL Viewer - NOT from  the Database itself !...";
			ClearGridView ( );
//			customerTableAdapter.ClearBeforeFill = true;
//			customerTableAdapter.Fill (ian1DataSet.Customer);
			info.Text = "ALL Customer Accounts have been cleared from SQL Viewer...";
		}

		private void reload_Click (object sender, EventArgs e)
		{
			info.Text = "Customer Accounts are being reloaded from SQL Database ...";
			CustGridView.DataSource = this.customerBindingSource;
			customerTableAdapter.Fill (ian1DataSet.Customer);
			info.Text = "ALL Customer Accounts have been loaded from SQL Database ...";
		}
	}
}
