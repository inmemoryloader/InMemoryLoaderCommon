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
	public class DateTimeUtilsDateDiffTests
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
		/// Gets the week difference test.
		/// </summary>
		/// <returns>The week difference test.</returns>
		/// <param name="firstDate">First date.</param>
		/// <param name="lastDate">Last date.</param>
		public static object GetWeekDifferenceTest (DateTime firstDate, DateTime lastDate)
		{
			try {
				object[] paramDate = { firstDate, lastDate };

				var dateDiff = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetWeekDifference", paramDate);

				return dateDiff;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the month difference test.
		/// </summary>
		/// <returns>The month difference test.</returns>
		/// <param name="firstDate">First date.</param>
		/// <param name="lastDate">Last date.</param>
		public static object GetMonthDifferenceTest (DateTime firstDate, DateTime lastDate)
		{
			try {
				object[] paramDate = { firstDate, lastDate };

				var dateDiff = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetMonthDifference", paramDate);

				return dateDiff;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the year difference test.
		/// </summary>
		/// <returns>The year difference test.</returns>
		/// <param name="firstDate">First date.</param>
		/// <param name="lastDate">Last date.</param>
		public static object GetYearDifferenceTest (DateTime firstDate, DateTime lastDate)
		{
			try {
				object[] paramDate = { firstDate, lastDate };

				var dateDiff = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetYearDifference", paramDate);

				return dateDiff;
			} catch (Exception ex) {
				throw ex;
			}		
		}

	}
}

