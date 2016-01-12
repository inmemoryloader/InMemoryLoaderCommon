using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class EmailUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(EmailUtilsTest));

		/// <summary>
		/// Emails the utils test case1.
		/// </summary>
		[Test ()]
		public void EmailUtilsTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "EmailUtilsTestCase1");

				var returnVoid = EmailUtilsTests.SendSimpleTest1 ();

				log.InfoFormat ("GetGermanCalendarWeekTest is Year {0} and Week {1}", returnVoid);
			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}
	}
}

