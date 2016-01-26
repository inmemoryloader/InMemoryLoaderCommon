using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;

namespace InMemoryLoaderCommenTestSuite.DateTimeUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// Getters the test.
		/// </summary>
		/// <returns><c>true</c>, if test was gettered, <c>false</c> otherwise.</returns>
		public static bool GetterTest ()
		{
			bool getterTest = false;

			getterTest = GetCalendarWeekCountTest ();
			getterTest = GetDayNameTest1 ();
			getterTest = GetDayNameTest2 ();
			getterTest = GetQuarterTest ();

			return getterTest;
		}

		/// <summary>
		/// Gets the calendar week count test.
		/// </summary>
		/// <returns><c>true</c>, if calendar week count test was gotten, <c>false</c> otherwise.</returns>
		private static bool GetCalendarWeekCountTest ()
		{
			try {
				bool isTrue = false;

				var year = 2015;
				var expected = 53;

				object[] paramDate = { year };
				var returnGet = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetCalendarWeekCount", paramDate);

				var weeks = Convert.ToInt32 (returnGet);

				if (weeks.Equals (expected)) {
					isTrue = true;
				}

				log.DebugFormat ("GetCalendarWeekCount (53) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the day name test1.
		/// </summary>
		/// <returns><c>true</c>, if day name test1 was gotten, <c>false</c> otherwise.</returns>
		private static bool GetDayNameTest1 ()
		{
			try {
				bool isTrue = false;

				var dayOfWeek = new DateTime (2016, 01, 25).DayOfWeek;
				var expected = "Monday";

				object[] paramDate = { dayOfWeek };
				var returnGet = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetDayName", paramDate);

				if (returnGet.Equals (expected)) {
					isTrue = true;
				}

				log.DebugFormat ("GetDayName (Monday) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the day name test2.
		/// </summary>
		/// <returns><c>true</c>, if day name test2 was gotten, <c>false</c> otherwise.</returns>
		private static bool GetDayNameTest2 ()
		{
			try {
				bool isTrue = false;

				var dayOfWeek = new DateTime (2016, 01, 25).DayOfWeek;
				var expected = "Montag";
				var culture = new CultureInfo ("de");

				object[] paramDate = { dayOfWeek, culture };
				var returnGet = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetDayName", paramDate);

				if (returnGet.Equals (expected)) {
					isTrue = true;
				}

				log.DebugFormat ("GetDayName (Montag) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the quarter test.
		/// </summary>
		/// <returns><c>true</c>, if quarter test was gotten, <c>false</c> otherwise.</returns>
		private static bool GetQuarterTest ()
		{
			try {
				bool isTrue = false;

				var dayOfWeek = new DateTime (2016, 12, 08);
				var expected = 4;

				object[] paramDate = { dayOfWeek };
				var returnGet = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetQuarter", paramDate);

				var quarter = Convert.ToInt32 (returnGet);

				if (quarter.Equals (expected)) {
					isTrue = true;
				}

				log.DebugFormat ("GetQuarter (4) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}