using System;
using System.Globalization;
using System.IO;
///  for NumberInfoFormat and Convert()
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;

namespace ClassAccessTest
{

	class Utils
	{
		        public static bool SQLconnection = false;
        #pragma warning disable CS0169 // The field 'Utils.command' is never used
//                static SqlCommand command;
        #pragma warning restore CS0169 // The field 'Utils.command' is never used
        #pragma warning disable CS0169 // The field 'Utils.dataReader' is never used
 //              static SqlDataReader dataReader;
        #pragma warning restore CS0169 // The field 'Utils.dataReader' is never used
                // Note the changed location for the database
                //        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ianch\source\C#SavedData\BankAccounts\SQL\ian1.mdf;Integrated Security=True;Connect Timeout=30";
                public static string connectionString = "";
                //original locatoin set by M$
                //public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ianch\source\repos\ClassAccessTest\ClassAccessTest\ian1.mdf;Integrated Security=True;Connect Timeout=30";

                public static SqlConnection cnn;
		//**************************************************************************************************************************************************************************************
		/*
		public static StringBuilder Stringbuilder = new StringBuilder ( );
		public static StringBuilder GetDataFromDiskFile(StringBuilder stringBuilder,  String File){
			StringBuilder SB = new StringBuilder();
			BinaryFormatter formatter = new BinaryFormatter ( );
			FileStream fs = new FileStream (File, FileMode.Open);
			var v = formatter.Deserialize (fs).ToString ( );
			SB.Append (v);
			fs.Close ( );
			return SB;
		}

		public static BankAccount GetDataFromDiskFile(BankAccount B, String File){
			FileStream fs = new FileStream (File, FileMode.Open);
			// Get a BankAccount object for our data
			BankAccount Bk = new BankAccount ( );
			BinaryFormatter formatter = new BinaryFormatter ( );
			Bk = (BankAccount)formatter.Deserialize (fs);
			fs.Close ( );
			return Bk;
		}
		public static string GetDataFromDiskFile(string s, String File){
			FileStream fs = new FileStream (File, FileMode.Open);
			// Get a BankAccount object for our data
			BinaryFormatter formatter = new BinaryFormatter ( );
			s = (string)formatter.Deserialize (fs);
			fs.Close ( );
			return s;
		}
*/
		// Get a Form from an IntPtr  HANDLE 
		// return a string[] for listing and saving our config data
		//*******************************************************************************************************************************************************************************************//
		public static string[] ReadAllSeedData ( )
			//*******************************************************************************************************************************************************************************************//
		{
			string[] str = { "", "", "", "", "", "" };
			char[] ch = { '\t' };
			str[0] = Customer.ReadCustNumberSeed ( ).ToString ( );
			str[1] = BankAccount.ReadBankAccountNumberSeed ( ).ToString ( );
			str[2] = BankAccount.ReadTotalBanks ( ).ToString ( );
			str[3] = Logger.ReadLastDate ( ).ToString ( );
			return str;
		}

		static public Form GetForm (IntPtr handle)
		//*******************************************************************************************************************************************
		{
			return handle == IntPtr.Zero ? null : Control.FromHandle (handle) as Form;
		}

