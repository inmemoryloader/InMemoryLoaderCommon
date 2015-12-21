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
	public class CheckUtilsIntegerTests
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
		/// The is int.
		/// </summary>
		private const int isInt = 123;
		/// <summary>
		/// The is string.
		/// </summary>
		private const string isString = "Some String";
		/// <summary>
		/// The is string int.
		/// </summary>
		private const string isStringInt = "521";

		/// <summary>
		/// Determines if is int = true
		/// </summary>
		/// <returns><c>true</c> if is int test1; otherwise, <c>false</c>.</returns>
		public static bool IsIntTest1 ()
		{
			try {
				object[] paramArg = { isInt };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringInt", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is int = true
		/// </summary>
		/// <returns><c>true</c> if is int test2; otherwise, <c>false</c>.</returns>
		public static bool IsIntTest2 ()
		{
			try {
				object[] paramArg = { isStringInt };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringInt", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is int = true
		/// </summary>
		/// <returns><c>true</c> if is int test3; otherwise, <c>false</c>.</returns>
		public static bool IsIntTest3 ()
		{
			try {
				object[] paramArg = { isStringInt, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringInt", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is int = false
		/// </summary>
		/// <returns><c>true</c> if is int test4; otherwise, <c>false</c>.</returns>
		public static bool IsIntTest4 ()
		{
			try {
				object[] paramArg = { isString, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringInt", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

