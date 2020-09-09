// we HAVE to put or #defines up here
#define SHOWCUSTDATATWICE
#undef SHOWCUSTDATATWICE

#define DODELETEOFCUSTOMERS
#undef DODELETEOFCUSTOMERS

#define DODELETEOFBANKACCOUNTS
#undef DODELETEOFBANKACCOUNTS

using System;
using System . Collections . Generic;
using System . Drawing;
using System . Windows . Forms;
using System . Linq;
/*
  This project is being used to test Class access methodology in some detail.
    I will use Public, Private, Internal, Static and all combinations to see what 
    access is possible with what combinations.

    THIS IS THE MAIN WINDOW's SOURCE FILE

 * */

namespace ClassAccessTest
{
	public delegate string MyDel ( string str );

	public partial class Form1 : Form
	{
		private const string TerminatorText = "---------------------------------------------------------------------------------------\r\n";
		public static int _direction = 0;
		//*********************************************************************************//
		/*
				class EventProgram
				{

					public event MyDel MyEvent;

					public EventProgram ( )
					{
						string txt = ";";
						this . MyEvent += new MyDel ( this . printtxt );
					}
					public string printtxt ( string str )
					{
						return "dfsgdsgfs";
					}

					public static void test ( )
					{
						EventProgram obj1 = new EventProgram ( );
						string result = obj1 . MyEvent ( "ian Turner" );
						output = new output;
						output . AppendText ( "" );

					}
				}
		*/
		//public static  TextBox output;

		public Form1 ( )
		//*********************************************************************************//
		{
			InitializeComponent ( );
			//			TextBox output = new TextBox();
			//		output = Output2;
			// Auito login to SQL server
			this . Cursor = Cursors . WaitCursor;
			WinInfo . Text = "Please wait,  connecting to SQL Server...";
			Output2 . AppendText ( "Connecting to SQL Server...\r\n" );
			if ( ConnectSQL ( ) )
			{
				SQLMarker . Checked = true;
				SQL_Connect . Enabled = false;
				SQL_Connect . BackColor = Color . LightGray;
				SQL_Connect . ForeColor = Color . CornflowerBlue;

				SQLDisconnect . Enabled = true;
				SQLDisconnect . BackColor = Color . SeaGreen;
				SQLDisconnect . ForeColor = Color . White;

				Output2 . AppendText ( "Connected to SQL Server successful...\r\n" );
				WinInfo . Text = "Successfully Connected to SQL Server";
			}
			else
			{
				SQLMarker . Checked = false;
				SQL_Connect . Enabled = true;
				SQL_Connect . BackColor = Color . SeaGreen;
				SQL_Connect . ForeColor = Color . White;

				SQLDisconnect . BackColor = Color . LightGray;
				SQLDisconnect . ForeColor = Color . CornflowerBlue;
				SQLDisconnect . Enabled = false;

				Output2 . AppendText ( "Sorry, Connecting to SQL Server FAILED...\r\n" );
				WinInfo . Text = "Sorry, connection to SQL Server FAILED...";
			}
			Output2 . AppendText ( "Welcome to the C# Bank Account Test System in development as we speak by Ian Turner !!\r\n" );

			// read our various static globals from disk & set them up again in the Application
			// if it doesn't exist, we rebuild it automatically to default values
			ConfigData . ReadConfigData ( );
			Output2 . AppendText ( "System configuration data loaded successfully...\r\n" );

			// here we go, now get ALL the Customer data back in from disk
			// Now, lets discover exactly how many customer objects we have
			//this loads the Customer  hastable only with customers but NOT the Sorted Array
			var totalcusts = Customer . LoadAllCustomerDataFiles ( "*.cust" );
			Customer . SetTotalCustomers ( Convert . ToInt16 ( totalcusts ) );
			Output2 . AppendText ( "Customer accounts verified successfully...\r\n" );
			// just for testing  27.8.2019
			//			StringBuilder custfiles = Customer . ReadCustSortedListFromText ( );
			//			string custfilesfromtext = custfiles . ToString ( );
			//			Lists . ParseCustSortedListText ( custfilesfromtext );
			// load both the hash tables from disk
			CustomerBalanceHashTable . LoadHashCustBalTable ( );
			CustomerFileHashTable . LoadHashFileHashTableFromDisk ( );
			Output2 . AppendText ( "Both Hash tables loaded successfully......\r\n" );
			// here we go, now get ALL the BankAccount data back in from disk
			// We Load all our bank accounts into the BankAccount.LinkedList
			// And the Customers into the Customer LinkedList

			// create our bank transactions list
			BankTransaction . allBankTransactions = new LinkedList<BankTransaction> ( );
			// first we need to load the bank transactions file off TXT file from disk.
			int count = BankTransaction . BuildBankTransactionsFromTextfile ( );
			Output2 . AppendText ( "There are " + count . ToString ( ) + " Bank Transactions loaded from the TextFile successfully...\r\n" );

			// load our new ArrayList's system with data via all OBJ files
			DataArray Dataarray = new DataArray ( );
			int Bcount = 0;
			int Ccount = 0;
			// This loads all  Bank A/C's nd Customer A/C's form the disk files
			//and adds them to the respective LinkedLists plus adding them 
			//into DataArray.CustNo and DataArray.BankNo
			Int16 arraycount = Dataarray . LoadArraysFromDisk ( out Bcount, out Ccount );
			_direction = 0;	// set sort to alphabetical
			DataArray . BankNo . Sort ( );
			_direction = 1;// set sort to reverse alphabetical
			DataArray . BankNo . Sort ( );
			Output2 . AppendText ( "There are " + arraycount . ToString ( ) + " Bank Account files in our Bank system...\r\n" );
			Output2 . AppendText ( "There are " + Bcount . ToString ( ) + " Bank Accounts loaded in our Bank SortedList...\r\n" );
			Output2 . AppendText ( "There are " + Ccount . ToString ( ) + " Customer Accounts loaded in our Customer SortedList...\r\n" );

			// now we will have access to Arrays.Dataarray[] that contains access to all three other arrays 
			Output2 . AppendText ( "Arrays setup data loaded successfully...\r\n" );
			// Dont forget to update all our static counters to match the customers we have juist read in from disk
			Output2 . AppendText ( "Housekeeping task completed successfully...\r\n" );
			Output2 . AppendText ( "internal LinkedList of Bank Accounts loaded successfully...\r\n" );
			// now get the data and build our linkedlist 
			Output2 . AppendText ( "There appear to be  " + totalcusts + " Customer accounts \r\n" );
			Output2 . AppendText ( "and " + BankAccount . ReadTotalBanks ( ) . ToString ( ) + " Bank Accounts currently in the system...\r\n" );
			Output2 . AppendText ( "\r\n -------->>>> [System is now ready for use.]  <<<<---------\r\n\r\n" );
			this . Cursor = Cursors . Default;
			Output2 . ScrollToCaret ( );
			//IEnumerator IE = BankAccount. GetEnumerator ( );
			//CustomerFileHashTable . FindCustomerObject ( (Int32)1234504 );
		}


