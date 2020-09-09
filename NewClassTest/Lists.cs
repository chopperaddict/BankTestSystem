using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

//using System.Data.SqlClient;
// MOST IMPORTANT FILE
// This will handle keeping the data in Lists[] for BankAccount, CustomerAccount and any others required
// and will provide it on demand to all other classes, so it must mostly contain public methods
namespace ClassAccessTest
{
    public class Lists
    {
        // Get new lists that are publically accessible
        // Save all our customer objects from our linkedList
        public static void SaveAllCustomerListData (string file)
        //************************************************************************************************************************************************//
        {
            // We only store partial customer data in this file.
            String str = "";
            // serialize the Customerlist
            foreach ( var Item in Customer.CustomersLinkedList )
            {
                // Now get on & serialize it
                str += Item.CustomerNumber + "\r\n" + Item.FirstName + "\r\n" + Item.LastName + "\r\n" + Item.PhoneNumber + "\r\n" + Item.MobileNumber + "\r\n" + Item.FullFileName + "\r\n";
            }
            // Call our generic  to save data to file in binary format
            SerializeData.Serialize ( str, file );
            string path = Customer.GetCustFilePath ( ) + "TextFiles\\CustLinkedListData.txt";
            File.WriteAllText ( path, str );
        }

        //************************************************************************************************************************************************//
        public static void SaveAllBankAccountListData ( )
        //************************************************************************************************************************************************//
        {
            // serialize the Bankaccountlist
            // null our string out again
            string Filename = BankAccount.ReadBankFilePath ( ) + "BankAccountListData.bnk";
            string record = "";
            StringBuilder SBdata = new StringBuilder ( );
            // THIS CREATES A  NEW FILE ON DISK FOR EACH OF THE BANK ACCOUNTS IN OUR LINKEDLIST
            // We "could" recreate all existing bank accounts from this fileif we have a valid LinkedList file !!
            // we build a very large string, then pass it to our generic serialize Fn() to save to disk
            foreach ( BankAccount Item in BankAccount.BankAccountsLinkedList )
            {
                // Now serialize it
                SBdata.Append ( Item.AccountType + "\r\n" );        // minor key
                SBdata.Append ( Item.CustAccountNumber + "\r\n" ); // major key
                SBdata.Append ( Item.Balance + "\r\n" );
                SBdata.Append ( Item.DateOpened.ToShortDateString ( ) + "\r\n" );
                SBdata.Append ( Item.DateClosed.ToShortDateString ( ) + "\r\n" );   // We do not fill this out.
                SBdata.Append ( Item.InterestRate + "\r\n" );    // Default value only
                SBdata.Append ( Item.Status + "\r\n" ); // 
                                                        //					SBdata.Clear();
                record += Item.AccountType.ToString ( ) + "," + Item.CustAccountNumber.ToString ( ) + "," + Item.BankAccountNumber.ToString ( ) + "," + Item.Balance.ToString ( )
                                                    + "," + Item.DateOpened.ToShortDateString ( ) + "," + Item.DateClosed.ToShortDateString ( ) + "," + Item.InterestRate.ToString ( ) + "," + Item.Status.ToString ( ) + "\r";
            }
            SerializeData.SBSerialize ( SBdata, Filename );
            SBdata.Clear ( );
            // This writes the std string [record] out in text format to the \\textfiles folder
            SaveBankAccountListDateToText ( record );
        }

