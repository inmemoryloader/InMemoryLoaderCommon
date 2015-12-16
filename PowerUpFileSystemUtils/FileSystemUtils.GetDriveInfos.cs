using System;
using log4net;
using PowerUpBase;
using System.Collections.Generic;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Liefert eine Liste von DriveInfo-Instanzen für alle Laufwerke,
		/// die einen bestimmten Typ aufweisen
		/// </summary>
		/// <param name="driveType">Der La
		/// ufwerktyp</param>
		public List<DriveInfo> GetDriveInfos(DriveType driveType)
		{
			// Ergebnis-Liste instanzieren
			List<DriveInfo> driveInfos = new List<DriveInfo>();

			// Alle Laufwerke des Systems durchgehen und den Laufwerk-Typ ermitteln
			foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
			{
				if (driveInfo.DriveType == driveType)
				{
					driveInfos.Add(driveInfo);
				}
			}

			// Die Liste zurückgeben
			return driveInfos;
		}
	}
}

