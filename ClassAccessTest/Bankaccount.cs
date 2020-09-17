using Amazon.Runtime.Internal.Util;

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

/* THIS IS THE BANKACCOUNT'S CLASS SOURCE FILE
*/

namespace ClassAccessTest
{
    [Serializable]
    public class BankAccount : IDisposable, IComparable<BankAccount>, IComparer<BankAccount>, Interface1
    {
        //******BANK ACCOUNT STRUCTURE*************//
        internal Int32 BankAccountNumber { get; set; }     // Secondary key
        internal Int32 CustAccountNumber { get; set; } // major key
        internal Int16 AccountType { get; set; }        // minor key
        internal decimal Balance { get; set; }
        internal DateTime DateOpened { get; set; }
        internal DateTime DateClosed { get; set; }// We do not fill this out.
        internal decimal InterestRate { get; set; }// Default value only
        internal Int16 Status { get; set; } // Status can be 0-Closed, 1- Active, 2-Suspended

        // global variables
        readonly static string BankFilePath = "C:\\Users\\ianch\\source\\C#SavedData\\BankAccounts\\";
        private static Int16 TotalBanks = 0;
        private static Int32 BankAccountNumberSeed = 1050000;
        private static Int16 BankFileNumberSeed = 0;
        internal string FullFileName = "";
        internal string FileName = "";
        //*********************************************************//

        // our only Linked List to hold BankAccount objects
        // Accessed outside this file as LinkedList.BankAccountsList.AddLast(); 
        //public static LinkedList<BankAccount> BankAccountsLinkedList;
        public static LinkedList<BankAccount> BankAccountsLinkedList = new LinkedList<BankAccount>();    // Bank a/c list
                                                                                                         // Enumeration for the above  LinkedList
        public static LinkedList<BankAccount>.Enumerator BankLListEnum = new LinkedList<BankAccount>.Enumerator();
        //		public static SortedList<Int32, BankAccount> SortedBankAccounts;
        public static string ReadBankFilePath() { return BankFilePath; }

        public static Int32 GetBankAccountNumberSeed() { return BankAccountNumberSeed++; }
        public static Int32 ReadBankAccountNumberSeed() { return BankAccountNumberSeed; }
        internal static void SetBankAccountNumberSeed(Int32 custno) { BankAccountNumberSeed = custno; }
        public static Int16 GetBankFileNumberSeed() { return BankFileNumberSeed++; }
        public static void SetBankFileNumberSeed(Int16 newseed) { BankFileNumberSeed = newseed; }
        public static Int16 ReadBankFilenumber() { return BankFileNumberSeed; }
        public static Int16 IncrementTotalBanks() { return TotalBanks++; }
        public static void SetTotalBanks(short newval) { TotalBanks = newval; }
        public static Int16 ReadTotalBanks() { return TotalBanks; }

        public static int GetAccountType(BankAccount bank) { return bank.AccountType; }
        //We will create a new Transaction instance for all deposits & withdrawls, including initial opening depost
        protected decimal m_Value = 0.00M;
        public static Dictionary<Int32, BankAccount > BankDict = new Dictionary<Int32, BankAccount>();

		public BankAccount ()
		{
			Bank_Load(this, null);
		}
		// **************** Events ****************************
		public static event EventHandler<string> BankArrayChangedEvent;
        public static event EventHandler<string> BankListChangedEvent;
        public static void BankAccountEvents()
        {
            BankArrayChangedEvent += BankAccount_BankArrayChangedEvent;
            BankListChangedEvent += BankAccount_BankListChangedEvent;
        }