		//*********************************************************************************//
		private void RunBank_Click_2 ( object sender, EventArgs e )
		//*********************************************************************************//
		{
			// This code works fine and create multiple transactions records
			// and the Account # incrments each pass thru it.
			WinInfo . Text = "";
			CreateBankaccount ( );
			listbankaccounts_Click ( sender, e );
		}

		//show the  create a new customer window
		//*********************************************************************************//
		private void NewCustButton_Click_1 ( object sender, EventArgs e )
		//*********************************************************************************//
		{
			WinInfo . Text = "";
			// find the a/c we want
			// Open customer data window
			CustomerInput B = new CustomerInput ( );
			B . Show ( );// create a data input window for customer details.
			WinInfo . Text = "New Customer added successfully...";
			ListSortedCustomers_Click ( sender, e );

		}

		// Close window
		//*********************************************************************************//
		private void CloseButton_Click ( object sender, EventArgs e )
		//*********************************************************************************//
		{
			WinInfo . Text = "";
			CloseDown ( );
		}
		private void CloseDown ( )
		{
			// We need to save our LINKEDLIST 1st
			Lists . SaveAllCustomerListData ( Customer . CustomerFilePath + "AllCustomersData.cust" );
			// and our sortedlist
			Customer . SaveSortedCustomerListToText ( );
			// Save BOTH the hash table to disk
			CustomerFileHashTable . SaveHashFileTableToDisk ( );
			CustomerBalanceHashTable . SaveHashCustBalTable ( );
			// This saves all our transactions data linked list
			SerializeData . WriteBankTransactionsToDisk ( );
			// This uses the LinkedList to create individual bankaccount objects
			Lists . SaveAllBankAccountListData ( );
			ConfigData . SaveConfigData ( );        // save our various seed number for account numbering so we can get them back (Persistence)
													// Check for SQL connection and close if necessary
													//			DataArray . SaveArrayData ( );
			if ( SQLAccess . SQLconnection )
				SQLAccess . SQLDisConnect ( );
			// we have saved some form data here
			// so we can go ahead and Close the App  down
			this . Close ( );
		}
		//*********************************************************************************//
		private void UpdateCustomer_Click_1 ( object sender, EventArgs e )
		//*********************************************************************************//
		{
			WinInfo . Text = "";
			// find the a/c we want
			// Open customer data edit window
			UpdateCustomer C = new UpdateCustomer ( );
			C . Show ( );// create a data input window for customer details.
		}

		//***************
		// BANK stuff
		//*********************************************************************************//
		// Create new deposit
		//*********************************************************************************//
		private void newbanktrans_Click ( object sender, EventArgs e )
		{
			// Display the make deposit Window
			// First, select the required Bank account
			MakeBankDeposit BD = new MakeBankDeposit ( );
			BD . Show ( );
		}
		//*********************************************************************************//
		private void DeleteCustomer_Click ( object sender, EventArgs e )
		{
			CustomerDeleteForm C = new CustomerDeleteForm ( );
			C . Show ( );
		}
		//*********************************************************************************//
		public void CustOutputButton_Click ( object sender, EventArgs e ) { CustomerDeleteForm D = new CustomerDeleteForm ( ); D . Show ( ); }
		//*********************************************************************************//
		private void ClearButton_Click_1 ( object sender, EventArgs e ) { WinInfo . Text = ""; Output2 . Clear ( ); }
		//*********************************************************************************//
		private void BankWithdrawbutton_Click_1 ( object sender, EventArgs e ) { withdrawl wd = new withdrawl ( ); wd . Show ( ); }
		//*********************************************************************************//
		public static bool ConnectSQL ( ) { if ( SQLAccess . SQLConnect ( ) ) return true; else return false; }
		//*********************************************************************************//
		///Open our SQL database connection
		//*********************************************************************************//
		private void SQL_Connect_Click_2 ( object sender, EventArgs e )
		//*********************************************************************************//
		{
			this . Cursor = Cursors . WaitCursor;
			WinInfo . Text = "Please wait,  connecting to SQL Server...";
			if ( ConnectSQL ( ) )
			{
				SQLMarker . Checked = true;
				SQL_Connect . Enabled = false;
				SQL_Connect . BackColor = Color . Silver;
				SQL_Connect . ForeColor = Color . Gray;
				SQLDisconnect . Enabled = true;
				SQLDisconnect . BackColor = Color . SeaGreen;
				SQLDisconnect . ForeColor = Color . White;

				WinInfo . Text = "Successfully Connected to SQL Server";
			}
			else WinInfo . Text = "Sorry, connection to SQL Server FAILED...";
			this . Cursor = Cursors . Default;
		}

		// List all bank accounts
		//*********************************************************************************//
		private void button1_Click_1 ( object sender, EventArgs e ) { Output2 . AppendText ( Lists . ListAllBankTransactions ( ) ); Output2 . ScrollToCaret ( ); }
		//*********************************************************************************//

		//*********************************************************************************//
		private void BankTxtOutputButton_Click ( object sender, EventArgs e )
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
		private void SQLDisconnect_Click ( object sender, EventArgs e )
		//*********************************************************************************//
		{
			SQLAccess . SQLDisConnect ( );
			SQLMarker . Checked = false;
			SQL_Connect . Enabled = true;
			SQL_Connect . BackColor = Color . SeaGreen;
			SQL_Connect . ForeColor = Color . White;
			SQLDisconnect . BackColor = Color . Silver;
			SQLDisconnect . ForeColor = Color . Gray;
			SQLDisconnect . Enabled = false;
			this . Cursor = Cursors . Default;
			WinInfo . Text = "Disconnected from SQL Server";
		}

