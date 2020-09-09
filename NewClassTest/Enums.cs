using System.Collections.Generic;

namespace ClassAccessTest
{
	class Enums
	{
		public static IEnumerable<int> OddNumbers (int max)
		{
			int i = 1;
			while ( i < (max * 2) )
			{
				yield return i;
				i += 2;
			}
		}
		static void OddNumbers ( )
		{
			string x = "";
			// this works just fine....  see Enums for configuration
			foreach ( int i in Enums.OddNumbers (650) )
			{
				x += i.ToString ( );
			}
		}

		public static IEnumerable<int> ListData ( )
		{
			int i = 1;
			while ( true )
			{
				yield return i;
				i++;
			}
		}
		/*		public static IEnumerable<int>ListData( )
                {
                    foreach( int i in DataArray . BankNo)
                    {
                        yield return i++;
                    }
                }
        */
	}
}