using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace InMemoryLoaderCommonUnitTest
{
	public class HelperAndObjectTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The date time utils helper.
		/// </summary>
		private static DateTimeUtilsHelper dateTimeUtilsHelper;

		/// <summary>
		/// Dates the format info test.
		/// </summary>
		/// <returns>The format info test.</returns>
		public static object DateFormatInfoTest ()
		{
			try {
				if (dateTimeUtilsHelper == null) {
					dateTimeUtilsHelper = new DateTimeUtilsHelper ();
				}

				return dateTimeUtilsHelper.GetDateFormatInfo (CultureInfo.CurrentCulture);
			} catch (Exception ex) {
				throw ex;
			}		
		}

	}
}

