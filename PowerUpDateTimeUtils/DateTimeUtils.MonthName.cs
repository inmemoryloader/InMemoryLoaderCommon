using System;
using log4net;
using PowerUpBase;
using System.Globalization;
using System.Threading;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Liefert den Namen des angegebenen Monats in der aktuellen Kultur
		/// </summary>
		/// <param name="month">
		/// Der Monat
		/// </param>
		/// <returns>
		/// Gibt einen String zurück, der den Namen des Monats
		///     in der aktuell eingestellten Kultur enthält
		/// </returns>
		public string GetMonthName(int month)
		{
			return GetMonthName(month, Thread.CurrentThread.CurrentCulture);
		}

		/// <summary>
		/// Liefert den Namen des angegebenen Monats in der angegebenen Kultur
		/// </summary>
		/// <param name="month">
		/// Der Monat
		/// </param>
		/// <param name="cultureInfo">
		/// Die Kultur, für die der Name ermittelt werden soll
		/// </param>
		/// <returns>
		/// Gibt einen String zurück, der den Namen des Monats
		///     in der übergebenen Kultur enthält
		/// </returns>
		public string GetMonthName(int month, CultureInfo cultureInfo)
		{
			// Den übergebenen Monat überprüfen
			if (month >= 1 && month <= 12)
			{
				return cultureInfo.DateTimeFormat.GetMonthName(month);
			}

			throw new ArgumentException("Der Monat muss ein Wert " + "Zwischen 1 und 12 sein");
		}
	}
}

