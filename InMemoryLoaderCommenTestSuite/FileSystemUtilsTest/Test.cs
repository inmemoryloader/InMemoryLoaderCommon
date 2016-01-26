using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;

namespace InMemoryLoaderCommenTestSuite.FileSystemUtilsTest
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
		private static IDynamicClassInfo fileSystemUtils = 
			appBase.ComponentLoader.ComponentRegistry.Where (utl => utl.Key.Class.Contains ("FileSystemUtils")).SingleOrDefault ().Value;

		/// <summary>
		/// The file1.
		/// </summary>
		private static string file1 = "/home/kaysta/github.com/InMemoryLoaderCommon/InMemoryLoaderCommenTestSuite/FileSystemUtilsTest/CompareFile1.txt";
		/// <summary>
		/// The file2.
		/// </summary>
		private static string file2 = "/home/kaysta/github.com/InMemoryLoaderCommon/InMemoryLoaderCommenTestSuite/FileSystemUtilsTest/CompareFile2.txt";
		/// <summary>
		/// The file3.
		/// </summary>
		private static string file3 = "/home/kaysta/github.com/InMemoryLoaderCommon/InMemoryLoaderCommenTestSuite/FileSystemUtilsTest/CompareFile3.txt";

		/// <summary>
		/// The folder1.
		/// </summary>
		private static string folder1 = "/home/kaysta/github.com/InMemoryLoaderCommon/InMemoryLoaderCommenTestSuite/FileSystemUtilsTest/CompareFolder1/";
		/// <summary>
		/// The folder2.
		/// </summary>
		private static string folder2 = "/home/kaysta/github.com/InMemoryLoaderCommon/InMemoryLoaderCommenTestSuite/FileSystemUtilsTest/CompareFolder2/";
		/// <summary>
		/// The folder3.
		/// </summary>
		private static string folder3 = "/home/kaysta/github.com/InMemoryLoaderCommon/InMemoryLoaderCommenTestSuite/FileSystemUtilsTest/CompareFolder3/";

	}
}