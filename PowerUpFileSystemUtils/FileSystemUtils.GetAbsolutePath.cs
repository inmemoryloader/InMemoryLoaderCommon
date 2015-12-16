using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Ermittelt für einen gegebenen relativen einen absoluten Pfad
		/// </summary>
		/// <param name="relativePath">Der relative Pfad</param>
		/// <param name="referencePath">Der Pfad, auf den sich der relative Pfad bezieht</param>
		/// <returns>Gibt den ermittelten absoluten Pfad zurück</returns>
		public string GetAbsolutePath(string relativePath, string referencePath)
		{
			if (referencePath.EndsWith("\\") == false)
			{
				referencePath += "\\";
			}
			return Path.GetFullPath(referencePath + relativePath);
		}
	}
}

