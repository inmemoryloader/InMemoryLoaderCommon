using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpCheckUtils
{
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Determines whether this instance is object null the specified obj.
		/// </summary>
		/// <returns><c>true</c> if this instance is object null the specified obj; otherwise, <c>false</c>.</returns>
		/// <param name="obj">Object.</param>
		public bool IsObjectNull(object obj)
		{
			if (obj == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// Determines whether this instance is string null or empty the specified paramValue.
		/// </summary>
		/// <returns><c>true</c> if this instance is string null or empty the specified paramValue; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool IsStringNullOrEmpty(object paramValue)
		{
			if (IsObjectNull(paramValue)) return true;
			if (IsStringEmpty(paramValue)) return true;
			return false;
		}
		/// <summary>
		/// Determines whether this instance is string empty the specified paramValue.
		/// </summary>
		/// <returns><c>true</c> if this instance is string empty the specified paramValue; otherwise, <c>false</c>.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool IsStringEmpty(object paramValue)
		{
			if (paramValue.ToString() == string.Empty) return true;
			return false;            
		}
	}
}

