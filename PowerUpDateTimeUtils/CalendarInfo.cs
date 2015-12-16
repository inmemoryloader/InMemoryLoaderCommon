using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
		/// <param name="calendar">Der Kalender</param>
		public CalendarInfo(Calendar calendar)
		{
			// Kalender übergeben
			this.Calendar = calendar;

			// Den Kalendernamen und die Beispielkultur ermitteln
			if (calendar is ChineseLunisolarCalendar)
			{
				this.CalendarName = "Chinese Lunisolar";
				this.SampleCulture = CultureInfo.GetCultureInfo("zh-CN");
			}
			else if (calendar is GregorianCalendar)
			{
				this.CalendarName = "Gregorian";
				this.SampleCulture = CultureInfo.GetCultureInfo("en-US");
			}
			else if (calendar is HebrewCalendar)
			{
				this.CalendarName = "Hebrew";
				this.SampleCulture = CultureInfo.GetCultureInfo("he-IL");
			}
			else if (calendar is HijriCalendar)
			{
				this.CalendarName = "Hijri";
				this.SampleCulture = CultureInfo.GetCultureInfo("ar-SA");
			}
			else if (calendar is JapaneseCalendar)
			{
				this.CalendarName = "Japanese";
				this.SampleCulture = CultureInfo.GetCultureInfo("ja-JP");
			}
			else if (calendar is JapaneseLunisolarCalendar)
			{
				this.CalendarName = "Japanese Lunisolar";
				this.SampleCulture = CultureInfo.GetCultureInfo("ja-JP");
			}
			else if (calendar is JulianCalendar)
			{
				this.CalendarName = "Julian";
				this.SampleCulture = CultureInfo.GetCultureInfo("en-US");
			}
			else if (calendar is KoreanCalendar)
			{
				this.CalendarName = "Korean";
				this.SampleCulture = CultureInfo.GetCultureInfo("ko-KR");
			}
			else if (calendar is KoreanLunisolarCalendar)
			{
				this.CalendarName = "Korean Lunisolar";
				this.SampleCulture = CultureInfo.GetCultureInfo("ko-KR");
			}
			else if (calendar is PersianCalendar)
			{
				this.CalendarName = "Persian";
				this.SampleCulture = CultureInfo.GetCultureInfo("fa-IR");
			}
			else if (calendar is TaiwanCalendar)
			{
				this.CalendarName = "Taiwan";
				this.SampleCulture = CultureInfo.GetCultureInfo("zh-TW");
			}
			else if (calendar is TaiwanLunisolarCalendar)
			{
				this.CalendarName = "Taiwan Lunisolar";
				this.SampleCulture = CultureInfo.GetCultureInfo("zh-TW");
			}
			else if (calendar is ThaiBuddhistCalendar)
			{
				this.CalendarName = "Thai Buddhist";
				this.SampleCulture = CultureInfo.GetCultureInfo("th-TH");
			}
			else if (calendar is UmAlQuraCalendar)
			{
				this.CalendarName = "Um Al Qura";
				this.SampleCulture = CultureInfo.GetCultureInfo("ar-SA");
			}
			else
			{
				this.SampleCulture = CultureInfo.InvariantCulture;
				this.CalendarName = "Unknown";
			}

			// Den Algorithmustyp-Namen ermitteln
			switch (calendar.AlgorithmType)
			{
			case CalendarAlgorithmType.LunarCalendar:
				this.AlgorithmTypeName = "Lunar";
				break;
			case CalendarAlgorithmType.LunisolarCalendar:
				this.AlgorithmTypeName = "Lunisolar";
				break;
			case CalendarAlgorithmType.SolarCalendar:
				this.AlgorithmTypeName = "Solar";
				break;
			case CalendarAlgorithmType.Unknown:
				this.AlgorithmTypeName = "Unknown";
				break;
			}

			// Ermitteln der minimalen und maximalen Anzahl der Monate im Jahr
			this.MonthInYearMin = int.MaxValue;
			this.MonthInYearMax = 0;
			DateTime date = calendar.MinSupportedDateTime;
			while (date < calendar.MaxSupportedDateTime)
			{
				// Die Anzahl der Monate im Jahr ermitteln
				int calendarYear = calendar.GetYear(date);
				try
				{
					int monthsInYear = calendar.GetMonthsInYear(calendarYear);
					if (monthsInYear == 0)
					{
						Debugger.Break();
					}
					this.MonthInYearMin = Math.Min(this.MonthInYearMin, monthsInYear);
					this.MonthInYearMax = Math.Max(this.MonthInYearMax, monthsInYear);
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
			date = calendar.MinSupportedDateTime;
			this.DaysInMonthMin = int.MaxValue;
			this.DaysInMonthMax = 0;
			while (date < calendar.MaxSupportedDateTime)
			{
				// Die Anzahl der Tage im Monat
				int calendarYear = calendar.GetYear(date);
				int calendarMonth = calendar.GetMonth(date);
				try
				{
					int daysInMonth = calendar.GetDaysInMonth(calendarYear, calendarMonth);
					this.DaysInMonthMin = Math.Min(this.DaysInMonthMin, daysInMonth);
					this.DaysInMonthMax = Math.Max(this.DaysInMonthMax, daysInMonth);
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
			date = calendar.MinSupportedDateTime;
			while (date < calendar.MaxSupportedDateTime)
			{
				int calendarYear = calendar.GetYear(date);
				try
				{
					int leapMonthCount = calendar.GetLeapMonth(calendarYear);
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

			this.LeapMonths = new ReadOnlyCollection<LeapMonthInfo>(leapMonths);
		}

		#endregion

		#region Instanzmethoden

		/// <summary>
		/// Liefert ein Datum als String in der Form des Kalenders
		/// </summary>
		/// <param name="date">Das Datum</param>
		public string GetCalendarDateString(DateTime date)
		{
			return this.Calendar.GetDayOfMonth(DateTime.Now) + "." +
				this.Calendar.GetMonth(DateTime.Now) + "." +
				this.Calendar.GetYear(DateTime.Now);
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
			return this.CalendarName;
		}

		#endregion
	}
}

