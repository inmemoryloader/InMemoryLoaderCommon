using System;
using log4net;
using PowerUpBase;
using System.Globalization;

namespace PowerUpCheckUtils
{
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Determines whether this instance is string date the specified paramValue.
		/// </summary>
		/// <returns><c>true</c> if this instance is string date the specified paramValue; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool IsStringDate(object paramValue)
		{
			DateTime result;
			return DateTime.TryParse(paramValue.ToString(), out result);
		}
		/// <summary>
		/// Determines whether this instance is string date the specified paramValue provider.
		/// </summary>
		/// <returns><c>true</c> if this instance is string date the specified paramValue provider; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		/// <param name="provider">Provider.</param>
		public bool IsStringDate(object paramValue, IFormatProvider provider)
		{
			DateTime result;
			return DateTime.TryParse(paramValue.ToString(), provider, DateTimeStyles.AssumeLocal, out result);
		}
	}
}

