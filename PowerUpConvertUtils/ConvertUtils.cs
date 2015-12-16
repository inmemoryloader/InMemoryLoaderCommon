using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(ConvertUtils));

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpConvertUtils.ConvertUtils"/> class.
		/// </summary>
		public ConvertUtils ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}
	}
}

