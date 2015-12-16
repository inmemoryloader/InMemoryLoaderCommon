using System;
using log4net;
using PowerUpBase;
using System.Globalization;

namespace PowerUpCheckUtils
{
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Determines whether this instance is string double the specified paramValue.
		/// </summary>
		/// <returns><c>true</c> if this instance is string double the specified paramValue; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool IsStringDouble(object paramValue)
		{
			double result;
			return double.TryParse(paramValue.ToString(), out result);
		}
	}
}

