using System;
using InMemoryLoaderBase;
using log4net;

namespace PowerUpStringUtils
{
    /// <summary>
    /// StringUtils
    /// </summary>
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(StringUtils));

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpStringUtils.StringUtils"/> class.
		/// </summary>
		public StringUtils ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", GetType ().ToString ());
		}


	}
}

