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
using System.Globalization;

namespace InMemoryLoaderCommonUnitTest
{
	public class DateTimeUtilsGetterTests
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
		/// Gets the calendar week count test.
		/// </summary>
		/// <returns>The calendar week count test.</returns>
		/// <param name="year">Year.</param>
		public static object GetCalendarWeekCountTest (int year)
		{
			try {
				object[] paramDate = { year };

				var returnGet = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetCalendarWeekCount", paramDate);

				return returnGet;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the day name test1.
		/// </summary>
		/// <returns>The day name test1.</returns>
		/// <param name="dayOfWeek">Day of week.</param>
		public static object GetDayNameTest1 (DayOfWeek dayOfWeek)
		{
			try {
				object[] paramDate = { dayOfWeek };

				var returnGet = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetDayName", paramDate);

				return returnGet;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the day name test2.
		/// </summary>
		/// <returns>The day name test2.</returns>
		/// <param name="dayOfWeek">Day of week.</param>
		/// <param name="cultureInfo">Culture info.</param>
		public static object GetDayNameTest2 (DayOfWeek dayOfWeek, CultureInfo cultureInfo)
		{
			try {
				object[] paramDate = { dayOfWeek, cultureInfo };

				var returnGet = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetDayName", paramDate);

				return returnGet;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the quarter test.
		/// </summary>
		/// <returns>The quarter test.</returns>
		/// <param name="date">Date.</param>
		public static object GetQuarterTest (DateTime date)
		{
			try {
				object[] paramDate = { date };

				var returnGet = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetQuarter", paramDate);

				return returnGet;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

