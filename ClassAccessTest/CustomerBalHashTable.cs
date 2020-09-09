using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassAccessTest
{
	public class CustomerBalanceHashTable
	{
		public static string CustomerFileName { get; set; }
		public static string Balance { get; set; }

		//            private string terminator = "\n!";

		internal static Hashtable CustNoBalHashTable = new Hashtable ( );

		readonly static string HashFileTableName = "C:\\Users\\ianch\\source\\C#SavedData\\Customers\\HashBalanceTable.hash";

		// constructor
		public CustomerBalanceHashTable ( )
		{
			//ashtable CustHashTable = new Hashtable();
		}
		public bool Current ( )
		{
			throw new NotImplementedException ( );
		}
		public bool MoveNext ( )
		{
			throw new NotImplementedException ( );
		}
		public bool Reset ( )
		{
			throw new NotImplementedException ( );
		}

		public IEnumerator GetEnumerator ( )
		{
			foreach ( object o in CustNoBalHashTable )
			{
				if ( o == null )
					break;
				yield return o;
			}
		}

		//*******************************************************************************
		public static Hashtable GetCustNoBalHashTable ( )
		{
			return CustNoBalHashTable;
		}

		//*******************************************************************************
		public static void UpdateCustBalHashTable (string accno, decimal bal)
		{
			//Update the Customer HASH TABLE
			foreach ( var v in CustomerBalanceHashTable.CustNoBalHashTable )
			{
				if ( v.ToString ( ) == accno )
				{
					CustNoBalHashTable.Remove (accno as string);
					CustNoBalHashTable.Add (accno as string, bal);
					break;
				}
			}

		}
		//**********************************************************************************************************************************************
		// Rebuild both hash tables
		public static bool ReBuildHashBalTable ( )
		//**********************************************************************************************************************************************
		{
			//var hash = new Hashtable ( );
			//var orderedKeys = CustNoBalHashTable . Keys . Cast<string> ( ) . OrderBy ( c => c ); // supposing you're using string keys
			//			var allKvp = from x in orderedKeys select new { key = x, value = CustNoBalHashTable [ x ] };
			try
			{
				CustNoBalHashTable.Clear ( );
				foreach ( var B in BankAccount.BankAccountsLinkedList )
				{
					if ( !FindHashCustBalEntry (B.CustAccountNumber.ToString ( )) )
						AddHashCustBalEntry (B.CustAccountNumber.ToString ( ), B.Balance);
					//if ( !CustNoBalHashTable . Contains ( B . CustAccountNumber . ToString ( ) ) )
					//CustNoBalHashTable . Add ( B . CustAccountNumber . ToString ( ), B . FullFileName . ToString ( ) );
				}
				return true;
			}
			catch
			{
				//				throw new Exception ( "");
				return false;
			}
		}
		//**********************************************************************************************************************************************
		public static void AddHashCustBalEntry (string CustNumber, decimal Balance)
		//**********************************************************************************************************************************************
		{
			object value = FindHashCustBalEntry (CustNumber);
			if ( value != null )
			{
				DeleteHashCustBalEntry (CustNumber);
				CustNoBalHashTable.Add (CustNumber, Balance);
			}
			else
				CustNoBalHashTable.Add (CustNumber, Balance);
		}
		//**********************************************************************************************************************************************
		public static void DeleteHashCustBalEntry (string CustNumber)
		//**********************************************************************************************************************************************
		{
			object value = CustNoBalHashTable[CustNumber];
			if ( value != null )
				CustNoBalHashTable.Remove (CustNumber);
			//        if ( FindHashCustBalEntry ( CustNumber ) )
			//                CustNoBalHashTable. Remove ( CustNumber );  
		}
		//**********************************************************************************************************************************************
		public static bool FindHashCustBalEntry (string accno)
		//**********************************************************************************************************************************************
		{// a clever way of doing the old fashoned commented out code
			object value = CustNoBalHashTable[accno];
			if ( value != null )
				return true;
			else return false;
			//if (CustNoBalHashTable.ContainsKey(accno)) { return true; }
			//else { return false; }
		}
		//**********************************************************************************************************************************************
		public static void SaveHashCustBalTable ( )
		//**********************************************************************************************************************************************
		{
			try
			{
				FileStream fs = new FileStream (HashFileTableName, FileMode.Create);
				BinaryFormatter formatter = new BinaryFormatter ( );
				formatter.Serialize (fs, CustNoBalHashTable);
				fs.Close ( ); // clean up
				string[] txt = null;
				foreach ( var v in HashFileTableName )
					txt.Append (v.ToString ( ) + ",\t");
				string dir = BankAccount.ReadBankFilePath ( ) + "BankTransDataText.txt";
				File.AppendAllLines (dir, txt);
			}
			catch { }
		}
		//**********************************************************************************************************************************************
		public static void LoadHashCustBalTable ( )
		//**********************************************************************************************************************************************
		{
			try
			{
				FileStream fs = new FileStream (HashFileTableName, FileMode.Open);
				BinaryFormatter formatter = new BinaryFormatter ( );
				CustNoBalHashTable = (Hashtable)formatter.Deserialize (fs);
				fs.Close ( ); // clean up
			}
			catch { }
		}
	}
}