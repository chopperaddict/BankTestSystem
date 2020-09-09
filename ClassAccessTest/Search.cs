using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassAccessTest
{
	class Search
	{
		//*******************************************************************************************************************************************
		// we have 2 versions, accepting Int32 or string for accountnumber
		public static BankAccount FindBankObjectfromCustNo (string CustAccountNo)
		//*******************************************************************************************************************************************
		{   // now we can shuffle thru the hashtable itself to find the Object file to load - SuperFast
			foreach ( BankAccount v in BankAccount.BankAccountsLinkedList )
			{
				if ( v.CustAccountNumber == Convert.ToInt32 (CustAccountNo) )
				{
					// got it, so load it into memory
					Int32 BankAccountNumber = v.BankAccountNumber;
					string path = v.FullFileName.ToString ( );
					BankAccount B = SerializeData.ReadBankAccountFromDisk (path);
					return B;
				}
			}
			return null;
		}
		public static BankAccount FindBankObjectfromCustNo (Int32 CustAccountNo)
		//*******************************************************************************************************************************************
		{   // now we can shuffle thru the hashtable itself to find the Object file to load - SuperFast
			foreach ( BankAccount v in BankAccount.BankAccountsLinkedList )
			{
				if ( v.CustAccountNumber == CustAccountNo )
				{
					// got it, so load it into memory
					Int32 BankAccountNumber = v.BankAccountNumber;
					string path = v.FullFileName.ToString ( );
					BankAccount B = SerializeData.ReadBankAccountFromDisk (path);
					return B;
				}
			}
			return null;
		}
		//*******************************************************************************************************************************************
		public static BankAccount FindBankObjectfromBankNo (Int32 BankAccountNo)
		//*******************************************************************************************************************************************
		{   // now we can shuffle thru the ArrayList itself to find the Object file to load - SuperFast
			bool result = false;
			string path = "";
			foreach ( BankAccount v in DataArray.BankNo )
			{
				if ( Convert.ToInt32 (v.BankAccountNumber) == BankAccountNo )
				{
					// got it, so load it into memory
					path = v.FullFileName.ToString ( );
					result = true;
					break;
				}
			}
			if ( result )
			{
				try
				{
					BankAccount B = new BankAccount ( );
//					B = Utils.GetDataFromDiskFile(B, path);
					FileStream fs = new FileStream (path, FileMode.Open);
					// Get a BankAccount object for our data
					BinaryFormatter formatter = new BinaryFormatter ( );
					B = (BankAccount)formatter.Deserialize (fs);
					fs.Close ( );

					return B;
				}
				catch { return null; }
			}
			return null;
		}
		public static BankAccount FindBankObjectfromBankNo (string BankAccountNo)
		//*******************************************************************************************************************************************
		{   // now we can shuffle thru the hashtable itself to find the Object file to load - SuperFast
			bool result = false;
			string path = "";
			Int32 bankno = Convert.ToInt32 (BankAccountNo);
			foreach ( var v in BankAccount.BankAccountsLinkedList )
			{
				if ( Convert.ToInt32 (v.BankAccountNumber) == bankno )
				{
					// got it, so load it into memory
					path = v.FullFileName.ToString ( );
					result = true;
					break;
				}
			}
			if ( result )
			{
				try
				{
					BankAccount B = new BankAccount ( );
//					B = Utils.GetDataFromDiskFile(B, path);//{
					FileStream fs = new FileStream (path, FileMode.Open);
					// Get a BankAccount object for our data
					BinaryFormatter formatter = new BinaryFormatter ( );
					B = (BankAccount)formatter.Deserialize (fs);
					fs.Close ( );
					return B;
				}
				catch { }
			}
			return null;
		}
		//=========================================================================//
		public static Customer FindCustInSortedList (Int32 accno)
		//=========================================================================//
		{
			foreach ( Customer c in DataArray.CustNo )
			{
				if ( c != null )
				{
					if ( c.CustomerNumber == accno )
					{
						return c;
					}
				}
			}
			return null;
		}
	}
}
