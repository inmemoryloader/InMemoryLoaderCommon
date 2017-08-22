using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Configuration;
using System.Configuration.Assemblies;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommonTestSuite.FileSystemUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(InMemoryLoaderCommonTestSuite.EmailUtilsTest.Test));
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The date time utils.
		/// </summary>
		private static IDynamicClassInfo fileSystemUtils = 
			appBase.ComponentLoader.ComponentRegistry.Where (utl => utl.Key.Class.Contains ("FileSystemUtils")).SingleOrDefault ().Value;

		/// <summary>
		/// The filepath.
		/// </summary>
		private static string filepath = Path.Combine (appBase.commonComponentPath, ConfigurationManager.AppSettings ["FileSystemUtilsTestPath"].ToString ());

		/// <summary>
		/// The file1.
		/// </summary>
		private static string file1 = Path.Combine (filepath, "CompareFile1.txt");
		/// <summary>
		/// The file2.
		/// </summary>
		private static string file2 = Path.Combine (filepath, "CompareFile2.txt");
		/// <summary>
		/// The file3.
		/// </summary>
		private static string file3 = Path.Combine (filepath, "CompareFile3.txt");

		/// <summary>
		/// The folder1.
		/// </summary>
		private static string folder1 = Path.Combine (filepath, "CompareFolder1");
		/// <summary>
		/// The folder2.
		/// </summary>
		private static string folder2 = Path.Combine (filepath, "CompareFolder2");
		/// <summary>
		/// The folder3.
		/// </summary>
		private static string folder3 = Path.Combine (filepath, "CompareFolder3");

	}
}