using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class StringUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(StringUtilsTest));

		/// <summary>
		/// Emails the utils test case1.
		/// </summary>
		[Test ()]
		public void StringUtilsTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "StringUtilsTestCase1");

				var getString = (string)StringUtilsTests.StringUtilsTest1 ();

				Assert.IsNotNullOrEmpty(getString);

				log.InfoFormat ("StringUtilsTest1 was {0}", getString);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		[Test ()]
		public void StringUtilsTestCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "StringUtilsTestCase2");

				var getString = (long)StringUtilsTests.StringUtilsTest2 ();
				var expected = 4;

				Assert.AreEqual(expected, getString);

				log.InfoFormat ("StringUtilsTest2 was {0}", getString);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

	}
}

