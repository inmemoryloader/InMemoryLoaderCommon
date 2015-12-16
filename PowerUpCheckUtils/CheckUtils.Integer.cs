using System;
using log4net;
using PowerUpBase;
using System.Globalization;

namespace PowerUpCheckUtils
{
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Determines whether this instance is string int the specified paramValue.
		/// </summary>
		/// <returns><c>true</c> if this instance is string int the specified paramValue; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool IsStringInt(object paramValue)
		{
			int result;
			return int.TryParse(paramValue.ToString(), NumberStyles.Integer, null, out result);
		}
		/// <summary>
		/// Determines whether this instance is string int the specified paramValue provider.
		/// </summary>
		/// <returns><c>true</c> if this instance is string int the specified paramValue provider; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		/// <param name="provider">Provider.</param>
		public bool IsStringInt(object paramValue, IFormatProvider provider)
		{
			int result;
			return int.TryParse(paramValue.ToString(), NumberStyles.Integer, provider, out result);
		}
	}
}

