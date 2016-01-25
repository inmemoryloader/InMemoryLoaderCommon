using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;

namespace InMemoryLoaderCommenTestSuite.CheckUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The is date.
		/// </summary>
		private static DateTime isDate = DateTime.Now;
		/// <summary>
		/// The is string.
		/// </summary>
		private const string isString = "Some String";

		/// <summary>
		/// Determines if is string date test.
		/// </summary>
		/// <returns><c>true</c> if is string date test; otherwise, <c>false</c>.</returns>
		public static bool IsStringDateTest ()
		{
			bool isStringDateTest = false;

			isStringDateTest = IsStringDateTest1 ();
			isStringDateTest = IsStringDateTest2 ();
			isStringDateTest = IsStringDateTest3 ();

			return isStringDateTest;
		}

		/// <summary>
		/// Determines if is date = true
		/// </summary>
		/// <returns><c>true</c> if is date test1; otherwise, <c>false</c>.</returns>
		private static bool IsStringDateTest1 ()
		{
			try {
				object[] paramArg = { isDate.ToString () };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils, "IsStringDate", paramArg);
				var isTrue = Convert.ToBoolean (result);

				log.DebugFormat ("IsStringDateTest1 (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is date = true
		/// </summary>
		/// <returns><c>true</c> if is date test2; otherwise, <c>false</c>.</returns>
		private static bool IsStringDateTest2 ()
		{
			try {
				object[] paramArg = { isDate.ToString (), CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils, "IsStringDate", paramArg);
				var isTrue = Convert.ToBoolean (result);

				log.DebugFormat ("IsStringDateTest2 (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		// / Determines if is date = false
		/// </summary>
		/// <returns><c>true</c> if is date test2; otherwise, <c>false</c>.</returns>
		private static bool IsStringDateTest3 ()
		{
			try {
				object[] paramArg = { isString, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils, "IsStringDate", paramArg);
				var isTrue = Convert.ToBoolean (result);

				log.DebugFormat ("IsStringDateTest3 (false) = {0}", isTrue);

				if (isTrue == false) {
					isTrue = true;
				}

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}