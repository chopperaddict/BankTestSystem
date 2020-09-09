
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassAccessTest
{

	public partial class UpdateCustomer : Form
	{
		public static Customer Cust = new Customer ( );
		public static BankAccount B = new BankAccount ( );
		public static string accno = "";
		public static int indx = 0;
		public static int btindex = 0;
		public int currentselection;
		public bool dirty = false;
		public UpdateCustomer ( )
		{       // Constructor
			InitializeComponent ( );
			accountno.AcceptsReturn = true;
			dirty = false;
			accountno.Focus ( );
		}

		//        public accounts[] accts = new accts();
		//*************************************************************************************************************************************************//
		private void findCust_Click_1 (object sender, EventArgs e)
		//*************************************************************************************************************************************************//
		{           // Find the customer record

			if ( accno != accountno.Text )
				accno = accountno.Text; ;
			if ( accno == "" )
				return;
			Cust = Search.FindCustInSortedList (Convert.ToInt32 (accno));
			//Cust = Customer . GetCustomerAccount ( accno );
			if ( Cust == null )
			{
				MessageBox.Show ("Unable to find the Customer Record from LinkedList", "Database system ERROR");
				clear_Click_1 (sender, e);         // Clear the data form the screen
				return;
			}
			else
			{
				if ( Cust.CustomerNumber.ToString ( ) == accountno.Text )
				{
					string curraccount = accountno.Text;
					// set them all back to standard
					//					actype1.Text= ""; actype2.Text = ""; actype3.Text = ""; actype4.Text = "";
					actype1.Enabled = false; actype2.Enabled = false; actype3.Enabled = false; actype4.Enabled = false;
					actype1.ForeColor = Color.Black; actype2.ForeColor = Color.Black; actype3.ForeColor = Color.Black; actype4.ForeColor = Color.Black;
					actype1.BackColor = Color.Gray; actype2.BackColor = Color.Gray; actype3.BackColor = Color.Gray; actype4.BackColor = Color.Gray;
					checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
					checkBox1.Enabled = false; checkBox2.Enabled = false; checkBox3.Enabled = false; checkBox4.Enabled = false;
					checkBox2.ForeColor = Color.Red;
					checkBox1.ForeColor = Color.Black; checkBox2.ForeColor = Color.Black; checkBox3.ForeColor = Color.Black; checkBox4.ForeColor = Color.Black;

					textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
					textBox1.Enabled = false; textBox2.Enabled = false; textBox3.Enabled = false; textBox4.Enabled = false;

					SaveCustButton.Enabled = true;
					clear.Enabled = true;
					Exit.Enabled = true;
					fname.Text = Cust.FirstName;
					lname.Text = Cust.LastName;
					day.Text = Cust.DOB.Day.ToString ( );
					month.Text = Cust.DOB.Month.ToString ( );
					year.Text = Cust.DOB.Year.ToString ( );
					addr1.Text = Cust.Address1;
					addr1.Text = Cust.Address1;
					addr2.Text = Cust.Address2;
					town.Text = Cust.Town;
					county.Text = Cust.County;
					pcode.Text = Cust.PostCode;
					pcode.Text = Cust.PhoneNumber; ;
					mob.Text = Cust.MobileNumber;
					// first we need to grab a customer account to get the bank a/c file number from

					// get the bank account for this customer*
					//open the BankAccount
					B = Search.FindBankObjectfromBankNo (Cust.accountnums[0].ToString ( ));
					AccountType.SelectedIndex = BankAccount.GetAccountType (B) - 1;
					AccountBalance.Text = B.Balance.ToString ( );
					Interest.Text = B.InterestRate.ToString ( );
					OpenDate.Text = B.DateOpened.ToShortDateString ( );
					// now sort out the multiple accounts problem
					// got the matching account
					currentselection = resetAccountIdentifiers (curraccount);
					info.Text = "Click the <UPDATE> button to save your changes";
				}
			}
			dirty = false;
		}
		//*************************************************************************************************************************************************//
		private int resetAccountIdentifiers (string curraccount)
		//*************************************************************************************************************************************************//
		{
			int counter = 0;
			int[] selected = { 0, 0, 0, 0 };
			int[] accnumber = { 0, 0, 0, 0 };

			for ( int x = 0; x < 4; x++ )
			{
				if ( Cust.accounttypes[x] > 0 )
				{
					selected[counter] = Cust.accounttypes[x];
					accnumber[counter++] = Cust.accountnums[x];
				}
			}
			for ( int x = 0; x < counter; x++ )
			{
				if ( selected[x] != 0 )
				{
					SetupAccountTypeFields (Convert.ToInt16 (selected[x]), Convert.ToInt32 (accnumber[x]));
				}
			}
			for ( int x = 0; x < 4; x++ )
				// This sets the speficic a/c type button of the ACTIVE A/C to White on Red
				if ( Cust.accountnums[x] == Convert.ToInt32 (curraccount) )
				{   // Set the colors on  the main buttons at top right of window
					AccountType.SelectedIndex = Cust.accounttypes[x] - 1;
					if ( AccountType.SelectedIndex == 0 )
					{ actype1.ForeColor = Color.White; actype1.BackColor = Color.Red; actype1.Enabled = false; }
					else if ( AccountType.SelectedIndex == 1 )
					{ actype2.ForeColor = Color.White; actype2.BackColor = Color.Red; actype2.Enabled = false; }
					else if ( AccountType.SelectedIndex == 2 )
					{ actype3.ForeColor = Color.White; actype3.BackColor = Color.Red; actype3.Enabled = false; }
					else if ( AccountType.SelectedIndex == 3 )
					{ actype4.ForeColor = Color.White; actype4.BackColor = Color.Red; actype4.Enabled = false; }
					break;
				}
			return AccountType.SelectedIndex;
		}

		//*************************************************************************************************************************************************//
		private void SetupAccountTypeFields (Int16 index, Int32 accnum)
		//*************************************************************************************************************************************************//
		{
			if ( index - 1 == 0 )
			{   // Normal
				textBox1.Enabled = true;
				actype1.Enabled = true;
				checkBox1.Checked = true;
				checkBox1.ForeColor = Color.Red;
				textBox1.Text = accnum.ToString ( );
				textBox1.ForeColor = Color.Red;
				//checkBox1.ForeColor = Color.Red;
				actype1.ForeColor = Color.Red;
				actype1.BackColor = Color.LightGray;
			}
			else if ( index - 1 == 1 )
			{   // Savings
				textBox2.Enabled = true;
				actype2.Enabled = true;
				checkBox2.Checked = true;
				checkBox2.ForeColor = Color.Red;
				textBox2.Text = accnum.ToString ( );
				textBox2.ForeColor = Color.Red;
				//checkBox2.ForeColor = Color.Red;
				actype2.ForeColor = Color.Red;
				actype2.BackColor = Color.LightGray;
			}
			else if ( index - 1 == 2 )
			{   // Deposit
				textBox3.Enabled = true;
				actype3.Enabled = true;
				checkBox3.Checked = true;
				checkBox3.ForeColor = Color.Red;
				textBox3.Text = accnum.ToString ( );
				textBox3.ForeColor = Color.Red;
				//checkBox3.ForeColor = Color.Red;
				actype3.ForeColor = Color.Red;
				actype3.BackColor = Color.LightGray;
			}
			else if ( index - 1 == 3 )
			{   // Business
				textBox4.Enabled = true;
				actype4.Enabled = true;
				checkBox4.Checked = true;
				checkBox4.ForeColor = Color.Red;
				textBox4.Text = accnum.ToString ( );
				textBox4.ForeColor = Color.Red;
				//checkBox4.ForeColor = Color.Red;
				actype4.ForeColor = Color.Red;
				actype4.BackColor = Color.LightGray;
			}
		}
		public bool VerifyData ( )
		{
			int count = 0;
			if ( fname.Text == "" ) count++;
			if ( lname.Text == "" ) count++;
			if ( addr1.Text == "" ) count++;
			if ( town.Text == "" ) count++;
			if ( county.Text == "" ) count++;
			if ( pcode.Text == "" ) count++; ;
			if ( mob.Text == "" ) count++;
			if ( AccountBalance.Text == "" ) count++;
			if ( Interest.Text == "" ) count++;
			if ( OpenDate.Text == "" ) count++;
			if ( day.Text == "" ) count++;
			if ( month.Text == "" ) count++;
			if ( year.Text == "" ) count++;

			if ( count > 5 )
				return false;
			else
				return true;
		}
		//*************************************************************************************************************************************************//
		private void SaveCustButton_Click (object sender, EventArgs e)
		//*************************************************************************************************************************************************//
		{       // update the details
			if ( !dirty )
			{
				MessageBox.Show ("No changes appear to have been made, so saving it is not required", "Data Validation Warning ");
				return;
			}
			if ( !VerifyData ( ) )
			{
				MessageBox.Show ("Various important data items appear to be empty. Please complete the necessary fields", "Data Validation Warning ");
				return;
			}
			if ( Cust != null )
			{
				// go ahead and update the object
				Cust.FirstName = fname.Text;
				Cust.LastName = lname.Text;
				Cust.Address1 = addr1.Text;
				Cust.Address2 = addr2.Text;
				Cust.Town = town.Text;
				Cust.County = county.Text;
				Cust.PostCode = pcode.Text;
				Cust.PhoneNumber = tel.Text;
				Cust.MobileNumber = mob.Text;
				// Update Customer Object on disk
				Customer.WriteCustObjectToDiskAndText (Cust, Cust.FullFileName);

				// update Customer  LinkedList
				foreach ( var L in Customer.CustomersLinkedList )
				{
					if ( L.CustomerNumber == Convert.ToInt32 (accountno.Text) )
					{   // got it
						L.FirstName = Cust.FirstName;
						L.LastName = Cust.LastName;
						L.Address1 = Cust.Address1;
						L.Address2 = Cust.Address2;
						L.Town = Cust.Town;
						L.County = Cust.County;
						L.PostCode = Cust.PostCode;
						L.PhoneNumber = Cust.PhoneNumber;
						L.MobileNumber = Cust.MobileNumber;
						break;
					}
				}
				// get the bank account for this customer
				// and update the relevant fields
				B = Search.FindBankObjectfromBankNo (accountno.Text);
				B.Balance = Convert.ToDecimal (AccountBalance.Text);
				B.InterestRate = Convert.ToDecimal (Interest.Text);
				// save the changes to our bank account
				SerializeData.WriteBankAccountToDiskAndText (B, B.FullFileName);
				// Write a transaction record too....
				BankTransaction newbankaccount = new BankTransaction ( );
				newbankaccount.TransDate = DateTime.Now;
				newbankaccount.AccountType = B.AccountType;
				newbankaccount.CustAccountNumber = B.CustAccountNumber;
				newbankaccount.BankAccountNumber = B.BankAccountNumber;
				newbankaccount.Transamount = B.Balance;
				newbankaccount.Notes = "Opening Balance";
				newbankaccount.Status = B.Status;
				BankTransaction.allBankTransactions.AddLast (newbankaccount);

				//our TWO hash tables do not hold any data that can be changed

				// update the interest  in List in case it hs been chnaged
				foreach ( var BL in BankAccount.BankAccountsLinkedList )
				{
					if ( BL.CustAccountNumber == Convert.ToInt32 (accountno.Text) )
					{
						BL.InterestRate = Convert.ToDecimal (Interest.Text);        // this is the ONLY thing we can update in a bank account
						break;
					}
				}
				MessageBox.Show ("The Customer details have been fully updated...", "Customer Update System");
				// tidy up after ourselves
//				Cust.Dispose ( );
			}
			dirty = false;
			//this.Close();	// do not close it on saving
		}
		//*************************************************************************************************************************************************//
		public static BankAccount FindBank (Int32 accountnum)
		//*************************************************************************************************************************************************//
		{
			foreach ( BankAccount Bk in DataArray.BankNo )
			{
				if ( Bk.BankAccountNumber == accountnum )
				{
					B = Bk; // set the form wide bankaccount to the one found
					return Bk;
				}
			}
			return null;
		}

		private void EnableSelectionButtons (int currsel)
		{
			actype1.Enabled = false;
			actype2.Enabled = false;
			actype3.Enabled = false;
			actype4.Enabled = false;
			for ( int x = 0; x < 4; x++ )
			{
				if ( Cust.accounttypes[x] != 0 )
				{
					if ( Cust.accounttypes[x] == 1 )
						actype1.Enabled = true;
					if ( Cust.accounttypes[x] == 2 )
						actype2.Enabled = true;
					if ( Cust.accounttypes[x] == 3 )
						actype3.Enabled = true;
					if ( Cust.accounttypes[x] == 4 )
						actype4.Enabled = true;
				}
			}
			// disable the button that was pushed
			if ( currsel == 1 )
				actype1.Enabled = false;
			else if ( currsel == 2 )
				actype2.Enabled = false;
			else if ( currsel == 3 )
				actype3.Enabled = false;
			else if ( currsel == 4 )
				actype4.Enabled = false;
		}

		//*************************************************************************************************************************************************//
		private void actype1_Click (object sender, EventArgs e)
		//*************************************************************************************************************************************************//
		{    // button 1 clicked - Normal // but we still gotta find it in our Cust arrays
			int currsel = 0;
			currsel = Convert.ToInt32 (textBox1.Text);
			// call the Find click event directly
			BankAccount Bank = FindBank (currsel);
			if ( B != Bank )
			{ MessageBox.Show ("ERROR ENCOUNTERED - Bank account found does not match ", "Data Processing Error"); }
			else
			{
				AccountType.SelectedIndex = 0;
				OpenDate.Text = Bank.DateOpened.ToShortDateString ( );
				AccountBalance.Text = Bank.Balance.ToString ( );
				Interest.Text = Bank.InterestRate.ToString ( );
				// Enabled the other buttons as relevant
				EnableSelectionButtons (1);
				this.Text = "Customer A/C Update facility (Normal)";
			}
		}

		//*************************************************************************************************************************************************//
		private void actype2_Click (object sender, EventArgs e)
		//*************************************************************************************************************************************************//
		{    // button 2 clicked - Savings// but we still gotta find it in our Cust arrays
			int currsel = 0;
			currsel = Convert.ToInt32 (textBox2.Text);
			BankAccount Bank = FindBank (currsel);
			if ( B != Bank )
			{ MessageBox.Show ("ERROR ENCOUNTERED - Bank account found does not match ", "Data Processing Error"); }
			else
			{
				AccountType.SelectedIndex = 1;
				OpenDate.Text = Bank.DateOpened.ToShortDateString ( );
				AccountBalance.Text = Bank.Balance.ToString ( );
				Interest.Text = Bank.InterestRate.ToString ( );
				// Enabled the other buttons as relevant
				EnableSelectionButtons (2);
				this.Text = "Customer A/C Update facility (Savings)";
			}
		}

		//*************************************************************************************************************************************************//
		private void actype3_Click (object sender, EventArgs e)
		//*************************************************************************************************************************************************//
		{    // button 3 clicked - Deposit // but we still gotta find it in our Cust arrays
			int currsel = 0;
			currsel = Convert.ToInt32 (textBox3.Text);
			// call the Find click event directly
			BankAccount Bank = FindBank (currsel);
			if ( B != Bank )
			{ MessageBox.Show ("ERROR ENCOUNTERED - Bank account found does not match ", "Data Processing Error"); }
			else
			{
				AccountType.SelectedIndex = 2;
				OpenDate.Text = Bank.DateOpened.ToShortDateString ( );
				AccountBalance.Text = Bank.Balance.ToString ( );
				Interest.Text = Bank.InterestRate.ToString ( );
				// Enabled the other buttons as relevant
				EnableSelectionButtons (3);
				this.Text = "Customer A/C Update facility (Deposit)";
			}
		}

		//*************************************************************************************************************************************************//
		private void actype4_Click (object sender, EventArgs e)
		//*************************************************************************************************************************************************//
		{// button 1 clicked - Business// but we still gotta find it in our Cust arrays
			int currsel = 0;
			currsel = Convert.ToInt32 (textBox4.Text);
			// call the Find click event directly
			BankAccount Bank = FindBank (currsel);
			if ( B != Bank )
			{ MessageBox.Show ("ERROR ENCOUNTERED - Bank account found does not match ", "Data Processing Error"); }
			else
			{
				AccountType.SelectedIndex = 3;
				OpenDate.Text = Bank.DateOpened.ToShortDateString ( );
				AccountBalance.Text = Bank.Balance.ToString ( );
				Interest.Text = Bank.InterestRate.ToString ( );
				// Enabled the other buttons as relevant
				EnableSelectionButtons (4);
				this.Text = "Customer A/C Update facility (Business)";
			}
		}
		//*************************************************************************************************************************************************//
		private void Exit_Click_2 (object sender, EventArgs e)
		//*************************************************************************************************************************************************//
		{
//			if ( Cust != null )
	//			Cust.Dispose ( );
		//	if ( B != null )
			//	B.Dispose ( );
			Close ( );

		}

		//*************************************************************************************************************************************************//
		private void clear_Click_1 (object sender, EventArgs e)
		//*************************************************************************************************************************************************//
		{   // clear all fields
			fname.Text = "";
			lname.Text = "";
			addr1.Text = "";
			addr2.Text = "";
			town.Text = "";
			county.Text = "";
			pcode.Text = "";
			mob.Text = "";
			AccountBalance.Text = "";
			Interest.Text = "";
			OpenDate.Text = "";
			day.Text = "";
			month.Text = "";
			year.Text = "";
			AccountType.SelectedIndex = 4;            // an empty entry I have added for just this purpose
			textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
			checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
			actype1.ForeColor = Color.Black; actype2.ForeColor = Color.DimGray; actype3.ForeColor = Color.Black; actype4.ForeColor = Color.Black;
		}

		//*************************************************************************************************************************************************//

		private void fname_Enter (object sender, EventArgs e) { fname.SelectAll ( ); }
		private void lname_Enter (object sender, EventArgs e) { lname.SelectAll ( ); }
		private void day_Enter (object sender, EventArgs e) { day.SelectAll ( ); }
		private void month_Enter (object sender, EventArgs e) { month.SelectAll ( ); }
		private void year_Enter (object sender, EventArgs e) { year.SelectAll ( ); }
		private void addr1_Enter (object sender, EventArgs e) { addr1.SelectAll ( ); }
		private void addr2_Enter (object sender, EventArgs e) { addr2.SelectAll ( ); }
		private void town_Enter (object sender, EventArgs e) { town.SelectAll ( ); }
		private void county_Enter (object sender, EventArgs e) { county.SelectAll ( ); }
		private void pcode_Enter (object sender, EventArgs e) { pcode.SelectAll ( ); }
		private void tel_Enter (object sender, EventArgs e) { tel.SelectAll ( ); }
		private void mob_Enter (object sender, EventArgs e) { mob.SelectAll ( ); }
		private void Interest_Enter (object sender, EventArgs e) { Interest.SelectAll ( ); }
		private void reason_Enter (object sender, EventArgs e) { Interest.SelectAll ( ); }
		private void OpenDate_TextChanged (object sender, EventArgs e) { }
		private void reason_TextChanged (object sender, EventArgs e) { }
		private void fname_Leave (object sender, EventArgs e) { fname.SelectionLength = 0; }
		private void reason_Leave (object sender, EventArgs e) { fname.SelectionLength = 0; }
		private void lname_Leave (object sender, EventArgs e) { lname.SelectionLength = 0; }
		private void day_Leave (object sender, EventArgs e) { day.SelectionLength = 0; }
		private void month_Leave (object sender, EventArgs e) { month.SelectionLength = 0; }
		private void year_Leave (object sender, EventArgs e) { year.SelectionLength = 0; }
		private void addr1_Leave (object sender, EventArgs e) { addr1.SelectionLength = 0; }
		private void addr2_Leave (object sender, EventArgs e) { addr2.SelectionLength = 0; }
		private void town_Leave (object sender, EventArgs e) { town.SelectionLength = 0; }
		private void county_Leave (object sender, EventArgs e) { county.SelectionLength = 0; }
		private void pcode_Leave (object sender, EventArgs e) { pcode.SelectionLength = 0; }
		private void mob_Leave (object sender, EventArgs e) { mob.SelectionLength = 0; }
		private void Interest_KeyDown (object sender, KeyEventArgs e) { }
		private void accountno_TextChanged (object sender, EventArgs e) { }

		//*************************************************************************************************************************************************//
		private void day_KeyPress (object sender, KeyPressEventArgs e)
		//*************************************************************************************************************************************************//
		{
			try
			{
				Int16 test = Convert.ToInt16 (day.Text);
			}
			catch
			{
				MessageBox.Show ("The entry for the Day in DOB is invlaid - Please correct this...");
			}
		}

		private void fname_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void lname_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void day_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void month_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void year_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void addr1_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void addr2_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void town_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void county_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void pcode_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void tel_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void mob_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void AccountBalance_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void Interest_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void textBox2_TextChanged (object sender, EventArgs e)
		{

		}

		private void UpdateCustomer_Load (object sender, EventArgs e)
		{

		}
	}
}
