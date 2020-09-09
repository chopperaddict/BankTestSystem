//using Microsoft.Graph;
using System;
using System.IO;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class CustomerDelete : Form
	{
		BankAccount Bank;
		Customer Cust;
		bool dirty = false;
		public CustomerDelete ( )
		{
			InitializeComponent ( );
			//			Bank. fc . Text += "Delete Customer Window Loaded..\r\n";
			AccountNumber.Focus ( );

		}

		// find account
		private void DeleteButton_Click (object sender, EventArgs e)
		{
			string accno = AccountNumber.Text;
			string balstr = "";

			if ( Cust == null )
				Cust = Customer.GetCustomerAccount (accno);
			if ( Cust == null )
			{ MessageBox.Show ("Unable to find the Customer Record on Disk", "Database system ERROR"); return; }
			// now check all the objects first, then finally delete it all
			Bank = Search.FindBankObjectfromCustNo (accno);     // get the full file name/path
			if ( Bank == null )
			{
				MessageBox.Show ("Unable to open the Bank Account Record File (Object for deletion)!", "Database system ERROR");
				//						Cu . Dispose ( );     // delete Customer object in memory sraight away
				return;
			}
			else
			{
				balstr = Bank.Balance.ToString ( );
				if ( Bank.Balance > 0 )
				{
					DialogResult result;
					result = MessageBox.Show ("This Customer has a positive balance of " + Bank.Balance.ToString ( ) + " in their main account!\nDo you really want to continue to delete it ?", "Financial Adjustment Required", MessageBoxButtons.YesNo);
					if ( result == DialogResult.No )
						return;
				}
				// Find CUSTOMER in LINKED LIST and DELETE IT.
				foreach ( var L in Customer.CustomersLinkedList )
				{
					if ( L.CustomerNumber == Convert.ToInt32 (accno) )
					{
						Customer.CustomersLinkedList.Remove (L);
						L.Dispose ( );
						break;
					}
				}

				// Find CUSTOMER in ArrayLIST and DELETE IT.
				// remember to also delete ALL other Bank A/cs
				// DeleteSecondaryBankAccounts handles both  LinkedList and ArrayList
				// and the disk file itself
				if ( Cust.accountnums[1] > 0 )
				{
					DeleteSecondaryBankAccounts (Bank, Cust.accountnums[1]);
				}
				if ( Cust.accountnums[2] > 0 )
				{
					DeleteSecondaryBankAccounts (Bank, Cust.accountnums[2]);
				}
				if ( Cust.accountnums[3] > 0 )
				{
					DeleteSecondaryBankAccounts (Bank, Cust.accountnums[3]);
				}
				// dont forget the original account
				DeleteSecondaryBankAccounts (Bank, Cust.accountnums[0]);
				BankTransaction newtransrecord = new BankTransaction (
											DateTime.Now,    // Transaction Date
											Bank.AccountType,           // Account Type
											Bank.CustAccountNumber,          // Cust Account #
											Bank.BankAccountNumber,           // Bank Account #
											Convert.ToDecimal ("0.00"),      // Transaction Amount
											"Customer " + Bank.CustAccountNumber.ToString ( ) + " has been deleted",            // Notes
											Bank.Status);           // Status

				// remove the customer from our ArrayList
				if ( !DataArray.ArrayDeleteCust (Cust) )
				{
					MessageBox.Show ("Failed to delete the Customer record from ArrayList", "Data processing ERROR");
				}
				// write a transaction record so we rmeeber th eCustomer has GONE...
				BankTransaction.allBankTransactions.AddLast (newtransrecord);
				// Finally Delete the Customer record
				if ( File.Exists (Cust.FullFileName) )
					File.Delete (Cust.FullFileName);
				// now delete the Textfile copy
				string fi = Customer.GetCustFilePath ( ) + "Textfiles\\custobj" + Bank.CustAccountNumber.ToString ( ) + ".txt";
				if ( File.Exists (fi) )
					File.Delete (fi);

				File.Delete (Bank.FullFileName);    // now delete the actual Bank Account file
													// clean up our memeory usage after ourselves so far 
													//				Bank . Dispose ( );     // delete BankAccount object in memory 
													//				Cust . Dispose ( );     // delete our file wide Customer object in memory
			}
			//			Bank. fc . Text = "Customer # " + accno + " has been deleted from the system successfully..\r\n";
			command.Text = "Account " + accno + " has been deleted completely";
			FirstName.Text = "";
			LastName.Text = "";
			//AccountNumber . Text = "";
			info.Text = "including all attached Bank Account(s)";
			if ( balstr.Length > 0 )
				MessageBox.Show ("The selected Customer # had a balance of " + Bank.Balance.ToString ( ) + " in their main account!\nbut the account  has still been deleted?", "Financial Adjustment Required", MessageBoxButtons.YesNo);
			else
				MessageBox.Show ("The selected Customer # has been deleted succesfully including  their main and auxuiliary accounts?", "Customer Deletion Utility", MessageBoxButtons.YesNo);
			AccountNumber.Focus ( );
		}

		public static bool DeleteSecondaryBankAccounts (BankAccount B, Int32 bankno)
		{
			int indx = DataArray.ArrayFindBank (bankno);
			if ( indx == -1 )
			{
				MessageBox.Show ("Unable to identify Bank Record in ArrayList, Bank Account has NOT been deleted!\nThe System data is NOW in an UNSTABLE condition....", "Data system ERROR");
				return false;
			}
			else
			{   // delete all the  bank stuff for this additional account
				DataArray.BankNo.RemoveAt (indx);
				// remove entry in linked list
				foreach ( BankAccount b in BankAccount.BankAccountsLinkedList )
				{
					if ( b.BankAccountNumber == bankno )
					{
						BankAccount.BankAccountsLinkedList.Remove (b);
						break;
					}
				}
				// Delete the file from disk
				File.Delete (B.FullFileName);
				//info.Text = "Secondary Bank Account # " + bankno . ToString ( ) + " has been deleted successfully..\r\n";
				return true;
			}
		}

		// Cancel window
		private void Cancelbutton_Click (object sender, EventArgs e)
		{
			dirty = true;
			//clean up our memeory usage after ourselves so far
			Bank.Dispose ( );     // delete our file wide BankAccount object from memory 
			Cust.Dispose ( );     // delete our file wide Customer object from memory
			Close ( );
		}

		// find the customer
		private void findaccount_Click (object sender, EventArgs e)
		{
			if ( dirty ) return;
			//			This is the BANK #
			string accno = AccountNumber.Text;

			Bank = DataArray.ArrayGetBank (Convert.ToInt32 (AccountNumber.Text));
			if ( Bank == null )
			{
				info.Text = "The Customer # " + AccountNumber.Text + " cannot be found ?. Please try again... ";
				MessageBox.Show ("The Bank account # " + AccountNumber.Text + " for this Customer cannot be found ?. Please try a  different  value... ", "Customer deletion system");
				AccountNumber.Focus ( );
				return;
			}

			Cust = Customer.GetCustomerAccount (Bank.CustAccountNumber.ToString ( ));
			if ( Cust == null )
			{ MessageBox.Show ("Unable to find the Customer Record from LinkedList", "Database system ERROR"); return; }
			else
			{
				DeleteButton.Enabled = true;
				command.Text = "Account has been identified successfully";
				FirstName.Text = Cust.FirstName;
				LastName.Text = Cust.LastName;
				command.Text = "Click <DELETE> to REMOVE PERMANENTLY";
			}
		}

		private void AccountNumber_Leave (object sender, EventArgs e)
		{
			if ( AccountNumber.Text == "1234" )
			{
				info.Text = "Please complete the Customer A/c # entry correctly";
				AccountNumber.Focus ( );
				return;
			}
			if ( dirty ) return;
			if ( AccountNumber.Text == "" )
			{
				MessageBox.Show ("You MUST enter a valid Cusotmer A/c #, Please try again... ", "Customer deletion system");
				AccountNumber.Focus ( );
				return;
			}

			if ( Bank == null )
			{
				Bank = DataArray.ArrayGetBank (Convert.ToInt32 (AccountNumber.Text));
				if ( Bank == null )
				{
					info.Text = "The Customer # " + AccountNumber.Text + " cannot be found ?. Please try again... ";
					MessageBox.Show ("The Bank account # " + AccountNumber.Text + " for this Customer cannot be found ?. Please try a  different  value... ", "Customer deletion system");
					AccountNumber.Focus ( );
					return;
				}
				bankno.Text = Bank.BankAccountNumber.ToString ( );
			}
			DeleteButton.Enabled = true;
			//Customer C = new Customer ( );
			Cust = DataArray.ArrayGetCust (Convert.ToInt32 (Bank.CustAccountNumber.ToString ( )));
			if ( Cust == null )
			{
				MessageBox.Show ("Cannot identify the Customer A/c # , Please try again... ", "Customer deletion system");
				return;
			}
			else
			{
				LastName.Text = Cust.LastName;
				FirstName.Text = Cust.FirstName;
				info.Text = "Customer A/C found ! - Click the Delete button to remove this account...";
				DeleteButton.Focus ( );
				MessageBox.Show ("Customer A/c # Identified, press the Delete button to remove it... ", "Customer deletion system");
			}

		}

		private void Cancelbutton_MouseDown (object sender, MouseEventArgs e)
		{
			Close ( );
		}

		private void CustomerDelete_Load (object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter (object sender, EventArgs e)
		{

		}
	}
}