		//*******************************************************************************************************************************************
		// Get a HANDLE for the specified Control
		static public Control.ControlCollection GetControlList (Form form1, string name, out object ctrl)
		//*******************************************************************************************************************************************
		{
			Form form = new Form ( );
			//			IntPtr handle = form1 . Handle;
			Control.ControlCollection CC = form1.Controls;
			foreach ( Control C in CC )
			{
				//				Output2 . AppendText ( );
				if ( C.Name == name )
				{   // This ithe Form handle - I think ?
					IntPtr Inp = C.TopLevelControl.Handle;
				}
			}
			//			ctrl = obj;
			ctrl = (object)null;
			return CC;
		}
		//*******************************************************************************************************************************************
		// Get a HANDLE for the specified Form
		static public IntPtr GetHandleForForm ( )
		//*******************************************************************************************************************************************
		{
			Form form = new Form ( );
			IntPtr handle = form.Handle;
			return handle;
		}
		//*******************************************************************************************************************************************
		public static double stringToDouble (string str)
		//*******************************************************************************************************************************************
		{
			double dbl;
			// This is how to convert anything to anything else basically.
			_ = new NumberFormatInfo {
				NumberDecimalSeparator = ".",
				NumberGroupSeparator = ",",
				NumberGroupSizes = new int[] { 2 }
			};
			// Finally we can now do the conversion
			dbl = Convert.ToDouble (str);
			return dbl;
		}
		//*******************************************************************************************************************************************
		public static decimal stringToDecimal (string str)
		//*******************************************************************************************************************************************
		{
			decimal dec;
			// This is how to convert anything to anything else basically.
			NumberFormatInfo numberFormatInfo1 = new NumberFormatInfo {
				NumberDecimalSeparator = ".",
				NumberGroupSeparator = ",",
				NumberGroupSizes = new int[] { 2 }
			};
			// Finally we can now do the conversion
			dec = Convert.ToDecimal (str);
			return dec;
		}
		//*******************************************************************************************************************************************
		public static Int16 stringToInt16 (string str)
		//*******************************************************************************************************************************************
		{
			Int16 int16;
			// This is how to convert anything to anything else basically.
			NumberFormatInfo reformat = new NumberFormatInfo {
				NumberDecimalSeparator = ".",
				NumberGroupSeparator = ",",
				NumberGroupSizes = new int[] { 2 }
			};
			// Finally we can now do the conversion
			int16 = Convert.ToInt16 (str, reformat);
			return int16;
		}
		//*******************************************************************************************************************************************
		public static int stringToInt32 (string str)
		//*******************************************************************************************************************************************
		{
			int intval;
			// This is how to convert anything to anything else basically.
			NumberFormatInfo reformat = new NumberFormatInfo {
				NumberDecimalSeparator = ".",
				NumberGroupSeparator = ",",
				NumberGroupSizes = new int[] { 2 }
			};
			// Finally we can now do the conversion
			intval = Convert.ToInt32 (str, reformat);
			return intval;
		}
		//*******************************************************************************************************************************************
		public static Int64 stringToInt64 (string str)
		//*******************************************************************************************************************************************
		{
			Int64 int64;
			// This is how to convert anything to anything else basically.
			NumberFormatInfo reformat = new NumberFormatInfo {
				NumberDecimalSeparator = ".",
				NumberGroupSeparator = ",",
				NumberGroupSizes = new int[] { 2 }
			};
			// Finally we can now do the conversion
			int64 = Convert.ToInt64 (str, reformat);
			return int64;
		}
		//*******************************************************************************************************************************************
		public static string GetCurrencyString (string amount)
		//*******************************************************************************************************************************************
		{
			if ( amount.Length == 0 ) return "";
			System.Globalization.CultureInfo CI = new System.Globalization.CultureInfo ("en-GB");
			string str = Global.ToFormattedCurrencyString (Convert.ToDecimal (amount), "£", CI);
			return str;
		}
		public static string GetFieldCurrencyString (string amount)
		//*******************************************************************************************************************************************
		{
			if ( amount.Length == 0 ) return "";
			System.Globalization.CultureInfo CI = new System.Globalization.CultureInfo ("en-GB");
			string str = Global.ToFormattedCurrencyString (Convert.ToDecimal (amount), "", CI);
			return str;
		}

