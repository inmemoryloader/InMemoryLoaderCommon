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
	public class DateTimeUtilsGetAgeTests
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
		/// Gets the age test1.
		/// </summary>
		/// <returns>The age test1.</returns>
		/// <param name="firstDate">First date.</param>
		/// <param name="lastDate">Last date.</param>
		public static object GetAgeTest1 (DateTime firstDate, DateTime lastDate)
		{
			try {
				object[] paramDate = { firstDate, lastDate };

				var getAge = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetAge", paramDate);

				return getAge;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the age test2.
		/// </summary>
		/// <returns>The age test2.</returns>
		/// <param name="firstDate">First date.</param>
		/// <param name="lastDate">Last date.</param>
		public static object GetAgeTest2 (DateTimeOffset firstDate, DateTimeOffset lastDate)
		{
			try {
				object[] paramDate = { firstDate, lastDate };

				var getAge = appBase.ComponentLoader.InvokeMethod (dateTimeUtils.Assembly, dateTimeUtils.Class, "GetAge", paramDate);

				return getAge;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

