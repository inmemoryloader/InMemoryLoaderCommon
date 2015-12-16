using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Verwaltet Informationen zu einem Quartal
	/// </summary>
	public class QuarterInfo
	{
		private int quarter;
		/// <summary>
		/// Das Quartal
		/// </summary>
		public int Quarter
		{
			get { return this.quarter; }
		}

		private int year;
		/// <summary>
		/// Das Jahr
		/// </summary>
		public int Year
		{
			get { return this.year; }
		}

		private DateTime startDate;
		/// <summary>
		/// Das Startdatum des Quartals
		/// </summary>
		public DateTime StartDate
		{
			get { return this.startDate; }
		}

		private DateTime endDate;
		/// <summary>
		/// Das Enddatum des Quartals
		/// </summary>
		public DateTime EndDate
		{
			get { return this.endDate; }
		}

		/// <summary>
		/// Konstruktor. Berechnet das Start- und das
		/// Enddatum des übergebenen Quartals.
		/// </summary>
		/// <param name="quarter">Das Quartal</param>
		/// <param name="year">Das Jahr</param>
		public QuarterInfo(int quarter, int year)
		{
			// Das übergebene Quartal und das Jahr überprüfen
			if (quarter >= 1 && quarter <= 4 &&
				year >= 0 && year <= 9999)
			{
				// Quartal und Jahr übergeben
				this.quarter = quarter;
				this.year = year;

				// Ersten Tag im Quartal berechnen
				this.startDate = new DateTime(year, (quarter * 3) - 2, 1);

				// Letzten Tag im Quartal berechnen
				this.endDate = this.startDate.AddMonths(3).AddDays(-1);
			}
			else
			{
				throw new ArgumentException("Das Quartal muss eine Zahl " +
					"zwischen 1 und 4 und das Jahr eine Zahl zwischen 0 " +
					"und 9999 sein");
			}
		}
	}
}

