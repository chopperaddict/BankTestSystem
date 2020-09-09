using System;
using System.Collections.Generic;
using System.Windows.Forms;
/*
* 
* THIS IS THE MAIN RUN CODE's SOURCE FILE
* */

namespace ClassAccessTest
{

	static class Program
	{
		public delegate T AddG<T> (T param1, T param2); // generic delegate
		public delegate T DivideG<T> (T param1, T param2); // generic delegate
		public delegate T MultiplyG<T> (T param1, T param2); // generic delegate

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public static CustomerFileHashTable CustomerHashTable = new CustomerFileHashTable ( );
		/*
         *        THESE ARE POTENTIALLY USEFUL
                   * SortedList<string, string> ascBalSortedList2 = Utils.GetAscendingSortedHashTable(CustomerBalanceHashTable.CustNoBalHashTable);
                   *SortedList<string, string> ascSortedList2 = Utils.GetAscendingSortedHashTable(CustomeFileHashTable.CustFileNoHashTable);
        */




		[STAThread]
		static void Main ( )
		{

			//// Declare a global Stringbuilder
			//var Report = new StringBuilder();
			//// Declare a global List<BankAccount>

			SortedList<Int32, BankAccount> BankList = new SortedList<Int32, BankAccount> ( );
			//// Declare a global List<Customer>
			SortedList<Int32, Customer> CustomerList = new SortedList<Int32, Customer> ( );

			//// Declare one and only <CustomerTransactions> Collections object (List)
			//List<CustomerTransactions> AllCustTransactions = new List<CustomerTransactions>();
			Application.EnableVisualStyles ( );
			Application.SetCompatibleTextRenderingDefault (false);
			Application.Run (new Bank ( ));

			//********************
			// TESTING AREA //
			//********************
			// standard Fn calls
			Utils.Add (4, 678);
			//double x = Utils.Add(12, 20);
			Utils.Add ((decimal)67, (decimal)34);
			double a = 23;
			double b = 12;
			Utils.Multiply (a, b);       // doubles
			Utils.Multiply (a, b);    // int's
			Utils.Multiply (a, b); // decimal
								   //x = Utils.Divide(20, 12);
			Utils.Concat ("aaaaaaaa", "dsfdafgdgfdfghgfh");
			string str = Utils.StripFilenameFromString ("safasd\\olh\\jklyuiyn\\kljgoyut\\cbcmbdfdkj.cnfd");
			Utils.FormatToDecimal ((Int16)1234);
			Utils.FormatToDecimal ((short)12345);
			Utils.FormatToDecimal ((Int32)12345);
			Utils.FormatToDecimal ((decimal)123456789);
			Utils.FormatToDecimal ((decimal)12345678.78);
			Utils.FormatToDecimal ((double)123.56);
			Utils.FormatToDecimal ("12345.6");


			//*******************************************************************************************************************************************
			// Delegate Fn calls
			//*******************************************************************************************************************************************
			AddG<int> IAdd = new AddG<int> (Utils.Add);
			AddG<decimal> DAdd = new AddG<decimal> (Utils.Add);
			AddG<double> Dz = new AddG<double> (Utils.Add);
		}
		//*******************************************************************************************************************************************

		public static string CallBakM (string a)
		{
			return "qqqqqqqqq";
		}


	}


	//*******************************************************************************************************************************************
	public class GetListBank
	//*******************************************************************************************************************************************
	{

	}
	//*******************************************************************************************************************************************
	public static class ControlID
	//*******************************************************************************************************************************************
	{
		public static string dataresult { get; set; }
	}
}