		// This is this the  name of the Connect SQL button in DEsign ??
		//  but c# does not call it         ??
		//*********************************************************************************//
		private void SQL_Connect_Click ( object sender, EventArgs e )
		//*********************************************************************************//
		{ ConnectSQL ( ); }

		//*********************************************************************************//
		private void ListSeedData_Click_1 ( object sender, EventArgs e )
		//*********************************************************************************//
		{
			string [ ] array;
			/*
												//now reset the variables in the class so we are READY TO START PROCESSING
								Customer.SetCustomerNumberSeed(Convert.ToInt32(datain[0]));
								Customer.SetCustomerFileNumberSeed(Convert.ToInt16(datain[1]));
								BankAccount.SetBankFileNumberSeed(Convert.ToInt16(datain[2]));
								BankAccount.SetBankAccountNumberSeed(Convert.ToInt32(datain[3]));
								BankAccount.SetTotalBanks(Convert.ToInt16(datain[4]));
						   }
* 
			 * */
			Output2 . AppendText ( "Current setting of all 4 seed values used\r\n" );
			array = Customer . ReadAllSeedData ( ); // non incrmenting version
			string txt = "Customer Account # Seed = " + array [ 0 ] + "\r\n" +
							  "Bank Account # Seed       = " + array [ 1 ] + "\r\n" +
							  "Total Bank Accounts        = " + array [ 2 ] + "\r\n\r\n";
			Output2 . AppendText ( txt );
			Output2 . AppendText ( TerminatorText );
			//Output2 . AppendText ( "===========================================================================\r\n" );
			Output2 . ScrollToCaret ( );
		}

		//Create the hash tables
		//*********************************************************************************//
		private void listhashtables_Click_1 ( object sender, EventArgs e )
		//*********************************************************************************//
		{
			Output2 . AppendText ( "List of all entries from the TWO Customer based Hash Tables:\r\n" );
			Output2 . AppendText ( "First a List of all entries in the A/C Balance Hash Tables:\r\n" );

			//create a sorted list (Descending order) from our Dictionary
			// create the sort on the fly
			SortedList<string, string> ascSortedList1 = Lists . GetAscendingSortedHashTable ( CustomerBalanceHashTable . CustNoBalHashTable );
			// now we got a sortedliast, display it
			if ( ascSortedList1 . Count > 0 )
				Output2 . AppendText ( "___________________________________________________________________________\r\n" );
			Output2 . AppendText ( "Account #\tBalance :\r\n" );
			for ( int i = 0 ; i < ascSortedList1 . Count ; i++ )
			{
				string CurrencyAmount = Utils . GetCurrencyString ( ascSortedList1 . Values [ i ] . ToString ( ) );
				Output2 . AppendText ( ascSortedList1 . Keys [ i ] . ToString ( ) + "\t\t" + CurrencyAmount + "\r\n" );
				//string CurrencyAmount = Utils.GetCurrencyString(ascSortedList1.Values[i].ToString());
				//					Output.AppendText(ascSortedList1.Keys[i].ToString() + "\t\t" + CurrencyAmount+ "\r\n");
				Output2 . ScrollToCaret ( );
			}
			if ( ascSortedList1 . Count > 0 )
				Output2 . AppendText ( "___________________________________________________________________________\r\n" );
			//------------------------------------------------------------------------------------------------------------------------------------------------
			//create a sorted list (Descending order) from our Dictionary
			// create the sort on the fly

			SortedList<string, string> ascSortedList2 = Lists . GetAscendingSortedHashTable ( CustomerFileHashTable . CustFileNoHashTable );
			// now we got a sortedliast, display it
			Output2 . AppendText ( "Account # \t#Filenames :\r\n" );
			for ( int i = 0 ; i < ascSortedList2 . Count ; i++ )
			{
				Output2 . AppendText ( ascSortedList2 . Keys [ i ] . ToString ( ) + "\t\t" + ascSortedList2 . Values [ i ] . ToString ( ) + "\r\n" );
				Output2 . ScrollToCaret ( );
			}
			Output2 . AppendText ( TerminatorText );
			//Output2 . AppendText ( "===========================================================================\r\n" );
			Output2 . ScrollToCaret ( );
			//------------------------------------------------------------------------------------------------------------------------------------------------
		}

		//*********************************************************************************//
		protected override void OnTextChanged ( EventArgs e ) { Output2 . ScrollToCaret ( ); }
		//*********************************************************************************//
		private void Output_TextChanged ( object sender, EventArgs e ) { Output2 . ScrollToCaret ( ); }
		//*********************************************************************************//
		private void MakeHashTables_Click_1 ( object sender, EventArgs e )
		{
			CustomerBalanceHashTable . ReBuildHashBalTable ( );
			CustomerFileHashTable . ReBuildHashFileTable ( );
		}
		//*********************************************************************************//
		//*********************************************************************************//

		private void button2_Click ( object sender, EventArgs e )
		{     // testing the code in CollectionTest.cs
			  // that uses the <T> generic collections facilities
			int [ ] x;
			x = CollectionTestClass<int> . test . runit ( );
			Output2 . AppendText ( "Output from the use of a generic <T> collection:\r\n" );
			for ( int i = 0 ; i < x . Length ; i++ )
			{
				Output2 . AppendText ( x [ i ] . ToString ( ) + ", " );
			}
			Output2 . AppendText ( "\r\nEnd of output from a generic <T> collection:\r\n" );
			Output2 . AppendText ( TerminatorText );
			//Output2 . AppendText ( "===========================================================================\r\n" );
			Output2 . ScrollToCaret ( );
		}

		//**************************************************************************************************************************//
		private void CheckNormal_CheckedChanged ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{
			if ( CheckNormal . Checked )
			{
				CheckDeposit . Checked = false;
				CheckSavings . Checked = false;
				CheckBusiness . Checked = false;
			}
		}
		//**************************************************************************************************************************//
		private void CheckDeposit_CheckedChanged ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{
			if ( CheckDeposit . Checked )
			{
				CheckNormal . Checked = false;
				CheckSavings . Checked = false;
				CheckBusiness . Checked = false;
			}
		}

