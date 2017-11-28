using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;
using InMemoryLoaderBase.HelperEnum;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Vergleich zwei Dateien
		/// </summary>
		/// <param name="filePath1">Pfad zur ersten Datei</param>
		/// <param name="filePath2">Pfad zur zweiten Datei</param>
		/// <param name="compareMethod">Angabe der Vergleichsmethode</param>
		/// <returns>Gibt true zurück, wenn beide Dateien entsprechend der 
		/// angegebenen Vergleichsmethode gleich sind</returns>
		public bool CompareFiles(string filePath1, string filePath2, FileCompareMethod compareMethod)
		{
			bool result = false;

			// Wenn beide Dateinamen identisch sind, true zurückgeben
			if (filePath1 == filePath2)
			{
				result = true;
			}

			// Über FileInfo-Objekte das Datum der letzten Änderung vergleichen, sofern dies gewünscht ist. 
			// Das Erstelldatum wird übrigens nicht verglichen, weil dieses beim Kopieren von Dateien 
			// auf das aktuelle Datum gesetzt wird
			if (compareMethod == FileCompareMethod.DateAndContent || compareMethod == FileCompareMethod.Date)
			{
				FileInfo fi1 = new FileInfo(filePath1);
				FileInfo fi2 = new FileInfo(filePath2);
				if (fi1.LastWriteTime != fi2.LastWriteTime)
				{
					result = false;
				}
			}

			// Den Inhalt vergleichen, sofern dies gewünscht ist
			if (compareMethod == FileCompareMethod.DateAndContent || compareMethod == FileCompareMethod.Content)
			{
				FileStream fs1 = new FileStream(filePath1, FileMode.Open);
				FileStream fs2 = new FileStream(filePath2, FileMode.Open);

				if (fs1.Length != fs2.Length)
				{
					result = false;
				}

				int fileByte1, fileByte2;

				do
				{
					fileByte1 = fs1.ReadByte();
					fileByte2 = fs2.ReadByte();
				} while (fileByte1 == fileByte2 && fileByte1 != -1);

				fs1.Close();
				fs2.Close();

				result = (fileByte1 == fileByte2);
			}
			return result;
		}
		/// <summary>
		/// Compares the files.
		/// </summary>
		/// <returns><c>true</c>, if files was compared, <c>false</c> otherwise.</returns>
		/// <param name="filePath1">File path1.</param>
		/// <param name="filePath2">File path2.</param>
		public bool CompareFiles(string filePath1, string filePath2)
		{
			return CompareFiles(filePath1, filePath2, FileCompareMethod.DateAndContent);
		}
	}
}

