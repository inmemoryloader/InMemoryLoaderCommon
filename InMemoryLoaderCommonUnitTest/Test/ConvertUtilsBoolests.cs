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
	public class ConvertUtilsBoolests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The convert utils.
		/// </summary>
		private static IDynamicClassSetup convertUtils = appBase.CommonComponentLoader.ConvertComponent;

		/// <summary>
		/// The is string true.
		/// </summary>
		private const string isStringTrue = "1";
		/// <summary>
		/// The is string false.
		/// </summary>
		private const string isStringFalse = "0";
		/// <summary>
		/// The is char true.
		/// </summary>
		private const char isCharTrue = '1';
		/// <summary>
		/// The is char false.
		/// </summary>
		private const char isCharFalse = '0';

		/// <summary>
		/// Converts the bool = true
		/// </summary>
		/// <returns><c>true</c>, if bool test1 was converted, <c>false</c> otherwise.</returns>
		public static bool ConvertBoolTest1 ()
		{
			try {
				object[] paramArg = { isStringTrue };

				var result = appBase.ComponentLoader.InvokeMethod (convertUtils.Assembly, convertUtils.Class, "StringToBoolean", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Converts the bool = false
		/// </summary>
		/// <returns><c>true</c>, if bool test2 was converted, <c>false</c> otherwise.</returns>
		public static bool ConvertBoolTest2 ()
		{
			try {
				object[] paramArg = { isStringFalse };

				var result = appBase.ComponentLoader.InvokeMethod (convertUtils.Assembly, convertUtils.Class, "StringToBoolean", paramArg);
				var isTrue = Convert.ToBoolean (result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}



	}
}

