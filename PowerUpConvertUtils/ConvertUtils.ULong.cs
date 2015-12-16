using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Strings to U long.
		/// </summary>
		/// <returns>The to U long.</returns>
		/// <param name="toConvert">To convert.</param>
		public ulong StringToULong(string toConvert)
		{
			ulong toInt;
			toInt = Convert.ToUInt64(toConvert);
			return toInt;
		}
	}
}

