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
		public void DateTimeUtilsCalendarWeekTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "DateTimeUtilsCalendarWeekTestCase");

				// Date is 01.01.2016

				var returnCalendarWeek = DateTimeUtilsCalendarWeekTests.GetCalendarWeekTest();

				log.InfoFormat ("GetCalendarWeekTest is Year {0} and Week {1}", returnCalendarWeek.Year, returnCalendarWeek.Week);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}
	}
}

