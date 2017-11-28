using System;
using log4net;
using InMemoryLoaderBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using InMemoryLoaderBase.HelperEnum;

namespace PowerUpDateTimeUtils
{
	public partial class DateTimeUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Überprüft eine Eingabe daraufhin, ob diese bezogen auf die aktuelle Kultur potenziell 
		/// ein gültiges Datum oder/und eine gültige Zeit ergeben kann
		/// </summary>
		/// <param name="input">Die Eingabe</param>
		/// <param name="includeDate">Gibt an, ob bei der Eingabe eine Datumsangabe berücksichtigt werden soll</param>
		/// <param name="includeTime">Gibt an, ob bei der Eingabe eine Zeitangabe berücksichtigt werden soll</param>
		/// <param name="allowZeroForDayAndMonth">Gibt an, ob die Eingabe eine 0 für den Tag und den Monat erlaubt ist</param>
		/// <returns>Gibt true zurück wenn die Eingabe potenziell ein Datum und/oder eine Zeit ergeben kann</returns>
		public bool IsPotentialDateTime(string input, bool includeDate, bool includeTime, bool allowZeroForDayAndMonth)
		{
			return IsPotentialDateTime(input, includeDate, includeTime, allowZeroForDayAndMonth, Thread.CurrentThread.CurrentCulture);
		}

