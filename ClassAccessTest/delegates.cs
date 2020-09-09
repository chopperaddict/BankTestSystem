using System;

namespace ClassAccessTest
{
	namespace delegates
	{

		// THIS WORKS......
		// A GOOD PATTERN TO WORK FROM
		// EVEN THOUGH IT CAME FROM A PAKISTANI.........
		// He knew how to explain it simply......
		class delegates
		{
			//*******************************************************
			// This is what is called to trigger our Delegate 
			/*
			 ********This is the code we implement in the main application code.***********
			 * 			HelloFunctionDelegate del = new HelloFunctionDelegate ( Hello );
						del ( "Hello from Delegate" );
			 */
			public static void Hello (string strMessage)
			{
				//*******************************************************
				int count = 0;
				Bank.form1.Output2.AppendText (strMessage);
				Bank.form1.Output2.ScrollToCaret ( );
				for ( int i = 0; i < 100; i++ )
				{
					if ( count % 10 == 0 )
					{
						Bank.form1.Output2.AppendText ("Delegate reporting our loop counter of " + i.ToString ( ));
						Bank.form1.Output2.ScrollToCaret ( );
					}
					count++;
					Bank.form1.Output2.AppendText (" Thats it, all done......\r\n");
				}
			}// END CLASS PROGRAM
			 //*******************************************************
			 //*******************************************************


			//--------------------------------------------------------------------------------
			//--------------------------------------------------------------------------------
			public class MyClass
			{
				public delegate void dCallBack (int i);
				//+++++++++++++++++++++++++++++++++++++++++
				public void LongRunning (dCallBack obj)
				//+++++++++++++++++++++++++++++++++++++++++
				{
					for ( int i = 0; i < 1; i++ )
					{
						obj (i);
						Console.WriteLine ("Still running - counter is " + i.ToString ( ) + "\r\n");
					}
				}
			}   // END CLASS MYCLASS
				//--------------------------------------------------------------------------------
				//--------------------------------------------------------------------------------

		}
	}
}
