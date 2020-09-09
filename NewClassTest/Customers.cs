using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


// This file handles the *** Customer *** "database" Class and processing
namespace ClassAccessTest
{

    [Serializable]
    public class Customer : IDisposable
    {
        public Int32 CustomerNumber;
        public string FirstName;
        public string LastName;
        public DateTime DOB;
        public string PhoneNumber;
        public string MobileNumber;
        public string Address1;
        public string Address2;
        public string Town;
        public string County;
        public string PostCode;
        public string FullFileName = "";
        public string FileName = "";
        public Int16[] accounttypes = { 0, 0, 0, 0 };
        public Int32[] accountnums = { 0, 0, 0, 0 };

        private static Int32 customerNumberSeed = 1234500;
        private static Int16 totalCustomers = 0;

        public static string CustomerFilePath = "C:\\Users\\ianch\\source\\C#SavedData\\Customers\\";

        // The One and Only List of Customer objects
        // This LinkedList is going to hold just the Cusotmer # and it's filename on disk
        public static LinkedList<Customer> CustomersLinkedList = new LinkedList<Customer> ( );

        public static int CustomerNumberSeed1 { get => customerNumberSeed; set => customerNumberSeed = value; }
        public static short TotalCustomers1 { get => totalCustomers; set => totalCustomers = value; }


        // EVENT HANDLERS **********************************************

        //------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Customer ( )
        {
        } // default Constructor
          //------------------------------------------------------------------------------------------------------------------------------------------------------------
          // DEFAULT ACCESSORS FOR THE PRIVATE DATA FIELDS.
          // All the GET Fn's automatically POST INCREMENT their values...
          // The READ optoins do NOT Increment
          // The Set options ONLY reset from backup data
        public static Int32 GetCustomerNumberSeed ( )
        {
            Int32 fno = CustomerNumberSeed1++; return ( fno );
        }
        public static Int32 ReadCustNumberSeed ( ) { return CustomerNumberSeed1; }    // just reads it - no incrementing
        public static void SetCustomerNumberSeed (Int32 newval) { CustomerNumberSeed1 = newval; }
        public static Int16 GetTotalCustomers ( ) { return TotalCustomers1; }
        public static void SetTotalCustomers (Int16 newval) { TotalCustomers1 = newval; }
        public static string GetCustFilePath ( ) { return Customer.CustomerFilePath; }

        //************************** Event handlers *************************
        public static event EventHandler<string> CustNoChangedEvent;
        public static event EventHandler<string> CustAccountChangedEvent;
        public static event EventHandler<string> CustListChangedEvent;
        public static event EventHandler<string> CustomerChangedEvent;

        public static void CustomerEvents ( )
        {
            Customer.CustNoChangedEvent += Customer_CustNoChangedEvent;
            CustAccountChangedEvent += Customer_CustAccountChangedEvent;
            Customer.CustListChangedEvent += Customer_CustListChangedEvent;
            CustomerChangedEvent += Customer_CustomerChangedEvent;
        }

        public static void Customer_CustNoChangedEvent (object sender, string e)
        {
            string outstr = "A Customer's Account has changed, A/.C # = " + e.ToString ( ) + "\r\n";
            Bank.form1.ShowText ( outstr, null, -1 );
            Logger.WriteLog ( outstr, 2 ); // 2 = customer
        }
        private static void Customer_CustAccountChangedEvent (object sender, string e)
        {
            string outstr = "A Customer's Account has changed, A/.C # = " + e.ToString ( ) + "\r\n";
            Bank.form1.ShowText ( outstr, null, -1 );
            Logger.WriteLog ( outstr, 2 ); // 2 = customer
        }
        public static void Customer_CustListChangedEvent (object sender, string e)
        {
            string outstr = "The Customer LinkedList has been modified...\r\n" + e + "\r\n";
            Bank.form1.Output2.AppendText ( outstr );
            Logger.WriteLog ( outstr, 2 ); // 2 = customer
        }
        public static void Customer_CustomerChangedEvent (object sender, string e)
        {
            string outstr = "A Customer's Account has changed, A/.C # = " + e.ToString ( ) + "\r\n";
            Bank.form1.ShowText ( outstr, null, -1 );
            Logger.WriteLog ( outstr, 2 ); // 2 = customer
        }

