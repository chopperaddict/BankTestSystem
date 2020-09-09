using System;

namespace ClassAccessTest
{
	partial class DataSet1
	{
		partial class Customer
		{
			Int32 CUSTNO;
			Int32 BANKNO;
			string FNAME;
			string LNAME;
			DateTime DOB;
			string ADD1;
			string ADD2;
			string TOWN;
			string CITY;
			string PCODE;
			string TEL;
			string MOB;
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
			Int32 BANKNO = 0;     // Secondary key
			Int32 CUSTNO = 0; // major key
			Int16 ACTYPE = 0;        // minor key
			double BALANCE = 0.00;
			DateTime OPENDATE;
			DateTime CLOSEDATE;// We do not fill this out.
			double INTEREST = 3.75;    // Default value only
			Int16 STATUS = 1; // Status can be 0-Closed, 1
		}
		// Each CUSTOMER A/C WILL HAVE UP TO 4 OF THESE ATTACHED
		partial class SeedData
		{
			double ACCOUNTNOSEED = 1230000;
			double CUSTNOSEED = 1234500;
			string CUSTFILESUFFIX = "cust";
			string BANKFILESUFFIX = ".bnk";
			Int16 BANKACCOUNTTOTAL = 0;
		}
	}
}
