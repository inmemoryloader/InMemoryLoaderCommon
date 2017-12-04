using System;

namespace PowerUpFileSystemUtils
{
	/// <summary>
	/// Verwaltet die Größe eines Ordners
	/// </summary>
	public class FolderSize
	{
		/// <summary>
		/// Der Pfad zum Ordner
		/// </summary>
		public string FolderPath;

		/// <summary>
		/// Die Gesamtgröße aller im Ordner und dessen Unterordnern enthaltenen Dateien
		/// </summary>
		public long Size;

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="folderPath">Der Pfad zum Ordner</param>
		/// <param name="size">Die Gesamtgröße aller im Ordner und dessen Unterordnern enthaltenen Dateien</param>
		internal FolderSize(string folderPath, long size)
		{
			FolderPath = folderPath;
			Size = size;
		}
	}
}