        // return a string[] for listing and saving our config data
        //*******************************************************************************************************************************************************************************************//
        public static string[] ReadAllSeedData ( )
        //*******************************************************************************************************************************************************************************************//
        {
            string[] str = { "", "", "", "", "", "" };
            char[] ch = { '\t' };
            str[0] = ReadCustNumberSeed ( ).ToString ( );
            str[1] = BankAccount.ReadBankAccountNumberSeed ( ).ToString ( );
            str[2] = BankAccount.ReadTotalBanks ( ).ToString ( );
            str[3] = Logger.ReadLastDate ( ).ToString ( );
            return str;
        }
        //****************************************************************************************************************************
        // following is justto allow me to kill objects on demand
        //private bool _disposed = false;
        // should receive false if called from a "Finalizer" but true if called from IDisposable.Dispose(true) method
        protected virtual void Dispose (bool disposing)
        //*******************************************************************************************************************************************************************************************//
        {
            if ( disposing )
            {
                // Free memory , unmanaged resources etc etc.
            }
        }
        // This is the Fn we call to delete the object !!
        //*******************************************************************************************************************************************************************************************//
        public void Dispose ( )
        //*******************************************************************************************************************************************************************************************//
        {
            // Dispose of unmanaged resources.
            Dispose ( true );
            // Suppress finalization.
            GC.SuppressFinalize ( this );
        }
        //******************************************************END OF OBJECT SPECIFICATION*********************************************************************************************//


        //******************************************************START OF CUSTOMER FUNCTIONALITY *************************************************************************************//

        // The main overloaded constructor used all the time
        public static Customer CreateNewCustomer (string accno, string Firstname, string lastname, string phone, string mobile, string addr1,
                            string addr2, string town, string County, string Postcode, int actype, Int32 bAccountNo, DateTime DOB)
        {
            //*******************************************************************************************************************************************************************************************//
            // This returns a new Customer Object to the caller 
            // & adds the customer to the LinkedList and Hashtable
            Customer Cust = new Customer ( );    // Customers object			   
            string fnamealone = "CustObj" + accno + ".cust";
            // Fill out the data in the ojbect
            Cust.CustomerNumber = Convert.ToInt32 ( accno );
            Cust.accountnums[0] = Cust.CustomerNumber;
            Cust.FirstName = Firstname; ;
            Cust.LastName = lastname;
            Cust.DOB = DOB;
            Cust.PhoneNumber = phone;
            Cust.MobileNumber = mobile;
            Cust.Address1 = addr1; ;
            Cust.Address2 = addr2;
            Cust.Town = town;
            Cust.County = County;
            Cust.PostCode = Postcode;
            Cust.FileName = fnamealone;
            // Sort out the array of bank account details
            for ( int i = 0; i < 4; i++ )
            {
                if ( Cust.accounttypes[i] == 0 )
                {
                    Cust.accounttypes[i] = Convert.ToInt16 ( actype );
                    Cust.accountnums[i] = bAccountNo;
                    break;
                }
            }

            string str = Customer.GetCustFilePath ( ) + fnamealone;
            // Ensure we save the file path in the customer object itself
            Cust.FullFileName = str;
            // update LinkedList
            Customer.CustomersLinkedList.AddLast ( Cust );
            // save our Customer LinkedList to disk as binary and txt files
            Lists.SaveAllCustomerListData ( Customer.CustomerFilePath + "CustSortedListData.cust" );
            // Add to Bank Array
            DataArray.ArrayAddCust ( Cust );

            // Saves the  new Customer Object to a disk file with a  unique name
            // and creates a Textfile version as well
            Customer.WriteCustObjectToDiskAndText ( Cust, str );
            CustNoChangedEvent?.Invoke ( Cust, "NEW CUSTOMER" );

            return Cust;
        }
        //**************************************************************************************************************************************************
        // Parse out from a Customer object and return the data as a StringBuilder object
        public StringBuilder ParseCustData (Customer C)
        //**************************************************************************************************************************************************
        {
            StringBuilder s = new StringBuilder ( );
            s.AppendLine ( C.FirstName );
            s.AppendLine ( C.LastName );
            s.AppendLine ( C.Address1 );
            s.AppendLine ( C.Address2 );
            s.AppendLine ( C.Town );
            s.AppendLine ( C.PostCode );
            s.AppendLine ( C.PhoneNumber );
            s.AppendLine ( C.MobileNumber );
            s.AppendLine ( C.DOB.ToString ( ) );
            // try t handle the account types and numbers arrays
            for ( int i = 0; i < C.accounttypes.Count ( ); i++ )
            {
                // only list account details if they are there, dont show all 5.
                if ( C.accounttypes[i] > 0 && C.accountnums[i] > 0 )
                {
                    s.AppendLine ( C.accounttypes[i].ToString ( ) );
                    s.AppendLine ( C.accountnums[i].ToString ( ) );
                }
            }
            return s;
        }

