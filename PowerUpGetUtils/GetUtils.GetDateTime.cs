using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpGetUtils
{
	public partial class GetUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Gets the get date time.
		/// </summary>
		/// <value>The get date time.</value>
		public DateTime GetDateTime
		{
			get
			{
				return DateTime.Now;
			}
		}
	}
}

