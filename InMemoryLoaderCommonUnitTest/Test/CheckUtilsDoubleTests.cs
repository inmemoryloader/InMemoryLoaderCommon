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
	public class CheckUtilsDoubleTests
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
		private const Double isDouble = 3.12;
		/// <summary>
		/// The is string.
		/// </summary>
		private const string isString = "Some String";

		/// <summary>
		/// Determines if is double = true
		/// </summary>
		/// <returns><c>true</c> if is double test1; otherwise, <c>false</c>.</returns>
		public static bool IsDoubleTest1 ()
		{
			try {
				object[] paramArg = { isDouble };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringDouble", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is double = false
		/// </summary>
		/// <returns><c>true</c> if is double test2; otherwise, <c>false</c>.</returns>
		public static bool IsDoubleTest2 ()
		{
			try {
				object[] paramArg = { isString };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringDouble", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

