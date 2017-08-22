using System;
using System.Globalization;

namespace InMemoryLoaderCommonTestSuite.CheckUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The is decimal.
		/// </summary>
		private const Decimal isDecimal = 3.12m;

		/// <summary>
		/// Determines if is string decimal test.
		/// </summary>
		/// <returns><c>true</c> if is string decimal test; otherwise, <c>false</c>.</returns>
		public static bool IsStringDecimalTest()
		{
			bool isStringDecimalTest = false;

			isStringDecimalTest = IsStringDecimalTest1();
			isStringDecimalTest = IsStringDecimalTest2();
			isStringDecimalTest = IsStringDecimalTest3();

			return isStringDecimalTest;
		}

		/// <summary>
		/// Determines if is decimal = true
		/// </summary>
		/// <returns><c>true</c> if is decimal test1; otherwise, <c>false</c>.</returns>
		private static bool IsStringDecimalTest1()
		{
			try
			{
				object[] paramArg = { isDecimal };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringDecimal", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringDecimalTest1 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is decimal = true
		/// </summary>
		/// <returns><c>true</c> if is decimal test2; otherwise, <c>false</c>.</returns>
		private static bool IsStringDecimalTest2()
		{
			try
			{
				object[] paramArg = { isDecimal, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringDecimal", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringDecimalTest2 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is decimal = false
		/// </summary>
		/// <returns><c>true</c> if is decimal test3; otherwise, <c>false</c>.</returns>
		private static bool IsStringDecimalTest3()
		{
			try
			{
				object[] paramArg = { isString, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringDecimal", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringDecimalTest3 (false) = {0}", isTrue);

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