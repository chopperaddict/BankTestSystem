using System;
using System.Drawing;
using System.Windows.Forms; // required for Dictionaries/Hastables

namespace ClassAccessTest
{
	// This is the customer data entry form
	public partial class CustomerEdit : Form
	{
		public static bool dirty = false;
		Customer Cust = null;
		BankAccount Bank = null;

		//*************************************************************************************************************//
		public CustomerEdit ( )
		//*************************************************************************************************************//
		{
			InitializeComponent ( );
			Cust = new Customer ( );
			Bank = new BankAccount ( );
			act1.ReadOnly = false;
			act2.ReadOnly = false;
			act3.ReadOnly = false;
			act4.ReadOnly = false;
			AccountNo.Focus ( );
		}

		//*************************************************************************************************************//
		private void findcustomer_Click_1 (object sender, EventArgs e)
		//*************************************************************************************************************//
		{
			string accno = AccountNo.Text;
			accountnums.Items.Clear ( );
			Cust = Customer.GetCustomerAccount (accno);
			if ( Cust == null )
			{ MessageBox.Show ("Unable to find the Customer Record from LinkedList", "Database system ERROR"); return; }
			else
			{
				act1.Enabled = false; act2.Enabled = false; act3.Enabled = false; act4.Enabled = false;
				fname.Text = Cust.FirstName;
				lname.Text = Cust.LastName;
				day.Text = Cust.DOB.Day.ToString ( );
				month.Text = Cust.DOB.Month.ToString ( );
				year.Text = Cust.DOB.Year.ToString ( );
				addr1.Text = Cust.Address1;
				addr2.Text = Cust.Address2;
				town.Text = Cust.Town;
				county.Text = Cust.County;
				pcode.Text = Cust.PostCode;
				tel.Text = Cust.PhoneNumber;
				mob.Text = Cust.MobileNumber;
				addr1.Text = Cust.Address1;
				addr1.Text = Cust.Address1;
				Info.Text = "Click <SAVE> to PERMANENTLY update this customer Account";
				// now get Bank Account

				if ( Cust.CustomerNumber.ToString ( ) == AccountNo.Text )
				{
					string curraccount = AccountNo.Text;
					// set them all back to standard
					SaveCustButton.Enabled = true;
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
					tel.Text = Cust.PhoneNumber; ;
					mob.Text = Cust.MobileNumber;
					// first we need to grab a customer account to get the bank a/c file number from

					// get the bank account for this customer*
					//open the BankAccount
					Bank = Search.FindBankObjectfromBankNo (Cust.accountnums[0].ToString ( ));
					// display th edreaded additional account info correctly
					string[] actype = { "Normal", "Savings", "Depost", "Business" };

					accountnums.Items.Add (Cust.accountnums[0].ToString ( ) + "\t" + actype[Cust.accounttypes[0] - 1]);
					ac1.Text = Cust.accountnums[0].ToString ( ); act1.Text = Cust.accounttypes[0].ToString ( ); act1.Enabled = true;
					if ( Cust.accountnums[1] > 0 )
					{
						accountnums.Items.Add (Cust.accountnums[1].ToString ( ) + "\t" + actype[Cust.accounttypes[1] - 1]);
						ac2.Text = Cust.accountnums[1].ToString ( ); act2.Text = Cust.accounttypes[1].ToString ( ); act2.Enabled = true;
					}
					else
					{ accountnums.Items.Add ("   ------   "); ac2.Text = "   ------   "; act2.Text = "------"; }
					if ( Cust.accountnums[2] > 0 )
					{
						accountnums.Items.Add (Cust.accountnums[2].ToString ( ) + "\t" + actype[Cust.accounttypes[2] - 1]);
						ac3.Text = Cust.accountnums[2].ToString ( ); act3.Text = Cust.accounttypes[2].ToString ( ); act3.Enabled = true;
					}
					else
					{ accountnums.Items.Add ("   ------   "); ac3.Text = "   ------   "; act3.Text = "------"; }
					if ( Cust.accountnums[3] > 0 )
					{
						accountnums.Items.Add (Cust.accountnums[3].ToString ( ) + "\t" + actype[Cust.accounttypes[3] - 1]);
						ac4.Text = Cust.accountnums[3].ToString ( ); act4.Text = Cust.accounttypes[3].ToString ( ); act4.Enabled = true;
					}
					else
					{ accountnums.Items.Add ("   ------   "); ac4.Text = "   ------   "; act4.Text = "------"; }

					accountnums.SelectedIndex = 0;
					//AccountBalance. Text = Bank. Balance. ToString ( );
					AccountBalance.Text = Utils.GetFieldCurrencyString (Bank.Balance.ToString ( ));

					//Interest. Text = Utils.GetCurrencyString(Bank. InterestRate. ToString ( ));
					Interest.Text = Utils.GetFieldCurrencyString (Bank.InterestRate.ToString ( ));
					OpenDate.Text = Bank.DateOpened.ToShortDateString ( );
					// now sort out the multiple accounts problem
					// got the matching account
					Info.Text = "Click the <UPDATE> button to save your changes";
					dirty = false;
				}
			}
		}
		// Save the new customer data as an Object and add it to the Customer List
		// plus create a BankAccount object and add it to the BankAccount List
		//*************************************************************************************************************//
		private void SaveCustButton_Click (object sender, EventArgs e)
		//*************************************************************************************************************//
		{
			if ( !dirty )
			{
				MessageBox.Show ("No changes appear to have been made ?... \nPlease make any changes needed, and then try again" +
					"", " FULL Customer EDIT entry System");
				return;
			}
			try
			{
				int test = Convert.ToInt16 (day.Text);
				test = Convert.ToInt16 (month.Text);
				test = Convert.ToInt16 (year.Text);
			}
			catch { new Exception ("Date of Birth entry data is invalid..." + day + "/" + month + "/" + year); }
			/*
						if ( AccountType. Text. Contains ( "Normal" ) ) type = 1;
						if ( AccountType. Text. Contains ( "Savings" ) ) type = 2;
						if ( AccountType. Text. Contains ( "Deposit" ) ) type = 3;
						if ( AccountType. Text. Contains ( "Business" ) ) type = 4;
			*/
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
			try { DateTime DOB = Convert.ToDateTime (dob); }
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

			if ( !dirty )
			{
				MessageBox.Show ("No changes appear to have been made, so saving it is not required", "Data Validation Warning ");
				return;
			}
			if ( Cust != null )
			{
				// first grab the ArrayList entry index using original data
				int index = DataArray.ArrayFindCust (Cust);
				if ( index == -1 )
				{
					MessageBox.Show ("This Customer account details cannot be found in ArrayList...,", "Customer FULL Edit facility");
					return;
				}
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
				// update  Now we can actually the ArrayList
				DataArray.CustNo.RemoveAt (index);
				DataArray.ArrayAddCust (Cust);
				/*
                            // already updated previously
                                // update Customer  LinkedList
                                foreach ( var L in Customer . CustomersLinkedList )
                                {
                                    if ( L . CustomerNumber == Convert . ToInt32 ( AccountNo . Text ) )
                                    {   // got it
                                        if ( Customer . CustomersLinkedList . Contains ( L ) )
                                        {
                                            Customer . CustomersLinkedList . Remove ( L );
                                            Customer . CustomersLinkedList . AddLast ( Cust );
                                        }
                                        break;
                                    }
                                }
                */
				// get the bank account for this customer
				// and update the relevant fields
				string s = accountnums.SelectedItem.ToString ( );
				char[] c = { '\t' };
				string[] opts = s.Split (c);
				Bank = Search.FindBankObjectfromBankNo (opts[0]);
				// Find the original Bank object in ArrayList
				int indx = DataArray.ArrayFindBank (Bank);
				if ( indx == -1 )
				{
					MessageBox.Show ("This Bank  account details cannot be found in ArrayList...,", "Customer FULL Edit facility");
					return;
				}
				try
				{
					DataArray.BankNo.RemoveAt (indx);
					// I do this in case the value is formatted eg : 1,235.76 !!  which definitely does not compuute easily !!
					Bank.Balance = Convert.ToDecimal (Convert.ToDecimal (AccountBalance.Text).ToString ( ));
					Bank.InterestRate = Convert.ToDecimal (Interest.Text);
					// save the changes to our bank account
					SerializeData.WriteBankAccountToDiskAndText (Bank, Bank.FullFileName);
				}
				catch
				{
					MessageBox.Show ("This Bank  account details cannot be updated , Data system is NOW inconsistent !...,", "Customer FULL Edit facility");
					return;
				}
				// Now we can update ArrayList safely
				if ( indx != -1 )
					DataArray.ArrayAddBank (Bank);
				// Write a transaction record too....
				BankTransaction newbankaccount = new BankTransaction ( );
				newbankaccount.TransDate = DateTime.Now;
				newbankaccount.AccountType = Bank.AccountType;
				newbankaccount.CustAccountNumber = Bank.CustAccountNumber;
				newbankaccount.BankAccountNumber = Bank.BankAccountNumber;
				newbankaccount.Transamount = Bank.Balance;
				newbankaccount.Notes = "Opening Balance";
				newbankaccount.Status = Bank.Status;
				BankTransaction.allBankTransactions.AddLast (newbankaccount);

				//our TWO hash tables do not hold any data that can be changed

				// update the interest  in BankAccount LinkedList in case it hs been chnaged
				foreach ( var BL in BankAccount.BankAccountsLinkedList )
				{
					if ( BL.CustAccountNumber == Convert.ToInt32 (AccountNo.Text) )
					{
						BL.InterestRate = Convert.ToDecimal (Interest.Text);        // this is the ONLY thing we can update in a bank account
						break;
					}
				}
				dirty = false;
			}
			MessageBox.Show ("This Customer account details have been updated successfully...,", "Customer FULL Edit facility");
		}

