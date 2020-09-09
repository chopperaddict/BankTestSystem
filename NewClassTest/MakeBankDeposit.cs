using System;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class MakeBankDeposit : Form
	{

		public static BankAccount Bank;
		public static Customer Cust;
		public MakeBankDeposit ( )
		{
			InitializeComponent ( );
			accountnumber.Focus ( );
		}

		//******************************************************************************************************************************
		private void button2_Click (object sender, EventArgs e)
		//******************************************************************************************************************************
		{
			accountnumber.Text = "";
			textBox2.Text = "";
			notes.Text = "";
		}

		private void button1_Click (object sender, EventArgs e)
		{
			this.Close ( );
		}

		private void accountnumber_Leave_1 (object sender, EventArgs e)
		{ // loosing focus of Bank A/C #

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
				MessageBox.Show ("The Bank account # " + accountnumber.Text + " cannot be found ?. Please try a  different  value... ", "Bank Account Deposit");
				accountnumber.Focus ( );
				return;
			}
			MakeDeposit.Enabled = true;
			//Customer C = new Customer ( );
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


		private void textBox2_Enter (object sender, EventArgs e)
		{
			MakeDeposit.Enabled = true;
			MakeDeposit_Click_1 (sender, e);
		}

		private void accountnumber_DoubleClick (object sender, EventArgs e)
		{
			/*			if ( accountnumber . Text . Length > 0 )
                        {
                            try
                            {
                                Convert . ToInt32 ( accountnumber . Text );
                                textBox2 . Focus ( );
                            }
                            catch
                            {
                                MessageBox . Show ( "You MUST enter a valid Customer A/c #, Please try again... ", "Bank Account Deposit" );
                            }
                        }
            */
		}

		private void textBox2_Leave (object sender, EventArgs e)
		{// amount field
		 //				Int32 acno = Convert . ToInt32 ( textBox2 . Text );
			notes.Focus ( );
			MakeDeposit.Enabled = true;
			/*				BankAccount B = new BankAccount ( );
                            B = DataArray . ArrayGetBank ( acno );
                            if ( B == null )
                            {
                                MessageBox . Show ( "Cannot identify the Bank A/c # requested, Please try again... ", "Bank Account Deposit" );
                            }
                        }
                        catch
                        {
                            MessageBox . Show ( "You MUST enter a valid Bank  A/c #, Please try again... ", "Bank Account Deposit" );
            */
		}
		// Go ahead and make bank account deposit
		//******************************************************************************************************************************
		private void MakeDeposit_Click_1 (object sender, EventArgs e)
		//******************************************************************************************************************************
		{
			// Caution, this bank account may be one of several for this customer, 
			// so make NO assumptions
			// Bank is already the correct record
			Int32 bankaccountno = 0;
			if ( accountnumber.Text.Length == 0 || textBox2.Text.Length == 0 )
			{
				info.Text = "Please complete both fields before pressing Go";
				MessageBox.Show ("Please complete both fields before pressing Go", "Data Input Error");
				return;
			}
			if ( notes.Text == "" )
			{
				MessageBox.Show ("You have not entered a reason for this deposit ?\nDo you want to continue without doing so ?",
										"Data Input Error", MessageBoxButtons.YesNo);
				if ( DialogResult == DialogResult.No )
					return;
			}

			// This is the bank account #
			bankaccountno = Convert.ToInt32 (accountnumber.Text);
			string acnostring = accountnumber.Text;
			string amountstr = textBox2.Text.Trim ( );
			if ( !amountstr.Contains (".") )
				amountstr += ".00";
			decimal amount = Convert.ToDecimal (amountstr);
			if ( amount <= 0 ) { throw new ArgumentOutOfRangeException (nameof (amount), "Amount of Deposit [" + amount + "] must be positive"); }

			// Update the Bank ArrayList
			Bank = DataArray.ArrayGetBank (bankaccountno);
			if ( Bank == null )
			{
				MessageBox.Show ("Unable to Find Bank  Account in LinkedList??..\nDeposit transaction aborted.", "Fatal Error"); return;
			}
			string custnostring = Bank.CustAccountNumber.ToString ( );


			// This call updates BOTH  the Bank A/c and the entry in the LinkedList
			if ( !BankAccount.UpdateBankLinkedList (bankaccountno, amount) )
			{
				MessageBox.Show ("Failed to update BankAccount Linked List for Account " + acnostring, "Bank Account Deposit");
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
			Deposit.Notes = "New Deposit : " + notes.Text;
			Deposit.Status = Bank.Status;
			BankTransaction.allBankTransactions.AddLast (Deposit);

			// update the Customer Balance Hash Table cos it holds the balance value
			CustomerBalanceHashTable.DeleteHashCustBalEntry (custnostring);
			CustomerBalanceHashTable.AddHashCustBalEntry (custnostring, Bank.Balance);

			MessageBox.Show ("Deposit of " + amount.ToString ( ) + " has been added to account  # " + custnostring + "\nThe new balance is £" + Bank.Balance.ToString ( ), "Bank Account Deposit");
			textBox2.Text = "";
			notes.Text = "";
			accountnumber.Focus ( );
			return;
		}

		private void MakeBankDeposit_KeyDown (object sender, KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Escape )
			{
				MessageBox.Show ("Are you sure you want to " + Bank.Balance.ToString ( ), "Bank Account Deposit");
				Close ( );
			}
		}

		private void MakeBankDeposit_Load (object sender, EventArgs e)
		{

		}
		//******************************************************************************************************************************

	}
}
