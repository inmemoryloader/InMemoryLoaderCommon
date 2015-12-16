using System;
using log4net;
using PowerUpBase;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Definiert, ob beim Kopieren mit <see cref="CopyFolderFaultTolerant"/>
		/// alle Dateien überschrieben werden sollen.
		/// </summary>
		private static bool overwriteAllFiles;

		/// <summary>
		/// Gibt an, ob beim Kopieren mit <see cref="CopyFolderFaultTolerant"/>
		/// bereits gefragt wurde, ob alle Dateien überschrieben werden sollen.
		/// </summary>
		private static bool alreadyAskedForOverwriteAllFiles;

		/// <summary>
		/// Kopiert (rekursiv) alle Unterordner und Dateien eines Ordners in einen anderen Ordner
		/// </summary>
		/// <param name="sourceFolderPath">Der Pfad zum Quellordner</param>
		/// <param name="destFolderPath">Der Pfad des Zielordners</param>
		/// <returns>Gibt eine <see cref="CopyFaults"/>-Auflistung zurück 
		/// mit Informationen über fehlgeschlagene Kopier-Vorgänge</returns>
		public ReadOnlyCollection<CopyFault> CopyFolderFaultTolerant(string sourceFolderPath, string destFolderPath)
		{
			// Liste von CopyFault-Objekten erzeugen
			List<CopyFault> copyFaults = new List<CopyFault>();

			// Datei-Überschreib-Flags voreinstellen 
			overwriteAllFiles = false;
			alreadyAskedForOverwriteAllFiles = false;

			// Die rekursive Methode zum Kopieren der Unterordner 
			// und Dateien aufrufen
			CopySubFoldersAndFiles(new DirectoryInfo(sourceFolderPath), sourceFolderPath, destFolderPath, copyFaults);

			// Ergebnis zurückgeben
			return new ReadOnlyCollection<CopyFault>(copyFaults);
		}

		/// <summary>
		/// Kopiert (rekursiv) alle Unterordner und Dateien eines Ordners in einen anderen Ordner
		/// </summary>
		/// <param name="folder">Referenz auf ein DirectoryInfo-Objekt, das den Ordner repräsentiert</param>
		/// <param name="mainSourceFolderPath">Pfad zum Haupt-Quellordner</param>
		/// <param name="mainDestFolderPath">Pfad zum Haupt-Zielordner</param>
		/// <param name="copyFaults">Referenz auf eine CopyFaults-Auflistung,
		/// in die diese Methode alle aufgetretenen Kopierfehler schreibt</param>
		private void CopySubFoldersAndFiles(DirectoryInfo folder, string mainSourceFolderPath, string mainDestFolderPath, List<CopyFault> copyFaults)
		{
			// Zielordner anlegen
			try
			{
				// Zielordnername ermitteln
				string destFolderPath = folder.FullName.Replace(mainSourceFolderPath, mainDestFolderPath);

				// Ordner anlegen
				Directory.CreateDirectory(destFolderPath);
			}
			catch (IOException ex)
			{
				// Fehler in der CopyFaults-Auflistung dokumentieren
				copyFaults.Add(new CopyFault(false, mainSourceFolderPath, mainDestFolderPath, ex.Message));
			}

			// Alle Unterordner des übergebenen Ordners durchgehen
			DirectoryInfo[] subFolders = folder.GetDirectories();
			for (int i = 0; i < subFolders.Length; i++)
			{
				// Pfad für den Ziel-Unterordner ermitteln, indem der Pfad zum 
				// Quellordner durch den Pfad zum Zielordner ersetzt wird
				// TODO: Check
				// string destSubFolderName = subFolders[i].FullName.Replace(mainSourceFolderPath, mainDestFolderPath);

				// Funktion rekursiv aufrufen um zunächst die weiteren Unterordner 
				// zu erzeugen
				CopySubFoldersAndFiles(subFolders[i], mainSourceFolderPath, mainDestFolderPath, copyFaults);
			}

			// Die im Ordner enthaltenen Dateien ermitteln
			FileInfo[] files = folder.GetFiles();

			// Alle Dateien durchgehen
			for (int i = 0; i < files.Length; i++)
			{
				// Ziel-Dateiname ermitteln, indem der Pfad zum Quellordner
				// durch den Pfad zum Zielordner ersetzt wird
				string destFileName = files[i].FullName.Replace(mainSourceFolderPath, mainDestFolderPath);

				// Flag setzen, das festlegt, ob die Datei kopiert werden soll
				bool performCopyOperation;
				performCopyOperation = true;

				// Überprüfen, ob die Datei bereits existiert
				if (File.Exists(destFileName))
				{
					// Fragen, ob die Datei überschrieben werden soll, falls der
					// Anwender dies zuvor noch nicht für alle Dateien und Ordner
					// gemeinsam bestätigt hat
					if (overwriteAllFiles == false)
					{
						switch (MessageBox.Show("Die Datei '"
							+ destFileName + "' existiert bereits.\r\n\r\n"
							+ "Soll diese Datei überschrieben werden?",
							global::System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
						{
						case DialogResult.Yes:
							// Nachfragen, ob alle Dateien überschrieben werden
							// sollen, falls dies noch nicht geschehen ist
							if (alreadyAskedForOverwriteAllFiles == false)
							{
								switch (MessageBox.Show("Sollen alle im Zielordner "
									+ "vorhandenen Dateien überschrieben werden?",
									global::System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
								{
								case DialogResult.Yes:
									// Flag setzen, das das Überschreiben steuert
									overwriteAllFiles = true;
									break;

								case DialogResult.Cancel:
									// Anwender hat abgebrochen: Ausnahme erzeugen,
									// da der Ordner nicht komplett kopiert werden
									// konnte
									throw new IOException("Benutzerabbruch");
								}

								// Festlegen, dass nicht mehr nachgefragt werden muss
								alreadyAskedForOverwriteAllFiles = true;
							}
							break;

						case DialogResult.No:
							// Festlegen, dass die aktuelle Datei nicht kopiert
							// werden soll
							performCopyOperation = false;
							break;

						case DialogResult.Cancel:
							// Anwender hat abgebrochen: Ausnahme erzeugen, da der 
							// Ordner nicht komplett kopiert werden konnte
							throw new IOException("Benutzerabbruch");
						}
					}
				}

				// Datei kopieren, wenn die Operation ausgeführt werden soll
				if (performCopyOperation)
				{
					try
					{
						File.Copy(files[i].FullName, destFileName, true);
					}
					catch (Exception ex)
					{
						// Fehler in der CopyFaults-Auflistung dokumentieren
						copyFaults.Add(new CopyFault(true, files[i].FullName, destFileName, ex.Message));
					}
				}
				else
				{
					// Datei sollte nicht überschrieben werden: Fehler in der 
					// CopyFaults-Auflistung dokumentieren
					copyFaults.Add(new CopyFault(true, files[i].FullName, destFileName, "Fehlende Anwender-Erlaubnis zum Überschreiben"));
				}
			}
		}
	}
}

