using System;
using log4net;
using PowerUpBase;
using System.Globalization;

namespace PowerUpCheckUtils
{
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Determines whether this instance is string float the specified paramValue.
		/// </summary>
		/// <returns><c>true</c> if this instance is string float the specified paramValue; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool IsStringFloat(object paramValue)
		{
			float result;
			return float.TryParse(paramValue.ToString(), NumberStyles.Float, null, out result);
		}
		/// <summary>
		/// Determines whether this instance is string float the specified paramValue provider.
		/// </summary>
		/// <returns><c>true</c> if this instance is string float the specified paramValue provider; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		/// <param name="provider">Provider.</param>
		public bool IsStringFloat(object paramValue, IFormatProvider provider)
		{
			float result;
			return float.TryParse(paramValue.ToString(), NumberStyles.Float, provider, out result);
		}
	}
}

