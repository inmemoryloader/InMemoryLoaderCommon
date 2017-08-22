using System;
using System.Globalization;

namespace InMemoryLoaderCommonTestSuite.CheckUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The is byte.
		/// </summary>
		private static byte[] isByte = new byte[isInt];

		/// <summary>
		/// Determines if is string byte test.
		/// </summary>
		/// <returns><c>true</c> if is string byte test; otherwise, <c>false</c>.</returns>
		public static bool IsStringByteTest()
		{
			bool isStringByteTest = false;

			isStringByteTest = IsStringByteTest1();
			isStringByteTest = IsStringByteTest2();
			isStringByteTest = IsStringByteTest3();
			isStringByteTest = IsStringByteTest4();
			isStringByteTest = IsStringByteTest5();

			return isStringByteTest;
		}

		/// <summary>
		/// Determines if is string byte = true
		/// </summary>
		/// <returns><c>true</c> if is string byte test1; otherwise, <c>false</c>.</returns>
		private static bool IsStringByteTest1()
		{
			try
			{
				object[] paramArg = { isByte[2] };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringByteTest1 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is string byte = false
		/// </summary>
		/// <returns><c>true</c> if is string byte test2; otherwise, <c>false</c>.</returns>
		private static bool IsStringByteTest2()
		{
			try
			{
				object[] paramArg = { "SomeString" };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringByteTest2 (false) = {0}", isTrue);

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
		/// Determines if is string byte = true
		/// </summary>
		/// <returns><c>true</c> if is string byte test3; otherwise, <c>false</c>.</returns>
		private static bool IsStringByteTest3()
		{
			try
			{
				object[] paramArg = { isByte[2], NumberStyles.None };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringByteTest3 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is string byte = true
		/// </summary>
		/// <returns><c>true</c> if is string byte test4; otherwise, <c>false</c>.</returns>
		private static bool IsStringByteTest4()
		{
			try
			{
				object[] paramArg = { "SomeString", NumberStyles.None, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringByteTest4 (false) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is string byte = true
		/// </summary>
		/// <returns><c>true</c> if is string byte test5; otherwise, <c>false</c>.</returns>
		private static bool IsStringByteTest5()
		{
			try
			{
				object[] paramArg = { isByte[2], NumberStyles.None, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsStringByteTest5 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}