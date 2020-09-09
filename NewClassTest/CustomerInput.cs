using System;
using System.Windows.Forms; // required for Dictionaries/Hastables

namespace ClassAccessTest
{
	// This is the customer data entry form
	public partial class CustomerInput : Form
	{
		public static bool dirty = false;
		readonly static decimal InterestRate = 3.75M;
		readonly static decimal InitBalance = 250.00M;

		public CustomerInput ( )
		{
			InitializeComponent ( );
			Interest.Text = InterestRate.ToString ( );
			AccountBalance.Text = InitBalance.ToString ( );
			OpenDate.Text = DateTime.Now.ToShortDateString ( );
			AccountType.SelectedIndex = 0;
			AccountNo.Text = Customer.GetCustomerNumberSeed ( ).ToString ( ); // let the system increment it
			dirty = true;   // set our flag so we can reduce seed if needed
		}

		// Save the new customer data as an Object and add it to the Customer List
		// plus create a BankAccount object and add it to the BankAccount List
		private void SaveCustButton_Click_1 (object sender, EventArgs e)
		{
			DateTime DOB;
			int type = 0;
			try
			{
				int test = Convert.ToInt16 (day.Text);
				test = Convert.ToInt16 (day.Text);
				test = Convert.ToInt16 (day.Text);
			}
			catch { new Exception ("Date of Birth entry data is invalid..." + day + "/" + month + "/" + year); }

			if ( AccountType.Text.Contains ("Normal") ) type = 1;
			if ( AccountType.Text.Contains ("Savings") ) type = 2;
			if ( AccountType.Text.Contains ("Deposit") ) type = 3;
			if ( AccountType.Text.Contains ("Business") ) type = 4;
			if ( day.Text == "" | month.Text == "" | year.Text == "" )
			{
				MessageBox.Show ("The DOB date you have entered is not valid... Please correct this", " New Customer entry System");
				return;
			}
			if ( Convert.ToInt16 (day.Text) < 0 | Convert.ToInt16 (day.Text) > 31 | Convert.ToInt16 (month.Text) < 0 | Convert.ToInt16 (month.Text) > 12
									| Convert.ToInt16 (year.Text) < 1920 | Convert.ToInt16 (year.Text) > DateTime.Now.Year )
			{ MessageBox.Show ("The DOB date you have entered is not valid... Please correct this", " New Customer entry System"); return; }
			string dob = day.Text + "/" + month.Text + "/" + year.Text;

			/// make sure our DOB data is sound, else we crqash everywhere
			try { DOB = Convert.ToDateTime (dob); }
			catch
			{ MessageBox.Show ("The DOB date you have entered is not valid... Please correct this", " New Customer entry System"); return; }
			if ( lname.Text == "" )
			{ MessageBox.Show ("You must enter a valid Last Name... Please correct this", " New Customer entry System"); return; }
			if ( town.Text == "" )
			{ MessageBox.Show ("You must enter a valid Town... Please correct this", " New Customer entry System"); return; }
			if ( county.Text == "" )
			{ MessageBox.Show ("You must enter a valid County... Please correct this", " New Customer entry System"); return; }
			if ( pcode.Text == "" )
			{ MessageBox.Show ("You must enter a valid PostCode... Please correct this", " New Customer entry System"); return; }
			//============================================================
			BankAccount Ba = new BankAccount ( );
			// this returns the Balance if we need it
			Ba = BankAccount.CreateNewBankAccount (Ba, AccountNo.Text, (Int16)type, Utils.stringToDecimal (AccountBalance.Text), Utils.stringToDecimal (Interest.Text));
			//========================CUSTOMER ACCOUNT================
			Customer cust = Customer.CreateNewCustomer (AccountNo.Text, fname.Text, lname.Text, tel.Text, mob.Text, addr1.Text, addr2.Text,
																						   town.Text, county.Text, pcode.Text, type, Ba.BankAccountNumber, DOB);

			Ba.Dispose ( );
			MessageBox.Show ("Customer account has been opened successfully...,", "New Customer account creation");
			dirty = false;
			this.Close ( );
		}

		//clear all data fields
		private void button1_Click (object sender, EventArgs e)
		{
			fname.Text = "";
			lname.Text = "";
			addr1.Text = "";
			addr2.Text = "";
			town.Text = "";
			county.Text = "";
			pcode.Text = "";
			tel.Text = "";
			mob.Text = "";
		}

		private void Exit_Click (object sender, EventArgs e)
		{
			if ( dirty )  // we must reset customer # seed as it has already been incremented
				Customer.SetCustomerNumberSeed (Convert.ToInt32 (AccountNo.Text) - 1);
			Close ( );
		}

		private void month_TextChanged (object sender, EventArgs e)
		{

		}

		private void CustomerInput_Load (object sender, EventArgs e)
		{

		}

		private void AccountType_SelectedIndexChanged (object sender, EventArgs e)
		{

		}

		private void checkBox4_CheckedChanged (object sender, EventArgs e)
		{

		}
		private void day_KeyDown (object sender, KeyEventArgs e)
		{
			if ( day.Text.Length == 2 )
			{
				try { Int16 test = Convert.ToInt16 (day.Text); }
				catch { MessageBox.Show ("The entry for the Day in DOB is invalid - Please correct this..."); }
			}
		}
		private void month_KeyDown (object sender, KeyEventArgs e)
		{
			if ( month.Text.Length == 2 )
			{
				try { Int16 test = Convert.ToInt16 (month.Text); }
				catch { MessageBox.Show ("The entry for the Month in DOB is invalid - Please correct this..."); }
			}
		}
		private void year_KeyDown (object sender, KeyEventArgs e)
		{
			if ( year.Text.Length == 4 )
			{
				try { Int16 test = Convert.ToInt16 (year.Text); }
				catch { MessageBox.Show ("The entry for the Year in DOB is invalid\nIt must be 4 digits - Please correct this..."); }
			}
		}
	}
}
