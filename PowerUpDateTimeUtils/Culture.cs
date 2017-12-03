using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Verwaltet die Namen einer Kultur und gibt ein Array der verfügbaren Kulturen zurück
	/// </summary>
	public class Culture
	{
		/// <summary>
		/// Der Name der Kultur
		/// </summary>
		public string Name;

		/// <summary>
		/// Der Anzeigename der Kultur
		/// </summary>
		public string DisplayName;

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="name">Der Name der Kultur</param>
		/// <param name="displayName">Der Anzeigename der Kultur</param>
		public Culture(string name, string displayName)
		{
			Name = name;
			DisplayName = displayName;
		}

		/// <summary>
		/// Gibt den Namen und den Displaynamen zurück
		/// </summary>
		public override string ToString()
		{
			return DisplayName + " (" + Name + ")";
		}

		/// <summary>
		/// Gibt die verfügbaren speziellen Kulturen zurück
		/// </summary>
		/// <returns></returns>
		public static Culture[] GetSpecificCultures()
		{
			// Die verfügbaren Kulturen einlesen
			CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

			// Sortieren
			Array.Sort(cultures, new CultureComparer());

			// Ergebnis erzeugen
			Culture[] result = new Culture[cultures.Length];

			// Die Kulturen durchgehen und in das Array schreiben
			for (int i = 0; i < cultures.Length; i++)
			{
				result[i] = new Culture(cultures[i].Name, cultures[i].EnglishName);
			}

			// Ergebnis zurückgeben
			return result;
		}

	}
}

