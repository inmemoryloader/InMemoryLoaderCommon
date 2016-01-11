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
using PowerUpDateTimeUtils;

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


		private static DateTime FirstWeekInThisYear ()
		{
			try {
				var dateString = "01.01.2016";
				object[] paramDateString = { dateString };

				var returnDate = appBase.ComponentLoader.InvokeMethod (convertUtils.Assembly, convertUtils.Class, "NormalizeDate", paramDateString);

				return (DateTime)returnDate;
			} catch (Exception ex) {
				throw ex;
			}
		}

		public static CalendarWeek GetCalendarWeekTest ()
		{
			try {
				var varDate = FirstWeekInThisYear();
				object[] paramDate = { varDate };

				var calendarWeek = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetCalendarWeek", paramDate);

				return (CalendarWeek)calendarWeek;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

