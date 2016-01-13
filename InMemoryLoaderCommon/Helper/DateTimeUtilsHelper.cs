using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using log4net;
using PowerUpDateTimeUtils;

namespace InMemoryLoaderCommon
{
	public class DateTimeUtilsHelper
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static ILog log = LogManager.GetLogger (typeof(DateTimeUtilsHelper));

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryLoaderCommon.DateTimeUtilsHelper"/> class.
		/// </summary>
		public DateTimeUtilsHelper ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}

		/// <summary>
		/// The date format info.
		/// </summary>
		private static DateFormatInfo dateFormatInfo;

		/// <summary>
		/// Gets the current date format info.
		/// </summary>
		/// <returns>The current date format info.</returns>
		public object GetCurrentDateFormatInfo ()
		{
			dateFormatInfo = new DateFormatInfo ();
			return dateFormatInfo.GetCurrentDateFormatInfo () as object;
		}

		/// <summary>
		/// Gets the date format info.
		/// </summary>
		/// <returns>The date format info.</returns>
		/// <param name="cultureInfo">Culture info.</param>
		public object GetDateFormatInfo (CultureInfo cultureInfo)
		{
			dateFormatInfo = new DateFormatInfo ();
			return dateFormatInfo.GetDateFormatInfo (cultureInfo) as object;
		}

		/// <summary>
		/// The calendar info.
		/// </summary>
		private static CalendarInfo calendarInfo;

		/// <summary>
		/// Gets the calendar info.
		/// </summary>
		/// <returns>The calendar info.</returns>
		/// <param name="calendar">Calendar.</param>
		public object GetCalendarInfo (Calendar calendar)
		{
			calendarInfo = new CalendarInfo (calendar);
			return calendarInfo as object;
		}

		/// <summary>
		/// Gets the system calendars.
		/// </summary>
		/// <returns>The system calendars.</returns>
		public List<object> GetSystemCalendars ()
		{
			var list = CalendarInfo.GetSystemCalendars ();
			List<object> systemCalendars = new List<object> (); 

			foreach (var item in list) {
				systemCalendars.Add (item as object);
			}

			return systemCalendars;
		}

		/// <summary>
		/// Gets the calendar date string.
		/// </summary>
		/// <returns>The calendar date string.</returns>
		/// <param name="date">Date.</param>
		public string GetCalendarDateString (DateTime date)
		{
			if (calendarInfo == null) {
				return string.Empty;
			}
			return calendarInfo.GetCalendarDateString (date);
		}
	}
}