		/// <summary>
		/// Überprüft eine Eingabe daraufhin, ob diese bezogen auf die übergebene Kultur potenziell 
		/// ein gültiges Datum oder/und eine gültige Zeit ergeben kann
		/// </summary>
		/// <param name="input">Die Eingabe</param>
		/// <param name="includeDate">Gibt an, ob bei der Eingabe eine Datumsangabe berücksichtigt werden soll</param>
		/// <param name="includeTime">Gibt an, ob bei der Eingabe eine Zeitangabe berücksichtigt werden soll</param>
		/// <param name="culture">Die Kultur, für die das Datum überprüft werden soll</param>
		/// <param name="allowZeroForDayAndMonth">Gibt an, ob die Eingabe eine 0 für den Tag und den Monat erlaubt ist</param>
		/// <returns>Gibt true zurück wenn die Eingabe potenziell ein Datum und/oder eine Zeit ergeben kann</returns>
		public bool IsPotentialDateTime(string input, bool includeDate, bool includeTime, bool allowZeroForDayAndMonth, CultureInfo culture)
		{
			// Anmerkung: Diese Methode setzt bewußt keinen StringBuilder ein um das Muster
			// für den regulären Ausdruck zu bilden. Die Gründe dafür sind, dass zum einen
			// die Performance der Variante mit StringBulder (IsPotentialDateTime_StringBuilderTest)
			// nicht besser war (gemessen in der Beispiel-Anwendung für eine internationale Prüfung
			// zu dem Rezept "Eine Eingabe daraufhin überprüfen, ob diese ein Datum ergeben kann") 
			// und zum anderen die Variante mit dem StringBuilder nur sehr schwer zu verstehen
			// und damit zu debuggen bzw. zu erweitern ist. Das schwierigere Debuggen und Erweitern 
			// war auch der Grund dafür, dass ich beim Bilden des Musters oft String-Literale 
			// statt String-Konstanten verwendet habe.

			// Datumsformatinfo ermitteln
			DateFormatInfo dateFormatInfo = new DateFormatInfo().GetDateFormatInfo(culture);

			// Min- und Maxwerte für Tag, Monat und Jahr ermitteln
			int minDay = (allowZeroForDayAndMonth ? 0 : 1);
			int maxDay;
			if (culture.Calendar is ChineseLunisolarCalendar ||
				culture.Calendar is HebrewCalendar ||
				culture.Calendar is HijriCalendar ||
				culture.Calendar is JapaneseLunisolarCalendar ||
				culture.Calendar is KoreanLunisolarCalendar ||
				culture.Calendar is UmAlQuraCalendar)
			{
				// Diese Kalender besitzen maximal 30 Tage im Monat
				maxDay = 30;
			}
			else
			{
				// Die restlichen Kalender besitzen maximal 31 Tage im Monat
				maxDay = 31;
			}

			int minMonth = (allowZeroForDayAndMonth ? 0 : 1);
			int maxMonth;
			if (culture.Calendar is ChineseLunisolarCalendar ||
				culture.Calendar is HebrewCalendar ||
				culture.Calendar is JapaneseLunisolarCalendar ||
				culture.Calendar is KoreanLunisolarCalendar)
			{
				// Diese Kalender besitzen (in manchen Jahren) 13 Monate
				maxMonth = 13;
			}
			else
			{
				//  Normaler Kalender mit maximal 12 Monaten (der 
				// persische Kalender hat auch Jahre mit 10 Monaten)
				maxMonth = 12;
			}
			int minYear = 0;
			int maxYear = dateFormatInfo.CultureInfo.Calendar.GetYear(
				dateFormatInfo.CultureInfo.Calendar.MaxSupportedDateTime);

			// Min- und Maxwerte für die Stunde, Minute und Sekunde festlegen
			int minHour = 0;
			int maxHour = (dateFormatInfo.TimeInputIn24HourFormatEnabled ? 23 : 12);
			int minMinute = 0;
			int maxMinute = 59;
			int minSecond = 0;
			int maxSecond = 59;

			// Die aktuellen Separatoren ermitteln 
			// Anm.: Einige Sprachen besitzen mehrteilige Separatoren 
			// (Beispiel: Ungarisch: "2007. 12. 31. 11:59:59") 
			string dateSeparatorPattern = null;
			string incrementedSeparator = null;
			if (culture.Name != "uz-Latn-UZ")
			{
				foreach (char ch in culture.DateTimeFormat.DateSeparator)
				{
					incrementedSeparator += Regex.Escape(ch.ToString());
					if (dateSeparatorPattern != null)
					{
						dateSeparatorPattern += "|";
					}
					dateSeparatorPattern += incrementedSeparator;
				}
				dateSeparatorPattern = "(?:" + dateSeparatorPattern + ")";
			}
			else
			{
				// Sonderfall für Uzbekistan wegen Leerzeichen als zweitem Datums-Separator
				// Beispiel: "31/12 2007 23:59:00"
				// HACK: Hier werden an beiden Stellen Leerzeichen und der Schrägstrich zugelassen,
				// da eine spezielle Programmierung zu aufwändig wäre
				dateSeparatorPattern = "(?: |/)";
			}

			string timeSeparatorPattern = null;
			incrementedSeparator = null;
			foreach (char ch in culture.DateTimeFormat.TimeSeparator)
			{
				incrementedSeparator += Regex.Escape(ch.ToString());
				if (timeSeparatorPattern != null)
				{
					timeSeparatorPattern += "|";
				}
				timeSeparatorPattern += incrementedSeparator;
			}
			timeSeparatorPattern = "(?:" + timeSeparatorPattern + ")";

			// Die Position der Datumsteile ermitteln
			int dayPosition = dateFormatInfo.DayPosition;
			int monthPosition = dateFormatInfo.MonthPosition;
			int yearPosition = dateFormatInfo.YearPosition;

			if (dateFormatInfo.DateFormat == DateFormat.UnSupportedFormat)
			{
				throw new Exception("Die  Kultur '" + culture.Name + "' wird nicht unterstützt");
			}

			// Die Muster für die Datumsteile ermitteln
			string datePart1Pattern = null;
			string datePart2Pattern = null;
			string datePart3Pattern = null;
			switch (yearPosition)
			{
			case 1:
				datePart1Pattern = @"\d{1,4}";
				datePart2Pattern = @"\d{1,2}";
				datePart3Pattern = @"\d{1,2}";
				break;

			case 2:
				datePart1Pattern = @"\d{1,2}";
				datePart2Pattern = @"\d{1,4}";
				datePart3Pattern = @"\d{1,2}";
				break;

			case 3:
				datePart1Pattern = @"\d{1,2}";
				datePart2Pattern = @"\d{1,2}";
				datePart3Pattern = @"\d{1,4}";
				break;
			}

			// Die Muster für das volle Datum, die volle lange und die
			// gesamte kurze Zeit festlegen
			string fullDatePattern = null;
			if (includeDate)
			{
				fullDatePattern = @"(?<d1>" + datePart1Pattern + ")" + dateSeparatorPattern +
					@"(?<d2>" + datePart2Pattern + ")" + dateSeparatorPattern + @"(?<d3>" +
					datePart3Pattern + ")" + dateFormatInfo.DateSuffixPattern;
			}
			string shortTimePattern = @"(?<t1>\d{1,2})" + timeSeparatorPattern + @"(?<t2>\d{1,2})";
			string fullTimePattern = shortTimePattern + timeSeparatorPattern + @"(?<t3>\d{1,2})";
			string dateTimeSeparatorPattern = (includeDate ? dateFormatInfo.DateTimeSeparatorPattern : null);

			// Das Muster für den regulären Ausdruck festlegen
			string pattern = @"^(?:";
			if (includeDate)
			{
				pattern +=
					@"(?<d1>" + datePart1Pattern + ")|" +
					@"(?:(?<d1>" + datePart1Pattern + ")" + dateSeparatorPattern + @")|" +
					@"(?:(?<d1>" + datePart1Pattern + ")" + dateSeparatorPattern + @"(?<d2>" +
					datePart2Pattern + "))|" +
					@"(?:(?<d1>" + datePart1Pattern + ")" + dateSeparatorPattern + @"(?<d2>" +
					datePart2Pattern + ")" + dateSeparatorPattern + ")|" +
					(dateFormatInfo.DateSuffixPattern != null ?
						@"(?:(?<d1>" + datePart1Pattern + ")" + dateSeparatorPattern + @"(?<d2>" +
						datePart2Pattern + ")" + dateSeparatorPattern + @"(?<d3>" + datePart3Pattern + "))|" : null) +
					@"(?:" + fullDatePattern + ")";
			}
			if (includeTime)
			{
				if (includeDate)
				{
					pattern += "|";
				}
				string leftAmPmPattern1 = null;
				string leftAmPmPattern2 = null;
				string rightAmPmPattern = null;
				string amPmPattern = null;
				if (dateFormatInfo.IsAmPmTime)
				{
					amPmPattern = null;
					if (string.IsNullOrEmpty(dateFormatInfo.AMString) == false)
					{
						string amPattern = null;
						foreach (char amChar in dateFormatInfo.AMString)
						{
							amPattern += amChar;
							if (amPmPattern != null)
							{
								amPmPattern += "|";
							}
							amPmPattern += "(?:" + amPattern + ")";
						}
					}

					if (string.IsNullOrEmpty(dateFormatInfo.PMString) == false)
					{
						string pmPattern = null;
						foreach (char pmChar in dateFormatInfo.PMString)
						{
							pmPattern += pmChar;
							if (amPmPattern != null)
							{
								amPmPattern += "|";
							}
							amPmPattern += "(?:" + pmPattern + ")";
						}
					}

					amPmPattern = "(?:" + amPmPattern + ")";
				}

				switch (dateFormatInfo.AmPmType)
				{
				case DateTimeAmPmType.None:
					leftAmPmPattern1 = null;
					leftAmPmPattern2 = null;
					rightAmPmPattern = null;
					break;

				case DateTimeAmPmType.Left:
					leftAmPmPattern1 = amPmPattern;
					leftAmPmPattern2 = "(?:" + dateFormatInfo.AMString + "|" + dateFormatInfo.PMString + ")";
					rightAmPmPattern = null;
					break;

				case DateTimeAmPmType.Right:
					leftAmPmPattern1 = null;
					leftAmPmPattern2 = null;
					rightAmPmPattern = amPmPattern;
					break;
				}

				if (leftAmPmPattern1 != null)
				{
					string leftAmPmSeparator = (includeDate ? dateFormatInfo.AmPmSeparator : null);
					string rightAmPmSeparator = dateFormatInfo.AmPmSeparator;
					pattern +=
						"(?:" + fullDatePattern + leftAmPmSeparator + @")|" +
						"(?:" + fullDatePattern + leftAmPmSeparator + leftAmPmPattern1 + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern + @"(?<t1>\d{1,2}))|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern +
						@"(?<t1>\d{1,2})" + timeSeparatorPattern + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern + shortTimePattern + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern + shortTimePattern +
						timeSeparatorPattern + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern + fullTimePattern + @")|" +
						"(?:" + fullDatePattern + leftAmPmSeparator + leftAmPmPattern2 +
						rightAmPmSeparator + @")|" +
						"(?:" + fullDatePattern + leftAmPmSeparator + leftAmPmPattern2 +
						rightAmPmSeparator + @"(?<t1>\d{1,2}))|" +
						"(?:" + fullDatePattern + leftAmPmSeparator + leftAmPmPattern2 +
						rightAmPmSeparator + @"(?<t1>\d{1,2})" + timeSeparatorPattern + @")|" +
						"(?:" + fullDatePattern + leftAmPmSeparator + leftAmPmPattern2 +
						rightAmPmSeparator + shortTimePattern + @")|" +
						"(?:" + fullDatePattern + leftAmPmSeparator + leftAmPmPattern2 +
						rightAmPmSeparator + shortTimePattern + timeSeparatorPattern + @")|" +
						"(?:" + fullDatePattern + leftAmPmSeparator + leftAmPmPattern2 +
						rightAmPmSeparator + fullTimePattern + @")";
				}
				else
				{
					if (includeDate)
					{
						pattern +=
							"(?:" + fullDatePattern + dateTimeSeparatorPattern + @")|";
					}
					pattern +=
						"(?:" + fullDatePattern + dateTimeSeparatorPattern +
						@"(?<t1>\d{1,2}))|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern +
						@"(?<t1>\d{1,2})" + timeSeparatorPattern + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern +
						shortTimePattern + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern +
						shortTimePattern + timeSeparatorPattern + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern +
						fullTimePattern + @")";
				}

				if (rightAmPmPattern != null)
				{
					pattern += "|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern + shortTimePattern +
						dateFormatInfo.AmPmSeparator + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern + shortTimePattern +
						dateFormatInfo.AmPmSeparator + rightAmPmPattern + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern + fullTimePattern +
						dateFormatInfo.AmPmSeparator + @")|" +
						"(?:" + fullDatePattern + dateTimeSeparatorPattern + fullTimePattern +
						dateFormatInfo.AmPmSeparator + rightAmPmPattern + ")";
				}
			}
			pattern += ")$";

			// Den regulären Ausdruck ausführen
			Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);

