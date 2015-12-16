using System;
using log4net;
using InMemoryLoaderBase;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Ermittelt, ob ein bestimmter Tag ein Feiertag ist
		/// </summary>
		/// <param name="date">Das Datum des Tages</param>
		/// <param name="name">In diesem Argument gibt die Methode
		/// den Namen des Feiertags zurück, falls es sich um einen solchen handelt</param>
		/// <param name="isNationWide">In diesem Argument gibt die Methode zurück,
		/// ob es sich um einen bundesweiten Feiertag handelt</param>
		/// <returns>Gibt true zurück wenn es sich bei dem übergebenen Datum
		/// um einen Feiertag handelt</returns>
		public bool IsGermanHoliday(DateTime date, out string name, out bool isNationWide)
		{
			// out-Argumente initialisieren
			name = null;
			isNationWide = false;

			// Auflistung der besonderen Tage des angegebenen Jahres erzeugen, 
			// durchgehen und das Datum der Feiertage mit dem angegebenen Datum
			// vergleichen
			foreach (GermanSpecialDay gsd in this.GetGermanSpecialDays(date.Year).Values)
			{
				if (date.Day == gsd.Date.Day &&
					date.Month == gsd.Date.Month)
				{
					// Datum gefunden
					if (gsd.IsHoliday)
					{
						// Es ist ein Feiertag: Infos definieren und true zurückgeben 
						name = gsd.Name;
						isNationWide = gsd.IsNationwide;
						return true;
					}
					else
					{
						// Kein Feiertag
						return false;
					}
				}
			}

			// Tag wurde nicht gefunden
			return false;
		}
	}
}

