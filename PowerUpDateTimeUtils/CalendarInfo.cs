//
// CalendarInfo.cs
//
// Author: responsive kaysta
//
// Copyright (c) 2017 responsive kaysta
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;

namespace PowerUpDateTimeUtils
{
    /// <summary>
    /// Liefert Informationen zu Kalendern, die diese leider nicht 
    /// direkt zur Verfügung stellen
    /// </summary>
    public class CalendarInfo
	{

		#region Öffentliche Felder

		/// <summary>
		/// Der Basis-Kalender
		/// </summary>
		public readonly Calendar Calendar;

		/// <summary>
		/// Referenziert eine Kultur, die diesen Kalender verwendet (bzw. verwendet hat)
		/// </summary>
		public readonly CultureInfo SampleCulture;

		/// <summary>
		/// Der Name des Kalenders
		/// </summary>
		public readonly string CalendarName;

		/// <summary>
		/// Der Name des Algorithmus-Typs, auf dem der Kalender basiert
		/// </summary>
		public readonly string AlgorithmTypeName;

		/// <summary>
		/// Gibt an, wie viele Tage ein Monat minimal besitzt
		/// </summary>
		public readonly int MonthInYearMin;

		/// <summary>
		/// Gibt an, wie viele Tage ein Monat maximal besitzt
		/// </summary>
		public readonly int MonthInYearMax;

		/// <summary>
		/// Gibt an, wie viele Tage ein Monat minimal besitzt
		/// </summary>
		public readonly int DaysInMonthMin;

		/// <summary>
		/// Gibt an, wie viele Tage ein Monat maximal besitzt
		/// </summary>
		public readonly int DaysInMonthMax;

		/// <summary>
		/// Gibt die Schaltmonate an falls solche existieren
		/// </summary>
		public readonly ReadOnlyCollection<LeapMonthInfo> LeapMonths;

		#endregion

