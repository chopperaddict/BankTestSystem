using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClassAccessTest
{
	[Serializable]
#pragma warning disable CS1591 //  'DataArray'
	public class DataArray : IComparer<Int32>, IComparer<Int16>
#pragma warning restore CS1591 //  'DataArray'
	{
#pragma warning disable CS1591 //  'DataArray.CustNo'
		public static List<Customer> CustNo = new List<Customer>();
#pragma warning restore CS1591 //  'DataArray.CustNo'
#pragma warning disable CS1591 //  'DataArray.BankNo'
		public static List<BankAccount> BankNo = new List<BankAccount>();
#pragma warning restore CS1591 //  'DataArray.BankNo'
#pragma warning disable CS1591 //  'DataArray.Dataarray'
		public static ArrayList[,] Dataarray = new ArrayList[20, 20];
#pragma warning restore CS1591 //  'DataArray.Dataarray'
		// provide a publically accessible enumerator
#pragma warning disable CS1591 //  'DataArray.ListEnum'
		public static IEnumerator ListEnum = CustNo.GetEnumerator();
#pragma warning restore CS1591 //  'DataArray.ListEnum'
#pragma warning disable CS1591 //  'DataArray.AccountNo'
		public static List<int> AccountNo;
#pragma warning restore CS1591 //  'DataArray.AccountNo'
		// User accessable Objects via  static below
		// always use THIS to access the data & public static methods in this class
#pragma warning disable CS1591 //  'DataArray.DataArray()'
		public DataArray()
#pragma warning restore CS1591 //  'DataArray.DataArray()'
		{
		}
#pragma warning disable CS1591 //  'DataArray.DataArray(bool)'
		public DataArray( bool doit )
#pragma warning restore CS1591 //  'DataArray.DataArray(bool)'
		{
			if (doit)
			{
				CustNo.Clear();
				Customer.CustDict.Clear();
				BankNo.Clear();
				BankAccount.BankDict.Clear();
				Dataarray.Initialize();

			}
		}

#pragma warning disable CS1591 //  'DataArray.Compare(int, int)'
		public Int32 Compare( Int32 a, Int32 b )
#pragma warning restore CS1591 //  'DataArray.Compare(int, int)'
		{
			if (a > b)
				return 1;
			else return a < b ? -1 : 0;
		}
#pragma warning disable CS1591 //  'DataArray.Compare(short, short)'
		public Int32 Compare( Int16 a, Int16 b )
#pragma warning restore CS1591 //  'DataArray.Compare(short, short)'
		{
			bool v = a < b;
			if (a > b)
				return 1;
			else if (v)
				return -1;
			else
				return 0;
		}
		//=========================================================================//
		// EXTERNAL 
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayAddCust(Customer)'
		public static void ArrayAddCust( Customer C )
#pragma warning restore CS1591 //  'DataArray.ArrayAddCust(Customer)'
		{
			CustNo.Add( C );
			//            Bank.CustDictionary.Add(C.CustomerNumber, C);

		}
#pragma warning disable CS1591 //  'DataArray.ArrayAddBank(BankAccount)'
		public static void ArrayAddBank( BankAccount B )
#pragma warning restore CS1591 //  'DataArray.ArrayAddBank(BankAccount)'
		{
			BankNo.Add( B );
			//            BankAccount.BankDict.Add(B. BankAccountNumber, B);


		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayClearBank()'
		public static bool ArrayClearBank()
#pragma warning restore CS1591 //  'DataArray.ArrayClearBank()'
		//=========================================================================//
		{
			int count = 0;
			BankNo.Clear();
			if (BankAccount.BankDict != null)
				BankAccount.BankDict.Clear();

			foreach (BankAccount c in DataArray.BankNo)
			{
				BankNo.Remove( c ); count++;
				if (BankAccount.BankDict != null)
					BankAccount.BankDict.Remove( c.BankAccountNumber );
			}
			if (count > 0)
				return false;
			else
				return true;
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayClearCust()'
		public static bool ArrayClearCust()
#pragma warning restore CS1591 //  'DataArray.ArrayClearCust()'
		//=========================================================================//
		{
			int count = 0;
			CustNo.Clear();
			if (Customer.CustDict != null)
				Customer.CustDict.Clear();
			foreach (Customer c in CustNo)
			{
				CustNo.Remove( c ); count++;
				if (Customer.CustDict != null)
					Customer.CustDict.Remove( c.CustomerNumber );
			}
			if (count > 0)
				return false;
			else
				return true;
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayDeleteCust(Customer)'
		public static bool ArrayDeleteCust( Customer C )
#pragma warning restore CS1591 //  'DataArray.ArrayDeleteCust(Customer)'
		//=========================================================================//
		{
			bool result = false;
			if (C != null)
			{// find on BankAccount
				foreach (Customer c in CustNo)
				{
					if (c == null) continue;
					if (c == C)
					{
						CustNo.Remove( c );
						Customer.CustDict.Remove( c.CustomerNumber );
						result = true;
						break;
					}
				}
			}
			return result;
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayDeleteCust(int)'
		public static bool ArrayDeleteCust( int index )
#pragma warning restore CS1591 //  'DataArray.ArrayDeleteCust(int)'
		//=========================================================================//
		{
			try
			{
				CustNo.RemoveAt( index );
				Customer.CustDict.Remove( index );
				return true;
			}
			catch { return false; }
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayDeleteBank(int)'
		public static bool ArrayDeleteBank( Int32 bankNo )
#pragma warning restore CS1591 //  'DataArray.ArrayDeleteBank(int)'
		//=========================================================================//
		{
			bool result = false;
			if (bankNo < 0)
			{// find on BankAccount
				foreach (BankAccount c in BankNo)
				{
					if (c == null) continue;
					if (c.BankAccountNumber == bankNo)
					{
						BankNo.Remove( c );
						BankAccount.BankDict.Remove( c.BankAccountNumber );
						result = true;
						break;
					}
				}
			}
			return result;
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayDeleteBank(BankAccount)'
		public static bool ArrayDeleteBank( BankAccount B )
#pragma warning restore CS1591 //  'DataArray.ArrayDeleteBank(BankAccount)'
		//=========================================================================//
		{
			bool result = false;
			if (B == null)
			{// find on BankAccount
				foreach (BankAccount c in BankNo)
				{
					if (c == null) continue;
					if (c.BankAccountNumber == B.BankAccountNumber)
					{
						BankNo.Remove( c );
						BankAccount.BankDict.Remove( c.BankAccountNumber );
						result = true;
						break;
					}
				}
			}
			return result;
		}

		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayFindBank(BankAccount)'
		public static int ArrayFindBank( BankAccount B )
#pragma warning restore CS1591 //  'DataArray.ArrayFindBank(BankAccount)'
		//=========================================================================//
		{
			try
			{
				foreach (BankAccount b in BankNo)
				{
					if (B.BankAccountNumber == b.BankAccountNumber && B.CustAccountNumber == b.CustAccountNumber)
						return BankNo.LastIndexOf( b );
				}
				return -1;
			}
			catch
			{
				MessageBox.Show( "Unable to find Bank object for " + B.BankAccountNumber.ToString() + "in ArrayList BankNo", "System Arraylist problem" );
				return -1;
			}
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayFindBank(int)'
		public static int ArrayFindBank( Int32 BankNo )
#pragma warning restore CS1591 //  'DataArray.ArrayFindBank(int)'
		//=========================================================================//
		{
			try
			{
				foreach (BankAccount b in DataArray.BankNo)
				{
					if (b.BankAccountNumber == BankNo)
						return DataArray.BankNo.LastIndexOf( b );
				}
				return -1;
			}
			catch
			{
				MessageBox.Show( "Unable to find Bank object for " + BankNo.ToString() + "in ArrayList BankNo", "System Arraylist problem" );
				return -1;
			}
		}
		//=========================================================================//
		// EXTERNAL 
#pragma warning disable CS1591 //  'DataArray.ArrayFindCust(Customer)'
		public static int ArrayFindCust( Customer C )
#pragma warning restore CS1591 //  'DataArray.ArrayFindCust(Customer)'
		//=========================================================================//
		{
			// also Deletes the entry in out Sorted array
			try
			{
				foreach (Customer c in CustNo)
				{
					if (c.CustomerNumber == C.CustomerNumber && c.FileName == C.FileName)
						return CustNo.LastIndexOf( c );
				}
				return -1;
			}
			catch { return -1; }

		}
#pragma warning disable CS1591 //  'DataArray.ArrayFindCust(int)'
		public static int ArrayFindCust( Int32 Custno )
#pragma warning restore CS1591 //  'DataArray.ArrayFindCust(int)'
		//=========================================================================//
		{
			try
			{
				foreach (Customer c in CustNo)
				{
					if (c.CustomerNumber == Custno)
						return CustNo.LastIndexOf( c );
				}
				return -1;
			}
			catch { return -1; }

		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayGetBank(int)'
		public static BankAccount ArrayGetBank( Int32 CustNo )
#pragma warning restore CS1591 //  'DataArray.ArrayGetBank(int)'
		//=========================================================================//
		{
			try
			{
				foreach (BankAccount b in BankNo)
				{
					if (b.BankAccountNumber == CustNo)
						return b;
				}
				return null;
			}
			catch
			{
				MessageBox.Show( "Unable to find Bank object for " + BankNo.ToString() + "in ArrayList BankNo", "System Arraylist problem" );
				return null;
			}
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayGetCust(int)'
		public static Customer ArrayGetCust( Int32 BankNo )
#pragma warning restore CS1591 //  'DataArray.ArrayGetCust(int)'
		//=========================================================================//
		{
			try
			{
				foreach (BankAccount b in DataArray.BankNo)
				{
					if (b.CustAccountNumber == BankNo)
					{
						foreach (Customer c in CustNo)
						{
							if (c.CustomerNumber == b.CustAccountNumber)
								return c;
						}
					}
				}
				return null;
			}
			catch
			{
				MessageBox.Show( "Unable to find Bank object for " + BankNo.ToString() + "in ArrayGetCustFromBankNo()", "System Arraylist problem" );
				return null;
			}
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayGetBankFromCustno(int)'
		public static BankAccount ArrayGetBankFromCustno( Int32 BankNo )
#pragma warning restore CS1591 //  'DataArray.ArrayGetBankFromCustno(int)'
		//=========================================================================//
		{
			try
			{
				foreach (Customer c in CustNo)
				{
					if (c.accountnums[0] == BankNo)
					{
						foreach (BankAccount b in DataArray.BankNo)
						{
							if (b.BankAccountNumber == BankNo)
								return b;
						}

					}
				}
				return null;
			}
			catch
			{
				MessageBox.Show( "Unable to find Bank object for " + BankNo.ToString() + "in ArrayList BankNo", "System Arraylist problem" );
				return null;
			}
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayGetCustFromBankno(int)'
		public static Customer ArrayGetCustFromBankno( Int32 BankNo )
#pragma warning restore CS1591 //  'DataArray.ArrayGetCustFromBankno(int)'
		//=========================================================================//
		{
			try
			{
				foreach (BankAccount b in DataArray.BankNo)
				{
					if (b.BankAccountNumber == BankNo)
					{
						foreach (Customer c in CustNo)
						{
							if (c.CustomerNumber == b.CustAccountNumber)
								return c;
						}
					}
				}
				return null;
			}
			catch
			{
				MessageBox.Show( "Unable to find Bank object for " + BankNo.ToString() + "in ArrayGetCustFromBankNo()", "System Arraylist problem" );
				return null;
			}
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.ArrayUpdateBankBalance(int, decimal)'
		public static bool ArrayUpdateBankBalance( Int32 accno, decimal amount )
#pragma warning restore CS1591 //  'DataArray.ArrayUpdateBankBalance(int, decimal)'
		//=========================================================================//
		{
			bool result = false;
			foreach (BankAccount Bank in BankNo)
			{
				if (Bank.CustAccountNumber == accno)
				{ Bank.Balance += amount; result = true; }
			}
			return result;
		}
		//=========================================================================//
#pragma warning disable CS1591 //  'DataArray.RebuildBankArrayFromLinkedList()'
		public static int RebuildBankArrayFromLinkedList()
#pragma warning restore CS1591 //  'DataArray.RebuildBankArrayFromLinkedList()'
		//=========================================================================//
		{
			int count = 0;
			ArrayClearBank();
			foreach (BankAccount Bank in BankAccount.BankAccountsLinkedList)
			{
				if (Bank! != null)
				{ ArrayAddBank( Bank ); count++; }
			}
			return count;

		}
		//=========================================================================//
		//EXTERNAL  
#pragma warning disable CS1591 //  'DataArray.LoadArraysFromDisk(out int, out int)'
		public Int16 LoadArraysFromDisk( out int Bcount, out int Ccount )
#pragma warning restore CS1591 //  'DataArray.LoadArraysFromDisk(out int, out int)'
		//=========================================================================//
		{
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			// We iterate through all Bank .BNK files cos we can also read the relevant 
			// Customer #  from it, and then load that to the Customer array - Clever eh ?
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			Int16 count = 0;
			Bcount = 0;
			Ccount = 0;
			Int32[] custno = new int[100];
			int custcount = 0;
			bool duplicated = false;
			// start with BankAccounts
			string dir = BankAccount.ReadBankFilePath();
			string dir2 = Customer.GetCustFilePath();
			string[] bankfiles = System.IO.Directory.GetFiles( dir, "Bankobject*.bnk" );
			// initilaize our check array
			for (int i = 0; i < 100; i++)
				custno[i] = 0;
			// Iterate trhu them and handle as required			
			foreach (var fi in bankfiles)
			{
				bool result = fi.Contains( "BankObject" );
				if (result)
				{
					// Got a bank account object
					BankAccount B = SerializeData.ReadBankAccountFromDisk( fi );
					if (B != null)
					{
						ArrayAddBank( B );     // Add to bank ArrayList
						if (BankAccount.BankDict != null)
						{
							if (!BankAccount.BankDict.ContainsKey( B.BankAccountNumber ))
								BankAccount.BankDict.Add( B.BankAccountNumber, B );
						}
						Bcount++;
						BankAccount.BankAccountsLinkedList.AddLast( B );
						Customer C = SerializeData.ReadCustomerDiskObject( dir2 + "Custobj" + B.CustAccountNumber + ".cust" );
						if (C != null)
						{
							// add to our test array
							// check to see if it has been added before ?
							for (int i = 0; i < custcount; i++)
							{
								if (custno[i] == C.CustomerNumber)
								{
									duplicated = true;
									break;
								}
							}
							custno[custcount++] = C.CustomerNumber;
							if (!duplicated)
							{
								ArrayAddCust( C );     // The one and only Customer ArrayList addition in this Fn()
								if (Customer.CustDict != null)
								{
									if (!Customer.CustDict.ContainsKey( C.CustomerNumber ))
										Customer.CustDict.Add( C.CustomerNumber, C );
								}

								Ccount++;
								Customer.CustomersLinkedList.AddLast( C );
							}
							/*							// Handle multiple a/c's held by this customer
														if ( C . accountnums [ 1 ] != 0 )
														{
															BankAccount Bk = ( BankAccount ) SerializeData . ReadBankAccountFromDisk ( dir + "Bankobject" + C . accountnums [ 1 ] + ".bnk" );
															DataArray . ArrayAddBank ( Bk );// Add to bank ArrayList
															Bcount++;
															Bk . Dispose ( );
														}
														if ( C . accountnums [ 2 ] != 0 )
														{
															BankAccount Bk = ( BankAccount ) SerializeData . ReadBankAccountFromDisk ( dir + "Bankobject" + C . accountnums [ 2 ] + ".bnk" );
															DataArray . ArrayAddBank ( Bk );// Add to bank ArrayList
															Bcount++;
															Bk . Dispose ( );
														}
														if ( C . accountnums [ 3 ] != 0 )
														{
															BankAccount Bk = ( BankAccount ) SerializeData . ReadBankAccountFromDisk ( dir + "Bankobject" + C . accountnums [ 3 ] + ".bnk" );
															DataArray . ArrayAddBank ( Bk );// Add to bank ArrayList
															Bcount++;
															Bk . Dispose ( );
														}
							*/
							//                            if (C != null)
							//                             C.Dispose();
						}
						//                  if (B != null)
						//                   B.Dispose();
					}
					count++;
				}
			}
			// save our Customer LinkedList to disk as binary and txt files
			Lists.SaveAllCustomerListData( Customer.CustomerFilePath + "CustSortedListData.cust" );
			// sort the arrays in Ascending v0 - 9
			SortArray.SortBankArray( 0 );
			return count;
		}
	}
}
