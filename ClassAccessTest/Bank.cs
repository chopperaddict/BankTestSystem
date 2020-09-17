// we HAVE to put or #defines up here
#define SHOWCUSTDATATWICE
#undef SHOWCUSTDATATWICE

#define DODELETEOFCUSTOMERS
#undef DODELETEOFCUSTOMERS

#define DODELETEOFBANKACCOUNTS
#undef DODELETEOFBANKACCOUNTS

//using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
/*
  This project is being used to test Class access methodology in some detail.
    I will use Public, Private, Internal, Static and all combinations to see what 
    access is possible with what combinations.

    THIS IS THE MAIN WINDOW's SOURCE FILE

 * */

namespace ClassAccessTest
{
    public partial class Bank : Form
    {
        public const Int32 V = 1050000;

        public const string TerminatorText = "---------------------------------------------------------------------------------------\r\n";
        // All sorted normally
        public static int _badirection = 0;
        public static int _bldirection = 0;
        public static int _cadirection = 0;
        public static int _cldirection = 0;
        public static Control ctrl = new Control ( );
        public static Control fc;
        public static string[] ControlArray = new string[50];
#pragma warning disable CS0649 // Field 'Bank.sortarray' is never assigned to, and will always have its default value null
        internal static SortArray sortarray;
#pragma warning restore CS0649 // Field 'Bank.sortarray' is never assigned to, and will always have its default value null
        public static Bank form1;
        //		public static Form form1;
        //		public IntPtr intptr;
        public IntPtr Inp;
#pragma warning disable CS0169 // The field 'Bank.CC' is never used
        //		Control . ControlCollection CC;
#pragma warning restore CS0169 // The field 'Bank.CC' is never used
        public static bool Startup = true;

        private static int _exporttype = 0;

		//        public static Dictionary<Int32, Customer> CustDictionary = new Dictionary<Int32, Customer> ();
		//        public static Dictionary<Int32, BankAccount> BankDictionary = new Dictionary<Int32, BankAccount> ();

//		public Delegate void SQLDataHandler(string);
//		public event SQLDataHandler  MySQLReceived;

	    public  delegate void MySQLReceived( string datain);
		//*******************************************************************************************************//
		//									THIS IS SINGLETON SUPPORT CODE
		//*******************************************************************************************************//

		// heres our declaration of the Delegate
		/*		public delegate void HelloFunctionDelegate (string Message);

*/
/*		private void MySQLReceived(string s){
			MessageBox . Show ( "In MySQLReceived Delegate handler..." );
		}
	  */
		private void Rundelegate_Click( Bank b , string s)
		{
			MessageBox.Show("In Rundelegate_Click");
		}
/*        {
            // This DOES create a valid Delegate object - should then be available globally

            HelloFunctionDelegate del = new HelloFunctionDelegate ( Hello );
            del ( "Hello from Delegate, here the called function processing a For() loop\r\n" );
        }
    */    //*******************************************************************************************************//
        //									END OFSINGLETON SUPPORT CODE
        //*******************************************************************************************************//

        // EVENT HANDLERS **********************************************

        public Bank ( )
        //*********************************************************************************//
        {
            InitializeComponent ( );
            Cursor = Cursors.WaitCursor;
            form1 = this;//refering to the current Bank
        }
        //**************************************************************************************************************************//
        public static int GetExportType ( ) { return _exporttype; }
        public static void SetExportType (int val) { _exporttype = val; }
        //*******************************************************
        public static void Hello (string strMessage)
        {
            //*******************************************************
            //			Console . WriteLine ( strMessage );
            for ( int i = 0; i < 1000; i++ )
            {
                if ( i % 10 == 0 )
                {
                    Bank.form1.Output2.AppendText ( "Delegate reporting our loop counter of " + i.ToString ( ) + "\r\n" );
                }
            }
            Bank.form1.Output2.AppendText ( " Thats it, all done......\r\n" );

//            SQLConnector.sqloutputform.Data.Text += "££££";

        }

        //**************************************************************************************************************************//
        //**************************************************************************************************************************//

        private void Bank_Load (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            Output2.AppendText ( "Welcome to the C# Bank Account Test System in development as we speak by Ian Turner !!\r\n" );
            // read our various static globals from disk & set them up again in the Application
            // if it doesn't exist, we rebuild it automatically to default values
            ConfigData.ReadConfigData ( );
            Output2.AppendText ( "System configuration data loaded successfully...\r\n" );

            // here we go, now get ALL the Customer data back in from disk
            // Now, lets discover exactly how many customer objects we have
            //this loads the Customer  hastable only with customers but NOT the Sorted Array
            // This loads the CustomerFileHashTable, which we do later, so ignore this
            var totalcusts = Customer.VerifyCustomerDataFiles ( "*.cust" );
            Customer.SetTotalCustomers ( Convert.ToInt16 ( totalcusts ) );
            Output2.AppendText ( "Customer accounts verified successfully...\r\n" );
            // just for testing  27.8.2019
            //			StringBuilder custfiles = Customer . ReadCustSortedListFromText ( );
            //			string custfilesfromtext = custfiles . ToString ( );
            //			Lists . ParseCustSortedListText ( custfilesfromtext );
            // load both the hash tables from disk
            CustomerBalanceHashTable.LoadHashCustBalTable ( );
            CustomerFileHashTable.LoadCustHashFileTableFromDisk ( );
            Output2.AppendText ( "Both Hash tables loaded successfully......\r\n" );
            // here we go, now get ALL the BankAccount data back in from disk
            // We Load all our bank accounts into the BankAccount.LinkedList
            // And the Customers into the Customer LinkedList

            // create our bank transactions list
            BankTransaction.allBankTransactions = new LinkedList<BankTransaction> ( );
            // first we load the bank transactions file off Binary Obj file from disk.
            // and parse it into our Transactions system
            int count = BankTransaction.RebuildBankTransactions ( );
            //			 This loads the bank transactions file off TXT file from disk. - used as a backup ???
            //			int count = BankTransaction . BuildBankTransactionsFromTextfile ( );
            Output2.AppendText ( "There are " + count.ToString ( ) + " Bank Transactions loaded from the Binary File successfully...\r\n" );

            // load our new ArrayList's system with data via all OBJ files
            DataArray Dataarray = new DataArray ( );
            int Bcount = 0;
            int Ccount = 0;

            if ( SerializeData.ReadBankDictionaryFromDisk ( ) )
			{Output2.AppendText ( "Bank Dictionary holds " + BankAccount.BankDict.Count + " records that were loaded successfully...\r\n" );}
			else { Output2.AppendText ("Bank Dictionary Failed to load...\r\n"); Output2.ScrollToCaret ( ); }
            if ( SerializeData.ReadCustomerDictionaryFromDisk ( ) )
            {
	            Output2.AppendText ("Customer Dictionary loaded successfully...\r\n"); Output2.ScrollToCaret ( );
	            Output2.AppendText ("Customer Dictionary holds " + Customer.CustDict.Count + " records that were loaded successfully...\r\n");

            }
            else { Output2.AppendText ("Customer Dictionary Failed to load...\r\n"); Output2.ScrollToCaret ( ); }
            // This loads all  Bank A/C's nd Customer A/C's form the disk files
			//and adds them to the respective LinkedLists plus adding them 
			//into DataArray.CustNo and DataArray.BankNo
			Int16 arraycount = Dataarray.LoadArraysFromDisk ( out Bcount, out Ccount );
            Output2.AppendText ( "There are " + arraycount.ToString ( ) + " Bank Account files in our Bank system...\r\n" );
            Output2.AppendText ( "There are " + Bcount.ToString ( ) + " Bank Accounts loaded in our Bank SortedList...\r\n" );
            Output2.AppendText ( "There are " + Ccount.ToString ( ) + " Customer Accounts loaded in our Customer SortedList...\r\n" );


            // now we will have access to Arrays.Dataarray[] that contains access to all three other arrays 
			Output2.AppendText ( "Arrays setup data loaded successfully...\r\n" );
            // set all sort indicators to Normal
            _badirection = 0;
            _bldirection = 0;
            _cadirection = 0;
            _cldirection = 0;

            // Dont forget to update all our static counters to match the customers we have juist read in from disk
            Output2.AppendText ( "Housekeeping task completed successfully...\r\n" );
            Output2.AppendText ( "internal LinkedList of Bank Accounts loaded successfully...\r\n" );
            // now get the data and build our linkedlist 
            Output2.AppendText ( "There appear to be  " + totalcusts + " Customer accounts \r\n" );
            Output2.AppendText ( "and " + BankAccount.ReadTotalBanks ( ).ToString ( ) + " Bank Accounts currently in the system...\r\n" );
            Output2.AppendText ( "\n -------->>>> [System is now ready for use.]  <<<<---------\n\r\n" );
            Output2.ScrollToCaret ( );
            //			string [ ] ControlArray = new string [ 50 ];
            int cnt = 0;
            //			Control controls;
            // This has to be in Load() else it will not work
            foreach ( Control control in Controls )
            {
                string name = control.Name.ToString ( );

                if ( cnt < 50 )
                {
                    ControlArray[cnt] = name;
                    cnt++;
                }

                if ( control is TextBox )
                {
                    if ( name == "Output2" )
                    {
                        fc = control;
                        //						fca.Text = fc . Name;
                    }
                }
            }
            //			ListControls ( );
            // setup our sort checkboxes
            bankasc.Checked = true;
            bankadesc.Checked = false;
            banklasc.Checked = true;
            bankldesc.Checked = false;
            custaasc.Checked = true;
            custadesc.Checked = false;
            custlasc.Checked = true;
            custldesc.Checked = false;
            Output2.ScrollToCaret ( );
            //		string MyTextBox = "";
            GetControlList2 ( this, "Output2" );//, out MyTextBox );
            Output2.ScrollToCaret ( );
            IntPtr I = Utils.GetHandleForForm ( );
            int VI = I.GetHashCode ( );
            Startup = false;
            this.Cursor = Cursors.Default;
			WinInfo.Text = "Please wait,  connecting to SQL Server...";
			if ( SQLHelper.SQLConnect ( )){
				Output2.AppendText ("Connected to SQL Server successfully...\r\n");
				Output2.ScrollToCaret ( );
			}
			//**************************
			// Subscribe to my Events
			//**************************
			BankAccount.BankAccountEvents ( );
            Customer.CustomerEvents ( );
//            SQLDataReceived += SqlConnector.SqlConnector_SQLDataReceived("", "");

            /*         Customer.CustNoChangedEvent += Customer.Bank_CustNoChangedEvent1;
			         Customer.CustListChangedEvent += Customer.Bank_CustListChangedEvent;
			         Customer.CustAccountChangedEvent += Bank_CustAccountChangedEvent;
			         Customer.CustomerChangedEvent += Bank_CustomerChangedEvent;
            **/
            //**************************
        }

