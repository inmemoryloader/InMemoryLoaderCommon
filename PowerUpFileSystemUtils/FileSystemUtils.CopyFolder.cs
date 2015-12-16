using System;
using log4net;
using PowerUpBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Kopiert einen Ordner
		/// </summary>
		/// <param name="sourceFolderPath">Pfad zum Quellordner</param>
		/// <param name="destFolderPath">Pfad zum Zielordner</param>
		public void CopyFolder(string sourceFolderPath, string destFolderPath)
		{
			// DirectoryInfo-Objekt für den Quellordner erzeugen
			DirectoryInfo sourceFolder = new DirectoryInfo(sourceFolderPath);

			// Überprüfen, ob der Zielordner bereits existiert
			if (Directory.Exists(destFolderPath))
			{
				// Ausnahme erzeugen
				throw new IOException("Der Zielordner '" + destFolderPath + "' existiert bereits");
			}

			// Zielordner anlegen
			Directory.CreateDirectory(destFolderPath);

			// Methode zum Kopieren der Unterordner und Dateien aufrufen
			CopySubFoldersAndFiles(sourceFolder, sourceFolderPath, destFolderPath);
		}

		/// <summary>
		/// Kopiert (rekursiv) alle Unterordner und Dateien eines Ordners in einen anderen Ordner
		/// </summary>
		/// <param name="folder">Referenz auf ein DirectoryInfo-Objekt, das den Ordner repräsentiert</param>
		/// <param name="sourceFolderPath">Pfad zum Quellordner</param>
		/// <param name="destFolderPath">Pfad zum Zielordner</param>
		private void CopySubFoldersAndFiles(DirectoryInfo folder, string sourceFolderPath, string destFolderPath)
		{
			// Alle Unterordner des übergebenen Ordners durchgehen
			DirectoryInfo[] subFolders = folder.GetDirectories();
			for (int i = 0; i < subFolders.Length; i++)
			{
				// Pfad für den Ziel-Unterordner ermitteln, indem der Pfad zum
				// Quellordner durch den Pfad zum Zielordner ersetzt wird
				string destSubFolderName = subFolders[i].FullName.Replace(sourceFolderPath, destFolderPath);

				// Unterordner im Zielordner erzeugen
				Directory.CreateDirectory(destSubFolderName);

				// Funktion rekursiv aufrufen um zunächst die weiteren Unterordner 
				// zu erzeugen
				CopySubFoldersAndFiles(subFolders[i], sourceFolderPath, destFolderPath);
			}

			// Die im Ordner enthaltenen Dateien ermitteln
			FileInfo[] files = folder.GetFiles();

			// Alle Dateien durchgehen
			for (int i = 0; i < files.Length; i++)
			{
				// Ziel-Dateiname ermitteln, indem der Pfad zum Quellordner
				// durch den Pfad zum Zielordner ersetzt wird
				string destFileName = files[i].FullName.Replace(sourceFolderPath, destFolderPath);

				// Datei kopieren
				File.Copy(files[i].FullName, destFileName);
			}
		}
	}
}

