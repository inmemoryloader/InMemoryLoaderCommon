using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpCheckUtils
{
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Determines whether this instance is string decimal the specified paramValue.
		/// </summary>
		/// <returns><c>true</c> if this instance is string decimal the specified paramValue; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool IsStringDecimal(object paramValue)
		{
			decimal result;
			return decimal.TryParse(paramValue.ToString(), NumberStyles.AllowDecimalPoint, null, out result);
		}
		/// <summary>
		/// Determines whether this instance is string decimal the specified paramValue provider.
		/// </summary>
		/// <returns><c>true</c> if this instance is string decimal the specified paramValue provider; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		/// <param name="provider">Provider.</param>
		public bool IsStringDecimal(object paramValue, IFormatProvider provider)
		{
			decimal result;
			return decimal.TryParse(paramValue.ToString(), NumberStyles.AllowDecimalPoint, provider, out result);
		}
	}
}

