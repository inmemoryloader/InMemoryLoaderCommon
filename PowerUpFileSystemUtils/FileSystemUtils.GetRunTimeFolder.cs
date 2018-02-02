using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractComponent
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

