using System;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . IO;
using System . Windows . Forms;
using System . Threading . Tasks;

namespace ClassAccessTest
{
	  public partial class SqlConnector : Form
	  {
		    public static SqlCommand command;
		    public static SqlDataReader reader;

		    //************************************************************************//
		    //THIS STRING ACTUALLY FUCKING WELL WORKS !!!!!!
		    //************************************************************************//
		    public string ConnectionString =
					@"Data Source = DINO-PC\SQLEXPRESS; Initial Catalog = ian1; Integrated Security = True";

		    private static bool firsttime = true;
		    private static bool mathfirsttime = true;
		    public static string threadArg1 = "";
		    public static string threadArg2 = "";
		    public static string[] sqlCommands;
		    public static string[] sqlValues;
		    public int listindex = 0;

		    public static SqlConnector sqloutputform;
		    //		    public static SqlConnection cnn;

		    public  TextBox sqlLine;

		    public static List<string> SQLdataOutput;
		    // Lists for fields names, and the int is for it's index in the db...
		    public List<string> FieldNames = new List<string>();

		    public List<int> FieldTypes = new List<int>();


		    public SqlConnector ( )
		    //=========================================================================================
		    {
				InitializeComponent ( );
				// display conection string on our window
				if (!SQLAccess . SQLconnection)
				{
					  this . connstring . Text = this . ConnectionString;
					  // connect to DB
					  if (SQLAccess . SQLconnection)
						    this . info . Text = "Connected to SQL server successfully...";
					  else
						    this . info . Text = "NOT yet connected to SQL server...";
				}

				this . FieldNames . Clear ( );
				this . FieldTypes . Clear ( );
				// load our sql commands list windows
				sqlCommands = stringhandler . LoadSQLFields ( );
				sqlValues = stringhandler . LoadSQLValues ( );
				sqloutputform = this;
				SQLdataOutput = new List<string> ( );
		    }
		    //========================================================
		    // This is a delegate	declared in Bank.CS

		    public void SqlConnector_SQLDataReceived ( string sender , string e )
		    //========================================================
		    {
				//string datain = (List<string>) sender;
				DisplayDatafromSQL ( sender );
				SqlConnector . sqloutputform . Data . Text += sender;
				;
		    }

		    // Called by our eventhandler to list our SQL data in Data TextBox
		    public void DisplayDatafromSQL ( string datain )
		    {
				//runit( datain );
				//				SqlDataView sdv = new SqlDataView ();
				//				sdv . Show ( );

				Data . Text += datain;
				//			CustGridView . DataSource = customerBindingSource;

				// TODO: This line of code loads data into the 'ian1DataSet.Customer' table. You can move, or remove it, as needed.
				//			customerTableAdapter . Fill ( ian1DataSet . Customer );

				//			int x = 0;
				//			for (int i = 0; i < datain.Count - 1; i++)
		    }

		    public void sqlConnect_Click ( object sender , EventArgs e )
		    //=========================================================================================
		    {
				if (!SQLAccess . SQLconnection)
				{
					  SqlConnection cnn;
					  this . connstring . Text = this . ConnectionString;
					  cnn = new SqlConnection ( this . ConnectionString );
					  cnn . Open ( );
					  Bank . form1 . Output2 . AppendText ( "SQL Connection opened successfully.." );
					  this . info . Text = "SQL Connection opened successfully";
				}
		    }

		    //=========================================================================================
		    // this is where we add user SQL statement selections into a listbox 
		    private void sqlcommandslist_MouseDoubleClick_1 ( object sender , MouseEventArgs e )
		    //=========================================================================================
		    { // select items from a listbox and add them 1 at a time to a lower listbox that "scores" each one
			// to let me control the assembly of the eventual SQL command string correctly
			// and finally add it to detailed SQL command window
				int index = 0;
				// current selected item (index)
				index = this . sqlcommandlist . SelectedIndex;
				string cmd = "";
				// This is the <string> that has been selected
				cmd = this . sqlcommandlist . Text;
				// Add TEXT data to our lower <string> list
				this . MathCommands . Items . Add ( cmd );
				// add it to our List<string>
				this . FieldNames . Add ( cmd );
				// now sort out the vlaues data for our "Collections"
				// ensure we are reading the correct value for our command
				this . sqlcommandvalues . SelectedIndex = index;
				// should let us access the correct fields selected later  on?
				int x = Convert.ToInt16( this.sqlcommandvalues.Text );
				this . FieldTypes . Add ( x );
				RefreshSQLCommands ( cmd , x );
				// set the topindex ot the last index to the newly added item so the ListBox  scrolls up 
				this . MathCommands . TopIndex = this . MathCommands . Items . Count - 1;
				this . MathCommands . Refresh ( );

				// set focus back to selection listbox
				this . sqlcommandlist . Focus ( );
		    }


		    private string StripCommas ( string input )
		    {
				string revstr = "";
				string output = "";
				revstr = Utils . ReverseString ( input );
				int cnt = 0;
				while (revstr [ cnt ] == ',' || revstr [ cnt ] == ' ') { cnt++; }

				if (cnt > 0)
				{
					  output = Utils . ReverseString ( revstr );
					  output = output . Substring ( 0 , output . Length - (cnt) );
					  output += "  ";
				}

				return output;
		    }

		    //************************************************************************//
		    private void ReadBankDB_Click_1 ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				this . info . Text = "Loading Bank Accounts SQL Database - Please wait ...";
				Cursor = Cursors . WaitCursor;
				BankDBView dbv = new BankDBView();
				dbv . Show ( );
				Cursor = Cursors . Default;
		    }