	// use this code - moved up into Bank.
	//**************************************************************************************************************************//
	public static Control.ControlCollection GetControlList2 (Form form1, string name)//, out object ctrl )
                                                                                         //**************************************************************************************************************************//
        {
//            Form form = new Form ( );
            //			IntPtr handle = form1 . Handle;
            Control.ControlCollection CC = form1.Controls;
            foreach ( Control C in CC )
            {
                if ( C.Name == name )
                {   // This ithe Form handle - I think ?
                    IntPtr Inp = C.TopLevelControl.Handle;
                }
            }
            //		ctrl = obj;
            //ctrl = ( object ) null;
            return CC;
        }

        //**************************************************************************************************************************//
        public void ListControls ( )
        //**************************************************************************************************************************//
        {
            if ( ControlArray == null ) return;
            foreach ( string c in ControlArray )
            {
                if ( c != null )
                {
                    Output2.AppendText ( "Control identified of : " + c + ".\r\n" );
                    //					Output2 . AppendText ( "Control identified of : " + c + ".\r\n" );
                    Output2.ScrollToCaret ( );
                }
                Output2.ScrollToCaret ( );
                if ( c == "Output2" )
                    Output2.AppendText ( "HERE IT IS...." );
            }
            Output2.ScrollToCaret ( );
        }
        //$$$$$$$$$$$$$$$$$$$$$$   DELEGATE CODE   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
        /*		public int AddItemDelegate ( string a )
				//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
				{
					DoIt ( "1234560" );
					Output2 . AppendText ( "Quite unbeievable really" );
					return 1;
				}
				//$$$$$$$$$$$$$$$$$$$$$$   DELEGATE CODE   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
				public static void UseTheDel ( MyDelType del, string a )
				//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
				{
					// This just acts as a workhorse and calls the delegate itself
					if ( del == null ) return;
					// cannot access Output2 here
					//Output2 . AppendText ( "Quite unbeievable really" );
		//			frm..DoIt ( a);
				}
				//$$$$$$$$$$$$$$$$$$$$$$   DELEGATE CODE   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
				private void DoIt ( string val )
				//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
				{
					Output2 . AppendText ( "This is   the  Delegate system printing this.... " );
					Output2 . AppendText ( val  );
					Output2 . ScrollToCaret ( );
				}
				//$$$$$$$$$$$$$$$$$$$$$$   DELEGATE CODE   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
				public void passiton ( int a )
				//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
				{
					Output2 . AppendText ( a . ToString ( ) );
				}
		*/
        //*********************************************************************************//
        private void RunBank_Click_2 (object sender, EventArgs e)
        //*********************************************************************************//
        {
            // This code works fine and create multiple transactions records
            // and the Account # incrments each pass thru it.
            WinInfo.Text = "";
            CreateBankaccount ( );
            listbankaccounts_Click ( sender, e );
        }

        //show the  create a new customer window
        //*********************************************************************************//
        private void NewCustButton_Click_1 (object sender, EventArgs e)
        //*********************************************************************************//
        {
            WinInfo.Text = "";
            // find the a/c we want
            // Open customer data window
            CustomerInput B = new CustomerInput ( );
            B.Show ( );// create a data input window for customer details.
            WinInfo.Text = "New Customer added successfully...";
            ListSortedCustomers_Click ( sender, e );

        }


        // Close window
        //*********************************************************************************//
        private void CloseButton_Click_1 (object sender, EventArgs e)
        //*********************************************************************************//
        {
            WinInfo.Text = "";
            CloseDown ( );
        }
        private void CloseDown ( )
        {
            // We need to save our Customer LINKEDLIST 1st
            // make sure it is in Normal sort order.....  Clever eh - thinking ahead
            if ( Bank._cldirection == 1 )
                SortArray.SwitchCustList ( );
            // do the same for our Bank ArrayList data
            SortArray.SortBankArray ( 0 );

            // save our Customer LinkedList to disk as binary and txt files
            Lists.SaveAllCustomerListData ( Customer.CustomerFilePath + "CustSortedListData.cust" );

            // save al cusrtomer data to .TXT backup fles from our ArrayData
            Customer.SaveAllCustomersToDiskAndText ( );
            // saves our Customer ArrayList to both Obj and Txt files
            Customer.SaveSortedCustomerListToText ( );

            // Save BOTH the hash table to disk
            CustomerFileHashTable.SaveHashFileTableToDisk ( );
            CustomerBalanceHashTable.SaveHashCustBalTable ( );

            // save al BankAccount data to .TXT backup fles from our ArrayData
            BankAccount.SaveAllBankAccountsToDiskAndText ( );
            // This saves all our transactions data linked list
            SerializeData.WriteBankTransactionsToDisk ( );

            // This saves the bank LinkedList to both an object file and a Text file
            Lists.SaveAllBankAccountListData ( );
            ConfigData.SaveConfigData ( );        // save our various seed number for account numbering so we can get them back (Persistence)

            SerializeData.SaveBankDictionaryToDisk ( );
			SerializeData.SaveCustDictionaryToDisk ( );
            // Check for SQL connection and close if necessary
			if ( SQLAccess.SQLconnection)
                Utils.SQLDisConnect();
            // Finally, we can go ahead and Close the App  down now
            Close ( );
        }
        //*********************************************************************************//
        private void UpdateCustomer_Click_1 (object sender, EventArgs e)
        //*********************************************************************************//
        {
            WinInfo.Text = "";
            // find the a/c we want
            // Open customer data edit window
            UpdateCustomer C = new UpdateCustomer ( );
            C.Show ( );// create a data input window for customer details.
        }

        //***************
        // BANK stuff
        //*********************************************************************************//
        // Create new deposit
        //*********************************************************************************//
        private void newbanktrans_Click (object sender, EventArgs e)
        {
            // Display the make deposit Window
            // First, select the required Bank account
            MakeBankDeposit BD = new MakeBankDeposit ( );
            BD.Show ( );
        }
        //*********************************************************************************//
        private void DeleteCustomer_Click (object sender, EventArgs e)
        {
            //$$$$$$$$$$$$$$$$$$$$$$   DELEGATE CODE   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
            //			Bank. UseTheDel ( del, "Opening Customer Deletion Window" );
            //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//
            CustomerDelete C = new CustomerDelete ( );
            C.Show ( );
        }
        //*********************************************************************************//
        public void CustOutputButton_Click (object sender, EventArgs e) { CustomerDelete D = new CustomerDelete ( ); D.Show ( ); }
        //*********************************************************************************//
        private void ClearButton_Click_1 (object sender, EventArgs e) { WinInfo.Text = ""; Output2.Clear ( ); }
        //*********************************************************************************//
        private void BankWithdrawbutton_Click_1 (object sender, EventArgs e) { withdrawl wd = new withdrawl ( ); wd.Show ( ); }
        /*      

        //        private static bool ConnectSQL() { if (Utils.SQLConnect()) return true; else return false; }
                ///Open our SQL database connection
         *        private void SQL_Connect_Click_2(object sender, EventArgs e)
                //*********************************************************************************
                {
                    this.Cursor = Cursors.WaitCursor;
                    WinInfo.Text = "Please wait,  connecting to SQL Server...";
                    if (ConnectSQL())
                    {
                        SQLMarker.Checked = true;
                        SQL_Connect.Enabled = false;
                        SQL_Connect.BackColor = Color.Silver;
                        SQL_Connect.ForeColor = Color.Gray;
                        SQLDisconnect.Enabled = true;
                        SQLDisconnect.BackColor = Color.SeaGreen;
                        SQLDisconnect.ForeColor = Color.White;
                        Output2.AppendText("We are CONNECTED to the SQL Server successfully..\r\n");
                        Output2.ScrollToCaret();
                        WinInfo.Text = "Successfully Connected to SQL Server";
                    }
                    else
                    {
                        WinInfo.Text = "Sorry, connection to SQL Server FAILED...";
                        form1.Output2.AppendText("Failed to Connect to SQL Server !!!..\r\n");
                    }
                    this.Cursor = Cursors.Default;
                }
                */
        // List all bank accounts
        //*********************************************************************************//
        private void button1_Click_1 (object sender, EventArgs e) { Output2.AppendText ( Lists.ListAllBankTransactions ( ) ); Output2.ScrollToCaret ( ); }
        //*********************************************************************************//

        //*********************************************************************************//
        private void BankTxtOutputButton_Click (object sender, EventArgs e)
        // list all bank account
        //*********************************************************************************//
        {
            //			string FileNumber = "";
            //			SerializeData . ReadBankFromTextfile ( FileNumber );
            // list all data from Text files on disk
            // no longer need - duplicated)
            /*            WinInfo. Text = "";
						// now do some BankAccount stuff
						Output. AppendText ( "There are " + BankAccount. BankAccountsLinkedList. Count ( ) + " entry(s) currently in our Bank Accounts LinkedList. \r\n" );
						if ( BankAccount. BankAccountsLinkedList. Count ( ) > 0 )
						{
							int i = 0;
							foreach ( var Item in BankAccount. BankAccountsLinkedList )
							{
								i++;
								if ( i == 1 ) Output. AppendText ( "Account\tType\tBalance\t\t\tDate Opened\tInterest %\r\n" );
								string output = String. Format ( "{0:C2}", Item. Balance );
								if ( output. Length < 12 ) output += "    ";
								// Format the output for a bit better display
								string act = String. Format ( "  {0}", Item. AccountType );
								string perc = String. Format ( "{0:P2}", Item. InterestRate / 100 );
								Output. AppendText ( Item. BankAccountNumber. ToString ( ) + "\t" + act + "\t" + output + "\t\t" + Item. DateOpened. ToShortDateString ( ) + "\t  " + perc + "\r\n" );
								Output. ScrollToCaret ( );
							}
							Output. AppendText ( "===========================================================================\r\n" );
							Output. AppendText ( "\r\n" );
							Output. ScrollToCaret ( );
						}
						else
						{ Output. AppendText ( "No Bank List data is available as yet..." + "\r\n" ); Output. ScrollToCaret ( ); }
			   */
        }

        // scroll the windoiw when we add text as caret is always at end of input
        ///Close our SQL database connection
        ///// DBDisconnect
        //*********************************************************************************//
        private void SQLDisconnect_Click (object sender, EventArgs e)
        //*********************************************************************************
        {
            Utils.SQLDisConnect();
            SQLMarker.Checked = false;
            SQL_Connect.Enabled = true;
            SQL_Connect.BackColor = Color.SeaGreen;
            SQL_Connect.ForeColor = Color.White;
            SQLDisconnect.BackColor = Color.Silver;
            SQLDisconnect.ForeColor = Color.Gray;
            SQLDisconnect.Enabled = false;
            Cursor = Cursors.Default;
            WinInfo.Text = "Disconnected from SQL Server";
            form1.Output2.AppendText("We have  DISCONNECTED from  SQL Server successfully..\r\n");

        }

