using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ClassAccessTest
{
	class ConfigData
	{
		// This class is solelyinvolved in getting and setting our "Global Variables" 
		// for numbering our files and customer account #'s etc
		internal static Int32 CfgCustNumberSeed = 0;
		internal static Int16 CfgCustomerFileSeed = 0;
		internal static Int16 CfgBankFileNumber = 0;
		internal static Int16 CfgBankTotalAccounts = 0;

		internal static string[] datain = { "", "", "", "" };

		//*******************************************************************************************************************************************
		public static string[] RegenerateConfigData ( )
		//*******************************************************************************************************************************************
		{
			string[] data = { "", "", "", "", "", "", };
			// iterate thru all the files on disk, startinmg at 1
			// Iterate trhu them and handle as required
			// Do Customers first
			string[] files = System.IO.Directory.GetFiles (Customer.GetCustFilePath ( ), "*.cust");
			int total = 0;
			foreach ( var fi in files )
			{
				if ( fi.Contains ("CustObject") ) { total++; }

			}
			Customer.SetTotalCustomers (Convert.ToInt16 (total));
			total++;
			Customer.SetCustomerNumberSeed (Convert.ToInt32 (Bank.V + total));
			data[0] = Customer.ReadCustNumberSeed ( ).ToString ( );
			data[1] = total.ToString ( );

			// Now do BankAccounts
			foreach ( var fi in files )
			{
				if ( fi.Contains ("BankObj") ) { total++; }
			}
			if ( total == 0 )
			{
				MessageBox.Show ("Unable to recreate CustomerConfig.dat", "Startup ERROR");
				return null;
			}
			BankAccount.SetTotalBanks (Convert.ToInt16 (total));
			data[2] = total.ToString ( );
			data[3] = DateTime.Now.ToShortDateString ( );
			return data;
		}
		//******************************************************************************************************
		public static void ReadConfigData ( )
		// Here we read our data from disk and then
		// update the variables in our application.
		//******************************************************************************************************
		{
			string fpath = "CustomerConfig.dat";
			string[] datain;
			try
			{
				if ( File.Exists (fpath) )
				{
					datain = System.IO.File.ReadAllLines (fpath);
					if ( datain.Count ( ) > 0 )
					{
						if ( datain[0].Length > 0 && datain[1].Length > 0 && datain[2].Length > 0 && datain[3].Length > 0 && datain[4].Length > 0 && datain[5].Length > 0 )
						{
							//now reset the variables in the class so we are READY TO START PROCESSING
							Customer.SetCustomerNumberSeed (Convert.ToInt32 (datain[0]));
							BankAccount.SetBankAccountNumberSeed (Convert.ToInt32 (datain[1]));
							BankAccount.SetTotalBanks (Convert.ToInt16 (datain[2]));
							Logger.SetLastDate (datain[3]);
						}
					}
					else { RegenerateConfigData ( ); }       // this return a stirng[] containing CORRECT config data
				}
				else
				{ RegenerateConfigData ( ); }
			}
			catch
			{ throw new Exception ("Failed to recreate config data file, line 50 in saveconfig.cs"); }
		}

		//******************************************************************************************************
		public static void SaveConfigData ( )
		// Here we write our data to disk after
		// getting the variables from our application.
		//******************************************************************************************************
		{
			string fpath = "CustomerConfig.dat";
			try
			{     // Assemble all our data into a string[]
				  // Finally - WRITE IT TO DISK     
				System.IO.File.WriteAllLines (fpath, Customer.ReadAllSeedData ( ));
			}
			catch { throw new Exception ("Failed to save config data file, line 96 in saveconfig.cs"); }
		}
	}
}