		//**************************************************************************************************************************//
		private void CheckSavings_CheckedChanged ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{
			if ( CheckSavings . Checked )
			{
				CheckDeposit . Checked = false;
				CheckNormal . Checked = false;
				CheckBusiness . Checked = false;
			}
		}
		//**************************************************************************************************************************//
		private void CheckBusiness_CheckedChanged ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{
			if ( CheckBusiness . Checked )
			{
				CheckDeposit . Checked = false;
				CheckSavings . Checked = false;
				CheckNormal . Checked = false;
			}
		}



		//*********************************************************************************//
		public void CreateBankaccount ( )
		//*********************************************************************************//

		{
			//*********************************************************************************
			WinInfo . Text = "";
			System . Random random = new System . Random ( );
			int y = random . Next ( 23, 105 );
			string [ ] strs = { random. Next ( 23, 105 ).ToString() + " Windsor Rd",random. Next ( 23, 105 ).ToString() + "  Buckingham Place",
					random. Next ( 23, 105 ).ToString() + "  Faraday Place",random. Next ( 23, 105 ).ToString() + " Wellington Terrace",random. Next ( 23, 105 ).ToString() + " Smithsonian Way",
					random. Next ( 23, 105 ).ToString() + " Flightline Drive",random. Next ( 23, 105 ).ToString() + " Amey Johnson Way",random. Next ( 23, 105 ).ToString() + " Cannibals road",
					random. Next ( 23, 105 ).ToString() + " Regent Street",random. Next ( 23, 105 ).ToString() + " Oxford St",random. Next ( 23, 105 ).ToString() + " Piccadilly",
					random. Next ( 23, 105 ).ToString() + " Lambeth Road",random. Next ( 23, 105 ).ToString() + " Chiltern Way",random. Next ( 23, 105 ).ToString() + " Ketchup avenue",
					random. Next ( 23, 105 ).ToString() + " Brown Sauce Terrace",random. Next ( 23, 105 ).ToString() + " Liitle hedges way",random. Next ( 23, 105 ).ToString() + " Great Missenden Road",
					random. Next ( 23, 105 ).ToString() + " Buckshot Lead",random. Next ( 23, 105 ).ToString() + " Drambuie Way",random. Next ( 23, 105 ).ToString() + " Google Plaza",
					random. Next ( 23, 105 ).ToString() + " Dell Road",random. Next ( 23, 105 ).ToString() + " Compaq Avenue",random. Next ( 23, 105 ).ToString() + " Mistletoe way",
					random. Next ( 23, 105 ). ToString ( ) + " LastEntry Close"};

			string [ ] towns = { " Aldershot",
					 "  Buckingham","  Edinburgh"," Wellington"," Shottley"," Bicester"," Arncott"," Brill"," Chinnor"," St Albanst"," St Annes on Sea"," Lytham St Annes"," Blackpool",
					" Eastcote"," lavington"," Oxford"," Cambridge"," Leicester"," Birmingham"," Lancaster"," New Brunswick"," Corrigador"," Christchurch"," Ely in the  Marsh"};

			string [ ] Countys = { random. Next ( 23, 105 ).ToString()
					+ " Lancashire","  BuckinghamShire","  Waverley"," Highlands & Islands"," Dorset"," Devon"," Cornwall"," Brecon"," Aberystwith"," Anglesey"," Kent"," Sussex",
					" Norfolk"," Suffolk"," Lincolnshire"," Northumberland"," Durham"," Rutland"," Tyneside"," Teeside"," Cumbria"," Lakeland"," Orkneys"," Shetland Islands"};

			string [ ] lname = {
								"Williams","Jones","Turner","Wilkinson","Prosser","Sankey","Logan","Read","Hasselblad","Nikon","Konig","Edwards","Smith","Little","Large",
								"Handscombe","Paddock","Wilson","Dooley","Smythe","Mannering","Halton","Butcher","Baker","Ironmonger" };
			string [ ] fnames = {
								"John","William","Johan","Brian","Hal","Robert","Bob","Jack","Olwen","Elizabeth","Mary","Anne","Susan","Sue","Margaret",
								"Matt","Colin","Martyn","Martin","Jules","Johann","Peter","Joe","Tony","Ron ",};
			double [ ] bal = { 12.45, 2300.10, 567.42, 25000, 1000, 90450, 456, 78, 123.45, 65321.99, 7504.73
									, 12000, 17500, 23600, 9023.65, 67.1, 4.53, 19.83, 12.32, 905.38, 862.41, 9.65, 11.42, 903.56,100.01,};

			double [ ] intrst = { 12.45, 2.3,10.8, 5.42, 2.5, 1.9, 9.5, 6.65,7.8, 3.45, 5.21, 7.5, 2,17.5 , 23.6, 9.65, 6.7, 4.53, 9.83, 12.32, 5.38,
										4.45, 9.32, 3.32, 6.68, 10.00, };

			if ( CheckNormal . Checked )
			{
				int x = random . Next ( 23, 105 );
				string addr = x . ToString ( ) + " AutoGen Road";
				string accno = Customer . GetCustomerNumberSeed ( ) . ToString ( );
				string Tn = random . Next ( 120, 600 ) . ToString ( ) + " ThisTown";
				string pcode = "AC" + random . Next ( 1, 99 ) . ToString ( ) + "ARC ";
				string tel = "0" + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + " "
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( )
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( );
				string mob = "0" + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + " "
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( )
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( );
				string surname = lname [ random . Next ( 0, 24 ) ];
				string fname = fnames [ random . Next ( 0, 24 ) ];
				// MUST do Bank first  as we need to get a valid Account #
				BankAccount bank = new BankAccount ( );
				//public static BankAccount CreateNewBankAccount ( BankAccount bank, string CustNo, Int16 accounttype, double amount, double interest )
				BankAccount . CreateNewBankAccount ( bank, accno, ( Int16 ) 1, ( double ) 237.18, ( double ) 3.72 );

				Customer Cust = new Customer ( );
				Cust = Customer . CreateNewCustomer ( accno, surname, fname, tel, mob, addr, strs [ random . Next ( 0, 24 ) ],
					towns [ random . Next ( 0, 24 ) ], Countys [ random . Next ( 0, 24 ) ], pcode, 1, bank . BankAccountNumber, DateTime . Now );
			}
			if ( CheckDeposit . Checked )
			{
				string accno = Customer . GetCustomerNumberSeed ( ) . ToString ( );
				int x = random . Next ( 23, 105 );
				string Tn = random . Next ( 120, 600 ) . ToString ( ) + " ThisTown";
				string addr = x . ToString ( ) + " AutoGen Road";
				string pcode = "AC" + random . Next ( 1, 99 ) . ToString ( ) + "ARC ";
				string tel = "0" + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + " "
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( )
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( );
				string mob = "0" + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + " "
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( )
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( );
				string surname = lname [ random . Next ( 0, 24 ) ];
				string fname = fnames [ random . Next ( 0, 24 ) ];
				double balance = bal [ random . Next ( 0, 24 ) ];
				double interest = intrst [ random . Next ( 0, 24 ) ];

				// MUST do Bank first  as we need to get a valid Account #
				BankAccount bank = new BankAccount ( );
				BankAccount . CreateNewBankAccount ( bank, accno, ( Int16 ) 2, balance, ( double ) interest );

				Customer Cust = new Customer ( );
				Cust = Customer . CreateNewCustomer ( accno, surname, fname, tel, mob, addr, strs [ random . Next ( 0, 24 ) ],
					towns [ random . Next ( 0, 24 ) ], Countys [ random . Next ( 0, 24 ) ], pcode, 2, bank . BankAccountNumber, DateTime . Now );

			}
			if ( CheckSavings . Checked )
			{
				int x = random . Next ( 23, 105 );
				string addr = x . ToString ( ) + " AutoGen Road";
				string Tn = random . Next ( 120, 600 ) . ToString ( ) + " ThisTown";
				string accno = Customer . GetCustomerNumberSeed ( ) . ToString ( );
				string pcode = "AC" + random . Next ( 1, 99 ) . ToString ( ) + "ARC ";
				string tel = "0" + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + " "
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( )
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( );
				string mob = "0" + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + " "
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( )
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( );
				string surname = lname [ random . Next ( 0, 24 ) ];
				string fname = fnames [ random . Next ( 0, 24 ) ];
				double balance = bal [ random . Next ( 0, 24 ) ];
				double interest = intrst [ random . Next ( 0, 24 ) ];

				// MUST do Bank first  as we need to get a valid Account #
				BankAccount bank = new BankAccount ( );
				BankAccount . CreateNewBankAccount ( bank, accno, ( Int16 ) 3, balance, ( double ) interest );

				Customer Cust = new Customer ( );
				Cust = Customer . CreateNewCustomer ( accno, surname, fname, tel, mob, addr, strs [ random . Next ( 0, 24 ) ],
					towns [ random . Next ( 0, 24 ) ], Countys [ random . Next ( 0, 24 ) ], pcode, 3, bank . BankAccountNumber, DateTime . Now );
			}
			if ( CheckBusiness . Checked )
			{
				int x = random . Next ( 23, 105 );
				string addr = x . ToString ( ) + " AutoGen Road";
				string Tn = random . Next ( 120, 600 ) . ToString ( ) + " ThisTown";
				string accno = Customer . GetCustomerNumberSeed ( ) . ToString ( );
				string pcode = "AC" + random . Next ( 1, 99 ) . ToString ( ) + "ARC ";
				string tel = "0" + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + " "
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( )
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( );
				string mob = "0" + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + " "
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( )
					+ random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( ) + random . Next ( 0, 9 ) . ToString ( );
				string surname = lname [ random . Next ( 0, 24 ) ];
				string fname = fnames [ random . Next ( 0, 24 ) ];
				double balance = bal [ random . Next ( 0, 24 ) ];
				double interest = intrst [ random . Next ( 0, 24 ) ];

				// MUST do Bank first  as we need to get a valid Account #
				BankAccount bank = new BankAccount ( );
				BankAccount . CreateNewBankAccount ( bank, accno, ( Int16 ) 4, balance, ( double ) interest );

				Customer Cust = new Customer ( );
				Cust = Customer . CreateNewCustomer ( accno, surname, fname, tel, mob, addr, strs [ random . Next ( 0, 24 ) ],
					towns [ random . Next ( 0, 24 ) ], Countys [ random . Next ( 0, 24 ) ], pcode, 4, bank . BankAccountNumber, DateTime . Now );
			}
			Output2 . AppendText ( "\r\nNew Account creation system has completed successfully\r\n" );
			Output2 . AppendText ( TerminatorText );
			//Output2 . AppendText ( "===========================================================================\r\n" );
			Output2 . ScrollToCaret ( );
			object sender = null;
			EventArgs e = null;
			//BankTxtOutputButton_Click ( sender, e );
		}

