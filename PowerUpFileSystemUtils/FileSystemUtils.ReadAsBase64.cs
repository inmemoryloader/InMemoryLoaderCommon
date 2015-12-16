using System;
using log4net;
using PowerUpBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Liest eine Datei ein und gibt deren Daten als
		/// Base64-kodierten String zurück
		/// </summary>
		/// <param name="filePath">Pfad zur Datei</param>
		/// <returns>Gibt einen String zurück, der die nach
		/// Base64 kodierten Daten enthält</returns>
		public string ReadAsBase64(string filePath)
		{
			// Datei einlesen
			FileInfo fi = new FileInfo(filePath);
			byte[] buffer = new byte[fi.Length];
			FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			fs.Read(buffer, 0, buffer.Length);
			fs.Close();

			// Das Byte-Array Base64-codiert zurückgeben
			return Convert.ToBase64String(buffer, 0, buffer.Length);
		}
	}
}

