using System;
using InMemoryLoaderBase;
using log4net;
using System.Text.RegularExpressions;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractComponent
	{
		/// <summary>
		/// Ersetzt einen Teilstring im übergebenen String nur dann, wenn dieser
		/// am Anfang des Strings steht
		/// </summary>
		/// <param name="source">Der Quellstring</param>
		/// <param name="find">Der zu suchende String</param>
		/// <param name="replacement">Der String, der den zu suchenden String ersetzen soll</param>
		/// <param name="ignoreCase">Gibt an, ob die Groß-/Kleinschreibung vernachlässigt werden soll</param>
		/// <returns>Gibt den resultierenden String zurück</returns>
		public string ReplaceLeadingString(string source, string find, string replacement, bool ignoreCase)
		{
			// Muster für die Suche zusammenstellen, dabei den Sonderzeichen im 
			// Suchstring einen Backslash voranstellen
			string pattern = "^" + Regex.Escape(find);
			// Muster ersetzen
			if (ignoreCase)
			{
				return Regex.Replace(source, pattern, replacement, RegexOptions.IgnoreCase);
			}
			else
			{
				return Regex.Replace(source, pattern, replacement);
			}
		}
	}
}

