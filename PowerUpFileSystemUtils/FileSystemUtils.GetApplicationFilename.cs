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
		/// Ermittelt den Dateinamen der Anwendung
		/// </summary>
		public string GetApplicationFilename
		{
			get
			{
				FileInfo fi = new FileInfo(Assembly.GetEntryAssembly().Location);
				return fi.Name;
			}
		}
	}
}

