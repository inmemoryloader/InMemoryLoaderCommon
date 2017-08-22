using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommonTestSuite.DateTimeUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// Determines if is potential date time test.
		/// </summary>
		/// <returns><c>true</c> if is potential date time test; otherwise, <c>false</c>.</returns>
		public static bool IsPotentialDateTimeTest ()
		{
			bool isPotentialDateTimeTest = false;

			isPotentialDateTimeTest = IsPotentialDateTimeTest1 ();
			isPotentialDateTimeTest = IsPotentialDateTimeTest2 ();
			isPotentialDateTimeTest = IsPotentialDateTimeTest3 ();
			isPotentialDateTimeTest = IsPotentialTimeTest1 ();
			isPotentialDateTimeTest = IsPotentialDateTest1 ();

			return isPotentialDateTimeTest;
		}

		/// <summary>
		/// Determines if is potential date time test1.
		/// </summary>
		/// <returns><c>true</c> if is potential date time test1; otherwise, <c>false</c>.</returns>
		private static bool IsPotentialDateTimeTest1 ()
		{
			try {
				bool isTrue = false;

				var dateString = "01/08/2008 14:50:50";
				var includeDate = true;
				var includeTime = true;
				var allowZeroForDayAndMonth = true;

				object[] paramDate = { dateString, includeDate, includeTime, allowZeroForDayAndMonth };
				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "IsPotentialDateTime", paramDate);

				isTrue = Convert.ToBoolean (isPotential);

				log.DebugFormat ("IsPotentialDateTime (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Determines if is potential date time test2.
		/// </summary>
		/// <returns><c>true</c> if is potential date time test2; otherwise, <c>false</c>.</returns>
		private static bool IsPotentialDateTimeTest2 ()
		{
			try {
				bool isTrue = false;

				var dateString = "01/08/2008 14:50:50";
				var includeDate = true;
				var includeTime = true;
				var allowZeroForDayAndMonth = true;
				var culture = new CultureInfo ("en-GB");

				object[] paramDate = { dateString, includeDate, includeTime, allowZeroForDayAndMonth, culture };
				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "IsPotentialDateTime", paramDate);

				isTrue = Convert.ToBoolean (isPotential);

				log.DebugFormat ("IsPotentialDateTime (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Determines if is potential date time test3.
		/// </summary>
		/// <returns><c>true</c> if is potential date time test3; otherwise, <c>false</c>.</returns>
		private static bool IsPotentialDateTimeTest3 ()
		{
			try {
				bool isTrue = false;

				var dateString = "01/08/2008 14:50:50";
				var includeDate = true;
				var includeTime = true;
				var allowZeroForDayAndMonth = true;
				var culture = new CultureInfo ("en-GB");

				object[] paramDate = { dateString, includeDate, includeTime, allowZeroForDayAndMonth, culture };
				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "IsPotentialDateTime_StringBuilderTest", paramDate);

				isTrue = Convert.ToBoolean (isPotential);

				log.DebugFormat ("IsPotentialDateTime_StringBuilderTest (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Determines if is potential time test1.
		/// </summary>
		/// <returns><c>true</c> if is potential time test1; otherwise, <c>false</c>.</returns>
		private static bool IsPotentialTimeTest1 ()
		{
			try {
				bool isTrue = false;

				var dateString = "14:50:50";
				var culture = new CultureInfo ("en-GB");

				object[] paramDate = { dateString, culture };
				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "IsPotentialTime", paramDate);

				isTrue = Convert.ToBoolean (isPotential);

				log.DebugFormat ("IsPotentialTime (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Determines if is potential date test1.
		/// </summary>
		/// <returns><c>true</c> if is potential date test1; otherwise, <c>false</c>.</returns>
		private static bool IsPotentialDateTest1 ()
		{
			try {
				bool isTrue = false;

				var dateString = "01/08/2008";
				var allowZeroForDayAndMonth = true;
				var culture = new CultureInfo ("en-GB");

				object[] paramDate = { dateString, allowZeroForDayAndMonth, culture };
				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "IsPotentialDate", paramDate);

				isTrue = Convert.ToBoolean (isPotential);

				log.DebugFormat ("IsPotentialDate (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}