		//**************************************************************************************************************************//
		private void listbankaccounts_Click ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{
			string dir = BankAccount . ReadBankFilePath ( );
			string [ ] files = System . IO . Directory . GetFiles ( dir, "*.bnk" );
			int count = 0;
			Output2 . AppendText ( String . Format ( "*** Full Bank Accounts details obtained from the BankNo  Array:- ***\r\n", count ) );
			Output2 . AppendText ( "Bank #\tType\tCustomer#   Balance\tDate Opened\tInterest %\tFileName\r\n" );
			//			foreach ( BankAccount v in BankAccount . BankAccountsLinkedList )
			foreach ( BankAccount v in DataArray . BankNo )
			{
				if ( v == null ) continue;
				OutputBankDetails ( v );   // list them in the form window - Fn is right below here
			}
			Output2 . AppendText ( TerminatorText );
			//			Output2 . AppendText ( "===========================================================================\r\n" );
			Output2 . ScrollToCaret ( );
		}

		//**************************************************************************************************************************//
		public void OutputBankDetails ( BankAccount Item )
		//**************************************************************************************************************************//
		{
			string output = String . Format ( "{0:C2}", Item . Balance );
			if ( output . Length < 12 ) output += "  ";
			// Format the output for a bit better display
			string act = String . Format ( "  {0}", Item . AccountType );
			string perc = String . Format ( "{0:P2}", Item . InterestRate / 100 );
			Output2 . AppendText ( Item . BankAccountNumber + "\t" + act + "\t" + Item . CustAccountNumber + "\t  " + output + "\t " + Item . DateOpened . ToShortDateString ( ) + "\t  " + perc + "\t   " + Item . FileName + "\r\n" );

			Output2 . ScrollToCaret ( );
		}
		//**************************************************************************************************************************//
		private void RunBank_Click ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{
			WinInfo . Text = "";
			Car car = new Car ( );    // will get default data  results
									  // create a list collection to store all the car data in itas we build the data up
			List<string> list = new List<string> ( );
			string data = car . GetMaker ( ); // returns Maker type only
			list . Add ( data );
			Output2 . AppendText ( "\r\n" + data );
			data = car . GetDetails ( ); // Returns data from the default values in the constructor
			list . Add ( data );
			Output2 . AppendText ( "\r\n" + data );
			// get a new instance
			Car car2 = new Car ( 85, 125, "Orange", "Honda", "Jazz" );
			data = car . GetDetails ( ); // Returns data from the default values in the constructor above
			list . Add ( data );
			Output2 . AppendText ( "\r\n" + data );
			//            data = car.Maker;
			// list data in mt Collection List<string>
			Output2 . AppendText ( "\r\nData stored in my collection List<string>" );
			foreach ( string s in list ) { Output2 . AppendText ( "\r\n" + s ); }
			// create an <car3> Car object directly
			// cannot be used until we initilize it - by Copying <car3 = car> works well.
			// then we can access it exactly same as <car>, change data directly etc
			//
			// To protect the Class data, we could just mark then INTERNAL.
			// all the other access remains OK.
			Car car3;
			car3 = car;
			car3 . HorsePower = 234;
			data = car3 . GetDetails ( );
			data += car3 . MaxSpeed . ToString ( );
			list . Add ( data );
			Output2 . AppendText ( "\r\nData from <car3>" );
			Output2 . AppendText ( "\r\n" + data );
			car . Maker = "Jowett";
			data = car . GetDetails ( );
			list . Add ( data );
			Output2 . AppendText ( "\r\nData from <car>" );
			Output2 . AppendText ( "\r\n" + data );
			data += car3 . MaxSpeed . ToString ( );
			list . Add ( data );
			Output2 . AppendText ( "\r\n" + data );
			Output2 . AppendText ( "\r\n" + car . ToString ( ) );
			Output2 . ScrollToCaret ( );
		}
		//**************************************************************************************************************************//
		private void AddSecondaryBank_Click_1 ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{
			WinInfo . Text = "";
			// find the a/c we want
			// Open customer data window
			SecondaryBnkAcct B = new SecondaryBnkAcct ( );
			B . Show ( );// create a data input window for customer details.
			WinInfo . Text = "New Bank Account completed successfully...";

		}

