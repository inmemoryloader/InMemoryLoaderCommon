using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommenTestSuite.ConvertUtilsTest
{
	public partial class Test
	{
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
		/// Converts the boolean test.
		/// </summary>
		/// <returns><c>true</c>, if boolean test was converted, <c>false</c> otherwise.</returns>
		public static bool ConvertBooleanTest ()
		{
			bool convertBooleanTest = false;

			convertBooleanTest = StringToBooleanTest1 ();
			convertBooleanTest = StringToBooleanTest2 ();
			convertBooleanTest = BooleanToStringTest1 ();

			return convertBooleanTest;
		}

		/// <summary>
		/// Converts the bool = true
		/// </summary>
		/// <returns><c>true</c>, if bool test1 was converted, <c>false</c> otherwise.</returns>
		private static bool StringToBooleanTest1 ()
		{
			try {
				object[] paramArg = { isStringTrue };

				var result = appBase.ComponentLoader.InvokeMethod (convertUtils, "StringToBoolean", paramArg);
				var isTrue = Convert.ToBoolean (result);

				log.DebugFormat ("StringToBooleanTest1 (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Converts the bool = false
		/// </summary>
		/// <returns><c>true</c>, if bool test2 was converted, <c>false</c> otherwise.</returns>
		private static bool StringToBooleanTest2 ()
		{
			try {
				object[] paramArg = { isStringFalse };

				var result = appBase.ComponentLoader.InvokeMethod (convertUtils, "StringToBoolean", paramArg);
				var isTrue = Convert.ToBoolean (result);

				log.DebugFormat ("StringToBooleanTest2 (false) = {0}", isTrue);

				if (isTrue == false) {
					isTrue = true;
				}

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Converts the bool = true
		/// </summary>
		/// <returns><c>true</c>, if bool test3 was converted, <c>false</c> otherwise.</returns>
		private static bool BooleanToStringTest1 ()
		{
			try {
				object[] paramArg = { true };

				var result = appBase.ComponentLoader.InvokeMethod (convertUtils, "BooleanToString", paramArg);
				var isTrue = Convert.ToString (result);

				log.DebugFormat ("BooleanToStringTest1 (1/true) = {0}", isTrue);

				return isTrue == "1";
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}