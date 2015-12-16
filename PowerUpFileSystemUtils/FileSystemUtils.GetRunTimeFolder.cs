using System;
using log4net;
using PowerUpBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Gets the get run time folder.
		/// </summary>
		/// <value>The get run time folder.</value>
		public string GetRunTimeFolder
		{
			get
			{
				return AppDomain.CurrentDomain.BaseDirectory;
			}
		}
	}
}

