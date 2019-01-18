using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractComponent
	{
		/// <summary>
		/// Erzeugt eine Datei aus den Daten eines Base64-kodierten Strings
		/// </summary>
		/// <param name="base64CodedString">Der Base64-kodierte String</param>
		/// <param name="filePath">Pfad zur Zieldatei</param>
		public void CreateFileFromBase64(string base64CodedString, string filePath)
		{
			// String in Byte-Array konvertieren
			byte[] buffer = Convert.FromBase64String(base64CodedString);
			// Datei über einen FileStream schreiben
			FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			fs.Write(buffer, 0, buffer.Length);
			fs.Close();
		}
	}
}

