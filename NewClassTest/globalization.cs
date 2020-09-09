using System.Globalization;

namespace ClassAccessTest
{
	public static class Global
	{
		// CALL TO USE THIS IN CODE IS 
		//string CurrencyAmount = Utils.GetCurrencyString(string amount);
		public static string ToFormattedCurrencyString (this decimal currencyAmount, string isoCurrencyCode, CultureInfo userCulture)
		{
			var userCurrencyCode = new RegionInfo (userCulture.Name).ISOCurrencySymbol;
			userCulture = new CultureInfo ("en-GB", false);
			if ( userCurrencyCode == isoCurrencyCode )
			{
				return currencyAmount.ToString ("C", userCulture);
			}

			return string.Format ("{0} {1}", isoCurrencyCode, currencyAmount.ToString ("N2", userCulture));
		}
	}
}
