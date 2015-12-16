using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpGetUtils
{
	public partial class GetUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Returns a global unique identifier.
		/// </summary>
		public string GetGuid(string param)
		{
			System.Guid guid = System.Guid.NewGuid();
			return guid.ToString();
		}
	}
}

