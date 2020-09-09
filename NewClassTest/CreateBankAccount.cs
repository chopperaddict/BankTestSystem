using System;
using System.Linq;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class CreateBankAccount : Form
	{
		public CreateBankAccount ( )
		{
			InitializeComponent ( );
			OpenDate.Text = DateTime.Now.ToShortDateString ( );
			foreach ( Customer C in DataArray.CustNo )
			{
				comboBox1.Items.Add (C.CustomerNumber.ToString ( ));
				comboBox1.SelectedIndex = 0;
				AccountType.SelectedIndex = 0;
			}
		}

		private void CreateAccount_Click (object sender, EventArgs e)
		{
			if ( AccountBalance.Text == "" || Interest.Text == "" )
			{
				info.Text = "Please fill out both Balance and Interest fields...";
				AccountBalance.Focus ( );
				return;
			}
			char[] ch = { '-' };
			BankAccount bank = new BankAccount ( );
			string custno = comboBox1.Text;
			string acctype = AccountType.Text;
			string[] temp = acctype.Split (ch);
			Int16 accounttype = Convert.ToInt16 (temp[0]);
			string amnt = AccountBalance.Text;
			decimal amount = Convert.ToDecimal (amnt);
			decimal interest = Convert.ToDecimal (Interest.Text);
			// This call handles Linked List, ArrayList etc
			BankAccount.CreateNewBankAccount (bank, custno, accounttype, amount, interest, "Solo Bank Account created  for Customer " + bank.BankAccountNumber);
			AccountNumber.Text = bank.BankAccountNumber.ToString ( );
			info.Text = "New Bank Account [" + bank.BankAccountNumber.ToString ( ) + "] created for Customer " + custno;
			Customer.UpdateCustWithNewBankAccount (Convert.ToInt32 (custno), bank.BankAccountNumber, accounttype);

		}

		private void CreateAccount_Click_1 (object sender, EventArgs e)
		{

		}

		private void button1_Click (object sender, EventArgs e)
		{
			Close ( );
		}

		private void AccountBalance_TextChanged (object sender, EventArgs e)
		{

		}

		private void AccountType_SelectedIndexChanged (object sender, EventArgs e)
		{
			//AccountType.SelectedIndex = 

		}

		private void AccountType_KeyPress (object sender, KeyPressEventArgs e)
		{
			if ( e.KeyChar == '\r' )
			{ AccountBalance.Focus ( ); }
		}

		//============================================================================================
		private void AccountBalance_KeyPress (object sender, KeyPressEventArgs e)
		//============================================================================================
		{
			if ( !Validate (e, AccountBalance.Text) )
			{
				string valid = ".0123456789";
				if ( valid.Contains (e.KeyChar) )
					return;
				else
				{
					e.KeyChar = Convert.ToChar (0);
					return;
				}
			}
			else
				Interest.Focus ( );
		}

		//============================================================================================
		private void Interest_KeyPress (object sender, KeyPressEventArgs e)
		//============================================================================================
		{
			if ( !Validate (e, Interest.Text) )
			{
				string valid = ".0123456789";
				if ( valid.Contains (e.KeyChar) )
					return;
				else
				{
					e.KeyChar = Convert.ToChar (0);
					return;
				}
			}
			else
				comboBox1.Focus ( );

		}

		//============================================================================================
		private void comboBox1_KeyPress (object sender, KeyPressEventArgs e)
		//============================================================================================
		{
			if ( e.KeyChar == '\r' )
			{
				info.Text = "All data is valid, Click Button to create new Bank Account...";
				CreateAccount.Focus ( );
			}
		}
		//============================================================================================
		public static bool Validate (KeyPressEventArgs e, string text)
		//============================================================================================
		{
			string valid = ".0123456789";
			string invalid = "!\"£$%^&*()_+-={}[]~#@':;?/><,|abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			if ( invalid.Contains (e.KeyChar.ToString ( )) )
				return false;
			if ( valid.Contains (e.KeyChar.ToString ( )) || e.KeyChar == '\r' || e.KeyChar == '\t' )
			{
				if ( e.KeyChar == '\r' || e.KeyChar == '\t' )
				{
					return true;
				}
				else
				{
					if ( valid.Contains (e.KeyChar.ToString ( )) )
					{
						return false;
					}
				}
			}

			if ( (e.KeyChar != '\r' || e.KeyChar != '\t') && text == "" )
			{
				MessageBox.Show ("You must enter a value for this item...", "Input validation error");
				return false;
			}
			if ( valid.Contains (e.KeyChar.ToString ( )) )
				return false;
			if ( e.KeyChar == '\r' || e.KeyChar == '\t' )
			{
				return true;
			}
			return false;
		}

		private void CreateBankAccount_Load (object sender, EventArgs e)
		{

		}

		private void panel1_Paint (object sender, PaintEventArgs e)
		{

		}
	}
}