		//**************************************************************************************************************************//
		private void BAEdit_Click ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{   // edit a bank accounts detials
			BankAccountEdit B = new BankAccountEdit ( );
			B . Show ( );

		}

		//**************************************************************************************************************************//
		private void bldCustList_Click_1 ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{
			BankAccount . RebuildBankDataFromTextFiles ( );
			// no longer used s it was a duplicate of RebuildBankLL_Click below
			////			Output2 . AppendText ( "The Customer Accounts LinkedList and Array have been rebuilt from Disk Objects successfully...\r\n" );
			//			Output2 . AppendText ( "There are now " + x + "  Customer Accounts in our LinkedList ...\r\n" );
			//			Output2 . ScrollToCaret ( );
		}
		//**************************************************************************************************************************//
		private void RebuildBankLL_Click ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{// rebuild Bank Linkedlist & SoirtedArray from object files on disk
			int x = BankAccount . RebuildBankLinkedListFromObjects ( );
			Output2 . AppendText ( "The Bank Accounts LinkedList & array have been rebuilt from disk objects successfully...\r\n" );
			Output2 . AppendText ( "There are now " + x + "  Bank Accounts verified in the system...\r\n" );
			Output2 . ScrollToCaret ( );
		}

		private void RebuildCustLL_Click ( object sender, EventArgs e )
		{   // rebuild customer LinkedList and Array from Dsik objects
			int x = Customer . RebuildCustLinkedListFromDisk ( );
			Output2 . AppendText ( "The Customer LinkedList & SortedArray has been rebuilt from the backup Text file successfully...\r\n" );
			Output2 . AppendText ( "There are now " + x + "  Customer Accounts verified in the system...\r\n" );
			Output2 . ScrollToCaret ( );
		}

		private void RebuildBankFromText_Click_1 ( object sender, EventArgs e )
		{// rebuild Bank Linked list ansd sorted array from TextFiles
			Lists . RebuildBankListsFromText ( );
		}

		private void button3_Click ( object sender, EventArgs e )
		{   // Bank ArrayList  reubuilt from Bank LinkedList
			int count = 0;
			count = DataArray . RebuildBankArrayFromLinkedList ( );
			Output2 . AppendText ( "The Bank ArrayList has been rebuilt with " + count . ToString ( ) + " from the Bank LinkedList. \r\n" );
			foreach ( BankAccount b in DataArray . BankNo )
				OutputBankDetails ( b );
		}

