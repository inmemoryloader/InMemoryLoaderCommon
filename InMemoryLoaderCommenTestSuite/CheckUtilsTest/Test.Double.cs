using System;

namespace InMemoryLoaderCommonTestSuite.CheckUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The is decimal.
		/// </summary>
		private const Double isDouble = 3.12;

		/// <summary>
		/// Determines if is string double test.
		/// </summary>
		/// <returns><c>true</c> if is string double test; otherwise, <c>false</c>.</returns>
		public static bool IsStringDoubleTest()
		{
			bool isStringDouble = false;

			isStringDouble = IsStringDoubleTest1();
			isStringDouble = IsStringDoubleTest2();

			return isStringDouble;
		}

		/// <summary>
		/// Determines if is double = true
		/// </summary>
		/// <returns><c>true</c> if is double test1; otherwise, <c>false</c>.</returns>
		private static bool IsStringDoubleTest1()
		{
			try
			{
				object[] paramArg = { isDouble };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringDouble", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringDoubleTest1 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is double = false
		/// </summary>
		/// <returns><c>true</c> if is double test2; otherwise, <c>false</c>.</returns>
		private static bool IsStringDoubleTest2()
		{
			try
			{
				object[] paramArg = { isString };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringDouble", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringDoubleTest2 (false) = {0}", isTrue);

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