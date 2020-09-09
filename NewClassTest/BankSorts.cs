using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassAccessTest
{
    class BankSorts
    {
        //===================================================================
        // Utility Function  that sorts BankAccounts from Asc to Desc order
        public static BankAccount[] SortDesc(BankAccount[] secondkey)
        //===================================================================
        {
            // sort out incoming BankAccount[]  from Asc to Desc
            int max = secondkey.Count();
            BankAccount[] output = new BankAccount[max];
            for (int y = 0; y < max; y++)
                output[y] = null;    // create the blank array for our results
            int outcount = max - 1, incount = 0;

            for (int i = max - 1; i >= 0; i--)
            {
                output[outcount--] = secondkey[incount++];
            }
            // now, our output BankAccount[] should be sorted in Descending order
            return output;
        }
        //===================================================================
        public static void SortBankbyACType(bool dir)
        //===================================================================
        {
            // Sort by A/C type ?
            int x = DataArray.BankNo.Count();
            int max = x;
            int nullcount = 0;
            Bank.form1.ShowText("Processing " + x.ToString() + " BankNo records\r\n", null, 5);
            List<Int16> input = new List<Int16>();
            List<Int16> secondkey = new List<Int16>();
            BankAccount[] output = new BankAccount[x];
            //Now sort Int16's into ascending order
            input.Sort();   // This seems to work
            int listcount = 0; int bacount = 0;
            //			int i = 0;
            // Now sort the bankaccounts based on our sorted Int16 List
            while (true)
            {
                foreach (BankAccount B in DataArray.BankNo)
                {
                    if (B != null)
                    {
                        if (B.AccountType == listcount)
                        {

                            output[bacount++] = B;
                            if (dir)
                            {
                                // add the account type into our temporary list so we can reverse it
                                secondkey.Add(B.AccountType);
                            }
                        }
                    }
                    else
                        nullcount++;
                }
                if (output.Count() > 15)
                {
                    Bank.form1.ShowText("Interim record count is " + output.Count().ToString() + "\r\n", null, 5);
                    Bank.form1.ShowText("bacount is " + bacount.ToString() + "\r\n", null, 5);
                }
                // we need ot get the next on
                if (listcount == 4)
                    break;
                else
                    listcount++;
            }
            // by now, output holds BankAccount Obj in a BankAccount[]
            // and secondkey is a List<Int16> in Asc order
            DataArray.BankNo.Clear();
            if (dir)
            {   // we have been asked for it in Descending order
                // output[] holds BankAccounts sorted in ascending order
                // force our temp List<Int16> of Account types into the same asc order and assign it to input
                BankAccount[] descbankaccounts = new BankAccount[max];
                descbankaccounts = SortDesc(output);
                //now we have all the BankAccount in descbankaccounts[] in desc order 
                // we need ot get he 
                // now spit them back out again in reverse order (desc) to our main ListArray DataArray.BankNo
                foreach (BankAccount Bk in descbankaccounts)
                    DataArray.BankNo.Add(Bk);
                Bank.form1.ShowText("The Bank A/C Array data has been resorted into [Descending Account types]\r\n", null, 5);
            }
            else
            {
                // This is performed for both sort options
                foreach (BankAccount B in output)
                {
                    if (B != null)
                        DataArray.BankNo.Add(B);
                    else nullcount++;

                }
                Bank.form1.ShowText("The Bank A/C Array data has been resorted into [Ascending Account types]\r\n", null, 5);
            }
            Bank.form1.ShowText("Final record count is " + DataArray.BankNo.Count.ToString() + "\r\n", null, 5);
            if (nullcount > 0)
                Bank.form1.ShowText("ERROR IDENTIFIED - There were " + nullcount.ToString() + " null entries included\r\n", null, 5);
        }
        //===================================================================
        public static void SortBankbyBalance(bool dir)
        //===================================================================
        {// Sort by A/C balance?
            int max = DataArray.BankNo.Count();
            int nullcount = 0;
            Bank.form1.ShowText("Processing " + max.ToString() + " BankNo records\r\n", null, 5);
            List<BankAccount> output = new List<BankAccount>();
            //			BankAccount [ ] output = new BankAccount [  ];
            List<decimal> input = new List<decimal>();
            // load the List
            foreach (BankAccount B in DataArray.BankNo)
            {
                if (B != null)
                    input.Add(B.Balance);
                else
                {
                    nullcount++; continue;
                }
            }
            if (input.Count() != max)
                Bank.form1.ShowText("PROBLEM ?  input[] contains " + input.Count().ToString() + ", while BankNo has " + max.ToString() + " records.\r\n", null, -1);
            nullcount = 0;
            if (input.Count() != max)
            { Bank.form1.ShowText("PROBLEM 2  input has" + input.Count().ToString() + " while max was " + max.ToString() + "\r\n", null, -1); }

            //Now sort doubles's into ascending order
            input.Sort();   // This seems to work, puts them into alpha sequence I think
            int bacount = 0;
            decimal curentvalue = input[0];
            int passes = 0;
            int indx = 0;
            int counter = 0;
            // OK so far to here 6/9/2019
            // Now sort the bankaccounts based on our sorted Int16 List
            while (true)
            {
                foreach (BankAccount B in DataArray.BankNo)
                {
                    //**********************************************
                    // our missing a/c gets lost in this loop
                    //**********************************************
                    if (B == null)
                    {
                        Bank.form1.ShowText("PROBLEM  BankNo contains a null at iteration " + counter.ToString() + ".\r\n", null, -1);
                        break;
                    }
                    else
                        counter++;
                    if (B.Balance == curentvalue)
                    {// only interested in balances matching  our input[] values, which are sorted
                     // the rest will come in in due course
                     // got the match,so bustout to the while(true) 
                     // and iterate thru the BankNo again for next one
                        if (B.Balance == curentvalue)
                        {
                            output.Add(B);
                            if(indx < max - 1)
                            indx++;
                            curentvalue = input[indx];     // blank it to save processing time
                        }
                        break;
                    }
                    passes++;
                }   // end for()

                if (output.Count == DataArray.BankNo.Count) break;      // were there, bust out
            }       // end While (true)

            if (output.Count() != max)
            {
                Bank.form1.ShowText("Interim record count is " + output.Count().ToString() + ", but BankNo has " + max.ToString() + " records !!\r\n", null, 5);
                Bank.form1.ShowText("bacount is " + bacount.ToString() + "\r\n", null, 5);
            }               // we need to get the next balance
            if (dir)
            {
                // gotta sort it to Descending
                // We have it in ASC order in  BankAccount[] output
                BankAccount[] BK = new BankAccount[max];
                int upcount = 0;
                for (int w = output.Count() - 1; w >= 0; w--)
                {
                    BK[upcount++] = output[w];
                }
                // nowBK holds the Desc sorted data
                // so get it into  DataArray.BankNo
                DataArray.BankNo.Clear();
                int cnt = BK.Count();
                for (int w = 0; w < cnt; w++)
                    DataArray.BankNo.Add(BK[w]);
                Bank.form1.ShowText("The Bank A/C Array data has been resorted into [Descending A/c Balance] order\r\n", null, 5);
                Bank.form1.ShowText("BK Count is " + cnt.ToString() + " output[] .Count is " + output.Count().ToString() + "\r\n", null, 5);
            }
            else
            {
                nullcount = 0;
                DataArray.BankNo.Clear();
                foreach (BankAccount B in output)
                {
                    if (B != null)
                        DataArray.BankNo.Add(B);
                    else
                        nullcount++;
                }
                Bank.form1.ShowText("The Bank A/C Array data has been resorted into [Ascending A/c Balance] order\r\n", null, 5);
            }
            Bank.form1.ShowText("interim BankNo count is " + DataArray.BankNo.Count.ToString() + "\r\n", null, 5);
            //			if ( nullcount > 0 )
            //			Bank. form1 . ShowText ( "ERROR IDENTIFIED - There were " + nullcount . ToString ( ) + " null entries included\r\n", null, 5 );
        }
        //===================================================================
        public static void SortBankbyCustomer(bool dir)
        //===================================================================
        {// Sort by A/C balance?
            int max = DataArray.BankNo.Count();
            int nullcount = 0;
            Bank.form1.ShowText("Processing " + max.ToString() + " BankNo records\r\n", null, 5);
            List<BankAccount> output = new List<BankAccount>();
            //			BankAccount [ ] output = new BankAccount [  ];
            List<decimal> input = new List<decimal>();
            // load the List
            foreach (BankAccount B in DataArray.BankNo)
            {
                if (B != null)
                    input.Add(B.CustAccountNumber);
                else
                {
                    nullcount++; continue;
                }
            }
            if (input.Count() != max)
                Bank.form1.ShowText("PROBLEM ?  input[] contains " + input.Count().ToString() + ", while BankNo has " + max.ToString() + " records.\r\n", null, -1);
            nullcount = 0;
            if (input.Count() != max)
            { Bank.form1.ShowText("PROBLEM 2  input has" + input.Count().ToString() + " while max was " + max.ToString() + "\r\n", null, -1); }

            //Now sort doubles's into ascending order
            input.Sort();   // This seems to work, puts them into alpha sequence I think
            int bacount = 0;
            decimal curentvalue = input[0];
            int passes = 0;
            int indx = 0;
            int counter = 0;
            // OK so far to here 6/9/2019
            // Now sort the bankaccounts based on our sorted Int16 List
            while (true)
            {
                foreach (BankAccount B in DataArray.BankNo)
                {
                    //**********************************************
                    // our missing a/c gets lost in this loop
                    //**********************************************
                    if (B == null)
                    {
                        Bank.form1.ShowText("PROBLEM  BankNo contains a null at iteration " + counter.ToString() + ".\r\n", null, -1);
                        break;
                    }
                    else
                        counter++;
                    if (B.CustAccountNumber >= curentvalue)
                    {// only interested in balances matching  our input[] values, which are sorted
                     // the rest will come in in due course
                        if (B.CustAccountNumber == input[indx])//input[] holds the DECIMAL Bank balance value
                        {
                            output.Add(B);
                            curentvalue = B.CustAccountNumber;     // blank it to save processing time
                            if (indx == max)  // BankNo count - 1
                                break;
                            else
                                indx++;
                        }
                        else nullcount++;
                    }
                    passes++;
                }   // end for()

                if (indx == DataArray.BankNo.Count) break;
            }       // end While (true)

            if (output.Count() != max)
            {
                Bank.form1.ShowText("Interim record count is " + output.Count().ToString() + ", but BankNo has " + max.ToString() + " records !!\r\n", null, 5);
                Bank.form1.ShowText("bacount is " + bacount.ToString() + "\r\n", null, 5);
            }               // we need to get the next balance
            if (dir)
            {
                // gotta sort it to Descending
                // We have it in ASC order in  BankAccount[] output
                BankAccount[] BK = new BankAccount[max];
                int upcount = 0;
                for (int w = output.Count() - 1; w >= 0; w--)
                {
                    BK[upcount++] = output[w];
                }
                // nowBK holds the Desc sorted data
                // so get it into  DataArray.BankNo
                DataArray.BankNo.Clear();
                int cnt = BK.Count();
                for (int w = 0; w < cnt; w++)
                    DataArray.BankNo.Add(BK[w]);
                Bank.form1.ShowText("The Bank A/C Array data has been resorted into [Descending A/c Balance] order\r\n", null, 5);
                Bank.form1.ShowText("BK Count is " + cnt.ToString() + " output[] .Count is " + output.Count().ToString() + "\r\n", null, 5);
            }
            else
            {
                nullcount = 0;
                DataArray.BankNo.Clear();
                foreach (BankAccount B in output)
                {
                    if (B != null)
                        DataArray.BankNo.Add(B);
                    else
                        nullcount++;
                }
                Bank.form1.ShowText("The Bank A/C Array data has been resorted into [Ascending A/c Balance] order\r\n", null, 5);
            }
            Bank.form1.ShowText("interim BankNo count is " + DataArray.BankNo.Count.ToString() + "\r\n", null, 5);



            /*			int x = DataArray . BankNo . Count ( );
						int max = x;
						int nullcount = 0;
						Bank. form1 . ShowText ( "Processing " + x . ToString ( ) + " BankNo records\r\n", null, 5 );
						List<Int32> input = new List<Int32> ( );
						// load the List
						List<Customer> output = new List<Customer> ( );

						foreach ( BankAccount B in DataArray . BankNo )
						{ input . Add ( B . CustAccountNumber ); }
						//Now sort Int32's into ascending order
						input . Sort ( );   // This seems to work
						int bacount = 0;
						Int32 curentvalue = input [ 0 ];
						int indx = 0;
						// Now sort the bankaccounts based on our sorted Int32List
						while ( true )
						{
							foreach ( BankAccount B in DataArray . BankNo )
							{
								if ( B != null )
								{
									if ( B . CustAccountNumber == input [ indx ] )
									{
										output .Add(B);
										curentvalue = B . CustAccountNumber;
										indx++;
										if ( indx == max - 1 )  // max = BankNo total !
											break;
									}
								}
								else nullcount++;
							}
							if ( output . Count ( ) > 15 )
							{
								Bank. form1 . ShowText ( "Interim record count is " + output . Count ( ) . ToString ( ) + "\r\n", null, 5 );
								Bank. form1 . ShowText ( "bacount is " + bacount . ToString ( ) + "\r\n", null, 5 );
							}               // we need to get the next balance
											//				indx++;
							if ( indx >= max - 1 ) break;   // max = BankNo count 
						}
						if ( dir )
						{
							// gotta sort it to Descending
							// We have it in ASC order in  BankAccount[] output
							int cnt = output . Count ( );
							BankAccount [ ] BK = new BankAccount [ cnt ];
							int upcount = 0;
							for ( int w = cnt - 1 ; w >= 0 ; w-- )
							{
								BK [ upcount++ ] = output [ w ];
							}
							// nowBK holds the Desc sorted data
							// so get it into  DataArray.BankNo
							DataArray . BankNo . Clear ( );
							for ( int w = 0 ; w < cnt ; w++ )
								DataArray . BankNo . Add ( BK [ w ] );
							Bank. form1 . ShowText ( "The Bank A/C Array data has been resorted into [Descending Customer #] order\r\n", null, 5 );
						}
						else
						{
							DataArray . BankNo . Clear ( );
							foreach ( BankAccount B in output )
							{
								if ( B != null )
									DataArray . BankNo . Add ( B );
								else
									nullcount++;
							}
							Bank. form1 . ShowText ( "The Bank A/C Array data has been resorted into [Descending Customer #] order\r\n", null, 5 );
						}
						Bank. form1 . ShowText ( "Final record count is " + DataArray . BankNo . Count . ToString ( ) + "\r\n", null, 5 );
						if ( nullcount > 0 )
							Bank. form1 . ShowText ( "ERROR IDENTIFIED - There were " + nullcount . ToString ( ) + " null entries included\r\n", null, 5 );
			*/
        }

        //===================================================================
        public static void SortbyCustomerNumber(bool dir)
        //===================================================================
        {
            // Sort by Customer #?
            int x = DataArray.BankNo.Count();
            Bank.form1.ShowText("Processing " + x.ToString() + " BankNo records\r\n", null, 5);
            List<Int32> input = new List<Int32>();
            BankAccount[] output = new BankAccount[x];
            // load the List
            foreach (BankAccount B in DataArray.BankNo)
            { input.Add(B.CustAccountNumber); }
            //Now sort doubles's into ascending order
            input.Sort();   // This seems to work
            int bacount = 0;
            decimal curentvalue = 0.00M;
            int nullcount = 0;
            int indx = 0;
            // Now sort the bankaccounts based on our sorted Int16 List
            while (true)
            {
                foreach (BankAccount B in DataArray.BankNo)
                {
                    if (B.CustAccountNumber == input[indx])
                    {
                        if (B != null)
                        {
                            output[bacount++] = B;
                            curentvalue = B.CustAccountNumber;    // blank it to save processing time
                            curentvalue += 1;
                        }
                        else nullcount++;
                    }
                }
                if (output.Count() > 15)
                {
                    Bank.form1.ShowText("Interim record count is " + output.Count().ToString() + "\r\n", null, 5);
                    Bank.form1.ShowText("bacount is " + bacount.ToString() + "\r\n", null, 5);
                }
                // we need to get the next balance
                indx++;
                if (indx == DataArray.BankNo.Count) break;
            }
            DataArray.BankNo.Clear();
            foreach (BankAccount B in output)
            {
                if (B != null)
                    DataArray.BankNo.Add(B);
                else
                    nullcount++;
            }
            Bank.form1.ShowText("Final record count is " + DataArray.BankNo.Count.ToString() + "\r\n", null, 5);
            //			BAsort . Text = " [Customer A/C #] ";
            Bank.form1.ShowText("The Bank A/C Array data has been resorted into [Ascending Customer# order]\r\n", null, 5);
            if (nullcount > 0)
                Bank.form1.ShowText("ERROR IDENTIFIED - There were " + nullcount.ToString() + " null entries included\r\n", null, 5);
        }

    }
}
