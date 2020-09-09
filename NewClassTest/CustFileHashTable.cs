
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ClassAccessTest
{
	class CustomerFileHashTable
	{           //CustomerFileHashTable.CustFileNoHashTable
		public static string CustomerNumber { get; set; }
		public static string CustomerFileName { get; set; }

		readonly static string HashFileTableName = "C:\\Users\\ianch\\source\\C#SavedData\\Customers\\HashFilenameTable.hash";
		// so we can iterate thru quickly
		//    public static LinkedList<HashTableAccess> CustAccessList = new LinkedList<HashTableAccess>();    // Customer a/c + filename list
		//This is going to hold Customer AccountNumber as  it's "Key"  and the file name of its Customer as the Data item
		public static Hashtable CustFileNoHashTable = new Hashtable ( );

		// constructor
		//*******************************************************************************************************************************************
		public CustomerFileHashTable ( )
		//*******************************************************************************************************************************************
		{
		}
		public bool Current ( )
		{ throw new NotImplementedException ( ); }
		public bool MoveNext ( )
		{ throw new NotImplementedException ( ); }
		public bool Reset ( )
		{ throw new NotImplementedException ( ); }
		public IEnumerator GetEnumerator ( )
		{
			foreach ( object o in CustFileNoHashTable )
			{
				if ( o == null )
					break;
				yield return o;
			}
		}

		//*******************************************************************************************************************************************
		public static void AddNewHashFileCustNo (string CustNumber, string FName)
		//*******************************************************************************************************************************************
		{ CustFileNoHashTable.Add (CustNumber, FName); }
		//*******************************************************************************************************************************************
		public static void DelHashFileEntry (string CustNumber)
		//*******************************************************************************************************************************************
		{
			if ( CustFileNoHashTable.ContainsValue (CustNumber) )
			{ CustFileNoHashTable.Remove (CustNumber); }

		}
		//*******************************************************************************************************************************************
		public static bool FindHashFileEntry (string accno)
		//*******************************************************************************************************************************************
		{
			if ( CustFileNoHashTable.ContainsKey (accno) ) { return true; }
			else { return false; }
		}
		//*******************************************************************************************************************************************
		public static bool SaveHashFileTableToDisk ( )
		//*******************************************************************************************************************************************
		{
			try
			{
				FileStream fs = new FileStream (HashFileTableName, FileMode.Create);
				BinaryFormatter formatter = new BinaryFormatter ( );
				formatter.Serialize (fs, CustFileNoHashTable);
				fs.Close ( );
				return true;
			}
			catch { return false; }
		}
		//*******************************************************************************************************************************************
		public static void LoadCustHashFileTableFromDisk ( )
		//*******************************************************************************************************************************************
		{
			try
			{
				FileStream fs = new FileStream (HashFileTableName, FileMode.Open);
				BinaryFormatter formatter = new BinaryFormatter ( );
				CustFileNoHashTable = (Hashtable)formatter.Deserialize (fs);
				fs.Close ( ); // clean up
			}
			catch { }
		}
		public static bool ReBuildHashFileTable ( )
		{
			try
			{
				CustFileNoHashTable.Clear ( );
				foreach ( var B in BankAccount.BankAccountsLinkedList )
				{
					if ( !FindHashFileEntry (B.CustAccountNumber.ToString ( )) )
						AddNewHashFileCustNo (B.CustAccountNumber.ToString ( ), B.FileName);
				}
				return true;
			}
			catch
			{ return false; }
			//*******************************************************************************************************************************************
		}
	}
}
