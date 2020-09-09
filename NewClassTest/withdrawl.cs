using System;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class withdrawl : Form
	{
		public Customer Cust;
		public BankAccount Bank;
		public withdrawl ( )
		{
			InitializeComponent ( );
		}

		private void button2_Click (object sender, EventArgs e)
		{
			accountnumber.Text = "";
			textBox2.Text = "";
			notes.Text = "";
		}

		private void MakeWithdrawl_Click_1 (object sender, EventArgs e)
		{
			if ( accountnumber.Text.Length == 0 || textBox2.Text.Length == 0 )
			{
				info.Text = "Please complete both fields before pressing Go";
				MessageBox.Show ("Please complete both fields before pressing Go", "Data Input Error");
				return;
			}
			if ( notes.Text == "" )
			{
				MessageBox.Show ("You have not entered a reason for this Withdrawl ?\nDo you want to continue without doing so ?",
										"Data Input Error", MessageBoxButtons.YesNo);
				if ( DialogResult == DialogResult.No )
					return;
			}

			// This is the bank account #
			Int32 bankaccountno = Convert.ToInt32 (accountnumber.Text);
			string acnostring = accountnumber.Text;
			string amountstr = textBox2.Text.Trim ( );
			if ( !amountstr.Contains (".") )
				amountstr += ".00";
			decimal amount = Convert.ToDecimal (amountstr);
			if ( amount <= 0 ) { throw new ArgumentOutOfRangeException (nameof (amount), "Amount of Withdrawl [" + amount + "] must be entered as a positive value"); }

			// Update the Bank ArrayList
			Bank = DataArray.ArrayGetBank (bankaccountno);
			if ( Bank == null )
			{
				MessageBox.Show ("Unable to Find Bank  Account in LinkedList??..\nWithdrawl transaction aborted.", "Fatal Error"); return;
			}
			string custnostring = Bank.CustAccountNumber.ToString ( );


			// This call updates BOTH  the Bank A/c and the entry in the LinkedList
			// we have made the amount negative for this call
			if ( !BankAccount.UpdateBankLinkedList (bankaccountno, amount * -1) )
			{
				MessageBox.Show ("Failed to update BankAccount Linked List for Account " + acnostring, "Bank Account Withdrawl");
			}
			// Also save the updated bank account back to disk
			SerializeData.WriteBankAccountToDiskAndText (Bank, Bank.FullFileName);
			// now add a new transaction for this operation
			BankTransaction Deposit = new BankTransaction ( );
			Deposit.TransDate = DateTime.Now;
			Deposit.AccountType = Bank.AccountType;
			Deposit.CustAccountNumber = Bank.CustAccountNumber;
			Deposit.BankAccountNumber = Bank.BankAccountNumber;
			Deposit.Transamount = amount;
			Deposit.Notes = "New Withdrawl: " + notes.Text;
			Deposit.Status = Bank.Status;
			BankTransaction.allBankTransactions.AddLast (Deposit);

			// update the Customer Balance Hash Table cos it holds the balance value
			CustomerBalanceHashTable.DeleteHashCustBalEntry (custnostring);
			CustomerBalanceHashTable.AddHashCustBalEntry (custnostring, Bank.Balance);

			MessageBox.Show ("Withdrawl of " + amount.ToString ( ) + " has been deducted from account  # " + custnostring + "\nThe new balance is £" + Bank.Balance.ToString ( ), "Bank Account account Withdrawl");
			textBox2.Text = "";
			notes.Text = "";
			accountnumber.Focus ( );
			return;
		}


		private void textBox2_KeyPress (object sender, KeyPressEventArgs e)
		{
			string valid = ".0123456789";
			string invalid = "!\"£$%^&*()_+-={}[]~#@':;?/><,|abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			if ( valid.Contains (e.KeyChar.ToString ( )) )
			{ }
			else
			{
				if ( invalid.Contains (e.KeyChar.ToString ( )) )
				{
					MessageBox.Show ("Invalid character entered. \n The entry CAN ONLY be of DIGITS or a single period only", "Input validation error");
					e.Handled = true;
				}
			}
		}

		private void accountnumber_Leave (object sender, EventArgs e)
		{
			if ( accountnumber.Text == "" )
			{
				MessageBox.Show ("You MUST enter a valid Bank  A/c #, Please try again... ", "Bank Account Deposit");
				accountnumber.Focus ( );
				return;
			}
			Bank = DataArray.ArrayGetBank (Convert.ToInt32 (accountnumber.Text));
			if ( Bank == null )
			{
				info.Text = "The Customer # " + accountnumber.Text + " cannot be found ?. Please try again... ";
				MessageBox.Show ("The Bank account # " + accountnumber.Text + " cannot be found ?. Please try a  different  value... ", "Bank Account account dep");
				accountnumber.Focus ( );
				return;
			}
			MakeWithdrawl.Enabled = true;
			Cust = DataArray.ArrayGetCust (Convert.ToInt32 (Bank.CustAccountNumber.ToString ( )));
			if ( Cust == null )
			{
				MessageBox.Show ("Cannot identify the Customer A/c # for this bank account , Please try again... ", "Bank Account Deposit");
				return;
			}
			else
			{
				lastname.Text = Cust.LastName;
				firstname.Text = Cust.FirstName;
				info.Text = "Bank A/C found ! - Enter the amount to be deposited...";
				textBox2.Focus ( );
			}

		}

		private void button1_Click (object sender, EventArgs e)
		{
			Close ( );
		}

		private void withdrawl_KeyDown (object sender, KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Escape )
			{
				MessageBox.Show ("Are you sure you want to exit ?" + Bank.Balance.ToString ( ), "Bank Account Withdrawl");
				Close ( );
			}

		}

		private void withdrawl_Load (object sender, EventArgs e)
		{

		}
	}
}

