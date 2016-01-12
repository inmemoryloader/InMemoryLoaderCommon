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


		[Test ()]
		public void DateTimeUtilsCalendarWeekTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "DateTimeUtilsCalendarWeekTestCase");

				var dateString = "19.01.2016"; // 4. Kalenderwoche
				var returnCalendarWeek = DateTimeUtilsCalendarWeekTests.GetCalendarWeekTest (dateString);

				var year = returnCalendarWeek.GetType ().GetField ("Year").GetValue(returnCalendarWeek);
				var week = returnCalendarWeek.GetType ().GetField ("Week").GetValue(returnCalendarWeek);

				log.InfoFormat ("GetCalendarWeekTest is Year {0} and Week {1}", year, week);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		[Test ()]
		public void DateTimeUtilsCalendarWeekTestCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "DateTimeUtilsCalendarWeekTestCase");

				var dateString = "01.01.2016"; // 1. Kalenderwoche
				var returnCalendarWeek = DateTimeUtilsCalendarWeekTests.GetCalendarWeekTest (dateString);

				var year = returnCalendarWeek.GetType ().GetField ("Year").GetValue(returnCalendarWeek);
				var week = returnCalendarWeek.GetType ().GetField ("Week").GetValue(returnCalendarWeek);

				log.InfoFormat ("GetCalendarWeekTest is Year {0} and Week {1}", year, week);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		[Test ()]
		public void DateTimeUtilsGermanCalendarWeekTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "DateTimeUtilsGermanCalendarWeekTestCase");

				var dateString = "19.01.2016"; // 4. Kalenderwoche
				var returnCalendarWeek = DateTimeUtilsCalendarWeekTests.GetGermanCalendarWeekTest (dateString);

				var year = returnCalendarWeek.GetType ().GetField ("Year").GetValue(returnCalendarWeek);
				var week = returnCalendarWeek.GetType ().GetField ("Week").GetValue(returnCalendarWeek);

				log.InfoFormat ("GetGermanCalendarWeekTest is Year {0} and Week {1}", year, week);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		[Test ()]
		public void DateTimeUtilsGermanCalendarWeekTestCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "DateTimeUtilsGermanCalendarWeekTestCase");

				var dateString = "01.01.2016"; // 1. Kalenderwoche
				var returnCalendarWeek = DateTimeUtilsCalendarWeekTests.GetGermanCalendarWeekTest (dateString);

				var year = returnCalendarWeek.GetType ().GetField ("Year").GetValue(returnCalendarWeek);
				var week = returnCalendarWeek.GetType ().GetField ("Week").GetValue(returnCalendarWeek);

				log.InfoFormat ("GetGermanCalendarWeekTest is Year {0} and Week {1}", year, week);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}
	}
}

