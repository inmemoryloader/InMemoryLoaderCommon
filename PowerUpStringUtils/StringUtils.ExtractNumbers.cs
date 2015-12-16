using System;
using PowerUpBase;
using log4net;
using System.Text.RegularExpressions;
using System.Threading;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Ermittelt alle Zahlen aus einem String
		/// </summary>
		/// <param name="source">Der String</param>
		/// <param name="extractOnlyIntegers">Gibt an, ob Ganzzahlen extrahiert werden sollen</param>
		/// <returns>Gibt ein Array zurück, das alle Ganzzahlen speichert, 
		/// die in dem übergebenen String vorkommen</returns>
		public double[] ExtractNumbers(string source, bool extractOnlyIntegers)
		{
			// Muster für den regulären Ausdruck definieren
			string pattern;
			if (extractOnlyIntegers)
			{
				pattern = @"\d{1,}";
			}
			else
			{
				string decimalSeparator = Regex.Escape( Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
				pattern = @"\d{1,}" + decimalSeparator + @"{0,1}\d{0,}";
			}
			// Die Treffer ermitteln
			MatchCollection matches = Regex.Matches(source, pattern);
			// Das Ergebnis in ein double-Array kopieren
			double[] result = new double[matches.Count];
			for (int i = 0; i < matches.Count; i++)
			{
				result[i] = Convert.ToDouble(matches[i].Value);
			}
			return result;
		}
	}
}

