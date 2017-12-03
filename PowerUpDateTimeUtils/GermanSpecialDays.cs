using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Auflistung zur Verwaltung der speziellen Tage in Deutschland
	/// </summary>
	public class GermanSpecialDays : Dictionary<GermanSpecialDayKey,  GermanSpecialDay>
	{
		private int year;
		/// <summary>
		/// Gibt das Jahr zurück, für das diese speziellen Tage gelten
		/// </summary>
		public int Year
		{
			get { return year; }
		}

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="year">Das Jahr</param>
		internal GermanSpecialDays(int year)
		{
			year = year;
		}

		/// <summary>
		/// Fügt der Auflistung ein neues GermanSpecialDay-Objekt hinzu
		/// </summary>
		/// <param name="key">Der Konstanten-Wert des hinzuzufügenden Tags</param>
		/// <param name="name">Der Name des Tags</param>
		/// <param name="date">Das Datum des Tags</param>
		/// <param name="nationWide">Gibt an, ob der spezielle Tag bundesweit gilt</param>
		/// <param name="holiday">Gibt an, ob der spezielle Tag ein Feiertag ist</param>
		internal void Add(GermanSpecialDayKey key, string name, DateTime date, bool nationWide, bool holiday)
		{
			base.Add(key, new GermanSpecialDay(key, name, date, nationWide, holiday));
		}
	}
}

