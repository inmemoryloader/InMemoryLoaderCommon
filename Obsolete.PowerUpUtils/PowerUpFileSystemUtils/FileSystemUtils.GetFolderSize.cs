using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractComponent
	{
		/// <summary>
		/// Ermittelt (rekursiv) die Gesamtgröße aller in einem Ordner und seinen Unterordnern enthaltenen Dateien
		/// </summary>
		/// <param name="folder">Referenz auf ein DirectoryInfo-Objekt, das den Ordner repräsentiert</param>
		/// <returns>Gibt die Gesamtgröße aller Dateien in Byte zurück</returns>
		public long GetFolderSize(DirectoryInfo folder)
		{
			// Variable zur Speicherung der jeweils ermittelten Dateigrößen-Summe 
			// eines (Unter-)Ordners
			long folderSize = 0;

			// Summe der Größen der Dateien im Ordner ermitteln
			FileInfo[] files = folder.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				folderSize += files[i].Length;
			}

			// Unterordner ermitteln und die Methode rekursiv für jeden Unterordner 
			// aufrufen und dabei die Variable folderSize hochzählen
			DirectoryInfo[] subFolders = folder.GetDirectories();
			for (int i = 0; i < subFolders.Length; i++)
			{
				folderSize += GetFolderSize(subFolders[i]);
			}

			// Die ermittelte Ordnergröße zurückgeben
			return folderSize;
		}

		/// <summary>
		/// Ermittelt die Gesamtgröße aller in einem Ordner und seinen Unterordnern enthaltenen Dateien
		/// </summary>
		/// <param name="folderPath">Pfad zum Ordner</param>
		/// <returns>Gibt die Gesamtgröße aller Dateien in Byte zurück</returns>
		public long GetFolderSize(string folderPath)
		{
			// Die rekursive Methode zur Ermittlung der Größe eines Ordners aufrufen
			return GetFolderSize(new DirectoryInfo(folderPath));
		}
	}
}

