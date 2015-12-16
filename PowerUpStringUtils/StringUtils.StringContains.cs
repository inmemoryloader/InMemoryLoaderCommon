using System;
using PowerUpBase;
using log4net;
using System.Text.RegularExpressions;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="strToCheck"></param>
		/// <param name="strContains"></param>
		/// <returns></returns>
		public bool StringContains(string strToCheck, string strContains)
		{
			if (strToCheck == null || strContains == null)
			{
				return false;
			}
			if (strToCheck.Contains(strContains))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