		public static int Add (int val1, int val2)
		{ return ((int)val1 + (int)val2); }
		//		public static Int32 Add ( Int32 val1, Int32 val2 )
		//		{ return val1 + val2; }
		public static Int64 Add (Int64 val1, Int64 val2)
		{ return val1 + val2; }
		public static decimal Add (decimal val1, decimal val2)
		{ return val1 + val2; }
		public static double Add (double val1, double val2)
		{ return val1 + val2; }
		public static double Add (float val1, float val2)
		{ return val1 + val2; }
		public static string Add (string val1, string val2)
		{ return val1 + val2; }
		public static int Divide (int val1, int val2)
		{ return val1 / val2; }
		//		public static Int32 Divide ( Int32 val1, Int32 val2 )
		//{ return val1 / val2; }
		public static Int64 Divide (Int64 val1, Int64 val2)
		{ return val1 / val2; }
		public static decimal Divide (decimal val1, decimal val2)
		{ return val1 / val2; }
		public static double Divide (double val1, double val2)
		{ return val1 / val2; }
		public static float Divide (float val1, float val2)
		{ return val1 / val2; }
		//		public static Int16 Multiply ( Int16 val1, Int16 val2 )
		//		{ return val1 * val2; }
		public static Int32 Multiply (Int32 val1, Int32 val2)
		{ return val1 * val2; }
		public static Int64 Multiply (Int64 val1, Int64 val2)
		{ return val1 * val2; }
		public static decimal Multiply (decimal val1, decimal val2)
		{ return val1 * val2; }
		public static double Multiply (double val1, double val2)
		{ return val1 * val2; }
		public static float Multiply (float val1, float val2)
		{ return val1 * val2; }
		public static string Concat (string val1, string val2)
		{ return val1 + val2; }
		//*******************************************************************************************************************************************
		public static string StripFilenameFromString (string val1)
		{   // worked well in testing !!!
			string input = val1;
			char c = '\\';
			string[] strs;
			string fname = "";
			strs = input.Split (c);
			if ( strs.Length == 1 )
			{
				if ( val1.Contains (".") ) return val1; // nothing to do
				else return "";
			}
			else
			{
				fname = strs[strs.Length - 1]; // the last entry is the file name part
				if ( fname.Contains (".") ) return fname; // nothing to do}
				else return "";
			}
		}
		//*******************************************************************************************************************************************
		public static string FitCommas (char[] chars)
		{
			//			FindControl fc = new FindControl ( );
			//			Control . ControlCollection ctrls;//  = new Control.ControlCollection();

			/*			if ( Bank. ActiveForm . Controls . Contains ( Output2 ) )
						{

						}
				*/
			//		((TextBox) fc . Ctrl ( fc . TheForm ( "Bank" ), "Output2" )).Text = "Output2 identified";
			string output = "";
			if ( chars.Length == 4 )
			{
				output += chars[0]; output += chars[1]; output += chars[2]; output += ','; output += chars[3];
			}
			else if ( chars.Length == 5 )
			{
				output += chars[0]; output += chars[1]; output += chars[2];
				output += ','; output += chars[3]; output += chars[4];
			}
			else if ( chars.Length == 6 )
			{
				output += chars[0]; output += chars[1]; output += chars[2];
				output += ','; output += chars[3]; output += chars[4]; output += chars[5];
			}
			else if ( chars.Length == 7 )
			{
				output += chars[0]; output += chars[1]; output += chars[2];
				output += ','; output += chars[3]; output += chars[4]; output += chars[5];
				output += ','; output += chars[6];
			}
			else if ( chars.Length == 8 )
			{
				output += chars[0]; output += chars[1]; output += chars[2];
				output += ','; output += chars[3]; output += chars[4]; output += chars[5];
				output += ','; output += chars[6]; output += chars[7];
			}
			else if ( chars.Length == 9 )
			{
				output += chars[0]; output += chars[1]; output += chars[2];
				output += ','; output += chars[3]; output += chars[4]; output += chars[5];
				output += ','; output += chars[6]; output += chars[7]; output += chars[8];
			}
			else if ( chars.Length == 10 )
			{
				output += chars[0]; output += chars[1]; output += chars[2];
				output += ','; output += chars[3]; output += chars[4]; output += chars[5];
				output += ','; output += chars[6]; output += chars[7]; output += chars[8];
				output += ','; output += chars[9];
			}
			else if ( chars.Length == 11 )
			{
				output += chars[0]; output += chars[1]; output += chars[2];
				output += ','; output += chars[3]; output += chars[4]; output += chars[5];
				output += ','; output += chars[6]; output += chars[7]; output += chars[8];
				output += ','; output += chars[9]; output += chars[10];
			}
			else if ( chars.Length == 12 )
			{
				output += chars[0]; output += chars[1]; output += chars[2];
				output += ','; output += chars[3]; output += chars[4]; output += chars[5];
				output += ','; output += chars[6]; output += chars[7]; output += chars[8];
				output += ','; output += chars[9]; output += chars[10]; output += chars[11];
			}
			else
			{
				// just return it as is
				output = BuildStringFromChar (chars);
			}
			return ReverseString (output);
		}
		//*******************************************************************************************************************************************
		public static string BuildStringFromChar (char[] input)
		{
			string output = "";
			for ( int i = 0; i < input.Length; i++ )
			{
				output += input[i];
			}
			return output;
		}
		//*******************************************************************************************************************************************
		public static string AddCommas (char[] chars)
		{   // we only received the Integer part to process, not the decimal part
			string output = "";
			char[] ch = { '.' };
			char[] data = null;
			// string is reversed, process it for commas
			if ( chars.Length > 3 )
			{
				string temp = BuildStringFromChar (chars);
				string rev = ReverseString (temp);
				//                string temp = rev . ToString ( );
				//                string[] d = temp . Split ( ch );
				data = rev.ToCharArray ( );
				// pass the reversed integer part as a char[] 
				output = FitCommas (data);
				//				output += ".00";
			}
			else if ( chars.Length == 2 )
			{   // we HAVE  decimal point in it
				return chars.ToString ( );
			}
			else
			{
				return "";
			}
			return output;
		}// Works OK