        // This is this the  name of the Connect SQL button in DEsign ??
        //  but c# does not call it         ??
        //*********************************************************************************
        //private void SQL_Connect_Click(object sender, EventArgs e)
        //*********************************************************************************
        //      { ConnectSQL(); }


        //*********************************************************************************//
        private void ListSeedData_Click_1 (object sender, EventArgs e)
        //*********************************************************************************//
        {
            string[] array;
            Output2.AppendText ( "Current setting of all 4 seed values used\r\n" );
            array = Utils.ReadAllSeedData ( ); // non incrmenting version
            string txt = "Customer Account # Seed = " + array[0] + "\r\n" +
                              "Bank Account # Seed     = " + array[1] + "\r\n" +
                              "Total Bank Accounts     = " + array[2] + "\r\n" +
                              "Last Log Date           = " + array[3] + "\r\n";
            Output2.AppendText ( txt );
            Output2.AppendText ( TerminatorText );
            //Output2 . AppendText ( "===========================================================================\r\n" );
            Output2.ScrollToCaret ( );
        }

        //Create the hash tables
        //*********************************************************************************//
        private void listhashtables_Click_1 (object sender, EventArgs e)
        //*********************************************************************************//
        {
            Output2.AppendText ( "List of all entries from the TWO Customer based Hash Tables:\r\n" );
            Output2.AppendText ( "First a List of all entries in the A/C Balance Hash Tables:\r\n" );

            //create a sorted list (Descending order) from our Dictionary
            // create the sort on the fly
            SortedList<string, string> ascSortedList1 = Lists.GetAscendingSortedHashTable ( CustomerBalanceHashTable.CustNoBalHashTable );
            // now we got a sortedliast, display it
            if ( ascSortedList1.Count > 0 )
                Output2.AppendText ( "___________________________________________________________________________\r\n" );
            Output2.AppendText ( "Account #\tBalance :\r\n" );
            for ( int i = 0; i < ascSortedList1.Count; i++ )
            {
                string CurrencyAmount = Utils.GetCurrencyString ( ascSortedList1.Values[i].ToString ( ) );
                Output2.AppendText ( ascSortedList1.Keys[i].ToString ( ) + "\t\t" + CurrencyAmount + "\r\n" );
                //string CurrencyAmount = Utils.GetCurrencyString(ascSortedList1.Values[i].ToString());
                //					Output.AppendText(ascSortedList1.Keys[i].ToString() + "\t\t" + CurrencyAmount+ "\r\n");
                Output2.ScrollToCaret ( );
            }
            if ( ascSortedList1.Count > 0 )
                Output2.AppendText ( "___________________________________________________________________________\r\n" );
            //------------------------------------------------------------------------------------------------------------------------------------------------
            //create a sorted list (Descending order) from our Dictionary
            // create the sort on the fly

            SortedList<string, string> ascSortedList2 = Lists.GetAscendingSortedHashTable ( CustomerFileHashTable.CustFileNoHashTable );
            // now we got a sortedliast, display it
            Output2.AppendText ( "Account # \t#Filenames :\r\n" );
            for ( int i = 0; i < ascSortedList2.Count; i++ )
            {
                Output2.AppendText ( ascSortedList2.Keys[i].ToString ( ) + "\t\t" + ascSortedList2.Values[i].ToString ( ) + "\r\n" );
                Output2.ScrollToCaret ( );
            }
            Output2.AppendText ( TerminatorText );
            //Output2 . AppendText ( "===========================================================================\r\n" );
            Output2.ScrollToCaret ( );
        }

        //*********************************************************************************//
        private void Output_TextChanged (object sender, EventArgs e) { Output2.ScrollToCaret ( ); }
        //*********************************************************************************//
        private void MakeHashTables_Click_1 (object sender, EventArgs e)
        {
            bool a = false, b = false;
            if ( CustomerBalanceHashTable.ReBuildHashBalTable ( ) )
            {
                a = true;
            }
            if ( CustomerFileHashTable.ReBuildHashFileTable ( ) )
            { b = true; }
            if ( a && b )
                MessageBox.Show ( "Both Hash table have been rebuilt, there are " + CustomerBalanceHashTable.CustNoBalHashTable.Count + " in the Balance Hash table\n and "
                    + CustomerFileHashTable.CustFileNoHashTable.Count + "in the Files Hash table" );
            else if ( a )
                MessageBox.Show ( "Hash table have been rebuilt, there are " + CustomerBalanceHashTable.CustNoBalHashTable.Count + "\n in the Balance table" );
            else if ( b )
                MessageBox.Show ( "Hash table have been rebuilt, there are " + CustomerFileHashTable.CustFileNoHashTable.Count + "\n in the Files table" );
            //			var sortedList = ( from kv in MyDictionary select kv order by kv . Key).ToList<KeyValuePair<string, int>> ( );


        }
        //**************************************************************************************************************************//
        /*        private void SQLQuery_Click_1(object sender, EventArgs e)
                ///**************************************************************************************************************************
                {
                    using (var form = new CustomerSQLEnquiry())
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            Output2.AppendText("SQL Enquiry completed....");
                            Output2.ScrollToCaret();
                        }
                    }

                }
        */
        private void temp ( )
        {
            // testing the code in CollectionTest.cs
            // that uses the <T> generic collections facilities
            int[] x;
            x = CollectionTestClass<int>.test.runit ( );
            Output2.AppendText ( "Output from the use of a generic <T> collection:\r\n" );
            for ( int i = 0; i < x.Length; i++ )
            {
                Output2.AppendText ( x[i].ToString ( ) + ", " );
            }
            Output2.AppendText ( "\nEnd of output from a generic <T> collection:\r\n" );
            Output2.AppendText ( TerminatorText );
            //Output2 . AppendText ( "===========================================================================\r\n" );
            Output2.ScrollToCaret ( );
        }

        //**************************************************************************************************************************//
        private void CheckNormal_CheckedChanged (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            if ( CheckNormal.Checked )
            {
                CheckDeposit.Checked = false;
                CheckSavings.Checked = false;
                CheckBusiness.Checked = false;
            }
        }
        //**************************************************************************************************************************//
        private void CheckDeposit_CheckedChanged (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            if ( CheckDeposit.Checked )
            {
                CheckNormal.Checked = false;
                CheckSavings.Checked = false;
                CheckBusiness.Checked = false;
            }
        }

        //**************************************************************************************************************************//
        private void CheckSavings_CheckedChanged (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            if ( CheckSavings.Checked )
            {
                CheckDeposit.Checked = false;
                CheckNormal.Checked = false;
                CheckBusiness.Checked = false;
            }
        }
        //**************************************************************************************************************************//
        private void CheckBusiness_CheckedChanged (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            if ( CheckBusiness.Checked )
            {
                CheckDeposit.Checked = false;
                CheckSavings.Checked = false;
                CheckNormal.Checked = false;
            }
        }



        //*********************************************************************************//
        private void CreateBankaccount ( )
        //*********************************************************************************//

