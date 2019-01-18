using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;
using System.Reflection;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractComponent
	{
		/// <summary>
		/// Ermittelt den Ordnernamen einer Klassenbibliothek
		/// </summary>
		/// <returns></returns>
		public string GetLibraryFolder
		{
			get
			{
				FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);
				return fi.DirectoryName;
			}
		}
	}
}

