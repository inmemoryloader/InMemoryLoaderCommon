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
		public DateTime GetDateTime (DateTimeKind dateTimeKind)
		{
			DateTime returnDateTime;

			switch (dateTimeKind) {

			case DateTimeKind.Local:
				returnDateTime = DateTime.SpecifyKind (DateTime.Now, DateTimeKind.Local);
				break;

			case DateTimeKind.Unspecified:
				returnDateTime = DateTime.SpecifyKind (DateTime.Now, DateTimeKind.Unspecified);
				break;

			case DateTimeKind.Utc:
				returnDateTime = DateTime.SpecifyKind (DateTime.Now, DateTimeKind.Utc);
				break;

			default:
				returnDateTime = DateTime.Now;
				break;
			}

			return returnDateTime;
		}
	}
}