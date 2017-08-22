using System;
using System.Globalization;

namespace InMemoryLoaderCommonTestSuite.CheckUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The is int.
		/// </summary>
		private const int isInt = 123;
		/// <summary>
		/// The is string int.
		/// </summary>
		private const string isStringInt = "521";

		/// <summary>
		/// Determines if is string int test.
		/// </summary>
		/// <returns><c>true</c> if is string int test; otherwise, <c>false</c>.</returns>
		public static bool IsStringIntTest()
		{
			bool isStringIntTest = false;

			isStringIntTest = IsStringIntTest1();
			isStringIntTest = IsStringIntTest2();
			isStringIntTest = IsStringIntTest3();
			isStringIntTest = IsStringIntTest4();

			return isStringIntTest;
		}

		/// <summary>
		/// Determines if is int = true
		/// </summary>
		/// <returns><c>true</c> if is int test1; otherwise, <c>false</c>.</returns>
		private static bool IsStringIntTest1()
		{
			try
			{
				object[] paramArg = { isInt };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringInt", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringIntTest1 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is int = true
		/// </summary>
		/// <returns><c>true</c> if is int test2; otherwise, <c>false</c>.</returns>
		private static bool IsStringIntTest2()
		{
			try
			{
				object[] paramArg = { isStringInt };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringInt", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringIntTest2 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is int = true
		/// </summary>
		/// <returns><c>true</c> if is int test3; otherwise, <c>false</c>.</returns>
		private static bool IsStringIntTest3()
		{
			try
			{
				object[] paramArg = { isStringInt, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringInt", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringIntTest3 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is int = false
		/// </summary>
		/// <returns><c>true</c> if is int test4; otherwise, <c>false</c>.</returns>
		private static bool IsStringIntTest4()
		{
			try
			{
				object[] paramArg = { isString, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringInt", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringIntTest4 (false) = {0}", isTrue);

				if (isTrue == false)
				{
					isTrue = true;
				}

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}