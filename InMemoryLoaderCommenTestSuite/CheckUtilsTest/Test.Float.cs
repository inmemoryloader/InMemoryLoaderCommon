using System;
using System.Globalization;

namespace InMemoryLoaderCommenTestSuite.CheckUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The is float.
		/// </summary>
		private const float isFloat = 1.32f;
		/// <summary>
		/// The is string float.
		/// </summary>
		private const string isStringFloat = "5.687";

		/// <summary>
		/// Determines if is string float test.
		/// </summary>
		/// <returns><c>true</c> if is string float test; otherwise, <c>false</c>.</returns>
		public static bool IsStringFloatTest()
		{
			bool isStringFloat = false;

			isStringFloat = IsStringFloatTest1();
			isStringFloat = IsStringFloatTest2();
			isStringFloat = IsStringFloatTest3();

			return isStringFloat;
		}

		/// <summary>
		/// Determines if is float = true
		/// </summary>
		/// <returns><c>true</c> if is float test1; otherwise, <c>false</c>.</returns>
		private static bool IsStringFloatTest1()
		{
			try
			{
				object[] paramArg = { isFloat };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringFloat", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringFloatTest1 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is float = false
		/// </summary>
		/// <returns><c>true</c> if is float test2; otherwise, <c>false</c>.</returns>
		private static bool IsStringFloatTest2()
		{
			try
			{
				object[] paramArg = { isString };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringFloat", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringFloatTest2 (false) = {0}", isTrue);

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

		/// <summary>
		/// Determines if is float = true
		/// </summary>
		/// <returns><c>true</c> if is float test3; otherwise, <c>false</c>.</returns>
		private static bool IsStringFloatTest3()
		{
			try
			{
				object[] paramArg = { isStringFloat, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringFloat", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringFloatTest3 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}