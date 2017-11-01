using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Gibt den Pfad zum Windows-Systemordner zurück
		/// </summary>
		public string GetSystemDirectory
		{
			get
			{
				return Environment.SystemDirectory;
			}
		}

		/// <summary>
		/// Gibt den Pfad zum Programmordner zurück
		/// </summary>
		public string GetProgramDirectory
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			}
		}

		/// <summary>
		/// Gibt den Pfad zum Ordner für Anwendungsdaten für "nicht wandernde" Benutzer zurück
		/// </summary>
		public string GetNonRoamingUserApplicationDataDirectory
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			}
		}

		/// <summary>
		/// Gibt den Pfad zum Ordner für Anwendungsdaten für "wandernde" Benutzer zurück
		/// </summary>
		public string GetRoamingUserApplicationDataDirectory
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			}
		}

		/// <summary>
		/// Gibt den Pfad zum Ordner für Anwendungsdaten für alle Benutzer zurück
		/// </summary>
		public string GetAllUsersApplicationDataDirectory
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			}
		}

		/// <summary>
		/// Gibt den Pfad zum Desktop-Ordner zurück
		/// </summary>
		public string GetDesktopDirectory
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			}
		}

		/// <summary>
		/// Gibt den Pfad zum Favoritenordner zurück
		/// </summary>
		public string GetFavoritesDirectory
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
			}
		}

		/// <summary>
		/// Gibt den Pfad zum Ordner zurück, der Verweise zu den zuletzt geöffneten Dokumenten enthält
		/// </summary>
		public string GetRecentDirectory
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.Recent);
			}
		}

        /// <summary>
        /// GetSystemTempFolder
        /// </summary>
		public string GetSystemTempFolder
		{
			get
			{
				return Path.GetTempPath();
			}
		}
	}
}

