using System;
using log4net;
using PowerUpBase;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Konvertiert ein Datum in das ISO-8601-Format
		/// </summary>
		/// <param name="date">Das zu konvertieren der Datum</param>
		/// <param name="includeTime">Gibt an, ob die Zeit mit eingeschlossen werden soll</param>
		/// <returns>Gibt einen String zurück, der das übergebene Datum
		/// im ISO-8601-Format enthält</returns>
		public string ToIsoDateTime(DateTime date, bool includeTime)
		{
			if (includeTime)
			{
				return String.Format("{0:yyyy-MM-ddTHH:mm:ss}", date);
			}
			else
			{
				return String.Format("{0:yyyy-MM-dd}", date);
			}
		}
	}
}

