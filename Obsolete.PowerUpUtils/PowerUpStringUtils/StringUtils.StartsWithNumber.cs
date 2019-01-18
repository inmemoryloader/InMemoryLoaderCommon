using System;
using InMemoryLoaderBase;
using log4net;
using System.Text.RegularExpressions;
using System.Threading;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractComponent
	{
		/// <summary>
		/// Überprüft, ob der übergebene String mit einer Zahl beginnt 
		/// und gibt die Zeichenlänge der Zahl zurück
		/// </summary>
		/// <param name="source">Der Quellstring</param>
		/// <param name="considerOnlyIntegers">Gibt an, ob nur Ganzzahlen
		/// berücksichtigt werden sollen</param>
		/// <returns>Gibt die Zeichenlänge der Zahl zurück falls eine solche
		/// am String-Anfang steht. Steht keine Zahl am Anfang des Strings,
		/// gibt die Methode 0 zurück</returns>
		public int StartsWithNumber(string source, bool considerOnlyIntegers)
		{
			// Muster für den regulären Ausdruck definieren
			string pattern;
			if (considerOnlyIntegers)
			{
				pattern = @"^\d{1,}";
			}
			else
			{
				string decimalSeparator = Regex.Escape(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
				pattern = @"^\d{1,}" + decimalSeparator + @"{0,1}\d{0,}";
			}
			// Match-Instanz erzeugen und überprüfen ob ein Treffer erzielt wurde
			Match match = Regex.Match(source, pattern);
			if (match.Success)
			{
				// Die Länge des gefundenen Teilstrings zurückgeben
				return match.Length;
			}
			else
			{
				return 0;
			}
		}
	}
}

