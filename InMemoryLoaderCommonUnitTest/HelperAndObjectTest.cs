using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class HelperAndObjectTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(HelperAndObjectTest));

		/// <summary>
		/// Calendars the info test case.
		/// </summary>
		[Test ()]
		public void CalendarInfoTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CalendarInfoTestCase");

				var dateFormatInfo = HelperAndObjectTests.CalendarInfoTest ();

				var Calendar = ObjectHelper.GetFieldValue ("Calendar", dateFormatInfo);
				var DaysInMonthMax = ObjectHelper.GetFieldValue ("DaysInMonthMax", dateFormatInfo);
				var DaysInMonthMin = ObjectHelper.GetFieldValue ("DaysInMonthMin", dateFormatInfo);
				var MonthInYearMax = ObjectHelper.GetFieldValue ("MonthInYearMax", dateFormatInfo);
				var SampleCulture = ObjectHelper.GetFieldValue ("SampleCulture", dateFormatInfo);
				var CalendarName = ObjectHelper.GetFieldValue ("CalendarName", dateFormatInfo);
				var AlgorithmTypeName = ObjectHelper.GetFieldValue ("AlgorithmTypeName", dateFormatInfo);
				var MonthInYearMin = ObjectHelper.GetFieldValue ("MonthInYearMin", dateFormatInfo);

				log.InfoFormat ("Calendar:{0}, DaysInMonthMax:{1}, DaysInMonthMin:{2}, MonthInYearMax:{3}", 
					Calendar, DaysInMonthMax, DaysInMonthMin, MonthInYearMax);

				log.InfoFormat ("SampleCulture:{0}, CalendarName:{1}, AlgorithmTypeName:{2}, MonthInYearMin:{3}", 
					SampleCulture, CalendarName, AlgorithmTypeName, MonthInYearMin);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Helpers the and object test case.
		/// </summary>
		[Test ()]
		public void GetDateFormatInfoTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "GetDateFormatInfoTestCase");

				var dateFormatInfo = HelperAndObjectTests.DateFormatInfoTest ();

				Assert.IsNotNull (dateFormatInfo);

				var dayPosition = ObjectHelper.GetPropertyValue ("DayPosition", dateFormatInfo);
				var isAmPmTime = ObjectHelper.GetPropertyValue ("IsAmPmTime", dateFormatInfo);
				var monthPosition = ObjectHelper.GetPropertyValue ("MonthPosition", dateFormatInfo);
				var yearPosition = ObjectHelper.GetPropertyValue ("YearPosition", dateFormatInfo);

				var dateFormat = ObjectHelper.GetFieldValue ("DateFormat", dateFormatInfo);
				var dateTimeSeparatorPattern = ObjectHelper.GetFieldValue ("DateTimeSeparatorPattern", dateFormatInfo);
				var dateSuffixPattern = ObjectHelper.GetFieldValue ("DateSuffixPattern", dateFormatInfo);
				var cultureInfo = ObjectHelper.GetFieldValue ("CultureInfo", dateFormatInfo);
				var timeInputIn24HourFormatEnabled = ObjectHelper.GetFieldValue ("TimeInputIn24HourFormatEnabled", dateFormatInfo);
				var amPmSeparator = ObjectHelper.GetFieldValue ("AmPmSeparator", dateFormatInfo);
				var pMString = ObjectHelper.GetFieldValue ("PMString", dateFormatInfo);
				var aMString = ObjectHelper.GetFieldValue ("AMString", dateFormatInfo);
				var amPmType = ObjectHelper.GetFieldValue ("AmPmType", dateFormatInfo);

				log.InfoFormat ("DayPosition:{0}, IsAmPmTime:{1}, MonthPosition:{2}, YearPosition:{3}", 
					dayPosition, isAmPmTime, monthPosition, yearPosition);

				log.InfoFormat ("DateFormat:{0}, DateTimeSeparatorPattern:{1}, DateSuffixPattern:{2}, CultureInfo:{3}," +
				"TimeInputIn24HourFormatEnabled:{4},AmPmSeparator:{5},PMString:{6},AMString:{7},AmPmType:{8}", 
					dateFormat, dateTimeSeparatorPattern, dateSuffixPattern, cultureInfo,
					timeInputIn24HourFormatEnabled, amPmSeparator, pMString, aMString, amPmType);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}


	}
}

