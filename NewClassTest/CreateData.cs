using System;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class CreateData : Form
	{
		public int ReturnValue = 0;
		public int ReturnValue2 = 0;
		public int ReturnValue3 = 0;
		public CreateData ( )
		{
			InitializeComponent ( );
		}

		private void CreateData_Load (object sender, EventArgs e)
		{

			int type = Bank.GetExportType ( );
			// make the default sort comma delimited
			checkBox1.Checked = true;
			outputtype.Text = type.ToString ( );
		}
		private void Cancel_Click (object sender, EventArgs e)
		{ Close ( ); }

		private void Go_Click (object sender, EventArgs e)
		{
			if ( Total.Text == "" )
			{
				MessageBox.Show ("You gotta enter the number of entries you want !", "Dumbo !!!!!");
				return;
			}
			ReturnValue = Convert.ToInt16 (Total.Text);
			if ( checkBox1.Checked )
				ReturnValue2 = 0;
			else if ( checkBox2.Checked )
				ReturnValue2 = 1;
			else if ( checkBox3.Checked )
				ReturnValue2 = 2;
			else if ( checkBox4.Checked )
				ReturnValue2 = 3;
			ReturnValue3 = Convert.ToInt16 (outputtype.Text);
			Close ( );
		}

		private void checkBox1_CheckedChanged (object sender, EventArgs e)
		{
			if ( checkBox1.Checked )
			{
				checkBox2.Checked = false;
				checkBox3.Checked = false;
				checkBox4.Checked = false;
			}
		}
		private void checkBox2_CheckedChanged_1 (object sender, EventArgs e)
		{
			if ( checkBox2.Checked )
			{
				checkBox1.Checked = false;
				checkBox3.Checked = false;
				checkBox4.Checked = false;
			}
		}
		private void checkBox3_CheckedChanged (object sender, EventArgs e)
		{
			if ( checkBox3.Checked )
			{
				checkBox2.Checked = false;
				checkBox1.Checked = false;
				checkBox4.Checked = false;
			}
		}
		private void checkBox4_CheckedChanged_1 (object sender, EventArgs e)
		{
			if ( checkBox4.Checked )
			{
				checkBox2.Checked = false;
				checkBox3.Checked = false;
				checkBox1.Checked = false;
			}
		}

	}
}
