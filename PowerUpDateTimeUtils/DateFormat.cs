using System;

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Gibt ein Datumsformat an
	/// </summary>
	public enum DateFormat
	{
		/// <summary>
		/// Deutsches Format (wird in den meisten Ländern verwendet)
		/// </summary>
		German,

		/// <summary>
		/// Etwa: dd/MM/yyyy hh:mm:ss tt
		/// </summary>
		English1,

		/// <summary>
		/// Etwa: MM/dd/yyyy h:mm:ss tt
		/// </summary>
		English2,

		/// <summary>
		/// Etwa: dd-MM-yyyy H:mm:ss
		/// </summary>
		Indian1,

		/// <summary>
		/// Etwa: dd-MM-yyyy HH.mm.ss
		/// </summary>
		Indian2,

		/// <summary>
		/// Etwa: yyyy-MM-dd HH:mm:ss
		/// </summary>
		Chinese1,

		/// <summary>
		/// Etwa: yyyy/MM/dd hh:mm:ss tt
		/// </summary>
		Chinese2,

		/// <summary>
		/// Etwa yyyy.MM.dd HH:mm:ss
		/// </summary>
		Hungary,

		/// <summary>
		/// Yakut in Russland. MM.dd.yyyy HH:mm:ss
		/// </summary>
		Yakut,

		/// <summary>
		/// Nicht unterstütztes Format
		/// </summary>
		UnSupportedFormat
	}
}

