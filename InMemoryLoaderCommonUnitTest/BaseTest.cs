using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class BaseTest
	{
		private static readonly ILog log = LogManager.GetLogger (typeof(BaseTest));
		private static AppBase appBase = AppBase.Instance;

		[Test ()]
		public void InitComponentsTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "Start InitComponentsTestCase");

				var path = AppBase.commonComponentPath;
				var result = appBase.CommonComponentLoader.InitCommonComponents(path);
				Assert.IsTrue(result);

				log.InfoFormat ("InitCommonComponents is {0}", result);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

		[Test ()]
		public void BaseTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "Start BaseTestCase");

				var loader = appBase.ComponentLoader;
				Assert.IsNotNull(loader);
				log.InfoFormat ("ComponentLoader is {0}", loader);

				var common = appBase.CommonComponentLoader;
				Assert.IsNotNull(common);
				log.InfoFormat ("CommonComponentLoader is {0}", common);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}
	}
}

