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
	public class DateTimeUtilsIsPotentialTests
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
		/// Determines if is potential date time test1 the specified input includeDate includeTime allowZeroForDayAndMonth.
		/// </summary>
		/// <returns><c>true</c> if is potential date time test1 the specified input includeDate includeTime allowZeroForDayAndMonth;
		/// otherwise, <c>false</c>.</returns>
		/// <param name="input">Input.</param>
		/// <param name="includeDate">If set to <c>true</c> include date.</param>
		/// <param name="includeTime">If set to <c>true</c> include time.</param>
		/// <param name="allowZeroForDayAndMonth">If set to <c>true</c> allow zero for day and month.</param>
		public static object IsPotentialDateTimeTest1 (string input, bool includeDate, bool includeTime, bool allowZeroForDayAndMonth)
		{
			try {
				object[] paramDate = { input, includeDate, includeTime, allowZeroForDayAndMonth };

				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "IsPotentialDateTime", paramDate);

				return isPotential;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Determines if is potential date time test2 the specified input includeDate includeTime allowZeroForDayAndMonth culture.
		/// </summary>
		/// <returns><c>true</c> if is potential date time test2 the specified input includeDate includeTime allowZeroForDayAndMonth
		/// culture; otherwise, <c>false</c>.</returns>
		/// <param name="input">Input.</param>
		/// <param name="includeDate">If set to <c>true</c> include date.</param>
		/// <param name="includeTime">If set to <c>true</c> include time.</param>
		/// <param name="allowZeroForDayAndMonth">If set to <c>true</c> allow zero for day and month.</param>
		/// <param name="culture">Culture.</param>
		public static object IsPotentialDateTimeTest2 (string input, bool includeDate, bool includeTime, bool allowZeroForDayAndMonth, CultureInfo culture)
		{
			try {
				object[] paramDate = { input, includeDate, includeTime, allowZeroForDayAndMonth, culture };

				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "IsPotentialDateTime", paramDate);

				return isPotential;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Determines if is potential date time test3 the specified input includeDate includeTime allowZeroForDayAndMonth culture.
		/// </summary>
		/// <returns><c>true</c> if is potential date time test3 the specified input includeDate includeTime allowZeroForDayAndMonth
		/// culture; otherwise, <c>false</c>.</returns>
		/// <param name="input">Input.</param>
		/// <param name="includeDate">If set to <c>true</c> include date.</param>
		/// <param name="includeTime">If set to <c>true</c> include time.</param>
		/// <param name="allowZeroForDayAndMonth">If set to <c>true</c> allow zero for day and month.</param>
		/// <param name="culture">Culture.</param>
		public static object IsPotentialDateTimeTest3 (string input, bool includeDate, bool includeTime, bool allowZeroForDayAndMonth, CultureInfo culture)
		{
			try {
				object[] paramDate = { input, includeDate, includeTime, allowZeroForDayAndMonth, culture };

				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "IsPotentialDateTime_StringBuilderTest", paramDate);

				return isPotential;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Determines if is potential time test1 the specified input culture.
		/// </summary>
		/// <returns><c>true</c> if is potential time test1 the specified input culture; otherwise, <c>false</c>.</returns>
		/// <param name="input">Input.</param>
		/// <param name="culture">Culture.</param>
		public static object IsPotentialTimeTest1 (string input, CultureInfo culture)
		{
			try {
				object[] paramDate = { input, culture };

				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "IsPotentialTime", paramDate);

				return isPotential;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Determines if is potential date test1 the specified input allowZeroForDayAndMonth culture.
		/// </summary>
		/// <returns><c>true</c> if is potential date test1 the specified input allowZeroForDayAndMonth culture; otherwise, <c>false</c>.</returns>
		/// <param name="input">Input.</param>
		/// <param name="allowZeroForDayAndMonth">If set to <c>true</c> allow zero for day and month.</param>
		/// <param name="culture">Culture.</param>
		public static object IsPotentialDateTest1 (string input, bool allowZeroForDayAndMonth, CultureInfo culture)
		{
			try {
				object[] paramDate = { input, allowZeroForDayAndMonth, culture };

				var isPotential = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "IsPotentialDate", paramDate);

				return isPotential;
			} catch (Exception ex) {
				throw ex;
			}		
		}

	}
}