        //************************************************************************************************************************************************
        public static void ReWriteBankLinkedList ( )
        //************************************************************************************************************************************************
        {
            // iterate thru bankaccount objects and add threm to our linkedList
            string dir = BankAccount.ReadBankFilePath ( );

            string[] files = System.IO.Directory.GetFiles ( dir, "*.bnk" );
            // iterate thru all the files on disk, startinmg at 1
            // Iterate trhu them and handle as required
            int count = 0;
            foreach ( var fi in files )
            {
                bool result = fi.Contains ( "BankObject" );
                if ( !result )
                    continue;
                {
                    using
                    BankAccount B = ( BankAccount ) SerializeData.ReadBankAccountFromDisk ( fi );

                    // As we have red it in, we need to delete it so we do not 
                    // duplicate it when saving all files at end of a user sessoin.
                    if ( B != null )
                    {
                        BankAccount.BankAccountsLinkedList.AddLast ( B );  // Add this one to our linked list of customers.
                        BankTransaction newbankaccount = new BankTransaction ( B.DateOpened, B.AccountType, B.CustAccountNumber,
                                                                                      B.BankAccountNumber, B.Balance, "Customer account updated successfuly", B.Status );
                        BankTransaction.allBankTransactions.AddLast ( newbankaccount );
                    }
                    count++;
                }
            }
            // save linked list to disk in text format
            Lists.SaveAllBankAccountListData ( );
        }

        public static int RebuildBankListFromText ( )
        {
            int count = 0;
            string fi = BankAccount.ReadBankFilePath ( ) + "Textfiles\\BankAccountListData.txt";
            if ( File.Exists ( fi ) )
            {
                string input = File.ReadAllText ( fi );       // you gotta delete them first, else it appends the data constantly
                char[] ch1 = { '\r' };
                char[] ch2 = { ',' };
                string[] record = input.Split ( ch1 );
                for ( int i = 0; i < record.Length; i++ )
                {
                    string str = record[i];
                    string[] Item2 = str.Split ( ch2 );
                    if ( record.Length < 6 )
                        break;
                    for ( int x = 0; x < record.Length; x++ )
                    {
                        // get a sring from string[] array Item1[]
                        BankAccount B = new BankAccount ( );
                        if ( B != null )
                        {
                            B.AccountType = Convert.ToInt16 ( Item2[x] );
                            B.CustAccountNumber = Convert.ToInt32 ( Item2[x + 1] );
                            B.Balance = Convert.ToInt32 ( Item2[x + 2] );
                            B.DateClosed = Convert.ToDateTime ( Item2[x + 3] );
                            B.InterestRate = Convert.ToDecimal ( Item2[x + 5] );
                            B.Status = Convert.ToInt16 ( Item2[x + 6] );
                            B.Status = Convert.ToInt16 ( Item2[x + 6] );
                            BankAccount.BankAccountsLinkedList.AddLast ( B );  // Add this one to our linked list of customers.
                            count++;
                            break;
                        }
                    }
                    // save linked list to disk in text format
                    Lists.SaveAllBankAccountListData ( );
                }
            }
            return count;
        }
        public static int RebuildBankListsFromText ( )
        {
            int count = 0;
            string fi = BankAccount.ReadBankFilePath ( ) + "Textfiles\\BankAccountListData.txt";
            if ( File.Exists ( fi ) )
            {
                string input = File.ReadAllText ( fi );       // you gotta delete them first, else it appends the data constantly
                char[] ch1 = { '\r' };
                char[] ch2 = { ',' };
                //				char [ ] ch3 = { '~' };
                string[] record = input.Split ( ch1 );
                string[] BAccts;

                DataArray.ArrayClearBank ( );
                BankAccount.BankAccountsLinkedList.Clear ( );
                // record now has an array of strings that were split on \t
                // this means we should have at least one, possibly multiple  B.Accs  in the last element
                // iterate through and split these out of record into string[] Item2
                for ( int i = 0; i < record.Length; i++ )
                {
                    string str = record[i];
                    //This should give us x strings,, the first one can be ignored
                    //, the rest will be bank account numbers cos the format is  "xxxxxx,xxxx,yyyy,~4455554544~65645
                    // and we are after the data immediately past the first ~
                    string[] Item2 = str.Split ( ch2 );
                    // check.  The plit always gives us ~ONE element, even though it is empty
                    if ( Item2.Length == 1 && Item2[0].Length == 0 )
                        break;	// Were all done here
                    BAccts = Item2[7].Split ( '~' );
                    // go get em (one or more B Accts in a BAccts[] string[]					
                    if ( BAccts.Length > 1 )
                    {   // got one or more - do something with them ?
                    }
                    //Baacts MAY contain a leading EMPTY string, so beware
                    // by here , we have an array of strings of Bank accounts owned by this customer. ?
                    for ( int x = 0; x < record.Length; x++ )
                    {
                        // get a string from string[] array Item1[]
                        BankAccount B = new BankAccount ( );
                        if ( B != null )
                        {
                            B.AccountType = Convert.ToInt16 ( Item2[x] );
                            B.CustAccountNumber = Convert.ToInt32 ( Item2[x + 1] );
                            B.BankAccountNumber = Convert.ToInt32 ( Item2[x + 2] );
                            B.Balance = Convert.ToDecimal ( Item2[x + 3] );
                            B.DateClosed = Convert.ToDateTime ( Item2[x + 4] );
                            B.InterestRate = Convert.ToDecimal ( Item2[x + 6] );
                            // We dont seem to save this ?????
                            B.Status = 1;
                            BankAccount.BankAccountsLinkedList.AddLast ( B );  // Add this one to our linked list of customers.
                            DataArray.ArrayAddBank ( B );
                            SerializeData.WriteBankAccountToDiskAndText ( B, fi );
                            count++;
                            break;
                        }
                    }
                    // save linked list to disk in text format
                    Lists.SaveAllBankAccountListData ( );
                }
            }
            return count;
        }

