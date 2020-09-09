using System;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class SecondaryBnkAcct : Form
	{
		public static Int16[] atype = { 0, 0, 0, 0 };
		public static Customer Cust = new Customer ( );
		public static BankAccount Bank = new BankAccount ( );
		public Int32 accno = 0;
		public bool startup = true;
		public int IsCurrent = -1;
		public SecondaryBnkAcct ( )
		{
			InitializeComponent ( );
			accountno.AcceptsReturn = true;
			accountno.Focus ( );
		}

		private void Exit_Click_1 (object sender, EventArgs e)
		{ this.Close ( ); }

		// Find the customer record
		//****************************************************************************************************************
		private void Find_Click_1 (object sender, EventArgs e)
		//****************************************************************************************************************
		{   // load  the data
			string accno = accountno.Text;
			if ( accno == "" )
				return;
			// load the correct customer object
			//  probably get it from Custlist much more easily ?
			Cust = Customer.GetCustomerAccount (accno);
			if ( Cust == null )
			{
				MessageBox.Show ("Unable to find the Customer Record from LinkedList", "Database system ERROR");
				button1_Click_1 (sender, e);         // Clear the data form the screen
				return;
			}
			else
			{
				if ( Cust.CustomerNumber.ToString ( ) == accountno.Text )
				{
					/*					if ( Cust . accounttypes [ 1 ] > 0 )
                                        {
                                            MessageBox . Show ( "There are more than one Bank Account types belonging to this customer,\nPlease select the account type you want to update", "Database system" );
                                            AccountType . SelectedIndex = 0;
                                            return;
                                        }
                    */
					// got the matching account
					fname.Text = Cust.FirstName;
					lname.Text = Cust.LastName;
					addr1.Text = Cust.Address1;
					addr1.Text = Cust.Address1;
					addr2.Text = Cust.Address2;
					town.Text = Cust.Town;
					county.Text = Cust.County;
					pcode.Text = Cust.PostCode;
					pcode.Text = Cust.PhoneNumber; ;
					mob.Text = Cust.MobileNumber;
					// get the original (Main accountnums[0]) bank account for this customer as entered manually
					Bank = Search.FindBankObjectfromBankNo (Cust.accountnums[0].ToString ( ));
					AccountBalance.Text = Bank.Balance.ToString ( );
					Interest.Text = Bank.InterestRate.ToString ( );
					OpenDate.Text = Bank.DateOpened.ToShortDateString ( );
					// now dislpay the other a/c types they may have
					if ( Cust.accounttypes[0] > 0 )
					{
						actype1.Text = Cust.accounttypes[0].ToString ( );
						atype[0] = Convert.ToInt16 (Cust.accounttypes[0]);
					}
					if ( Cust.accounttypes[1] > 0 )
					{
						actype2.Text = Cust.accounttypes[1].ToString ( );
						atype[1] = Convert.ToInt16 (Cust.accounttypes[1]);
					}
					if ( Cust.accounttypes[2] > 0 )
					{
						actype3.Text = Cust.accounttypes[2].ToString ( );
						atype[2] = Convert.ToInt16 (Cust.accounttypes[2]);
					}
					if ( Cust.accounttypes[3] > 0 )
					{
						actype4.Text = Cust.accounttypes[3].ToString ( );
						atype[3] = Convert.ToInt16 (Cust.accounttypes[2]);
					}
					AccountType.SelectedIndex = Cust.accounttypes[0] - 1;
					if ( IsCurrent == AccountType.SelectedIndex || IsCurrent == -1 )
					{
						EnableFields (false);
						info.Text = "Account Type is already Held by this customer";
						IsCurrent = AccountType.SelectedIndex;
						day.Text = Cust.DOB.Day.ToString ( );
						month.Text = Cust.DOB.Month.ToString ( );
						year.Text = Cust.DOB.Year.ToString ( );
					}
					else
					{
						info.Text = "Account Type is valid  for this customer";
						day.Text = "";
						month.Text = "";
						year.Text = "";
						EnableFields (true);
					}
				}
			}
			startup = false;
		}
		//****************************************************************************************************************
		private void SaveCustButton_Click (object sender, EventArgs e)
		//****************************************************************************************************************
		{       // update the details
				// go get a customer object
			Customer C;

			if ( AccountBalance.Text.Length == 0 || Interest.Text.Length == 0 ) { MessageBox.Show ("Please complete the Account Balance & Interest Rate...", "Customer Update System"); return; }
			C = Customer.GetCustomerAccount (accountno.Text);
			if ( C != null )
			{
				// go ahead and update the Customers details
				C.CustomerNumber = Convert.ToInt32 (accountno.Text);
				C.FirstName = fname.Text;
				C.LastName = lname.Text;
				C.Address1 = addr1.Text;
				C.Address2 = addr2.Text;
				C.Town = town.Text;
				C.County = county.Text;
				C.PostCode = pcode.Text;
				C.MobileNumber = mob.Text;

				// Create the new bank account for this customer
				// and update the relevant fields
				BankAccount NewBAccount = BankAccount.CreateNewBankAccount (Bank, C.CustomerNumber.ToString ( ), Convert.ToInt16 (AccountType.SelectedIndex + 1),
																				 Convert.ToDecimal (AccountBalance.Text), Convert.ToDecimal (Interest.Text),
																				 "Secondary Bank account  for Customer A/c " + Bank.CustAccountNumber.ToString ( ) + " added  :-  ");
				// Sort out the array of bank account details
				for ( int i = 0; i < 4; i++ )
				{
					if ( C.accounttypes[i] == 0 )
					{
						if ( AccountType.SelectedIndex != -1 )
						{
							C.accounttypes[i] = Convert.ToInt16 (AccountType.SelectedIndex + 1);
							//						C.accountnums[i] = Convert.ToInt32(accountno.Text);
							// Now, finally, we store the correct data in th aCustomer record
							// The accountnums field SHOULD hold the BankAccount #, NOT the Customer #
							C.accountnums[i] = NewBAccount.BankAccountNumber;
							break;
						}
					}
				}
				// Update Customer Object on disk
				Customer.WriteCustObjectToDiskAndText (C, C.FullFileName);
				// update Customer  List
				//				foreach ( var L in Customer . CustomersLinkedList )
				foreach ( Customer L in DataArray.CustNo )
				{
					if ( L.CustomerNumber == Convert.ToInt32 (accountno.Text) )
					{   // got it
						L.FirstName = C.FirstName;
						L.LastName = C.LastName;
						L.Address1 = C.Address1;
						L.Address2 = C.Address2;
						L.Town = C.Town;
						L.County = C.County;
						L.PostCode = C.PostCode;
						L.PhoneNumber = C.PhoneNumber;
						L.MobileNumber = C.MobileNumber;
						break;
					}
				}
				MessageBox.Show ("The New Bank account has been created...", "Bank Account Maintenance System");
			}
			Close ( );
		}

		//****************************************************************************************************************
		private void Exit_Click_2 (object sender, EventArgs e)
		//****************************************************************************************************************
		{
			if ( Cust != null )
				Cust.Dispose ( );
			this.Close ( );
		}

		//****************************************************************************************************************
		private void button1_Click_1 (object sender, EventArgs e)
		//****************************************************************************************************************
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
			if ( AccountType.SelectedIndex == -1 )
				return;
			AccountType.SelectedIndex = Cust.accounttypes[0];            // the one we can guarantee is taken
		}

		//****************************************************************************************************************
		private void AccountType_SelectedIndexChanged (object sender, EventArgs e)
		//****************************************************************************************************************
		{
			if ( startup )
				return;
			for ( int i = 0; i < 4; i++ )
			{
				if ( AccountType.SelectedIndex == -1 )
					return;
				if ( AccountType.SelectedIndex == atype[i] - 1 )
				{
					//MessageBox . Show ( "You already have a Bank Account of this type.\nPlease select a different type of account and then try again");
					info.Text = "This account type is already in use...";
					AccountBalance.Text = Bank.Balance.ToString ( );
					Interest.Text = Bank.InterestRate.ToString ( );
					OpenDate.Text = Bank.DateOpened.ToShortDateString ( );
					IsCurrent = AccountType.SelectedIndex;
					OpenDate.Text = "";
					EnableFields (false);
					return;
				}
			}

			EnableFields (true);
			// clear the required fields that need updating
			AccountBalance.Text = Bank.Balance.ToString ( );
			Interest.Text = Bank.InterestRate.ToString ( );
			OpenDate.Text = Bank.DateOpened.ToShortDateString ( );
			// now dislpay the other a/c types they may have
			if ( Cust.accounttypes[0] > 0 )
			{
				actype1.Text = Cust.accounttypes[0].ToString ( );
				atype[0] = Convert.ToInt16 (Cust.accounttypes[0]);
			}
			if ( Cust.accounttypes[1] > 0 )
			{
				actype2.Text = Cust.accounttypes[1].ToString ( );
				atype[1] = Convert.ToInt16 (Cust.accounttypes[1]);
			}
			if ( Cust.accounttypes[2] > 0 )
			{
				actype3.Text = Cust.accounttypes[2].ToString ( );
				atype[2] = Convert.ToInt16 (Cust.accounttypes[2]);
			}
			if ( Cust.accounttypes[3] > 0 )
			{
				actype4.Text = Cust.accounttypes[3].ToString ( );
				atype[3] = Convert.ToInt16 (Cust.accounttypes[2]);
			}
			AccountBalance.Text = "";
			Interest.Text = "";
			info.Text = "Account Type is valid, Please enter Balance & Interest";
		}
		//****************************************************************************************************************
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
		private void OpenDate_TextChanged (object sender, EventArgs e) { }
		private void fname_Leave (object sender, EventArgs e) { fname.SelectionLength = 0; }
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
		//****************************************************************************************************************
		private void EnableFields (bool how)
		{
			if ( how )
			{
				fname.Enabled = true;
				lname.Enabled = true;
				addr1.Enabled = true;
				addr2.Enabled = true;
				town.Enabled = true;
				county.Enabled = true;
				pcode.Enabled = true;
				tel.Enabled = true;
				mob.Enabled = true;
				AccountBalance.Enabled = true;
				Interest.Enabled = true;
				OpenDate.Enabled = true;
				day.Enabled = true;
				month.Enabled = true;
				year.Enabled = true;
				SaveCustButton.Enabled = true;
				Find.Enabled = true;
			}
			else
			{
				fname.Enabled = false;
				lname.Enabled = false;
				addr1.Enabled = false;
				addr2.Enabled = false;
				town.Enabled = false;
				county.Enabled = false;
				pcode.Enabled = false;
				tel.Enabled = false;
				mob.Enabled = false;
				AccountBalance.Enabled = false;
				Interest.Enabled = false;
				OpenDate.Enabled = false;
				day.Enabled = false;
				month.Enabled = false;
				year.Enabled = false;
				SaveCustButton.Enabled = false;
				Find.Enabled = false;

			}
		}

		private void Interest_TextChanged (object sender, EventArgs e)
		{
			info.Text = "";
		}

		private void groupBox2_Enter (object sender, EventArgs e)
		{

		}
	}
}
