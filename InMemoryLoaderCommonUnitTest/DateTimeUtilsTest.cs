using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class DateTimeUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(CryptUtilsTest));

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

				var returnDate = DateTimeUtilsCalendarWeekTests.GetWeekDifferenceTest (firstDate, lastDate);

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

				var returnDate = DateTimeUtilsCalendarWeekTests.GetMonthDifferenceTest (firstDate, lastDate);

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

				var returnDate = DateTimeUtilsCalendarWeekTests.GetYearDifferenceTest (firstDate, lastDate);

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

