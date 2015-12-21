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
	public class CheckUtilsUrlTests
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
		/// The is string URL.
		/// </summary>
		private const string isStringUrl = "http://www.google.ch/";
		/// <summary>
		/// The is string no URL.
		/// </summary>
		private const string isStringNoUrl = "Some String";

		/// <summary>
		/// Determines if is URL = true
		/// </summary>
		/// <returns><c>true</c> if is URL test1; otherwise, <c>false</c>.</returns>
		public static bool IsUrlTest1 ()
		{
			try {
				object[] paramArg = { isStringUrl };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsUrlValid", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is URL = false
		/// </summary>
		/// <returns><c>true</c> if is URL test2; otherwise, <c>false</c>.</returns>
		public static bool IsUrlTest2 ()
		{
			try {
				object[] paramArg = { isStringNoUrl };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsUrlValid", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

