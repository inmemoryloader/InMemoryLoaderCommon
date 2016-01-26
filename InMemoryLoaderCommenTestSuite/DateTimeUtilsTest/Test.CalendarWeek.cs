using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;

namespace InMemoryLoaderCommenTestSuite.DateTimeUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// Dates the time calendar week test.
		/// </summary>
		/// <returns><c>true</c>, if time calendar week test was dated, <c>false</c> otherwise.</returns>
		public static bool DateTimeCalendarWeekTest ()
		{
			bool dateTimeCalendarWeekTest = false;

			dateTimeCalendarWeekTest = NormalizeDateTest ();
			dateTimeCalendarWeekTest = GetCalendarWeekStartDateTest ();
			dateTimeCalendarWeekTest = GetGermanCalendarWeekStartDateTest ();

			return dateTimeCalendarWeekTest;
		}

		/// <summary>
		/// Normalizes the date test.
		/// </summary>
		/// <returns><c>true</c>, if date test was normalized, <c>false</c> otherwise.</returns>
		private static bool NormalizeDateTest ()
		{
			try {
				bool isTrue = false;
				string dateString = "2015-08-12 12:53:23";

				object[] paramDateString = { dateString };
				var returnDate = (DateTime)appBase.ComponentLoader.InvokeMethod (convertUtils, "NormalizeDate", paramDateString);

				if (returnDate.GetType() == typeof(DateTime)) {
					isTrue = true;
				}

				log.DebugFormat ("NormalizeDate (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Gets the calendar week start date test.
		/// </summary>
		/// <returns><c>true</c>, if calendar week start date test was gotten, <c>false</c> otherwise.</returns>
		private static bool GetCalendarWeekStartDateTest ()
		{
			try {
				bool isTrue = false;
				var yearInt = 2016;
				var weekInt = 1;
				var startDate = new DateTime (2016, 01, 04);

				object[] paramDate = { weekInt, yearInt };
				var weekStartDate = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetCalendarWeekStartDate", paramDate);

				if (weekStartDate.Equals(startDate)) {
					isTrue = true;
				}

				log.DebugFormat ("GetCalendarWeekStartDate (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the german calendar week start date test.
		/// </summary>
		/// <returns><c>true</c>, if german calendar week start date test was gotten, <c>false</c> otherwise.</returns>
		private static bool GetGermanCalendarWeekStartDateTest ()
		{
			try {
				bool isTrue = false;
				var yearInt = 2016;
				var weekInt = 1;
				var startDate = new DateTime (2016, 01, 04);

				object[] paramDate = { weekInt, yearInt };
				var weekStartDate = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetGermanCalendarWeekStartDate", paramDate);

				if (weekStartDate.Equals(startDate)) {
					isTrue = true;
				}

				log.DebugFormat ("GetGermanCalendarWeekStartDate (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}