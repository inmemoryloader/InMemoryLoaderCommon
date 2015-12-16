using System;
using log4net;
using PowerUpBase;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(DateTimeUtils));

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpDateTimeUtils.DateTimeUtils"/> class.
		/// </summary>
		public DateTimeUtils ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}

	}
}

