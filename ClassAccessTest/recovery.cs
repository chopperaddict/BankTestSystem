using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace ClassAccessTest
{
	class recovery
	{
		public static event EventHandler<string> BankListChangedEvent;

		public static int RebuildBankDataFromTextFiles ( )
		//************************************************************************************************************************************************
		{
			// iterate thru reading bankaccount objects from disk and add them to our LinkedList and /BankArray
			int count = 0;
			string dir = BankAccount.ReadBankFilePath ( );
			dir += "Textfiles\\";
			string[] files = Directory.GetFiles (dir);
			// clear the lists- JIC
			DataArray.ArrayClearBank ( );    // Clear ( );
			BankAccount.BankAccountsLinkedList.Clear ( );

			foreach ( var fi in files )
			{
				bool result = fi.Contains ("BankObject");
				if ( !result )
					continue;
				else
				{

					string input = File.ReadAllText (fi);
					char[] ch = { ',' };
					string[] items = input.Split (ch);
					BankAccount B = new BankAccount ( );
					B.BankAccountNumber = Convert.ToInt32 (items[0]);
					B.CustAccountNumber = Convert.ToInt32 (items[1]);
					B.AccountType = Convert.ToInt16 (items[2]);
					B.Balance = Convert.ToDecimal (items[3]);
					B.DateOpened = Convert.ToDateTime (items[4]);
					B.DateClosed = Convert.ToDateTime (items[5]);
					B.Balance = Convert.ToDecimal (items[6]);
					B.Status = Convert.ToInt16 (items[7]);
					//Write it back as OBj and TXT - yes even though we onlt just read it in.
					SerializeData.WriteBankAccountToDiskAndText (B, B.FullFileName);
					// add each one to our new List so we cna use the Enumeration later
					try
					{
						BankAccount.BankAccountsLinkedList.AddLast (B);
						DataArray.ArrayAddBank (B);
						if (BankAccount.BankDict != null)
						{
							if (!BankAccount.BankDict.ContainsKey( B.BankAccountNumber ))
								BankAccount.BankDict.Add( B.BankAccountNumber, B );
						}
					}
					catch
					{ new Exception (" Failed to update LinkeList or Bank array in RebuildBankDataFromTextFiles at line 311"); }
					count++;
					B.Dispose ( );
				}
			}
			// This saves the bank LinkedList to both an object file and a Text file
			Lists.SaveAllBankAccountListData ( );
			BankListChangedEvent?.Invoke (null, "ALLDATA REBUILT FROM TEXTFILES");
			return count;
		}
	}
}
