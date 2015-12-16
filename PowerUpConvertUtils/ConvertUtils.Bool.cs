using System;
using log4net;
using PowerUpBase;
using System.Globalization;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Strings to boolean.
		/// </summary>
		/// <returns><c>true</c>, if to boolean was strung, <c>false</c> otherwise.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool StringToBoolean(string paramValue)
		{
			if (paramValue == "1") return true;            
			else if (paramValue == "0") return false;            
			else return false;            
		}
		/// <summary>
		/// Chars to boolean.
		/// </summary>
		/// <returns><c>true</c>, if to boolean was chared, <c>false</c> otherwise.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool CharToBoolean(char paramValue)
		{
			if (paramValue == '1') return true;
			else if (paramValue == '0') return false;
			else return false;
		}
		/// <summary>
		/// Booleans to string.
		/// </summary>
		/// <returns>The to string.</returns>
		/// <param name="paramValue">If set to <c>true</c> parameter value.</param>
		public string BooleanToString(bool paramValue)
		{
			if (paramValue == true) return "1";
			else if (paramValue == false) return "0";
			else return "0";            
		}
		/// <summary>
		/// Booleans to char.
		/// </summary>
		/// <returns>The to char.</returns>
		/// <param name="paramValue">If set to <c>true</c> parameter value.</param>
		public char BooleanToChar(bool paramValue)
		{
			if (paramValue == true) return '1';
			else if (paramValue == false) return '0';
			else return '0';
		}
	}
}

