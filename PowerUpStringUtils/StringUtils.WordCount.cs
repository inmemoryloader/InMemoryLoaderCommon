using System;
using InMemoryLoaderBase;
using log4net;
using System.Text.RegularExpressions;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Ermittelt die Anzahl der Wörter in einem String mit beliebigen Zeichen (langsam im Vergleich zu <see cref="WordCountLatin"/>
		/// </summary>
		/// <param name="source">Der String</param>
		/// <returns>Gibt die ermittelte Anzahl zurück</returns>
		/// <remarks>Diese Methode arbeitet sehr sicher, auch für Wörter 
		/// mit Unicode-Zeichen, die nicht aus der lateinischen Teiltabelle
		/// stammen (Zeichen ab Zeichen 0x0370). 
		/// WordCount ist im Vergleich zu <see cref="WordCountLatin"/>
		/// aber leider auch recht langsam.</remarks>
		public long WordCount(string source)
		{
			return Regex.Matches(source, @"\w{1,}").Count;
		}
	}
}

