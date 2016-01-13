using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class GetUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(EmailUtilsTest));

		/// <summary>
		/// Emails the utils test case1.
		/// </summary>
		[Test ()]
		public void GetUtilsTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "GetUtilsTestCase1");

				var getDateTime = (DateTime)GetUtilsTests.GetUtilsTest1 ();

				log.InfoFormat ("GetUtilsTest1 was {0}", getDateTime.ToString ());
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Gets the utils test case2.
		/// </summary>
		[Test ()]
		public void GetUtilsTestCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "GetUtilsTestCase2");

				var getRandom = (byte[])GetUtilsTests.GetUtilsTest2 ();

				foreach (var item in getRandom) {
					Assert.IsNotNull(item);
				}

				log.InfoFormat ("GetUtilsTest1 was {0}", getRandom.Length > 0);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}
	}
}

