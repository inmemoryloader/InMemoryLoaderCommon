using System;
using log4net;
using InMemoryLoaderBase;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractComponent
	{
		/// <summary>
		/// Berechnet das Quartal eines gegebenen Datums
		/// </summary>
		/// <param name="date">Das Datum</param>
		/// <returns>Gibt das Quartal zurück</returns>
		public int GetQuarter(DateTime date)
		{
			return ((date.Month - 1) / 3) + 1;
		}
	}
}

