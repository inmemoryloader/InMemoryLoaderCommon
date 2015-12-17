using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class CheckUtilsTest
	{
		private static readonly ILog log = LogManager.GetLogger (typeof(CheckUtilsTest));

		[Test ()]
		public void CheckUtilsByteTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsByteTestCase");

				// Is true
				var isTrue1 = CheckUtilsByteTests.IsByteTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("IsByteTest1 = true is {0}", isTrue1);

				// Is false
				var isTrue2 = CheckUtilsByteTests.IsByteTest2();
				Assert.IsFalse(isTrue2);
				log.InfoFormat ("IsByteTest2 = false is {0}", isTrue2);

				// Is true
				var isTrue3 = CheckUtilsByteTests.IsByteTest3();
				Assert.IsTrue(isTrue3);
				log.InfoFormat ("IsByteTest3 = true is {0}", isTrue3);

				// Is false
				var isTrue4 = CheckUtilsByteTests.IsByteTest4();
				Assert.IsFalse(isTrue4);
				log.InfoFormat ("IsByteTest4 = false is {0}", isTrue4);

				// Is true
				var isTrue5 = CheckUtilsByteTests.IsByteTest5();
				Assert.IsTrue(isTrue5);
				log.InfoFormat ("IsByteTest5 = true is {0}", isTrue5);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

	}
}

