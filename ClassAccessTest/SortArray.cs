using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClassAccessTest
{

	//************************************************************************
	public partial class SortArray : Form
	{
		public static int[] a = { 0, 0, 0, 0 };
		public SortArray ( )
		//************************************************************************
		{
			InitializeComponent ( );
		}

		private void SortArray_Load (object sender, EventArgs e)
		{
			a[0] = a[1] = a[2] = a[3] = 0;
			if ( Bank._badirection == 0 )
			{
				Info.ForeColor = Color.Black;
				Info.Text = "Normal - Ascending";
				a[0] = 0;
				Alpha.Enabled = false;
				Contra.Enabled = true;
			}
			else
			{
				Info.ForeColor = Color.Red;
				Info.Text = "Reversed - Descending";
				a[0] = 1;
				Alpha.Enabled = true;
				Contra.Enabled = false;
			}
			if ( Bank._bldirection == 0 )
			{
				Info2.ForeColor = Color.Black;
				Info2.Text = "Normal - Ascending";
				a[1] = 0;
				SLLnormal.Enabled = false;
				SLLreverse.Enabled = true;
			}
			else
			{
				Info2.ForeColor = Color.Red;
				Info2.Text = "Reversed - Descending";
				a[1] = 1;
				SLLreverse.Enabled = false;
				SLLnormal.Enabled = true;
			}

			if ( Bank._cadirection == 0 )
			{
				Custarrayinfo.ForeColor = Color.Black;
				Custarrayinfo.Text = "Normal - Ascending";
				a[2] = 0;
				Custarraynormal.Enabled = false;
				Custarrayreverse.Enabled = true;
			}
			else
			{
				Custarrayinfo.ForeColor = Color.Red;
				Custarrayinfo.Text = "Reversed - Descending";
				a[2] = 1;
				Custarrayreverse.Enabled = false;
				Custarraynormal.Enabled = true;
			}
			if ( Bank._cldirection == 0 )
			{
				Custllinfo.ForeColor = Color.Black;
				Custllinfo.Text = "Normal - Ascending";
				a[3] = 0;
				Custlistnormal.Enabled = false;
				Custlistreverse.Enabled = true;
			}
			else
			{
				Custllinfo.ForeColor = Color.Red;
				Custllinfo.Text = "Reversed - Descending";
				a[3] = 1;
				Custlistreverse.Enabled = false;
				Custlistnormal.Enabled = true;
			}
		}
		//************************************************************************
		public static void alpha_Click (object sender, EventArgs e)
		//************************************************************************
		{
			// Sort Bank array normal
			if ( Bank._badirection == 1 )
			{
				a[0] = 0;
				string msg = "Bank ArrayList Sort Order has been changed to Normal (Ascending)\r\n";
				SortBankArray (0);
				Bank.form1.ShowText (msg, a, 0);//the method defined in Bank
			}
		}
		//************************************************************************
		public static void contra_Click (object sender, EventArgs e)
		//************************************************************************
		{
			// Sort Bank array reversed
			if ( Bank._badirection == 0 )
			{
				a[0] = 1;
				string msg = "Bank ArrayList Sort Order has been changed to Reverse (Descending)\r\n";
				SortArray.SortBankArray (1);
				Bank.form1.ShowText (msg, a, 0);//the method defined in Bank
			}
		}

		//************************************************************************
		public static void LLreverse_Click_1 (object sender, EventArgs e)
		//************************************************************************
		{// Bank reverse linked list ?
			if ( Bank._bldirection == 0 )
			{
				Bank._bldirection = 1;
				a[1] = 1;
				string msg = "Bank LinkedList Sort Order has been changed to Reverse (Descending)\r\n";

				LinkedList<BankAccount> temp = new LinkedList<BankAccount> ( );    // Bank a/c list
				foreach ( BankAccount B in BankAccount.BankAccountsLinkedList )
				{ temp.AddFirst (B); }

				BankAccount.BankAccountsLinkedList.Clear ( );
				BankAccount.BankAccountsLinkedList = temp;
				Bank.form1.ShowText (msg, a, 1);//the method defined in Bank
			}
		}

		//************************************************************************
		public static void LLnormal_Click_1 (object sender, EventArgs e)
		//************************************************************************
		{ //Bank  linkedlist set to norrmal
			if ( Bank._bldirection == 1 )
			{
				Bank._bldirection = 0;
				a[1] = 0;
				string msg = "Bank LinkedList Sort Order has been changed to Normal (Ascending)\r\n";
				LinkedList<BankAccount> temp = new LinkedList<BankAccount> ( );    // Bank a/c list
				foreach ( BankAccount B in BankAccount.BankAccountsLinkedList )
				{ temp.AddFirst (B); }  // This actuuially reverses them into Temp

				BankAccount.BankAccountsLinkedList.Clear ( );
				// now just rpelace with the NEWLY sorted entries in temp
				BankAccount.BankAccountsLinkedList = temp;
				Bank.form1.ShowText (msg, a, 1);//the method defined in Bank
			}
		}

		//************************************************************************
		public static void custarrayreverse_Click_1 (object sender, EventArgs e)
		//************************************************************************
		{// LINKED LIST SWITCHING
		 // Sort Bank array normal
			if ( Bank._cadirection == 0 )
			{
				Bank._cadirection = 1;
				a[2] = 1;
				string msg = "Customer ArrayList Sort Order has been changed to Reverse (Descending)\r\n";
				SortCustArray (1);
				Bank.form1.ShowText (msg, a, 2);//the method defined in Bank
			}
		}

		//************************************************************************
		public static void custarraynormal_Click_1 (object sender, EventArgs e)
		//************************************************************************
		{
			// Sort Bank array normal
			Bank._cadirection = 0;
			a[2] = 0;
			string msg = "Customer ArrayList Sort Order has been changed to Normal (Ascending)\r\n";
			SortCustArray (0);
			Bank.form1.ShowText (msg, a, 2);//the method defined in Bank												
		}
		//************************************************************************
		public static void custlistnormal_Click (object sender, EventArgs e)
		//************************************************************************
		{
			if ( Bank._cldirection == 1 )
			{
				Bank._cldirection = 0;
				a[3] = 0;
				string msg = "Customer LinkedList Sort Order has been changed to Normal (Ascending)\r\n";
				SwitchCustList ( );
				Bank.form1.ShowText (msg, a, 3);//the method defined in Bank
			}
		}
		//************************************************************************
		public static void custlistreverse_Click (object sender, EventArgs e)
		//************************************************************************
		{
			if ( Bank._cldirection == 0 )
			{
				Bank._cldirection = 1;
				a[3] = 1;
				string msg = "Customer LinkedList Sort Order has been changed to Reverse (Descending)\r\n";
				SwitchCustList ( );
				Bank.form1.ShowText (msg, a, 3);//the method defined in Bank
			}
		}
		//************************************************************************
		public static void SwitchCustList ( )
		//************************************************************************
		{
			LinkedList<Customer> temp = new LinkedList<Customer> ( );    // Bank a/c list
			foreach ( Customer C in Customer.CustomersLinkedList )
			{ temp.AddFirst (C); }  // This actuuially reverses them into Temp
			Customer.CustomersLinkedList.Clear ( );
			// now just replace with the NEWLY sorted entries in temp
			Customer.CustomersLinkedList = temp;
		}
		//************************************************************************
		public static void SortCustArray (int direction)
		//************************************************************************
		{
			if ( direction == 1 )
			{
				Bank._bldirection = 1;
			}// set sort to alphabetical
			else
			{
				{
					Bank._bldirection = 0;
				}// set sort to alphabetical
			}
			SortCustListArray ( );

		}
		//************************************************************************
		public static void SortCustListArray ( )
		//************************************************************************
		{
			List<Customer> temp = new List<Customer> ( );
			// copy it all to Temp array
			int indx = DataArray.CustNo.Count;
			indx--;
			for ( int i = 0; i < DataArray.CustNo.Count; i++ )
			{
				temp.Add (DataArray.CustNo[indx--]);
			}
			DataArray.CustNo.Clear ( );
			Customer.CustDict.Clear ( );
			//			temp . CopyTo ( DataArray . CustNo );
			for ( int i = 0; i < temp.Count; i++ )
			{
				DataArray.CustNo.Add (temp[i]);
				if ( !Customer.CustDict.ContainsKey (temp[i].CustomerNumber) )
					Customer.CustDict.Add (temp[i].CustomerNumber, temp[i]);
			}
		}
		//************************************************************************
		public static void SortBankArray (int direction)
		//************************************************************************
		{
			if ( direction == 0 )
			{
				a[0] = 0;
				Bank._badirection = 0; // set sort to alphabetical
				DataArray.BankNo.Sort ( );
			}
			else
			{
				Bank._badirection = 1;// set sort to reverse alphabetical
				a[0] = 1;
				string msg = "Bank ArrayList Sort Order has been changed to Reverse (Descending\n)";
				Bank.form1.ShowText (msg, null, 0);//the method defined in Bank
				DataArray.BankNo.Sort ( );
			}
		}

		//************************************************************************
		private void close_Click_1 (object sender, EventArgs e)
		//************************************************************************
		{
			string msg = "One or more Sort orders may have been changed..\r\n";
			//int[] a  = new int[4];
			a[0] = a[1] = a[2] = a[3] = 0;
			if ( Bank._badirection == 1 )
				a[0] = 1;
			if ( Bank._bldirection == 1 )
				a[1] = 1;
			if ( Bank._cadirection == 1 )
				a[2] = 1;
			if ( Bank._cldirection == 1 )
				a[3] = 1;
			Bank.form1.ShowText (msg, a, 4);//the method defined in Bank
			Close ( );
		}
		//************************************************************************
		//************************************************************************
		//THESE ARE THE DIRECT CONTROL FROM SORTARRAY.CS
		//************************************************************************
		//************************************************************************

		//************************************************************************
		private void Alpha_Click_1 (object sender, EventArgs e)
		//************************************************************************
		{
			// Sort Bank array normal
			if ( Bank._badirection == 1 )
			{
				Bank._badirection = 0;
				a[0] = 0;
				string msg = "Bank ArrayList Sort Order has been changed to Normal (Ascending)\r\n";
				SortArray.SortBankArray (0);
				Info.Text = "Normal ( Ascending)";
				Info.ForeColor = Color.Black;
				Bank.form1.ShowText (msg, a, 0);//the method defined in Bank
				Alpha.Enabled = false;
				Contra.Enabled = true;
				Contra.Focus ( );
			}
		}

		//************************************************************************
		private void Contra_Click_1 (object sender, EventArgs e)
		//************************************************************************
		{
			// Sort Bank array reversed
			if ( Bank._badirection == 0 )
			{
				Bank._badirection = 1;
				a[0] = 1;
				string msg = "Bank ArrayList Sort Order has been changed to Reverse (Descending)\r\n";
				SortArray.SortBankArray (1);
				Info.Text = "Reverse ( Descending)";
				Info.ForeColor = Color.Red;
				Bank.form1.ShowText (msg, a, 0);//the method defined in Bank
				Alpha.Enabled = true;
				Contra.Enabled = false;
				Alpha.Focus ( );
			}
		}

		//************************************************************************
		private void SLLnormal_Click (object sender, EventArgs e)
		//************************************************************************
		{
			if ( Bank._bldirection == 1 )
			{
				Bank._bldirection = 0;
				a[1] = 0;
				string msg = "Bank LinkedList Sort Order has been changed to Normal (Ascending)\r\n";

				LinkedList<BankAccount> temp = new LinkedList<BankAccount> ( );    // Bank a/c list
				foreach ( BankAccount B in BankAccount.BankAccountsLinkedList )
				{ temp.AddFirst (B); }

				BankAccount.BankAccountsLinkedList.Clear ( );
				BankAccount.BankAccountsLinkedList = temp;
				Info2.ForeColor = Color.Black;
				Info2.Text = "Normal ( Ascending)";
				Bank.form1.ShowText (msg, a, 1);//the method defined in Bank
				SLLnormal.Enabled = false;
				SLLreverse.Enabled = true;
				SLLreverse.Focus ( );
			}
		}

		//************************************************************************
		private void SLLreverse_Click (object sender, EventArgs e)
		//************************************************************************
		{
			if ( Bank._bldirection == 0 )
			{
				Bank._bldirection = 1;
				a[1] = 1;
				string msg = "Bank LinkedList Sort Order has been changed to Reverse (Descending)\r\n";

				LinkedList<BankAccount> temp = new LinkedList<BankAccount> ( );    // Bank a/c list
				foreach ( BankAccount B in BankAccount.BankAccountsLinkedList )
				{ temp.AddFirst (B); }

				BankAccount.BankAccountsLinkedList.Clear ( );
				BankAccount.BankAccountsLinkedList = temp;
				Info2.ForeColor = Color.Red;
				Info2.Text = "Reverse ( Descending)";
				Bank.form1.ShowText (msg, a, 1);//the method defined in Bank
				SLLnormal.Enabled = true;
				SLLreverse.Enabled = false;
				SLLnormal.Focus ( );
			}
		}

		//************************************************************************
		private void Custarraynormal_Click (object sender, EventArgs e)
		//************************************************************************
		{
			// Sort Bank array normal
			if ( Bank._cadirection == 1 )
			{
				Bank._cadirection = 0;
				a[2] = 0;
				string msg = "Customer ArrayList Sort Order has been changed to Normal (Ascending)\r\n";
				SortCustArray (0);
				Custarrayinfo.ForeColor = Color.Black;
				Custarrayinfo.Text = "Normal ( Ascending)";
				Bank.form1.ShowText (msg, a, 2);//the method defined in Bank												
				Custarraynormal.Enabled = false;
				Custarrayreverse.Enabled = true;
				Custarrayreverse.Focus ( );
			}
		}
		//************************************************************************
		private void Custarrayreverse_Click_2 (object sender, EventArgs e)
		//************************************************************************
		{
			// Sort Bank array normal
			if ( Bank._cadirection == 0 )
			{
				Bank._cadirection = 1;
				a[2] = 1;
				string msg = "Customer ArrayList Sort Order has been changed to Reverse (Descending)\r\n";
				SortCustArray (1);
				Custarrayinfo.ForeColor = Color.Red;
				Custarrayinfo.Text = "Reverse ( Descending)";
				Bank.form1.ShowText (msg, a, 2);//the method defined in Bank
				Custarraynormal.Enabled = true;
				Custarrayreverse.Enabled = false;
				Custarraynormal.Focus ( );
			}
		}

		//************************************************************************
		private void Custlistnormal_Click_1 (object sender, EventArgs e)
		//************************************************************************
		{
			if ( Bank._cldirection == 1 )
			{
				Bank._cldirection = 0;
				a[3] = 1;
				string msg = "Customer LinkedList Sort Order has been changed to Normal (Ascending)\r\n";
				SwitchCustList ( );
				Custllinfo.ForeColor = Color.Black;
				Custllinfo.Text = "Normal ( Ascending)";
				Bank.form1.ShowText (msg, a, 3);//the method defined in Bank
				Custlistreverse.Enabled = true;
				Custlistnormal.Enabled = false;
				Custlistreverse.Focus ( );
			}
		}

		//************************************************************************
		private void Custlistreverse_Click_1 (object sender, EventArgs e)
		//************************************************************************
		{
			if ( Bank._cldirection == 0 )
			{
				Bank._cldirection = 1;
				a[3] = 0;
				string msg = "Customer LinkedList Sort Order has been changed Reverse (Descending)\r\n";
				SwitchCustList ( );
				Custllinfo.ForeColor = Color.Red;
				Custllinfo.Text = "Reverse ( Descending)";
				Bank.form1.ShowText (msg, a, 3);//the method defined in Bank
				Custlistnormal.Enabled = true;
				Custlistreverse.Enabled = false;
				Custlistnormal.Focus ( );
			}
		}
	}
}