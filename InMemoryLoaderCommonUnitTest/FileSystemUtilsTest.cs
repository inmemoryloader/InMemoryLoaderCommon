using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class FileSystemUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(FileSystemUtilsTest));

		/// <summary>
		/// The file1.
		/// </summary>
		private static string file1 = "/home/kaysta/github.com/InMemoryLoaderCommon/CompareFile1.txt";
		/// <summary>
		/// The file2.
		/// </summary>
		private static string file2 = "/media/kaysta/18B66500B664DFAC/Temp/IsNotYourShit.txt";
		/// <summary>
		/// The file3.
		/// </summary>
		private static string file3 = "/home/kaysta/github.com/InMemoryLoaderCommon/CompareFile2.txt";

		/// <summary>
		/// The folder1.
		/// </summary>
		private static string folder1 = "/home/kaysta/github.com/InMemoryLoaderCommon/CompareFolder1/";
		/// <summary>
		/// The folder2.
		/// </summary>
		private static string folder2 = "/home/kaysta/github.com/InMemoryLoaderCommon/CompareFolder2/";
		/// <summary>
		/// The folder3.
		/// </summary>
		private static string folder3 = "/home/kaysta/github.com/InMemoryLoaderCommon/CompareFolder3/";

		/// <summary>
		/// Files the system utils case4.
		/// </summary>
		[Test ()]
		public void FileSystemUtilsCase4 ()
		{
			try {
				log.InfoFormat ("{0}", "FileSystemUtilsCase3");

				var driveInfo = (List<DriveInfo>)FileSystemUtilsTests.GetDriveInfoTest ();

				foreach (var item in driveInfo) {
					Assert.IsNotNull (item.TotalFreeSpace);
				}

				log.InfoFormat ("GetDriveInfoTest is not null = {0}", driveInfo.Count > 0);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Files the system utils case3.
		/// </summary>
		[Test ()]
		public void FileSystemUtilsCase3 ()
		{
			try {
				log.InfoFormat ("{0}", "FileSystemUtilsCase3");

				var findFiles = (ReadOnlyCollection<FileInfo>)FileSystemUtilsTests.FindFilesTest (folder1, "*.txt", true);

				bool foundFiles = findFiles.Count > 0;

				Assert.IsTrue (foundFiles);

				log.InfoFormat ("FindFilesTest is true = {0}", foundFiles);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Files the system utils case2.
		/// </summary>
		[Test ()]
		public void FileSystemUtilsCase2 ()
		{
			try {
				log.InfoFormat ("{0}", "FileSystemUtilsCase2");

				// isTrue
				var isTrue = FileSystemUtilsTests.CompareFoldersTest (folder1, folder3);
				var true1 = Convert.ToBoolean (isTrue);
				log.InfoFormat ("CompareFoldersTest is true = {0}", true1);
				Assert.IsTrue (true1);

				// isFalse
				var isFalse = FileSystemUtilsTests.CompareFoldersTest (folder1, folder2);
				var true2 = Convert.ToBoolean (isFalse);
				log.InfoFormat ("CompareFoldersTest is false = {0}", true2);
				Assert.IsFalse (true2);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Files the system utils case1.
		/// </summary>
		[Test ()]
		public void FileSystemUtilsCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "FileSystemUtilsCase1");

				// isTrue
				var isTrue = FileSystemUtilsTests.CompareFilesTest (file1, file3);
				var true1 = Convert.ToBoolean (isTrue);
				log.InfoFormat ("CompareFilesTest is true = {0}", true1);
				Assert.IsTrue (true1);

				// isFalse
				var isFalse = FileSystemUtilsTests.CompareFilesTest (file1, file2);
				var true2 = Convert.ToBoolean (isFalse);
				log.InfoFormat ("CompareFilesTest is false = {0}", true2);
				Assert.IsFalse (true2);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}
	}
}

