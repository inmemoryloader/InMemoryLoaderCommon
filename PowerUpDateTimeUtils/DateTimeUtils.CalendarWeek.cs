//
// DateTimeUtils.CalendarWeek.cs
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
using InMemoryLoaderBase;
using System.Globalization;

namespace PowerUpDateTimeUtils
{
    public partial class DateTimeUtils : AbstractPowerUpComponent
    {
        /// <summary>
        /// Berechnet die Kalenderwoche eines internationalen Datums
        /// </summary>
        /// <param name="date">Das Datum</param>
        /// <returns>Gibt ein CalendarWeek-Objekt zurück</returns>
        /// <remarks>
        /// Diese Methode berechnet die Kalenderwoche eines Datums
        /// nach der GetWeekOfYear-Methode eines Calendar-Objekts
        /// und korrigiert den darin enthaltenen Fehler.
        /// </remarks>
        public CalendarWeek GetCalendarWeek (DateTime date)
        {
            // Aktuelle Kultur ermitteln
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            // Aktuellen Kalender ermitteln
            Calendar calendar = currentCulture.Calendar;

            // Kalenderwoche über das Calendar-Objekt ermitteln
            int calendarWeek = calendar.GetWeekOfYear (date, currentCulture.DateTimeFormat.CalendarWeekRule, currentCulture.DateTimeFormat.FirstDayOfWeek);

            // Überprüfen, ob eine Kalenderwoche größer als 52
            // ermittelt wurde und ob die Kalenderwoche des Datums
            // in einer Woche 2 ergibt: In diesem Fall hat
            // GetWeekOfYear die Kalenderwoche nicht nach ISO 8601 
            // berechnet (Montag, der 31.12.2007 wird z. B.
            // fälschlicherweise als KW 53 berechnet). 
            // Die Kalenderwoche wird dann auf 1 gesetzt
            if (calendarWeek > 52) {
                date = date.AddDays (7);
                int testCalendarWeek = calendar.GetWeekOfYear (date, currentCulture.DateTimeFormat.CalendarWeekRule, currentCulture.DateTimeFormat.FirstDayOfWeek);
                if (testCalendarWeek == 2) {
                    calendarWeek = 1;
                }
            }

            // Das Jahr der Kalenderwoche ermitteln
            int year = date.Year;
            if (calendarWeek == 1 && date.Month == 12) {
                year++;
            }
            if (calendarWeek >= 52 && date.Month == 1) {
                year--;
            }
            // Die ermittelte Kalenderwoche zurückgeben
            return new CalendarWeek (year, calendarWeek);
        }

        /// <summary>
        /// Berechnet die Kalenderwoche eines deutschen Datums
        /// </summary>
        /// <param name="date">Das Datum</param>
        /// <returns>Gibt ein CalendarWeek-Objekt zurück</returns>
        /// <remarks>
        /// <para>
        /// Diese Methode gilt nur für die deutsche Kultur.
        /// Sie ist wesentlich schneller als die Methode
        /// <see cref="GetCalendarWeek"/>.
        /// </para>
        /// <para>
        /// Die Berechnung erfolgt nach dem 
        /// C++-Algorithmus von Ekkehard Hess aus einem Beitrag vom
        /// 29.7.1999 in der Newsgroup 
        /// borland.public.cppbuilder.language
        ///(freigegeben zur allgemeinen Verwendung)
        /// </para>
        /// </remarks>
        public CalendarWeek GetGermanCalendarWeek (DateTime date)
        {
            double a = Math.Floor ((14 - (date.Month)) / 12D);
            double y = date.Year + 4800 - a;
            double m = (date.Month) + (12 * a) - 3;

            double jd = date.Day + Math.Floor (((153 * m) + 2) / 5) + (365 * y) + Math.Floor (y / 4) - Math.Floor (y / 100) + Math.Floor (y / 400) - 32045;

            double d4 = (jd + 31741 - (jd % 7)) % 146097 % 36524 % 1461;
            double L = Math.Floor (d4 / 1460);
            double d1 = ((d4 - L) % 365) + L;

            // Kalenderwoche ermitteln
            int calendarWeek = (int)Math.Floor (d1 / 7) + 1;

            // Das Jahr der Kalenderwoche ermitteln
            int year = date.Year;
            if (calendarWeek == 1 && date.Month == 12) {
                year++;
            }
            if (calendarWeek >= 52 && date.Month == 1) {
                year--;
            }
            // Die ermittelte Kalenderwoche zurückgeben
            return new CalendarWeek (year, calendarWeek);
        }
    }
}