		//clear all data fields
		//*************************************************************************************************************//
		private void button1_Click_1 (object sender, EventArgs e)
		//*************************************************************************************************************//
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
			AccountBalance.Text = "";
			Interest.Text = "";
			OpenDate.Text = "";
			ac1.Text = "";
			ac2.Text = "";
			ac3.Text = "";
			ac4.Text = "";
			accountnums.Items.Clear ( );
			dirty = true;
		}

		//*************************************************************************************************************//
		private void Exit_Click_1 (object sender, EventArgs e)


		//*************************************************************************************************************//
		{
			//	if ( dirty )    // we must reset customer # seed as it has already been incremented
			//	Customer . SetCustomerNumberSeed ( Convert . ToInt32 ( AccountNo . Text ) - 1 );
			Bank.Dispose ( );
			Cust.Dispose ( );
			Close ( );
		}

		//*************************************************************************************************************//
		private void day_KeyDown (object sender, KeyEventArgs e)
		//*************************************************************************************************************//
		{
			if ( day.Text.Length == 2 )
			{
				try { Int16 test = Convert.ToInt16 (day.Text); }
				catch { MessageBox.Show ("The entry for the Day in DOB is invalid - Please correct this..."); }
			}
		}
		//*************************************************************************************************************//
		private void month_KeyDown (object sender, KeyEventArgs e)
		//*************************************************************************************************************//
		{
			if ( month.Text.Length == 2 )
			{
				try { Int16 test = Convert.ToInt16 (month.Text); }
				catch { MessageBox.Show ("The entry for the Month in DOB is invalid - Please correct this..."); }
			}
		}
		//*************************************************************************************************************//
		private void year_KeyDown (object sender, KeyEventArgs e)
		//*************************************************************************************************************//
		{
			if ( year.Text.Length == 4 )
			{
				try { Int16 test = Convert.ToInt16 (year.Text); }
				catch { MessageBox.Show ("The entry for the Year in DOB is invalid\nIt must be 4 digits - Please correct this..."); }
			}
		}

