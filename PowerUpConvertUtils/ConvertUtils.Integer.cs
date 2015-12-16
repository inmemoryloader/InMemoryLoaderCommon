using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Strings to integer.
		/// </summary>
		/// <returns>The to integer.</returns>
		/// <param name="toConvert">To convert.</param>
		public int StringToInteger(string toConvert)
		{
			int toInt;
			toInt = Convert.ToInt32(toConvert);
			return toInt;
		}
	}
}