		    //************************************************************************//
		    private void ReadCustDB_Click ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				this . info . Text = "Loading Customer Accounts SQL Database - Please wait ...";
				Cursor = Cursors . WaitCursor;
				CustDataView dbv = new CustDataView();
				Cursor = Cursors . Default;
				dbv . Show ( );
		    }

		    private void ReadStdCustomerSqlData ( object sender , EventArgs e )
		    {
				this . Data . Text = "Requesting limited field's Bankaccount data from SQL Server.....\r\n";
				string query =
						"Select  BankACNumber, CustACNumber, Balance , InterestRate, OpenDate, Status from BankAccount ";

				this . Cursor = Cursors . WaitCursor;
				int count = 0;
				//			public static string ReadSQLdata (string enquiry, List<string> fldnames, List<int> fldtypes, string requiredDb, out int count)
				ReadSQLdata ( query , null , null , "CUSTOMER" );
				/*				if (input . Length > 0)
									  this . Data . AppendText ( input );
								else
									  this . Data . AppendText ( "No data was returned by that SQL enquiry.\r\n" );
								this . RecordCount . Text = count . ToString ( );
				*/
				this . Cursor = Cursors . Default;
		    }

		    //************************************************************************//
		    private void ReadCustDB_Click_1 ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				this . Data . Text += "Requesting limited fields Customer data from SQL Server.....\r\n";
				string query =
						"Select  CustomerNumber, FirstName, LastName, Town, County, DOB, SecAccounts from Customer";

				this . Cursor = Cursors . WaitCursor;
				int count = 0;
				//			public static string ReadSQLdata (string enquiry, List<string> fldnames, List<int> fldtypes, string requiredDb, out int count)
				ReadSQLdata ( query , null , null , "CUSTOMER" );
				/*				if (input . Length > 0)
									  this . Data . AppendText ( input );
								else
									  this . Data . AppendText ( "No data was returned by that SQL enquiry.\r\n" );
								this . RecordCount . Text = count . ToString ( );
				*/
				this . Cursor = Cursors . Default;
		    }

		    private void ReadCustomerSqlData ( object sender , EventArgs e )
		    {
				this . Data . Text += "\r\nRequesting all fields from Customer Db data from SQL Server.....\r\n";
				Cursor = Cursors . WaitCursor;
				string query = "Select * from Customer ";
				int count = 0;
				// thiis Fn loops getting lines of data
				//			public static string ReadSQLdata (string enquiry, List<string> fldnames, List<int> fldtypes, string requiredDb, out int count)
				ReadSQLdata ( query , null , null , "CUSTOMER" );
				/*				if (input . Length > 0)
									  this . Data . AppendText ( input );
								else
									  this . Data . AppendText ( "No data was returned by that SQL enquiry.\r\n" );
								this . RecordCount . Text = count . ToString ( );
				*/
				this . Cursor = Cursors . Default;
		    }

		    //************************************************************************//
		    //		private void WriteCSVtoBank_Click (object sender, EventArgs e) { }
		    private void WriteCSVtoBank_Click_1 ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				// write data to DB
				string cmdroot = "Insert into BankAccount";
				cmdroot +=
							"(BankACNumber, CustACnumber, AccountType, Balance, OpenDate, CloseDate, InterestRate, Status)  Values (";
				string file = "C:\\Users\\ianch\\source\\C#SavedData\\BulkData\\DelimitedBankData(comma).txt";
				if (!SQLAccess . SQLconnection)
				{
					  sqlConnect_Click ( sender , e );
				} // ensure we are connected

				if (File . Exists ( file ))
				{
					  this . Cursor = Cursors . WaitCursor;
					  Int32 bankno = 1050000;
					  ;
					  Int32 custno = 1234500;
					  string[] inputdata = File.ReadAllLines( file );
					  string datain = "";
					  foreach (string s in inputdata)
					  { // eg: 1230003, 1234503, 3, 2345.17, 2020 - 09 - 01, 2070 - 01 - 01, 3.45, 1 + ")";
					    // s contains AccountType -> Status
						    string bulkstr = ParseInputString( 1, s );
						    //					string filename = "BankObject" + bankno.ToString ( ) + ".cust";
						    //					string fullpath = custfolder + "BankObject" + bankno.ToString ( ) + ".cust,";
						    datain = "'" + bankno . ToString ( ) + "','" + custno . ToString ( ) + "'," + bulkstr;
						    bankno++;
						    custno++;
						    string cmddata = cmdroot + datain + ")";
						    SQLHelper . WriteSQLdata ( cmddata );
					  }

					  this . Cursor = Cursors . Default;
				}
		    }

		    private void WriteTestdatatoBank_Click ( object sender , EventArgs e )
		    {
				//Used  mostly for Update/Insert  operations on BankAccount Db.
				// sort out command line from TEXT entered and finally give it to SQL
				// to read/write data to DB
				int SqlTypeException = 0;
				string bulkstr = "";
				string Command, temp1 = "", temp2 = "", output = "";
				Command = this . SQLcommand . Text;
				string[] tmp = {"", "", "", ""};
				char[] brace = {'('};
				string[] str = {
								   "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
								   "", "", "", "", "",
								   "", "", "", "",
								   "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
								   "", "", "", "", "",
								   "", "",
					   };
				char[] ch = {','};
				if (!SQLAccess . SQLconnection)
				{
					  sqlConnect_Click ( sender , e );
				} // ensure we are connected

				tmp = Command . Split ( brace );
				if (tmp . Length > 1)
				{
					  if (tmp [ 0 ] . ToUpper ( ) . Contains ( "SELECT" ) || tmp [ 0 ] . ToUpper ( ) . Contains ( "INSERT" ) ||
						tmp [ 0 ] . ToUpper ( ) . Contains ( "UPDATE" ))
					  {
						    if (tmp [ 0 ] . ToUpper ( ) . Contains ( "SELECT" )) SqlTypeException = 0;
						    if (tmp [ 0 ] . ToUpper ( ) . Contains ( "INSERT" )) SqlTypeException = 1;
						    if (tmp [ 0 ] . ToUpper ( ) . Contains ( "UPDATE" )) SqlTypeException = 2;
						    output = tmp [ 0 ];
					  }

					  //			else
					  //			{
					  str = tmp [ 1 ] . Split ( ch );
					  foreach (string s in str)
					  {
						    if (s . Length == 0) continue;
						    {
								if (s . Contains ( "()" ))
									  output += ", " + ParseFunction ( s );
								else
								{
									  if (s . Contains ( "from " ))
									  {
										    string temp = s.Substring( 0, s.Length - 1 ); // remove traing comma
										    output += temp;
									  }
								}
						    }
					  }
				}
				else
				{
					  if (SqlTypeException == 0
						&& !tmp [ 0 ] . ToUpper ( ) . Contains ( "FROM" ))
					  { // a SELECT enquiry with no FROM clause{
						    var result =
								MessageBox.Show(
											"[" + output +
											$"]\r\n\r\nYour enquiry does not have a \"From\" Clause that tells the SQL server\r\n which Database you want to obtain the data from." +
											$"\r\nPlease edit your SQL enquiry with a from clause and try it again !",
											$"SQL command Creation system",
											MessageBoxButtons.OK, MessageBoxIcon.Error,
											MessageBoxDefaultButton.Button1 );
						    return;
					  }
				}

				this . Cursor = Cursors . WaitCursor;
				int count = 0;
				string dbname = "";
				if (SqlTypeException == 0)
				{ // SELECT REQUEST - Just Read data - shown in our output window
				  //			public static string ReadSQLdata (string enquiry, List<string> fldnames, List<int> fldtypes, string requiredDb, out int count)
					  if (output . ToUpper ( ) . Contains ( "CUSTOMER" ))
						    dbname = "CUSTOMER";
					  else if (output . ToUpper ( ) . Contains ( "BANKACCOUNT" ))
						    dbname = "CUSTOMER";
					  else
						    dbname = "SECONDARYCUSTACCOUNTS";

					  ReadSQLdata ( output , null , null , dbname );
				}
				else if (SqlTypeException == 1 || SqlTypeException == 2)
				{ // Update / Insert / Alter Db
					  SQLHelper . WriteSQLdata ( output );
				}

				Cursor = Cursors . Default;
		    }

		    //************************************************************************//
		    private void WriteTestdatatoCust_Click ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				//Used  mostly for Update/Insert  operations on Customer Db.
				if (!SQLAccess . SQLconnection)
				{
					  sqlConnect_Click ( sender , e );
				} // ensure we are connected

				this . Cursor = Cursors . WaitCursor;
				SQLHelper . WriteSQLdata ( this . SQLcommand . Text );
				//		TEST DATA OPTIONS
				//			string cmdroot = "Insert into Customer (Id, CustomerNo, LastName, FirstName, PhoneNumber, MobileNumber, Address1, Address2, Town, County, Postcode, FileName, FullFileName, SecAccounts) " +
				//			"	 values (1,1234500, 'Turner', 'Ian', '01253 737014', '0757 90622440', 'Flat 38', 'Liggard Court', 'Lytham St Annes', 'Lancashire', 'FY8  4SG', 'CustObject1234500.cust', 'C:\\Users\\ianch\\source\\C#SavedData\\Customers\\custobject1234500.cust' , 1230000)";
				//			cmdroot = "Insert into Customer (Id, CustomerNo, LastName, FirstName, PhoneNumber, MobileNumber, Address1, Address2, Town, County, Postcode, FileName, FullFileName, SecAccounts) " +
				//			"	 values (1,1234501, 'Turner', 'Ian', '01253 737014', '0757 90622440', 'Flat 38', 'Liggard Court', 'Lytham St Annes', 'Lancashire', 'FY8  4SG', 'CustObject1234501.cust', 'C:\\Users\\ianch\\source\\C#SavedData\\Customers\\custobject1234501.cust' , 1230001)";
				//			SQLHelper.WriteSQLdata (cmdroot);
				this . Cursor = Cursors . Default;
		    }

		    //************************************************************************//
		    private void listBox1_MouseDoubleClick ( object sender , MouseEventArgs e )
		    //************************************************************************//
		    { // paste selected item from listbox into inline SQL command editor window
				string cmd = this.listBox1.SelectedItem.ToString();
				Clipboard . Clear ( );
				if (this . SQLcommand . Text . Contains ( "Type your SQL enquiry here." ))
				{
					  if (!cmd . Contains ( "Select" ))
						    Clipboard . SetText ( "Select  " );
					  else if (!cmd . Contains ( "Update" ))
						    Clipboard . SetText ( "Update " );
					  else if (!cmd . Contains ( "Insert" ))
						    Clipboard . SetText ( "Insert " );
					  else
						    Clipboard . SetText ( "UNKNOWN SQL entry ???? " );
				}
				else
				{
					  Clipboard . SetText ( cmd );
				}

				this . SQLcommand . Paste ( );
				this . listBox1 . Focus ( );
		    }



		    //************************************************************************//
		    private void clear_Click ( object sender , EventArgs e )
		    //************************************************************************//
		    {
		    }

		    //************************************************************************//
		    private void button1_Click ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				SQLHelper . SQLDisConnect ( );
		    }

		    //************************************************************************//
		    private void close_Click_1 ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				Close ( );
		    }

		    //************************************************************************//
		    public static string ParseFunction ( string input )
		    //************************************************************************//
		    {
				string[] functions = {
									   "GetCustNumber()",
									   "GetBankNumber()",
									   "GetCustFileName()",
									   "GetBankFileName()",
									   "GetCustFullFileName()",
									   "GetBankFullFileName()",
									   "GetRandomSQLdate()"
						   };
				string output = "";
				string cmd = "", tmp = "";
				int indx = 0;
				foreach (string item in functions)
				{
					  if (item . ToUpper ( ) . Contains ( input . ToUpper ( ) ))
					  {
						    switch (indx)
						    {
								case 0:
									  tmp = GetCustNumber ( );
									  break;
								case 1:
									  tmp = GetBankNumber ( );
									  break;
								case 2:
									  tmp = GetCustFileName ( );
									  break;
								case 3:
									  tmp = GetBankFileName ( );
									  break;
								case 4:
									  tmp = GetCustFullFileName ( );
									  break;
								case 5:
									  tmp = GetBankFullFileName ( );
									  break;
								case 6:
									  tmp = GetRandomSQLdate ( );
									  break;
						    }

						    output += "'" + tmp + "', ";
						    break;
					  }

					  indx++;
				}

				return output;
		    }

		    public static string ParseInputString ( int type , string input )
		    //************************************************************************//
		    {
				// type = 0 or 1 (Customer or BankAccount
				// string = one input line from CSV file

				// Takes a line in from the bulk data csv file 
				// and creates an output string formatted  for SQL 
				// so comma delimited values with each field being single quoted when a string

				// Formats suported CUSTOMER 
				// These are ALL strings
				// Formats suported BANKACCOUNT
				// Only the dates are string, the rest are numerics
				string typestr;
				if (type == 0) typestr = "CUST";
				else typestr = "BANK";
				string output = "";
				string datestr = "";
				char[] ch = {','};
				int itemcount = 0;
				string[] fieldstr = input.Split( ch );
				foreach (string s in fieldstr)
				{
					  if (typestr == "CUST")
					  {
						    if (input . Contains ( "DOB" ))
						    {
								//	 Need to do this when I add DOB field in
								int day = 0, month = 0, year = 0;
								DateTime dt = Convert.ToDateTime( fieldstr[2] );
								day = dt . Day;
								month = dt . Month;
								year = dt . Year;
								// convert date to YYYY/MM/DD format for SQL
								datestr = year . ToString ( ) + "/" + month . ToString ( ) + "/" + day . ToString ( );
						    }

						    output += "'" + s + "' , ";
					  }
					  else
					  {
						    if (itemcount == 0 || itemcount == 1 || itemcount == 3 || itemcount == 4)
						    {
								if (itemcount == 4)
									  output += "'" + fieldstr [ itemcount ] +
											"'"; // do NOT want end of line comma....
								else
									  output += "'" + fieldstr [ itemcount ] + "', ";
						    }
						    else if (itemcount == 2)
						    {
								// strip time off input date and we have to rEVERSE it for SQL
								char[] chr = {' '};
								string[] dates = s.Split( chr );
								int day = 0, month = 0, year = 0;
								DateTime dt = Convert.ToDateTime( fieldstr[2] );
								day = dt . Day;
								month = dt . Month;
								year = dt . Year;
								// convert date to YYYY/MM/DD format for SQL
								dates [ 0 ] = year . ToString ( ) + "/" + month . ToString ( ) + "/" + day . ToString ( );
								output += "' " + dates [ 0 ] + "', '2070/01/01', "; // dummy closed date
						    }
						    //					else if ( itemcount == 3 )
						    //						output += "'01/01/2070', " + fieldstr[itemcount + 1] + ", " + fieldstr[itemcount + 2 + ","];
						    else
								output += fieldstr [ itemcount ];

						    itemcount++;
					  }
				}

				return output;
		    }

		    public static string GetRandomSQLdate ( )
		    //************************************************************************//
		    {
				Random rnd = new Random();
				DateTime dtin = DateTime.Now;
				DateTime dtout = DateTime.Now;
				string SQLdateout = "";
				string dy = "", mnth = "", yr = "";
				int year = rnd.Next( 1930, 2010 );
				int month = rnd.Next( 1, 12 );
				int day = rnd.Next( 1, 31 );
				if (month == 2)
					  day = day > 28 ? 28 : day;
				if (day < 10)
					  dy = "0" + day . ToString ( );
				else dy = day . ToString ( );
				if (month < 10)
					  mnth = "0" + month . ToString ( );
				else
					  mnth = month . ToString ( );
				yr = year . ToString ( );
				return (SQLdateout = "'" + yr + "/" + mnth + "/" + dy + "'");
		    }

		    // UTILITY FUNCTIONS BELOW HERE...
		    //************************************************************************//
		    private void SQLcommand_Enter ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				if (firsttime)
				{
					  // let user delete this easily....
					  this . SQLcommand . SelectAll ( );
					  this . SQLcommand . Text = "";
					  firsttime = false;
				}
		    }

		    private void MathCommand_Enter ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				if (mathfirsttime)
				{
					  // let user delete tis easily....
					  this . MathCommands . SelectedIndex = 0;
					  this . MathCommands . SelectedItem = "";
					  mathfirsttime = false;
				}
		    }

		    private void exit_Click ( object sender , EventArgs e )
		    {
				Close ( );
		    }

		    //************************************************************************//
		    public static string GetCustNumber ( )
		    //************************************************************************//
		    {
				string str = "";
				str = "'" + Customer . GetCustomerNumberSeed ( ) + "'";
				return str; // str is a fully SQL formatted string value
		    }

		    public static string GetBankNumber ( )
		    //************************************************************************//
		    {
				string str = "";
				str = "'" + BankAccount . GetBankAccountNumberSeed ( ) + "'";
				return str; // str is a fully SQL formatted string value
		    }

		    public static string GetCustFileName ( )
		    //************************************************************************//
		    {
				string str = "";
				str += "'CustObj" + Customer . GetCustomerNumberSeed ( ) . ToString ( ) + ".cust'";
				return str; // str is a fully SQL formatted string value
		    }

		    public static string GetBankFileName ( )
		    //************************************************************************//
		    {
				string str = BankAccount.ReadBankFilePath();
				str += "'BankObject" + BankAccount . GetBankFileNumberSeed ( ) . ToString ( ) + ".bnk'";
				return str; // str is a fully SQL formatted string value
		    }

		    public static string GetCustFullFileName ( )
		    //************************************************************************//
		    {
				string str = "";
				str = Customer . GetCustFilePath ( );
				str += GetCustFileName ( );
				string tmp = "'" + str + "'";
				return tmp; // tmp  is a fully SQL formatted string value
		    }

		    private void MathCommands_KeyDown ( object sender , KeyEventArgs e )
		    //************************************************************************//
		    {
				int index = 0;
				if (e . KeyCode == Keys . Delete)
				{
					  index = this . MathCommands . SelectedIndex;
					  if (index == -1) return;
					  this . MathCommands . Items . RemoveAt ( index );
				}
		    }

		    private void clear_Click_1 ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				this . Data . Clear ( );
		    }

		    public static string GetBankFullFileName ( )
		    //************************************************************************//
		    {
				string str = "";
				str = BankAccount . ReadBankFilePath ( );
				str += GetBankFileName ( );
				string tmp = "'" + str + "'";
				return tmp; // tmp is a fully SQL formatted string value
		    }

		    //************************************************************************//
		    private void ShowDataTable ( DataTable dt , Int32 length )
		    // list all data in a DataTable passed ot us
		    //**************************************************************************************************************************************************************************************
		    {

				// Dislay the schema data in our textbox
				foreach (DataColumn col in dt . Columns)
				{
					  this . Data . Text += (col . ColumnName . ToString ( ) + "\r\n");
				}

				foreach (DataRow row in dt . Rows)
				{
					  foreach (DataColumn col in dt . Columns)
					  {
						    if (col . DataType . Equals ( typeof ( DateTime ) ))
								this . Data . Text += (row [ col ] . ToString ( ) + "\r\n");
						    else if (col . DataType . Equals ( typeof ( Decimal ) ))
								this . Data . Text += (row [ col ] . ToString ( ) + "\r\n");
						    else
								this . Data . Text += (row [ col ] . ToString ( ) + "\r\n");
					  }
				}
		    }

		    private void schemas_Click ( object sender , EventArgs e )
		    {
				if (SQLHelper . cnn != null)
				{
					  // got a connectoin, go ahead

					  DataTable dtDBSchema = SQLHelper.cnn.GetSchema( "Tables" );
					  //				ShowDataTable (dtDBSchema, 25);
					  string[] columnRestrictions = new string[4];
					  columnRestrictions [ 0 ] = "Customer";
					  //				columnRestrictions[1] = "BankAccount";
					  //				columnRestrictions[2] = "SecondaryCustAccounts";
					  dtDBSchema = SQLHelper . cnn . GetSchema ( "Columns" , columnRestrictions );
					  //				ShowDataTable (dtDBSchema, 25);
					  //				dtDBSchema = SQLHelper.cnn.GetSchema ("IndexColumns");
					  //				ShowDataTable (dtDBSchema, 25);
					  // Not much useful info in this one
					  //				DataTable dtDBSchema = cnn.GetSchema ("DataBases");
					  //				ShowDataTable (dtDBSchema);
					  ShowColumns ( dtDBSchema );
				}
		    }

		    private void ShowColumns ( DataTable dt )
		    {
				var selectedRows = from info in dt.AsEnumerable()
							 select new {
								   TableCatalog = info["TABLE_CATALOG"],
								   TableSchema = info["TABLE_SCHEMA"],
								   TableName = info["TABLE_NAME"],
								   ColumnName = info["COLUMN_NAME"],
								   DataType = info["DATA_TYPE"]
							 };
				this . Data . Text += ("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", "TableCatalog", "TABLE_SCHEMA",
							"TABLE_NAME", "COLUMN_NAME", "DATA_TYPE", "\r\n");
				foreach (var row in selectedRows)
				{
					  this . Data . Text += ("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", row . TableCatalog,
								  row . TableSchema, row . TableName, row . ColumnName, row . DataType);
				}
		    }

		    private void Data_TextChanged ( object sender , EventArgs e )
		    {

		    }

		    private void WriteCSVtoCust_Click ( object sender , EventArgs e )
		    {

		    }

		    private void sqlcommandslist_SelectedIndexChanged ( object sender , EventArgs e )
		    {

		    }

		    private void button1_Click_1 ( object sender , EventArgs e )
		    {
				// start a new selection, so clear last lot of selections
				this . MathCommands . Items . Clear ( );
		    }

		    private void button2_Click ( object sender , EventArgs e )
		    {
				this . sqlcommandlist . Items . Clear ( );
				this . sqlcommandlist . Items . AddRange ( (string [ ]) sqlCommands );
				this . sqlcommandvalues . Items . Clear ( );
				this . sqlcommandvalues . Items . AddRange ( (string [ ]) sqlValues );
				this . FieldNames . Clear ( );
				this . FieldTypes . Clear ( );
				this . sqlcommandlist . Refresh ( );
				this . sqlcommandvalues . Refresh ( );

		    }

		    private void clear_Click_2 ( object sender , EventArgs e )
		    {
				this . Data . Clear ( );
		    }


		    //************************************************************************//
		    private void WriteCSVtoCust_Click_1 ( object sender , EventArgs e )
		    //************************************************************************//
		    {
				if (!this . SQLcommand . Text . Contains ( "Type your SQL enquiry here" ))
				{
					  //// We  have some form of SQL entry, so try to process it
					  //				string cmddata = cmdroot + datain + ")";
					  string cmddata = "";
					  string input = this.SQLcommand.Text;
					  char[] ch = {','};
					  string[] args = input.Split( ch );
					  int count = 0;
					  foreach (string item in args)
					  {
						    if (item . Contains ( "Select" ))
						    {
								cmddata = item;
						    }
						    else if (item . Contains ( "Update" ))
						    {
								cmddata = item;
						    }
						    else if (item . Contains ( "Insert" ))
						    {
								cmddata = item;
						    }
						    else
						    {
								// hmmmm, what has been entered ???
								cmddata = item;
						    }
					  }

					  if (cmddata != "")
						    SQLHelper . WriteSQLdata ( cmddata );
				}
				else
				{
					  // write data to Customer DB
					  string cmdroot = "Insert into Customer (CustomerNumber, LastName, FirstName, PhoneNumber, "
						     + "MobileNumber, Address1, Address2, Town, County, Postcode, FileName, FullFileName, SecAccounts)  values ( ";
					  // //Now need to add data itself to our Command line
					  // here we read it from a Bu;lk CSV file
					  string file = "C:\\Users\\ianch\\source\\C#SavedData\\BulkData\\DelimitedCustData(comma).txt";
					  string custfolder = "C:\\Users\\ianch\\source\\C#SavedData\\Customers\\";
					  this . Cursor = Cursors . WaitCursor;
					  if (File . Exists ( file ))
					  {
						    Int32 custno = 1234500;
						    Int32 SecAccounts = 1230000;
						    string[] inputdata = File.ReadAllLines( file );
						    string datain = "";
						    foreach (string s in inputdata)
						    { // eg: 1230003, 1234503, 3, 2345.17, 2020 - 09 - 01, 2070 - 01 - 01, 3.45, 1 + ")";
							// s contains Lastname --> Postcode
								string bulkstr = ParseInputString( 0, s );
								string filename = "CustObject" + custno.ToString() + ".cust";
								string fullpath = custfolder + "CustObject" + custno.ToString() + ".cust,";
								datain = "'" + custno . ToString ( ) + "'," + bulkstr + "'" + filename + "','" +
									   fullpath + "','" +
									   SecAccounts . ToString ( ) + "'";
								custno++;
								SecAccounts++;
								string cmddata = cmdroot + datain + ")";
								SQLHelper . WriteSQLdata ( cmddata );
						    }

						    this . Cursor = Cursors . Default;
					  }
				}

				if (!SQLAccess . SQLconnection)
				{
					  sqlConnect_Click ( sender , e );
				} // ensure we are connected

		    }



		    //+++++++++++++++++++++++++++++++++++++++++++++++++++
		    private string RefreshSQLCommands ( string linein )
		    //+++++++++++++++++++++++++++++++++++++++++++++++++++
		    {
				string output = "";
				int indexer = 0;
				int max = 0;
				int currentrow = 0;
				bool alldone = false;
				//			int currselection = this.FieldNames.f.
				if (linein . ToUpper ( ) . Contains ( "SELECT" ) || linein . ToUpper ( ) . Contains ( "INSERT" )
											|| linein . ToUpper ( ) . Contains ( "UPDATE" ) ||
											linein . ToUpper ( ) . Contains ( "ALTER" ))
				{
					  max = this . FieldTypes . Count;
					  if (linein . ToUpper ( ) . Contains ( "SELECT" ))
					  {
						    currentrow = this . sqlcommandvalues . SelectedIndex;
						    //remove ALL select/Insert/Alter etc commands from our selection list
						    /*					 string [] newlist1 = {
												    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
																	    "", "", "", "", "", "", "", "", "", "", "",
																	    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
																	    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
																	    "", "", "", "", "", "", "", "", "", "", "", ""

																    };
											    string[] newlist2 = {
																	    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
																	    "", "", "", "", "", "", "", "", "", "", "",
																	    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
																	    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
																	    "", "", "", "", "", "", "", "", "", "", "", ""
																    };
											    */
						    List<string> newlist1 = new List<string>();
						    List<string> newlist2 = new List<string>();

						    indexer = this . sqlcommandlist . Items . Count;
						    int insertindex = 0;
						    for (int i = 0 ; i < indexer - 1 ; i++)
						    {
								if (!(sqlValues [ i ] == "1" || sqlValues [ i ] == "2" || sqlValues [ i ] == "3"
									|| sqlValues [ i ] == "4" || sqlValues [ i ] == "8" || sqlValues [ i ] == "9"))
								{
									  newlist1 . Add ( sqlValues [ i ] );
									  newlist2 . Add ( sqlCommands [ i ] );
								}
						    }

						    this . sqlcommandvalues . Items . Clear ( );
						    this . sqlcommandlist . Items . Clear ( );
						    for (int i = 0 ; i < indexer - 1 ; i++)
						    {
								this . sqlcommandvalues . Items . Add ( newlist1 [ i ] );
								this . sqlcommandlist . Items . Add ( newlist2 [ i ] );
						    }

						    this . sqlcommandlist . Refresh ( );
						    this . sqlcommandvalues . Refresh ( );
					  }
				}

				return "output";
		    }

		    //========================================================
		    private void ProcessSQLCommand_Click ( object sender , EventArgs e )
		    //========================================================
		    {
				/*			bool bcustfieldsdone = false;
							bool bbankfieldsdone = false;
							bool bsecfieldsdone = false;
							bool bvaluesdone = false;
							bool bfieldsdone = false;
				*/
				this . Data . Text += "\r\nParsing your SQL command ...\r\n";
				bool bstartup = false;
				bool bselect = false;
				bool bfrom = false;
				bool bselectall = false;
				int fieldscount = 0;
				int cmdtype = 0;
				int dbnameid = 0;
				string Initialcmd = "";
				// default it to Customer
				string selectedDb = "";
				int count = 0;
				// process the data from the RH listbox system
				int SqlTypeException = 0;
				string output = "";
				string str = "";
				List<string> sqlSelectedFields = new List<string>();
				int counter = 0;
				int indx = 0;
				string selitem = "";
				foreach (int item in this . FieldTypes)
				{
					  if (counter == this . FieldTypes . Count)
						    break;
					  if (item == -1 || item == 0 || item == 99)
					  {
						    counter++;
						    continue;
					  } // ignore any -1 field types

					  switch (item)
					  {
						    case 1:
								// Select commands
								if (!bstartup)
								{
									  output += this . FieldNames [ counter ] +
											" "; // Select/insert etc - on;y oONE allowed, hence bstartup test
									  bstartup = true;
									  bselect = true; // flag a "Select " statement
									  Initialcmd = this . FieldNames [ counter ];
									  if (this . FieldNames [ counter ] . Contains ( "*" ))
									  {
										    cmdtype = 14;
										    bselectall = true;
									  }
									  else
										    cmdtype = item;
								}

								counter++;
								break;

						    case 2:
								// Insert commands
								if (!bstartup)
								{
									  output += this . FieldNames [ counter ] +
											" "; // Select/insert etc - on;y oONE allowed, hence bstartup test
									  cmdtype = item;
									  bstartup = true;
									  Initialcmd = this . FieldNames [ counter ];
								}

								counter++;
								break;

						    case 3:
								// Update commands
								if (!bstartup)
								{
									  output += this . FieldNames [ counter ] +
											" "; // Select/insert etc - on;y oONE allowed, hence bstartup test
									  cmdtype = item;
									  bstartup = true;
									  Initialcmd = this . FieldNames [ counter ];
								}

								counter++;
								break;

						    case 4:
								// Alter commands
								if (!bstartup)
								{
									  output += this . FieldNames [ counter ] +
											" "; // Select/insert etc - on;y oONE allowed, hence bstartup test
									  cmdtype = item;
									  bstartup = true;
									  Initialcmd = this . FieldNames [ counter ];
								}

								counter++;
								break;

						    case 5: // fieldnames for CUSTOMER
								if ((selectedDb == "" || selectedDb == "CUSTOMER")
								    && ((dbnameid == 0 || dbnameid == 5)
									  && (dbnameid != 6 && dbnameid != 7)))
								{
									  output += this . FieldNames [ counter ] + ", "; // fieldnames for CUSTOMER
									  fieldscount++;
									  dbnameid = 5;
									  sqlSelectedFields . Add ( this . FieldNames [ counter ] );
									  selectedDb = "CUSTOMER";
								}

								counter++;
								break;

						    case 6: // fieldnames for BANKACCOUNT
								if ((selectedDb == "" || selectedDb == "CUSTOMER")
								    && ((dbnameid == 0 || dbnameid == 6)
									  && (dbnameid != 5 && dbnameid != 7)))
								{
									  output += this . FieldNames [ counter ] + ", ";
									  fieldscount++;
									  dbnameid = 6;
									  sqlSelectedFields . Add ( this . FieldNames [ counter ] );
									  selectedDb = "BANKACCOUNT";
								}

								counter++;
								break;

						    case 7: // fieldnames for SECONDARYACCOUNTS
								if ((selectedDb == "" || selectedDb == "CUSTOMER")
								    && ((dbnameid == 0 || dbnameid == 7)
									  && (dbnameid != 5 && dbnameid != 6)))
								{
									  output += this . FieldNames [ counter ] + ", ";
									  fieldscount++;
									  dbnameid = 7;
									  sqlSelectedFields . Add ( this . FieldNames [ counter ] );
									  selectedDb = "SECONDARYCUSTACCOUNTS";
								}

								counter++;
								break;

						    case 8:
								// Values clause, only useful if not a Select command (cmdtype = 1)
								if (cmdtype != 1)
									  output += this . FieldNames [ counter ] + ", ";
								counter++;
								break;

						    case 9:
								//Functions - only if NOT a Select command

								if (cmdtype == 1)
								{
									  var result =
										MessageBox.Show(
													"You  selected a Function, but you are using a \"Select\"  ?. \r\n" +
													"This will NOT work, so do you want to ignore this selection?",
													"SQL command Creation system",
													MessageBoxButtons.YesNo,
													MessageBoxIcon.Error,
													MessageBoxDefaultButton.Button1 );
									  if (result == DialogResult . No) // Yes
										    output += this . FieldNames [ counter ];
								}
								else
									  output += this . FieldNames [ counter ];

								counter++;
								break;

						    case 10:
								//From statements
								if (cmdtype == 1 || bselectall == true)
								{ // only for SElect commands
									  if (bselectall)
										    output += this . FieldNames [ counter + 1 ];
									  else
										    output = StripCommas ( output );
								}
								else
								{ // default button to NO
									  var result =
										MessageBox.Show(
													"You  have selected a \"From Db\" call item, but you are NOT using a \"Select\"  ?. " +
													"\r\nDo you want to ignore this selection ?",
													"SQL command Creation system",
													MessageBoxButtons.YesNo,
													MessageBoxIcon.Error,
													MessageBoxDefaultButton.Button1 );
									  if (result == DialogResult . No) // Yes
										    output += this . FieldNames [ counter ];
								}

								counter++;
								break;
						    case 14:
								// got a select * clause
								bstartup = true;
								bselect = true; // flag a "Select " statement
								bselectall = true;
								cmdtype = 14;
								output += this . FieldNames [ counter ];
								break;

						    default:
								break;
					  } // End Switch
				} // End FOREACH

				if (bselect && bfrom == false && bselectall == false)
				{
					  var result =
							MessageBox.Show(
										"[" + output +
										$"]\r\n\r\nYou have created the \"Select \" enquiry shown above but you" +
										$"\r\nhave NOT included a \"From\" statement  to define the Db required?. \r\n" +
										$"\r\nThe fields selected are for {selectedDb}, \r\nWould you like this added now?",
										$"SQL command Creation system",
										MessageBoxButtons.YesNo, MessageBoxIcon.Error,
										MessageBoxDefaultButton.Button1 );
					  if (result == DialogResult . No)
					  { // Yes
						    MessageBox . Show (
									    $"Do you want to keep the data you have selected so far ?\r\n" +
									    $"If you Click No ALL of the selected data fields will be DELETED\r\n" +
									    $"\r\nDo you want to keep tis data or not ?" ,
									    $"SQL command Creation system" ,
									    MessageBoxButtons . YesNo , MessageBoxIcon . Question ,
									    MessageBoxDefaultButton . Button1 );
						    if (result == DialogResult . No)
						    { // Yes
								this . FieldNames . Clear ( );
								this . FieldTypes . Clear ( );
								this . MathCommands . Items . Clear ( );
								return;
						    }
					  }
					  else
					  { //add the correct FROM clause
					    // first make sure there is  no trailing comma on fields list
						    output = StripCommas ( output );
						    output += " From " + selectedDb + "";
					  }
				}

				this . Data . Text += ("\r\nYour processed SQL command string created is shown below :-\r\n[ " + output +
							 "]\r\n");
				if (cmdtype == 1 || cmdtype == 14)
				{ // Select is the  command
					  string input = "";
					  this . Data . Text += $"Processing Your SQL enquiry, Please Wait ...\r\n";
					  ReadSQLdata ( output , sqlSelectedFields , this . FieldTypes , selectedDb );

					  this . Data . Text += $"Your Completed SQL enquiry above returned {count} entries...\r\n";
					  var result =
							MessageBox.Show(
										"[" + output +
										$"]\r\n\r\nYou have successfully completed the \"Select \" enquiry shown above. \r\n" +
										$"\r\nIf you have finished with this particular SQL Enquiry ?\r\n" +
										$"\r\nClick Yes to have the entire list of current selections deleted.\r\n" +
										$"\r\nIf you click \"No\" you can still delete or edit them on the SQL Enquiry form itself ",
										"SQL command Creation system",
										MessageBoxButtons.YesNo, MessageBoxIcon.Question,
										MessageBoxDefaultButton.Button2 );
					  if (result == DialogResult . Yes)
					  { // Yes - dleete the enquiry now
						    this . FieldNames . Clear ( );
						    this . FieldTypes . Clear ( );
						    // clear the selection chosesn list
						    this . MathCommands . Items . Clear ( );
						    // refill both our selection lists
						    this . sqlcommandlist . Items . Clear ( );
						    this . sqlcommandlist . Items . AddRange ( (string [ ]) sqlCommands );
						    this . sqlcommandvalues . Items . Clear ( );
						    this . sqlcommandvalues . Items . AddRange ( (string [ ]) sqlValues );
						    this . sqlcommandlist . Refresh ( );
						    this . sqlcommandvalues . Refresh ( );
						    this . sqlcommandlist . SelectedIndex = 1;
						    this . sqlcommandlist . Focus ( );

						    return;
					  }
				}
		    }


		    //+++++++++++++++++++++++++++++++++++++++++++++++++++
		    private string RefreshSQLCommands ( string linein , int indx )
		    //+++++++++++++++++++++++++++++++++++++++++++++++++++
		    {
				string output = "";
				int indexer = 0;
				int max = 0;
				int currentrow = 0;
				bool alldone = false;

				if ((!linein . ToUpper ( ) . Contains ( "*" )) && (linein . ToUpper ( ) . Contains ( "SELECT" ) ||
											  linein . ToUpper ( ) . Contains ( "INSERT" )
											  || linein . ToUpper ( ) . Contains ( "UPDATE" ) ||
											  linein . ToUpper ( ) . Contains ( "ALTER" )))
				{
					  max = this . FieldTypes . Count;
					  if (linein . ToUpper ( ) . Contains ( "SELECT" ))
					  {
						    currentrow = this . sqlcommandvalues . SelectedIndex;
						    List<string> newlist1 = new List<string>();
						    List<string> newlist2 = new List<string>();

						    indexer = this . sqlcommandlist . Items . Count;
						    //int insertindex = 0;
						    for (int i = 0 ; i < indexer - 1 ; i++)
						    {
								if (!(sqlValues [ i ] == "1" || sqlValues [ i ] == "2" || sqlValues [ i ] == "3"
									|| sqlValues [ i ] == "4" || sqlValues [ i ] == "8" || sqlValues [ i ] == "9"
									|| sqlValues [ i ] == "14" || sqlValues [ i ] == "-2" || sqlValues [ i ] == "-3"))
								{ // only keep those options that still apply fter  SELECT clause is selected by user
									  newlist1 . Add ( sqlValues [ i ] );
									  newlist2 . Add ( sqlCommands [ i ] );
								}
						    }

						    indexer = newlist1 . Count;
						    this . sqlcommandvalues . Items . Clear ( );
						    this . sqlcommandlist . Items . Clear ( );
						    for (int i = 0 ; i < indexer - 1 ; i++)
						    {
								this . sqlcommandvalues . Items . Add ( newlist1 [ i ] );
								this . sqlcommandlist . Items . Add ( newlist2 [ i ] );
						    }

						    // update the visible and hidden listboxes
						    this . sqlcommandlist . Refresh ( );
						    this . sqlcommandvalues . Refresh ( );
					  }
				}
				//sqlcommandlist.Text[ sqlcommandlist . SelectedIndex].ToString().Contains( "*")
				else if (linein . Contains ( "*" ))
				{ // got a Select * clause, so they want ALL FIELDS
				  // so we gotta  remove ALL field selections
					  max = this . FieldTypes . Count;
					  currentrow = this . sqlcommandvalues . SelectedIndex;
					  List<string> newlist1 = new List<string>();
					  List<string> newlist2 = new List<string>();

					  indexer = this . sqlcommandlist . Items . Count;
					  //int insertindex = 0;
					  for (int i = 0 ; i < indexer - 1 ; i++)
					  { // this is going to remove most everything !!
						    if (!(sqlValues [ i ] == "1" || sqlValues [ i ] == "2" || sqlValues [ i ] == "3"
							    || sqlValues [ i ] == "4" || sqlValues [ i ] == "5" || sqlValues [ i ] == "6"
							    || sqlValues [ i ] == "7" || sqlValues [ i ] == "8"
							    || sqlValues [ i ] == "9" || sqlValues [ i ] == "11"
							    || sqlValues [ i ] == "12" || sqlValues [ i ] == "13" || sqlValues [ i ] == "14"
							    || sqlValues [ i ] == "-2" || sqlValues [ i ] == "-3" || sqlValues [ i ] == "-4" ||
							    sqlValues [ i ] == "-5"))
						    {
								newlist1 . Add ( sqlValues [ i ] );
								newlist2 . Add ( sqlCommands [ i ] );
						    }
					  }

					  this . sqlcommandvalues . Items . Clear ( );
					  this . sqlcommandlist . Items . Clear ( );
					  indexer = newlist1 . Count;
					  for (int i = 0 ; i < indexer - 1 ; i++)
					  {
						    this . sqlcommandvalues . Items . Add ( newlist1 [ i ] );
						    this . sqlcommandlist . Items . Add ( newlist2 [ i ] );
					  }

					  // update the visible and hidden listboxes
					  this . sqlcommandlist . Refresh ( );
					  this . sqlcommandvalues . Refresh ( );
				}

				//			else if (linein.Contains( "from " ))
				//				MathCommands.Items.Add( linein );
				return "output";
		    }

		    private void MathCommands_SelectedIndexChanged ( object sender , EventArgs e )
		    {
				int last = 0;
				if (MathCommands . SelectedIndex == -1)
					  MathCommands . SelectedIndex = 0;

				this . MathCommands . Items . Insert ( last , "" );
				this . MathCommands . SelectedIndex = last;
		    }

		    public async void ReadSQLdata
					    ( string enquiry , List<string> sqlSelectedFields , List<int> fldtypes , string requiredDb )
		    //***********************************************************************************************************************************
		    /*
	     * we also have this similar function (below here) to try if this one fails....
	     *	  public static void readSQLdata(string sql)
	     * */
		    {
				string sql, Output = "";
				int cnt = 0;
				//				count = 0;
				int counter = 0;
				int fldcount = 0;
				SQLdataOutput . Clear ( );

				// Make sure we have a connection to our SQLDb
				if (!SQLAccess . SQLconnection)
					  SQLHelper . SQLConnect ( );

				if (SQLAccess . SQLconnection)
				{ // we should be connected by this point - see above
					  bool experiment = false;
					  sql = enquiry;
					  SqlConnection cnn = new SqlConnection( this.ConnectionString );
					  cnn . Open ( );

					  if (experiment == false)
					  {
						    //==================================//
						    // A MANUAL enquiry
						    //==================================//
						    if (sqlSelectedFields == null && fldtypes == null)
						    {
								command = new SqlCommand ( enquiry , cnn );
								reader = command . ExecuteReader ( );
								fldcount = reader . FieldCount;
								Output = "";

								while (reader . Read ( ))
								{
									  for (int i = 0 ; i < fldcount - 1 ; i++)
										    Output += "\t" + reader . GetValue ( i );
									  cnt++;
									  Output += "\r\n";
									  // stick  our data into a  hidden holding textbox
									  //							sqlLine.Text = Output;
									  SQLdataOutput . Add ( Output );
									  //DisplayDatafromSQL ( Output );
									  Output = "";
								}

								reader . Close ( );
								//					SQLDataChangedEvent?.Invoke( Output, count.ToString() );
						    }
						    else
						    {

								//==================================//
								// A GENERATED enquiry
								//==================================//
								// Called from SqlConnector for Customer, BankAccount or Secondary Db's.
								//Task  t = Task.Factory(  );
								try
								{
									  cnn = new SqlConnection ( this . ConnectionString );
									  cnn . Open ( );
									  command = new SqlCommand ( enquiry , cnn );
									  reader = command . ExecuteReader ( );
									  fldcount = reader . FieldCount;
									  Output = "";
									  while (reader . Read ( ))
									  {
										    for (int i = 0 ; i < fldcount - 1 ; i++)
												Output += "\t" + reader . GetValue ( i );
										    cnt++;
										    Output += "\r\n";
										    SQLdataOutput . Add ( Output );
										    Output = "";
									  }
									  reader . Close ( );
									  // just add data to the publically declared  List<string> object
									  SQLdataOutput . Add ( Output );
									  object o = SQLdataOutput;
								}
								catch
								{
									  new Exception ( "Failed to readSQL  data......" );
								}
						    }
					  }
					  // This is my FIRST WORKING  thread handed off ....
					  var myTask = Task.Factory.StartNew( () => { listSQLData( SQLdataOutput );} )  ;
				}
		    }

		    public async void listSQLData ( List<String> SQLdataOutput )
		    {
				TextBox sqlLine = new TextBox();
				sqlLine . Multiline = true;
				for (int i = 0 ; i < SQLdataOutput . Count - 1 ; i++)
					  sqlLine . Text += SQLdataOutput [ i ];
				showdbdata ( sqlLine . Text );
		    }
		    public void showdbdata ( string str )
		    {
				if (InvokeRequired)
				{
					  this . Invoke ( new Action<string> ( showdbdata ) , new object [ ] { str } );
					  return;
				}
				Data . Text += str;
				Data . Text += "\r\nEnd of SQL data returned from your recent enquiry...\r\n.";
				//			    Data.Text.
				Data . ScrollToCaret ( );
		    }
	  }
}       // End CLASS