		private void AccountBalance_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

		private void Interest_TextChanged (object sender, EventArgs e)
		{ dirty = true; }

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

		private void accountnums_SelectedIndexChanged (object sender, EventArgs e)
		{
			// user has selected a different Bank account
			// so fill out the details
			//open the BankAccount
			string acrequired = accountnums.SelectedItem.ToString ( );
			char c = '\t';
			string[] temp = acrequired.Split (c);
			if ( temp[0] == "   ------   " )
			{
				MessageBox.Show ("The entry \"   ------ \" from the list you have selected is invalid- Please select a valid entry...");
				return;
			}

			Bank = Search.FindBankObjectfromBankNo (temp[0]);
			AccountBalance.Text = Utils.GetFieldCurrencyString (Bank.Balance.ToString ( ));

			//Interest. Text = Utils.GetCurrencyString(Bank. InterestRate. ToString ( ));
			Interest.Text = Utils.GetFieldCurrencyString (Bank.InterestRate.ToString ( ));
			OpenDate.Text = Bank.DateOpened.ToShortDateString ( );
			act1.ForeColor = Color.Black;
			act2.ForeColor = Color.Black;
			act3.ForeColor = Color.Black;
			act4.ForeColor = Color.Black;
			if ( Bank.AccountType == 1 )
				act1.ForeColor = Color.Red;
			if ( Bank.AccountType == 2 )
				act2.ForeColor = Color.Red;
			if ( Bank.AccountType == 3 )
				act3.ForeColor = Color.Red;
			if ( Bank.AccountType == 4 )
				act4.ForeColor = Color.Red;
		}
		private void saveBank_Click (object sender, EventArgs e)
		{
			Bank.Balance = Convert.ToDecimal (AccountBalance.Text);
			Bank.InterestRate = Convert.ToDecimal (Interest.Text);
			SerializeData.WriteBankAccountToDiskAndText (Bank, Bank.FullFileName);
			// update array data
			BankAccount B = DataArray.ArrayGetBank (Bank.BankAccountNumber);
			B.Balance = Bank.Balance;
			B.InterestRate = Bank.InterestRate;
			// update LinkedList
			foreach ( BankAccount Bk in BankAccount.BankAccountsLinkedList )
			{
				if ( Bk.BankAccountNumber == Bank.BankAccountNumber )
				{
					Bk.Balance = Bank.Balance;
					Bk.InterestRate = Bank.InterestRate;
					break;
				}
			}
			MessageBox.Show ("Bank Account [" + Bank.BankAccountNumber.ToString ( ) + "] has been updated successfully..", "Data Maintenance");
			string msg = "Bank Account [" + Bank.BankAccountNumber.ToString ( ) + " has been updated successfully...\r\n";
			//			Bank.form1. ShowText ( msg, null, -1 );//the method defined in Bank
		}

		private void AccountNo_Leave (object sender, EventArgs e)
		{
			findcustomer_Click_1 (sender, e);
		}

		private void label9_Click (object sender, EventArgs e)
		{

		}
	}
}
