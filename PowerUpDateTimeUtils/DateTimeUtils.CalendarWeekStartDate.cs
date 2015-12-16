using System;
using log4net;
using PowerUpBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Berechnet das Startdatum einer deutschen Kalenderwoche
		/// </summary>
		/// <param name="calendarWeek">Die Kalenderwoche</param>
		/// <param name="year">Das Jahr</param>
		/// <returns>Gibt das Datum zurück, an dem die Kalenderwoche beginnt</returns>
		public DateTime GetGermanCalendarWeekStartDate(int calendarWeek, int year)
		{
			// Datum für den 4.1. des Jahres ermitteln
			DateTime baseDate = new DateTime(year, 1, 4);

			// Den Montag dieser Woche ermitteln
			int dayOfWeek = (int)baseDate.DayOfWeek;
			if (dayOfWeek > 0)
			{
				// Montag bis Samstag
				baseDate = baseDate.AddDays((dayOfWeek - 1) * -1);
			}
			else
			{
				// Sonntag
				baseDate = baseDate.AddDays(-6);
			}

			// Das Ergebnisdatum ermitteln
			return baseDate.AddDays((calendarWeek - 1) * 7);
		}

		/// <summary>
		/// Berechnet das Startdatum einer internationalen Kalenderwoche
		/// </summary>
		/// <param name="calendarWeek">Die Kalenderwoche</param>
		/// <param name="year">Das Jahr</param>
		/// <returns>Gibt das Datum zurück, an dem die Kalenderwoche beginnt</returns>
		public DateTime GetCalendarWeekStartDate(int calendarWeek, int year)
		{
			// Basisdatum (1.1. des angegebenen Jahres) ermitteln
			DateTime startDate = new DateTime(year, 1, 1);

			// Das Datum des ersten Wochentags dieser Woche ermitteln
			while (startDate.DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
			{
				startDate = startDate.AddDays(-1);
			}
			// Die Kalenderwoche ermitteln: Wenn es sich um die Woche 1 handelt,
			// ist dies das Basisdatum für die Berechnung, wenn nicht, müssen
			// sieben Tage aufaddiert werden
			CalendarWeek cw = GetCalendarWeek(startDate);
			if (cw.Week != 1)
			{
				startDate = startDate.AddDays(7);
			}
			// Das Ergebnisdatum ermitteln
			return startDate.AddDays((calendarWeek - 1) * 7);
		}
	}
}