		public int CompareTo (BankAccount obj)
		{
			BankAccount other = obj;
			if ( BankAccountNumber < other.BankAccountNumber )
				return -1;
			else if ( BankAccountNumber > other.BankAccountNumber )
				return 1;
			else
				return 0;
		}
		public int Compare (BankAccount x, BankAccount y)
		{
			BankAccount first = (BankAccount)x;
			BankAccount second = (BankAccount) y;
			return first.BankAccountNumber - second.BankAccountNumber;
		}
		private void Bank_Load (object sender, EventArgs e)
		{
		}
		public static void BankAccount_BankListChangedEvent(object sender, string e)
        {
            // We usually receive the bank object in sender, so we can extraplate our info.
            string str = "";
            if (e == "NEW BANKACCOUNT")
            {    // new bank account created
                BankAccount B = (BankAccount)sender;
                if (B != null)
                {
                    str = "A new Bank Account has been created, A/.C # = " + B.BankAccountNumber.ToString() + "\r\n";
                    str += "Customer (Owner) is A/C # " + B.CustAccountNumber + " & Opening balance is " + B.Balance.ToString() + "\r\n";
                }
                else
                {
                    str = "A new Bank Account has been created, A/.C # , but the bank object was not returned ?\r\n";
                }
                Logger.WriteLog(str, 1);
                Bank.form1.ShowText(str, null, -1);
            }
        }

        private static void BankAccount_BankArrayChangedEvent(object sender, string e)
        {
            // We usually receive the bank object in sender, so we can extraplate our info.
            string str = "";
            string typestr = "";
            if (e == "NEW BANKACCOUNT")
            {    // new bank account created
                BankAccount B = (BankAccount)sender;
                if (B.AccountType == 1)
                    typestr = "[Normal]";
                else if (B.AccountType == 2)
                    typestr = "[Savings]";
                else if (B.AccountType == 3)
                    typestr = "[Deposit]";
                else if (B.AccountType == 4)
                    typestr = "[Business]";
                str = "A new " + typestr + " Bank Account [" + B.BankAccountNumber.ToString() + "] has been created.\r\n";
                str += "The Customer (Owner) is A/C # " + B.CustAccountNumber + " & Opening balance is " + B.Balance.ToString() + "\r\n";
            }
            else if (e == "") {  
            }
            Logger.WriteLog(str, 1);
            Bank.form1.ShowText(str, null, -1); 
        }

        public string FullInfo
        {get		{return $"{BankAccountNumber} {CustAccountNumber} ({Balance})";}
        }

        public void CheckBank(Int32 accno) { }
        public void CheckCustomer(Int32 accno) { }
        // implementation of Sort() using the M$ Interface stuff

