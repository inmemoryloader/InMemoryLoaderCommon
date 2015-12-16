using System;
using log4net;
using PowerUpBase;
using System.Globalization;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Strings to long.
		/// </summary>
		/// <returns>The to long.</returns>
		/// <param name="toConvert">To convert.</param>
		public long StringToLong(string toConvert)
		{
			long toInt;
			toInt = Convert.ToInt64(toConvert);
			return toInt;

		}
	}
}

