using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Verwaltet Informationen zu einem Monat
	/// </summary>
	public class MonthInfo
	{
		private int month;
		/// <summary>
		/// Das Quartal
		/// </summary>
		public int Month
		{
			get { return month; }
		}

		private int year;
		/// <summary>
		/// Das Jahr
		/// </summary>
		public int Year
		{
			get { return year; }
		}

		private DateTime startDate;
		/// <summary>
		/// Das Startdatum des Monats
		/// </summary>
		public DateTime StartDate
		{
			get { return startDate; }
		}

		private DateTime endDate;
		/// <summary>
		/// Das Enddatum des Monats
		/// </summary>
		public DateTime EndDate
		{
			get { return endDate; }
		}

		/// <summary>
		/// Konstruktor. Berechnet das Start- und das
		/// Enddatum des übergebenen Monate.
		/// </summary>
		/// <param name="month">Der Monat</param>
		/// <param name="year">Das Jahr</param>
		public MonthInfo(int month, int year)
		{
			// Die Argumente überprüfen
			if (month < 1 || month > 12 || year < 0 || year > 9999)
			{
				throw new ArgumentException("Der Monat muss ein Wert zwischen 1 und 12 " + "und das Jahr muss ein Wert zwischen 0 und 9999 sein");
			}

			// Argumente übergeben
			month = month;
			year = year;

			// Den ersten Tag des Monats ermitteln
			startDate = new DateTime(year, month, 1);

			// Den letzten Tag des Monats ermitteln
			if (month == 12)
			{
				month = 1;
				year++;
			}
			else
			{
				month++;
			}
			endDate = new DateTime(year, month, 1).AddDays(-1);
		}
	}
}

