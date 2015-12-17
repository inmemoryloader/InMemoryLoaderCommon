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
		public void BaseTestCase ()
		{
			try {

				Assert.IsNotNull(appBase.ComponentLoader);
				Assert.IsNotNull(appBase.CommonComponentLoader);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}
	}
}

