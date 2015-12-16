using System;

namespace PowerUpFileSystemUtils
{
	/// <summary>
	/// Daten-Container
	/// </summary>
	public class CopyFault
	{
		/// <summary>
		/// Gibt an, ob es sich um eine Datei handelt
		/// </summary>
		public bool IsFile;

		/// <summary>
		/// Der Quellpfad
		/// </summary>
		public string Source;

		/// <summary>
		/// Der Zielpfad
		/// </summary>
		public string Destination;

		/// <summary>
		/// Der aufgetretene Fehler
		/// </summary>
		public string Error;

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="isFile">Gibt an, ob es sich um eine Datei handelt</param>
		/// <param name="source">Der Quellpfad</param>
		/// <param name="destination">Der Zielpfad</param>
		/// <param name="error">Der aufgetretene Fehler</param>
		internal CopyFault(bool isFile, string source, string destination, string error)
		{
			this.IsFile = isFile;
			this.Source = source;
			this.Destination = destination;
			this.Error = error;
		}
	}
}