        //****************************************************************************************************************************
        // following is just to allow me to kill objects on demand
        //private bool _disposed = false;
        // should receive false if called from a "Finalizer" but true if called from IDisposable.Dispose(true) method
        // I call it using {    Dispose(true);   }
        //*********************************************************************************************************************************************************************
        protected virtual void Dispose(bool disposing)
        //*********************************************************************************************************************************************************************
        {
            if (disposing) { }//ree memory , unmanaged resources etc etc.
        }
        // This is the Fn we call to delete the object !!
        //*********************************************************************************************************************************************************************
        public void Dispose()
        //*********************************************************************************************************************************************************************
        {
            // Dispose of unmanaged resources.
//            Dispose(true);
            // Suppress finalization.
//            GC.SuppressFinalize(this);
        }
        //****************************************************************************************************************************
        // this handles making a deposit call. creating the unique a/c #...
        // and creates a transaction record, and adds it to the linkedlist
        //**********************************************************************************************************//
        public static BankAccount CreateNewBankAccount(BankAccount bank, string CustNo, Int16 accounttype, decimal amount, decimal interest, string reason = "")
        //**********************************************************************************************************//
        {
            // create unique account number and set it in the account.
            bank.BankAccountNumber = GetBankAccountNumberSeed();// this post increments it's value internally
            bank.CustAccountNumber = Convert.ToInt32(CustNo);
            bank.Balance = amount;
            bank.AccountType = accounttype;
            bank.DateOpened = DateTime.Today.Date;
            bank.InterestRate = interest;
            // 
            //This call increments the file numbering seed data
            bank.FileName = "BankObject" + bank.BankAccountNumber + ".bnk";
            // add full filename to the object            
            bank.FullFileName = BankAccount.ReadBankFilePath() + bank.FileName;

            //This call increments the total banks seed data
            // Even though we do NOT need its content here.
            IncrementTotalBanks();

            // Ensure we save the file to disk for the Bank  object itself
            SerializeData.WriteBankAccountToDiskAndText(bank, bank.FullFileName);

            BankTransaction newbankaccount = new BankTransaction();
            newbankaccount.TransDate = DateTime.Now;
            newbankaccount.AccountType = bank.AccountType;
            newbankaccount.CustAccountNumber = bank.CustAccountNumber;
            newbankaccount.BankAccountNumber = bank.BankAccountNumber;
            newbankaccount.Transamount = (decimal)bank.Balance;
            if (reason == "")
                newbankaccount.Notes = "Opening Balance";
            else
            {
                if (reason.Contains("Secondary Bank account  for Customer"))
                    reason += bank.BankAccountNumber.ToString();
                newbankaccount.Notes = reason;
            }
            newbankaccount.Status = bank.Status;
            // Add a transaction record
            BankTransaction.allBankTransactions.AddLast(newbankaccount);
            BankAccountsLinkedList.AddLast(bank);
            DataArray.ArrayAddBank(bank);
			// Update our new Dictionary system
			if (BankAccount.BankDict != null)
			{
				if ( !BankAccount.BankDict.ContainsKey (bank.BankAccountNumber) )
					BankAccount.BankDict.Add (bank.BankAccountNumber, bank);
			}
            // This saves the bank LinkedList to both an object file and a Text file
			Lists.SaveAllBankAccountListData();

            //Add data ot our TWO hash tables
            // First the Customer hash tables
            try
            {
                if (CustomerBalanceHashTable.FindHashCustBalEntry(bank.CustAccountNumber.ToString()))
                    CustomerBalanceHashTable.DeleteHashCustBalEntry(bank.CustAccountNumber.ToString());
                CustomerBalanceHashTable.AddHashCustBalEntry(bank.CustAccountNumber.ToString(), bank.Balance);

                if (CustomerFileHashTable.CustFileNoHashTable.ContainsKey(bank.CustAccountNumber))
                    CustomerFileHashTable.CustFileNoHashTable.Remove(bank.CustAccountNumber.ToString());
                CustomerFileHashTable.CustFileNoHashTable.Add(bank.CustAccountNumber.ToString(), bank.FullFileName.ToString());
            }
            catch
            {

            }
            BankArrayChangedEvent?.Invoke(bank, "NEW BANKACCOUNT");
            return bank;
        }

        public static void SendBankEventData(BankAccount B, string info)
        {
            if (B != null)
            {if(info == "BANKACCOUNT MODIFIED")
                {   BankAccount_BankListChangedEvent(B, info);}}
            else
            { BankAccount_BankListChangedEvent(null, info); }
        }

       //*******************************************************************************************//
        public static bool DeleteBankAccount(string accountNo)
        //**********************************************************************************************************//
        {
            bool result = false;
            //First we need the relevant bank account object
            foreach (var Bank in BankAccountsLinkedList)
            {
                // check for matching AccountNumber in each BankAccount Object
                if (Bank.CustAccountNumber == Convert.ToInt32(accountNo))
                {   // Found the BankAccount object we want to close
                    // first, remove it from the LinkedList
                    BankAccountsLinkedList.Remove(Bank);
                    // now do the bankno array
                    int index = DataArray.ArrayFindBank(Bank);                    
                   DataArray.BankNo.RemoveAt(index);
                   // Update our new Dictionary system
				   if(BankDict != null)
					BankDict.Remove (index);
                   
					 // Then delete the bank object itself
					//                    Bank.Dispose();
					// Finally,we need to add a transactions record for this account
					BankTransaction bt = new BankTransaction();
                    bt.TransDate = DateTime.Now;
                    bt.AccountType = 9;
                    bt.CustAccountNumber = Convert.ToInt32(accountNo);
                    bt.BankAccountNumber = Bank.BankAccountNumber;
                    bt.Transamount = 0;
                    bt.Notes = "Account has been closed";
                    bt.Status = 2;  // closed

                    BankTransaction.allBankTransactions.AddLast(bt);
                    result  = true;
                   	//Trigger our event
                    BankListChangedEvent?.Invoke(Bank, "BANKACCOUNT DELETED");
                    break;
                 }
            }
            if (!result)
            {
                MessageBox.Show("Failed to delete the entry from the Transactions list...");
                return false;
            }
            else
                return true;
        }
        //***************************************************************************//
        public static bool VerifyAccountExists(string AccountNumber)
        //***************************************************************************//
        {
            bool result = false;
            Int32 acno = Convert.ToInt32(AccountNumber);
            foreach (var Bank in BankAccountsLinkedList)
            {
                if (Bank.CustAccountNumber == acno) { result = true; break; }
            }
            return result;
        }

