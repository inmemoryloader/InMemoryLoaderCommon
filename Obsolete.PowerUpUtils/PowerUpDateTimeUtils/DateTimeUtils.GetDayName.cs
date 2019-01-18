using System;
using log4net;
using InMemoryLoaderBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractComponent
	{
		/// <summary>
		/// Liefert den Namen des angegebenen Wochentags in der aktuellen Kultur
		/// </summary>
		/// <param name="dayOfWeek">Der Wochentag</param>
		/// <returns>Gibt einen String zurück, der den Namen des Wochentags
		/// in der aktuell eingestellten Kultur enthält</returns>
		public string GetDayName(DayOfWeek dayOfWeek)
		{
			return Thread.CurrentThread.CurrentCulture.DateTimeFormat.GetDayName(dayOfWeek);
		}

		/// <summary>
		/// Liefert den Namen des angegebenen Wochentags in der angegebenen Kultur
		/// </summary>
		/// <param name="dayOfWeek">Der Wochentag</param>
		/// <param name="cultureInfo">Die Kultur, für die der Name ermittelt werden soll</param>
		/// <returns>Gibt einen String zurück, der den Namen des Wochentags
		/// in der übergebenen Kultur enthält</returns>
		public string GetDayName(DayOfWeek dayOfWeek, CultureInfo cultureInfo)
		{
			return cultureInfo.DateTimeFormat.GetDayName(dayOfWeek);
		}
	}
}