		//**************************************************************************************************************************//
		private void CustplusBank_Click ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{   // generate and list all customer with details of EACH Bank account they have.
			// iterate thru linked list
			Output2 . AppendText ( "*** List of all Customers including their Bank Account(s) from Datarray.CustNo ***\r\n" );
			//			foreach ( var C in Customer . CustomersLinkedList )
			// new method using sorted array in memory
			foreach ( Customer C in DataArray . CustNo )
			{
				if ( C == null )
					continue;
				string actype = "";
				string padding25 = "                        ";
				string fname = "";
				string town = "";
				fname = C . FirstName + padding25 . Substring ( 25 - C . FirstName . Length );
				string lname = C . LastName + padding25 . Substring ( 25 - C . LastName . Length );
				town = C . Town + padding25 . Substring ( 25 - C . Town . Length );

				Output2 . AppendText ( "Account\tLastName\tFirstName\t Town\t\tCounty\r\n" );
				Output2 . AppendText ( C . CustomerNumber . ToString ( ) + "\t" + lname + "       " + fname + "\t" + town + "\t" + C . County + "\r\n" );
				Output2 . AppendText ( "A/C Type\tBank A/C #\tBalance\t       Open Date\tFile Name\r\n" );
				for ( int x = 0 ; x < 4 ; x++ )
				{
					if ( C . accountnums [ x ] > 0 )
					{
						//						filename = "C:\\Users\\ianch\\source\\C#SavedData\\BankAccounts\\BankObject" + C.accountnums[x] + ".bnk";
						BankAccount B = Search . FindBankObjectfromBankNo ( C . accountnums [ x ] . ToString ( ) );
						if ( B == null )
							break;
						if ( B . AccountType == 1 )
							actype = "1-Normal     ";
						else if ( B . AccountType == 2 )
							actype = "2-Savings    ";
						else if ( B . AccountType == 3 )
							actype = "3-Deposit    ";
						else if ( B . AccountType == 4 )
							actype = "4-Business   ";
						string bal = Utils . GetCurrencyString ( B . Balance . ToString ( ) );
						string bal2 = bal + padding25 . Substring ( 15 - bal . Length );
						string dataline = actype + "   " + B . BankAccountNumber + "\t\t" + bal + "\t" + B . DateOpened . ToShortDateString ( ) + "\t" + B . FileName + "\r\n";
						Output2 . AppendText ( dataline );
						Output2 . ScrollToCaret ( );
						B . Dispose ( );
					}
				}
				Output2 . AppendText ( TerminatorText );
				//				Output2 . AppendText ( "----------------------------------------------------------------------------------------------\r\n" );
				Output2 . ScrollToCaret ( );
			}
		}

		//**************************************************************************************************************************//
		private void ListSortedCustomers_Click ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{   // list all customer account info in sorted order from our sorted Array DataArray.CustNo
			int count = 0;
			string Padding = "                    ", fname = "", lname = "";
			string bankno = "";
			Output2 . AppendText ( "*** Sorted List of Customers from DataArray.CustNo Array ***\r\n" );
			Output2 . AppendText ( "Type\tA/C #\tBank A/C #\tSurname\t\t   Forename\t\tDOBr\r\n" );
			// new method, using sorted array in memory 
			foreach ( Customer v in DataArray . CustNo )
			{
				if ( v == null )
					continue;
				fname = v . FirstName + Padding . Substring ( 0, 20 - v . FirstName . Length );
				lname = v . LastName + Padding . Substring ( 0, 20 - v . LastName . Length );
				bankno = v . accountnums [ 0 ] . ToString ( ) . TrimEnd ( );
				Output2 . AppendText ( v . accounttypes [ 0 ] . ToString ( ) + "\t" + v . CustomerNumber . ToString ( ) + "\t " + bankno + "\t"
														+ lname + fname + v . DOB . ToShortDateString ( ) + "\r\n" );
				if ( v . accountnums [ 1 ] > 0 )
				{
					bankno = v . accountnums [ 1 ] . ToString ( ) . TrimEnd ( );
					Output2 . AppendText ( v . accounttypes [ 1 ] . ToString ( ) + "\t" + v . CustomerNumber . ToString ( ) + "\t " + bankno + "\t" + "<<<--- Secondary Bank Account\r\n" );
				}
				if ( v . accountnums [ 2 ] > 0 )
				{
					bankno = v . accountnums [ 2 ] . ToString ( ) . TrimEnd ( );
					Output2 . AppendText ( v . accounttypes [ 2 ] . ToString ( ) + "\t" + v . CustomerNumber . ToString ( ) + "\t" + bankno + "\t" + "<<<--- Secondary Bank Account\r\n" );
					Output2 . ScrollToCaret ( );
				}
				if ( v . accountnums [ 3 ] > 0 )
				{
					bankno = v . accountnums [ 3 ] . ToString ( ) . TrimEnd ( );
					Output2 . AppendText ( v . accounttypes [ 3 ] . ToString ( ) + "\t" + v . CustomerNumber . ToString ( ) + "\t" + bankno + "\t" + "<<<--- Secondary Bank Account\r\n" );
					Output2 . ScrollToCaret ( );
				}
			}
			Output2 . AppendText ( TerminatorText );
			//			Output2 . AppendText ( "---------------------------------------------------------------------------------------\r\n" );
			Output2 . ScrollToCaret ( );

		}

		//**************************************************************************************************************************//
		private void Form1_Load ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{

		}

		//**************************************************************************************************************************//
		private void CustEdit_Click ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{   // fully edit a customer account
			CustomerEdit CE = new CustomerEdit ( );
			CE . Show ( );
		}

