using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommenTestSuite.GetUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// Gets the utils test.
		/// </summary>
		/// <returns><c>true</c>, if utils test was gotten, <c>false</c> otherwise.</returns>
		public static bool GetUtilsTest ()
		{
			bool getUtilsTest = false;

			getUtilsTest = GetUtilsTest1 ();
			getUtilsTest = GetUtilsTest2 ();

			return getUtilsTest;
		}

		/// <summary>
		/// Gets the utils test1.
		/// </summary>
		/// <returns><c>true</c>, if utils test1 was gotten, <c>false</c> otherwise.</returns>
		private static bool GetUtilsTest1 ()
		{
			try {
				bool isTrue = false;

				object[] paramObject = { null };
				var getDateTime = (DateTime)appBase.ComponentLoader.InvokeMethod (getUtils, "GetDateTime", paramObject);

				if (getDateTime.GetType() == typeof(DateTime)) {
					isTrue = true;
				}

				log.DebugFormat ("GetDateTime (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the utils test2.
		/// </summary>
		/// <returns><c>true</c>, if utils test2 was gotten, <c>false</c> otherwise.</returns>
		private static bool GetUtilsTest2 ()
		{
			try {
				bool isTrue = false;

				byte min = 0;
				byte max = 255;

				object[] paramObject = { 12, min, max };
				var getRandom = (byte[])appBase.ComponentLoader.InvokeMethod (getUtils, "GetRandomNumbers", paramObject);

				if (getRandom.Count() > 0) {
					isTrue = true;
				}

				log.DebugFormat ("GetRandomNumbers (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

	}
}