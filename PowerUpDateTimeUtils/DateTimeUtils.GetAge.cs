using System;
using log4net;
using PowerUpBase;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Berechnet ein Alter in Jahren
		/// </summary>
		/// <param name="lowerDate">Das kleinere Datum</param>
		/// <param name="higherDate">Das größere Datum</param>
		/// <returns>Gibt das Alter in ganzen Jahren zurück</returns>
		public int GetAge(DateTime lowerDate, DateTime higherDate)
		{
			return GetAge(new DateTimeOffset(lowerDate), new DateTimeOffset(higherDate));
		}

		/// <summary>
		/// Berechnet ein Alter in Jahren
		/// </summary>
		/// <param name="lowerDate">Das kleinere Datum</param>
		/// <param name="higherDate">Das größere Datum</param>
		/// <returns>Gibt das Alter in ganzen Jahren zurück</returns>
		public int GetAge(DateTimeOffset lowerDate, DateTimeOffset higherDate)
		{
			// Basis-Alter als Differenz zwischen den Jahren ermitteln
			int age = higherDate.Year - lowerDate.Year;

			// Wenn der Monat des größeren Datums kleiner oder wenn der Monat gleich 
			// und der Tag kleiner ist, muss ein Jahr abgezogen werden
			if ((higherDate.Month < lowerDate.Month) || (higherDate.Month == lowerDate.Month && higherDate.Day < lowerDate.Day))
			{
				age--;
			}

			return age;
		}
	}
}

