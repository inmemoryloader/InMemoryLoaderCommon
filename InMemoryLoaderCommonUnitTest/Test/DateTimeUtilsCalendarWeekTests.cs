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

		/// <summary>
		/// Gets the week difference test.
		/// </summary>
		/// <returns>The week difference test.</returns>
		/// <param name="firstDate">First date.</param>
		/// <param name="lastDate">Last date.</param>
		public static object GetWeekDifferenceTest (DateTime firstDate, DateTime lastDate)
		{
			try {
				object[] paramDate = { firstDate, lastDate };

				var dateDiff = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetWeekDifference", paramDate);

				return dateDiff;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the month difference test.
		/// </summary>
		/// <returns>The month difference test.</returns>
		/// <param name="firstDate">First date.</param>
		/// <param name="lastDate">Last date.</param>
		public static object GetMonthDifferenceTest (DateTime firstDate, DateTime lastDate)
		{
			try {
				object[] paramDate = { firstDate, lastDate };

				var dateDiff = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetMonthDifference", paramDate);

				return dateDiff;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the year difference test.
		/// </summary>
		/// <returns>The year difference test.</returns>
		/// <param name="firstDate">First date.</param>
		/// <param name="lastDate">Last date.</param>
		public static object GetYearDifferenceTest (DateTime firstDate, DateTime lastDate)
		{
			try {
				object[] paramDate = { firstDate, lastDate };

				var dateDiff = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetYearDifference", paramDate);

				return dateDiff;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the calendar week start date test.
		/// </summary>
		/// <returns>The calendar week start date test.</returns>
		/// <param name="calendarWeek">Calendar week.</param>
		/// <param name="year">Year.</param>
		public static object GetCalendarWeekStartDateTest (int calendarWeek, int year)
		{
			try {
				object[] paramDate = { calendarWeek, year };

				var weekStartDate = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetCalendarWeekStartDate", paramDate);

				return weekStartDate;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the german calendar week start date test.
		/// </summary>
		/// <returns>The german calendar week start date test.</returns>
		/// <param name="calendarWeek">Calendar week.</param>
		/// <param name="year">Year.</param>
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

