using System;
using PowerUpBase;
using log4net;
using System.Text.RegularExpressions;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Counts the occurence of string.
		/// </summary>
		/// <returns>The occurence of string.</returns>
		/// <param name="source">Source.</param>
		/// <param name="match">Match.</param>
		public long CountOccurenceOfString(string source, string match)
		{
			return Regex.Matches(source, @match).Count;
		}
	}
}

