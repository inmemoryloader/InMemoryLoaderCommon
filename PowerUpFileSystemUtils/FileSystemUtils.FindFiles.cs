using System;
using log4net;
using InMemoryLoaderBase;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Sucht alle Dateien, die dem angegebenen Muster entsprechen
		/// </summary>
		/// <param name="startDirectory">Pfad zu dem Verzeichnis, dem gesucht werden soll</param>
		/// <param name="filePattern">Das Such-Muster (z. B. *.txt)</param>
		/// <param name="recursive">Gibt an, ob auch in den Unterordnern gesucht werden soll</param>
		/// <returns>Gibt ein ReadOnlyCollection vom Typ FileInfo zurück, die die 
		/// gefundenen Dateien repräsentiert</returns>
		public ReadOnlyCollection<FileInfo> FindFiles(string startDirectory, string filePattern, bool recursive)
		{
			// Basis-Auflistung erzeugen
			List<FileInfo> fileList = new List<FileInfo>();

			// Die rekursive private Methode aufrufen
			findFiles(new DirectoryInfo(startDirectory), filePattern, recursive, fileList);

			// Ergebnis-Collection zurückgeben
			return new ReadOnlyCollection<FileInfo>(fileList);
		}

		/// <summary>
		/// Sucht alle Dateien, die dem angegebenen Muster entsprechen
		/// </summary>
		/// <param name="directory">Das Verzeichnis, in dem gesucht werden soll</param>
		/// <param name="filePattern">Das Such-Muster (z. B. *.txt)</param>
		/// <param name="recursive">Gibt an, ob auch in den Unterordnern gesucht werden soll</param>
		/// <param name="fileList">Referenz auf eine List-Auflistung, die die 
		/// Pfade zu den gefundenen Dateien aufnimmt</param>
		private void findFiles(DirectoryInfo directory, string filePattern, bool recursive, List<FileInfo> fileList)
		{
			if (filePattern != null && filePattern.Length > 0)
			{
				// Das Dateimuster splitten
				string[] filePatterns = filePattern.Split(';');

				// Alle Dateimuster durchgehen und in dem übergebenen Verzeichnis suchen
				foreach (string partPattern in filePatterns)
				{
					foreach (FileInfo fileInfo in directory.GetFiles(partPattern))
					{
						fileList.Add(fileInfo);
					}
				}
			}
			else
			{
				// Kein Suchmuster angegeben: Alle Dateien durchgehen 
				foreach (FileInfo fileInfo in directory.GetFiles())
				{
					fileList.Add(fileInfo);
				}
			}

			if (recursive)
			{
				// Wenn rekursiv gesucht werden soll:
				// Die Methode für alle Unterordner aufrufen
				foreach (DirectoryInfo subDirectory in directory.GetDirectories())
				{
					findFiles(subDirectory, filePattern, recursive, fileList);
				}
			}
		}
	}
}

