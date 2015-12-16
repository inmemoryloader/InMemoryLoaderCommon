using System;
using log4net;
using PowerUpBase;
using System.Globalization;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Strings to date time.
		/// </summary>
		/// <returns>The to date time.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public DateTime StringToDateTime(string paramValue)
		{
			try
			{
				DateTime dt;
				dt = this.NormalizeDate(paramValue);
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

