using System;

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Verwaltet die Daten einer Kalenderwoche
	/// </summary>
	public class CalendarWeek
	{
		/// <summary>
		/// Das Jahr
		/// </summary>
		public int Year;

		/// <summary>
		/// Die Kalenderwoche
		/// </summary>
		public int Week;

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="year">Das Jahr</param>
		/// <param name="week">Die Kalenderwoche</param>
		public CalendarWeek(int year, int week)
		{
			this.Year = year;
			this.Week = week;
		}
	}
}

