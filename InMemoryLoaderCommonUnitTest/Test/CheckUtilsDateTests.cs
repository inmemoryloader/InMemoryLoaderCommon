using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;

namespace InMemoryLoaderCommonUnitTest
{
	public class CheckUtilsDateTests
	{
		private static AppBase appBase = AppBase.Instance;
		private static IDynamicClassSetup checkUtils = appBase.CommonComponentLoader.CheckComponent;

		private static DateTime isDate = DateTime.Now;
		private const string isString = "Some String";

		/// <summary>
		/// Determines if is date = true
		/// </summary>
		/// <returns><c>true</c> if is date test1; otherwise, <c>false</c>.</returns>
		public static bool IsDateTest1 ()
		{
			try {
				object[] paramArg = { isDate.ToString() };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringDate", paramArg);
				var isTrue = Convert.ToBoolean(result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is date = true
		/// </summary>
		/// <returns><c>true</c> if is date test2; otherwise, <c>false</c>.</returns>
		public static bool IsDateTest2 ()
		{
			try {
				object[] paramArg = { isDate.ToString(), CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringDate", paramArg);
				var isTrue = Convert.ToBoolean(result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		// / Determines if is date = false
		/// </summary>
		/// <returns><c>true</c> if is date test2; otherwise, <c>false</c>.</returns>
		public static bool IsDateTest3 ()
		{
			try {
				object[] paramArg = { isString, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringDate", paramArg);
				var isTrue = Convert.ToBoolean(result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

