using System;
using log4net;
using PowerUpBase;
using System.Globalization;

namespace PowerUpGetUtils
{
	public partial class GetUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(GetUtils));

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpGetUtils.GetUtils"/> class.
		/// </summary>
		public GetUtils ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}
	}
}

