using System;
using log4net;
using PowerUpBase;
using System.Globalization;

namespace PowerUpCheckUtils
{
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Determines whether this instance is string byte the specified paramValue.
		/// </summary>
		/// <returns><c>true</c> if this instance is string byte the specified paramValue; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool IsStringByte(object paramValue)
		{
			byte result;
			return byte.TryParse(paramValue.ToString(), out result);
		}
		/// <summary>
		/// Determines whether this instance is string byte the specified paramValue paramNumberStyles.
		/// </summary>
		/// <returns><c>true</c> if this instance is string byte the specified paramValue paramNumberStyles; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		/// <param name="paramNumberStyles">Parameter number styles.</param>
		public bool IsStringByte(object paramValue, NumberStyles paramNumberStyles)
		{
			byte result;
			return byte.TryParse(paramValue.ToString(), paramNumberStyles, null, out result);
		}
		/// <summary>
		/// Determines whether this instance is string byte the specified paramValue paramNumberStyles paramIFormatProvider.
		/// </summary>
		/// <returns><c>true</c> if this instance is string byte the specified paramValue paramNumberStyles paramIFormatProvider;
		/// otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		/// <param name="paramNumberStyles">Parameter number styles.</param>
		/// <param name="paramIFormatProvider">Parameter I format provider.</param>
		public bool IsStringByte(object paramValue, NumberStyles paramNumberStyles, IFormatProvider paramIFormatProvider)
		{
			byte result;
			return byte.TryParse(paramValue.ToString(), paramNumberStyles, paramIFormatProvider, out result);
		}
	}
}

