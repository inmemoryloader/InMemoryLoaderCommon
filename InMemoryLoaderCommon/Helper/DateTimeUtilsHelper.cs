using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using log4net;
using PowerUpDateTimeUtils;

namespace InMemoryLoaderCommon
{
	public class DateTimeUtilsHelper
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static ILog log = LogManager.GetLogger (typeof(DateTimeUtilsHelper));

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryLoaderCommon.DateTimeUtilsHelper"/> class.
		/// </summary>
		public DateTimeUtilsHelper ()
		{
		}

		/// <summary>
		/// The date format info.
		/// </summary>
		private static DateFormatInfo dateFormatInfo;

		/// <summary>
		/// Gets the current date format info.
		/// </summary>
		/// <returns>The current date format info.</returns>
		public object GetCurrentDateFormatInfo ()
		{
			dateFormatInfo = new DateFormatInfo ();
			return dateFormatInfo.GetCurrentDateFormatInfo () as object;
		}

		/// <summary>
		/// Gets the date format info.
		/// </summary>
		/// <returns>The date format info.</returns>
		/// <param name="cultureInfo">Culture info.</param>
		public object GetDateFormatInfo (CultureInfo cultureInfo)
		{
			dateFormatInfo = new DateFormatInfo ();
			return dateFormatInfo.GetDateFormatInfo (cultureInfo) as object;
		}

	}
}

