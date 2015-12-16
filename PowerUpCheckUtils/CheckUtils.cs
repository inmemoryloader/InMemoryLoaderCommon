using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpCheckUtils
{
	/// <summary>
	/// Check utils.
	/// </summary>
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(CheckUtils));

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpCheckUtils.CheckUtils"/> class.
		/// </summary>
		public CheckUtils ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}
	}
}

