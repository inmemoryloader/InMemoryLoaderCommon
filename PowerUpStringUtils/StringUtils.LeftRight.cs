using System;
using InMemoryLoaderBase;
using log4net;
using System.Text.RegularExpressions;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Extrahiert einen linken Teilstring aus einem String
		/// </summary>
		/// <param name="source">Der Quellstring</param>
		/// <param name="count">Die Anzahl zu extrahierender Zeichen</param>
		/// <returns>Gibt den extrahierten String zurück</returns>
		public string Left(string source, int count)
		{
			if (source.Length >= count)
			{
				return source.Substring(0, count);
			}
			else
			{
				return source;
			}
		}

		/// <summary>
		/// Extrahiert einen rechten Teilstring aus einem String
		/// </summary>
		/// <param name="source">Der Quellstring</param>
		/// <param name="count">Die Anzahl zu extrahierender Zeichen</param>
		/// <returns>Gibt den extrahierten String zurück</returns>
		public string Right(string source, int count)
		{
			int length = source.Length;
			if (length >= count)
			{
				return source.Substring(length - count, count);
			}
			else
			{
				return source;
			}
		}
	}
}