		#region Konstruktor

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="paramCalendar">Der Kalender</param>
		public CalendarInfo(Calendar paramCalendar)
		{
			// Kalender übergeben
			Calendar = paramCalendar;

			// Den Kalendernamen und die Beispielkultur ermitteln
			if (paramCalendar is ChineseLunisolarCalendar)
			{
				CalendarName = "Chinese Lunisolar";
				SampleCulture = CultureInfo.GetCultureInfo("zh-CN");
			}
			else if (paramCalendar is GregorianCalendar)
			{
				CalendarName = "Gregorian";
				SampleCulture = CultureInfo.GetCultureInfo("en-US");
			}
			else if (paramCalendar is HebrewCalendar)
			{
				CalendarName = "Hebrew";
				SampleCulture = CultureInfo.GetCultureInfo("he-IL");
			}
			else if (paramCalendar is HijriCalendar)
			{
				CalendarName = "Hijri";
				SampleCulture = CultureInfo.GetCultureInfo("ar-SA");
			}
			else if (paramCalendar is JapaneseCalendar)
			{
				CalendarName = "Japanese";
				SampleCulture = CultureInfo.GetCultureInfo("ja-JP");
			}
			else if (paramCalendar is JapaneseLunisolarCalendar)
			{
				CalendarName = "Japanese Lunisolar";
				SampleCulture = CultureInfo.GetCultureInfo("ja-JP");
			}
			else if (paramCalendar is JulianCalendar)
			{
				CalendarName = "Julian";
				SampleCulture = CultureInfo.GetCultureInfo("en-US");
			}
			else if (paramCalendar is KoreanCalendar)
			{
				CalendarName = "Korean";
				SampleCulture = CultureInfo.GetCultureInfo("ko-KR");
			}
			else if (paramCalendar is KoreanLunisolarCalendar)
			{
				CalendarName = "Korean Lunisolar";
				SampleCulture = CultureInfo.GetCultureInfo("ko-KR");
			}
			else if (paramCalendar is PersianCalendar)
			{
				CalendarName = "Persian";
				SampleCulture = CultureInfo.GetCultureInfo("fa-IR");
			}
			else if (paramCalendar is TaiwanCalendar)
			{
				CalendarName = "Taiwan";
				SampleCulture = CultureInfo.GetCultureInfo("zh-TW");
			}
			else if (paramCalendar is TaiwanLunisolarCalendar)
			{
				CalendarName = "Taiwan Lunisolar";
				SampleCulture = CultureInfo.GetCultureInfo("zh-TW");
			}
			else if (paramCalendar is ThaiBuddhistCalendar)
			{
				CalendarName = "Thai Buddhist";
				SampleCulture = CultureInfo.GetCultureInfo("th-TH");
			}
			else if (paramCalendar is UmAlQuraCalendar)
			{
				CalendarName = "Um Al Qura";
				SampleCulture = CultureInfo.GetCultureInfo("ar-SA");
			}
			else
			{
				SampleCulture = CultureInfo.InvariantCulture;
				CalendarName = "Unknown";
			}

			// Den Algorithmustyp-Namen ermitteln
			switch (paramCalendar.AlgorithmType)
			{
			case CalendarAlgorithmType.LunarCalendar:
				AlgorithmTypeName = "Lunar";
				break;
			case CalendarAlgorithmType.LunisolarCalendar:
				AlgorithmTypeName = "Lunisolar";
				break;
			case CalendarAlgorithmType.SolarCalendar:
				AlgorithmTypeName = "Solar";
				break;
			case CalendarAlgorithmType.Unknown:
				AlgorithmTypeName = "Unknown";
				break;
			}

			// Ermitteln der minimalen und maximalen Anzahl der Monate im Jahr
			MonthInYearMin = int.MaxValue;
			MonthInYearMax = 0;
			DateTime date = paramCalendar.MinSupportedDateTime;
			while (date < paramCalendar.MaxSupportedDateTime)
			{
				// Die Anzahl der Monate im Jahr ermitteln
				int calendarYear = paramCalendar.GetYear(date);
				try
				{
					int monthsInYear = paramCalendar.GetMonthsInYear(calendarYear);
					if (monthsInYear == 0)
					{
						Debugger.Break();
					}
					MonthInYearMin = Math.Min(MonthInYearMin, monthsInYear);
					MonthInYearMax = Math.Max(MonthInYearMax, monthsInYear);
				}
				catch (ArgumentOutOfRangeException)
				{
					// HACK: Der Japanese-Lunisolar-Kalender erzeugt bei Jahren ab
					// 62 (Gregorianisches Jahr 1988) eine ArgumentOutOfRangeException
					// bei Aufruf von GetMonthsInYear, obwohl GetYear dieses Jahr
					// selbst zurückgegeben hat!?
					break;
				}

				// Das Datum um ein (gregorianisches) Jahr erhöhen
				try
				{
					date = date.AddYears(1);
				}
				catch
				{
					break;
				}
			}

			// Die minimale und maximale Anzahl der Tage 
			// für die Monate des Kalenders ermitteln
			date = paramCalendar.MinSupportedDateTime;
			DaysInMonthMin = int.MaxValue;
			DaysInMonthMax = 0;
			while (date < paramCalendar.MaxSupportedDateTime)
			{
				// Die Anzahl der Tage im Monat
				int calendarYear = paramCalendar.GetYear(date);
				int calendarMonth = paramCalendar.GetMonth(date);
				try
				{
					int daysInMonth = paramCalendar.GetDaysInMonth(calendarYear, calendarMonth);
					DaysInMonthMin = Math.Min(DaysInMonthMin, daysInMonth);
					DaysInMonthMax = Math.Max(DaysInMonthMax, daysInMonth);
				}
				catch (ArgumentOutOfRangeException)
				{
					// HACK: GetDaysInMonth liefert zumindest beim 
					// Japanese-Lunisolar-Kalender eine ArgumentOutOfRangeException 
					// wenn der Monat 13 angegeben wird, obwohl GetMonth diesen Monat selbst
					// zurückgegeban hat!?
					// Das Datum um einen (gregorianischen) Monat erhöhen
					try
					{
						date = date.AddMonths(1);
					}
					catch
					{
						break;
					}
					continue;
				}

				// Das Datum um einen (gregorianischen) Monat erhöhen
				try
				{
					date = date.AddMonths(1);
				}
				catch
				{
					break;
				}
			}

			// Ermitteln der Schaltmonate
			List<LeapMonthInfo> leapMonths = new List<LeapMonthInfo>();
			date = paramCalendar.MinSupportedDateTime;
			while (date < paramCalendar.MaxSupportedDateTime)
			{
				int calendarYear = paramCalendar.GetYear(date);
				try
				{
					int leapMonthCount = paramCalendar.GetLeapMonth(calendarYear);
					if (leapMonthCount > 0)
					{
						leapMonths.Add(new LeapMonthInfo() { LeapMonthCount = leapMonthCount, GregorianYear = date.Year });
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					// HACK: Der Japanese-Lunisolar-Kalender erzeugt bei Jahren ab
					// 62 (Gregorianisches Jahr 1988) eine ArgumentOutOfRangeException
					// bei Aufruf von GetLeapMonth, obwohl GetYear dieses Jahr
					// selbst zurückgegeben hat!?
					break;
				}

				// Das Datum um ein (gregorianisches) Jahr erhöhen
				try
				{
					date = date.AddYears(1);
				}
				catch
				{
					break;
				}
			}

			LeapMonths = new ReadOnlyCollection<LeapMonthInfo>(leapMonths);
		}

		#endregion

		#region Instanzmethoden

		/// <summary>
		/// Liefert ein Datum als String in der Form des Kalenders
		/// </summary>
		/// <param name="date">Das Datum</param>
		public string GetCalendarDateString(DateTime date)
		{
			return Calendar.GetDayOfMonth(DateTime.Now) + "." + Calendar.GetMonth(DateTime.Now) + "." + Calendar.GetYear(DateTime.Now);
		}

		#endregion

		#region Statische Methoden

		/// <summary>
		/// Liefert die System-Kalender
		/// </summary>
		public static List<CalendarInfo> GetSystemCalendars()
		{
			List<CalendarInfo> calendarInfos = new List<CalendarInfo>();
			calendarInfos.Add(new CalendarInfo(new ChineseLunisolarCalendar()));
			calendarInfos.Add(new CalendarInfo(new GregorianCalendar()));
			calendarInfos.Add(new CalendarInfo(new HebrewCalendar()));
			calendarInfos.Add(new CalendarInfo(new HijriCalendar()));
			calendarInfos.Add(new CalendarInfo(new JapaneseCalendar()));
			calendarInfos.Add(new CalendarInfo(new JapaneseLunisolarCalendar()));
			calendarInfos.Add(new CalendarInfo(new JulianCalendar()));
			calendarInfos.Add(new CalendarInfo(new KoreanCalendar()));
			calendarInfos.Add(new CalendarInfo(new KoreanLunisolarCalendar()));
			calendarInfos.Add(new CalendarInfo(new PersianCalendar()));
			calendarInfos.Add(new CalendarInfo(new ThaiBuddhistCalendar()));
			calendarInfos.Add(new CalendarInfo(new TaiwanCalendar()));
			calendarInfos.Add(new CalendarInfo(new TaiwanLunisolarCalendar()));
			calendarInfos.Add(new CalendarInfo(new UmAlQuraCalendar()));
			return calendarInfos;
		}

		#endregion

		#region Überschriebene Methoden

		/// <summary>
		/// Gibt den Namen des Kalenders zurück
		/// </summary>
		public override string ToString()
		{
			return CalendarName;
		}

		#endregion
	}
}

