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


		private static DateTime FirstWeekInThisYear (string dateString)
		{
			try {
				
				object[] paramDateString = { dateString };

				var returnDate = appBase.ComponentLoader.InvokeMethod (convertUtils.Assembly, convertUtils.Class, "NormalizeDate", paramDateString);

				return (DateTime)returnDate;
			} catch (Exception ex) {
				throw ex;
			}
		}

		public static object GetCalendarWeekTest (string paramDateString)
		{
			try {
				var varDate = FirstWeekInThisYear(paramDateString);
				object[] paramDate = { varDate };

				var calendarWeek = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetCalendarWeek", paramDate);

				return calendarWeek;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		public static object GetGermanCalendarWeekTest (string paramDateString)
		{
			try {
				var varDate = FirstWeekInThisYear(paramDateString);
				object[] paramDate = { varDate };

				var calendarWeek = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetGermanCalendarWeek", paramDate);

				return calendarWeek;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

