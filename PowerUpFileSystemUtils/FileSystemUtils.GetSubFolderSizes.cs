using System;
using log4net;
using PowerUpBase;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Ermittelt die Größe aller einem Ordner direkt untergeordneten Unterordner
		/// </summary>
		/// <param name="folderPath">Pfad zum Ordner</param>
		/// <param name="progress">Referenz auf einen FolderProgress-Delegate,
		/// über den diese Methode den Fortschritt meldet</param>
		/// <returns>Gibt eine Referenz auf eine Auflistung von
		/// FolderSize-Objekten zurück</returns>
		public ReadOnlyCollection<FolderSize> GetSubFolderSizes(string folderPath, FolderProgressHandler progress)
		{
			List<FolderSize> folderSizes = new List<FolderSize>();
			DirectoryInfo folder = new DirectoryInfo(folderPath);
			if (progress != null)
			{
				progress(folder.Name);
			}
			FileInfo[] files = folder.GetFiles();
			long folderSize = 0;
			for (int i = 0; i < files.Length; i++)
			{
				folderSize += files[i].Length;
			}
			folderSizes.Add(new FolderSize(folderPath, folderSize));
			DirectoryInfo[] subFolders = folder.GetDirectories();
			for (int i = 0; i < subFolders.Length; i++)
			{
				if (progress != null)
				{
					progress(subFolders[i].Name);
				}
				folderSize = GetFolderSize(subFolders[i]);
				folderSizes.Add(new FolderSize(subFolders[i].FullName, folderSize));
			}
			return new ReadOnlyCollection<FolderSize>(folderSizes);
		}

		/// <summary>
		/// Delegate für das <see cref="FolderProgress"/>-Ereignis
		/// </summary>
		public delegate void FolderProgressHandler(string currentFolderPath);
	}
}