        //**************************************************************************************************************************************************
        public static Customer GetCustomerAccount (string accountno)
        //**************************************************************************************************************************************************
        {
            foreach ( var C in CustomersLinkedList )
            {
                if ( C == null ) continue;
                if ( C.CustomerNumber == Convert.ToInt32 ( accountno ) )
                {   // got it
                    return C;
                }
            }
            return null;
        }

        //************************************************************************************************************************************************
        // called to list all customer accounts in our output window
        public static int VerifyCustomerDataFiles (string style = "*.CUST")
        //************************************************************************************************************************************************
        {
            // FIRST, LETS READ THE CUSTOMER TRANSACTIONS FILE  SO WE CAN COMPARE            
            // /Get all customer data from the disk file <bankCustomerData.cust>as Stringbuilder

            string dir = GetCustFilePath ( );// + "CustSortedListData.cust";

            //This call gets a full list of the files in the given folder
            //The style parameter contains the file suffix to be matched (CUST in our case)
            //C:\Users\ianch\source\C#SavedData\Customers\
            string[] files = System.IO.Directory.GetFiles ( dir, style );
            // iterate thru all the files on disk
            // count how many objects we should have to read in
            Int16 count = 0;
            // Iterate trhu them and handle as required
            foreach ( var fi in files )
            {
                // first we need to strip path off the filename
                if ( fi.Contains ( "CustObj" ) )
                    count++;
                //  Make sure we update the BankAccount LinkedList
            }
            return count;// Total number of files that match out pattern as customer files
        }

