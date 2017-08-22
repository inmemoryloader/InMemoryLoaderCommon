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
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommonTestSuite.FileSystemUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// Files the system utils compare test.
		/// </summary>
		/// <returns><c>true</c>, if system utils compare test was filed, <c>false</c> otherwise.</returns>
		public static bool FileSystemUtilsCompareTest ()
		{
			bool fileSystemUtilsCompareTest = false;

			fileSystemUtilsCompareTest = CompareFilesTest1 ();
			fileSystemUtilsCompareTest = CompareFilesTest2 ();
			fileSystemUtilsCompareTest = CompareFoldersTest1 ();
			fileSystemUtilsCompareTest = CompareFoldersTest2 ();
			fileSystemUtilsCompareTest = FindFilesTest ();
			fileSystemUtilsCompareTest = GetDriveInfoTest ();

			return fileSystemUtilsCompareTest;
		}

		/// <summary>
		/// Compares the files test1.
		/// </summary>
		/// <returns><c>true</c>, if files test1 was compared, <c>false</c> otherwise.</returns>
		private static bool CompareFilesTest1 ()
		{
			try {
				bool isTrue = false;

				object[] paramObject = { file1, file2 };
				var areEqual = (bool)appBase.ComponentLoader.InvokeMethod (fileSystemUtils, "CompareFiles", paramObject);

				if (!areEqual) {
					isTrue = true;
				}

				log.DebugFormat ("CompareFiles (false) = {0}", areEqual);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Compares the files test2.
		/// </summary>
		/// <returns><c>true</c>, if files test2 was compared, <c>false</c> otherwise.</returns>
		private static bool CompareFilesTest2 ()
		{
			try {
				bool isTrue = false;

				object[] paramObject = { file1, file3 };
				var areEqual = (bool)appBase.ComponentLoader.InvokeMethod (fileSystemUtils, "CompareFiles", paramObject);

				if (areEqual) {
					isTrue = true;
				}

				log.DebugFormat ("CompareFiles (true) = {0}", areEqual);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Compares the folders test1.
		/// </summary>
		/// <returns><c>true</c>, if folders test1 was compared, <c>false</c> otherwise.</returns>
		private static bool CompareFoldersTest1 ()
		{
			try {
				bool isTrue = false;

				DirectoryInfo info1 = new DirectoryInfo (folder1);
				DirectoryInfo info2 = new DirectoryInfo (folder2);

				object[] paramObject = { info1, info2, true };
				var areEqual = (bool)appBase.ComponentLoader.InvokeMethod (fileSystemUtils, "CompareFolder", paramObject);

				if (!areEqual) {
					isTrue = true;
				}

				log.DebugFormat ("CompareFolder (false) = {0}", areEqual);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Compares the folders test2.
		/// </summary>
		/// <returns><c>true</c>, if folders test2 was compared, <c>false</c> otherwise.</returns>
		private static bool CompareFoldersTest2 ()
		{
			try {
				bool isTrue = false;

				DirectoryInfo info1 = new DirectoryInfo (folder1);
				DirectoryInfo info2 = new DirectoryInfo (folder3);

				object[] paramObject = { info1, info2, true };
				var areEqual = (bool)appBase.ComponentLoader.InvokeMethod (fileSystemUtils, "CompareFolder", paramObject);

				if (areEqual) {
					isTrue = true;
				}

				log.DebugFormat ("CompareFolder (true) = {0}", areEqual);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Finds the files test.
		/// </summary>
		/// <returns><c>true</c>, if files test was found, <c>false</c> otherwise.</returns>
		private static bool FindFilesTest ()
		{
			try {
				bool isTrue = false;

				object[] paramObject = { folder1, "*.txt", true };
				var fileInfo = (ReadOnlyCollection<FileInfo>)appBase.ComponentLoader.InvokeMethod (fileSystemUtils, "FindFiles", paramObject);

				isTrue = fileInfo.Count > 0;

				log.DebugFormat ("FindFiles File Count {0}", fileInfo.Count);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the drive info test.
		/// </summary>
		/// <returns><c>true</c>, if drive info test was gotten, <c>false</c> otherwise.</returns>
		private static bool GetDriveInfoTest ()
		{
			try {
				bool isTrue = false;

				DriveType driveType = DriveType.Fixed;
				object[] paramObject = { driveType };
				var driveInfo = (List<DriveInfo>)appBase.ComponentLoader.InvokeMethod (fileSystemUtils, "GetDriveInfos", paramObject);

				foreach (var item in driveInfo) {
					log.DebugFormat ("Free Space {0}", item.AvailableFreeSpace);
				}

				if (driveInfo.Count > 0) {
					isTrue = true;
				}

				log.DebugFormat ("GetDriveInfos Drive Count {0}", driveInfo.Count);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}