        {
            //*********************************************************************************
            WinInfo.Text = "";
            System.Random random = new System.Random ( );
            random.Next ( 23, 105 );
            string[] roads = { random. Next ( 1, 155 ).ToString() + " Windsor Rd",random. Next ( 23, 105 ).ToString() + "  Buckingham Place",
                    random. Next ( 23, 105 ).ToString() + "  Faraday Place",random. Next ( 23, 105 ).ToString() + " Wellington Terrace",random. Next ( 23, 105 ).ToString() + " Smithsonian Way",
                    random. Next ( 23, 105 ).ToString() + " Flightline Drive",random. Next ( 23, 105 ).ToString() + " Amey Johnson Way",random. Next ( 23, 105 ).ToString() + " Cannibals road",
                    random. Next ( 23, 105 ).ToString() + " Regent Street",random. Next ( 23, 105 ).ToString() + " Oxford St",random. Next ( 23, 105 ).ToString() + " Piccadilly",
                    random. Next ( 23, 105 ).ToString() + " Lambeth Road",random. Next ( 23, 105 ).ToString() + " Chiltern Way",random. Next ( 23, 105 ).ToString() + " Ketchup avenue",
                    random. Next ( 23, 105 ).ToString() + " Brown Sauce Terrace",random. Next ( 23, 105 ).ToString() + " Liitle hedges way",random. Next ( 23, 105 ).ToString() + " Great Missenden Road",
                    random. Next ( 23, 105 ).ToString() + " Buckshot Lead",random. Next ( 23, 105 ).ToString() + " Drambuie Way",random. Next ( 23, 105 ).ToString() + " Google Plaza",
                    random. Next ( 23, 105 ).ToString() + " Dell Road",random. Next ( 23, 105 ).ToString() + " Compaq Avenue",random. Next ( 23, 105 ).ToString() + " Mistletoe way",
                    random. Next ( 23, 105 ). ToString ( ) + " LastEntry Close"};

            string[] towns = { " Aldershot",
                     "  Buckingham","  Edinburgh"," Wellington"," Shottley"," Bicester"," Arncott"," Brill"," Chinnor"," St Albanst"," St Annes on Sea"," Lytham St Annes"," Blackpool",
                    " Eastcote"," lavington"," Oxford"," Cambridge"," Leicester"," Birmingham"," Lancaster"," New Brunswick"," Corrigador"," Christchurch"," Ely in the  Marsh"};

            string[] Countys = { random. Next ( 23, 105 ).ToString()
                    + " Lancashire","  BuckinghamShire","  Waverley"," Highlands & Islands"," Dorset"," Devon"," Cornwall"," Brecon"," Aberystwith"," Anglesey"," Kent"," Sussex",
                    " Norfolk"," Suffolk"," Lincolnshire"," Northumberland"," Durham"," Rutland"," Tyneside"," Teeside"," Cumbria"," Lakeland"," Orkneys"," Shetland Islands"};

            string[] lname = {
                                "Williams","Jones","Turner","Wilkinson","Prosser","Sankey","Logan","Read","Hasselblad","Nikon","Konig","Edwards","Smith","Little","Large",
                                "Handscombe","Paddock","Wilson","Dooley","Smythe","Mannering","Halton","Butcher","Baker","Ironmonger" };
            string[] fnames = {
                                "John","William","Johan","Brian","Hal","Robert","Bob","Jack","Olwen","Elizabeth","Mary","Anne","Susan","Sue","Margaret",
                                "Matt","Colin","Martyn","Martin","Jules","Johann","Peter","Joe","Tony","Ron ",};
            decimal[] bal = { 12.45M, 2300.10M, 567.42M, 25000M, 1000M, 90450M, 456M, 78M, 123.45M, 65321.99M, 7504.73M,
                                        12000M, 17500M, 23600M, 9023.65M, 67.1M, 4.53M, 19.83M, 12.32M, 905.38M, 862.41M, 9.65M, 11.42M, 903.56M,100.01M, };
            decimal[] intrst = { 12.45M,2.3M,10.8M, 5.42M, 2.5M, 1.9M, 9.5M, 6.65M,7.8M, 3.45M, 5.21M, 7.5M, 2M,17.5M, 23.6M, 9.65M, 6.7M, 4.53M, 9.83M, 12.32M, 5.38M,
                                        4.45M, 9.32M, 3.32M, 6.68M, 10.00M, };
//            int[] pcode1 = { 1, 23, 54, 6, 9, 7, 3, 84, 23, 14, 17, 2, 45, 4, 90, 99, 35, 42, 3, 27, 5, 21, 32, 5, 7, };
            string[] pcode2 = { "AA", "CB", "FS", "HT", "FY", "SE", "WM", "ID", "ON", "NU", "QM", "PC", "CD", "AK", "KF", "VU", "WY", "XG", "GK", "SH", "XX", "YY", "ZZ", "AM", "YD", };
            int[] pcode3 = { 1, 23, 54, 76, 93, 7, 3, 84, 23, 14, 17, 21, 65, 34, 90, 99, 85, 42, 36, 27, 51, 21, 32, 5, 7, };
            int[] pcode4 = { 1, 2, 5, 7, 9, 6, 3, 4, 8, 10, 17, 21, 25, 34, 19, 27, 15, 22, };
            string[] addr2 = { " Cedar Tree Circle", " Torrington Condominiums", " Valley Circle", " Tarragon Way", " Piccaddily Way", " Oxenford", " Regis Way", "  Marshall Square"
                                            , " Sunshine Boulevard", " Everest Way", " Llangolen Route", " Capson Apex Place", " Liggard Square", " Smithway Estate", " Amy Smith", " Arlingon Square", " Rossal Way", "Upper Boulevard", " Litle Essex", " Nonsuch"
                                        , " Gatcombe Circle", " Standard Homes Estate", "Upper  Pinmill", " Paladin Square", " Trafalgar place", };


            if ( CheckNormal.Checked )
            {
//                int x = random.Next ( 1, 155 );
                string accno = Customer.GetCustomerNumberSeed ( ).ToString ( );
                string addr = roads[random.Next ( 0, 24 )].ToString ( );
                string pcode = pcode2[random.Next ( 0, 24 )].ToString ( ) + pcode3[random.Next ( 0, 24 )].ToString ( ) + " "
                    + pcode4[random.Next ( 0, 17 )].ToString ( ) + pcode2[random.Next ( 0, 24 )].ToString ( );
                string tel = "0" + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + " "
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( )
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( );
                string mob = "0" + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + " "
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( )
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( );
                string surname = lname[random.Next ( 0, 24 )];
                string fname = fnames[random.Next ( 0, 24 )];
                BankAccount bank = new BankAccount ( );
                //public static BankAccount CreateNewBankAccount ( BankAccount bank, string CustNo, Int16 accounttype, decimal  amount, decimal  interest )
                BankAccount.CreateNewBankAccount ( bank, accno, 1, ( decimal ) 237.18, ( decimal ) 3.72 );

                Customer Cust = new Customer ( );
                Cust = Customer.CreateNewCustomer ( accno, surname, fname, tel, mob, addr, addr2[random.Next ( 0, 24 )],
                    towns[random.Next ( 0, 24 )], Countys[random.Next ( 0, 24 )], pcode, 1, bank.BankAccountNumber, DateTime.Now );
                form1.Output2.AppendText ( "New Normal Checking Bank Account " + bank.BankAccountNumber + " created successfully for Customer " + Cust.CustomerNumber.ToString ( ) + "..\r\n" );
            }
            if ( CheckDeposit.Checked )
            {
                int x = random.Next ( 1, 155 );
                string accno = Customer.GetCustomerNumberSeed ( ).ToString ( );
                string addr = roads[random.Next ( 0, 24 )].ToString ( );
                string pcode = pcode2[random.Next ( 0, 24 )].ToString ( ) + pcode3[random.Next ( 0, 24 )].ToString ( ) + " "
                    + pcode4[random.Next ( 0, 17 )].ToString ( ) + pcode2[random.Next ( 0, 24 )].ToString ( );
                string tel = "0" + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + " "
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( )
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( );
                string mob = "0" + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + " "
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( )
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( );
                string surname = lname[random.Next ( 0, 24 )];
                string fname = fnames[random.Next ( 0, 24 )];
                decimal balance = bal[random.Next ( 0, 24 )];
                decimal interest = intrst[random.Next ( 0, 24 )];
                // MUST do Bank first  as we need to get a valid Account #
                BankAccount bank = new BankAccount ( );
                BankAccount.CreateNewBankAccount ( bank, accno, ( Int16 ) 2, balance, ( decimal ) interest );

                Customer Cust = new Customer ( );
                Cust = Customer.CreateNewCustomer ( accno, surname, fname, tel, mob, addr, addr2[random.Next ( 0, 24 )],
                    towns[random.Next ( 0, 24 )], Countys[random.Next ( 0, 24 )], pcode, 2, bank.BankAccountNumber, DateTime.Now );
                form1.Output2.AppendText ( "New Deposit Bank Account " + bank.BankAccountNumber + " created successfully for Customer " + Cust.CustomerNumber.ToString ( ) + "..\r\n" );

            }
            if ( CheckSavings.Checked )
            {
                int x = random.Next ( 1, 155 );
                string accno = Customer.GetCustomerNumberSeed ( ).ToString ( );
                string addr = roads[random.Next ( 0, 24 )].ToString ( );
                string pcode = pcode2[random.Next ( 0, 24 )].ToString ( ) + pcode3[random.Next ( 0, 24 )].ToString ( ) + " "
                    + pcode4[random.Next ( 0, 17 )].ToString ( ) + pcode2[random.Next ( 0, 24 )].ToString ( );
                string tel = "0" + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + " "
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( )
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( );
                string mob = "0" + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + " "
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( )
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( );
                string surname = lname[random.Next ( 0, 24 )];
                string fname = fnames[random.Next ( 0, 24 )];
                decimal balance = bal[random.Next ( 0, 24 )];
                decimal interest = intrst[random.Next ( 0, 24 )];
                // MUST do Bank first  as we need to get a valid Account #
                BankAccount bank = new BankAccount ( );
                BankAccount.CreateNewBankAccount ( bank, accno, ( Int16 ) 3, balance, ( decimal ) interest );

                Customer Cust = new Customer ( );
                Cust = Customer.CreateNewCustomer ( accno, surname, fname, tel, mob, addr, addr2[random.Next ( 0, 24 )],
                    towns[random.Next ( 0, 24 )], Countys[random.Next ( 0, 24 )], pcode, 3, bank.BankAccountNumber, DateTime.Now );
                form1.Output2.AppendText ( "New Savings Bank Account " + bank.BankAccountNumber + " created successfully for Customer " + Cust.CustomerNumber.ToString ( ) + "..\r\n" );
            }
            if ( CheckBusiness.Checked )
            {
                int x = random.Next ( 1, 155 );
                string accno = Customer.GetCustomerNumberSeed ( ).ToString ( );
                string addr = roads[random.Next ( 0, 24 )].ToString ( );
                string pcode = pcode2[random.Next ( 0, 24 )].ToString ( ) + pcode3[random.Next ( 0, 24 )].ToString ( ) + " "
                    + pcode4[random.Next ( 0, 17 )].ToString ( ) + pcode2[random.Next ( 0, 24 )].ToString ( );
                string tel = "0" + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + " "
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( )
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( );
                string mob = "0" + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + " "
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( )
                    + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( ) + random.Next ( 0, 9 ).ToString ( );
                string surname = lname[random.Next ( 0, 24 )];
                string fname = fnames[random.Next ( 0, 24 )];
                decimal balance = bal[random.Next ( 0, 24 )];
                decimal interest = intrst[random.Next ( 0, 24 )];

                // MUST do Bank first  as we need to get a valid Account #
                BankAccount bank = new BankAccount ( );
                BankAccount.CreateNewBankAccount ( bank, accno, ( Int16 ) 4, balance, ( decimal ) interest );

                Customer Cust = new Customer ( );
                Cust = Customer.CreateNewCustomer ( accno, surname, fname, tel, mob, addr, addr2[random.Next ( 0, 24 )],
                    towns[random.Next ( 0, 24 )], Countys[random.Next ( 0, 24 )], pcode, 4, bank.BankAccountNumber, DateTime.Now );
                form1.Output2.AppendText ( "New Business Bank Account " + bank.BankAccountNumber + " created successfully for Customer " + Cust.CustomerNumber.ToString ( ) + "..\r\n" );
            }
            Output2.AppendText ( "\nNew Account creation system has completed successfully\r\n" );
            Output2.AppendText ( TerminatorText );
            //Output2 . AppendText ( "===========================================================================\r\n" );
            Output2.ScrollToCaret ( );
            BAsort.Text = "[Normal]";
            BLsort.Text = "[Normal]";
            CAsort.Text = "[Normal]";
            CLsort.Text = "[Normal]";

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void DisplayDataScreen (Customer C)
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        {
            // USED BY SEVERAL LISTING BUTTONS
            //see if the Customer owns more than one bank account ?
            // Make  this output a seperate function
            if ( C != null )
            {
                Output2.AppendText ( C.CustomerNumber.ToString ( ) + ",  " + C.accountnums[0].ToString ( ) + ",  " + GetAccountTypeText ( C.accounttypes[0] ) + ",  " + C.LastName + ",  "
                    + C.FirstName + ",  " + C.DOB.ToShortDateString ( ) + ",  " + C.Address1 + "\n " + C.Address2 + ",  " + C.Town + ",  " + C.County + "\r\n" );
                if ( C.accounttypes[1] > 0 )
                {
                    Output2.AppendText ( "Secondary Bank Account(s) ---vvv\r\n" );
                    Output2.AppendText ( C.CustomerNumber.ToString ( ) + ",  *** " + C.accountnums[1].ToString ( ) + " ***,  " + GetAccountTypeText ( C.accounttypes[1] ) + "\t<<<---  Secondary Bank Account\r\n" );
                }
                if ( C.accounttypes[2] > 0 )
                {
                    Output2.AppendText ( C.CustomerNumber.ToString ( ) + ",  *** " + C.accountnums[2].ToString ( ) + " ***,  " + GetAccountTypeText ( C.accounttypes[2] ) + "\t<<<---  Secondary Bank Account\r\n" );
                }
                if ( C.accounttypes[3] > 0 )
                {
                    Output2.AppendText ( C.CustomerNumber.ToString ( ) + ",  *** " + C.accountnums[3].ToString ( ) + ",***  " + GetAccountTypeText ( C.accounttypes[3] ) + "\t<<<---  Secondary Bank Account\r\n" );
                }
                Output2.AppendText ( "......\r\n" );
//                C.Dispose ( );
            }
            Output2.AppendText ( TerminatorText );
            //			Output2 .Text += ( "-------------------------------------------------------------------------------------\r\n" );

        }


        //**************************************************************************************************************************//
        private void listbankaccounts_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            string dir = BankAccount.ReadBankFilePath ( );
//            string[] files = System.IO.Directory.GetFiles ( dir, "*.bnk" );
            int count = 0;
            //			string padding = "                         ";
            Output2.AppendText ( String.Format ( "*** Full Bank Accounts details obtained from the BankNo  Array:- ***\r\n", count ) );
            Output2.AppendText ( "Bank #\tType\tCustomer#   Balance\tDate Opened\tInterest %\tFileName\r\n" );
            //			foreach ( BankAccount v in BankAccount . BankAccountsLinkedList )
            foreach ( BankAccount v in DataArray.BankNo )
            {
                if ( v == null ) continue;
                OutputBankDetails ( v );   // list them in the form window - Fn is right below here
                Output2.ScrollToCaret ( );
            }
            Output2.AppendText ( TerminatorText );
            Output2.ScrollToCaret ( );
            Output2.ScrollToCaret ( );
            // list all bank accounts using iterator thru the LinkedList
            //			LinkedList<BankAccount> . Enumerator LListEnum = BankAccount . BankAccountsLinkedList . GetEnumerator ( );
            Output2.AppendText ( "All Bank Account information from DataArray.BankNo  Array\r\n" );
            Output2.AppendText ( "Bank #\t   Cust #\tBalance\t\tInterest\tFileName\r\n" );
            //use the Enumeration version as shown below
            //			while ( LListEnum . MoveNext ( ) )
            foreach ( BankAccount B in DataArray.BankNo )
            {
                if ( B == null ) continue;
                string cstr = Utils.GetCurrencyString ( B.Balance.ToString ( ) );
                string currencystr = cstr + "    "; //+ padding . Substring ( padding.Length - (cstr . Length + 4) );

                string Intrst = Utils.GetFieldCurrencyString ( B.InterestRate.ToString ( ) );
                Output2.AppendText ( B.BankAccountNumber.ToString ( ) + "\t" + B.AccountType.ToString ( ) + "  "
                                    + B.CustAccountNumber.ToString ( ) + "\t" + currencystr + "\t" + Intrst + "%" + "\t" + B.FileName + "\r\n" );
            }
            //Output2.AppendText( Text );
            Output2.ScrollToCaret ( );
        }