        //************************************************************************************************************************************************
        public static int RebuildAllCustDataFromDisk ( )
        //************************************************************************************************************************************************
        {
            // iterate thru reading Customer objects from disk and add them to our linkedList and SortedArray
            int count = 0;
            string dir = Customer.GetCustFilePath ( );
            string[] files = System.IO.Directory.GetFiles ( dir, "*.cust" );
            // clear the lists- JIC
            CustomersLinkedList.Clear ( );
            if ( !DataArray.ArrayClearCust ( ) )
            {     // delete customer arrayList totally
            }
            foreach ( Customer o in DataArray.CustNo )
            { if ( o == null ) continue; o.Dispose ( ); }

            // Iterate trhu them and handle as required
            foreach ( var fi in files )
            {
                bool result = fi.Contains ( "CustObj" );
                if ( !result ) continue;
                Customer C = SerializeData.ReadCustomerDiskObject ( fi );
                // add each one to our new List so we cna use the Enumeration later
                if ( C != null )
                {
                    try
                    {
                        count++;
                        CustomersLinkedList.AddLast ( C );        // Add to LinkedList
                        DataArray.ArrayAddCust ( C );      // Add to SortedList
                    }
                    catch { }
                    new Exception ( " Failed to update LinkeList of sortedlist in RebuildCustLinkedListFromDisk at line 256" );
                }
                C.Dispose ( );
            }
            // save our Customer LinkedList to disk as binary and txt files
            Lists.SaveAllCustomerListData ( Customer.CustomerFilePath + "CustSortedListData.cust" );

            return count;
        }
        //************************************************************************************************************************************************
        public static bool UpdateCustomerLinkedList (Customer Cust)
        //************************************************************************************************************************************************
        {
            bool result = false;
            foreach ( var L in Customer.CustomersLinkedList )
            {
                if ( L == null ) continue;
                if ( L.CustomerNumber == Cust.CustomerNumber )
                {   // got it
                    if ( Customer.CustomersLinkedList.Contains ( L ) )
                    {
                        Customer.CustomersLinkedList.Remove ( L );
                        Customer.CustomersLinkedList.AddLast ( Cust );
                        result = true;
                        break;
                    }
                }
                // save our Customer LinkedList to disk as binary and txt files
                Lists.SaveAllCustomerListData ( Customer.CustomerFilePath + "CustSortedListData.cust" );
            }
            CustListChangedEvent?.Invoke ( Cust, "FULL LINKEDLIST UPDATE" );

            return result;
        }
        //************************************************************************************************************************************************
        public static void SaveSortedCustomerListToText ( )
        //************************************************************************************************************************************************
        {   // save the Customer Array/List data to obj and Text
            StringBuilder SB = new StringBuilder ( );
            string output = "";
            string path = Customer.GetCustFilePath ( );
            path += "CustSortedListData.cust";
            foreach ( Customer v in DataArray.CustNo )
            {
                if ( v == null ) continue;
                SB.Append ( v );
                output += v.CustomerNumber.ToString ( ) + "," + v.LastName + "," + v.FirstName + "," + v.Address1 + ","
                            + v.Address2 + "," + v.Town + "," + v.County + "," + v.PostCode + "," + v.PhoneNumber + "," + v.MobileNumber
                            + "," + v.DOB.ToShortDateString ( ) + "," + v.accountnums[0].ToString ( ) + "," + v.accounttypes[0].ToString ( ) + ","
                                            + v.accountnums[1].ToString ( ) + "," + v.accounttypes[1].ToString ( )
                                            + "," + v.accountnums[2].ToString ( ) + "," + v.accounttypes[2].ToString ( )
                                            + "," + v.accountnums[3].ToString ( ) + "," + v.accounttypes[3].ToString ( ) + "," + v.FileName + "," + v.FullFileName + ",\t";
            }
            SerializeData.SBSerialize ( SB, path );
            path = Customer.GetCustFilePath ( );
            path += "Textfiles\\CustSortedListData.txt";
            File.WriteAllText ( path, output );
        }
        public static void ReadSortedCustomerListFromText ( )
        //************************************************************************************************************************************************
        {   // Read the Customer SortedList data obj 
            string dir = BankAccount.ReadBankFilePath ( );
            string[] files = System.IO.Directory.GetFiles ( dir, "CustSortedListData.cust" );
            // iterate thru all the files on disk, startinmg at 1
            // Iterate trhu them and handle as required
            StringBuilder SB = null;
            foreach ( var fi in files )
            {
                bool result = fi.Contains ( "CustSortedListData.cust" );
                if ( result )
                {
                    SB = Utils.GetDataFromDiskFile(SB, fi);
/*
                    FileStream fs = new FileStream ( fi, FileMode.Open );
                    // Get a SortedList object for our data
                    //new SortedList<Int32, Customer> ( );
                    //					SortedList<Int32, Customer> C = new SortedList<Int32, Customer> ( );
                    BinaryFormatter formatter = new BinaryFormatter ( );
                    SB = ( StringBuilder ) formatter.Deserialize ( fs );
                    fs.Close ( );
  */              }
            }
            string output = SB.ToString ( ); ;
            Lists.ParseCustSortedListText ( output );
        }
        //************************************************************************************************************************************************
        public static StringBuilder ReadCustSortedListFromText ( )
        //************************************************************************************************************************************************
        {   // read sorted customer list in from Text file
            StringBuilder SB = new StringBuilder ( );
            string path = Customer.GetCustFilePath ( );
            path += "Textfiles\\CustSortedListData.txt";
            if ( !File.Exists ( path ) ) return SB;
            string input = File.ReadAllText ( path );
            SB.Append ( input );
            return SB;
            /*FORMAT of data is 
			 * v . Key . ToString ( ) + "," + v . Value . CustomerNumber . ToString ( ) + "," + v . Value . LastName + "," + v . Value . FirstName + "," + v . Value . Address1 + ","
			+ v . Value . Address2 + "," + v . Value . Town + "," + v . Value . County + "," + v . Value . PostCode + "," + v . Value . PhoneNumber + "," + v . Value . MobileNumber
			+ "," + v . Value . DOB . ToShortDateString ( ) + "," + v . Value . accountnums [ 0 ] . ToString ( ) + "," + v . Value . accounttypes [ 0 ] . ToString ( ) + ","
			+ v . Value . accountnums [ 1 ] . ToString ( ) + "," + v . Value . accounttypes [ 1 ] . ToString ( ) + "," + v . Value . accountnums [ 2 ] . ToString ( ) + ","
			+ v . Value . accounttypes [ 2 ] . ToString ( ) + "," + v . Value . accountnums [ 3 ] . ToString ( ) + "," + v . Value . accounttypes [ 3 ] . ToString ( ) + "\t";
*/
        }
        //************************************************************************************************************************************************
        // update Customer account after a solo bank account is created and allocated
        public static void UpdateCustWithNewBankAccount (Int32 custno, Int32 bankno, Int16 actype)
        //************************************************************************************************************************************************
        {
            Customer Cust = new Customer ( );
            string fi = GetCustFilePath ( ) + "Custobj" + custno.ToString ( ) + ".cust";
            Cust = SerializeData.ReadCustomerDiskObject ( fi );
            for ( int i = 0; i < 4; i++ )
            {
                if ( Cust.accounttypes[i] == 0 )
                {
                    Cust.accounttypes[i] = Convert.ToInt16 ( actype );
                    Cust.accountnums[i] = bankno;
                    break;
                }
            }
            // save  new bank details to customer a/c
            Customer.WriteCustObjectToDiskAndText ( Cust, fi );
            // update Linkedlist
            foreach ( Customer C in CustomersLinkedList )
            {
                if ( C.CustomerNumber == Cust.CustomerNumber )
                {
                    for ( int i = 0; i < 4; i++ )
                    {
                        if ( C.accounttypes[i] == 0 )
                        {
                            C.accounttypes[i] = Convert.ToInt16 ( actype );
                            C.accountnums[i] = bankno;
                            break;
                        }
                    }
                }
            }
            // save our Customer LinkedList to disk as binary and txt files
            Lists.SaveAllCustomerListData ( Customer.CustomerFilePath + "CustSortedListData.cust" );
        }
        public static bool RebuildCustDataFromTextFiles ( )
        {
            string[] fullpath = null;
            char[] c = { '\\' };
            string path = GetCustFilePath ( );
            path += "Textfiles\\";
            string[] files = Directory.GetFiles ( path );
            string input = "";
            DataArray.ArrayClearCust ( );
            if ( files.Length > 0 )
            {
                foreach ( string s in files )
                {
                    if ( s.Contains ( "CustObj" ) )
                    {
                        input = File.ReadAllText ( s );
                        string[] fields = input.Split ( ',' );
                        fullpath = s.Split ( c );
                        Customer C = new Customer ( );
                        C.CustomerNumber = Convert.ToInt32 ( fields[0] );
                        C.LastName = fields[1];
                        C.FirstName = fields[2];
                        C.Address1 = fields[3];
                        C.Address2 = fields[4];
                        C.Town = fields[5];
                        C.County = fields[6];
                        C.PostCode = fields[7];
                        C.PhoneNumber = fields[8];
                        C.MobileNumber = fields[9];
                        C.DOB = Convert.ToDateTime ( fields[10] ).Date;
                        string tmp = fields[12];    // this should give us the MAIN BA # as 2nd part (tmp[1])
                                                    //need to check for additional bank a/cs here...
                                                    // we will always have at least ONE tilde
                        char[] c1 = { '~' };
                        string[] additionalbakaccounts = tmp.Split ( c1 );
                        //We will have at least TWO strings form this, possibly more
                        C.FileName = fields[11];// this is definitely the C.filename
                        C.accountnums[0] = Convert.ToInt32 ( additionalbakaccounts[1] );
                        C.accounttypes[0] = Convert.ToInt16 ( additionalbakaccounts[0] );
                        if ( fields.Count ( ) >= 13 && fields[13] != "" )
                        {
                            tmp = fields[13];
                            if ( tmp.Contains ( "~" ) )
                            {//we have at least one of these in every file, possibly more
                                char[] c2 = { '~' };
                                string[] tmp2 = tmp.Split ( c2 );// try to remove the <CR>
                                C.accounttypes[1] = Convert.ToInt16 ( tmp2[0] );
                                C.accountnums[1] = Convert.ToInt32 ( tmp2[1] );
                            }
                        }
                        if ( fields.Count ( ) >= 14 && fields[14] != "" )
                        {// we got more than one bank account attached, so process it/them
                            tmp = fields[14];
                            if ( tmp.Contains ( "~" ) )
                            {//we have at least one of these in every file, possibly more
                                char[] c2 = { '~' };
                                string[] tmp2 = tmp.Split ( c2 );// try to remove the <CR>
                                C.accounttypes[2] = Convert.ToInt16 ( tmp2[0] );
                                C.accountnums[2] = Convert.ToInt32 ( tmp2[1] );
                            }
                            if ( fields.Count ( ) >= 15 && fields[15] != "" )
                            {// we got more than one bank account attached, so process it/them
                                tmp = fields[15];
                                if ( tmp.Contains ( "~" ) )
                                {//we have at least one of these in every file, possibly more
                                    char[] c2 = { '~' };
                                    string[] tmp2 = tmp.Split ( c2 );// try to remove the <CR>
                                    C.accounttypes[3] = Convert.ToInt16 ( tmp2[0] );
                                    C.accountnums[3] = Convert.ToInt32 ( tmp2[1] );
                                }
                            }
                        }
                        C.FullFileName = GetCustFilePath ( ) + C.FileName;
                        DataArray.ArrayAddCust ( C );
                        Customer.CustomersLinkedList.AddLast ( C );
                        Customer.WriteCustObjectToDiskAndText ( C, C.FullFileName );
                    }
                }
                // save our Customer LinkedList to disk as binary and txt files
                Lists.SaveAllCustomerListData ( Customer.CustomerFilePath + "CustSortedListData.cust" );
            }
            return true;
        }     // end Fn
        public static void SaveAllCustomersToDiskAndText ( )
        {
            string path = GetCustFilePath ( );
            string FileName = "";
            foreach ( Customer v in DataArray.CustNo )
            {
                FileName = path + v.FileName;
                WriteCustObjectToDiskAndText ( v, FileName );
            }
        }
        //************************************************************************************************************************************************
        //*******************************************************************************************************************************************
        //Save a Customer object to disk file
        public static void WriteCustObjectToDiskAndText (Customer Cust, string FileName)
        //*******************************************************************************************************************************************
        {
            // Add a number ot the filename to make it unique
            // number is a static int in this class.
            // FileName += CustomerFileExtensionNo.ToString() + ".cust";
            // Open the file and write the Customer object data that you want to serialize to a disk file
            FileStream fs = new FileStream ( FileName, FileMode.Create );
            BinaryFormatter formatter = new BinaryFormatter ( );
            formatter.Serialize ( fs, Cust );
            // clean up
            fs.Close ( );
            string accts = "";
            if ( Cust.accounttypes[0] > 0 )
                accts = Cust.accounttypes[0].ToString ( ) + "~" + Cust.accountnums[0].ToString ( );
            if ( Cust.accounttypes[1] > 0 )
                accts += "," + Cust.accounttypes[1].ToString ( ) + "~" + Cust.accountnums[1].ToString ( );
            else
                accts += ",";
            if ( Cust.accounttypes[2] > 0 )
                accts += "," + Cust.accounttypes[2].ToString ( ) + "~" + Cust.accountnums[2].ToString ( );
            else
                accts += ",";
            if ( Cust.accounttypes[3] > 0 )
                accts += "," + Cust.accounttypes[3].ToString ( ) + "~" + Cust.accountnums[3].ToString ( );
            else
                accts += ",";
            string s = Cust.CustomerNumber + "," + Cust.FirstName + "," + Cust.LastName + "," + Cust.Address1 + "," + Cust.Address2 + "," + Cust.Town + "," + Cust.County + ","
                        + Cust.PostCode + "," + Cust.PhoneNumber + "," + Cust.MobileNumber + "," + Cust.DOB.ToString ( ) + "," + Cust.FileName + "," + accts + ",\r\n";
            // This writes the std string [record] out in text format in \\textfiles folder
            string path = Customer.GetCustFilePath ( ) + "Textfiles\\" + Cust.FileName.Substring ( 0, Cust.FileName.Length - 5 ) + ".txt";
            if ( File.Exists ( path ) )
                File.Delete ( path );       // you gotta delete them first, else it appends the data constantly
            File.AppendAllText ( path, s );
        }


    }   //end of namespace
}