		//**************************************************************************************************************************//
		public static Customer ListCustomerlist ( )
		//**************************************************************************************************************************//
		{
			Customer C;

			LinkedList<Customer> . Enumerator LListEnum = new LinkedList<Customer> . Enumerator ( );

			while ( LListEnum . MoveNext ( ) )
			{
				C = LListEnum . Current;
				return C;
			}
			return null;
		}
		//**************************************************************************************************************************//
		private void DisplayCustsFromArray ( )
		//**************************************************************************************************************************//
		{
			Output2 . AppendText ( "*** All Customers from DataArray,CustNo Array. ***\r\n" );
			Output2 . AppendText ( "Cust #\t   Bank #    type\t\tA/C details\r\n" );
			foreach ( Customer C in DataArray . CustNo )
			{   // here we go, using our Sorted array
				// this is the default Bank account  type
				Int32 actype = C . accountnums [ 0 ];
				DisplayDataScreen ( C );
			}
		}
		private void DisplayCustsFromLinkedList ( )
		//**************************************************************************************************************************//
		{
			Output2 . AppendText ( "*** All Customers from Linked List. ***\r\n" );
			Output2 . AppendText ( "Cust #\t   Bank #    type\t\tA/C details\r\n" );
			foreach ( Customer C in Customer . CustomersLinkedList )
			{   // here we go, using our Sorted array
				// this is the default Bank account  type
				Int32 actype = C . accountnums [ 0 ];
				DisplayDataScreen ( C );
			}
		}
		// Generic output for Customer data from wherever it is sourced
		private void DisplayDataScreen ( Customer C )
		{
			//see if the Customer owns more than one bank account ?
			// Make  this output a seperate function
			if ( C != null )
			{
				Output2 . AppendText ( C . CustomerNumber . ToString ( ) + ",  " + C . accountnums [ 0 ] . ToString ( ) + ",  " + GetAccountTypeText ( C . accounttypes [ 0 ] ) + ",  " + C . LastName + ",  " 
					+ C . FirstName + ",  "+ C . DOB . ToShortDateString ( ) + ",  " + C . Address1 + "\r\n " + C . Address2 + ",  " + C . Town + ",  " + C . County + "\r\n" );
				if ( C . accounttypes [ 1 ] > 0 )
				{
					Output2 . AppendText ( "Secondary Bank Account(s) ---vvv\r\n" );
					Output2 . AppendText ( C . CustomerNumber . ToString ( ) + ",  *** " + C . accountnums [ 1 ] . ToString ( ) + " ***,  " + GetAccountTypeText ( C . accounttypes [ 1 ] ) + "\t<<<---  Secondary Bank Account\r\n" );
				}
				if ( C . accounttypes [ 2 ] > 0 )
				{
					Output2 . AppendText ( C . CustomerNumber . ToString ( ) + ",  *** " + C . accountnums [ 2 ] . ToString ( ) + " ***,  " + GetAccountTypeText ( C . accounttypes [ 2 ] ) + "\t<<<---  Secondary Bank Account\r\n" );
				}
				if ( C . accounttypes [ 3 ] > 0 )
				{
					Output2 . AppendText ( C . CustomerNumber . ToString ( ) + ",  *** " + C . accountnums [ 3 ] . ToString ( ) + ",***  " + GetAccountTypeText ( C . accounttypes [ 3 ] ) + "\t<<<---  Secondary Bank Account\r\n" );
				}
				Output2 . AppendText ( "......\r\n" );
				C . Dispose ( );
			}
			Output2 . AppendText ( TerminatorText );
			//			Output2 . AppendText ( "-------------------------------------------------------------------------------------\r\n" );
			Output2 . ScrollToCaret ( );
		}
		public static string GetAccountTypeText ( Int16 act )
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
		// Top button on screen
		private void BanklistFromLinkedList_Click ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{   // list all bank accounts thru the LinkedList
			Output2 . AppendText ( "*** Bank A/C's listed through Linked List ***\r\n" );
			Output2 . AppendText ( "Type\tCust#\tBank #\tBalance\t\tOpen Date\tInterest\tStatus\r\n" );
			foreach ( BankAccount B in BankAccount . BankAccountsLinkedList )
			{
				Output2 . AppendText ( B . AccountType . ToString ( ) + "\t" + B . BankAccountNumber . ToString ( ) + "\t" + B . CustAccountNumber . ToString ( ) + "\t   " + String . Format ( "{0:C2}", B . Balance )
													+ "\t" + B . DateOpened . ToShortDateString ( ) + "\t" + B . InterestRate . ToString ( ) + "\t\t" + B . Status . ToString ( ) + "\r\n" );
			}
			Output2 . AppendText ( TerminatorText );
			//			Output2 . AppendText ( "===========================================================================\r\n" );
		}

		//**************************************************************************************************************************//
		private void ListLink_Click ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{ DisplayCustsFromArray ( ); }

		//**************************************************************************************************************************//
		private void DoCustomers_CheckedChanged ( object sender, EventArgs e )
		//**************************************************************************************************************************//
		{ }
		private void ListAllBankAccounts ( )
		{
			// list all bank accounts using iterator thru the LinkedList
			LinkedList<BankAccount> . Enumerator LListEnum = BankAccount . BankAccountsLinkedList . GetEnumerator ( );
			Output2 . AppendText ( "All Bank Account information from DataArray.BankNo  Array\r\n" );
			//use the Enumeration version as shown below
			string padding = "                    ";
			//			while ( LListEnum . MoveNext ( ) )
			foreach ( BankAccount B in DataArray . BankNo )
			{
				if ( B == null ) continue;
				string cstr = Utils . GetCurrencyString ( B . Balance . ToString ( ) );
				string currencystr = cstr;// + padding . Substring ( padding.Length - (cstr . Length + 4) );

				string Intrst = Utils . GetFieldCurrencyString ( B . InterestRate . ToString ( ) );
				Output2 . AppendText ( B . BankAccountNumber . ToString ( ) + "\t" + B . AccountType . ToString ( ) + "  "
									+ B . CustAccountNumber . ToString ( ) + "\t" + currencystr + "\t" + Intrst + "%" + "\t" + B . FileName + "\r\n" );
			}
			//foreach ( BankAccount B in DataArray . BankNo )
			//{
			//	string cstr = Utils . GetCurrencyString ( LListEnum . Current . Balance . ToString ( ) );
			//	string currencystr = cstr + padding . Substring ( cstr . Length );

			//	string Intrst = Utils . GetFieldCurrencyString ( LListEnum . Current . InterestRate . ToString ( ) );
			//	Output2 . AppendText ( LListEnum . Current . BankAccountNumber . ToString ( ) + "\t" + LListEnum . Current . AccountType . ToString ( ) + "\t"
			//						+ LListEnum . Current . CustAccountNumber . ToString ( ) + "\t" + currencystr + "\t" + Intrst + "%" + "\t" + LListEnum . Current . FileName + "\r\n" );
			//}
			Output2 . AppendText ( Text );
			Output2 . ScrollToCaret ( );
		}

		private void BankTxtOutputButton_Click_1 ( object sender, EventArgs e )
		{
			ReadBankTextFile RBT = new ReadBankTextFile ( );
			RBT . Show ( );

		}

		private void CreatenewBankAccount_Click ( object sender, EventArgs e )
		{
			Form CreateBankAccount = new CreateBankAccount ( );
			CreateBankAccount . Show ( );
		}
		private void ArraySort_Click ( object sender, EventArgs e )
		{

		}     // End CLASS 
	}   // END Namespace
}
