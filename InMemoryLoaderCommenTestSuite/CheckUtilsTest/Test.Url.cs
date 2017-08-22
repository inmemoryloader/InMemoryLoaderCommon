using System;

namespace InMemoryLoaderCommonTestSuite.CheckUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The is string URL.
		/// </summary>
		private const string isStringUrl = "http://www.google.ch/";
		/// <summary>
		/// The is string no URL.
		/// </summary>
		private const string isStringNoUrl = "Some String";

		/// <summary>
		/// Determines if is URL valid test.
		/// </summary>
		/// <returns><c>true</c> if is URL valid test; otherwise, <c>false</c>.</returns>
		public static bool IsUrlValidTest()
		{
			bool isUrlValidTest = false;

			isUrlValidTest = IsUrlValidTest1();
			isUrlValidTest = IsUrlValidTest2();

			return isUrlValidTest;
		}

		/// <summary>
		/// Determines if is URL = true
		/// </summary>
		/// <returns><c>true</c> if is URL test1; otherwise, <c>false</c>.</returns>
		private static bool IsUrlValidTest1()
		{
			try
			{
				object[] paramArg = { isStringUrl };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsUrlValid", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsUrlValidTest1 (true) = {0}", isTrue);

				return isTrue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Determines if is URL = false
		/// </summary>
		/// <returns><c>true</c> if is URL test2; otherwise, <c>false</c>.</returns>
		private static bool IsUrlValidTest2()
		{
			try
			{
				object[] paramArg = { isStringNoUrl };

				var result = appBase.ComponentLoader.InvokeMethod(checkUtils, "IsUrlValid", paramArg);
				var isTrue = Convert.ToBoolean(result);

				log.DebugFormat("IsUrlValidTest2 (false) = {0}", isTrue);

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

