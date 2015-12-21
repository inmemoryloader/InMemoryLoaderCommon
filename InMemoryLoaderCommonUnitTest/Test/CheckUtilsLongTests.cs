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
	public class CheckUtilsLongTests
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
		private const long isLong = 12345678;
		/// <summary>
		/// The is string.
		/// </summary>
		private const string isString = "Some String";
		/// <summary>
		/// The is string int.
		/// </summary>
		private const string isStringLong = "521345678";

		/// <summary>
		/// Determines if is long = true
		/// </summary>
		/// <returns><c>true</c> if is long test1; otherwise, <c>false</c>.</returns>
		public static bool IsLongTest1 ()
		{
			try {
				object[] paramArg = { isLong };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringLong", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is long = true
		/// </summary>
		/// <returns><c>true</c> if is long test2; otherwise, <c>false</c>.</returns>
		public static bool IsLongTest2 ()
		{
			try {
				object[] paramArg = { isStringLong };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringLong", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is long = false
		/// </summary>
		/// <returns><c>true</c> if is long test3; otherwise, <c>false</c>.</returns>
		public static bool IsLongTest3 ()
		{
			try {
				object[] paramArg = { isString };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringLong", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

