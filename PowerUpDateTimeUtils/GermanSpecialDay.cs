using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Verwaltet einen speziellen deutschen Tag
	/// </summary>
	public class GermanSpecialDay : IComparable<GermanSpecialDay>
	{
		/// <summary>
		/// Der Schlüssel des speziellen Tags
		/// </summary>
		public GermanSpecialDayKey Key;

		/// <summary>
		/// Der Name des speziellen Tags
		/// </summary>
		public string Name;

		/// <summary>
		/// Das Datum des speziellen Tags
		/// </summary>
		public DateTime Date;

		/// <summary>
		/// Gibt an, ob der spezielle Tag bundesweit gilt
		/// </summary>
		public bool IsNationwide;

		/// <summary>
		/// Gibt an, ob es sich bei dem speziellen Tag
		/// um einen Feiertag handelt
		/// </summary>
		public bool IsHoliday;

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="key">Der Schlüssel des speziellen Tags</param>
		/// <param name="name">Der Name des speziellen Tags</param>
		/// <param name="date">Das Datum des speziellen Tags</param>
		/// <param name="isNationwide">Gibt an, ob der spezielle Tag bundesweit gilt</param>
		/// <param name="isHoliday">Gibt an, ob es sich bei dem speziellen Tag um einen Feiertag handelt</param>
		public GermanSpecialDay(GermanSpecialDayKey key, string name, DateTime date, bool isNationwide, bool isHoliday)
		{
			this.Key = key;
			this.Name = name;
			this.Date = date;
			this.IsNationwide = isNationwide;
			this.IsHoliday = isHoliday;
		}

		/// <summary>
		/// Vergleicht ein GermanSpecialDay-Objekt mit dem aktuellen
		/// </summary>
		/// <param name="otherSpecialDay">Das andere GermanSpecialDay-Objekt</param>
		public int CompareTo(GermanSpecialDay otherSpecialDay)
		{
			return this.Date.CompareTo(otherSpecialDay.Date);
		}
	}
}

