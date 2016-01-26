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
		/// The first date.
		/// </summary>
		private static DateTime firstDate = new DateTime (1975, 12, 8);
		/// <summary>
		/// The last date.
		/// </summary>
		private static DateTime lastDate = new DateTime (2015, 12, 8);

		/// <summary>
		/// Dates the time diff test.
		/// </summary>
		/// <returns><c>true</c>, if time diff test was dated, <c>false</c> otherwise.</returns>
		public static bool DateTimeDiffTest ()
		{
			bool dateTimeDiffTest = false;

			dateTimeDiffTest = GetWeekDifferenceTest ();
			dateTimeDiffTest = GetMonthDifferenceTest ();
			dateTimeDiffTest = GetYearDifferenceTest ();

			return dateTimeDiffTest;
		}

		/// <summary>
		/// Gets the week difference test.
		/// </summary>
		/// <returns><c>true</c>, if week difference test was gotten, <c>false</c> otherwise.</returns>
		private static bool GetWeekDifferenceTest ()
		{
			try {
				bool isTrue = false;
				
				object[] paramDate = { firstDate, lastDate };
				var dateDiff = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetWeekDifference", paramDate);

				var diff = Convert.ToInt32(dateDiff);

				if (diff == 2087) {
					isTrue = true;
				}

				log.DebugFormat ("GetWeekDifference (2087) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the month difference test.
		/// </summary>
		/// <returns><c>true</c>, if month difference test was gotten, <c>false</c> otherwise.</returns>
		private static bool GetMonthDifferenceTest ()
		{
			try {
				bool isTrue = false;

				object[] paramDate = { firstDate, lastDate };
				var dateDiff = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetMonthDifference", paramDate);

				var diff = Convert.ToInt32(dateDiff);

				if (diff == 480) {
					isTrue = true;
				}

				log.DebugFormat ("GetMonthDifference (480) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the year difference test.
		/// </summary>
		/// <returns><c>true</c>, if year difference test was gotten, <c>false</c> otherwise.</returns>
		private static bool GetYearDifferenceTest ()
		{
			try {
				bool isTrue = false;

				object[] paramDate = { firstDate, lastDate };
				var dateDiff = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetYearDifference", paramDate);

				var diff = Convert.ToInt32(dateDiff);

				if (diff == 40) {
					isTrue = true;
				}

				log.DebugFormat ("GetYearDifference (40) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}