        // Called on CLOSEDOWN
        public static void SaveBankAccountListDateToText (string listdata)
        {
            if ( listdata.Length > 0 )
            {
                string fi = BankAccount.ReadBankFilePath ( ) + "Textfiles\\BankAccountListData.txt";
                if ( File.Exists ( fi ) )
                    File.Delete ( fi );       // you gotta delete them first, else it appends the data constantly
                File.AppendAllText ( fi, listdata );
            }
        }

        public static void ParseCustSortedListText (string custfilesfromtext)
        {
            // this data is separated by "\t"'s, so lets go
            char[] ch = { '\t' };
            char[] charstrings = { ',' };
            string[] str = custfilesfromtext.Split ( ch );
            /*FORMAT of data is 
				 * v . Key . ToString ( ) + "," + v . Value . CustomerNumber . ToString ( ) + "," + v . Value . LastName + "," + v . Value . FirstName + "," + v . Value . Address1 + ","
				+ v . Value . Address2 + "," + v . Value . Town + "," + v . Value . County + "," + v . Value . PostCode + "," + v . Value . PhoneNumber + "," + v . Value . MobileNumber
				+ "," + v . Value . DOB . ToShortDateString ( ) + "," + v . Value . accountnums [ 0 ] . ToString ( ) + "," + v . Value . accounttypes [ 0 ] . ToString ( ) + ","
				+ v . Value . accountnums [ 1 ] . ToString ( ) + "," + v . Value . accounttypes [ 1 ] . ToString ( ) + "," + v . Value . accountnums [ 2 ] . ToString ( ) + ","
				+ v . Value . accounttypes [ 2 ] . ToString ( ) + "," + v . Value . accountnums [ 3 ] . ToString ( ) + "," + v . Value . accounttypes [ 3 ] . ToString ( )  + Filrename + Fullfilename
			+ "\t";*/
            //			for ( int i = 1 ; i < stringarray . Length ; i += 18) // one entry uses 18 separate elements in stringarray[]
            foreach ( string s in str )
            {
                int i = 0;
                string[] stringarray = s.Split ( charstrings );
                if ( stringarray.Length == 1 ) break;
                Customer C = new Customer ( );
                C.CustomerNumber = Convert.ToInt32 ( stringarray[i] );
                C.FirstName = stringarray[i + 1];
                C.LastName = stringarray[i + 2];
                C.Address1 = stringarray[i + 3];
                C.Address2 = stringarray[i + 4];
                C.Town = stringarray[i + 5];
                C.County = stringarray[i + 6];
                C.PostCode = stringarray[i + 7];
                C.PhoneNumber = stringarray[i + 8];
                C.MobileNumber = stringarray[i + 9];
                C.DOB = Convert.ToDateTime ( stringarray[i + 10] );
                C.accountnums[0] = Convert.ToInt32 ( stringarray[i + 11] );
                C.accounttypes[0] = Convert.ToInt16 ( stringarray[i + 12] );
                C.accountnums[1] = Convert.ToInt32 ( stringarray[i + 13] );
                C.accounttypes[1] = Convert.ToInt16 ( stringarray[i + 14] );
                C.accountnums[2] = Convert.ToInt32 ( stringarray[i + 15] );
                C.accounttypes[2] = Convert.ToInt16 ( stringarray[i + 16] );
                C.accountnums[3] = Convert.ToInt32 ( stringarray[i + 17] );
                C.accounttypes[3] = Convert.ToInt16 ( stringarray[i + 18] );
                C.FileName = stringarray[i + 19];
                C.FullFileName = stringarray[i + 20];
            }
        }
        //*******************************************************************************************************************************************
        public static SortedList<string, string> GetAscendingSortedHashTable (Hashtable Dict)
        //*******************************************************************************************************************************************
        {
            var ascendingComparer = Comparer<string>.Create ( (x, y) => x.CompareTo ( y ) );
            SortedList<string, string> ascSortedList1 = new SortedList<string, string> ( ascendingComparer );
            foreach ( DictionaryEntry H in Dict )
            {
                ascSortedList1.Add ( H.Key.ToString ( ), H.Value.ToString ( ) );
            }
            return ascSortedList1;
        }

