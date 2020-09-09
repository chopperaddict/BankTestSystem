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
	public partial class SQLDbSelector : Form
	{
		public string threadArg1;
		public SQLDbSelector ( )
		{
			InitializeComponent ( );
		}

		private void button2_Click (object sender, EventArgs e)
		{
			if ( radioButton1.Checked ) threadArg1 = "Customer";
			else if ( radioButton2.Checked ) threadArg1 = "BankAccount";
			else if ( radioButton3.Checked ) threadArg1 = "SecondaryCustAccounts";
			Close ( );
		}

		private void button1_Click (object sender, EventArgs e)
		{
			threadArg1 = "";
			Close();
		}
	}
}
