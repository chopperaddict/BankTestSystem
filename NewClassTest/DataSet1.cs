using System;

namespace ClassAccessTest
{
	partial class DataSet1
	{
		partial class Customer
		{
			Int32 CUSTOMERACCOUNTNUMBER;
			Int32 BANKACCOUNTNUMBER;
			string FNAME;
			string LNAME;
			DateTime DOB;
			string ADD1;
			string ADD2;
			string TOWN;
			string CTY;
			string POSTCODE;
			Int16 ACTYPE;  // Hooks  to BankAccount to restrict searches
		}
		partial class BankTransaction
		{
			DateTime TRANSDATE;
			Int16 ACTYPE;
			Int32 ACNO;
			double TRANSAMOUNT;
			string NOTES;
			Int16 STATUS;
		}
		partial class BankAccounts
		{
			Int32 BANKACCOUNTNUMBER = 0;     // Secondary key
			Int32 CUSTACCOUNTNUMBER = 0; // major key
			Int16 ACCOUNTTYPE = 0;        // minor key
			double BALANCE = 0.00;
			DateTime DATEOPENED;
			DateTime DATECLOSED;// We do not fill this out.
			double INTERESTRATE = 3.75;    // Default value only
			Int16 STATUS = 1; // Status can be 0-Closed, 1
		}
		// Each CUSTOMER A/C WILL HAVE UP TO 4 OF THESE ATTACHED
		partial class SeedData
		{
			double ACCOUNTNOSEED = 1234500;
			double CUSTNOSEED = 1234500;
			string CUSTFILESUFFIX = "cust";
			string BANKFILESUFFIX = ".bnk";
			Int16 BANKACCOUNTTOTAL = 0;
		}
	}
}
