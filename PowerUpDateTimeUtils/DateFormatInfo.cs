using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using InMemoryLoaderBase.HelperEnum;

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Liefert Informationen zu dem Datumsformat für eine Kultur
	/// </summary>
	/// <remarks>
	/// <para>
	/// Über <see cref="GetCurrentDateFormatInfo"/> und <see cref="GetDateFormatInfo"/> können Sie
	/// dein DateFormatInfo-Objekt für die aktuelle oder eine spezielle Kultur erzeugen lassen.
	/// </para>
	/// </remarks>
	public class DateFormatInfo
	{
		#region Öffentliche Felder

		/// <summary>
		/// Das Basis-Format
		/// </summary>
		public readonly DateFormat DateFormat;

		/// <summary>
		/// Der Typ der AM/PM-Angabe
		/// </summary>
		public readonly DateTimeAmPmType AmPmType;

		/// <summary>
		/// Der String, der für eine Zeitangabe bis 12:59 
		/// verwendet wird wenn die Zeit mit AM/PM angegeben wird
		/// </summary>
		public readonly string AMString;

		/// <summary>
		/// Der String, der für eine Zeitangabe ab 13:00 
		/// verwendet wird wenn die Zeit mit AM/PM angegeben wird
		/// </summary>
		public readonly string PMString;

		/// <summary>
		/// Gibt das Zeichen an, mit dem die AM/PM-Angabe von der Zeit getrennt ist
		/// </summary>
		public readonly string AmPmSeparator;

		/// <summary>
		/// Gibt an, ob eine Zeitangabe im 24-Stunden-Format möglich ist
		/// </summary>
		public readonly bool TimeInputIn24HourFormatEnabled;

		/// <summary>
		/// Die verwendete Kultur
		/// </summary>
		public readonly CultureInfo CultureInfo;

		/// <summary>
		/// Das Regex-Muster, das auf die Zeichen passt, mit denen ein
		/// Datum (ohne Zeit) abgeschlossen sein kann.
		/// Normalerweise ist dieses Muster nicht gesetzt, bei Bulgarisch (bg-BG) ist das aber z. B.
		/// das Pattern @"(?: | г| г\.)"
		/// </summary>
		public readonly string DateSuffixPattern;

		/// <summary>
		/// Das Regex-Muster, das auf die Trennzeichen zwischen Zeit und Datum passt (normalerweise ist das einfach ein Leerzeichen)
		/// </summary>
		public readonly string DateTimeSeparatorPattern;

		#endregion

		#region Konstruktor

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="dateFormat"><Das Basis-Format</param>
		/// <param name="aMString">Der String, der für eine Zeitangabe bis 12:59 verwendet wird wenn die Zeit mit AM/PM angegeben wird</param>
		/// <param name="pMString"> Der String, der für eine Zeitangabe ab 13:00 verwendet wird wenn die Zeit mit AM/PM angegeben wird</param>
		/// <param name="amPmType">Der Typ der AM/PM-Angabe</param>
		/// <param name="amPmSeparator">Gibt das Zeichen an, mit dem die AM/PM-Angabe von der Zeit getrennt ist</param>
		/// <param name="calendar"> Der verwendete Kalender</param>
		/// <param name="dateSuffixPattern">Das Regex-Muster, das auf den Suffix passt, mit dem ein Datum abgeschlossen sein kann</param>
		/// <param name="dateTimeSeparatorPattern">Das Regex-Muster, das auf die Trennzeichen zwischen Zeit und Datum passt (normalerweise ist das einfach ein Leerzeichen)</param>
		/// <param name="cultureInfo">Das CultureInfo-Objekt der Kultur, für die die DateFormatInfo erzeugt wird</param>
		/// <param name="timeInputIn24HourFormatEnabled">Gibt an, ob eine Zeitangabe im 24-Stunden-Format möglich ist</param>
		public DateFormatInfo(DateFormat dateFormat, DateTimeAmPmType amPmType, string aMString, string pMString, string amPmSeparator, string dateSuffixPattern, string dateTimeSeparatorPattern, CultureInfo cultureInfo, bool timeInputIn24HourFormatEnabled)
		{
			this.DateFormat = dateFormat;
			this.AmPmType = amPmType;
			this.AMString = aMString;
			this.PMString = pMString;
			this.AmPmSeparator = amPmSeparator;
			this.CultureInfo = cultureInfo;
			this.DateSuffixPattern = dateSuffixPattern;
			this.DateTimeSeparatorPattern = dateTimeSeparatorPattern;
			this.TimeInputIn24HourFormatEnabled = timeInputIn24HourFormatEnabled;
		}

		public DateFormatInfo()
		{
		}

		#endregion

		#region Eigenschaften

		/// <summary>
		/// Gibt zurück, ob die Zeitangabe im Datum eine AM/PM-Angabe ist
		/// </summary>
		public bool IsAmPmTime
		{
			get
			{
				return this.AmPmType != DateTimeAmPmType.None;
			}
		}

		#endregion

		#region Instanzmethoden

		/// <summary>
		/// Liefert die logischen (1-basierte) Position des Tages in der Datumsangabe
		/// </summary>
		public int DayPosition
		{
			get
			{
				switch (this.DateFormat)
				{
				case DateFormat.German:
				case DateFormat.English1:
				case DateFormat.Indian1:
				case DateFormat.Indian2:
				case DateFormat.UnSupportedFormat:
					return 1;

				case DateFormat.English2:
				case DateFormat.Yakut:
					return 2;

				case DateFormat.Chinese1:
				case DateFormat.Chinese2:
				case DateFormat.Hungary:
					return 3;

				default:
					throw new Exception("Unsupported DateFormat '" + this.DateFormat.ToString() + "'");
				}
			}
		}

		/// <summary>
		/// Liefert die logischen (1-basierte) Position des Monats in der Datumsangabe
		/// </summary>
		public int MonthPosition
		{
			get
			{
				switch (this.DateFormat)
				{
				case DateFormat.German:
				case DateFormat.English1:
				case DateFormat.Indian1:
				case DateFormat.Indian2:
				case DateFormat.Chinese1:
				case DateFormat.Chinese2:
				case DateFormat.Hungary:
				case DateFormat.UnSupportedFormat:
					return 2;

				case DateFormat.English2:
				case DateFormat.Yakut:
					return 1;

				default:
					throw new Exception("Unsupported DateFormat '" + this.DateFormat.ToString() + "'");
				}
			}
		}

		/// <summary>
		/// Liefert die logischen (1-basierte) Position des Jahres in der Datumsangabe
		/// </summary>
		public int YearPosition
		{
			get
			{
				switch (this.DateFormat)
				{
				case DateFormat.German:
				case DateFormat.English1:
				case DateFormat.English2:
				case DateFormat.Indian1:
				case DateFormat.Indian2:
				case DateFormat.Yakut:
				case DateFormat.UnSupportedFormat:
					return 3;

				case DateFormat.Chinese1:
				case DateFormat.Chinese2:
				case DateFormat.Hungary:
					return 1;

				default:
					throw new Exception("Unsupported DateFormat '" + this.DateFormat.ToString() + "'");
				}
			}
		}

		#endregion

		#region Methoden

		/// <summary>
		/// Liefert eine Information zum Datumsformat der aktuellen Kultur
		/// </summary>
		/// <returns></returns>
		public DateFormatInfo GetCurrentDateFormatInfo()
		{
			return this.GetDateFormatInfo(Thread.CurrentThread.CurrentCulture);
		}

		/// <summary>
		/// Liefert eine Information zum Datumsformat der übergebenen Kultur
		/// </summary>
		public DateFormatInfo GetDateFormatInfo(CultureInfo cultureInfo)
		{
			#region  Ermitteln des Datumsformats der übergebenen Kultur

			DateFormat dateFormat = DateFormat.UnSupportedFormat;
			switch (cultureInfo.Name)
			{
			case "ar-AE":
			case "ar-BH":
			case "ar-EG":
			case "ar-IQ":
			case "ar-JO":
			case "ar-KW":
			case "ar-LB":
			case "ar-LY":
			case "ar-OM":
			case "ar-QA":
			case "ar-SA":
			case "ar-SY":
			case "ar-YE":
			case "ca-ES":
			case "div-MV":
			case "en-BZ":
			case "en-CA":
			case "en-GB":
			case "en-IE":
			case "en-JM":
			case "en-TT":
			case "es-AR":
			case "es-BO":
			case "es-CO":
			case "es-CR":
			case "es-DO":
			case "es-EC":
			case "es-ES":
			case "es-GT":
			case "es-HN":
			case "es-MX":
			case "es-NI":
			case "es-PE":
			case "es-PR":
			case "es-PY":
			case "es-SV":
			case "es-UY":
			case "es-VE":
			case "fr-FR":
			case "fr-LU":
			case "fr-MC":
			case "gl-ES":
			case "he-IL":
			case "id-ID":
			case "it-IT":
			case "ms-BN":
			case "ms-MY":
			case "syr-SY":
			case "ur-PK":
			case "uz-UZ-Latn":
			case "vi-VN":
			case "el-GR":
			case "en-AU":
			case "en-NZ":
			case "fr-BE":
			case "nl-BE":
			case "pt-BR":
			case "th-TH":
			case "zh-HK":
			case "zh-MO":
			case "zh-SG":
			case "gsw-FR":
			case "am-ET":
			case "br-FR":
			case "co-FR":
			case "en-MY":
			case "en-SG":
			case "ha-Latn-NG":
			case "ig-NG":
			case "iu-Cans-CA":
			case "iu-Latn-CA":
			case "ga-IE":
			case "qut-GT":
			case "lo-LA":
			case "lb-LU":
			case "mi-NZ":
			case "mt-MT":
			case "oc-FR":
			case "quz-BO":
			case "quz-EC":
			case "quz-PE":
			case "rm-CH":
			case "cy-GB":
			case "wo-SN":
			case "yo-NG":
			case "dv-MV":  // 22/12/28 23:59:00 (Hijri-Kalender)
			case "prs-AF": // 22/12/28 11:59 غ.م                                22/12/28 11:59 غ.و
			case "ps-AF":  // 22/12/28 11:59 غ.م                                22/12/28 11:59 غ.و
			case "uz-Latn-UZ": // 31/12 2007 23:59:00 => Sonderfall wegen Leerzeichen als zweitem Datums-Separator
				dateFormat = DateFormat.English1;
				break;

			case "en-CB":
			case "en-PH":
			case "en-US":
			case "en-ZW":
			case "es-PA":
			case "fa-IR":
			case "sw-KE":
			case "en-029":
			case "fil-PH":
			case "rw-RW":
			case "moh-CA":
			case "ne-NP":
			case "es-US":
				dateFormat = DateFormat.English2;
				break;

			case "az-AZ-Cyrl":
			case "az-AZ-Latn":
			case "be-BY":
			case "bg-BG":
			case "cs-CZ":
			case "de-AT":
			case "de-CH":
			case "de-DE":
			case "de-LI":
			case "de-LU":
			case "et-EE":
			case "fi-FI":
			case "fr-CH":
			case "hr-HR":
			case "hy-AM":
			case "is-IS":
			case "it-CH":
			case "ka-GE":
			case "kk-KZ":
			case "ky-KZ":
			case "mk-MK":
			case "nb-NO":
			case "nn-NO":
			case "ro-RO":
			case "ru-RU":
			case "sk-SK":
			case "sl-SI":
			case "sr-SP-Cyrl":
			case "sr-SP-Latn":
			case "sv-FI":
			case "tr-TR":
			case "tt-RU":
			case "uk-UA":
			case "uz-UZ-Cyrl":
			case "az-Cyrl-AZ":
			case "az-Latn-AZ":
			case "ba-RU": // 31.12.07 23:59:59
			case "bs-Cyrl-BA":
			case "bs-Latn-BA":
			case "hr-BA":
			case "ky-KG": // 31.12.07 23:59:59
			case "se-FI":
			case "se-NO":
			case "sms-FI":
			case "sma-NO":
			case "sr-Cyrl-BA":
			case "sr-Cyrl-CS":
			case "sr-Latn-BA":
			case "sr-Latn-CS":
			case "tg-Cyrl-TJ": // 31.12.07 23:59:59
			case "tk-TM": // 31.12.07 23:59:59
			case "uz-Cyrl-UZ":
			case "smn-FI":
			case "smj-NO":
			case "dsb-DE": // 31. 12. 2007 23:59:00
			case "hsb-DE": // 31. 12. 2007 23:59:00
				dateFormat = DateFormat.German;
				break;

			case "a-DZ":
			case "a-MA":
			case "a-TN":
			case "da-DK":
			case "es-CL":
			case "fo-FO":
			case "gu-IN":
			case "hi-IN":
			case "kn-IN":
			case "kok-IN":
			case "m-IN":
			case "nl-NL":
			case "pa-IN":
			case "pt-PT":
			case "sa-IN":
			case "ta-IN":
			case "te-IN":
			case "ar-DZ":
			case "ar-MA":
			case "ar-TN":
			case "as-IN":
			case "en-IN":
			case "fy-NL":
			case "kl-GL":
			case "arn-CL":
			case "mr-IN":
			case "tzm-Latn-DZ":
			case "or-IN":
				dateFormat = DateFormat.Indian1;
				break;

			case "bn-BD":
			case "bn-IN":
			case "ml-IN":
				dateFormat = DateFormat.Indian2;
				break;

			case "ko-KR":
			case "pl-PL":
			case "sq-AL":
			case "sv-SE":
			case "zh-CN":
			case "fr-CA":
			case "km-KH":
			case "smj-SE":
			case "se-SE":
			case "sma-SE":
			case "si-LK":
			case "lt-LT": //  2007.12.31 23:59:00
				dateFormat = DateFormat.Chinese1;
				break;

			case "af-ZA":
			case "en-ZA":
			case "eu-ES":
			case "ja-JP":
			case "zh-TW":
			case "xh-ZA":
			case "zu-ZA":
			case "mn-Mong-CN":
			case "nso-ZA":
			case "tn-ZA":
			case "bo-CN":
			case "ug-CN":
			case "ii-CN":
				dateFormat = DateFormat.Chinese2;
				break;

			case "hu-HU":
			case "lv-LV":
			case "mn-MN":
				dateFormat = DateFormat.Hungary;
				break;

			case "sah-RU":
				dateFormat = DateFormat.Yakut;
				break;

			default:
				dateFormat = DateFormat.UnSupportedFormat;
				break;
			}

			#endregion

			#region AM- und PM-Angaben ermitteln

			string amString = null;
			string pmString = null;
			string amPmSeparator = " ";
			DateTimeAmPmType amPmType = DateTimeAmPmType.None;
			if (dateFormat != DateFormat.UnSupportedFormat)
			{
				switch (cultureInfo.Name)
				{
				case "af-ZA":
					amString = null;
					pmString = "nm";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "am-ET":
					amString = "ጡዋት";
					pmString = "ከሰዓት";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "ar-AE":
				case "ar-BH":
				case "ar-EG":
				case "ar-IQ":
				case "ar-JO":
				case "ar-KW":
				case "ar-LB":
				case "ar-LY":
				case "ar-OM":
				case "ar-QA":
				case "ar-SA":
				case "ar-SY":
				case "ar-YE":
					amString = "ص";
					pmString = "م";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "as-IN":
					amString = "ৰাতিপু";
					pmString = "আবেলি";
					amPmType = DateTimeAmPmType.Left;
					break;

				case "el-GR":
					amString = "πμ";
					pmString = "μμ";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "en-029":
				case "en-AU":
				case "en-BZ":
				case "en-CA":
				case "en-JM":
				case "en-MY":
				case "en-PH":
				case "en-SG":
				case "en-TT":
				case "en-US":
				case "en-ZA":
				case "en-ZW":
				case "es-US":
				case "fil-PH":
				case "iu-Cans-CA":
				case "iu-Latn-CA":
				case "moh-CA":
				case "nso-ZA":
				case "sw-KE":
				case "tn-ZA":
				case "ur-PK":
				case "xh-ZA":
				case "zu-ZA":
					amString = "AM";
					pmString = "PM";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "en-NZ":
				case "es-AR":
				case "es-BO":
				case "es-CO":
				case "es-CR":
				case "es-DO":
				case "es-GT":
				case "es-HN":
				case "es-MX":
				case "es-NI":
				case "es-PA":
				case "es-PE":
				case "es-PR":
				case "es-PY":
				case "es-SV":
				case "es-UY":
				case "es-VE":
				case "mi-NZ":
				case "qut-GT":
				case "quz-BO":
				case "quz-PE":
					amString = "a.m.";
					pmString = "p.m.";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "fa-IR":
					amString = "ق.ظ";
					pmString = "ب.ظ";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "ha-Latn-NG":
					amString = "Safe";
					pmString = "Yamma";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "ig-NG":
					amString = "Ututu";
					pmString = "Efifie";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "ko-KR":
					amString = "오전";
					pmString = "오후";
					amPmType = DateTimeAmPmType.Left;
					break;

				case "mn-Mong-CN":
					amString = "ᠡᠮᠦᠨᠡᠬᠢ";
					pmString = "ᠬᠤᠢᠢᠨᠠᠬᠢ";
					amPmType = DateTimeAmPmType.Left;
					break;

				case "ne-NP":
					amString = "विहानी";
					pmString = "बेलुकी";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "pa-IN":
					amString = "ਸਵੇਰੇ";
					pmString = "ਸ਼ਾਮ";
					amPmType = DateTimeAmPmType.Left;
					break;

				case "prs-AF":
				case "ps-AF":
					amString = "غ.م";
					pmString = "غ.و";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "rw-RW":
					amString = "saa moya z.m.";
					pmString = "saa moya z.n.";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "si-LK":
					amString = "පෙ.ව.";
					pmString = "ප.ව.";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "sq-AL":
					amString = "PD";
					pmString = "MD";
					amPmSeparator = ".";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "syr-SY":
					amString = "ܩ.ܛ";
					pmString = "ܒ.ܛ";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "vi-VN":
					amString = "SA";
					pmString = "CH";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "yo-NG":
					amString = "Owuro";
					pmString = "Ale";
					amPmType = DateTimeAmPmType.Right;
					break;

				case "zh-SG":
					amString = "AM";
					pmString = "PM";
					amPmType = DateTimeAmPmType.Left;
					break;

				case "zh-TW":
					amString = "上午";
					pmString = "下午";
					amPmType = DateTimeAmPmType.Left;
					break;
				}
			}

			#endregion

			#region Muster für ein eventuell vorhandenes Datums-Suffix und das Muster für die Trennumg von Datum und Zeit ermitteln

			string dateSuffixPattern = null;
			string dateTimeSeparatorPattern = " ";
			switch (cultureInfo.Name)
			{
			case "bg-BG":
				dateSuffixPattern = @"(?: | г| г\.)"; ;
				break;

			case "hu-HU":
			case "lv-LV":
				dateSuffixPattern = @"(?:\.)";
				break;

			default:
				dateSuffixPattern = null;
				break;
			}

			#endregion

			#region Ermitteln, ob eine Zeitangabe im 24-Stunden-Format möglich ist

			bool timeInputIn24HourFormatEnabled = false;
			string testTime = "23" + cultureInfo.DateTimeFormat.TimeSeparator + "00" + cultureInfo.DateTimeFormat.TimeSeparator + "00";
			try
			{
				Convert.ToDateTime(testTime, cultureInfo);
				timeInputIn24HourFormatEnabled = true;
			}
			catch { }

			#endregion

			// Ergebnis zurückgeben
			return new DateFormatInfo(dateFormat, amPmType, amString, pmString, amPmSeparator, dateSuffixPattern, dateTimeSeparatorPattern, cultureInfo, timeInputIn24HourFormatEnabled);
		}

		#endregion
	}
}