        public static bool MarkBankAccountClosed(string AccountNumber)
        //***************************************************************************//
        {
            bool result = false;
            Int32 acno = Convert.ToInt32(AccountNumber);

            //			   foreach (var Bank in BankAccountsLinkedList)
            // Here we have substituted Direct Enumeration via our file wide public static GetEnumerator method 
            // This is usually much faster	
            LinkedList<BankAccount>.Enumerator BankLListEnum = new LinkedList<BankAccount>.Enumerator();
            while (BankLListEnum.MoveNext())
            {
                BankAccount Bank = BankLListEnum.Current;
                if (Bank.CustAccountNumber == acno)
                {   // Found th eone we want to close
                    Bank.DateClosed = DateTime.Now;
                    Bank.Status = 0;    // signals it is now closed 1= active, 2=Suspended
                    result = true;
                    BankListChangedEvent?.Invoke(Bank, "BANKACCOUNT CLOSED");
                    break;
                }
                else
                    break;

            }
            return result;
        }

        //******************************************************************************************//
        // called from Deposit and withdrawl only so far  to update BankACcount LinkedList
        // This automatically updates the current Bank account Balance, so beware of doing it again elsewhere
        public static bool UpdateBankLinkedList(Int32 Bankno, decimal deposit)
        {
            bool result = false;
            foreach (var B in BankAccount.BankAccountsLinkedList)
            {
                if (B.BankAccountNumber == Bankno)
                {   // got it
                    BankAccount.BankAccountsLinkedList.Remove(B);
                    B.Balance += deposit;
                    BankAccount.BankAccountsLinkedList.AddLast(B);
                    // This saves the bank LinkedList to both an object file and a Text file
                    Lists.SaveAllBankAccountListData();
                    BankListChangedEvent?.Invoke(B, "DEPOSIT");
                    result = true;
                    break;
                }
            }
            return result;
        }
        //******************************************************************************************//

        //************************************************************************************************************************************************
        public static int RebuildBankLinkedListFromObjects()
        //************************************************************************************************************************************************
        {
            // iterate thru reading bankaccount objects from disk and add them to our linkedList
            int count = 0;
            string dir = ReadBankFilePath();
            string[] files = Directory.GetFiles(dir, "*.bnk");
            // clear the lists- JIC
            DataArray.ArrayClearBank();    // Clear ( );
            foreach (var fi in files)
            {
                bool result = fi.Contains("BankObject");
                if (!result)
                    continue;
                {
                    BankAccount B = SerializeData.ReadBankAccountFromDisk(fi);
                    //BankAccount B = directories . GetBankObjectFromPath ( fi );
                    // add each one to our new List so we cna use the Enumeration later
                    if (B != null)
                    {
                        try
                        {
                            count++;
                            BankAccountsLinkedList.AddLast(B);
                            DataArray.ArrayAddBank(B);
                            if (BankAccount.BankDict != null)
                            {
	                            if (!BankAccount.BankDict.ContainsKey( B.BankAccountNumber ))
		                            BankAccount.BankDict.Add( B.BankAccountNumber, B );
                            }
                        }
						catch { }
                        new Exception(" Failed ot update LinkeList of sortedlist in RebuildCustLinkedList atliner 366");
                    }
                    B.Dispose();
                }
            }
            // This saves the bank LinkedList to both an object file and a Text file
            Lists.SaveAllBankAccountListData();
            BankListChangedEvent?.Invoke(null, "ALLDATA REBUILT FROM OBJECTS");
            return count;
        }
        
        public static void SaveAllBankAccountsToDiskAndText()
        {
            foreach (BankAccount B in DataArray.BankNo)
            {
                SerializeData.WriteBankAccountToDiskAndText(B, B.FullFileName);
            }
        }
    }   // end class
}   // END of namespace
