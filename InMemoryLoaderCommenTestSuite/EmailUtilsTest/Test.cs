using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;

namespace InMemoryLoaderCommenTestSuite.EmailUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(InMemoryLoaderCommenTestSuite.EmailUtilsTest.Test));
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The date time utils.
		/// </summary>
		private static IDynamicClassInfo emailUtils = 
			appBase.ComponentLoader.ComponentRegistry.Where (utl => utl.Key.Class.Contains ("EmailUtils")).SingleOrDefault ().Value;
	}
}