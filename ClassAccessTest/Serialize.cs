using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Microsoft.Graph;
using Directory = System.IO.Directory;
using File = System.IO.File;

namespace ClassAccessTest
{

	class SerializeData
	{

		//*****************************************************************************************************************************************************//
		//                                                Serialization PRIMITIVES
		//*****************************************************************************************************************************************************//
		public static void SBSerialize (StringBuilder StringData, string OutputFile)
		//******************************************************************************************************************************************************//
		{   // Creates (serializes) a StringBuilder object
			try
			{
				FileStream fs = new FileStream (OutputFile, FileMode.Create);
				BinaryFormatter formatter = new BinaryFormatter ( );
				formatter.Serialize (fs, StringData);
				fs.Close ( );
			}
			catch
			{
				throw new Exception ("Failed to handle file in SBSerialize Function, line 24 in Serialize.cs");
			}

		}

		//*******************************************************************************************************************************************
		public static void Serialize (String StringData, string OutputFile)
		//*******************************************************************************************************************************************
		{       // Creates (serializes) a <string> object
			try
			{
				FileStream fs = new FileStream (OutputFile, FileMode.Create);
				// Construct a BinaryFormatter and use it to serialize the data to the stream.
				BinaryFormatter formatter = new BinaryFormatter ( );
				formatter.Serialize (fs, StringData);
				fs.Close ( );
			}
			catch { throw new Exception ("Failed to handle file in Serialize Function, line 34 in Serialize.cs"); }
		}

		public static void SaveBankDictionaryToDisk ( )
		{
			try
			{
				string FileName = BankAccount.ReadBankFilePath ( ) + "BankDictionary.dict";
				FileStream fs = new FileStream (FileName, FileMode.Create);
				BinaryFormatter formatter = new BinaryFormatter ( );
				formatter.Serialize (fs, BankAccount.BankDict);
				fs.Close ( ); // clean up
			}
			catch
			{
				throw new Exception ("Failed to handle file in SaveDictionaryToDisk Function, line 60 in Serialize.cs");
			}
		}
		public static void SaveCustDictionaryToDisk ( )
		{
			try
			{
				string FileName = Customer.GetCustFilePath ( ) + "CustomerDictionary.dict";
				FileStream fs = new FileStream (FileName, FileMode.Create);
				BinaryFormatter formatter = new BinaryFormatter ( );
				formatter.Serialize (fs, Customer.CustDict);
				fs.Close ( ); // clean up
			}
			catch
			{
				throw new Exception ("Failed to handle file in SaveDictionaryToDisk Function, line 60 in Serialize.cs");
			}
		}

		public static bool ReadBankDictionaryFromDisk()
		{
			string FileName = BankAccount.ReadBankFilePath ( ) + "BankDictionary.dict";
			if ( !File.Exists (FileName) )
				return false;
			// Get a Bank Dictionary object for our data
			BinaryFormatter formatter = new BinaryFormatter ( );
			FileStream fs = new FileStream (FileName, FileMode.Open);
			BankAccount.BankDict = (Dictionary<Int32, BankAccount>)formatter.Deserialize (fs);
			fs.Close ( );
			return true;
		}
		public static bool ReadCustomerDictionaryFromDisk ( )
		{
			try
			{
				string FileName = Customer.GetCustFilePath ( ) + "CustomerDictionary.dict";
				if ( !File.Exists (FileName) )
					return false;
				BinaryFormatter formatter = new BinaryFormatter ( );
				FileStream fs = new FileStream (FileName, FileMode.Open);
				Customer.CustDict = (Dictionary<Int32, Customer>)formatter.Deserialize (fs);
				fs.Close ( );
				return true;
			}
			catch
			{
				
				throw new Exception ("Failed to handle file in readDictionaryFromDisk Function, line 96 in Serialize.cs");
			}

		}

		//*******************************************************************************************************************************************
		public static BankAccount ReadBankAccountFromDisk (string FileName)
		//*******************************************************************************************************************************************
		{
			// Deserialize the object from the file and
			// return the BankAccount object
			try
			{
				BankAccount C = new BankAccount ( );
//				Utils.GetDataFromDiskFile(C,  FileName);//{
				FileStream fs = new FileStream (FileName, FileMode.Open);
				// Get a BankAccount object for our data
				BinaryFormatter formatter = new BinaryFormatter ( );
				C = (BankAccount)formatter.Deserialize (fs);
				fs.Close ( );
				return C;
			}
			catch
			{
				throw new Exception ("Failed to handle file in ReturnBankAccountObject Function, line 110 in Serialize.cs");
			}
		}

