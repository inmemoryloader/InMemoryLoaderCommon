using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommenTestSuite.DateTimeUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// Gets the age test.
		/// </summary>
		/// <returns><c>true</c>, if age test was gotten, <c>false</c> otherwise.</returns>
		public static bool GetAgeTest ()
		{
			bool getAgeTest = false;

			getAgeTest = GetAgeTest1 ();

			return getAgeTest;
		}

		/// <summary>
		/// Gets the age test1.
		/// </summary>
		/// <returns><c>true</c>, if age test1 was gotten, <c>false</c> otherwise.</returns>
		private static bool GetAgeTest1 ()
		{
			try {
				bool isTrue = false;

				object[] paramDate = { firstDate, lastDate };
				var getAge = appBase.ComponentLoader.InvokeMethod (dateTimeUtils, "GetAge", paramDate);

				var age = Convert.ToInt32(getAge);

				if (age == 40) {
					isTrue = true;
				}

				log.DebugFormat ("GetAge (40) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}