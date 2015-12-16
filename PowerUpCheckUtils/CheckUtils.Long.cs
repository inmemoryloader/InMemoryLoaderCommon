using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpCheckUtils
{
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Determines whether this instance is string long the specified paramValue.
		/// </summary>
		/// <returns><c>true</c> if this instance is string long the specified paramValue; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool IsStringLong(object paramValue)
		{
			long result;
			return long.TryParse(paramValue.ToString(), out result);
		}
	}
}