        //**************************************************************************************************************************//
        private void AddSecondaryBank_Click_1 (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            WinInfo.Text = "";
            // find the a/c we want
            // Open customer data window
            SecondaryBnkAcct B = new SecondaryBnkAcct ( );
            B.Show ( );// create a data input window for customer details.
            WinInfo.Text = "Secondary Bank Account system completed successfully...";

        }

        //**************************************************************************************************************************//
        private void BAEdit_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {   // edit a bank accounts detials
            BankAccountEdit B = new BankAccountEdit ( );
            B.Show ( );
            form1.Output2.AppendText ( "Bank Account Edit Form opened...\r\n" );

        }

        //**************************************************************************************************************************//
        private void bldCustList_Click_1 (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            Customer.RebuildCustDataFromTextFiles ( );
            form1.Output2.AppendText ( "Customer  Accounts + LinkedList and DataArray have been rebuilt from Text files successfully...\r\n" );
            // no longer used s it was a duplicate of RebuildBankLL_Click below
            ////			Output2 . AppendText ( "The Customer Accounts LinkedList and Array have been rebuilt from Disk Objects successfully...\r\n" );
            //			Output2 . AppendText ( "There are now " + x + "  Customer Accounts in our LinkedList ...\r\n" );
            //			Output2 . ScrollToCaret ( );
        }
        //**************************************************************************************************************************//
        private void RebuildBankLL_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {// rebuild Bank Linkedlist & SoirtedArray from object files on disk
            int x = BankAccount.RebuildBankLinkedListFromObjects ( );
            Output2.AppendText ( "The Bank Accounts LinkedList and DataArray have been rebuilt from disk objects successfully...\r\n" );
            Output2.AppendText ( "There are now " + x + "  Bank Accounts verified in the system...\r\n" );
            Output2.ScrollToCaret ( );
        }

        private void RebuildCustLL_Click (object sender, EventArgs e)
        {   // rebuild customer LinkedList and Array from Disk objects
            int x = Customer.RebuildAllCustDataFromDisk ( );
            Output2.AppendText ( "The Customer LinkedList & SortedArray have been rebuilt from the backup Text file successfully...\r\n" );
            Output2.AppendText ( "There are now " + x + "  Customer Accounts verified in the system...\r\n" );
            Output2.ScrollToCaret ( );
        }

        private void RebuildBankFromText_Click_1 (object sender, EventArgs e)
        {// rebuild Bank Linked list and BankNo array from TextFiles
            if ( Lists.RebuildBankListsFromText ( ) > 0 )
                Output2.AppendText ( "The Bank LinkedList and DataArray have been rebuilt from the backup Text file successfully...\r\n" );
        }

        private void button3_Click (object sender, EventArgs e)
        {   // Bank ArrayList  reubuilt from Bank LinkedList
            //			form1.Output2 . AppendText ( "Bank Account Array is going to be rebuilt from Linked List data...\r\n");

            int count = 0;
            count = DataArray.RebuildBankArrayFromLinkedList ( );
            Output2.AppendText ( "The Bank ArrayList has been rebuilt with " + count.ToString ( ) + " from the Bank LinkedList. \r\n" );
            foreach ( BankAccount b in DataArray.BankNo )
            {
                OutputBankDetails ( b );
                Output2.ScrollToCaret ( );
            }
        }

        //**************************************************************************************************************************//
        private void CustplusBank_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {   // generate and list all customer with details of EACH Bank account they have.
            ListCustWithBank ( );
            Output2.ScrollToCaret ( );
        }

        //**************************************************************************************************************************//
        private void ListSortedCustomers_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {   // list all customer account info in sorted order from our sorted Array DataArray.CustNo
            ListCustomersFromArray ( );
            Output2.ScrollToCaret ( );

        }

        //**************************************************************************************************************************//
        private void CustEdit_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {   // fully edit a customer account
            form1.Output2.AppendText ( "Customer is edit dialog opened ...\r\n" );
            CustomerEdit CE = new CustomerEdit ( );
            CE.Show ( );
        }
/*
        private void DisplayCustsFromLinkedList ( )
        //**************************************************************************************************************************
        {
            DisplayLinkedListForCusts ( );
            Output2.ScrollToCaret ( );
        }
*/
		//**************************************************************************************************************************//
        // Top button on screen
        private void BanklistFromLinkedList_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            ShowBanksFromLinkedList ( );
            Output2.ScrollToCaret ( );
        }

        //**************************************************************************************************************************//
        private void ListLink_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {//  list fromlinked list
            Output2.AppendText ( "*** All Customers from DataArray,CustNo Array. ***\r\n" );
            Output2.AppendText ( "Cust #\t   Bank #    type\t\tA/C details\r\n" );
            foreach ( Customer C in Customer.CustomersLinkedList )
            {   // here we go, using our Sorted array
                // this is the default Bank account  type
                //				Int32 actype = C . accountnums [ 0 ];
                DisplayDataScreen ( C );
                Output2.ScrollToCaret ( );
            }
            Output2.ScrollToCaret ( );
        }

        //**************************************************************************************************************************//
        private void DoCustomers_CheckedChanged (object sender, EventArgs e)
        //**************************************************************************************************************************//
        { }
        private void BankTxtOutputButton_Click_1 (object sender, EventArgs e)
        {
            ReadBankTextFile RBT = new ReadBankTextFile ( );
            RBT.Show ( );

        }

