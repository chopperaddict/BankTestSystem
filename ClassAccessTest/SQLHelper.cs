
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ClassAccessTest
{
	public class SQLHelper
	{
		public static bool SQLconnection = false;
		static SqlCommand command;
		static SqlDataReader dataReader;
		public static event EventHandler<string> SQLDataChangedEvent;

		// Note the changed location for the database
		public static SqlConnection cnn;
		//**************************************************************************************************************************************************************************************
		public static string ConnectionString = @"Data Source = DINO-PC\SQLEXPRESS; Initial Catalog = ian1; Integrated Security = True";
		//**************************************************************************************************************************************************************************************
		public static string CnnVal (string name)
		{ return ConfigurationManager.ConnectionStrings[name].ConnectionString; }
		//**************************************************************************************************************************************************************************************
		public static bool SQLConnect ( )
		//**************************************************************************************************************************************************************************************
		{
			cnn = new SqlConnection (ConnectionString);
			try
			{
				cnn.Open ( );
				SQLAccess.SQLconnection = true;
				string login = cnn.ConnectionString;
				// Subscribe to our delegate - in sqlconnector.cs
				//				SQLDataChangedEvent += sqlconnector_SQLDataChangedEvent;
				return true;
			}
			catch
			{
				Bank.form1.Output2.AppendText ("SQL connection encountered a problem\r\n");
				return false;
			}
		}

		public static void SQLDisConnect ( )
		//***********************************************************************************************************************************
		{
			try
			{
				cnn.Close ( );
				SQLAccess.SQLconnection = false;
			}
			catch { new Exception (" Failed to disconnect from SQL Server"); }
		}
		// called to load Customer data
		public static string ReadSQLLine (string enquiry, out int count)
		//***********************************************************************************************************************************
		{
			string sql, Output = "";
			int cnt = 0;
			if ( SQLAccess.SQLconnection )
			{
				bool experiment = false;
				bool experiment2 = false;
				bool experiment3 = false;       //This loads the Datagrid on sqlconnector.cs
				bool experiment4 = false;
				bool experiment5 = true;
				string custno = "", fname = "", lname = "", phone = "", mobile = "", addr1 = "", addr2 = "", town = "", county = "", pcode = "", dob = "", filename = "", fullfname = "", secaccts = "";
				sql = enquiry;
				{
					if ( experiment )
					{
						// Initdata()
						DataSet dsCustomer = new DataSet ( );
						SqlDataAdapter daCustomers = new SqlDataAdapter (command);
						SqlCommandBuilder cmdBuilder = new SqlCommandBuilder (daCustomers);
						DataGrid dgCustomers;       // ???
						if ( dataReader != null ) dataReader.Close ( );
						daCustomers.Fill (dsCustomer, "Customers");
						dgCustomers = new DataGrid ( );

					}
					else if ( experiment2 )
					{
						SqlConnection nwindConn = new SqlConnection (ConnectionString);
						SqlCommand selectCMD = new SqlCommand (enquiry, nwindConn);
						selectCMD.CommandTimeout = 30;
						SqlDataAdapter customerDA = new SqlDataAdapter ( );
						customerDA.SelectCommand = selectCMD;
						nwindConn.Open ( );
						DataSet customerDS = new DataSet ( );
						customerDA.Fill (customerDS, "Customers");
						nwindConn.Close ( );
						//						sqlconnector.data.AppendText (customerDA.);

					}
					else if ( experiment3 )
					{
						// processing the data
						command = new SqlCommand (sql, cnn);
						if ( dataReader != null ) dataReader.Close ( );
						DataTable dt = new DataTable ( );
						SqlDataAdapter daCustomers = new SqlDataAdapter (command);
						dataReader = command.ExecuteReader ( );
						// now loaddarta into our data table
						dt.Load (dataReader);
						//load our datagrid on sqlconnector Form??
						//						sqlconnector.LoadDataGrid (dt);
					}
					else if ( experiment4 )
					{
						command = new SqlCommand (sql, cnn);
						//						if ( dataReader != null ) dataReader.Close ( );
						//						DataTable dt = new DataTable ( );
						//						SqlDataAdapter daCustomers = new SqlDataAdapter (command);
						dataReader = command.ExecuteReader ( );

						try
						{
							// This is REALLY SLOW....... Even when not updating textbox on the fly
							// Gets slower as time goes by...
							// unusable really.
							while ( dataReader.Read ( ) )
							{
								custno = dataReader["CustomerNo"].ToString ( );
								fname = dataReader["FirstName"].ToString ( );
								lname = dataReader["LastName"].ToString ( );
								phone = dataReader["PhoneNumber"].ToString ( );
								mobile = dataReader["MobileNumber"].ToString ( );
								addr1 = dataReader["Address1"].ToString ( );
								addr2 = dataReader["Address2"].ToString ( );
								town = dataReader["Town"].ToString ( );
								county = dataReader["County"].ToString ( );
								pcode = dataReader["PostCode"].ToString ( );
								dob = dataReader["DOB"].ToString ( );
								filename = dataReader["FileName"].ToString ( );
								fullfname = dataReader["FullFileName"].ToString ( );
								secaccts = dataReader["SecAccounts"].ToString ( );

								if ( sql.Contains ("Select") && sql.Contains ("Customer") )
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
								SQLDataChangedEvent?.Invoke (Output, "SQLDATA");
								cnt++;
							}
						}
						catch
						{
						}
					}   // end of while there is data											
					else if ( experiment5 )
					{
						SqlConnection connection = new SqlConnection (ConnectionString);
						connection.Open ( );
						command = new SqlCommand (sql, connection);
						SqlDataAdapter adapter = new SqlDataAdapter (command);
						DataSet ds = new DataSet ( );
						DataView dv = new DataView ( );
						adapter.SelectCommand = command;
						adapter.Fill (ds, "Create DataView");
						adapter.Dispose ( );
						command.Dispose ( );
						connection.Close ( );

						Output = "Field names for selected Db...\r\n";
						dv = ds.Tables[0].DefaultView;
						ds.Dispose ( );
						int rowcount = dv.Table.Rows.Count;
						Output += "Db contains " + rowcount.ToString ( ) + "\r\n";
						int colcount = dv.Table.Columns.Count;
						string[] colnames = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", };
						// declare it bigger than required....
						DataColumn[] dca = { (DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null,
											(DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null,
											(DataColumn)null, (DataColumn)null, (DataColumn)null, (DataColumn)null, };
						dv.Table.Columns.CopyTo (dca, 0); ;
						dv.Dispose ( );
						Output = "Field names for selected Db...\r\n";
						foreach ( var item in dca )
						{
							if ( item != null )
								Output += item.Caption + "\r\n";
						}
					}
				}
			}
			count = cnt;
			return Output;
		}

		public static string ReadSQLdata(string enquiry, List<string> fldnames, List<int> fldtypes, string requiredDb, out int count)
			//***********************************************************************************************************************************
		{
			string sql, Output = "";
			int cnt = 0;
			count = 0;
			if ( SQLAccess.SQLconnection )
			{
				bool experiment = false;
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
				if ( experiment == false )
				{
					// Called from sqlconnector for Customer, BankAccount or Secondary Db's.
					command = new SqlCommand(sql, cnn);
					dataReader = command.ExecuteReader();
					int fldcount = dataReader.FieldCount;
					int counter = 0;
					/*
								 [Id] INT NOT NULL IDENTITY, 
								[CustomerNo]   NCHAR(20) NOT NULL,
								[FirstName]    NVARCHAR(200) NOT NULL,
								[LastName]     NVARCHAR(200) NOT NULL,
								[Address1]     NVARCHAR(200) NOT NULL,
								[Address2]     NVARCHAR(200) NULL,
								[Town]         NVARCHAR(200) NOT NULL,
								[County]       NVARCHAR(200) NOT NULL,
								[Postcode]     NVARCHAR(50) NOT NULL,
								[DOB] DATE NOT NULL DEFAULT getdate(), 
								[FileName]     NVARCHAR(200) NOT NULL,
								[FullFileName] NVARCHAR(200) NOT NULL,
					  */

					if ( fldnames[0].ToUpper() == "CUSTOMER" )
					{ // we areprocessing Customer DB
						while ( dataReader.Read() )
						{
							if ( fldnames[counter].ToUpper() == "CUSTOMERNO" )
								if ( fldnames[counter].ToUpper() == "CUSTOMERNO" )
									Output += dataReader.GetValue(0)
							+"\t" + dataReader.GetValue(1) + "\t" + dataReader.GetValue(2) + "\t\t" +
								dataReader.GetValue(3) + "\r\n";
							cnt++;
						}
					}
					else if ( fldnames[0].ToUpper() == "BANKACCOUNT" ) { }
					else if ( fldnames[0].ToUpper() == "SECONDARY" )
					{

					}

					command = new SqlCommand(sql, cnn);
					dataReader = command.ExecuteReader();
					fldcount = dataReader.FieldCount;
					while ( dataReader.Read() )
					{
						custno = dataReader["CustomerNo"].ToString();
						fname = dataReader["FirstName"].ToString();
						lname = dataReader["LastName"].ToString();
						phone = dataReader["PhoneNumber"].ToString();
						mobile = dataReader["MobileNumber"].ToString();
						addr1 = dataReader["Address1"].ToString();
						addr2 = dataReader["Address2"].ToString();
						town = dataReader["Town"].ToString();
						county = dataReader["County"].ToString();
						pcode = dataReader["PostCode"].ToString();
						dob = dataReader["DOB"].ToString();
						filename = dataReader["FileName"].ToString();
						fullfname = dataReader["FullFileName"].ToString();
						secaccts = dataReader["SecAccounts"].ToString();

						if ( sql.Contains("Select") && sql.Contains("Customer") )
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

						SQLDataChangedEvent?.Invoke(Output, "SQLDATA");

					}
				}

				dataReader.Close();
				count = cnt;
				return Output;
			}

			return "";
		}

		public static bool WriteSQLdata (string sql)
		//***********************************************************************************************************************************
			{
				SqlDataAdapter adapter = new SqlDataAdapter ( );
				if ( SQLAccess.SQLconnection )
				{
					command = new SqlCommand (sql, cnn);
					adapter.InsertCommand = new SqlCommand (sql, cnn);
					adapter.InsertCommand.ExecuteNonQuery ( );
					command.Dispose ( );
					return true;
				}
				else return false;
			}
		}
	}

