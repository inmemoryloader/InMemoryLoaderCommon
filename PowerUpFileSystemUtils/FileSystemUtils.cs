using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(FileSystemUtils));

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpFileSystemUtils.FileSystemUtils"/> class.
		/// </summary>
		public FileSystemUtils ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}

		/// <summary>
		/// Aufzählung für die möglichen Vergleichstypen
		/// </summary>
		public enum FileCompareMethod
		{
			Date,
			Content,
			DateAndContent
		}
	}
}

