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
	public class CheckUtilsFloatTests
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
		/// The is float.
		/// </summary>
		private const float isFloat = 1.32f;
		/// <summary>
		/// The is string.
		/// </summary>
		private const string isString = "Some String";
		/// <summary>
		/// The is string float.
		/// </summary>
		private const string isStringFloat = "5.687";

		/// <summary>
		/// Determines if is float = true
		/// </summary>
		/// <returns><c>true</c> if is float test1; otherwise, <c>false</c>.</returns>
		public static bool IsFloatTest1 ()
		{
			try {
				object[] paramArg = { isFloat };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringFloat", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is float = false
		/// </summary>
		/// <returns><c>true</c> if is float test2; otherwise, <c>false</c>.</returns>
		public static bool IsFloatTest2 ()
		{
			try {
				object[] paramArg = { isString };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringFloat", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is float = true
		/// </summary>
		/// <returns><c>true</c> if is float test3; otherwise, <c>false</c>.</returns>
		public static bool IsFloatTest3 ()
		{
			try {
				object[] paramArg = { isStringFloat, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringFloat", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

