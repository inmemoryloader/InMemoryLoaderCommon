using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommenTestSuite.CheckUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(InMemoryLoaderCommenTestSuite.CheckUtilsTest.Test));
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The check utils.
		/// </summary>
		private static IDynamicClassInfo checkUtils = 
			appBase.ComponentLoader.ComponentRegistry.Where (utl => utl.Key.Class.Contains ("CheckUtils")).SingleOrDefault ().Value;

	}
}