			// Das Ergebnis auswerten
			if (match.Success)
			{
				bool valid = (includeDate || includeTime ? true : false);

				// Ermitteln der eingegebenen Datumsteile
				if (includeDate)
				{
					int day = -1;
					int month = -1;
					int year = -1;
					if (match.Groups["d1"].Value.Length > 0) // 31
					{
						if (dayPosition == 1)
						{
							day = Convert.ToInt32(match.Groups["d1"].ToString());
						}
						else if (monthPosition == 1)
						{
							month = Convert.ToInt32(match.Groups["d1"].ToString());
						}
						else
						{
							year = Convert.ToInt32(match.Groups["d1"].ToString());
						}
					}
					if (match.Groups["d2"].Value.Length > 0) // 31.12.
					{
						if (dayPosition == 2)
						{
							day = Convert.ToInt32(match.Groups["d2"].ToString());
						}
						else if (monthPosition == 2)
						{
							month = Convert.ToInt32(match.Groups["d2"].ToString());
						}
						else
						{
							year = Convert.ToInt32(match.Groups["d2"].ToString());
						}
					}
					if (match.Groups["d3"].Value.Length > 0) // 31.12.2010
					{
						if (dayPosition == 3)
						{
							day = Convert.ToInt32(match.Groups["d3"].ToString());
						}
						else if (monthPosition == 3)
						{
							month = Convert.ToInt32(match.Groups["d3"].ToString());
						}
						else
						{
							year = Convert.ToInt32(match.Groups["d3"].ToString());
						}
					}

					// Ermitteln, ob das Datum valide ist;
					valid &=
						(day == -1 || (day >= minDay && day <= maxDay)) &&
						(month == -1 || (month >= minMonth && month <= maxMonth)) &&
						(year == -1 || (year >= minYear && year <= maxYear));
				}

				if (includeTime)
				{
					// Den Zeitanteil auswerten
					if (match.Groups["t1"].Value.Length > 0) // 31.12.2010 23:
					{
						int hour = Convert.ToInt32(match.Groups["t1"].ToString());
						valid &= (hour >= minHour && hour <= maxHour);
					}
					if (match.Groups["t2"].Value.Length > 0) // 31.12.2010 23:59
					{
						int minute = Convert.ToInt32(match.Groups["t2"].ToString());
						valid &= (minute >= minMinute && minute <= maxMinute);
					}
					if (match.Groups["t3"].Value.Length > 0) // 31.12.2010 23:59:59
					{
						int second = Convert.ToInt32(match.Groups["t3"].ToString());
						valid &= (second >= minSecond && second <= maxSecond);
					}
				}

				return valid;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Überprüft eine Eingabe daraufhin, ob diese bezogen auf die übergebene Kultur potenziell 
		/// ein gültiges Datum oder/und eine gültige Zeit ergeben kann
		/// </summary>
		/// <param name="input">Die Eingabe</param>
		/// <param name="includeDate">Gibt an, ob bei der Eingabe eine Datumsangabe berücksichtigt werden soll</param>
		/// <param name="includeTime">Gibt an, ob bei der Eingabe eine Zeitangabe berücksichtigt werden soll</param>
		/// <param name="culture">Die Kultur, für die das Datum überprüft werden soll</param>
		/// <param name="allowZeroForDayAndMonth">Gibt an, ob die Eingabe eine 0 für den Tag und den Monat erlaubt ist</param>
		/// <returns>Gibt true zurück wenn die Eingabe potenziell ein Datum und/oder eine Zeit ergeben kann</returns>
		public bool IsPotentialDateTime_StringBuilderTest(string input, bool includeDate, bool includeTime, bool allowZeroForDayAndMonth, CultureInfo culture)
		{
			// Anmerkung: Diese Variante verwendet einen StringBuilder zur Bildung des
			// Musters für den regulären Ausdruck. Die Performance war gegenüber der
			// Variante ohne StringBuilder aber sogar im Schnitt gleich bzw. geringfügig schlechter!

			// Die Strings für den regulären Ausdruck definieren
			const string decimal1to2Pattern = @"\d{1,2}";
			const string decimal1To4Pattern = @"\d{1,4}";
			const string nonRecordingGroupStart = "(?:";
			const string slash = "|";
			const string datePart1GroupStart = @"(?<d1>";
			const string datePart2GroupStart = @"(?<d2>";
			const string datePart3GroupStart = @"(?<d3>";
			const string timePart1Pattern = @"(?<t1>\d{1,2})";
			const string timePart2Pattern = @"(?<t2>\d{1,2})";
			const string timePart3Pattern = @"(?<t3>\d{1,2})";
			const string closingBracket = ")";
			const string closingBracketWithSlash = ")|";
			const string doubleClosingBracketWithSlash = "))|";

			// Datumsformatinfo ermitteln
			DateFormatInfo dateFormatInfo = new DateFormatInfo().GetDateFormatInfo(culture);

			// Min- und Maxwerte für Tag, Monat und Jahr ermitteln
			int minDay = (allowZeroForDayAndMonth ? 0 : 1);
			int maxDay;
			if (culture.Calendar is ChineseLunisolarCalendar ||
				culture.Calendar is HebrewCalendar ||
				culture.Calendar is HijriCalendar ||
				culture.Calendar is JapaneseLunisolarCalendar ||
				culture.Calendar is KoreanLunisolarCalendar ||
				culture.Calendar is UmAlQuraCalendar)
			{
				// Diese Kalender besitzen maximal 30 Tage im Monat
				maxDay = 30;
			}
			else
			{
				// Die restlichen Kalender besitzen maximal 31 Tage im Monat
				maxDay = 31;
			}

			int minMonth = (allowZeroForDayAndMonth ? 0 : 1);
			int maxMonth;
			if (culture.Calendar is ChineseLunisolarCalendar ||
				culture.Calendar is HebrewCalendar ||
				culture.Calendar is JapaneseLunisolarCalendar ||
				culture.Calendar is KoreanLunisolarCalendar)
			{
				// Diese Kalender besitzen (in manchen Jahren) 13 Monate
				maxMonth = 13;
			}
			else
			{
				//  Normaler Kalender mit maximal 12 Monaten (der 
				// persische Kalender hat auch Jahre mit 10 Monaten)
				maxMonth = 12;
			}
			int minYear = 0;
			int maxYear = dateFormatInfo.CultureInfo.Calendar.GetYear(
				dateFormatInfo.CultureInfo.Calendar.MaxSupportedDateTime);

			// Min- und Maxwerte für die Stunde, Minute und Sekunde festlegen
			int minHour = 0;
			int maxHour = (dateFormatInfo.TimeInputIn24HourFormatEnabled ? 23 : 12);
			int minMinute = 0;
			int maxMinute = 59;
			int minSecond = 0;
			int maxSecond = 59;

			// Die aktuellen Separatoren ermitteln 
			// Anm.: Einige Sprachen besitzen mehrteilige Separatoren 
			// (Beispiel: Ungarisch: "2007. 12. 31. 11:59:59") 
			string dateSeparatorPattern = null;
			string incrementedSeparator = null;
			if (culture.Name != "uz-Latn-UZ")
			{
				foreach (char ch in culture.DateTimeFormat.DateSeparator)
				{
					incrementedSeparator += Regex.Escape(ch.ToString());
					if (dateSeparatorPattern != null)
					{
						dateSeparatorPattern += slash;
					}
					dateSeparatorPattern += incrementedSeparator;
				}
				dateSeparatorPattern = nonRecordingGroupStart + dateSeparatorPattern + closingBracket;
			}
			else
			{
				// Sonderfall für Uzbekistan wegen Leerzeichen als zweitem Datums-Separator
				// Beispiel: "31/12 2007 23:59:00"
				// HACK: Hier werden an beiden Stellen Leerzeichen und der Schrägstrich zugelassen,
				// da eine spezielle Programmierung zu aufwändig wäre
				dateSeparatorPattern = "(?: |/)";
			}

			string timeSeparatorPattern = null;
			incrementedSeparator = null;
			foreach (char ch in culture.DateTimeFormat.TimeSeparator)
			{
				incrementedSeparator += Regex.Escape(ch.ToString());
				if (timeSeparatorPattern != null)
				{
					timeSeparatorPattern += slash;
				}
				timeSeparatorPattern += incrementedSeparator;
			}
			timeSeparatorPattern = nonRecordingGroupStart + timeSeparatorPattern + closingBracket;

			// Die Position der Datumsteile ermitteln
			int dayPosition = dateFormatInfo.DayPosition;
			int monthPosition = dateFormatInfo.MonthPosition;
			int yearPosition = dateFormatInfo.YearPosition;

			if (dateFormatInfo.DateFormat == DateFormat.UnSupportedFormat)
			{
				throw new Exception("Die  Kultur '" + culture.Name + "' wird nicht unterstützt");
			}

			// Die Muster für die Datumsteile ermitteln
			string datePart1Pattern = null;
			string datePart2Pattern = null;
			string datePart3Pattern = null;
			switch (yearPosition)
			{
			case 1:
				datePart1Pattern = decimal1To4Pattern;
				datePart2Pattern = decimal1to2Pattern;
				datePart3Pattern = decimal1to2Pattern;
				break;

			case 2:
				datePart1Pattern = decimal1to2Pattern;
				datePart2Pattern = decimal1To4Pattern;
				datePart3Pattern = decimal1to2Pattern;
				break;

			case 3:
				datePart1Pattern = decimal1to2Pattern;
				datePart2Pattern = decimal1to2Pattern;
				datePart3Pattern = decimal1To4Pattern;
				break;
			}

			// Die Muster für das volle Datum, die volle lange und die
			// gesamte kurze Zeit festlegen
			string fullDatePattern = null;
			if (includeDate)
			{
				fullDatePattern = datePart1GroupStart + datePart1Pattern + closingBracket + dateSeparatorPattern +
					datePart2GroupStart + datePart2Pattern + closingBracket + dateSeparatorPattern + datePart3GroupStart +
					datePart3Pattern + closingBracket + dateFormatInfo.DateSuffixPattern;
			}
			string shortTimePattern = timePart1Pattern + timeSeparatorPattern + timePart2Pattern;
			string fullTimePattern = shortTimePattern + timeSeparatorPattern + timePart3Pattern;
			string dateTimeSeparatorPattern = (includeDate ? dateFormatInfo.DateTimeSeparatorPattern : null);

			// Das Muster für den regulären Ausdruck festlegen
			StringBuilder patternBuilder = new StringBuilder();
			patternBuilder.Append(@"^(?:");
			if (includeDate)
			{
				patternBuilder.Append(datePart1GroupStart);
				patternBuilder.Append(datePart1Pattern);
				patternBuilder.Append(closingBracketWithSlash);
				patternBuilder.Append(nonRecordingGroupStart);
				patternBuilder.Append(datePart1GroupStart);
				patternBuilder.Append(datePart1Pattern);
				patternBuilder.Append(closingBracket);
				patternBuilder.Append(dateSeparatorPattern);
				patternBuilder.Append(closingBracketWithSlash);
				patternBuilder.Append(nonRecordingGroupStart);
				patternBuilder.Append(datePart1GroupStart);
				patternBuilder.Append(datePart1Pattern);
				patternBuilder.Append(closingBracket);
				patternBuilder.Append(dateSeparatorPattern);
				patternBuilder.Append(datePart2GroupStart);
				patternBuilder.Append(datePart2Pattern);
				patternBuilder.Append(doubleClosingBracketWithSlash);
				patternBuilder.Append(nonRecordingGroupStart);
				patternBuilder.Append(datePart1GroupStart);
				patternBuilder.Append(datePart1Pattern);
				patternBuilder.Append(closingBracket);
				patternBuilder.Append(dateSeparatorPattern);
				patternBuilder.Append(datePart2GroupStart);
				patternBuilder.Append(datePart2Pattern);
				patternBuilder.Append(closingBracket);
				patternBuilder.Append(dateSeparatorPattern);
				patternBuilder.Append(closingBracketWithSlash);
				if (dateFormatInfo.DateSuffixPattern != null)
				{
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(datePart1GroupStart);
					patternBuilder.Append(datePart1Pattern);
					patternBuilder.Append(closingBracket);
					patternBuilder.Append(dateSeparatorPattern);
					patternBuilder.Append(datePart2GroupStart);
					patternBuilder.Append(datePart2Pattern);
					patternBuilder.Append(closingBracket);
					patternBuilder.Append(dateSeparatorPattern);
					patternBuilder.Append(datePart3GroupStart);
					patternBuilder.Append(datePart3Pattern);
					patternBuilder.Append(doubleClosingBracketWithSlash);
				}
				patternBuilder.Append(@nonRecordingGroupStart);
				patternBuilder.Append(fullDatePattern);
				patternBuilder.Append(closingBracket);
			}
			if (includeTime)
			{
				if (includeDate)
				{
					patternBuilder.Append(slash);
				}
				string leftAmPmPattern1 = null;
				string leftAmPmPattern2 = null;
				string rightAmPmPattern = null;
				string amPmPattern = null;
				if (dateFormatInfo.IsAmPmTime)
				{
					amPmPattern = null;
					if (string.IsNullOrEmpty(dateFormatInfo.AMString) == false)
					{
						string amPattern = null;
						foreach (char amChar in dateFormatInfo.AMString)
						{
							amPattern += amChar;
							if (amPmPattern != null)
							{
								amPmPattern += slash;
							}
							amPmPattern += nonRecordingGroupStart + amPattern + closingBracket;
						}
					}

					if (string.IsNullOrEmpty(dateFormatInfo.PMString) == false)
					{
						string pmPattern = null;
						foreach (char pmChar in dateFormatInfo.PMString)
						{
							pmPattern += pmChar;
							if (amPmPattern != null)
							{
								amPmPattern += slash;
							}
							amPmPattern += nonRecordingGroupStart + pmPattern + closingBracket;
						}
					}

					amPmPattern = nonRecordingGroupStart + amPmPattern + closingBracket;
				}

				switch (dateFormatInfo.AmPmType)
				{
				case DateTimeAmPmType.None:
					leftAmPmPattern1 = null;
					leftAmPmPattern2 = null;
					rightAmPmPattern = null;
					break;

				case DateTimeAmPmType.Left:
					leftAmPmPattern1 = amPmPattern;
					leftAmPmPattern2 = nonRecordingGroupStart + dateFormatInfo.AMString + slash + dateFormatInfo.PMString + closingBracket;
					rightAmPmPattern = null;
					break;

				case DateTimeAmPmType.Right:
					leftAmPmPattern1 = null;
					leftAmPmPattern2 = null;
					rightAmPmPattern = amPmPattern;
					break;
				}

				if (leftAmPmPattern1 != null)
				{
					string leftAmPmSeparator = (includeDate ? dateFormatInfo.AmPmSeparator : null);
					string rightAmPmSeparator = dateFormatInfo.AmPmSeparator;
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(leftAmPmSeparator);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(leftAmPmSeparator);
					patternBuilder.Append(leftAmPmPattern1);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(timePart1Pattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(timePart1Pattern);
					patternBuilder.Append(timeSeparatorPattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(shortTimePattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(shortTimePattern);
					patternBuilder.Append(timeSeparatorPattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(fullTimePattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(leftAmPmSeparator);
					patternBuilder.Append(leftAmPmPattern2);
					patternBuilder.Append(rightAmPmSeparator);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(leftAmPmSeparator);
					patternBuilder.Append(leftAmPmPattern2);
					patternBuilder.Append(rightAmPmSeparator);
					patternBuilder.Append(timePart1Pattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(leftAmPmSeparator);
					patternBuilder.Append(leftAmPmPattern2);
					patternBuilder.Append(rightAmPmSeparator);
					patternBuilder.Append(timePart1Pattern);
					patternBuilder.Append(timeSeparatorPattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(leftAmPmSeparator);
					patternBuilder.Append(leftAmPmPattern2);
					patternBuilder.Append(rightAmPmSeparator);
					patternBuilder.Append(shortTimePattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(leftAmPmSeparator);
					patternBuilder.Append(leftAmPmPattern2);
					patternBuilder.Append(rightAmPmSeparator);
					patternBuilder.Append(shortTimePattern);
					patternBuilder.Append(timeSeparatorPattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(leftAmPmSeparator);
					patternBuilder.Append(leftAmPmPattern2);
					patternBuilder.Append(rightAmPmSeparator);
					patternBuilder.Append(fullTimePattern);
					patternBuilder.Append(@closingBracket);
				}
				else
				{
					if (includeDate)
					{
						patternBuilder.Append(nonRecordingGroupStart);
						patternBuilder.Append(fullDatePattern);
						patternBuilder.Append(dateTimeSeparatorPattern);
						patternBuilder.Append(closingBracketWithSlash);
					}
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(timePart1Pattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(timePart1Pattern);
					patternBuilder.Append(timeSeparatorPattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(shortTimePattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(shortTimePattern);
					patternBuilder.Append(timeSeparatorPattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(fullTimePattern);
					patternBuilder.Append(@closingBracket);
				}

				if (rightAmPmPattern != null)
				{
					patternBuilder.Append(slash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(shortTimePattern);
					patternBuilder.Append(dateFormatInfo.AmPmSeparator);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(shortTimePattern);
					patternBuilder.Append(dateFormatInfo.AmPmSeparator);
					patternBuilder.Append(rightAmPmPattern);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(fullTimePattern);
					patternBuilder.Append(dateFormatInfo.AmPmSeparator);
					patternBuilder.Append(closingBracketWithSlash);
					patternBuilder.Append(nonRecordingGroupStart);
					patternBuilder.Append(fullDatePattern);
					patternBuilder.Append(dateTimeSeparatorPattern);
					patternBuilder.Append(fullTimePattern);
					patternBuilder.Append(dateFormatInfo.AmPmSeparator);
					patternBuilder.Append(rightAmPmPattern);
					patternBuilder.Append(closingBracket);
				}
			}
			patternBuilder.Append(")$");

			// Den regulären Ausdruck ausführen
			string pattern = patternBuilder.ToString();
			Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);

			// Das Ergebnis auswerten
			if (match.Success)
			{
				bool valid = (includeDate || includeTime ? true : false);

				// Ermitteln der eingegebenen Datumsteile
				if (includeDate)
				{
					int day = -1;
					int month = -1;
					int year = -1;
					if (match.Groups["d1"].Value.Length > 0) // 31
					{
						if (dayPosition == 1)
						{
							day = Convert.ToInt32(match.Groups["d1"].ToString());
						}
						else if (monthPosition == 1)
						{
							month = Convert.ToInt32(match.Groups["d1"].ToString());
						}
						else
						{
							year = Convert.ToInt32(match.Groups["d1"].ToString());
						}
					}
					if (match.Groups["d2"].Value.Length > 0) // 31.12.
					{
						if (dayPosition == 2)
						{
							day = Convert.ToInt32(match.Groups["d2"].ToString());
						}
						else if (monthPosition == 2)
						{
							month = Convert.ToInt32(match.Groups["d2"].ToString());
						}
						else
						{
							year = Convert.ToInt32(match.Groups["d2"].ToString());
						}
					}
					if (match.Groups["d3"].Value.Length > 0) // 31.12.2010
					{
						if (dayPosition == 3)
						{
							day = Convert.ToInt32(match.Groups["d3"].ToString());
						}
						else if (monthPosition == 3)
						{
							month = Convert.ToInt32(match.Groups["d3"].ToString());
						}
						else
						{
							year = Convert.ToInt32(match.Groups["d3"].ToString());
						}
					}

					// Ermitteln, ob das Datum valide ist;
					valid &=
						(day == -1 || (day >= minDay && day <= maxDay)) &&
						(month == -1 || (month >= minMonth && month <= maxMonth)) &&
						(year == -1 || (year >= minYear && year <= maxYear));
				}

				if (includeTime)
				{
					// Den Zeitanteil auswerten
					if (match.Groups["t1"].Value.Length > 0) // 31.12.2010 23:
					{
						int hour = Convert.ToInt32(match.Groups["t1"].ToString());
						valid &= (hour >= minHour && hour <= maxHour);
					}
					if (match.Groups["t2"].Value.Length > 0) // 31.12.2010 23:59
					{
						int minute = Convert.ToInt32(match.Groups["t2"].ToString());
						valid &= (minute >= minMinute && minute <= maxMinute);
					}
					if (match.Groups["t3"].Value.Length > 0) // 31.12.2010 23:59:59
					{
						int second = Convert.ToInt32(match.Groups["t3"].ToString());
						valid &= (second >= minSecond && second <= maxSecond);
					}
				}

				return valid;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Überprüft eine Eingabe daraufhin, ob diese bezogen auf die übergebene Kultur potenziell 
		/// eine gültige Zeit ergeben kann
		/// </summary>
		/// <param name="input">Die Eingabe</param>
		/// <param name="culture">Die Kultur, für die das Datum überprüft werden soll</param>
		/// <returns>Gibt true zurück wenn die Eingabe potenziell eine Zeit ergeben kann</returns>
		public bool IsPotentialTime(string input, CultureInfo culture)
		{
			return IsPotentialDateTime(input, false, true, false, culture);
		}

		/// <summary>
		/// Überprüft eine Eingabe daraufhin, ob diese bezogen auf die aktuelle Kultur potenziell 
		/// eine gültige Zeit ergeben kann
		/// </summary>
		/// <param name="input">Die Eingabe</param>
		/// <returns>Gibt true zurück wenn die Eingabe potenziell eine Zeit ergeben kann</returns>
		public bool IsPotentialTime(string input)
		{
			return IsPotentialDateTime(input, false, true, false);
		}

		/// <summary>
		/// Überprüft eine Eingabe daraufhin, ob diese bezogen auf die übergebene Kultur potenziell 
		/// ein gültiges Datum (ohne Zeit) ergeben kann
		/// </summary>
		/// <param name="input">Die Eingabe</param>
		/// <param name="allowZeroForDayAndMonth">Gibt an, ob die Eingabe eine 0 für den Tag und den Monat erlaubt ist</param>
		/// <param name="culture">Die Kultur, für die das Datum überprüft werden soll</param>
		/// <returns>Gibt true zurück wenn die Eingabe potenziell ein Datumt ergeben kann</returns>
		public bool IsPotentialDate(string input, bool allowZeroForDayAndMonth, CultureInfo culture)
		{
			return IsPotentialDateTime(input, true, false, allowZeroForDayAndMonth, culture);
		}

		/// <summary>
		/// Überprüft eine Eingabe daraufhin, ob diese bezogen auf die aktuelle Kultur potenziell 
		/// ein gültiges Datum (ohne Zeit) ergeben kann
		/// </summary>
		/// <param name="input">Die Eingabe</param>
		/// <param name="allowZeroForDayAndMonth">Gibt an, ob die Eingabe eine 0 für den Tag und den Monat erlaubt ist</param>
		/// <returns>Gibt true zurück wenn die Eingabe potenziell ein Datum ergeben kann</returns>
		public bool IsPotentialDate(string input, bool allowZeroForDayAndMonth)
		{
			return IsPotentialDateTime(input, true, false, allowZeroForDayAndMonth);
		}
	}
}

