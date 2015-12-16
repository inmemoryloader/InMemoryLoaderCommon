using System;
using InMemoryLoaderBase;
using log4net;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Uppercases the first.
		/// </summary>
		/// <returns>The first.</returns>
		/// <param name="paramString">Parameter string.</param>
		public string UppercaseFirst(string paramString)
		{
			// Check for empty string.
			if (string.IsNullOrEmpty(paramString))
			{
				return string.Empty;
			}
			// Return char and concat substring.
			return char.ToUpper(paramString[0]) + paramString.Substring(1);
		}
		/// <summary>
		/// Lowercases the first.
		/// </summary>
		/// <returns>The first.</returns>
		/// <param name="paramString">Parameter string.</param>
		public string LowercaseFirst(string paramString)
		{
			// Check for empty string.
			if (string.IsNullOrEmpty(paramString))
			{
				return string.Empty;
			}
			// Return char and concat substring.
			return char.ToLower(paramString[0]) + paramString.Substring(1);
		}
	}
}

