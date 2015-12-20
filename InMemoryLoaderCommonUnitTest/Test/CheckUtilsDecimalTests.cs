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
	public class CheckUtilsDecimalTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The check utils.
		/// </summary>
		private static IDynamicClassSetup checkUtils = appBase.CommonComponentLoader.CheckComponent;

		/// <summary>
		/// The is decimal.
		/// </summary>
		private const Decimal isDecimal = 3.12m;
		/// <summary>
		/// The is string.
		/// </summary>
		private const string isString = "Some String";

		/// <summary>
		/// Determines if is decimal = true
		/// </summary>
		/// <returns><c>true</c> if is decimal test1; otherwise, <c>false</c>.</returns>
		public static bool IsDecimalTest1 ()
		{
			try {
				object[] paramArg = { isDecimal };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringDecimal", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is decimal = true
		/// </summary>
		/// <returns><c>true</c> if is decimal test2; otherwise, <c>false</c>.</returns>
		public static bool IsDecimalTest2 ()
		{
			try {
				object[] paramArg = { isDecimal, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringDecimal", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is decimal = false
		/// </summary>
		/// <returns><c>true</c> if is decimal test3; otherwise, <c>false</c>.</returns>
		public static bool IsDecimalTest3 ()
		{
			try {
				object[] paramArg = { isString, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringDecimal", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

