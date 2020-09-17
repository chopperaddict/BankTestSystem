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
		
		public SQLDbSelector ( )
		{
			InitializeComponent ( );
		}

		private void button2_Click (object sender, EventArgs e)
		{
			if ( radioButton1.Checked ) SqlConnector.threadArg1 = "Customer";
			else if ( radioButton2.Checked ) SqlConnector.threadArg1= "BankAccount";
			else if ( radioButton3.Checked ) SqlConnector.threadArg1 = "SecondaryCustAccounts";
			Close ( );
		}

		private void button1_Click (object sender, EventArgs e)
		{
			SqlConnector.threadArg1 = "";
			Close();
		}
	}
}
