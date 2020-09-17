
using System;
using System . Configuration;
using System . Data . SqlClient;
using System . Data;
using System . Windows . Forms;
using System . Collections . Generic;
using System . Threading . Tasks;
namespace ClassAccessTest
{
//	public delegate void SQLDataChangedEvent ( );
	public class SQLHelper
	{
		public static bool SQLconnection = false;
		public static SqlCommand command2;
		public static SqlDataReader dataReader2;
		
//		public event Notify SQLDataReceived;
		//**************************************************************************************************************************************************************************************
		public static string ConnectionString =
			@"Data Source = DINO-PC\SQLEXPRESS; Initial Catalog = ian1; Integrated Security = True";

		// Note the changed location for the database
		public static SqlConnection cnn;

		//**************************************************************************************************************************************************************************************
		//**************************************************************************************************************************************************************************************
		public static string CnnVal ( string name )
		{
			return ConfigurationManager . ConnectionStrings [ name ] . ConnectionString;
		}

		//**************************************************************************************************************************************************************************************
		public static bool SQLConnect ( )
		//**************************************************************************************************************************************************************************************
		{
			cnn = new SqlConnection ( ConnectionString );
			try
			{
				cnn . Open ( );
				SQLAccess . SQLconnection = true;
				string login = cnn . ConnectionString;
				// Subscribe to our delegate - in SqlConnector.cs
				return true;
			}
			catch
			{
				Bank . form1 . Output2 . AppendText ( "SQL connection encountered a problem\r\n" );
				return false;
			}
		}
		
		public static void SQLDisConnect ( )
		//***********************************************************************************************************************************
		{
			try
			{
				cnn . Close ( );
				SQLAccess . SQLconnection = false;
			}
			catch { new Exception ( " Failed to disconnect from SQL Server" ); }
		}

		// called to load Customer data
		public static string ReadSQLLine ( string enquiry , out int count )
		//***********************************************************************************************************************************
		{
			string sql, Output = "";
			int cnt = 0;
			if (SQLAccess . SQLconnection)
			{
				bool experiment = false;
				bool experiment2 = false;
				bool experiment3 = false; //This loads the Datagrid on SqlConnector.cs
				bool experiment4 = false;
				bool experiment5 = true;
				string custno = "",
					fname = "",
					lname = "",
					phone = "",
					mobile = "",
					addr1 = "",
					addr2 = "",
					town = "",
					county = "",
					pcode = "",
					dob = "",
					filename = "",
					fullfname = "",
					secaccts = "";
				sql = enquiry;
				{
					{
						SqlConnection connection = new SqlConnection ( ConnectionString );
						connection . Open ( );
						command2 = new SqlCommand ( sql , connection );
						SqlDataAdapter adapter = new SqlDataAdapter ( command2 );
						DataSet ds = new DataSet ( );
						DataView dv = new DataView ( );
						adapter . SelectCommand = command2;
						adapter . Fill ( ds , "Create DataView" );
						adapter . Dispose ( );
						command2. Dispose ( );
						connection . Close ( );

						Output = "Field names for selected Db...\r\n";
						dv = ds . Tables [ 0 ] . DefaultView;
						ds . Dispose ( );
						int rowcount = dv . Table . Rows . Count;
						Output += "Db contains " + rowcount . ToString ( ) + "\r\n";
						int colcount = dv . Table . Columns . Count;
						string [ ] colnames = {
												"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
												"", "", "", "", "",
												"", "",
											};
						// declare it bigger than required....
						DataColumn [ ] dca = {
											   (DataColumn) null, (DataColumn) null, (DataColumn) null,
											   (DataColumn) null, (DataColumn) null, (DataColumn) null,
											   (DataColumn) null, (DataColumn) null,
											   (DataColumn) null, (DataColumn) null, (DataColumn) null,
											   (DataColumn) null, (DataColumn) null, (DataColumn) null,
											   (DataColumn) null, (DataColumn) null,
											   (DataColumn) null, (DataColumn) null, (DataColumn) null,
											   (DataColumn) null,
										   };
						dv . Table . Columns . CopyTo ( dca , 0 );
						;
						dv . Dispose ( );
						Output = "Field names for selected Db...\r\n";
						foreach (var item in dca)
						{
							if (item != null)
								Output += item . Caption + "\r\n";
						}
					}
				}
			}

			count = cnt;
			return Output;
		}

		
		private static string GetOutputData ( int fldno )
		{     // This strips the ipnut data from SQL server and returns it as a printable string
			string fldtype = "", Output = "";
			object o = dataReader2 . GetValue ( fldno );
			fldtype = dataReader2 . GetDataTypeName ( fldno ) . ToUpper ( );
			if (!
				(fldtype == "NVARCHAR" || fldtype == "VARCHAR" || fldtype == "TINYTEXT"
				  || fldtype == "TEXT" || fldtype == "MEDIUMTEXT" || fldtype == "LONGTEXT"))
			{       // NOT a text item, so fomat it in usual way
				Output += o . ToString ( );
			}
			else Output += (string) o;      // just a string - no processing required
			return Output;
		}
		public static bool WriteSQLdata ( string sql )
		//***********************************************************************************************************************************
		{
			SqlDataAdapter adapter = new SqlDataAdapter ( );
			if (SQLAccess . SQLconnection)
			{
				command2 = new SqlCommand ( sql , cnn );
				adapter . InsertCommand = new SqlCommand ( sql , cnn );
				adapter . InsertCommand . ExecuteNonQuery ( );
				command2 . Dispose ( );
				return true;
			}
			else return false;
		}

