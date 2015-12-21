using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class ConvertUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(ConvertUtilsTest));

		[Test ()]
		public void ConvertUtilsBoolTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "ConvertUtilsBoolTestCase");

				// Is true
				var isTrue1 = ConvertUtilsBoolests.ConvertBoolTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("ConvertBoolTest1 = true is {0}", isTrue1);

				// Is false
				var isTrue2 = ConvertUtilsBoolests.ConvertBoolTest2();
				Assert.IsFalse(isTrue2);
				log.InfoFormat ("ConvertBoolTest1 = false is {0}", isTrue2);


			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}
	}
}

