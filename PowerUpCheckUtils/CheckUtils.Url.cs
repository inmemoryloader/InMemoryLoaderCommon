using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;
using System.Net;

namespace PowerUpCheckUtils
{
	public partial class CheckUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Determines whether this instance is URL valid the specified parmURL.
		/// </summary>
		/// <returns><c>true</c> if this instance is URL valid the specified parmURL; otherwise, <c>false</c>.</returns>
		/// <param name="parmURL">Parm UR.</param>
		public bool IsUrlValid(object parmURL)
		{
			HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(parmURL.ToString());
			HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
			if (HttpStatusCode.OK == rspFP.StatusCode)
			{
				rspFP.Close();
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