		public string FormatNumberWithCommas (string input)
		{
			char[] chars;
			string output = "";
			chars = input.ToCharArray ( );
			output = AddCommas (chars);
			return output;
		}
		//*******************************************************************************************************************************************
		public static string ReverseString (string input)
		{
			string output = null;
			char[] chars = input.ToCharArray ( );
			int Inlen = chars.Length;
			char[] outch = new char[Inlen];
			for ( int i = chars.Length - 1; i >= 0; i-- )
				output += chars[i];
			return output;
		}
		//*******************************************************************************************************************************************
		public static string[] FormatCheck1 (string instr, int type)
		{   // do initial check of what we got
			// type is 1-Int16, 2 - Int32, 3 - Int64, 4 - double, 5 - decimal, 6 - 
			string input = "", output = "", intstr = "", decstr = "";
			string[] parts;

			char[] ch = { '.' };
			input = instr;
			// convert to string array of 2 parts (integer and decimal parts)
			parts = input.Split (ch);
			if ( parts.Length == 1 )
			{
				// just an integer part
				intstr = parts[0];
				output = parts[0].ToString ( );
			}
			else
			{
				// integer and decimal parts
				intstr = parts[0];
				decstr = parts[1];
			}
			return parts;
		}
		//*******************************************************************************************************************************************
		//*******************************************************************************************************************************************
		//*******************************************************************************************************************************************
		public static string ProcessAnyInt (string input)
		{
			string[] parts = null;
			string output = "";
			parts = FormatCheck1 (input, 1);
			int partscount = parts.Length;

			if ( partscount == 1 )
			{
				// only got the int part, so
				// just return the string value
				if ( parts[0].Length <= 3 )
				{
					output = parts[0].ToString ( ) + ".00";
				}
				else
				{   // string of more than 3 digits so
					output = input;
					//					output = AddCommas ( chars );
					return output;
				}
			}
			else
			{   // call the double handler
				double d = Convert.ToDouble (input);
				output = FormatToDecimal (d);
			}
			return output;
		}
		//*******************************************************************************************************************************************
		//*******************************************************************************************************************************************
		public static string FormatToDecimal (string inval)
		{
			// 1st we do a standard check to see what we got
			string output = "";
			string validstr = "0123456789.";
			decimal d = 0.0M;
			// check for non numeric  characters
			char[] array = inval.ToCharArray ( );
			char[] checkarray = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };
			int count = 0;

