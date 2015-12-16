using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Strings to decimal.
		/// </summary>
		/// <returns>The to decimal.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public decimal StringToDecimal(string paramValue)
		{
			decimal dec;
			dec = Convert.ToDecimal(paramValue);
			return dec;
		}
	}
}