        public static string ListAllBankTransactions ( )
        //**********************************************************************************************************//
        {
            var report = new System.Text.StringBuilder ( );
            int count = 0;
            if ( BankTransaction.allBankTransactions == null ) return "";
            report.AppendLine ( "There are " + BankTransaction.allBankTransactions.Count + " Bank Transaction records :-" );
            report.AppendLine ( "Account #  \t Date\t\t\tType\t          Amount" );
            foreach ( var item in BankTransaction.allBankTransactions )
            {
                // This gets the amount ion correct currency format with £ sign and everything else required via Localization....
                string CurrencyAmount = Utils.GetCurrencyString ( item.Transamount.ToString ( ) );
                report.AppendLine ( item.CustAccountNumber + "\t\t " + item.TransDate.ToString ( ) + "\t" + item.AccountType + "\t          " + CurrencyAmount );
                report.AppendLine ( "Reason :- " + item.Notes );
                count++;
            }
            report.AppendLine ( "====================================================================================\r\n" );
            return report.ToString ( );

        }
        public static BankAccount FindBankFromLinkedList (BankAccount Bank)
        {
            bool success = false;
            BankAccount Bk = new BankAccount ( ); ;
            foreach ( BankAccount b in BankAccount.BankAccountsLinkedList )
            {
                if ( b.BankAccountNumber == Bank.BankAccountNumber )
                { success = true; Bk = b; break; }
            }
            if ( success )
                return Bk;
            else
                return null;
        }

        //**********************************************************************************************************//*
        /*		public static int RebuildBankLinkedList ( )
				//************************************************************************************************************************************************
				{
					// iterate thru reading bankaccount objects from disk and add them to our linkedList
					int count = 0;
					//			DataArray . BankNo . Initialize ( );
					BankAccount . BankAccountsLinkedList . Clear ( );
					foreach ( BankAccount B in DataArray . BankNo )
					{
						if ( B != null )
						{
							try
							{
								count++;
								BankAccount . BankAccountsLinkedList . AddLast ( B );
								//						DataArray . BankAdd ( B );
							}
							catch { }
							new Exception ( " Failed to update LinkedList in RebuildBankLists at line 399" );
						}
						B . Dispose ( );
					}
					return count;
				}
		*/
    }
}