			foreach ( char c in array )
			{   // ensure we have only vlaid numbers, comma or decimal point
				if ( !validstr.Contains (c.ToString ( )) )
					return "";
				else if ( c != ',' )
					checkarray[count++] = c;
			}

			//convert it back  to a string again, trimming empty chars off the end
			output = BuildStringFromChar (checkarray);
			output.TrimEnd (' ');
			// convert to a valid numeric value to check it is a vlaid numeric value
			if ( output.Contains (".") )
			{
				d = Convert.ToDecimal (output);
				return FormatToDecimal (d);
			}
			else
			{
				Convert.ToInt32 (output);
				return FormatToDecimal (output);
			}

		}
		//*******************************************************************************************************************************************
		public static string FormatToDecimal (Int16 inval)
		{
			// 1st we do a standard check to see what we got
			string output = "";
			string input = inval.ToString ( );
			output = ProcessAnyInt (input);
			string[] parts = output.Split ('.');
			char[] chars = parts[0].ToCharArray ( );
			output = AddCommas (chars);
			if ( output.Length == 0 )
				output = input; // no change
			if ( !output.Contains (".00") )
				output += ".00";
			return output;
		}
		//*******************************************************************************************************************************************
		public static string FormatToDecimal (Int32 inval)
		{
			// 1st we do a standard check to see what we got
			string output = "";
			string input = inval.ToString ( );
			output = ProcessAnyInt (input);
			char[] chars = output.ToCharArray ( );
			output = AddCommas (chars);
			if ( !output.Contains (".00") )
				output += ".00";
			return output;
		}
		//*******************************************************************************************************************************************
		public static string FormatToDecimal (Int64 inval)
		{
			// 1st we do a standard check to see what we got
			string output = "";
			string input = inval.ToString ( );
			output = ProcessAnyInt (input);
			char[] chars = output.ToCharArray ( );
			output = AddCommas (chars);
			if ( !output.Contains (".00") )
				output += ".00";
			return output;
		}
		//*******************************************************************************************************************************************
		public static string FormatToDecimal (decimal inval)
		{
			char[] ch = { '.' };
			string input = inval.ToString ( );
			string output = "";
			// handle the 'integer part 1st - same as othe rInts
			string[] parts = input.Split (ch);
			char[] chars = parts[0].ToCharArray ( );
			input = BuildStringFromChar (chars);
			output = ProcessAnyInt (input);
			chars = output.ToCharArray ( );
			output = AddCommas (chars);

			// handle the decimal part - if we have oine ?
			if ( parts.Length > 1 )
			{
				if ( parts[1].Length == 1 )
				{   // got a decimal point, just make it 2 digits                
					output += parts[0] + "." + parts[1] + "0";
				}
				else if ( parts[1].Length == 2 )
					output = parts[0] + "." + parts[1];
			}
			return output;
		}
		//*******************************************************************************************************************************************
		public static string FormatToDecimal (double inval)
		{
			char[] ch = { '.' };
			string input = inval.ToString ( );
			string output = "";
			// handle the 'integer part 1st - same as othe rInts
			string[] parts = input.Split (ch);
			char[] chars = parts[0].ToCharArray ( );
			input = BuildStringFromChar (chars);
			output = ProcessAnyInt (input);
			chars = output.ToCharArray ( );
			// this return the Int part with commas as needed, but no . or deimal part
			output = AddCommas (chars);

			// handle the decimal part - if we have oine ?
			if ( parts.Length > 1 )
			{
				if ( parts[1].Length == 1 )
				{   // got a decimal point, just make it 2 digits                
					output += parts[1] + "." + parts[1] + "0";
				}
				else if ( parts[1].Length == 2 )
					output = parts[0] + "." + parts[1];
			}
			return output;
		}
		public static void GenerateBankDataFile (int totalRequired, int delimindex)
		{
			char[] delims = { ',', '\t', ':', '~' };
			char delim = delims[delimindex];
			string delm = delims[delimindex].ToString ( );
			if ( delm == "\t" ) delm = "tab";
			if ( delm == "~" ) delm = "tilde";
			if ( delm == "," ) delm = "comma";
			if ( delm == ":" ) delm = "colon";
			string path = "C:\\Users\\ianch\\source\\C#SavedData\\BulkData\\DelimitedBankData(" + delm + ").txt";
			using ( TextWriter writer = File.CreateText (path) )
			{
				//				Random random = new System . Random ( 1 );
				Random random = new Random ((int)DateTime.Now.Ticks & 0x0000FFFF);
				int total = 0, count = 0;
				string[] actype = new string[60];
				while ( true )
				{
					// just 4 types
					int t = random.Next (1, 5);
					if ( t < 5 )
					{
						total++;
						actype[count] = t.ToString ( );
					}
					count++;
					if ( count == 60 ) break;
				}
				// we have 60  ac types in range 1-4 now.

				// trying for 60 options for balance
				decimal[] balance = {12.45M, 2.3M,10.8M, 5.42M, 2.5M, 1.9M, 50603.32M, 66.5M,7.8M, 3.45M, 425.21M, 7500M, 25125M,175.34M, 62859.99M, 9.65M, 6.7M, 4.53M, 9.83M, 12.32M,
										5.38M,4.45M, 9.32M, 3.32M, 6.68M, 10.00M,672.45M, 23000M,10.8M, 5.42M, 2.5M, 1.9M, 9.5M, 6.65M,7.8M, 3.45M, 5.21M, 7.5M, 2M,17.5M, 23.6M, 9.65M, 6.7M, 4.53M, 9.83M, 12.32M,
										538.32M,445M, 1000M, 3.32M, 668M, 10.00M, 450.21M, 934M,75389.48M,1.36M,903.24M,490035.78M,55.62M,12.88M, };
				DateTime[] opendate = new DateTime[60];
				count = 0; total = 0;
				while ( true )
				{
					int day = 0, month = 0, year = 0;
					string dstring = "";
					day = random.Next (1, 31);
					month = random.Next (1, 12);
					year = random.Next (1940, 2019);
					dstring = day + "/" + month + "/" + year;
					if ( month == 2 && day > 28 ) continue;
					if ( (month == 4 || month == 6 || month == 9 || month == 11) && day > 30 ) continue;
					DateTime date = Convert.ToDateTime (dstring);
					opendate[count++] = date;
					total++;
					if ( count >= 60 ) break;
				}
				// 30 interest options here
				decimal[] intrst = { 12.45M, 2.3M,10.8M, 5.42M, 2.5M, 1.9M, 9.5M, 6.65M,7.8M, 3.45M, 5.21M, 7.5M, 2M,17.5M, 23.6M, 9.65M, 6.7M, 4.53M, 9.83M, 12.32M,
						5.38M,4.45M, 9.32M, 3.32M, 6.68M, 10.00M, 5.7M, 8.32M, 2.54M, 5.38M};
				int[] status = new int[25];
				int check = 0;
				for ( int q = 0; q < 25; q++ )
				{
					check = random.Next (0, 2);
					if ( check < 2 )
						status[q] = check;
				}
				// now create the output file.
				for ( int i = 0; i < totalRequired; i++ )
				{
					string Output = $"{actype[random.Next (1, 60)].ToString ( )}{delim}{balance[random.Next (1, 60)].ToString ( )}{delim}{opendate[random.Next (1, 60)].ToString ( )}{delim}{intrst[random.Next (1, 30)].ToString ( )}{delim}{status[random.Next (1, 25)].ToString ( )}";
					writer.WriteLine (Output);
				}
				writer.Close ( );
			}
		}
		public static void GenerateCustomerDataFile (int totalRequired, int delimindex)
		{
			char[] delims = { ',', '\t', ':', '~' };
			char delim = delims[delimindex];
			string delm = delims[delimindex].ToString ( );
			if ( delm == "\t" ) delm = "tab";
			if ( delm == "~" ) delm = "tilde";
			if ( delm == "," ) delm = "comma";
			if ( delm == ":" ) delm = "colon";
			string path = "C:\\Users\\ianch\\source\\C#SavedData\\BulkData\\DelimitedCustData(" + delm + ").txt";

			using ( TextWriter writer = File.CreateText (path) )
			{
				Random random = new Random ((int)DateTime.Now.Ticks & 0x0000FFFF);
				for ( int i = 0; i < totalRequired; i++ )
				{
					random.Next (1, 155);
					string[] roads = { random. Next ( 1, 155 ).ToString() + " Windsor Rd",random. Next (1,105 ).ToString() + "  Buckingham Place",
					random. Next (1,105 ).ToString() + "  Faraday Place",random. Next (1,105 ).ToString() + " Wellington Terrace",random. Next (1,105 ).ToString() + " Smithsonian Way",
					random. Next (1,105 ).ToString() + " Flightline Drive",random. Next (1,105 ).ToString() + " Amey Johnson Way",random. Next (1,105 ).ToString() + " Cannibals road",
					random. Next (1,105 ).ToString() + " Regent Street",random. Next (1,105 ).ToString() + " Oxford St",random. Next (1,105 ).ToString() + " Piccadilly",
					random. Next (1,105 ).ToString() + " Lambeth Road",random. Next (1,105 ).ToString() + " Chiltern Way",random. Next (1,105 ).ToString() + " Ketchup avenue",
					random. Next (1,105 ).ToString() + " Brown Sauce Terrace",random. Next (1,105 ).ToString() + " Liitle hedges way",random. Next (1,105 ).ToString() + " Great Missenden Road",
					random. Next (1,105 ).ToString() + " Buckshot Lead",random. Next (1,105 ).ToString() + " Drambuie Way",random. Next (1,105 ).ToString() + " Google Plaza",
					random. Next (1,105 ).ToString() + " Dell Road",random. Next (1,105 ).ToString() + " Compaq Avenue",random. Next (1,105 ).ToString() + " Mistletoe way",
					random. Next (1,105 ). ToString ( ) + " LastEntry Close"};

					string[] towns = { " Aldershot",
					 "  Buckingham","  Edinburgh"," Wellington"," Shottley"," Bicester"," Arncott"," Brill"," Chinnor"," St Albanst"," St Annes on Sea"," Lytham St Annes"," Blackpool",
					" Eastcote"," lavington"," Oxford"," Cambridge"," Leicester"," Birmingham"," Lancaster"," New Brunswick"," Corrigador"," Christchurch"," Ely in the  Marsh"};

					string[] Countys = { random. Next (1,105 ).ToString()
					+ " Lancashire","  BuckinghamShire","  Waverley"," Highlands & Islands"," Dorset"," Devon"," Cornwall"," Brecon"," Aberystwith"," Anglesey"," Kent"," Sussex",
					" Norfolk"," Suffolk"," Lincolnshire"," Northumberland"," Durham"," Rutland"," Tyneside"," Teeside"," Cumbria"," Lakeland"," Orkneys"," Shetland Islands"};

					string[] lname = {
								"Williams","Jones","Turner","Wilkinson","Prosser","Sankey","Logan","Read","Hasselblad","Nikon","Konig","Edwards","Smith","Little","Large",
								"Handscombe","Paddock","Wilson","Dooley","Smythe","Mannering","Halton","Butcher","Baker","Ironmonger" };
					string[] fnames = {
								"John","William","Johan","Brian","Hal","Robert","Bob","Jack","Olwen","Elizabeth","Mary","Anne","Susan","Sue","Margaret",
								"Matt","Colin","Martyn","Martin","Jules","Johann","Peter","Joe","Tony","Ron ",};
					decimal[] bal = { 12.45M, 2300.10M, 567.42M, 25000M, 1000M, 90450M, 456M, 78M, 123.45M, 65321.99M, 7504.73M
									, 12000M, 17500M, 23600M, 9023.65M, 67.1M, 4.53M, 19.83M, 12.32M, 905.38M, 862.41M, 9.65M, 11.42M, 903.56M,100.01M,};

					decimal[] intrst = { 12.45M, 2.3M,10.8M, 5.42M, 2.5M, 1.9M, 9.5M, 6.65M,7.8M, 3.45M, 5.21M, 7.5M, 2M,17.5M , 23.6M, 9.65M, 6.7M, 4.53M, 9.83M, 12.32M, 5.38M,
										4.45M, 9.32M, 3.32M, 6.68M, 10.00M, };
					int[] pcode1 = { 1, 23, 54, 6, 9, 7, 3, 84, 23, 14, 17, 2, 45, 4, 90, 99, 35, 42, 3, 27, 5, 21, 32, 5, 7, };
					string[] pcode2 = { "AA", "CB", "FS", "HT", "FY", "SE", "WM", "ID", "ON", "NU", "QM", "PC", "CD", "AK", "KF", "VU", "WY", "XG", "GK", "SH", "XX", "YY", "ZZ", "AM", "YD", };
					int[] pcode3 = { 1, 23, 54, 76, 93, 7, 3, 84, 23, 14, 17, 21, 65, 34, 90, 99, 85, 42, 36, 27, 51, 21, 32, 5, 7, };
					int[] pcode4 = { 1, 2, 5, 7, 9, 6, 3, 4, 8, 10, 17, 21, 25, 34, 19, 27, 15, 22, };
					string[] addr2 = { " Cedar Tree Circle", " Torrington Condominiums", " Valley Circle", " Tarragon Way", " Piccaddily Way", " Oxenford", " Regis Way", "  Marshall Square"
											, " Sunshine Boulevard", " Everest Way", " Llangolen Route", " Capson Apex Place", " Liggard Square", " Smithway Estate", " Amy Smith", " Arlingon Square", " Rossal Way", "Upper Boulevard", " Litle Essex", " Nonsuch"
										, " Gatcombe Circle", " Standard Homes Estate", "Upper  Pinmill", " Paladin Square", " Trafalgar place", };

					int x = random.Next (1, 105);
					string addr = roads[random.Next (0, 24)].ToString ( );
					string pcode = pcode2[random.Next (0, 24)].ToString ( ) + pcode3[random.Next (0, 24)].ToString ( ) + " "
						+ pcode4[random.Next (0, 17)].ToString ( ) + pcode2[random.Next (0, 24)].ToString ( );
					string tel = "0" + random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( ) + " "
						+ random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( )
						+ random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( );
					string mob = "0" + random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( ) + " "
						+ random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( )
						+ random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( ) + random.Next (0, 9).ToString ( );
					string surname = lname[random.Next (0, 24)];
					string fname = fnames[random.Next (0, 24)];

					string Output = surname + delim + fname + delim + tel + delim + mob + delim + addr + delim + addr2[random.Next (0, 24)] + delim +
								towns[random.Next (0, 24)] + delim + Countys[random.Next (0, 24)] + delim + pcode;

					writer.WriteLine (Output);
				}
				writer.Close ( );
			}
		}
		
                public static bool SQLConnect()
                //**************************************************************************************************************************************************************************************
                {
                    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ianch\source\repos\\ClassAccessTest\ClassAccessTest\ian1.mdf;Integrated Security=True;Connect Timeout=30
                    cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ian1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//                    cnn = new SqlConnection("");
                    string t = connectionString;
                    try
                    {
                        cnn.Open();
                        SQLAccess.SQLconnection = true;
                        string login = cnn.ConnectionString;
                        return true;
                    }
                    catch
                    {
                        Bank.form1.Output2.AppendText("SQL connection encountered a problem, P:lease try again\r\n");
                        //throw new ESqlNotificationInfo();
                        SQLDisConnect();
                        return false;
                    }
                }
                //**************************************************************************************************************************************************************************************
                public static void SQLDisConnect()
                //**************************************************************************************************************************************************************************************
                {
                    try
                    {
                        if (cnn == null)
                            return;
                        cnn.Close();
        //                SQLAccess.SQLconnection = false;
                    }
                    catch { new Exception(" Failed to disconnect from SQL Server"); }
                }//*******************************************************************************************************************************************
            
	}
}
