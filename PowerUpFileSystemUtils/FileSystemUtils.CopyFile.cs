using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;
using System.Windows.Forms;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Kopiert eine Datei
		/// </summary>
		/// <param name="sourceFilePath">Pfad zur Quelldatei</param>
		/// <param name="destFilePath">Pfad zur Zieldatei</param>
		/// <returns>Gibt true zurück, wenn die Datei kopiert werden konnte</returns>
		public bool CopyFile(string sourceFilePath, string destFilePath)
		{
			// Abfragen, ob die Datei existiert 
			if (File.Exists(destFilePath))
			{
				// Den Anwender fragen, ob die Datei überschrieben werden soll 
				if (MessageBox.Show("Die Datei '" + destFilePath + "' existiert bereits.\r\n\r\nSoll diese Datei überschrieben werden?",
					global::System.Windows.Forms.Application.ProductName,
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Exclamation) == DialogResult.No)
					return false;
			}

			try
			{
				// Datei kopieren 
				File.Copy(sourceFilePath, destFilePath, true);

				return true;
			}
			catch (Exception ex)
			{
				// Fehlermeldung ausgeben
				MessageBox.Show("Die Datei '" + sourceFilePath + "' kann nicht " + "kopiert werden: " + ex.Message,
					global::System.Windows.Forms.Application.ProductName,
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}
	}
}

