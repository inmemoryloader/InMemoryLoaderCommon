using System;
using InMemoryLoaderBase;
using log4net;
using System.Text.RegularExpressions;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Splits the string.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="source">Source.</param>
		/// <param name="split">Split.</param>
		public string[] SplitString(string source, char split)
		{
			string[] words = source.Split(split);
			return words;
		}
	}
}

