using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="toWrite"></param>
		/// <param name="toFile"></param>
		public void WriteStringToFile(string toWrite, string toFile)
		{
			StreamWriter file = new StreamWriter(toFile);
			file.WriteLine(toWrite);
			file.Close();
		}
		/// <summary>
		/// Creates the directory.
		/// </summary>
		/// <param name="paramPath">Parameter path.</param>
		public void CreateDirectory(string paramPath)
		{
			if (!Directory.Exists(paramPath))
			{
				Directory.CreateDirectory(paramPath);
			}
		}
	}
}

