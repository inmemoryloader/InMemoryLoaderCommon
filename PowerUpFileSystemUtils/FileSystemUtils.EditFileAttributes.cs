using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractComponent
	{
		/// <summary>
		/// Entfernt Dateiattribute von einer Datei
		/// </summary>
		/// <param name="filename">Der Dateiname</param>
		/// <param name="attributesToRemove">Die zu entfernenden Attribute</param>
		public void RemoveFileAttributes(string filename, FileAttributes attributesToRemove)
		{
			FileInfo fileInfo = new FileInfo(filename);
			fileInfo.Attributes = fileInfo.Attributes & ~attributesToRemove;
		}

        /// <summary>
        /// Setzt Dateiattribute für eine Datei
        /// </summary>
        /// <param name="filename">Der Dateiname</param>
        /// <param name="attributesToSet">Die zu setzenden Attribute</param>
        public void SetFileAttributes(string filename, FileAttributes attributesToSet)
		{
			FileInfo fileInfo = new FileInfo(filename);
			fileInfo.Attributes = fileInfo.Attributes | attributesToSet;
		}
	}
}