		public static void readSQLdata ( string sql , string dbname )
		{
			string custno = "",
			fname = "",
			lname = "",
			phone = "",
			mobile = "",
			addr1 = "",
			addr2 = "",
			town = "",
			county = "",
			pcode = "",
			dob = "",
			filename = "",
			fullfname = "",
			secaccts = "";
			string Output = "";
			int cnt = 0;
			int fldcount = 0;
			int count = 0;
			if (SQLAccess . SQLconnection)
			{

				command2 = new SqlCommand ( sql , cnn );
				dataReader2 = command2 . ExecuteReader ( );
				fldcount = dataReader2 . FieldCount;
				while (dataReader2 . Read ( ))
				{
					custno = dataReader2 [ "CustomerNo" ] . ToString ( );
					fname = dataReader2 [ "FirstName" ] . ToString ( );
					lname = dataReader2 [ "LastName" ] . ToString ( );
					phone = dataReader2 [ "PhoneNumber" ] . ToString ( );
					mobile = dataReader2 [ "MobileNumber" ] . ToString ( );
					addr1 = dataReader2 [ "Address1" ] . ToString ( );
					addr2 = dataReader2 [ "Address2" ] . ToString ( );
					town = dataReader2 [ "Town" ] . ToString ( );
					county = dataReader2 [ "County" ] . ToString ( );
					pcode = dataReader2 [ "PostCode" ] . ToString ( );
					dob = dataReader2 [ "DOB" ] . ToString ( );
					filename = dataReader2 [ "FileName" ] . ToString ( );
					fullfname = dataReader2 [ "FullFileName" ] . ToString ( );
					secaccts = dataReader2 [ "SecAccounts" ] . ToString ( );

					if (sql . Contains ( "Select" ) && sql . Contains ( "Customer" ))
					{
						Output += custno + "\t";
						Output += fname + "\t";
						Output += lname + "\t";
						Output += phone + "\t";
						Output += mobile + "\t";
						Output += addr1 + "\t";
						Output += addr2 + "\t";
						Output += town + "\t";
						Output += county + "\t";
						Output += pcode + "\t";
						Output += dob + "\t";
						Output += filename + "\t";
						Output += fullfname + "\t";
						Output += secaccts + "\t";
					}

//					SQLDataChangedEvent?.Invoke ( Output , "SQLDATA" );
				}
			}
			//			return Output;
		}
	}
	//dataReader.GetValue ( i );

	/*								else if (sqlSelectedFields[i].ToUpper() == "CUSTOMERNO")
									{ Output += "\t" + GetOutputData ( 1 ); }
									else if (sqlSelectedFields[i].ToUpper() == "FIRSTNAME")
									{ Output += "\t" + GetOutputData ( 2 ); }
									else if (sqlSelectedFields[i].ToUpper() == "LASTNAME")
									{ Output += "\t" + GetOutputData ( 3 ); }
									else if (sqlSelectedFields[i].ToUpper() == "ADDRESS1")
									{ Output += "\t" + GetOutputData ( 4 ); }
									else if (sqlSelectedFields[counter].ToUpper() == "ADDRESS2")
									{ Output += "\t" + GetOutputData ( 5 ); }
									else if (sqlSelectedFields[counter].ToUpper() == "TOWN")
									{ Output += "\t" + GetOutputData ( 6 ); }
									else if (sqlSelectedFields[counter].ToUpper() == "COUNTY")
									{ O*utput += "\t" + GetOutputData ( 7 ); }
									else if (sqlSelectedFields[counter].ToUpper() == "POSTCODE")
									{ Output += "\t" + GetOutputData ( 8 ); }
									else if (sqlSelectedFields[counter].ToUpper() == "DOB")
									{ Output += "\t" + GetOutputData ( 9 ); }
									else if (sqlSelectedFields[counter].ToUpper() == "FILENAME")
									{ Output += "\t" + GetOutputData ( 10 ); }
									else if (sqlSelectedFields[counter].ToUpper() == "FULLFILENAME")
									{ Output += "\t" + GetOutputData ( 11); }
	*/
}
