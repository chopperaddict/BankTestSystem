using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Amazon.Runtime.Internal.Transform;

namespace ClassAccessTest
{
    [Serializable]
    public class DataArray : IComparer<Int32>, IComparer<Int16>
	{
        public static List<Customer> CustNo = new List<Customer>();
        public static List<BankAccount> BankNo = new List<BankAccount>();
        public static ArrayList[,] Dataarray = new ArrayList[20, 20];
		// provide a publically accessible enumerator
		public static IEnumerator ListEnum = CustNo.GetEnumerator();
        public static List<Int32> AccountNo;
        // User accessable Objects via  static below
        // always use THIS to access the data & public static methods in this class
        public DataArray()
        {
        }
        public DataArray(bool doit)
        {
            if (doit)
            {
                DataArray.CustNo.Clear();
                Customer.CustDict.Clear ( );
                DataArray.BankNo.Clear();
                BankAccount.BankDict.Clear ( );
				Dataarray.Initialize();

            }
        }

		public Int32 Compare(Int32 a, Int32 b)
        {
			if ( a > b )
				return 1;
            else if ( a < b )
				return -1;
					else
				return 0;
        }
        public Int32 Compare(Int16 a, Int16 b)
        {
			if ( a > b )
				return 1;
			else if ( a < b )
				return -1;
			else
				return 0;
		}
		//=========================================================================//
		// EXTERNAL 
		//=========================================================================//
		public static void ArrayAddCust(Customer C)
        {
            DataArray.CustNo.Add(C);
//            Bank.CustDictionary.Add(C.CustomerNumber, C);

        }
        public static void ArrayAddBank(BankAccount B)
        {
            DataArray.BankNo.Add(B);
//            BankAccount.BankDict.Add(B. BankAccountNumber, B);


		}
		//=========================================================================//
		public static bool ArrayClearBank()
        //=========================================================================//
        {
            int count = 0;
            DataArray.BankNo.Clear();
			if (BankAccount.BankDict != null)
				BankAccount.BankDict.Clear ();

			foreach ( BankAccount c in DataArray.BankNo)
            {
                DataArray.BankNo.Remove(c); count++;
                if (BankAccount.BankDict != null)
					BankAccount.BankDict.Remove (c.BankAccountNumber);
            }
			if (count > 0)
                return false;
            else
                return true;
        }
        //=========================================================================//
        public static bool ArrayClearCust()
        //=========================================================================//
        {
            int count = 0;
            DataArray.CustNo.Clear();
			if(Customer.CustDict != null)
				Customer.CustDict.Clear ( );
            foreach ( Customer c in DataArray.CustNo)
            {
                DataArray.CustNo.Remove(c); count++;
                if (Customer.CustDict != null)
					Customer.CustDict.Remove(c.CustomerNumber);
            }
			if (count > 0)
                return false;
            else
                return true;
        }
        //=========================================================================//
        public static bool ArrayDeleteCust(Customer C)
        //=========================================================================//
        {
            bool result = false;
            if (C != null)
            {// find on BankAccount
                foreach (Customer c in DataArray.CustNo)
                {
                    if (c == null) continue;
                    if (c == C)
                    {
                        DataArray.CustNo.Remove(c);
                        Customer.CustDict.Remove (c.CustomerNumber);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        //=========================================================================//
        public static bool ArrayDeleteCust(int index)
        //=========================================================================//
        {
            try
            {
                CustNo.RemoveAt(index);
                Customer.CustDict.Remove (index);
                return true;
            }
            catch { return false; }
        }
        //=========================================================================//
        public static bool ArrayDeleteBank(Int32 bankNo)
        //=========================================================================//
        {
            bool result = false;
            if (bankNo < 0)
            {// find on BankAccount
                foreach (BankAccount c in DataArray.BankNo)
                {
                    if (c == null) continue;
                    if (c.BankAccountNumber == bankNo)
                    {
                        DataArray.BankNo.Remove(c);
                        BankAccount.BankDict.Remove (c.BankAccountNumber);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        //=========================================================================//
        public static bool ArrayDeleteBank(BankAccount B)
        //=========================================================================//
        {
            bool result = false;
            if (B == null)
            {// find on BankAccount
                foreach (BankAccount c in DataArray.BankNo)
                {
                    if (c== null) continue;
                    if (c.BankAccountNumber == B.BankAccountNumber )
                    {
                        DataArray.BankNo.Remove(c);
                        BankAccount.BankDict.Remove (c.BankAccountNumber);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        //=========================================================================//
        public static int ArrayFindBank(BankAccount B)
        //=========================================================================//
        {
            try
            {
                foreach (BankAccount b in DataArray.BankNo)
                {
                    if (B.BankAccountNumber == b.BankAccountNumber && B.CustAccountNumber == b.CustAccountNumber)
                        return DataArray.BankNo.LastIndexOf(b);
                }
                return -1;
            }
            catch
            {
                MessageBox.Show("Unable to find Bank object for " + B.BankAccountNumber.ToString() + "in ArrayList BankNo", "System Arraylist problem");
                return -1;
            }
        }
        //=========================================================================//
        public static int ArrayFindBank(Int32 BankNo)
        //=========================================================================//
        {
            try
            {
                foreach (BankAccount b in DataArray.BankNo)
                {
                    if (b.BankAccountNumber == BankNo)
                        return DataArray.BankNo.LastIndexOf(b);
                }
                return -1;
            }
            catch
            {
                MessageBox.Show("Unable to find Bank object for " + BankNo.ToString() + "in ArrayList BankNo", "System Arraylist problem");
                return -1;
            }
        }
        //=========================================================================//
        // EXTERNAL 
        public static int ArrayFindCust(Customer C)
        //=========================================================================//
        {
            // also Deletes the entry in out Sorted array
            try
            {
                foreach (Customer c in DataArray.CustNo)
                {
                    if (c.CustomerNumber == C.CustomerNumber && c.FileName == C.FileName)
                        return DataArray.CustNo.LastIndexOf(c);
                }
                return -1;
            }
            catch { return -1; }

        }
        public static int ArrayFindCust(Int32 Custno)
        //=========================================================================//
        {
            try
            {
                foreach (Customer c in DataArray.CustNo)
                {
                    if (c.CustomerNumber == Custno)
                        return DataArray.CustNo.LastIndexOf(c);
                }
                return -1;
            }
            catch { return -1; }

        }
        //=========================================================================//
        public static BankAccount ArrayGetBank(Int32 CustNo)
        //=========================================================================//
        {
            try
            {
                foreach (BankAccount b in DataArray.BankNo)
                {
                    if (b.BankAccountNumber == CustNo)
                        return b;
                }
                return null;
            }
            catch
            {
                MessageBox.Show("Unable to find Bank object for " + BankNo.ToString() + "in ArrayList BankNo", "System Arraylist problem");
                return null;
            }
        }
        //=========================================================================//
        public static Customer ArrayGetCust(Int32 BankNo)
        //=========================================================================//
        {
            try
            {
                foreach (BankAccount b in DataArray.BankNo)
                {
                    if (b.CustAccountNumber == BankNo)
                    {
                        foreach (Customer c in DataArray.CustNo)
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
                MessageBox.Show("Unable to find Bank object for " + BankNo.ToString() + "in ArrayGetCustFromBankNo()", "System Arraylist problem");
                return null;
            }
        }
        //=========================================================================//
        public static BankAccount ArrayGetBankFromCustno(Int32 BankNo)
        //=========================================================================//
        {
            try
            {
                foreach (Customer c in DataArray.CustNo)
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
                MessageBox.Show("Unable to find Bank object for " + BankNo.ToString() + "in ArrayList BankNo", "System Arraylist problem");
                return null;
            }
        }
        //=========================================================================//
        public static Customer ArrayGetCustFromBankno(Int32 BankNo)
        //=========================================================================//
        {
            try
            {
                foreach (BankAccount b in DataArray.BankNo)
                {
                    if (b.BankAccountNumber == BankNo)
                    {
                        foreach (Customer c in DataArray.CustNo)
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
                MessageBox.Show("Unable to find Bank object for " + BankNo.ToString() + "in ArrayGetCustFromBankNo()", "System Arraylist problem");
                return null;
            }
        }
        //=========================================================================//
        public static bool ArrayUpdateBankBalance(Int32 accno, decimal amount)
        //=========================================================================//
        {
            bool result = false;
            foreach (BankAccount Bank in DataArray.BankNo)
            {
                if (Bank.CustAccountNumber == accno)
                { Bank.Balance += amount; result = true; }
            }
            return result;
        }
        //=========================================================================//
        public static int RebuildBankArrayFromLinkedList ( )
	        //=========================================================================//
        {
	        int count = 0;
	        DataArray.ArrayClearBank ( );
	        foreach (BankAccount Bank in BankAccount.BankAccountsLinkedList)
	        {
		        if (Bank! != null)
		        { DataArray.ArrayAddBank ( Bank ); count++; }
	        }
	        return count;

        }
        //=========================================================================//
		//EXTERNAL  
		public Int16 LoadArraysFromDisk(out int Bcount, out int Ccount)
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
            string[] bankfiles = System.IO.Directory.GetFiles(dir, "Bankobject*.bnk");
            // initilaize our check array
            for (int i = 0; i < 100; i++)
                custno[i] = 0;
            // Iterate trhu them and handle as required			
            foreach (var fi in bankfiles)
            {
                bool result = fi.Contains("BankObject");
                if (result)
                {
                    // Got a bank account object
                    BankAccount B = (BankAccount)SerializeData.ReadBankAccountFromDisk(fi);
                    if (B != null)
                    {
                        DataArray.ArrayAddBank(B);     // Add to bank ArrayList
                        if (BankAccount.BankDict != null)
                        {
	                        if (!BankAccount.BankDict.ContainsKey( B.BankAccountNumber ))
		                        BankAccount.BankDict.Add( B.BankAccountNumber, B );
                        }
                        Bcount++;
                        BankAccount.BankAccountsLinkedList.AddLast(B);
                        Customer C = (Customer)SerializeData.ReadCustomerDiskObject(dir2 + "Custobj" + B.CustAccountNumber + ".cust");
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
                                DataArray.ArrayAddCust(C);     // The one and only Customer ArrayList addition in this Fn()
                                if (Customer.CustDict != null)
                                {
	                                if (!Customer.CustDict.ContainsKey( C.CustomerNumber ))
		                                Customer.CustDict.Add( C.CustomerNumber, C );
                                }

                                Ccount++;
                                Customer.CustomersLinkedList.AddLast(C);
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
            Lists.SaveAllCustomerListData(Customer.CustomerFilePath + "CustSortedListData.cust");
            // sort the arrays in Ascending v0 - 9
            SortArray.SortBankArray(0);
            return count;
        }
    }
}
