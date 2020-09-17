using System;
using System.Windows.Forms; // required for Dictionaries/Hastables


namespace ClassAccessTest
{
    public partial class BankAccountEdit : Form
    {
        private BankAccount Bank;
        private Customer Cust;
        private string accno = "";
        public static bool listupdateneeded = true;
        public BankAccountEdit()
        {
            InitializeComponent();
            Bank = new BankAccount();
            Cust = new Customer();
            AccountNo.Enabled = true;
            Interest.Enabled = true;
            OpenDate.Enabled = true;
            Info.Text = "Enter Account #. then any fields may be changed";
            AccountNo.Focus();
        }

        //*************************************************************************************************************************************************//
        // Find the customer record
        private void findbank_Click_1(object sender, EventArgs e)
        //*************************************************************************************************************************************************//
        {
            accno = AccountNo.Text;
            if (accno == "")
            {
                MessageBox.Show("You MUST enter a valid Bank Account number. They start at 1050000", "A/C number entry Error");
                // lots of work to prefill  # and put cursor at end of it with text 
                // unselected. so user can just start typing numbers
                AccountNo.Text = "123";
                AccountNo.Focus();
                AccountNo.SelectionLength = 0;
                AccountNo.SelectionStart = AccountNo.Text.Length;
                return;
            }
            if (Convert.ToInt32(accno) < 1050000)
            {
                MessageBox.Show("Invalid Entry - The Bank Account numbers start at 105000.", "File number entry Error");
                return;
            }
            // housekeeping
            allbankaccounts.Items.Clear();
            // Now get the bank account for this customer
            //Now we know the "main" Bank Account # anyway to read details of
            try
            {
                Bank = Search.FindBankObjectfromBankNo(accno);
                if (Bank == null)
                { MessageBox.Show("There was a problem finding the BankAccount # " + accno + " you entered...\n              Please try again ! ", "File Access problem"); return; }
            }
            catch
            {
                MessageBox.Show("There was a problem finding the BankAccount file " + accno, "File Access problem");
                return;
            }
            Custno.Text = Bank.CustAccountNumber.ToString();
            AccountBalance.Text = Bank.Balance.ToString();
            Interest.Text = Bank.InterestRate.ToString();
            OpenDate.Text = Bank.DateOpened.ToShortDateString();
            if (Bank.Status == 0)
                status.Text = "**Closed**";
            else if (Bank.Status == 1)
                status.Text = "Active";
            else if (Bank.Status == 2)
                status.Text = "Suspended";
            try
            {
                Cust = Customer.GetCustomerAccount(Bank.CustAccountNumber.ToString());
                if (Cust == null)
                {
                    MessageBox.Show("Unable to find the Customer Record from LinkedList", "Database system ERROR");
                    button1_Click_1(sender, e);         // Clear the data form the screen
                    return;
                }
            }
            catch
            {
                new Exception(" Unable to load Customer account in bankaccountedit.cs, Line 55");
            }
            int typevalue = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Cust.accountnums[i] > 0)
                {
                    typevalue = Cust.accounttypes[i];
                    string output = Cust.accountnums[i].ToString() + "\t" + typevalue.ToString();
                    allbankaccounts.Items.Add(output);
                }
            }
            /*				if ( Cust . accountnums [ i ] . ToString ( ) == AccountNo . Text )
							{
								// got the matching account
								// load thre combo of bank accounts
								if ( Cust . accountnums [i ] > 0 )
								{
									typevalue = Cust . accounttypes [ i ];
									string output = Cust . accountnums [ 0 ] . ToString ( ) + "\t" + typevalue . ToString ( );
									allbankaccounts . Items . Add ( output );
								}
			/*
								if ( Cust . accountnums [ 1 ] > 0 )
								{
									typevalue = Cust . accounttypes [ 1 ];
									string output = Cust . accountnums [ 1 ] . ToString ( ) + "\t" + typevalue . ToString ( );
									allbankaccounts . Items . Add ( output );
								}
								if ( Cust . accountnums [ 2 ] > 0 )
								{
									typevalue = Cust . accounttypes [ 2 ];
									string output = Cust . accountnums [ 2 ] . ToString ( ) + "\t" + typevalue . ToString ( );
									allbankaccounts . Items . Add ( output );
								}
								if ( Cust . accountnums [ 3 ] > 0 )
								{
									typevalue = Cust . accounttypes [ 3 ];
									string output = Cust . accountnums [ 3 ] . ToString ( ) + "\t" + typevalue . ToString ( );
									allbankaccounts . Items . Add ( output );
								}

							}
			*/
            AccountType.SelectedIndex = typevalue - 1;
            allbankaccounts.SelectedItem = 1;
            allbankaccounts.SelectedIndex = 0;// Text = allbankaccounts. SelectedItem. ToString ( );
            SaveBankButton.Enabled = true;
            button1.Enabled = true;
            Exit.Enabled = true;
            // fill out ALL the fields
            // Customer first
            fname.Text = Cust.FirstName;
            lname.Text = Cust.LastName;
            day.Text = Cust.DOB.Day.ToString();
            month.Text = Cust.DOB.Month.ToString();
            year.Text = Cust.DOB.Year.ToString();
            day.Text = Cust.DOB.Day.ToString();
            month.Text = Cust.DOB.Month.ToString();
            year.Text = Cust.DOB.Year.ToString();
            fname.Text = Cust.FirstName;
            lname.Text = Cust.LastName;
            addr1.Text = Cust.Address1;
            addr2.Text = Cust.Address2;
            town.Text = Cust.Town;
            county.Text = Cust.County;
            postcode.Text = Cust.PostCode;
            phone.Text = Cust.PhoneNumber;
            mobile.Text = Cust.MobileNumber;

