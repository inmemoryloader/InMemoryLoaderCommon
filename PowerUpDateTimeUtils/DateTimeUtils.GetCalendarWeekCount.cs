using System;
using log4net;
using PowerUpBase;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Berechnet die Anzahl der Kalenderwochen in einem Jahr
		/// </summary>
		/// <param name="year">Das Jahr</param>
		/// <returns>Gibt die Anzahl der Kalenderwochen zurück, die das angegebene Jahr enthält</returns>
		public int GetCalendarWeekCount(int year)
		{
			// Kalenderwoche des 31.12. des Jahres ermitteln
			DateTime baseDate = new DateTime(year, 12, 31);
			CalendarWeek calendarWeek = this.GetCalendarWeek(baseDate);

			// Wenn dieser Tag in die Woche 1 des neuen Jahres fällt, die Kalenderwoche 
			// des um eine Woche reduzierten Datums ermitteln
			if (calendarWeek.Week == 1)
			{
				var retDate = baseDate.AddDays (-7);
				return this.GetCalendarWeek(retDate).Week;
			}
			// Ergebnis zurückgeben
			return calendarWeek.Week;
		}
	}
}

