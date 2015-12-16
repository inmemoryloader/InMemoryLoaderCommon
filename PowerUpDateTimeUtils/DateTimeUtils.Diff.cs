using System;
using log4net;
using InMemoryLoaderBase;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Berechnet die Differenz zwischen zwei Datumswerten
		/// </summary>
		/// <param name="firstDate">Das erste (normalerweise kleinere) Datum</param>
		/// <param name="lastDate">Das zweite (normalerweise größere) Datum</param>
		/// <param name="interval">Gibt an, in welchem Datums-Intervall das Ergebnis zurückgegeben werden soll</param>
		/// <returns>Gibt die Anzahl Tage, Stunden, Minuten, Sekunden 
		/// oder Millisekunden zurück, die zwischen den beiden angegebenen
		/// Datumswerten liegen</returns>
		public double DateDiff(DateTime firstDate, DateTime lastDate, DateInterval interval)
		{
			// Je nach Intervall das Ergebnis berechnen
			switch (interval)
			{
			case DateInterval.Years:
				return this.GetYearDifference(firstDate, lastDate);

			case DateInterval.Months:
				return this.GetMonthDifference(firstDate, lastDate);

			case DateInterval.Weeks:
				return this.GetWeekDifference(firstDate, lastDate);

			case DateInterval.Days:
				return (lastDate - firstDate).TotalDays;

			case DateInterval.Hours:
				return (lastDate - firstDate).TotalHours;

			case DateInterval.Minutes:
				return (lastDate - firstDate).TotalMinutes;

			case DateInterval.Seconds:
				return (lastDate - firstDate).TotalSeconds;

			default:
				return (lastDate - firstDate).TotalMilliseconds;
			}
		}

		/// <summary>
		/// Berechnet die Differenz zwischen zwei Datumswerten in Jahren
		/// </summary>
		/// <param name="firstDate">Das erste (normalerweise kleinere) Datum</param>
		/// <param name="lastDate">Das zweite (normalerweise größere) Datum</param>
		/// <returns>Gibt die Differenz zwischen den übergebenen Datumswerten in Jahren zurück</returns>
		/// <remarks>
		/// Liegen beide Datumswerte im selben Jahr, gibt die Methode
		/// den Anteil der Ticks, die zwischen den Datumswerten liegen,
		/// geteilt durch die Gesamt-Ticks des Jahres zurück.
		/// Anderenfalls werden der Anteil der Ticks im ersten Jahr 
		/// mit denen im letzten Jahr addiert und die vollen Jahre,
		/// die u. U. dazwischen liegen, addiert.
		/// </remarks>
		public double GetYearDifference(DateTime firstDate, DateTime lastDate)
		{
			// Differenz berechnen
			TimeSpan timeSpan = lastDate - firstDate;

			if (firstDate.Year == lastDate.Year)
			{
				// Wenn beide Datumswerte im selben Jahr liegen:
				// Die Ticks in diesem Jahr berechnen
				long yearTicks = ((new DateTime(firstDate.Year + 1, 1, 1)) - (new DateTime(firstDate.Year, 1, 1))).Ticks - 1;

				// Den Anteil an Ticks für das Jahr berechnen
				return timeSpan.Ticks / (double)yearTicks;
			}
			else
			{
				// Wenn beide Datumswerte in unterschiedlichen 
				// Jahren liegen:

				// Wenn das erste Datum größer ist als das
				// zweite, werden die Datumswerte vertauscht
				// und das Programm merkt sich, dass das
				// Ergebnis negiert werden muss
				bool negate = false;
				if (firstDate > lastDate)
				{
					DateTime temp = firstDate;
					firstDate = lastDate;
					lastDate = temp;
					negate = true;
				}

				// Den Anteil im ersten Jahr berechnen
				DateTime firstYearStartDate = new DateTime(firstDate.Year, 1, 1);
				DateTime firstYearEndDate = new DateTime(firstDate.Year + 1, 1, 1).AddTicks(-1);
				long yearTicks = (firstYearEndDate - firstYearStartDate).Ticks;
				long ticks = (firstYearEndDate - firstDate).Ticks;
				double years = ticks / (double)yearTicks;

				// Den Anteil im letzten Jahr berechnen
				DateTime lastYearStartDate = new DateTime(lastDate.Year, 1, 1);
				DateTime lastYearEndDate = new DateTime(lastDate.Year + 1, 1, 1).AddTicks(-1);
				yearTicks = (lastYearEndDate - lastYearStartDate).Ticks;
				ticks = (lastDate - lastYearStartDate).Ticks;
				years += ticks / (double)yearTicks;

				// Die Jahre dazwischen addieren und das Ergebnis
				// zurückgeben
				return (years + lastDate.Year - firstDate.Year - 1) * (negate ? -1 : 1);
			}
		}

		/// <summary>
		/// Berechnet die Differenz zwischen zwei Datumswerten in Monaten
		/// </summary>
		/// <param name="firstDate">Das erste (normalerweise kleinere) Datum</param>
		/// <param name="lastDate">Das zweite (normalerweise größere) Datum</param>
		/// <returns>Gibt die Differenz zwischen den übergebenen Datumswerten in Monaten zurück</returns>
		/// <remarks>
		/// Liegen beide Datumswerte im selben Monat, gibt die Methode
		/// den Anteil der Ticks, die zwischen den Datumswerten liegen,
		/// geteilt durch die Gesamt-Ticks des Monats zurück.
		/// Anderenfalls werden der Anteil der Ticks im ersten Monat 
		/// mit denen im letzten Monat addiert und die vollen Monate,
		/// die u. U. dazwischen liegen, addiert.
		/// </remarks>
		public double GetMonthDifference(DateTime firstDate, DateTime lastDate)
		{
			// Differenz berechnen
			TimeSpan timeSpan = lastDate - firstDate;

			if (firstDate.Year == lastDate.Year && firstDate.Month == lastDate.Month)
			{
				// Wenn beide Datumswerte im selben Monat liegen:
				// Die Ticks in diesem Monat berechnen
				DateTime monthStartDate = new DateTime(firstDate.Year, firstDate.Month, 1);
				DateTime monthEndDate = monthStartDate.AddMonths(1).AddTicks(-1);
				long monthTicks = (monthEndDate - monthStartDate).Ticks;

				// Den Anteil an Ticks für den Monat berechnen
				return timeSpan.Ticks / (double)monthTicks;
			}
			else
			{
				// Wenn beide Datumswerte in unterschiedlichen 
				// Monaten liegen:

				// Wenn das erste Datum größer ist als das
				// zweite werden die Datumswerte vertauscht
				// und das Programm merkt sich, dass das
				// Ergebnis negiert werden muss
				bool negate = false;
				if (firstDate > lastDate)
				{
					DateTime temp = firstDate;
					firstDate = lastDate;
					lastDate = temp;
					negate = true;
				}

				// Den Anteil im ersten Monat berechnen
				DateTime firstMonthStartDate = new DateTime(firstDate.Year, firstDate.Month, 1);
				DateTime firstMonthEndDate = firstMonthStartDate.AddMonths(1).AddTicks(-1);
				long monthTicks = (firstMonthEndDate - firstMonthStartDate).Ticks;
				long ticks = (firstMonthEndDate - firstDate).Ticks;
				double months = ticks / (double)monthTicks;

				// Den Anteil im letzten Monat berechnen
				DateTime lastMonthStartDate = new DateTime(lastDate.Year, lastDate.Month, 1);
				DateTime lastMonthEndDate = lastMonthStartDate.AddMonths(1).AddTicks(-1);
				monthTicks = (lastMonthEndDate - lastMonthStartDate).Ticks;
				ticks = (lastDate - lastMonthStartDate).Ticks;
				months += ticks / (double)monthTicks;

				// Die Monate dazwischen addieren 
				// und das Ergebnis zurückgeben
				return (months + (12 - firstDate.Month) + ((lastDate.Year - firstDate.Year - 1) * 12) + (lastDate.Month - 1)) * (negate ? -1 : 1);
			}
		}

		/// <summary>
		/// Berechnet die Differenz zwischen zwei Datumswerten in Wochen
		/// </summary>
		/// <param name="firstDate">Das erste (normalerweise kleinere) Datum</param>
		/// <param name="lastDate">Das zweite (normalerweise größere) Datum</param>
		/// <returns>Gibt die Differenz zwischen den übergebenen Datumswerten in Wochen zurück</returns>
		/// <remarks>
		/// Liegen beide Datumswerte in der selben Woche, gibt die Methode
		/// den Anteil der Ticks, die zwischen den Datumswerten liegen,
		/// geteilt durch die Gesamt-Ticks einer Woche zurück.
		/// Anderenfalls werden der Anteil der Ticks in der ersten Woche 
		/// mit denen in der letzten Woche addiert und die vollen Wochen,
		/// die u. U. dazwischen liegen, addiert.
		/// </remarks>
		public double GetWeekDifference(DateTime firstDate, DateTime lastDate)
		{
			// Differenz in Tagen berechnen und durch 
			// 7 geteilt zurückgeben
			TimeSpan timeSpan = lastDate - firstDate;
			return timeSpan.TotalDays / 7;
		}

	}
}