            /*                  // Bank account fields //
							* 		  internal Int32 BankAccountNumber = 0;	  // Secondary key
									internal Int32 CustAccountNumber = 0; // major key
									internal Int16 AccountType = 0;        // minor key
									internal decimal  Balance = 0.00;
									internal DateTime DateOpened;
									internal DateTime DateClosed;// We do not fill this out.
									internal decimal  InterestRate = 3.75;    // Default value only
									internal Int16 Status = 1; // Status can be 0-Closed, 1- Active, 2-Suspended     
			*/
        }
        // Save the new customer data as an Object and add it to the Customer List
        // plus create a BankAccount object and add it to the BankAccount List
        // and add a bak transaction
        //*************************************************************************************************************************************************//
        private void SaveBankButton_Click(object sender, EventArgs e)
        //*************************************************************************************************************************************************//
        {
            if (AccountNo.Text.Length == 0 || AccountBalance.Text.Length == 0 || Interest.Text.Length == 0 || OpenDate.Text.Length == 0 || fname.Text.Length == 0
                            || lname.Text.Length == 0 || day.Text.Length == 0 || month.Text.Length == 0 || year.Text.Length == 0)
            {
                MessageBox.Show("One or more fields are empty, All fields must be populated", "User Input Error");
                return;
            }
            Int16 type = 0;
            if (AccountType.Text.Contains("Normal")) type = 1;
            if (AccountType.Text.Contains("Savings")) type = 2;
            if (AccountType.Text.Contains("Deposit")) type = 3;
            if (AccountType.Text.Contains("Business")) type = 4;

            //====================BANK ACCOUNT ========================================
            // READ BANK OBJECT FROM DISK and update it
            // Bank should be valid as it is a global in this file ?
            if (allbankaccounts.SelectedIndex == -1)
            {
                MessageBox.Show("The Bank Account list does not appear to have an item selected\nWe No data has been changed, but we are UNABLE to continue with update...", "Database system ERROR");
                return;
            }
            string target = allbankaccounts.Items[allbankaccounts.SelectedIndex].ToString();
            char[] ch = { '\t' };
            char[] dashch = { '-' };
            string[] tempacno = target.Split(ch);
            Int32 accountno = Convert.ToInt32(tempacno[0]);
            Bank = Search.FindBankObjectfromBankNo(accountno);
            int actype = Convert.ToInt16(AccountType.SelectedIndex + 1);
            string actypeselected = AccountType.SelectedItem.ToString();
            string[] newselaccount = actypeselected.Split(dashch);
            if (newselaccount[0] != tempacno[1])
            {   // the type of account has been changed - handle it
                for (int i = 0; i < allbankaccounts.Items.Count; i++)
                {
                    string temp = "";
                    temp = allbankaccounts.Items[i].ToString();
                    string[] thisentry = temp.Split(ch);
                    if (thisentry[0] == tempacno[0] && thisentry[1] != newselaccount[0])
                    {
                        listupdateneeded = false;   //This simply avoids the auto update of the listbox, set back to true afterwards
                        allbankaccounts.Items.RemoveAt(i);
                        temp = Bank.BankAccountNumber.ToString() + "\t" + actype.ToString();
                        allbankaccounts.Items.Add(temp);
                        allbankaccounts.SelectedIndex = i;
                        listupdateneeded = true;
                        break;
                    }
                }
            }
            // Thkis call sends Event data to Bankaccount.cs so the handlers can handle it
            // cos we cannot call them directly in BankAccount.cs
            BankAccount.SendBankEventData(Bank, "BANKACCOUNT MODIFIED");

            // we need to  delete the old account and insert the new details  in our ArrayList
            int index = DataArray.ArrayFindBank(Bank);
            DataArray.BankNo.RemoveAt(index);
            BankAccount.BankDict.Remove (index);

			Bank.Balance = Convert.ToDecimal(AccountBalance.Text);
            Bank.InterestRate = Convert.ToDecimal(Interest.Text);
            Bank.DateOpened = Convert.ToDateTime(OpenDate.Text);
            Bank.AccountType = Convert.ToInt16(actype);
            //SAVE BANK OBJECT BACK TO DISK
            SerializeData.WriteBankAccountToDiskAndText(Bank, Bank.FullFileName);
            DataArray.ArrayAddBank(Bank);
            if (BankAccount.BankDict != null)
            {
	            if (!BankAccount.BankDict.ContainsKey( Bank.BankAccountNumber ))
		            BankAccount.BankDict.Add( Bank.BankAccountNumber, Bank );
            } // handle the Linkedlist as well

            // CREATE A NEW BANK TRANSACTION
			BankTransaction newbankaccount = new BankTransaction();
            newbankaccount.TransDate = DateTime.Now;
            newbankaccount.AccountType = Bank.AccountType;
            newbankaccount.CustAccountNumber = Bank.CustAccountNumber;
            newbankaccount.BankAccountNumber = Bank.BankAccountNumber;
            newbankaccount.Transamount = Bank.Balance;
            newbankaccount.Notes = "Opening Balance";
            newbankaccount.Status = Bank.Status;
            BankTransaction.allBankTransactions.AddLast(newbankaccount);
            //Update the Customer HASH TABLE
            CustomerBalanceHashTable.UpdateCustBalHashTable(Bank.CustAccountNumber.ToString(), Bank.Balance);

            //NOW UPDATE CUSTOMER RECORD
            Cust = Customer.GetCustomerAccount(Bank.CustAccountNumber.ToString());
            if (Cust == null)
            { MessageBox.Show("Unable to find the Customer Record from LinkedList", "Database system ERROR"); return; }
            else
            {
                // we need to  delete the old Customer account and insert the new details  in our ArrayList
                int indx = DataArray.ArrayFindCust(Cust);
                DataArray.CustNo.RemoveAt(indx);
                Customer.CustDict.Remove(indx );
                // Now update the Customer record so we can add it to the array
				Cust.FirstName = fname.Text;
                Cust.LastName = lname.Text;
                Cust.DOB = Convert.ToDateTime(day.Text + "/" + month.Text + "/" + year.Text);
                if (Cust.accountnums[0] == Convert.ToInt32(Bank.BankAccountNumber))
                    Cust.accounttypes[0] = type;
                else if (Cust.accountnums[1] == Convert.ToInt32(Bank.BankAccountNumber))
                    Cust.accounttypes[1] = type;
                else if (Cust.accountnums[2] == Convert.ToInt32(Bank.BankAccountNumber))
                    Cust.accounttypes[2] = type;
                else if (Cust.accountnums[3] == Convert.ToInt32(Bank.BankAccountNumber))
                    Cust.accounttypes[3] = type;
                Cust.Address1 = addr1.Text;
                Cust.Address2 = addr2.Text;
                Cust.Town = town.Text;
                Cust.County = county.Text;
                Cust.PostCode = postcode.Text;
                Cust.PhoneNumber = phone.Text;
                Cust.MobileNumber = mobile.Text;

                // SAVE CUSTOMER OBJECT BACK TO DISK
                Customer.WriteCustObjectToDiskAndText(Cust, Cust.FullFileName);
                try
                {   // update Customer Linked List & ArrayList
                    Customer.CustomersLinkedList.Remove(Cust);
                    Customer.CustomersLinkedList.AddLast(Cust);
                    // save our Customer LinkedList to disk as binary and txt files
                    Lists.SaveAllCustomerListData(Customer.CustomerFilePath + "CustSortedListData.cust");
                    DataArray.ArrayAddCust(Cust);
                    if (Customer.CustDict != null)
                    {
	                    if (!Customer.CustDict.ContainsKey( Cust.CustomerNumber ))
		                    Customer.CustDict.Add( Cust.CustomerNumber, Cust );
                    }
                }
				catch { new Exception("Customer Linked List coukld not be updated in bankaccountEdit.cs cline 103"); }
            }

            MessageBox.Show("Bank & Customer  accounts have been updated successfully...,", "Bank account Edit Facility");
        }

        //clear all data fields
        //*************************************************************************************************************************************************//
        private void button1_Click_1(object sender, EventArgs e)
        //*************************************************************************************************************************************************//
        {
            clearscreen();
        }
        //*************************************************************************************************************************************************//
        public void clearscreen()
        //*************************************************************************************************************************************************//
        {
            /*                  // Bank account fields //
                            * 		  internal Int32 BankAccountNumber = 0;	  // Secondary key
                                    internal Int32 CustAccountNumber = 0; // major key
                                    internal Int16 AccountType = 0;        // minor key
                                    internal decimal Balance = 0.00;
                                    internal DateTime DateOpened;
                                    internal DateTime DateClosed;// We do not fill this out.
                                    internal decimal  InterestRate = 3.75;    // Default value only
                                    internal Int16 Status = 1; // Status can be 0-Closed, 1- Active, 2-Suspended     
            */
            Custno.Text = "";
            day.Text = "";
            month.Text = "";
            year.Text = "";
            fname.Text = "";
            lname.Text = "";
            day.Text = "";
            month.Text = "";
            year.Text = "";
            Interest.Text = "";
            AccountBalance.Text = "";
            addr1.Text = "";
            addr2.Text = "";
            town.Text = "";
            county.Text = "";
            postcode.Text = "";
            phone.Text = "";
            mobile.Text = "";
            addr1.Text = "";
            addr1.Text = "";
            AccountNo.Text = "123";
            allbankaccounts.Items.Clear();
            OpenDate.Text = "";
            AccountType.SelectedIndex = 0;
            status.Text = "";
        }
        //*************************************************************************************************************************************************//
        private void Exit_Click_1(object sender, EventArgs e)
        //*************************************************************************************************************************************************//
        {   // tidy up after ourselves
//            Bank.Dispose();
   //         Cust.Dispose();
            this.Close();
        }

        private void allbankaccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get bank account for selected bank
            if (!listupdateneeded) return;
            Int32 currsel = 0;
            string temp = allbankaccounts.SelectedItem.ToString();
            char[] ch = { '\t' };
            string[] x = temp.Split(ch);
            currsel = Convert.ToInt32(x[0]);
            // call the Find click event directly
            BankAccount Bank = DataArray.ArrayGetBank(currsel);
            if (Bank == null)
            { MessageBox.Show("ERROR ENCOUNTERED - Bank account found does not match ", "Data Processing Error"); return; }
            // Display the bank data
            AccountBalance.Text = Bank.Balance.ToString();
            Interest.Text = Bank.InterestRate.ToString();
            int indx = Convert.ToInt16(x[1]);
            AccountType.SelectedIndex = indx - 1;
        }
    }
}

