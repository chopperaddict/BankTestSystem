using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class sqlconnector : Form
	{

		//************************************************************************//
		//THIS STRING ACTUALLY FUCKING WELL WORKS !!!!!!
		//************************************************************************//
		public string ConnectionString =
			@"Data Source = DINO-PC\SQLEXPRESS; Initial Catalog = ian1; Integrated Security = True";

		/*
				string CustSQLTemplate_Command = "Insert into Customer ";
				string CustSQLTemplate_Fields = "(Id, CustomerNo, LastName, FirstName, PhoneNumber, MobileNumber, Address1, Address2, Town, County, Postcode, FileName, FullFileName, SecAccounts) ";
				//																Num,  Num,       'string',       'string',     'string',  'string',   ' string',  'string', 'string', 'string',     'string',      'string',    'string',           Number
				string CustSQLTemplate_Data = "	values (x, 1234500, 'Lastname', Firstname', 'Phone', 'Mobile', 'Addr1', 'Addr2', 'Town', 'County', 'Postcode', 'Fname', 'fullFname' , BankACNo1)";

				string BankSQLTemplate_Command = "Insert into BankAccount";
				string BankSQLTemplate_Fields = "(Id, BankACNumber, CustACnumber, AccountType, Balance, OpenDate, CloseDate, InterestRate, Status) ";
				//																	Num,  Num,       Num,     Num,     decimal,    'xx/xx/xx',  'xx/xx/xx',     decimal,   Num
				string BankSQLTemplate_Data = " values (x,    1230xxx,  1234xxx, 1/2/3/4,  Balance,   OpenDate, ClosedDate, Interest,    Status)";
		*/
		private static bool firsttime = true;
		private static bool mathfirsttime = true;
		public string threadArg1 = "";
		public string threadArg2 = "";

		public int listindex = 0;

		// Lists for fields names, and the int is for it's index in the db...
		public List<string> FieldNames = new List<string> ( );

		public List<int> FieldTypes = new List<int> ( );

		//**************************************************************************************************************************************************************************************
		// This is a delegate
		private void sqlconnector_SQLDataChangedEvent (object sender, string e)
		//**************************************************************************************************************************************************************************************
		{
			string datain = (string)sender;
			Data.AppendText (datain);
		}

		//**************************************************************************************************************************************************************************************
		public static void uppdateSQLOutput (string datain)
		//**************************************************************************************************************************************************************************************
		{
			//			sqlconnector.Data.AppendText (datain);

		}

		public sqlconnector ( )
		//=========================================================================================
		{
			InitializeComponent ( );
			// display conection string on our window
			if ( !SQLAccess.SQLconnection )
			{
				connstring.Text = ConnectionString;
				// connect to DB
				if ( SQLAccess.SQLconnection )
					info.Text = "Connected to SQL server successfully...";
				else
					info.Text = "NOT yet connected to SQL server...";
			}

			// prefill first entry so we can update it later with our chosen DB name/Type
			FieldNames.Add ("");
			FieldTypes.Add (0);
		}

		public void sqlConnect_Click (object sender, EventArgs e)
		//=========================================================================================
		{
			if ( !SQLAccess.SQLconnection )
			{
				SqlConnection cnn;
				connstring.Text = ConnectionString;
				cnn = new SqlConnection (ConnectionString);
				cnn.Open ( );
				Bank.form1.Output2.AppendText ("SQL Connection opened successfully..");
				info.Text = "SQL Connection opened successfully";
			}
		}

		//=========================================================================================
		// this is where we add user SQL statement selections into a listbox 
		private void sqlcommandslist_MouseDoubleClick_1 (object sender, MouseEventArgs e)
		//=========================================================================================
		{
			// process selected item from selections and format it for SQL
			// and finally add it to detailed SQL command window
			int index = 0;
			// current selected item (index)
			index = sqlcommandslist.SelectedIndex;
			string cmd = "";
			// This is the <string> that has been selected
			cmd = sqlcommandslist.Text;
			// Add TEXT data to our lower <string> list
			MathCommands.Items.Add (cmd);
			// add it to our List<string>
			FieldNames.Add (cmd);
			// now sort out the vlaues data for our "Collections"
			// ensure we are reading the correct value for our command
			MathsValues.SelectedIndex = index;
			// should let us access the correct fields selected later  on?
			int x = Convert.ToInt16 (MathsValues.Text);
			FieldTypes.Add (x);
			// set the selection focus to the newly added item so the ListBox  scrolls up 

			MathCommands.SelectedItem = MathCommands.Items.Count - 1;
			// set focus back to selection listbox
			sqlcommandslist.Focus ( );
		}
		//************************************************************************//
		private void ProcessSQLCommand_Click (object sender, EventArgs e)
		//************************************************************************//
		{
			bool bstartup = false;
			bool bcustfieldsdone = false;
			bool bbankfieldsdone = false;
			bool bsecfieldsdone = false;
			bool bvaluesdone = false;
			bool bfieldsdone = false;
			bool bselect = false;
			bool bfrom = false;
			int fieldscount = 0;
			int cmdtype = 0;

			string Initialcmd = "";
			// default it to Customer
			string selectedDb = "";
			int count = 0;
			// process the data from the RH listbox system
			int SqlTypeException = 0;
			string output = "";
			string str = "";
			///			string[] lines = str.Split (ch);
			MathCommands.SelectedItem = 0;
			MathsValues.SelectedItem = 0;
			for ( int i = 0; i < MathCommands.Items.Count; i++ )
			{
				MathCommands.SelectedIndex = i;
				// update our public lists
				FieldNames.Add (MathCommands.Text);
				int code = 0;
				MathsValues.SelectedItem = i;
				if ( MathsValues.SelectedItem != "" )
				{
					code = Convert.ToInt16 (MathsValues.SelectedItem);
					FieldTypes.Add (code);
				}
			}

			int counter = 0;
			int indx = 0;
			string selitem = "";
			foreach ( int item in FieldTypes )
			{
				selitem = FieldNames[FieldTypes[counter]];
				//indx = counter;
				//	FieldTypes.SelectedIndex = selitem;
				if ( item == -1 || item == 0 || item == 99 )
				{
					counter++;
					continue;
				} // ignoire any -1 field types

				else if ( item == 1 || item == 2 || item == 3 || item == 4 )
				{
					if ( !bstartup )
					{
						output += FieldNames[counter] + " "; // Select/insert etc - on;y oONE allowed, hence bstartup test
						cmdtype = item;
						bstartup = true;
						if ( item == 1 ) bselect = true;    // flag a "Select " statement
						Initialcmd = FieldNames[counter];
						counter++;
					}
					else
					{
						counter++;
						continue;
					}
				}
				// on;ly allow ONE type of fields
				else if ( item == 5 && (!bbankfieldsdone && !bsecfieldsdone) )
				{
					output += FieldNames[counter] + ", "; // fieldnames for CUSTOMER
					fieldscount++;
					bcustfieldsdone = true; // flag our fieldstype is customer
					counter++;
					continue;
				}
				else if ( item == 6 && (!bcustfieldsdone && !bsecfieldsdone) )
				{
					output += FieldNames[counter] + ", "; // fieldnames for BANKACCOUNT
					fieldscount++;
					bbankfieldsdone = true; // flag our fieldstype is BankAccount
					counter++;
					continue;
				}
				else if ( item == 7 && (!bcustfieldsdone && !bbankfieldsdone) )
				{
					output += FieldNames[counter] + ", "; // fieldnames for BANKACCOUNT
					fieldscount++;
					bbankfieldsdone = true; // flag our fieldstype is BankAccount
					counter++;
					continue;
				}
				else if ( !bvaluesdone && ((item == 8 || item == 9) && cmdtype != 1) )
				{ // Allow just one "Values() clause, but ONLY for NON Select statements
					output += FieldNames[counter] + ", ";
					bvaluesdone = true;
					counter++;
					continue;
				}
				else if ( item == 9 && cmdtype == 1 && bfieldsdone == false )
				{ // Functions - but we have a select command , so just remove LAST comma(s) in our string
					string revstr = "";
					revstr = Utils.ReverseString (output);
					int cnt = 0;
					while ( revstr[cnt] == ',' || revstr[cnt] == ' ' )
					{ cnt++; }
					if ( cnt > 0 )
					{
						output = Utils.ReverseString (revstr);
						output = output.Substring (0, output.Length - (cnt));
						output += "  ";
					}
					else
						output = Utils.ReverseString (revstr);
					counter++;
					bfieldsdone = true;
					continue;
				}
				else if ( item == 9 && bfieldsdone == true )
				{
					counter++;
					var result =
						MessageBox.Show (
							"You  selected a Function call() item, but you are using a \"Select\"  ?. \r\nDo you really want to add this your SQL statement ?",
							"SQL command Creation system", MessageBoxButtons.YesNo);
					if ( result == DialogResult.Yes ) // Yes
						output += FieldNames[counter];
					else
						break;

				}
				else if ( item == 10 && cmdtype == 1 )
				{ // "Functions "From clause AND we have a select clause
					output += FieldNames[counter] + ", ";
					counter++;
					continue;
				}
				else if ( item == 10 && cmdtype != 1 == true )
				{
					var result =
					MessageBox.Show (
						"You  have selected a \"From Db\" call item, but you are NOT using a \"Select\"  ?. \r\nDo you really want to add this your SQL statement ?",
						"SQL command Creation system", MessageBoxButtons.YesNo);
					if ( result == DialogResult.Yes ) // Yes
						output += FieldNames[counter];
				}
				counter++;
			}      // End ForEach

			if ( bselect && bfrom == false )
			{
				var result =
					MessageBox.Show (
						"You  have used a \"Select \" option , but you have NOT using selected a \"From\" statement  ?. \r\nThis SQL statement will not work, do you want to select it now ??",
						"SQL command Creation system", MessageBoxButtons.YesNo);
				if ( result == DialogResult.No )
				{ // Yes
					FieldNames.Clear ( );
					FieldTypes.Clear ( );
					return;
				}
				else
				{   // dislay a selection window for the "from"
					SQLDbSelector SQLS = new SQLDbSelector ( );
					SQLS.ShowDialog ( );
					if ( threadArg1 == "" )
					{
						FieldNames.Clear ( );
						FieldTypes.Clear ( );
						return;
					}

					if ( threadArg1 == "Customer" )
					{ output += " From Customer"; }
					else if ( threadArg1 == "BankAccount" )
					{ output += " From BankAccount"; }
					else
					{ output += " From SecondaryCustAccounts"; }
				};
			}

			Bank.form1.Output2.AppendText("\r\nYour SQL command string created is shown below :-\r\n" + output +"\r\n");
			if ( cmdtype == 1 )
			{ // Select is the  command
				string input = "";
				input = SQLHelper.ReadSQLdata (output, FieldNames, FieldTypes, selectedDb, out count);
				FieldNames.Clear ( );
				FieldTypes.Clear ( );
			}
			else
			{ // Update /insert / Alter Db
				SQLHelper.WriteSQLdata (output);
				FieldNames.Clear ( );
				FieldTypes.Clear ( );
			}
		}   // function

		private void sqlcommandslist_SelectedIndexChanged (object sender, EventArgs e)
		//=========================================================================================
		{

		}
		//************************************************************************//
		private void ReadBankDB_Click_1 (object sender, EventArgs e)
		//************************************************************************//
		{
			info.Text = "Loading Bank Accounts SQL Database - Please wait ...";
			Cursor = Cursors.WaitCursor;
			BankDBView dbv = new BankDBView ( );
			dbv.Show ( );
			Cursor = Cursors.Default;
		}
		//************************************************************************//
		private void ReadCustDB_Click (object sender, EventArgs e)
		//************************************************************************//
		{
			info.Text = "Loading Customer Accounts SQL Database - Please wait ...";
			Cursor = Cursors.WaitCursor;
			CustDataView dbv = new CustDataView ( );
			Cursor = Cursors.Default;
			dbv.Show ( );
		}
		private void ReadStdCustomerSqlData (object sender, EventArgs e)
		{
			Data.Text = "Requesting limited field's Bankaccount data from SQL Server.....\r\n";
			string query = "Select  BankACNumber, CustACNumber, Balance , InterestRate, OpenDate, Status from BankAccount ";

			this.Cursor = Cursors.WaitCursor;
			int count = 0;
			//			public static string ReadSQLdata (string enquiry, List<string> fldnames, List<int> fldtypes, string requiredDb, out int count)
			string input = SQLHelper.ReadSQLdata (query, null, null, "CUSTOMER", out count);
			if ( input.Length > 0 )
				Data.AppendText (input);
			else
				Data.AppendText ("No data was returned by that SQL enquiry.\r\n");
			RecordCount.Text = count.ToString ( );
			this.Cursor = Cursors.Default;
		}
		//************************************************************************//
		private void ReadCustDB_Click_1 (object sender, EventArgs e)
		//************************************************************************//
		{
			Data.Text += "Requesting limited fields Customer data from SQL Server.....\r\n";
			string query = "Select  CustomerNumber, FirstName, LastName, Town, County, DOB, SecAccounts from Customer";

			this.Cursor = Cursors.WaitCursor;
			int count = 0;
			//			public static string ReadSQLdata (string enquiry, List<string> fldnames, List<int> fldtypes, string requiredDb, out int count)
			string input = SQLHelper.ReadSQLdata (query, null, null, "CUSTOMER", out count);
			if ( input.Length > 0 )
				Data.AppendText (input);
			else
				Data.AppendText ("No data was returned by that SQL enquiry.\r\n");
			RecordCount.Text = count.ToString ( );
			this.Cursor = Cursors.Default;
		}
		private void ReadCustomerSqlData (object sender, EventArgs e)
		{
			Data.Text += "\r\nRequesting all fields from Customer Db data from SQL Server.....\r\n";
			Cursor = Cursors.WaitCursor;
			string query = "Select * from Customer ";
			int count = 0;
			// thiis Fn loops getting lines of data
			//			public static string ReadSQLdata (string enquiry, List<string> fldnames, List<int> fldtypes, string requiredDb, out int count)
			string input = SQLHelper.ReadSQLdata (query, null, null, "CUSTOMER", out count);
			if ( input.Length > 0 )
				Data.AppendText (input);
			else
				Data.AppendText ("No data was returned by that SQL enquiry.\r\n");
			RecordCount.Text = count.ToString ( );
			this.Cursor = Cursors.Default;
		}
		//************************************************************************//
		//		private void WriteCSVtoBank_Click (object sender, EventArgs e) { }
		private void WriteCSVtoBank_Click_1 (object sender, EventArgs e)
		//************************************************************************//
		{
			// write data to DB
			string cmdroot = "Insert into BankAccount";
			cmdroot += "(BankACNumber, CustACnumber, AccountType, Balance, OpenDate, CloseDate, InterestRate, Status)  Values (";
			string file = "C:\\Users\\ianch\\source\\C#SavedData\\BulkData\\DelimitedBankData(comma).txt";
			if ( !SQLAccess.SQLconnection )
			{ sqlConnect_Click (sender, e); }       // ensure we are connected
			if ( File.Exists (file) )
			{
				this.Cursor = Cursors.WaitCursor;
				Int32 bankno = 1050000; ;
				Int32 custno = 1234500;
				string[] inputdata = File.ReadAllLines (file);
				string datain = "";
				foreach ( string s in inputdata )
				{   // eg: 1230003, 1234503, 3, 2345.17, 2020 - 09 - 01, 2070 - 01 - 01, 3.45, 1 + ")";
					// s contains AccountType -> Status
					string bulkstr = ParseInputString (1, s);
					//					string filename = "BankObject" + bankno.ToString ( ) + ".cust";
					//					string fullpath = custfolder + "BankObject" + bankno.ToString ( ) + ".cust,";
					datain = "'" + bankno.ToString ( ) + "','" + custno.ToString ( ) + "'," + bulkstr;
					bankno++; custno++;
					string cmddata = cmdroot + datain + ")";
					SQLHelper.WriteSQLdata (cmddata);
				}
				this.Cursor = Cursors.Default;
			}
		}
		//************************************************************************//
		private void WriteCSVtoCust_Click_1 (object sender, EventArgs e)
		//************************************************************************//
		{
			if ( !SQLcommand.Text.Contains ("Type your SQL enquiry here") )
			{
				//// We  have some form of SQL entry, so try to process it
				//				string cmddata = cmdroot + datain + ")";
				string cmddata = "";
				string input = SQLcommand.Text;
				char[] ch = { ',' };
				string[] args = input.Split (ch);
				int count = 0;
				foreach ( string item in args )
				{
					if ( item.Contains ("Select") )
					{ cmddata = item; }
					else if ( item.Contains ("Update") )
					{ cmddata = item; }
					else if ( item.Contains ("Insert") )
					{ cmddata = item; }
					else
					{
						// hmmmm, what has been entered ???
						cmddata = item;
					}
				}
				if ( cmddata != "" )
					SQLHelper.WriteSQLdata (cmddata);
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
				this.Cursor = Cursors.WaitCursor;
				if ( File.Exists (file) )
				{
					Int32 custno = 1234500;
					Int32 SecAccounts = 1230000;
					string[] inputdata = File.ReadAllLines (file);
					string datain = "";
					foreach ( string s in inputdata )
					{   // eg: 1230003, 1234503, 3, 2345.17, 2020 - 09 - 01, 2070 - 01 - 01, 3.45, 1 + ")";
						// s contains Lastname --> Postcode
						string bulkstr = ParseInputString (0, s);
						string filename = "CustObject" + custno.ToString ( ) + ".cust";
						string fullpath = custfolder + "CustObject" + custno.ToString ( ) + ".cust,";
						datain = "'" + custno.ToString ( ) + "'," + bulkstr + "'" + filename + "','" + fullpath + "','" + SecAccounts.ToString ( ) + "'";
						custno++;
						SecAccounts++;
						string cmddata = cmdroot + datain + ")";
						SQLHelper.WriteSQLdata (cmddata);
					}
					this.Cursor = Cursors.Default;
				}
			}

			if ( !SQLAccess.SQLconnection )
			{ sqlConnect_Click (sender, e); }       // ensure we are connected

		}
		private void WriteTestdatatoBank_Click (object sender, EventArgs e)
		{
			//Used  mostly for Update/Insert  operations on BankAccount Db.
			// sort out command line from TEXT entered and finally give it to SQL
			// to read/write data to DB
			int SqlTypeException = 0;
			string bulkstr = "";
			string Command, temp1 = "", temp2 = "", output = "";
			Command = SQLcommand.Text;
			string[] tmp = { "", "", "", "" };
			char[] brace = { '(' };
			string[] str = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", };
			char[] ch = { ',' };
			if ( !SQLAccess.SQLconnection )
			{ sqlConnect_Click (sender, e); }       // ensure we are connected

			tmp = Command.Split (brace);
			if ( tmp[0].ToUpper ( ).Contains ("SELECT") || tmp[0].ToUpper ( ).Contains ("INSERT") || tmp[0].ToUpper ( ).Contains ("UPDATE") )
			{
				if ( tmp[0].ToUpper ( ).Contains ("SELECT") ) SqlTypeException = 0;
				if ( tmp[0].ToUpper ( ).Contains ("INSERT") ) SqlTypeException = 1;
				if ( tmp[0].ToUpper ( ).Contains ("UPDATE") ) SqlTypeException = 2;
				output = tmp[0];
			}
			//			else
			//			{
			str = tmp[1].Split (ch);
			foreach ( string s in str )
			{
				if ( s.Length == 0 ) continue;
				{
					if ( s.Contains ("()") )
						output += ", " + ParseFunction (s);
					else
					{
						if ( s.Contains ("from ") )
						{
							string temp = s.Substring (0, s.Length - 1);        // remove traing comma
							output += temp;
						}
					}
				}
			}
			//			}
			this.Cursor = Cursors.WaitCursor;
			int count = 0;
			if ( SqlTypeException == 0 )
			{   // Select - Just Read data - shown in our output window
				//			public static string ReadSQLdata (string enquiry, List<string> fldnames, List<int> fldtypes, string requiredDb, out int count)
				string input = SQLHelper.ReadSQLdata (output, null, null, "BANKACCOUNT", out count);
			}
			else if ( SqlTypeException == 1 || SqlTypeException == 2 )
			{   // Update or insert Db
				SQLHelper.WriteSQLdata (output);
			}
			Cursor = Cursors.Default;
		}
		//************************************************************************//
		private void WriteTestdatatoCust_Click (object sender, EventArgs e)
		//************************************************************************//
		{
			//Used  mostly for Update/Insert  operations on Customer Db.
			if ( !SQLAccess.SQLconnection )
			{ sqlConnect_Click (sender, e); }       // ensure we are connected

			this.Cursor = Cursors.WaitCursor;
			SQLHelper.WriteSQLdata (SQLcommand.Text);
			//		TEST DATA OPTIONS
			//			string cmdroot = "Insert into Customer (Id, CustomerNo, LastName, FirstName, PhoneNumber, MobileNumber, Address1, Address2, Town, County, Postcode, FileName, FullFileName, SecAccounts) " +
			//			"	 values (1,1234500, 'Turner', 'Ian', '01253 737014', '0757 90622440', 'Flat 38', 'Liggard Court', 'Lytham St Annes', 'Lancashire', 'FY8  4SG', 'CustObject1234500.cust', 'C:\\Users\\ianch\\source\\C#SavedData\\Customers\\custobject1234500.cust' , 1230000)";
			//			cmdroot = "Insert into Customer (Id, CustomerNo, LastName, FirstName, PhoneNumber, MobileNumber, Address1, Address2, Town, County, Postcode, FileName, FullFileName, SecAccounts) " +
			//			"	 values (1,1234501, 'Turner', 'Ian', '01253 737014', '0757 90622440', 'Flat 38', 'Liggard Court', 'Lytham St Annes', 'Lancashire', 'FY8  4SG', 'CustObject1234501.cust', 'C:\\Users\\ianch\\source\\C#SavedData\\Customers\\custobject1234501.cust' , 1230001)";
			//			SQLHelper.WriteSQLdata (cmdroot);
			this.Cursor = Cursors.Default;
		}
		//************************************************************************//
		private void listBox1_MouseDoubleClick (object sender, MouseEventArgs e)
		//************************************************************************//
		{   // paste selected item from listbox into inline SQL command editor window
			string cmd = listBox1.SelectedItem.ToString ( );
			Clipboard.Clear ( );
			if ( SQLcommand.Text.Contains ("Type your SQL enquiry here.") )
			{
				if ( !cmd.Contains ("Select") )
					Clipboard.SetText ("Select  ");
				else if ( !cmd.Contains ("Update") )
					Clipboard.SetText ("Update ");
				else if ( !cmd.Contains ("Insert") )
					Clipboard.SetText ("Insert ");
				else
					Clipboard.SetText ("UNKNOWN SQL entry ???? ");
			}
			else
			{ Clipboard.SetText (cmd); }
			SQLcommand.Paste ( );
			listBox1.Focus ( );
		}



		//************************************************************************//
		private void clear_Click (object sender, EventArgs e)
		//************************************************************************//
		{ }
		//************************************************************************//
		private void button1_Click (object sender, EventArgs e)
		//************************************************************************//
		{ SQLHelper.SQLDisConnect ( ); }
		//************************************************************************//
		private void close_Click_1 (object sender, EventArgs e)
		//************************************************************************//
		{ Close ( ); }
		//************************************************************************//
		public static string ParseFunction (string input)
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
			foreach ( string item in functions )
			{
				if ( item.ToUpper ( ).Contains (input.ToUpper ( )) )
				{
					switch ( indx )
					{
						case 0:
							tmp = GetCustNumber ( ); break;
						case 1:
							tmp = GetBankNumber ( ); break;
						case 2:
							tmp = GetCustFileName ( ); break;
						case 3:
							tmp = GetBankFileName ( ); break;
						case 4:
							tmp = GetCustFullFileName ( ); break;
						case 5:
							tmp = GetBankFullFileName ( ); break;
						case 6:
							tmp = GetRandomSQLdate ( ); break;
					}
					output += "'" + tmp + "', ";
					break;
				}
				indx++;
			}
			return output;
		}
		public static string ParseInputString (int type, string input)
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
			if ( type == 0 ) typestr = "CUST";
			else typestr = "BANK";
			string output = "";
			string datestr = "";
			char[] ch = { ',' };
			int itemcount = 0;
			string[] fieldstr = input.Split (ch);
			foreach ( string s in fieldstr )
			{
				if ( typestr == "CUST" )
				{
					if ( input.Contains ("DOB") )
					{
						//	 Need to do this when I add DOB field in
						int day = 0, month = 0, year = 0;
						DateTime dt = Convert.ToDateTime (fieldstr[2]);
						day = dt.Day; month = dt.Month; year = dt.Year;
						// convert date to YYYY/MM/DD format for SQL
						datestr = year.ToString ( ) + "/" + month.ToString ( ) + "/" + day.ToString ( );
					}
					output += "'" + s + "' , ";
				}
				else
				{
					if ( itemcount == 0 || itemcount == 1 || itemcount == 3 || itemcount == 4 )
					{
						if ( itemcount == 4 )
							output += "'" + fieldstr[itemcount] + "'";      // do NOT want end of line comma....
						else
							output += "'" + fieldstr[itemcount] + "', ";
					}
					else if ( itemcount == 2 )
					{
						// strip time off input date and we have to rEVERSE it for SQL
						char[] chr = { ' ' };
						string[] dates = s.Split (chr);
						int day = 0, month = 0, year = 0;
						DateTime dt = Convert.ToDateTime (fieldstr[2]);
						day = dt.Day; month = dt.Month; year = dt.Year;
						// convert date to YYYY/MM/DD format for SQL
						dates[0] = year.ToString ( ) + "/" + month.ToString ( ) + "/" + day.ToString ( );
						output += "' " + dates[0] + "', '2070/01/01', ";    // dummy closed date
					}
					//					else if ( itemcount == 3 )
					//						output += "'01/01/2070', " + fieldstr[itemcount + 1] + ", " + fieldstr[itemcount + 2 + ","];
					else
						output += fieldstr[itemcount];
					itemcount++;
				}
			}
			return output;
		}
		//************************************************************************//
		public static string GetRandomSQLdate ( )
		//************************************************************************//
		{
			Random rnd = new Random ( );
			DateTime dtin = DateTime.Now;
			DateTime dtout = DateTime.Now;
			string SQLdateout = "";
			string dy = "", mnth = "", yr = "";
			int year = rnd.Next (1930, 2010);
			int month = rnd.Next (1, 12);
			int day = rnd.Next (1, 31);
			if ( month == 2 )
				day = day > 28 ? 28 : day;
			if ( day < 10 )
				dy = "0" + day.ToString ( );
			else dy = day.ToString ( );
			if ( month < 10 )
				mnth = "0" + month.ToString ( );
			else
				mnth = month.ToString ( );
			yr = year.ToString ( );
			return (SQLdateout = "'" + yr + "/" + mnth + "/" + dy + "'");
		}
		//************************************************************************//
		// UTILITY FUNCTIONS BELOW HERE...
		//************************************************************************//
		private void SQLcommand_Enter (object sender, EventArgs e)
		//************************************************************************//
		{
			if ( firsttime )
			{
				// let user delete this easily....
				SQLcommand.SelectAll ( );
				SQLcommand.Text = "";
				firsttime = false;
			}
		}
		//************************************************************************//
		private void MathCommand_Enter (object sender, EventArgs e)
		//************************************************************************//
		{
			if ( mathfirsttime )
			{
				// let user delete tis easily....
				MathCommands.SelectedIndex = 0;
				MathCommands.SelectedItem = "";
				mathfirsttime = false;
			}
		}
		//************************************************************************//
		private void exit_Click (object sender, EventArgs e)
		//************************************************************************//
		{ Close ( ); }
		//************************************************************************//
		public static string GetCustNumber ( )
		{
			string str = "";
			str = "'" + Customer.GetCustomerNumberSeed ( ) + "'";
			return str;     // str is a fully SQL formatted string value
		}
		//************************************************************************//
		public static string GetBankNumber ( )
		{
			string str = "";
			str = "'" + BankAccount.GetBankAccountNumberSeed ( ) + "'";
			return str;         // str is a fully SQL formatted string value
		}
		//************************************************************************//
		public static string GetCustFileName ( )
		{
			string str = "";
			str += "'CustObj" + Customer.GetCustomerNumberSeed ( ).ToString ( ) + ".cust'";
			return str;         // str is a fully SQL formatted string value
		}
		//************************************************************************//
		public static string GetBankFileName ( )
		{
			string str = BankAccount.ReadBankFilePath ( );
			str += "'BankObject" + BankAccount.GetBankFileNumberSeed ( ).ToString ( ) + ".bnk'";
			return str;         // str is a fully SQL formatted string value
		}
		//************************************************************************//
		public static string GetCustFullFileName ( )
		{
			string str = "";
			str = Customer.GetCustFilePath ( );
			str += GetCustFileName ( );
			string tmp = "'" + str + "'";
			return tmp;          // tmp  is a fully SQL formatted string value
		}
		//************************************************************************//
		public static string GetBankFullFileName ( )
		{
			string str = "";
			str = BankAccount.ReadBankFilePath ( );
			str += GetBankFileName ( );
			string tmp = "'" + str + "'";
			return tmp;         // tmp is a fully SQL formatted string value
		}
		private void MathCommands_KeyDown (object sender, KeyEventArgs e)
		{
			int index = 0;
			if ( e.KeyCode == Keys.Delete )
			{
				index = MathCommands.SelectedIndex;
				if ( index == -1 ) return;
				MathCommands.Items.RemoveAt (index);
			}
		}
		/*
				private void sqlconnector_Load (object sender, EventArgs e)
				{
					// TODO: This line of code loads data into the 'ian1DataSet.Customer' table. You can move, or remove it, as needed.
					customerTableAdapter.Fill (ian1DataSet.Customer);
				}
		*/
		private void clear_Click_1 (object sender, EventArgs e)
		{
			Data.Clear ( );
		}
		//************************************************************************//
		private void ShowDataTable (DataTable dt, Int32 length)
		// list all data in a DataTable passed ot us
		//**************************************************************************************************************************************************************************************
		{

			// Dislay the schema data in our textbox
			foreach ( DataColumn col in dt.Columns )
			{
				Data.Text += (col.ColumnName.ToString ( ) + "\r\n");
			}
			foreach ( DataRow row in dt.Rows )
			{
				foreach ( DataColumn col in dt.Columns )
				{
					if ( col.DataType.Equals (typeof (DateTime)) )
						Data.Text += (row[col].ToString ( ) + "\r\n");
					else if ( col.DataType.Equals (typeof (Decimal)) )
						Data.Text += (row[col].ToString ( ) + "\r\n");
					else
						Data.Text += (row[col].ToString ( ) + "\r\n");
				}
			}
		}

		private void schemas_Click (object sender, EventArgs e)
		{
			if ( SQLHelper.cnn != null )
			{
				// got a connectoin, go ahead

				DataTable dtDBSchema = SQLHelper.cnn.GetSchema ("Tables");
				//				ShowDataTable (dtDBSchema, 25);
				string[] columnRestrictions = new string[4];
				columnRestrictions[0] = "Customer";
				//				columnRestrictions[1] = "BankAccount";
				//				columnRestrictions[2] = "SecondaryCustAccounts";
				dtDBSchema = SQLHelper.cnn.GetSchema ("Columns", columnRestrictions);
				//				ShowDataTable (dtDBSchema, 25);
				//				dtDBSchema = SQLHelper.cnn.GetSchema ("IndexColumns");
				//				ShowDataTable (dtDBSchema, 25);
				// Not much useful info in this one
				//				DataTable dtDBSchema = cnn.GetSchema ("DataBases");
				//				ShowDataTable (dtDBSchema);
				ShowColumns (dtDBSchema);
			}
		}

		private void ShowColumns (DataTable dt)
		{
			var selectedRows = from info in dt.AsEnumerable ( )
							   select new {
								   TableCatalog = info["TABLE_CATALOG"],
								   TableSchema = info["TABLE_SCHEMA"],
								   TableName = info["TABLE_NAME"],
								   ColumnName = info["COLUMN_NAME"],
								   DataType = info["DATA_TYPE"]
							   };
			Data.Text += ("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", "TableCatalog", "TABLE_SCHEMA",
				"TABLE_NAME", "COLUMN_NAME", "DATA_TYPE", "\r\n");
			foreach ( var row in selectedRows )
			{
				Data.Text += ("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", row.TableCatalog,
						row.TableSchema, row.TableName, row.ColumnName, row.DataType);
			}
		}

		private void Data_TextChanged (object sender, EventArgs e)
		{

		}

	}
}


