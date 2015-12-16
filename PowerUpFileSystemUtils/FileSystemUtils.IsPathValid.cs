using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Überprüft, ob eine Pfadangabe gültig ist
		/// </summary>
		/// <param name="path">Der Pfad</param>
		public bool IsPathValid(string path)
		{
			try
			{
				// GetFullPath aufrufen um eine Exception 
				// bei einem ungültigen Pfad zu provozieren
				Path.GetFullPath(path);
				return true;
			}
			catch (NotSupportedException)
			{
				// Wird bei ungültigen Pfad-Formaten geworfen,
				// z. B. wenn ein Ordner- oder ein Dateiname
				// Doppelpunkte enthält 
				return false;
			}
			catch (ArgumentException)
			{
				// Wird bei ungültigen Zeichen im Pfad geworfen
				return false;
			}
		}
	}
}

