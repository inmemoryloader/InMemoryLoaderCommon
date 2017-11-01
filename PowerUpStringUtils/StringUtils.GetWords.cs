using System;
using InMemoryLoaderBase;
using log4net;
using System.Text.RegularExpressions;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Extrahiert alle Wörter aus einem String
		/// </summary>
		/// <param name="source">Der String</param>
		/// <returns>Gibt ein String-Array mit den einzelnen Wörtern zurück</returns>
		public string[] GetWords(string source)
		{
			// Alle Wörter abfragen
			MatchCollection matches = Regex.Matches(source, @"\w{1,}");

			// Die MatchCollection in ein String-Array kopieren und zurückgeben
			string[] words = new string[matches.Count];
			for (int i = 0; i < matches.Count; i++)
			{
				words[i] = matches[i].Value;
			}
			return words;
		}

        /// <summary>
        /// GetWords
        /// </summary>
        /// <param name="source"></param>
        /// <param name="minLength"></param>
        /// <returns>GetWords</returns>
		public string[] GetWords(string source, int minLength)
		{
			// Alle Wörter abfragen
			MatchCollection matches = Regex.Matches(source, @"\w{1,}");

			// Die MatchCollection in ein String-Array kopieren und zurückgeben
			string[] words = new string[matches.Count];
			for (int i = 0; i < matches.Count; i++)
			{
				if (matches[i].Value.Length >= minLength)
				{
					words[i] = matches[i].Value; 
				}
			}
			return words;
		}
	}
}

