using System;
using log4net;
using InMemoryLoaderBase;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Berechnet das Datum des Ostersonntags des übergebenen Jahres
		/// </summary>
		/// <param name="year">Das Jahr, für das das Ostersonntag-Datum berechnet werden soll</param>
		/// <returns>Die das Datum des Ostersonntags des übergebenen Jahres zurück</returns>
		/// <remarks>
		/// Die Berechnung erfolgt nach dem Original von Ronald W. Mallen (www.assa.org.au/edm.html)
		/// </remarks>
		public DateTime GetEasterSundayDate(int year)
		{
			// Überprüfen, ob das Jahr für die Osterberechnung gültig ist
			if (year < 1583 || year > 4099)
			{
				throw new Exception("Das Jahr muss zwischen 1583 " +
					"und 4099 liegen");
			}

			int firstDigits, remaining19, temp; // Zwischenergebnisse
			int tA, tB, tC, tD, tE; // Tabellenergebnisse A bis E

			firstDigits = year / 100; // die ersten zwei Ziffern
			remaining19 = year % 19; // Rest von year / 19  

			// PFM-Datum berechnen
			temp = (firstDigits - 15) / 2 + 202 - 11 * remaining19;

			switch (firstDigits)
			{
			case 21:
			case 24:
			case 25:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 34:
			case 35:
			case 38:
				temp -= 1;
				break;
			case 33:
			case 36:
			case 37:
			case 39:
			case 40:
				temp -= 2;
				break;
			}

			temp = temp % 30;

			tA = temp + 21;
			if (temp == 29)
			{
				tA = tA - 1;
			}
			if (temp == 28 && remaining19 > 10)
			{
				tA = tA - 1;
			}

			// Nächsten Sonntag ermitteln
			tB = (tA - 19) % 7;

			tC = (40 - firstDigits) % 4;
			if (tC == 3)
			{
				tC = tC + 1;
			}
			if (tC > 1)
			{
				tC = tC + 1;
			}

			temp = year % 100;
			tD = (temp + temp / 4) % 7;

			tE = ((20 - tB - tC - tD) % 7) + 1;

			// Das Datum ermitteln und zurückgeben
			int day = tA + tE;
			int month = 0;

			if (day > 31)
			{
				day -= 31;
				month = 4;
			}
			else
			{
				month = 3;
			}

			return new DateTime(year, month, day);
		}

		/// <summary>
		/// Berechnet die speziellen Tage für Deutschland
		/// </summary>
		/// <param name="year">Das Jahr, für das die speziellen Tage berechnet werden sollen</param>
		/// <returns>Gibt eine GermanSpecialDays-Auflistung mit den Daten der wichtigsten
		/// speziellen Tage für Deutschland zurück</returns>
		public GermanSpecialDays GetGermanSpecialDays(int year)
		{
			// GermanSpecialDays-Instanz erzeugen
			GermanSpecialDays gsd = new GermanSpecialDays(year);

			// Die festen besonderen Tage eintragen
			gsd.Add(GermanSpecialDayKey.Neujahr, "Neujahr", new DateTime(year, 1,
				1), true, true);
			gsd.Add(GermanSpecialDayKey.HeiligeDreiKönige,
				"Heilige Drei Könige", new DateTime(year, 1, 6), false, true);
			gsd.Add(GermanSpecialDayKey.Valentinstag, "Valentinstag", new
				DateTime(year, 2, 14), true, false);
			gsd.Add(GermanSpecialDayKey.Maifeiertag, "Maifeiertag", new DateTime
				(year, 5, 1), true, true);
			gsd.Add(GermanSpecialDayKey.MariaHimmelfahrt, "Maria Himmelfahrt",
				new DateTime(year, 8, 15), false, true);
			gsd.Add(GermanSpecialDayKey.TagDerDeutschenEinheit,
				"Tag der Deutschen Einheit", new DateTime(year, 10, 3), true, true);
			gsd.Add(GermanSpecialDayKey.Reformationstag, "Reformationstag", new
				DateTime(year, 10, 31), false, true);
			gsd.Add(GermanSpecialDayKey.Allerheiligen, "Allerheiligen", new
				DateTime(year, 11, 1), false, true);
			gsd.Add(GermanSpecialDayKey.HeiligerAbend, "Heiliger Abend", new
				DateTime(year, 12, 24), true, true);
			gsd.Add(GermanSpecialDayKey.ErsterWeihnachtstag,
				"Erster Weihnachtstag", new DateTime(year, 12, 25), true, true);
			gsd.Add(GermanSpecialDayKey.ZweiterWeihnachtstag,
				"Zweiter Weihnachtstag", new DateTime(year, 12, 26), true, true);

			// Datum des Ostersonntag berechnen
			DateTime easterSunday = GetEasterSundayDate(year);

			// Die beweglichen besonderen Tage ermitteln, die sich auf Ostern beziehen
			gsd.Add(GermanSpecialDayKey.Rosenmontag, "Rosenmontag",
				easterSunday.AddDays(-48), true, false);
			gsd.Add(GermanSpecialDayKey.Aschermittwoch, "Aschermittwoch",
				easterSunday.AddDays(-46), true, false);
			gsd.Add(GermanSpecialDayKey.Gründonnerstag, "Gründonnerstag",
				easterSunday.AddDays(-3), true, false);
			gsd.Add(GermanSpecialDayKey.Karfreitag, "Karfreitag",
				easterSunday.AddDays(-2), true, true);
			gsd.Add(GermanSpecialDayKey.Ostermontag, "Ostermontag",
				easterSunday.AddDays(1), true, true);
			gsd.Add(GermanSpecialDayKey.Ostersonntag, "Ostersonntag",
				easterSunday, true, true);
			gsd.Add(GermanSpecialDayKey.ChristiHimmelfahrt,
				"Christi Himmelfahrt", easterSunday.AddDays(39), true, true);
			gsd.Add(GermanSpecialDayKey.Pfingstsonntag, "Pfingstsonntag",
				easterSunday.AddDays(49), true, true);
			gsd.Add(GermanSpecialDayKey.Pfingstmontag, "Pfingstmontag",
				easterSunday.AddDays(50), true, true);
			gsd.Add(GermanSpecialDayKey.Fronleichnam, "Fronleichnam",
				easterSunday.AddDays(60), false, true);

			// Die beweglichen besonderen Tage ermitteln, die sich auf Weihnachten
			// beziehen
			// Sonntag vor dem 25. Dezember (4. Advent) ermitteln
			DateTime firstXMasDay = new DateTime(year, 12, 25);
			DateTime fourthAdvent;
			int weekday = (int)firstXMasDay.DayOfWeek;
			if (weekday == 0)
			{
				// Sonntag
				fourthAdvent = firstXMasDay.AddDays(-7);
			}
			else
			{
				fourthAdvent = firstXMasDay.AddDays(-weekday);
			}
			gsd.Add(GermanSpecialDayKey.VierterAdvent, "Vierter Advent",
				fourthAdvent, true, false);
			gsd.Add(GermanSpecialDayKey.DritterAdvent, "Dritter Advent",
				fourthAdvent.AddDays(-7), true, false);
			gsd.Add(GermanSpecialDayKey.ZweiterAdvent, "Zweiter Advent",
				fourthAdvent.AddDays(-14), true, false);
			gsd.Add(GermanSpecialDayKey.ErsterAdvent, "Erster Advent",
				fourthAdvent.AddDays(-21), true, false);

			// Totensonntag ermitteln
			DateTime deadSunday = fourthAdvent.AddDays(-28);
			gsd.Add(GermanSpecialDayKey.Totensonntag, "Totensonntag", deadSunday,
				true, false);

			// Den Mittwoch vor dem Totensonntag ermitteln
			weekday = (int)deadSunday.DayOfWeek;
			if (weekday < 4)
			{
				// Sonntag bis Mittwoch
				gsd.Add(GermanSpecialDayKey.BußUndBettag, "Buß- und Bettag",
					deadSunday.AddDays(-(weekday + 4)), false, true);
			}
			else
			{
				// Donnerstag bis Samstag
				gsd.Add(GermanSpecialDayKey.BußUndBettag, "Buß- und Bettag",
					deadSunday.AddDays(-(weekday - 3)), false, true);
			}

			// Das Ergebnis zurückgeben
			return gsd;
		}
	}
}

