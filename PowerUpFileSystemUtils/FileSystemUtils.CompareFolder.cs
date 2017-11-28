using System;
using log4net;
using InMemoryLoaderBase.HelperEnum;
using System.IO;
using InMemoryLoaderBase;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Vergleicht zwei Ordner
		/// </summary>
		/// <param name="folder1">Referenz auf ein DirectoryInfo-Objekt für den ersten Ordner</param>
		/// <param name="folder2">Referenz auf ein DirectoryInfo-Objekt für den zweiten Ordner</param>
		/// <param name="compareFileContent">Gibt an, ob der Dateiinhalt 
		/// der in Ordner gespeicherten Dateien verglichen werden soll</param>
		/// <returns>Gibt true zurück, wenn beide Ordner identisch sind</returns>
		public bool CompareFolder(DirectoryInfo folder1, DirectoryInfo folder2, bool compareFileContent)
		{
			// Die Anzahl der Dateien im Ordner vergleichen
			FileInfo[] files1 = folder1.GetFiles();
			FileInfo[] files2 = folder2.GetFiles();
			if (files1.Length != files2.Length)
			{
				return false;
			}

			// Die Dateien durchgehen und diese vergleichen
			foreach (FileInfo file1 in files1)
			{
				// Dateiname im zweiten Ordner ermitteln und überprüfen, ob die Datei existiert
				string fileName2 = Path.Combine(folder2.FullName, file1.Name);
				if (File.Exists(fileName2))
				{
					FileCompareMethod compareMethod = compareFileContent ? FileCompareMethod.Content : FileCompareMethod.Date;

					if (CompareFiles(file1.FullName, fileName2, compareMethod) == false)
					{
						return false;
					}
				}
				else
				{
					// Datei existiert nicht, also sind die Ordner nicht identisch
					return false;
				}
			}

			// Die Anzahl der Unterordner vergleichen
			DirectoryInfo[] subFolders1 = folder1.GetDirectories();
			DirectoryInfo[] subFolders2 = folder2.GetDirectories();
			if (subFolders1.Length != subFolders2.Length)
			{
				return false;
			}

			// Die Unterordner des ersten Ordners durchgehen um zu vergleichen, ob der
			// zweite Ordner dieselben Unterordner besitzt, und um diese rekursiv
			// durchzugehen
			foreach (DirectoryInfo subFolder1 in subFolders1)
			{
				// Ordnername des zweiten Ordners ermitteln und überprüfen, ob der
				// Ordner existiert
				string folderPath2 = Path.Combine(folder2.FullName, subFolder1.Name);
				DirectoryInfo subFolder2 = new DirectoryInfo(folderPath2);
				if (subFolder2.Exists == false)
				{
					return false;
				}

				// Rekursiver Aufruf zum Vergleich der beiden Unterordner
				if (CompareFolder(subFolder1, subFolder2,
					compareFileContent) == false)
				{
					return false;
				}
			}

			// Wenn die Methode hier ankommt, enthalten beide (Unter-)Ordner einen
			// identischen Inhalt
			return true;
		}

		/// <summary>
		/// Vergleicht zwei Ordner
		/// </summary>
		/// <param name="folderPath1">Pfad zum ersten Ordner</param>
		/// <param name="folderPath2">Pfad zum zweiten Ordner</param>
		/// <param name="compareFileContent">Gibt an, ob der Dateiinhalt 
		/// der in Ordner gespeicherten Dateien verglichen werden soll</param>
		/// <returns>Gibt true zurück, wenn beide Ordner identisch sind</returns>
		public bool CompareFolders(string folderPath1, string folderPath2, bool compareFileContent)
		{
			// Die übergebenen Ordnernamen angleichen
			if (folderPath1.EndsWith("\\") == false) folderPath1 += "\\";
			if (folderPath2.EndsWith("\\") == false) folderPath2 += "\\";

			// Die rekursive Vergleichsmethode mit zwei neuen DirectoryInfo-
			// Objekten für die beiden Ordner aufrufen
			DirectoryInfo folder1 = new DirectoryInfo(folderPath1);
			DirectoryInfo folder2 = new DirectoryInfo(folderPath2);
			return CompareFolder(folder1, folder2, compareFileContent);
		}
	}
}

