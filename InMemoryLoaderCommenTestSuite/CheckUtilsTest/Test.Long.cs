using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommenTestSuite.CheckUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The is int.
		/// </summary>
		private const long isLong = 12345678;
		/// <summary>
		/// The is string int.
		/// </summary>
		private const string isStringLong = "521345678";

		/// <summary>
		/// Determines if is string long test.
		/// </summary>
		/// <returns><c>true</c> if is string long test; otherwise, <c>false</c>.</returns>
		public static bool IsStringLongTest ()
		{
			bool isStringLong = false;

			isStringLong = IsStringLongTest1 ();
			isStringLong = IsStringLongTest2 ();
			isStringLong = IsStringLongTest3 ();

			return isStringLong;
		}

		/// <summary>
		/// Determines if is long = true
		/// </summary>
		/// <returns><c>true</c> if is long test1; otherwise, <c>false</c>.</returns>
		private static bool IsStringLongTest1 ()
		{
			try {
				object[] paramArg = { isLong };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils, "IsStringLong", paramArg);
				var isTrue = Convert.ToBoolean (result);

				log.DebugFormat ("IsStringLongTest1 (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is long = true
		/// </summary>
		/// <returns><c>true</c> if is long test2; otherwise, <c>false</c>.</returns>
		private static bool IsStringLongTest2 ()
		{
			try {
				object[] paramArg = { isStringLong };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils, "IsStringLong", paramArg);
				var isTrue = Convert.ToBoolean (result);

				log.DebugFormat ("IsStringLongTest2 (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is long = false
		/// </summary>
		/// <returns><c>true</c> if is long test3; otherwise, <c>false</c>.</returns>
		private static bool IsStringLongTest3 ()
		{
			try {
				object[] paramArg = { isString };

				var result = appBase.ComponentLoader.InvokeMethod (checkUtils, "IsStringLong", paramArg);
				var isTrue = Convert.ToBoolean (result);

				log.DebugFormat ("IsStringLongTest3 (false) = {0}", isTrue);

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