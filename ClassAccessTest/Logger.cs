using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ClassAccessTest
{
	// THIS CLASS HANDLES FILE LOGGING OF OPERATIONS PERFORMED ON THE SYSTEM
	// IT USES  VARIOUS EVENT HANDLERS TO TRIGGER THE LOG FILE WRITE OPERATION
	// YEAH - REALLY !!!!!
	// The files change automatically each day with new fille names based on current date
	// access is provided to get log data back at 3 levels of detail.
	class Logger
	{
		private static DateTime lastdate = DateTime.Now;
		private static string custpath = "C:\\Users\\ianch\\source\\C#SavedData\\Customers\\CustLogs\\";
		private static string bankpath = "C:\\Users\\ianch\\source\\C#SavedData\\BankAccounts\\BankLogs\\";
		private static string dt = DateTime.Now.ToShortDateString ( );
		// Handles maintaining our ongoing log files.
		private static List<string> CustLogList = new List<string> ( );
		private static List<string> BankLogList = new List<string> ( );

		public static string ReadLastDate ( )
		{ return dt; }
		public static void SetLastDate (string date)
		{ dt = date; }
		//**************************************************************************
		public static void WriteLog (string inputstr, int type)
		//**************************************************************************
		{       // Write the entry to the log file
				// first, see if we need to update the system stored date

			if ( !inputstr.Contains ("\r\n") ) inputstr += "\n/";
			string path = "";
			DateTime dnow = DateTime.Now;
			string str1 = dnow.ToShortDateString ( );
			string str2 = lastdate.ToShortDateString ( );
			string date = "";
			if ( str1 != str2 )
			{
				date = str1;
				dt = dnow.ToShortDateString ( ); // update our stored date
			}
			else
			{
				string day = DateTime.Now.Day.ToString ( );
				string month = DateTime.Now.Month.ToString ( );
				string year = DateTime.Now.Year.ToString ( );
				if ( day.Length < 2 ) day = "0" + day;
				if ( month.Length < 2 ) month = "0" + month;
				year = year.Substring (2);
				date = day + month + year;
			}
			string time = DateTime.Now.ToLongTimeString ( );
			if ( type == 1 ) // Bank
			{ path = bankpath + "BankLog-" + date + ".log"; }
			else { path = custpath + "CustLog-" + date + ".log"; }

			File.AppendAllText (path, time + " : " + inputstr);
		}
		//**************************************************************************
		//**************************************************************************
		public static List<string> GetLogStats (int type, int datalevel)
		//**************************************************************************
		{       // Generate the data according to level requested and returnj to caller
				//datalevel: 1-just total files, 2- total + all filenames, 3 - include actual file data
				// List for our output
				// format data [0] = files.count
				// format data [1 -[0]] = files.names
			List<string> data = new List<string> ( );
			string searchpath = "";

			// get log type from user input
			if ( type == 1 )
				searchpath = bankpath;
			else
				searchpath = custpath;
			// get list of files in relevant folder , + count
			// code is generic from here onwards
			string[] files = Directory.GetFiles (searchpath, "*.log");
			char[] ch = { '\r' };
			int FileCount = files.Count ( );

			if ( datalevel >= 1 )
			{
				string fname = "";
				int counter = 0;
				data.Add (FileCount.ToString ( ));
				if ( datalevel >= 2 )
				{
					foreach ( string item in files )
					{
						fname = Utils.StripFilenameFromString (item);
						//fname = item.Substring(item.Length - 18);
						data.Add ("File Name : " + fname + "\r\n");
						if ( datalevel >= 3 )
						{   // add the contents of each file
							// read file contents  and add them ot output
							string filein = File.ReadAllText (files[counter]);
							data.Add (filein);
							data.Add ("\r\n***FILE END***\r\n");
							counter++;
							if ( counter > files.Count ( ) ) break;
						}      // add all the filenames to output data
					}
					data.Add ("***DATA FILE - END***");
				}
			}
			return data;
		}
	}
}