        //**************************************************************************************************************************//
        private void CreatenewBankAccount_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            Form CreateBankAccount = new CreateBankAccount ( );
            CreateBankAccount.Show ( );
        }
        //**************************************************************************************************************************//
        //**************************************************************************************************************************//
        public static void OutputBankDetails (BankAccount Item)
        //**************************************************************************************************************************//
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        {
            //where ia the code ????????????????????????????????
        }

       /*
				//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
				public static void DisplayCustsFromArray ( )
				//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
				{
					Output2.AppendText( "*** All Customers from DataArray,CustNo Array. ***\r\n" );
					Output2.AppendText( "Cust #\t   Bank #    type\t\tA/C details\r\n" );
					foreach ( Customer C in DataArray . CustNo )
					{   // here we go, using our Sorted array
						// this is the default Bank account  type
						Int32 actype = C . accountnums [ 0 ];
						DisplayDataScreen ( C );
					}
				}
		*/        // Generic output for Customer data from wherever it is sourced
                  //**************************************************************************************************************************//
        public static string GetAccountTypeText (Int16 act)
        //**************************************************************************************************************************//
        {
            switch ( act )
            {
                case 1:
                    return "Normal";
                case 2:
                    return "Savings";
                case 3:
                    return "Deposit";
                case 4:
                    return "Business";
                default:
                    break;
            }
            return "";
        }
        //**************************************************************************************************************************//
        public static void ListBankAccounts ( )
        //**************************************************************************************************************************//
        {
        }
        //**************************************************************************************************************************//
        public void ShowBanksFromLinkedList ( )
        //**************************************************************************************************************************//
        {
            // list all bank accounts thru the LinkedList
            Output2.AppendText ( "*** Bank A/C's listed through Linked List ***\r\n" );
            Output2.AppendText ( "Type\tBank #\tCust #\tBalance\t\tOpen Date\tInterest\tStatus\r\n" );
            foreach ( BankAccount B in BankAccount.BankAccountsLinkedList )
            {
                Output2.AppendText ( B.AccountType.ToString ( ) + "\t" + B.BankAccountNumber.ToString ( ) + "\t" + B.CustAccountNumber.ToString ( ) + "\t   " + String.Format ( "{0:C2}", B.Balance )
                                                    + "\t" + B.DateOpened.ToShortDateString ( ) + "\t" + B.InterestRate.ToString ( ) + "\t\t" + B.Status.ToString ( ) + "\r\n" );
            }
            Output2.AppendText ( TerminatorText );
        }
        public void DisplayLinkedListForCusts ( )
        {
            Output2.AppendText ( "*** All Customers from Linked List. ***\r\n" );
            Output2.AppendText ( "Cust #\t   Bank #    type\t\tA/C details\r\n" );
            foreach ( Customer C in Customer.CustomersLinkedList )
            {   // here we go, using our Sorted array
                // this is the default Bank account  type
                //				Int32 actype = C . accountnums [ 0 ];
                DisplayDataScreen ( C );
            }
        }
        //**************************************************************************************************************************//
        public void ListCustomersFromArray ( )
        //**************************************************************************************************************************//
        {
            string Padding = "                    ", fname = "", lname = "";
            string bankno = "";
            Output2.AppendText ( "*** Sorted List of Customers from the DataArray.CustNo Array ***\r\n" );
            Output2.AppendText ( "Type\tCust  #\tBank A/C #\tSurname\t\t   Forename\t\tDOBr\r\n" );
            // new method, using sorted array in memory 
            foreach ( Customer v in DataArray.CustNo )
            {
                if ( v == null )
                {
                    Output2.AppendText ( "*** NULL RECORD IDENTIFIED in Sorted List of Customers from the DataArray.CustNo Array ***\r\n" );
                    continue;
                }
                fname = v.FirstName + Padding.Substring ( 0, 20 - v.FirstName.Length );
                lname = v.LastName + Padding.Substring ( 0, 20 - v.LastName.Length );
                bankno = v.accountnums[0].ToString ( ).TrimEnd ( );
                Output2.AppendText ( v.accounttypes[0].ToString ( ) + "\t" + v.CustomerNumber.ToString ( ) + "\t " + bankno + "\t"
                                                                + lname + fname + v.DOB.ToShortDateString ( ) + "\r\n" );
                if ( v.accountnums[1] > 0 )
                {
                    bankno = v.accountnums[1].ToString ( ).TrimEnd ( );
                    Output2.AppendText ( v.accounttypes[1].ToString ( ) + "\t" + v.CustomerNumber.ToString ( ) + "\t " + bankno + "\t" + "<<<--- Secondary Bank Account\r\n" );
                }
                if ( v.accountnums[2] > 0 )
                {
                    bankno = v.accountnums[2].ToString ( ).TrimEnd ( );
                    Output2.AppendText ( v.accounttypes[2].ToString ( ) + "\t" + v.CustomerNumber.ToString ( ) + "\t" + bankno + "\t" + "<<<--- Secondary Bank Account\r\n" );
                }
                if ( v.accountnums[3] > 0 )
                {
                    bankno = v.accountnums[3].ToString ( ).TrimEnd ( );
                    Output2.AppendText ( v.accounttypes[3].ToString ( ) + "\t" + v.CustomerNumber.ToString ( ) + "\t" + bankno + "\t" + "<<<--- Secondary Bank Account\r\n" );
                }
            }
            Output2.AppendText ( TerminatorText );
            //			Output2.Text +=  ( "---------------------------------------------------------------------------------------\r\n" );
        }
        //**************************************************************************************************************************//
        public void ListCustWithBank ( )
        //**************************************************************************************************************************//
        {
            // iterate thru linked list
            Output2.AppendText ( "*** List of all Customers including their Bank Account(s) from Datarray.CustNo ***\r\n" );
            //			foreach ( var C in Customer . CustomersLinkedList )
            // new method using sorted array in memory
            foreach ( Customer C in DataArray.CustNo )
            {
                if ( C == null )
                    continue;
                string actype = "";
                string padding25 = "                        ";
                string fname = "";
                string town;
                fname = C.FirstName + padding25.Substring ( 25 - C.FirstName.Length );
                string lname = C.LastName + padding25.Substring ( 25 - C.LastName.Length );
                town = C.Town + padding25.Substring ( 25 - C.Town.Length );

                Output2.AppendText ( "Account\tLastName\tFirstName\t Town\t\tCounty\r\n" );
                Output2.AppendText ( C.CustomerNumber.ToString ( ) + "\t" + lname + "       " + fname + "\t" + town + "\t" + C.County + "\r\n" );
                Output2.AppendText ( "A/C Type\tBank A/C #\tBalance\t       Open Date\tFile Name\r\n" );
                for ( int x = 0; x < 4; x++ )
                {
                    if ( C.accountnums[x] > 0 )
                    {
                        BankAccount B = Search.FindBankObjectfromBankNo ( C.accountnums[x].ToString ( ) );
                        if ( B == null )
                            break;
                        if ( B.AccountType == 1 )
                            actype = "1-Normal     ";
                        else if ( B.AccountType == 2 )
                            actype = "2-Savings    ";
                        else if ( B.AccountType == 3 )
                            actype = "3-Deposit    ";
                        else if ( B.AccountType == 4 )
                            actype = "4-Business   ";
                        string bal = Utils.GetCurrencyString ( B.Balance.ToString ( ) );
                        string bal2 = bal + padding25.Substring ( 15 - bal.Length );
                        string dataline = actype + "   " + B.BankAccountNumber + "\t\t" + bal + "\t" + B.DateOpened.ToShortDateString ( ) + "\t" + B.FileName + "\r\n";
                        Output2.AppendText ( dataline );
                        B.Dispose ( );
                    }
                }
                Output2.AppendText ( TerminatorText );
            }
        }

        //**************************************************************************************************************************//
        private void Sortarrays_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            // subscribe this form  for callback			
            //			SetValueForText1 = Output2. Text;
            Form SortArray = new SortArray ( );
            SortArray.Show ( );
        }

        //**************************************************************************************************************************//
        private void bankasc_CheckedChanged (object sender, EventArgs e)
        {
            if ( Startup ) return;
            SortArray.alpha_Click ( sender, e );
            BAsort.Text = "[Normal]";
        }
        private void bankadesc_CheckedChanged (object sender, EventArgs e)
        {
            if ( Startup ) return;
            SortArray.contra_Click ( sender, e );
            BAsort.Text = "[Normal]";
        }

        private void banklasc_CheckedChanged (object sender, EventArgs e)
        {
            if ( Startup ) return;
            SortArray.LLnormal_Click_1 ( sender, e );
            BLsort.Text = "[Normal]";
        }

        private void bankldesc_CheckedChanged (object sender, EventArgs e)
        {
            if ( Startup ) return;
            SortArray.LLreverse_Click_1 ( sender, e );
            BLsort.Text = "[Normal]";
        }

        private void custaasc_CheckedChanged (object sender, EventArgs e)
        {
            if ( Startup ) return;
            SortArray.custarraynormal_Click_1 ( sender, e );
            CAsort.Text = "[Normal]";
        }

        private void custadesc_CheckedChanged (object sender, EventArgs e)
        {
            if ( Startup ) return;
            SortArray.custarrayreverse_Click_1 ( sender, e );
            CAsort.Text = "[Normal]";
        }

        private void custlasc_CheckedChanged (object sender, EventArgs e)
        {
            if ( Startup ) return;
            SortArray.custlistnormal_Click ( sender, e );
            CLsort.Text = "[Normal]";
        }

        private void custldesc_CheckedChanged (object sender, EventArgs e)
        {
            if ( Startup ) return;
            SortArray.custlistreverse_Click ( sender, e );
            CLsort.Text = "[Normal]";
        }


        //**************************************************************************************************************************//
        public void ShowText (string msg, int[] a, int indx)//the method which I want to call
                                                            //**************************************************************************************************************************//
        {
            // We send null and -1 as last args from Events etc
            if ( msg == null ) return;
            if ( msg.Length > 0 )
            {
                Output2.AppendText ( msg );
                Output2.ScrollToCaret ( );
            }
            if ( a == null )
                return;
            // set all checkboxes to unchecked intially
            if ( Startup ) return;
            //			bankasc . Checked = bankadesc . Checked = banklasc . Checked = bankldesc . Checked
            //				= custaasc . Checked = custadesc . Checked = custlasc . Checked = custlasc . Checked = false;
            Startup = true;
            if ( indx == 5 ) return;
            if ( ( indx == 0 || indx == 4 ) && a[0] == 1 )
            {
                bankadesc.Checked = true; bankasc.Checked = false;
                BAsort.Text = "[Normal]";
            }
            else if ( indx == 0 || indx == 4 )
            {
                bankadesc.Checked = false;
                bankasc.Checked = true; BAsort.Text = "[Normal]";
            }
            if ( ( indx == 1 || indx == 4 ) && a[1] == 1 )
            {
                bankldesc.Checked = true; banklasc.Checked = false;
                BLsort.Text = "[Normal]";
            }
            else if ( indx == 1 || indx == 4 )
            {
                bankldesc.Checked = false; banklasc.Checked = true;
                BLsort.Text = "[Normal]";
            }
            if ( ( indx == 2 || indx == 4 ) && a[2] == 1 )
            {
                custadesc.Checked = true; custaasc.Checked = false;
                CAsort.Text = "[Normal]";
            }
            else if ( indx == 2 || indx == 4 )
            {
                custadesc.Checked = false; custaasc.Checked = true;
                CAsort.Text = "[Normal]";
            }
            if ( ( indx == 3 || indx == 4 ) && a[3] == 1 )
            {
                custldesc.Checked = true; custlasc.Checked = false;
                CLsort.Text = "[Normal]";
            }
            else if ( indx == 3 || indx == 4 )
            {
                custldesc.Checked = false; custlasc.Checked = true;
                CLsort.Text = "[Normal]";
            }
            Startup = false;

        }


        private void bankAccountToolStripMenuItem_Click (object sender, EventArgs e)
        {//Generate Bank  style export data; 

            SetExportType ( 1 );// bank is 1
            customerToolStripMenuItem_Click ( sender, e );
        }
        private void customerStyleDataToolStripMenuItem_Click (object sender, EventArgs e)
        {
            SetExportType ( 2 );    // customer is 2
            customerToolStripMenuItem_Click ( sender, e );
        }
        private void customerToolStripMenuItem_Click (object sender, EventArgs e)
        {

        }
        private void ascendingOrderToolStripMenuItem_Click (object sender, EventArgs e)
        {
            /*			// Sort bank  by Bank A/C Type Ascending
                        BankSorts . SortBankbyACType ( false );
                        BAsort . Text = "[Account Type (Asc)]";
                        BLsort . Text = "[Normal]";
            */
        }
        //******************************************************************************************************************************
        //******************************************************************************************************************************
        private void BankCustnoAscendingOrderMenuItem_Click (object sender, EventArgs e)
        {
            // Sort bank  by Customer # Ascending
            BankSorts.SortBankbyCustomer ( false );
            BAsort.Text = "[Customer # (Asc)]";
            BLsort.Text = "[Normal]";
        }
        private void BankCustnoDescendingOrderMenuItem_Click_1 (object sender, EventArgs e)
        {
            // Sort bank  by Customer # Descending
            BankSorts.SortBankbyCustomer ( true );
            BAsort.Text = "[Customer # (Desc)]";
            BLsort.Text = "[Normal]";
        }
        private void BankTypeAscendingOrderMenuItem_Click (object sender, EventArgs e)
        {
            // Sort bank  by Bank A/C Type Descending
            BankSorts.SortBankbyACType ( false );
            BAsort.Text = "[Account Type (Asc)]";
            BLsort.Text = "[Normal]";
        }
        private void BankTypeDescendingOrderMenuItem_Click (object sender, EventArgs e)
        {
            // Sort bank  by Bank A/C Type Descending
            BankSorts.SortBankbyACType ( true );
            BAsort.Text = "[Account Type (Desc)]";
            BLsort.Text = "[Normal]";
        }

        private void BankBalanceAscendingOrderMenuItem_Click_1 (object sender, EventArgs e)
        {
            // Sort bank  by Bank Balance Ascending
            BankSorts.SortBankbyBalance ( false );
            Output2.ScrollToCaret ( );
            BAsort.Text = "[Balance (Asc)]";
            BLsort.Text = "[Normal]";
        }
        private void BankBalanceDescendingOrderMenuItem_Click_1 (object sender, EventArgs e)
        {
            // Sort bank  by Bank Balance Ascending
            BankSorts.SortBankbyBalance ( true );
            Output2.ScrollToCaret ( );
            BAsort.Text = "[Balance (Desc)]";
            BLsort.Text = "[Normal]";

        }

        private void customerStyleDataToolStripMenuItem1_Click (object sender, EventArgs e)
        {
			using var form = new CreateData ( );
			int total = 0, delimindx = 0;
			form.Text = "Export Bulk Customer Style Data";

			var result = form.ShowDialog ( );
			if ( result == DialogResult.OK )
			{
				// these values are specified in the dialog form as well as ** publics **
				total = form.ReturnValue;            //values preserved after close
				delimindx = form.ReturnValue2;   //values preserved after close
				string del = "";
				if ( delimindx == 0 ) del = ",";
				if ( delimindx == 1 ) del = "\\t";
				if ( delimindx == 2 ) del = ":";
				else del = "~";
				Utils.GenerateCustomerDataFile (total, delimindx);
				Output2.AppendText ("A data file of " + total.ToString ( ) + " Customer style records using [ " + del + "] as a delimiter  has been generated\r\n");
				Output2.ScrollToCaret ( );
			}
		}
        private void bankStyleDataToolStripMenuItem_Click (object sender, EventArgs e)
        {
			// Create bulk data 
			// This is the best way to handle dialogs and get data values back
			using var form = new CreateData ( );
			int total = 0, delimindx = 0;
			form.Text = "Export Bulk Bank Style Data";
			var result = form.ShowDialog ( );
			if ( result == DialogResult.OK )
			{
				// these values are specified in the dialog form as well as ** publics **
				total = form.ReturnValue;            //values preserved after close
				delimindx = form.ReturnValue2;   //values preserved after close
				string del = "";
				if ( delimindx == 0 ) del = ",";
				if ( delimindx == 1 ) del = "\\t";
				if ( delimindx == 2 ) del = ":";
				else del = "~";
				Utils.GenerateBankDataFile (total, delimindx);
				Output2.AppendText ("A data file of " + total.ToString ( ) + " Bank Account style records using [ " + del + "] as a delimiter  has been generated\r\n");
				Output2.ScrollToCaret ( );
			}
		}
        /*        internal void CallSQLOpen()
                {
                    if (ConnectSQL())
                    {
                        SQLMarker.Checked = true;
                        SQL_Connect.Enabled = false;
                        SQL_Connect.BackColor = Color.LightGray;
                        SQL_Connect.ForeColor = Color.CornflowerBlue;

                        SQLDisconnect.Enabled = true;
                        SQLDisconnect.BackColor = Color.SeaGreen;
                        SQLDisconnect.ForeColor = Color.White;

                        Output2.AppendText("Connected to SQL Server successful...\r\n");
                        WinInfo.Text = "Successfully Connected to SQL Server";
                    }
                    else
                    {
                        SQLMarker.Checked = false;
                        SQL_Connect.Enabled = true;
                        SQL_Connect.BackColor = Color.SeaGreen;
                        SQL_Connect.ForeColor = Color.White;

                        SQLDisconnect.BackColor = Color.LightGray;
                        SQLDisconnect.ForeColor = Color.CornflowerBlue;
                        SQLDisconnect.Enabled = false;

                        Output2.AppendText("Sorry, Connecting to SQL Server FAILED...\r\n");
                        WinInfo.Text = "Sorry, connection to SQL Server FAILED...";
                    }

                }
        */        // BANK LOG LIST OPTIONS
                  //**************************************************************************************************************************//
        private void toolStripComboBox1_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            // NOT USED - MAIN MENU BAR ENTRY
        }
        //**************************************************************************************************************************//
        private void fileCountOnlyToolStripMenuItem_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            // get bank log data - level 1 count only
            List<string> data = new List<string> ( );
            data = Logger.GetLogStats ( 1, 1 );    // Bank level 1, count only
            Output2.AppendText ( "\r\nBank Log system contains " + data[0] + " log files.\r\n\r\n" );
            Output2.ScrollToCaret ( );
        }
        //**************************************************************************************************************************//
        private void countFileNamesToolStripMenuItem_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            // get bank log data Level 2, include list of file names
            List<string> data = new List<string> ( );
            data = Logger.GetLogStats ( 1, 2 );
            Output2.AppendText ( "\r\nBank Log system contains " + data[0] + " log files, as listed below :-\r\n" );
            Output2.ScrollToCaret ( );
            int count = 0;
            foreach ( string lines in data )
            {
                if ( count++ == 0 ) continue;
                {       // first element contains count, which we have handled
                    Output2.AppendText ( lines );
                    Output2.ScrollToCaret ( );
                }
                count++;
            }
            Output2.AppendText ( "End of Log file reporting...\r\n" );
            Output2.ScrollToCaret ( );
        }
        //**************************************************************************************************************************//
        private void countFilewNamesFileContentsToolStripMenuItem_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            // get bank log data Level 2
            int count = 0;
            List<string> data = new List<string> ( );
            List<string> names = new List<string> ( );

            data = Logger.GetLogStats ( 1, 3 );
            Output2.AppendText ( "\r\nBank  Log system contains " + data[0] + " log files, as listed below :-\r\n" );

            foreach ( string lines in data )
            {
                if ( count > 0 )
                {
                    if ( count >= data.Count ) break;
                    Output2.AppendText ( lines );
                    // now add file contents
                    Output2.ScrollToCaret ( );
                    count++;
                }
                else count++;
            }
            Output2.AppendText ( "End of Log file reporting...\r\n" );
            Output2.ScrollToCaret ( );
        }

        //  CUSTOMER LOG LIST OPTIONS
        //**************************************************************************************************************************//
        private void fileCountOnlyToolStripMenuItem1_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            // get bank log data - level 1 count only
            List<string> data = new List<string> ( );
            data = Logger.GetLogStats ( 2, 1 );    // Bank level 1, count only
            Output2.AppendText ( "\r\nCustomer Log system contains " + data[0] + " log files.\r\n\r\n" );
            Output2.ScrollToCaret ( );
        }
        private void countFileNamesToolStripMenuItem1_Click (object sender, EventArgs e)
        {
            // get bank log data Level 2, include list of file names
            List<string> data = new List<string> ( );
            data = Logger.GetLogStats ( 2, 2 );
            Output2.AppendText ( "\r\nCustomer Log system contains " + data[0] + " log files, as listed below :-\r\n" );
            Output2.ScrollToCaret ( );
            int count = 0;
            foreach ( string lines in data )
            {
                if ( count++ == 0 ) continue;
                {       // first element contains count, which we have handled
                    Output2.AppendText ( lines );
                    Output2.ScrollToCaret ( );
                }
                count++;
            }
            Output2.AppendText ( "End of Log file reporting...\r\n" );
            Output2.ScrollToCaret ( );
        }
        //**************************************************************************************************************************//
        private void countNamesContentsToolStripMenuItem_Click (object sender, EventArgs e)
        //**************************************************************************************************************************//
        {
            // get bank log data Level 2
            int count = 0;
            List<string> data = new List<string> ( );
            List<string> names = new List<string> ( );

            data = Logger.GetLogStats ( 2, 3 );
            Output2.AppendText ( "\r\nCustomer Log system contains " + data[0] + " log files, as listed below :-\r\n" );

            // get file names in a seperate ,list
            //            for (int i = 1; i <= Convert.ToInt16(data[0]); i++)
            //            { names.Add(data[i]); }

            foreach ( string lines in data )
            {
                if ( count > 0 )
                {
                    if ( count >= data.Count ) break;
                    //                Output2.AppendText("FILE NAME : " + names[count2++] + "\r\n");
                    Output2.AppendText ( lines );
                    // now add file contents
                    Output2.ScrollToCaret ( );
                    count++;
                }
                else count++;
            }
            Output2.AppendText ( "End of Log file reporting...\r\n" );
            Output2.ScrollToCaret ( );
        }

        //**********************
        // testing only
        //**************************************************************************************************************************//
        class FindControl
        //**************************************************************************************************************************//
        //**********************
        {
            FormCollection fc = Application.OpenForms;
            Control c = null;
            Control f = null;
            public Control TheForm (string name)
            {
                for ( int i = 0; i < fc.Count; i++ )
                {
                    c = null;
                    if ( fc[i].Name == name )
                    {
                        f = fc[i];
                        break;
                    }
                }
                return ( ( Control ) f );
            }
            public Control Ctrl (Control f, string name)
            {// look for control we want by name
                for ( int i = 0; i < fc.Count; i++ )
                {
                    if ( f.Controls[i].Name == name )
                    {
                        c = f.Controls[i];
                        break;
                    }
                    if ( c == null )
                    {
                        if ( f.Controls[i].Controls.Count > 0 )
                            Ctrl ( f.Controls[i], name );
                    }
                    //found the control, get out of here
                    if ( c != null )
                        break;
                }
                return ( c );
            }

        }   // End Class FindControl
        private void exitToolStripMenuItem_Click (object sender, EventArgs e)
        { CloseDown ( ); Close ( ); }


        //---------------------------------------------------------------------------
        private void bldCustList_MouseEnter (object sender, EventArgs e)
        { bldCustList.BackColor = Color.LightGray; }
        private void bldCustList_MouseLeave_1 (object sender, EventArgs e)
        { bldCustList.BackColor = Color.Yellow; }
        //---------------------------------------------------------------------------
        private void RebuildCustLL_MouseEnter (object sender, EventArgs e)
        { RebuildCustLL.BackColor = Color.LightGray; }
        private void RebuildCustLL_MouseLeave_1 (object sender, EventArgs e)
        { RebuildCustLL.BackColor = Color.Yellow; }
        //---------------------------------------------------------------------------
        private void RebuildBankFromText_MouseEnter (object sender, EventArgs e)
        { RebuildBankFromText.BackColor = Color.LightGray; }
        private void RebuildBankFromText_MouseLeave (object sender, EventArgs e)
        { RebuildBankFromText.BackColor = Color.Lime; }
        //---------------------------------------------------------------------------
        private void RebuildBankLL_MouseEnter (object sender, EventArgs e)
        { RebuildBankLL.BackColor = Color.LightGray; }
        private void RebuildBankLL_MouseLeave (object sender, EventArgs e)
        { RebuildBankLL.BackColor = Color.Lime; }
        //---------------------------------------------------------------------------
        private void button3_MouseEnter (object sender, EventArgs e)
        { button3.BackColor = Color.LightGray; }
        private void button3_MouseLeave (object sender, EventArgs e)
        { button3.BackColor = Color.Yellow; }
        //---------------------------------------------------------------------------
        private void BAEdit_MouseEnter (object sender, EventArgs e)
        { BAEdit.BackColor = Color.LightGray; }
        private void BAEdit_MouseLeave_1 (object sender, EventArgs e)
        { BAEdit.BackColor = Color.Yellow; }
        //---------------------------------------------------------------------------
        private void BankTxtOutputButton_MouseEnter (object sender, EventArgs e)
        { BankTxtOutputButton.BackColor = Color.LightGray; }
        private void BankTxtOutputButton_MouseLeave_1 (object sender, EventArgs e)
        { BankTxtOutputButton.BackColor = Color.Yellow; }
        //---------------------------------------------------------------------------
        private void CustEdit_MouseEnter (object sender, EventArgs e)
        { CustEdit.BackColor = Color.LightGray; }
        private void CustEdit_MouseLeave_1 (object sender, EventArgs e)
        { CustEdit.BackColor = Color.Lime; }
        //---------------------------------------------------------------------------
        private void MakeHashTables_MouseEnter (object sender, EventArgs e)
        { MakeHashTables.BackColor = Color.LightGray; }
        private void MakeHashTables_MouseLeave_1 (object sender, EventArgs e)
        { MakeHashTables.BackColor = Color.Red; }
        //---------------------------------------------------------------------------
        private void ListSeedData_MouseEnter (object sender, EventArgs e)
        {
            ListSeedData.ForeColor = Color.DimGray;
            ListSeedData.BackColor = Color.White;
        }
        private void ListSeedData_MouseLeave_1 (object sender, EventArgs e)
        {
            ListSeedData.ForeColor = Color.White;
            ListSeedData.BackColor = Color.Gray;
        }
        //---------------------------------------------------------------------------
        private void listhashtables_MouseEnter (object sender, EventArgs e)
        {
            listhashtables.ForeColor = Color.DimGray;
            listhashtables.BackColor = Color.White;
        }
        private void listhashtables_MouseLeave_1 (object sender, EventArgs e)
        {
            listhashtables.ForeColor = Color.White;
            listhashtables.BackColor = Color.Gray;
        }
        //---------------------------------------------------------------------------
        private void RunBank_MouseEnter (object sender, EventArgs e)
        {
            RunBank.ForeColor = Color.Blue;
            RunBank.BackColor = Color.White;
        }
        private void RunBank_MouseLeave_1 (object sender, EventArgs e)
        {
            RunBank.ForeColor = Color.White;
            RunBank.BackColor = Color.Blue;
        }
        //---------------------------------------------------------------------------
        private void ClearButton_MouseEnter (object sender, EventArgs e)
        {
            ClearButton.ForeColor = Color.Red;
            ClearButton.BackColor = Color.White;
        }
        private void ClearButton_MouseLeave (object sender, EventArgs e)
        {
            ClearButton.ForeColor = Color.White;
            ClearButton.BackColor = Color.Red;
        }
        //---------------------------------------------------------------------------
        private void CloseButton_MouseEnter (object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
            CloseButton.BackColor = Color.Red;
        }
        private void CloseButton_MouseLeave (object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black;
            CloseButton.BackColor = Color.LightSteelBlue;
        }
        private void BanklistFromLinkedList_MouseEnter (object sender, EventArgs e)
        { BanklistFromLinkedList.BackColor = Color.LightGray; }
        private void BanklistFromLinkedList_MouseLeave_1 (object sender, EventArgs e)
        { BanklistFromLinkedList.BackColor = Color.Yellow; }
        private void listbankaccounts_MouseEnter (object sender, EventArgs e)
        { listbankaccounts.BackColor = Color.LightGray; }
        private void listbankaccounts_MouseLeave_1 (object sender, EventArgs e)
        { listbankaccounts.BackColor = Color.Yellow; }
        private void newbanktrans_MouseEnter (object sender, EventArgs e)
        { newbanktrans.BackColor = Color.LightGray; }
        private void newbanktrans_MouseLeave (object sender, EventArgs e)
        { newbanktrans.BackColor = Color.Yellow; }
        private void BankWithdrawbutton_MouseEnter (object sender, EventArgs e)
        { BankWithdrawbutton.BackColor = Color.LightGray; }
        private void BankWithdrawbutton_MouseLeave (object sender, EventArgs e)
        { BankWithdrawbutton.BackColor = Color.Yellow; }
        private void AddSecondaryBank_MouseEnter (object sender, EventArgs e)
        { AddSecondaryBank.BackColor = Color.LightGray; }
        private void AddSecondaryBank_MouseLeave (object sender, EventArgs e)
        { AddSecondaryBank.BackColor = Color.Yellow; }
        private void button1_MouseEnter (object sender, EventArgs e)
        { button1.BackColor = Color.LightGray; }
        private void button1_MouseLeave (object sender, EventArgs e)
        { button1.BackColor = Color.Yellow; }
        private void ListLink_MouseEnter (object sender, EventArgs e)
        { ListLink.BackColor = Color.LightGray; }
        private void ListLink_MouseLeave (object sender, EventArgs e)
        { ListLink.BackColor = Color.Lime; }
        private void ListSortedCustomers_MouseEnter (object sender, EventArgs e)
        { ListSortedCustomers.BackColor = Color.LightGray; }
        private void ListSortedCustomers_MouseLeave (object sender, EventArgs e)
        { ListSortedCustomers.BackColor = Color.Lime; }
        private void NewCustButton_MouseEnter (object sender, EventArgs e)
        { NewCustButton.BackColor = Color.LightGray; }
        private void NewCustButton_MouseLeave (object sender, EventArgs e)
        { NewCustButton.BackColor = Color.Lime; }
        private void UpdateCustomer_MouseEnter (object sender, EventArgs e)
        { UpdateCustomer.BackColor = Color.LightGray; }
        private void UpdateCustomer_MouseLeave (object sender, EventArgs e)
        { UpdateCustomer.BackColor = Color.Lime; }
        private void DeleteCustomer_MouseEnter (object sender, EventArgs e)
        { DeleteCustomer.BackColor = Color.LightGray; }
        private void DeleteCustomer_MouseLeave (object sender, EventArgs e)
        { DeleteCustomer.BackColor = Color.Yellow; }
        private void CustplusBank_MouseEnter (object sender, EventArgs e)
        { CustplusBank.BackColor = Color.LightGray; }
        private void CustplusBank_MouseLeave (object sender, EventArgs e)
        { CustplusBank.BackColor = Color.Goldenrod; }
        private void Sortarrays_MouseEnter (object sender, EventArgs e)
        { Sortarrays.BackColor = Color.LightGray; }
        private void Sortarrays_MouseLeave (object sender, EventArgs e)
        { Sortarrays.BackColor = Color.GreenYellow; }
        private void CreatenewBankAccount_MouseEnter (object sender, EventArgs e)
        { CreatenewBankAccount.BackColor = Color.LightGray; }
        private void CreatenewBankAccount_MouseLeave (object sender, EventArgs e)
        { CreatenewBankAccount.BackColor = Color.GreenYellow; }
        private void SQL_Connect_MouseEnter (object sender, EventArgs e)
        {
            SQL_Connect.ForeColor = Color.SeaGreen;
            SQL_Connect.BackColor = Color.White;
        }
        private void SQL_Connect_MouseLeave (object sender, EventArgs e)
        {
            SQL_Connect.ForeColor = Color.White;
            SQL_Connect.BackColor = Color.SeaGreen;
        }
        private void SQLDisconnect_MouseEnter (object sender, EventArgs e)
        {
            SQLDisconnect.ForeColor = Color.SeaGreen;
            SQLDisconnect.BackColor = Color.White;
        }
        private void SQLDisconnect_MouseLeave (object sender, EventArgs e)
        {
            SQLDisconnect.ForeColor = Color.White;
            SQLDisconnect.BackColor = Color.SeaGreen;
        }
        private void bankasc_MouseEnter (object sender, EventArgs e)
        { bankasc.ForeColor = Color.Red; }
        private void bankasc_MouseLeave (object sender, EventArgs e)
        { bankasc.ForeColor = Color.Black; }

        private void SQLQuery_MouseEnter (object sender, EventArgs e)
        {
            SQLQuery.ForeColor = Color.White;
            SQLQuery.BackColor = Color.LightGray;
        }
        private void SQLQuery_MouseLeave (object sender, EventArgs e)
        {
            SQLQuery.ForeColor = Color.Black;
            SQLQuery.BackColor = Color.Thistle;
        }
        private void bankadesc_MouseEnter (object sender, EventArgs e)
        { bankadesc.ForeColor = Color.Red; }
        private void bankadesc_MouseLeave (object sender, EventArgs e)
        { bankadesc.ForeColor = Color.Black; }
        private void banklasc_MouseEnter (object sender, EventArgs e)
        { banklasc.ForeColor = Color.Red; }
        private void banklasc_MouseLeave (object sender, EventArgs e)
        { banklasc.ForeColor = Color.Black; }
        private void bankldesc_MouseEnter (object sender, EventArgs e)
        { bankldesc.ForeColor = Color.Red; }
        private void bankldesc_MouseLeave (object sender, EventArgs e)
        { bankldesc.ForeColor = Color.Black; }
        private void custaasc_MouseEnter (object sender, EventArgs e)
        { custaasc.ForeColor = Color.Red; }
        private void custaasc_MouseLeave (object sender, EventArgs e)
        { custaasc.ForeColor = Color.Black; }
        private void custadesc_MouseEnter (object sender, EventArgs e)
        { custadesc.ForeColor = Color.Red; }
        private void custadesc_MouseLeave (object sender, EventArgs e)
        { custadesc.ForeColor = Color.Black; }
        private void custlasc_MouseEnter (object sender, EventArgs e)
        { custlasc.ForeColor = Color.Red; }
        private void custlasc_MouseLeave (object sender, EventArgs e)
        { custlasc.ForeColor = Color.Black; }
        private void custldesc_MouseEnter (object sender, EventArgs e)
        { custldesc.ForeColor = Color.Red; }
        private void custldesc_MouseLeave (object sender, EventArgs e)
        { custldesc.ForeColor = Color.Black; }

		private void Output2_TextChanged (object sender, EventArgs e)
		{

		}

		private void SQL_Connect_Click (object sender, EventArgs e)
		{
			SqlConnector sqconnector = new SqlConnector ( );
			sqconnector.Show( );
		}

		private void SQLQuery_Click (object sender, EventArgs e)
		{
			SqlConnector sql = new SqlConnector ( );
			sql.ShowDialog ( );

		}



		//---------------------------------------------------------------------------
		//---------------------------------------------------------------------------
	}
}   // End NAMESPACE
