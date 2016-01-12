using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class DateTimeUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(CryptUtilsTest));


		[Test ()]
		public void GetterTestCase4 ()
		{
			try {
				log.InfoFormat ("{0}", "GetterTestCase3");

				var dayOfWeek = new DateTime (2016, 12, 08);
				var expected = 4;

				var returnGet = DateTimeUtilsGetterTests.GetQuarterTest (dayOfWeek);

				Assert.AreEqual (expected, returnGet);

				log.InfoFormat ("GetQuarterTest is {0}", returnGet);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		[Test ()]
		public void GetterTestCase3 ()
		{
			try {
				log.InfoFormat ("{0}", "GetterTestCase3");

				var dayOfWeek = new DateTime (2016, 01, 25).DayOfWeek;
				var expected = "Montag";
				var culture = new CultureInfo ("de");

				var returnGet = DateTimeUtilsGetterTests.GetDayNameTest2 (dayOfWeek, culture);

				Assert.AreEqual (expected, returnGet);

				log.InfoFormat ("GetDayNameTest2 is {0}", returnGet);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		[Test ()]
		public void GetterTestCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "GetterTestCase2");

				var dayOfWeek = new DateTime (2016, 01, 25).DayOfWeek;
				var expected = "Monday";

				var returnGet = DateTimeUtilsGetterTests.GetDayNameTest1 (dayOfWeek);

				Assert.AreEqual (expected, returnGet);

				log.InfoFormat ("GetDayNameTest1 is {0}", returnGet);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		[Test ()]
		public void GetterTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "GetterTestCase1");

				var year = 2015;
				var expected = 53;

				var returnGet = DateTimeUtilsGetterTests.GetCalendarWeekCountTest (year);

				var getter = Convert.ToInt32 (returnGet);

				Assert.AreEqual (expected, getter);

				log.InfoFormat ("GetCalendarWeekCountTest is {0}", getter);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Gets the age test case2.
		/// </summary>
		[Test ()]
		public void GetAgeTestCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "GetAgeTestCase2");

				var firstDateTime = new DateTime (1975, 12, 08);
				var lastDateTime = new DateTime (2016, 12, 08);

				var firstDate = new DateTimeOffset (firstDateTime);
				var lastDate = new DateTimeOffset (lastDateTime);

				var expectedValue = 41;

				var returnDate = DateTimeUtilsGetAgeTests.GetAgeTest2 (firstDate, lastDate);

				var getAge = Convert.ToInt32 (returnDate);

				Assert.AreEqual (expectedValue, getAge);

				log.InfoFormat ("GetAgeTest2 is {0}", getAge);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Gets the age test case1.
		/// </summary>
		[Test ()]
		public void GetAgeTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "GetAgeTestCase1");

				var firstDate = new DateTime (1975, 12, 08);
				var lastDate = new DateTime (2016, 12, 08);
				var expectedValue = 41;

				var returnDate = DateTimeUtilsGetAgeTests.GetAgeTest1 (firstDate, lastDate);

				var getAge = Convert.ToInt32 (returnDate);

				Assert.AreEqual (expectedValue, getAge);

				log.InfoFormat ("GetAgeTest1 is {0}", getAge);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Gets the date diff test case3.
		/// </summary>
		[Test ()]
		public void GetDateDiffTestCase3 ()
		{
			try {
				log.InfoFormat ("{0}", "GetDateDiffTestCase3");

				var firstDate = new DateTime (1975, 12, 08);
				var lastDate = new DateTime (2016, 12, 08);
				var expectedValue = 2139;

				var returnDate = DateTimeUtilsDateDiffTests.GetWeekDifferenceTest (firstDate, lastDate);

				var weekDifference = Convert.ToInt32 (returnDate);

				Assert.AreEqual (expectedValue, weekDifference);

				log.InfoFormat ("GetWeekDifferenceTest is {0}", weekDifference);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Gets the date diff test case2.
		/// </summary>
		[Test ()]
		public void GetDateDiffTestCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "GetDateDiffTestCase2");

				var firstDate = new DateTime (1975, 12, 08);
				var lastDate = new DateTime (2016, 12, 08);
				var expectedValue = 492;

				var returnDate = DateTimeUtilsDateDiffTests.GetMonthDifferenceTest (firstDate, lastDate);

				var monthDifference = Convert.ToInt32 (returnDate);

				Assert.AreEqual (expectedValue, monthDifference);

				log.InfoFormat ("GetMonthDifferenceTest is {0}", monthDifference);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Gets the date diff test case1.
		/// </summary>
		[Test ()]
		public void GetDateDiffTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "GetDateDiffTestCase1");

				var firstDate = new DateTime (1975, 12, 08);
				var lastDate = new DateTime (2016, 12, 08);
				var expectedValue = 41;

				var returnDate = DateTimeUtilsDateDiffTests.GetYearDifferenceTest (firstDate, lastDate);

				var yearDifference = Convert.ToInt32 (returnDate);

				Assert.AreEqual (expectedValue, yearDifference);

				log.InfoFormat ("GetYearDifferenceTest is {0}", yearDifference);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Gets the calendar week start date test case1.
		/// </summary>
		[Test ()]
		public void GetCalendarWeekStartDateTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "GetCalendarWeekStartDateTestCase1");

				var yearInt = 2016;
				var weekInt = 1;

				var returnDate = DateTimeUtilsCalendarWeekTests.GetCalendarWeekStartDateTest (weekInt, yearInt);

				var startDate = new DateTime (2016, 01, 04);

				Assert.AreEqual (startDate, returnDate);

				log.InfoFormat ("GetCalendarWeekStartDateTest is Year {0}", returnDate);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Gets the german calendar week start date test case1.
		/// </summary>
		[Test ()]
		public void GetGermanCalendarWeekStartDateTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "GetGermanCalendarWeekStartDateTestCase1");

				var yearInt = 2016;
				var weekInt = 1;

				var returnDate = DateTimeUtilsCalendarWeekTests.GetGermanCalendarWeekStartDateTest (weekInt, yearInt);

				var startDate = new DateTime (2016, 01, 04);

				Assert.AreEqual (startDate, returnDate);

				log.InfoFormat ("GetGermanCalendarWeekStartDateTest is Year {0}", returnDate);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Dates the time utils calendar week test case1.
		/// </summary>
		[Test ()]
		public void DateTimeUtilsCalendarWeekTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "DateTimeUtilsCalendarWeekTestCase");

				var dateString = "19.01.2016"; // 4. Kalenderwoche
				var returnCalendarWeek = DateTimeUtilsCalendarWeekTests.GetCalendarWeekTest (dateString);

				var year = ObjectHelper.GetFieldValue ("Year", returnCalendarWeek);
				var week = ObjectHelper.GetFieldValue ("Week", returnCalendarWeek);

				Assert.AreEqual (3, week);
				Assert.AreEqual (2016, year);

				log.InfoFormat ("GetCalendarWeekTest is Year {0} and Week {1}", year, week);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Dates the time utils calendar week test case2.
		/// </summary>
		[Test ()]
		public void DateTimeUtilsCalendarWeekTestCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "DateTimeUtilsCalendarWeekTestCase");

				var dateString = "01.01.2016"; // 1. Kalenderwoche
				var returnCalendarWeek = DateTimeUtilsCalendarWeekTests.GetCalendarWeekTest (dateString);

				var year = ObjectHelper.GetFieldValue ("Year", returnCalendarWeek);
				var week = ObjectHelper.GetFieldValue ("Week", returnCalendarWeek);

				Assert.AreEqual (53, week);
				Assert.AreEqual (2015, year);

				log.InfoFormat ("GetCalendarWeekTest is Year {0} and Week {1}", year, week);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Dates the time utils german calendar week test case1.
		/// </summary>
		[Test ()]
		public void DateTimeUtilsGermanCalendarWeekTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "DateTimeUtilsGermanCalendarWeekTestCase");

				var dateString = "19.01.2016"; // 4. Kalenderwoche
				var returnCalendarWeek = DateTimeUtilsCalendarWeekTests.GetGermanCalendarWeekTest (dateString);

				var year = ObjectHelper.GetFieldValue ("Year", returnCalendarWeek);
				var week = ObjectHelper.GetFieldValue ("Week", returnCalendarWeek);

				Assert.AreEqual (3, week);
				Assert.AreEqual (2016, year);

				log.InfoFormat ("GetGermanCalendarWeekTest is Year {0} and Week {1}", year, week);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Dates the time utils german calendar week test case2.
		/// </summary>
		[Test ()]
		public void DateTimeUtilsGermanCalendarWeekTestCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "DateTimeUtilsGermanCalendarWeekTestCase");

				var dateString = "01.01.2016"; // 53. Kalenderwoche
				var returnCalendarWeek = DateTimeUtilsCalendarWeekTests.GetGermanCalendarWeekTest (dateString);

				var year = ObjectHelper.GetFieldValue ("Year", returnCalendarWeek);
				var week = ObjectHelper.GetFieldValue ("Week", returnCalendarWeek);

				Assert.AreEqual (53, week);
				Assert.AreEqual (2015, year);

				log.InfoFormat ("GetGermanCalendarWeekTest is Year {0} and Week {1}", year, week);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}
	}
}