		//Saves a BankAccount object to disk file & Text file
		//*******************************************************************************************************************************************
		public static void WriteBankAccountToDiskAndText (BankAccount account, string FileName)
		//*******************************************************************************************************************************************
		{
			// Open the file and write the Bank object data that you want to serialize to a disk file
			// PLUS it saves a copy  as a Text file in \\Textfiles folder with same root name + ".txt"
			try
			{
				FileStream fs = new FileStream (FileName, FileMode.Create);
				BinaryFormatter formatter = new BinaryFormatter ( );
				formatter.Serialize (fs, account);
				fs.Close ( ); // clean up
				/*
				 * Now write it out as a named text file in the \\Textfiles folder
				 * */
				string s = account.BankAccountNumber + "," + account.CustAccountNumber + "," + account.AccountType + "," + account.Balance + "," + account.DateOpened.ToShortDateString ( )
								+ "," + account.DateClosed.ToShortDateString ( ) + "," + account.InterestRate + "," + account.Status + "\r\n";
				// This writes the Bank Account object as a std string [record] out in text format in \\textfiles folder
				string newfname = FileName.Substring (FileName.Length - 21);
				string path = BankAccount.ReadBankFilePath ( ) + "Textfiles\\" + newfname.Substring (0, newfname.Length - 4) + ".txt";
				if ( File.Exists (path) )
					File.Delete (path);      // you gotta delete them first, else it appends the data constantly
				File.AppendAllText (path, s);
			}
			catch { throw new Exception ("Failed to handle file in WriteBankAccount Function, line 98 in Serialize.cs"); }
		}

		//*******************************************************************************************************************************************
		// Read a Customer Object from Disk
		// & return a Customer Object containing that data
		public static Customer ReadCustomerDiskObject (string FileName)
		//*******************************************************************************************************************************************
		{
			// Deserialize the object from the file and
			// assign the reference to the local variable.
			// Open the file containing the data that you want to deserialize.
			try
			{
				if ( File.Exists (FileName) )
				{
					FileStream fs = new FileStream (FileName, FileMode.Open);
					// Get a BankAccount object for our data
					Customer C = new Customer ( );
					BinaryFormatter formatter = new BinaryFormatter ( );
					C = (Customer)formatter.Deserialize (fs);
					fs.Close ( );
					return C;
				}
				else
					return null;
			}
			catch ( SerializationException e )
			{
				throw new Exception ("Failed to Read data from file in ReadCustomerObject Function, line 229 in Serialize.cs" + e.Message);
			}
		}


		/*		//*******************************************************************************************************************************************
                public static StringBuilder ReturnCustDataAsStringbuilder ( string FileName )
                //*******************************************************************************************************************************************
                {
                    // Reads a file from disk and returns its data in a StringBuilder object
                    StringBuilder StringData = new StringBuilder ( );
                    if ( !File . Exists ( FileName ) ) // file  not found !!
                        return StringData;  // return an empty ~StringBuilder object

                    // Open the file containing the data that you want to deserialize.
                    FileStream fs = new FileStream ( FileName, FileMode . Open );
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter ( );
                        // Deserialize the object file and
                        // assign the data to a <StringBuilder> object
                        var v = formatter . Deserialize ( fs ) . ToString ( );
                        StringData . Append ( v );
                        fs . Close ( );
                    }
                    catch ( SerializationException e )
                    {
                        fs . Close ( );
                        StringData . Append ( "Error - Exception encountered - Unable to read file " + FileName );
                    }
                    return StringData;
                }

        */
		//*******************************************************************************************************************************************
		public static void WriteBankTransactionsToDisk ( )
		//*******************************************************************************************************************************************
		{
			string record = "";
			// Sanity check = maybe we have not done any work in the app yet ?
			// so we do not have LinkedList, Transactions etc avaialbel yet.
			if ( BankTransaction.allBankTransactions != null )
			{
				foreach ( var bt in BankTransaction.allBankTransactions )
				{   // this gives us an array in bt[];
					// parse bt out to fields & build   the data string I want to use - my design

					if ( bt != null )
					{
						//string strout = string.Format("{0:2C}", BT.Transamount);
						string CurrencyAmount = Utils.GetCurrencyString (bt.Transamount.ToString ( ));
						record += bt.TransDate + "," + bt.AccountType + "," + bt.CustAccountNumber + "," + bt.BankAccountNumber
									+ "," + bt.Transamount.ToString ( ) + "," + bt.Notes + "," + bt.Status + ",\t";
					}
				}
				try
				{
					string fi = BankAccount.ReadBankFilePath ( ) + "BankTransData.bnk";
					BinaryFormatter formatter = new BinaryFormatter ( );
					FileStream fs = new FileStream (fi, FileMode.Create);
					formatter.Serialize (fs, record);
					fs.Close ( );
					// This writes the std string [record] out in text format in \\textfiles folder
					fi = BankAccount.ReadBankFilePath ( ) + "Textfiles\\BankTransData.txt";
					if ( File.Exists (fi) )
						File.Delete (fi);      // you gotta delete them first, else it appends the data constantly
					File.AppendAllText (fi, record);
				}
				catch
				{
					throw new Exception ("Failed to handle file in WriteBankTransactions Function, line 138 in Serialize.cs");
				}
			}
		}
		//*******************************************************************************************************************************************
		// Read a Customer Object from Disk
		// & return a Customer Object containing that data
		public static StringBuilder ReadBankFromDiskAsStringBuilder (string FileNumber)
		//*******************************************************************************************************************************************
		{
			// Open the file containing the txt data that you want to deserialize.
			string FileName = BankAccount.ReadBankFilePath ( ) + "Textfiles\\bankobject" + FileNumber + ".txt";
			try
			{
				StringBuilder StringData = new StringBuilder ( );
				StringData.Append (File.ReadAllText (FileName));
				return StringData;
			}
			catch
			{ throw new Exception ("Failed to Read data from file in ReadBankFromDisk Function, line 224 in Serialize.cs"); }
		}
	}
}
