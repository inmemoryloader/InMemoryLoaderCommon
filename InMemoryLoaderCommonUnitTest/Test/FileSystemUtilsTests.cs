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
	public class FileSystemUtilsTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The crypt utils.
		/// </summary>
		private static IDynamicClassSetup fileSystemUtils = appBase.CommonComponentLoader.FileSystemComponent;

		/// <summary>
		/// Compares the files test1.
		/// </summary>
		/// <returns>The files test1.</returns>
		/// <param name="file1">File1.</param>
		/// <param name="file2">File2.</param>
		public static object CompareFilesTest (string file1, string file2)
		{
			try {
				object[] paramObject = { file1, file2 };

				var areEqual = appBase.ComponentLoader.InvokeMethod (fileSystemUtils.Assembly, fileSystemUtils.Class, "CompareFiles", paramObject);

				return areEqual;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Compares the folders test.
		/// </summary>
		/// <returns>The folders test.</returns>
		/// <param name="folder1">Folder1.</param>
		/// <param name="folder2">Folder2.</param>
		public static object CompareFoldersTest (string folder1, string folder2)
		{
			try {
				DirectoryInfo info1 = new DirectoryInfo (folder1);
				DirectoryInfo info2 = new DirectoryInfo (folder2);

				object[] paramObject = { info1, info2, true };

				var areEqual = appBase.ComponentLoader.InvokeMethod (fileSystemUtils.Assembly, fileSystemUtils.Class, "CompareFolder", paramObject);

				return areEqual;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Finds the files test.
		/// </summary>
		/// <returns>The files test.</returns>
		/// <param name="startDirectory">Start directory.</param>
		/// <param name="filePattern">File pattern.</param>
		/// <param name="recursive">If set to <c>true</c> recursive.</param>
		public static object FindFilesTest (string startDirectory, string filePattern, bool recursive)
		{
			try {
				object[] paramObject = { startDirectory, filePattern, recursive };

				var files = (ReadOnlyCollection<FileInfo>)appBase.ComponentLoader.InvokeMethod (fileSystemUtils.Assembly, fileSystemUtils.Class, "FindFiles", paramObject);

				return files;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the drive info test.
		/// </summary>
		/// <returns>The drive info test.</returns>
		public static object GetDriveInfoTest ()
		{
			try {
				DriveType driveType = DriveType.Fixed;
				object[] paramObject = { driveType };

				var files = (List<DriveInfo>)appBase.ComponentLoader.InvokeMethod (fileSystemUtils.Assembly, fileSystemUtils.Class, "GetDriveInfos", paramObject);

				return files;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

