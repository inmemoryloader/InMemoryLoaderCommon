using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Configuration;
using System.Configuration.Assemblies;

namespace InMemoryLoaderCommenTestSuite.XmlUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(InMemoryLoaderCommenTestSuite.StringUtilsTest.Test));
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The date time utils.
		/// </summary>
		private static IDynamicClassInfo xmlUtils = 
			appBase.ComponentLoader.ComponentRegistry.Where (utl => utl.Key.Class.Contains ("XmlUtils")).SingleOrDefault ().Value;

		/// <summary>
		/// The xml folder path.
		/// </summary>
		private static string xmlFolderPath = Path.Combine (appBase.commonComponentPath, ConfigurationManager.AppSettings ["XmlUtilsTestPath"].ToString ());
		/// <summary>
		/// The xml file to write.
		/// </summary>
		private static string xmlFileToWrite = "TestXmlFileToWrite.xml";
	}
}