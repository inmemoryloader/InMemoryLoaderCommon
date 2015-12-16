using System;
using log4net;
using InMemoryLoaderBase;

namespace PowerUpCryptUtils
{
	public partial class CryptUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(CryptUtils));

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpCryptUtils.CryptUtils"/> class.
		/// </summary>
		public CryptUtils ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}
	}
}

