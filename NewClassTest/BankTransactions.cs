using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using Microsoft.Graph;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
namespace ClassAccessTest
{
	[Serializable]
	//    [Enumerable]

	//**********************************************************//
	public class BankTransaction : IEnumerable
	//**********************************************************//
	{
		// This is our transaction record we are basing tis schema on
		//internal static int accountNumberSeed = 1050000;
		//*********************************************************//
		///BankTransaction newtransrecord = new BankTransaction(
		// Convert.ToDateTime(item[0]),    // Transaction Date
		// Convert.ToInt16(item[1]),           // Account Type
		// Convert.ToInt32(item[2]),          // Cust Account #
		// Convert.ToInt32(item[3]),          // Bank Account #
		// Convert.ToDecimal(item[3]),          // Transaction Amount
		// item[4]);           // Notes
		// Convert.ToInt16(item[5]);            // Status

		internal DateTime TransDate { get; set; }
		internal Int16 AccountType { get; set; }
		internal Int32 CustAccountNumber { get; set; }
		internal Int32 BankAccountNumber { get; set; }
		internal decimal Transamount { get; set; }
		internal string Notes { get; set; }
		internal Int16 Status { get; set; }

		public static LinkedList<BankTransaction>.Enumerator BankLListEnum;

		public static LinkedList<BankTransaction> allBankTransactions;

		public BankTransaction ( ) { }

		//*******************************************************************************************************************************************
		public BankTransaction (DateTime date, Int16 type, Int32 accountnumber, Int32 CustAcc, decimal amount, string note, Int16 status)
		//*******************************************************************************************************************************************
		{
			TransDate = date; // DateTime.Now;
			AccountType = type;
			CustAccountNumber = CustAcc;
			BankAccountNumber = accountnumber;
			Transamount = amount;
			Notes = note;
			Status = status;
		}
		public IEnumerator GetEnumerator ( )
		{
			foreach ( object o in allBankTransactions )
			{
				if ( o == null )
					break;
				yield return o;
			}
		}

		//*******************************************************************************************************************************************
		public static int BuildBankTransactionsFromTextfile ( )
		{
			//*******************************************************************************************************************************************
			string fi = BankAccount.ReadBankFilePath ( ) + "Textfiles\\BankTransData.txt";
			int count = 0;
			if ( File.Exists (fi) )
			{
				string input = File.ReadAllText (fi);       // you gotta delete them first, else it appends the data constantly
				char[] ch1 = { '\t' };
				char[] ch2 = { ',' };
				string[] record = input.Split (ch1);
				int x = 0;

				for ( int i = 0; i < record.Length - 1; i++ )
				{   // There is n empty record for some reason, hence Length - 1
					string str = record[i];
					string[] Item = str.Split (ch2);
					BankTransaction BT = new BankTransaction (
						Convert.ToDateTime (Item[x]),
						Convert.ToInt16 (Item[x + 1]),
						Convert.ToInt32 (Item[x + 2]),
						Convert.ToInt32 (Item[x + 3]),
						Convert.ToDecimal (Item[x + 4]),
						Item[x + 5],
						Convert.ToInt16 (Item[x + 6]));
					BankTransaction.allBankTransactions.AddLast ((BankTransaction)BT);
					count++;
				}
			}
			return count;
		}

		//**********************************************************************************************************//*
		// Calculate the Balance in the ACCOUNT from transactions
		//**********************************************************************************************************//
		public static decimal GetBankTransactionsBalance (int accountnumber)
		//**********************************************************************************************************//
		{
			decimal balance = 0;
			foreach ( var item in BankTransaction.allBankTransactions )
			{
				if ( item.CustAccountNumber == accountnumber )
				{
					balance += item.Transamount; ;
					break;
				}
			}
			return balance;
		}
		//*******************************************************************************************************************************************
		public static StringBuilder ReadAllBankTransactions ( )
		//*******************************************************************************************************************************************
		{   // read data from binary disk object
			StringBuilder SB = new StringBuilder ( );
			string fi = BankAccount.ReadBankFilePath ( ) + "BankTransData.bnk";
			if ( !File.Exists (fi) )
			{ // file  not found !!//
				MessageBox.Show ("Transactions File not found on disk\nNo Transactions History will be available !", "Transactions ERROR");
				return null;
			}
			try
			{
				SB = Utils.GetDataFromDiskFile(SB, fi);
/*				BinaryFormatter formatter = new BinaryFormatter ( );
				FileStream fs = new FileStream (fi, FileMode.Open);
				var v = formatter.Deserialize (fs).ToString ( );
				SB.Append (v);
				fs.Close ( );
*/
			}
			
			catch
			{ throw new Exception ("Failed to open file in ReadBankTransactions Function, line 158 in Serialize.cs"); }

			if ( SB.Length == 0 )
				return null;
			else
				return SB;
		}

		public static void ReadTransactionsFromTextfile ( )
		{
			string fi = BankAccount.ReadBankFilePath ( ) + "Textfiles\\BankTransData.txt";
			if ( File.Exists (fi) )
			{
				string input = File.ReadAllText (fi);       // you gotta delete them first, else it appends the data constantly
				string datain = fi;
				string[] item = datain.Split (',');
				int i = 0;
				while ( true )
				{
					try
					{
						DateTime d = Convert.ToDateTime (item[i]);    // Transaction Date
						Int16 b = Convert.ToInt16 (item[i + 1]);           // Account Type
						Int32 c = Convert.ToInt32 (item[i + 2]);          // Cust Account #
						Int32 f = Convert.ToInt32 (item[i + 3]);           // Bank Account #
						decimal e = Convert.ToDecimal (item[i + 4]);          // Transaction Amount
						string s = item[i + 5];    // Notes
						string temp = item[i + 6];
						char[] ch = { '\t' };
						string[] str = temp.Split (ch);

						Int16 a = Convert.ToInt16 (str[0]);
						//						a = Convert . ToInt16 ( actype );
						//						format of data proecessed is :-
						/*												   d,    // Transaction Date
                                                                           b,           // Account Type
                                                                           c,          // Cust Account #
                                                                           f,           // Bank Account #
                                                                           e,          // Transaction Amount
                                                                           s,                                        // Notes
                                                                           a );           // Status

                        //						allBankTransactions . AddLast ( newtransrecord );
                        */
						i += 7;
						if ( i + 1 >= item.Count ( ) )
							break;
					}
					catch
					{ throw new Exception ("Failed to handle data in ReadBankTransactions Function, line 163 in Serialize.cs"); }
				}
			}
		}
		//*******************************************************************************************************************************************
		public static int RebuildBankTransactions ( )
		//*******************************************************************************************************************************************
		{
			// use data from disk object
			StringBuilder SB = ReadAllBankTransactions ( ); // read data from binary disk objuect
			int count = 0;
			if ( SB == null )
				return 0;
			// parse bt out the various fields to a string array
			// ech record ends with '\n'
			string datain = SB.ToString ( );
			string[] item = datain.Split (',');
			int i = 0;
			string temp = "";
			while ( true )
			{
				try
				{
					if ( item[i].Contains ('\t') )
						temp = item[i].Substring (1);
					else
						temp = item[i];
					DateTime d = Convert.ToDateTime (temp);    // Transaction Date
					Int16 b = Convert.ToInt16 (item[i + 1]);           // Account Type
					Int32 c = Convert.ToInt32 (item[i + 2]);          // Cust Account #
					Int32 f = Convert.ToInt32 (item[i + 3]);           // Bank Account #
					decimal e = Convert.ToDecimal (item[i + 4]);          // Transaction Amount
					string s = item[i + 5];    // Notes
					Int16 a = Convert.ToInt16 (item[i + 6]);
					//					char [ ] ch = { '\t' };
					//					string [ ] str = temp . Split ( ch );

					//				Int16 a = Convert . ToInt16 ( str [ 0 ] );
					//					actype = item [ i + 7 ] . Substring ( 0, 1 );   // remove the \n from this field
					//					a = Convert . ToInt16 ( actype );
					BankTransaction newtransrecord = new BankTransaction (
											   d,    // Transaction Date
											   b,           // Account Type
											   c,          // Cust Account #
											   f,           // Bank Account #
											   e,          // Transaction Amount
											   s,                                        // Notes
											   a);           // Status

					allBankTransactions.AddLast (newtransrecord);
					count++;
					i += 7;
					if ( i + 1 >= item.Count ( ) )
						break;
				}
				catch
				{ new Exception ("Failed to handle data in ReadBankTransactions Function, line 163 in Serialize.cs"); }
			}
			return count;
		}
		//*******************************************************************************************************************************************
		public static bool RebuildSystemFromTransactionsText ( )
		{
			string fi = BankAccount.ReadBankFilePath ( ) + "Textfiles\\BankTransData.txt";
			int count = 0;
			if ( File.Exists (fi) )
			{
				string input = File.ReadAllText (fi);       // you gotta delete them first, else it appends the data constantly
				char[] ch1 = { '\t' };
				char[] ch2 = { ',' };
				string[] record = input.Split (ch1);
				int x = 0;

				for ( int i = 0; i < record.Length - 1; i++ )
				{   // There is n empty record for some reason, hence Length - 1
					string str = record[i];
					string[] Item = str.Split (ch2);
					BankTransaction BT = new BankTransaction (
						Convert.ToDateTime (Item[x]),
						Convert.ToInt16 (Item[x + 1]),
						Convert.ToInt32 (Item[x + 2]),
						Convert.ToInt32 (Item[x + 3]),
						Convert.ToDecimal (Item[x + 4]),
						Item[x + 5],
						Convert.ToInt16 (Item[x + 6]));
					// now do the clever stuff
					count++;
				}
				return false;
			}
			else
				return false;
		}
	}
}