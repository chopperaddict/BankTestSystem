//using Microsoft.Graph;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace ClassAccessTest
{
	//     THIS FILE IS ONLY TO TEST THE GENERIC COLLECTIONS <T> OPERATION
	//       IT IS CALLED FROM FORM1 AND DOES LIST AL THE VALUES AS EXPECTED.....
	public class CollectionTestClass<T>
	{
		// define an Array of Generic type with length 5  
		T[] obj = new T[10];
		int count = 0;

		// adding items mechanism into generic type  
		//========================================
		public void Add (T item)
		//========================================
		{
			//checking length  
			if ( count + 1 < 11 )
			{
				obj[count] = item;

			}
			count++;
		}
		//========================================
		//indexer for foreach statement iteration  
		public T this[int index]
		//========================================
		{
			get { return obj[index]; }
			set { obj[index] = value; }
		}

		//========================================
		public class test
		//========================================
		{
			public static int[] runit ( )
			{
				int[] intarray = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
				//instantiate generic with Integer  
				CollectionTestClass<int> intObj = new CollectionTestClass<int> ( );

				//adding integer values into collection  
				intObj.Add (1);
				intObj.Add (2);
				intObj.Add (3);     //No boxing  
				intObj.Add (4);
				intObj.Add (5);
				intObj.Add (6);
				intObj.Add (7);
				intObj.Add (8);
				intObj.Add (9);
				intObj.Add (10);

				//displaying values  
				for ( int i = 0; i < intObj.count; i++ )
				{
					intarray[i] = intObj[i];
				}
				return intarray;
			}
		}
	}// end CLASS
}
