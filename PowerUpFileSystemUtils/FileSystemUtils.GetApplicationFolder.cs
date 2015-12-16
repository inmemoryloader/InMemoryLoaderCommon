using System;
using log4net;
using PowerUpBase;
using System.IO;
using System.Reflection;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Ermittelt den Ordnernamen einer Anwendung
		/// </summary>
		public string GetApplicationFolder
		{
			get
			{
				FileInfo fi = new FileInfo(Assembly.GetCallingAssembly().Location);
				return fi.DirectoryName;
			}
		}
	}
}

