using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;

namespace InMemoryLoaderCommonUnitTest
{
	public class DateTimeUtilsCalendarWeekTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The crypt utils.
		/// </summary>
		private static IDynamicClassSetup dateTimeUtils = appBase.CommonComponentLoader.DateTimeComponent;
		/// <summary>
		/// The convert utils.
		/// </summary>
		private static IDynamicClassSetup convertUtils = appBase.CommonComponentLoader.ConvertComponent;

		/// <summary>
		/// Returns the CalendarWeek of the submitted Date (Year)
		/// </summary>
		/// <returns>The week in this year.</returns>
		/// <param name="dateString">Date string.</param>
		private static DateTime CalendarWeekInThisYear (string dateString)
		{
			try {
				
				object[] paramDateString = { dateString };

				var returnDate = appBase.ComponentLoader.InvokeMethod (convertUtils.Assembly, convertUtils.Class, "NormalizeDate", paramDateString);

				return (DateTime)returnDate;
			} catch (Exception ex) {
				throw ex;
			}
		}

		public static object GetGermanCalendarWeekStartDateTest (int calendarWeek, int year)
		{
			try {
				object[] paramDate = { calendarWeek, year };

				var weekStartDate = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetGermanCalendarWeekStartDate", paramDate);

				return weekStartDate;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the calendar week test.
		/// </summary>
		/// <returns>The calendar week test.</returns>
		/// <param name="paramDateString">Parameter date string.</param>
		public static object GetCalendarWeekTest (string paramDateString)
		{
			try {
				var varDate = CalendarWeekInThisYear (paramDateString);
				object[] paramDate = { varDate };

				var calendarWeek = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetCalendarWeek", paramDate);

				return calendarWeek;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the german calendar week test.
		/// </summary>
		/// <returns>The german calendar week test.</returns>
		/// <param name="paramDateString">Parameter date string.</param>
		public static object GetGermanCalendarWeekTest (string paramDateString)
		{
			try {
				var varDate = CalendarWeekInThisYear (paramDateString);
				object[] paramDate = { varDate };

				var calendarWeek = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetGermanCalendarWeek", paramDate);

				return calendarWeek;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

