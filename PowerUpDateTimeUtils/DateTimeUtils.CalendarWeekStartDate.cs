//
// DateTimeUtils.CalendarWeekStartDate.cs
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
        /// Berechnet das Startdatum einer deutschen Kalenderwoche
        /// </summary>
        /// <param name="calendarWeek">Die Kalenderwoche</param>
        /// <param name="year">Das Jahr</param>
        /// <returns>Gibt das Datum zurück, an dem die Kalenderwoche beginnt</returns>
        public DateTime GetGermanCalendarWeekStartDate (int calendarWeek, int year)
        {
            // Datum für den 4.1. des Jahres ermitteln
            var baseDate = new DateTime (year, 1, 4);

            // Den Montag dieser Woche ermitteln
            int dayOfWeek = (int)baseDate.DayOfWeek;
            baseDate = dayOfWeek > 0 ? baseDate.AddDays ((dayOfWeek - 1) * -1) : baseDate.AddDays (-6);

            // Das Ergebnisdatum ermitteln
            return baseDate.AddDays ((calendarWeek - 1) * 7);
        }

        /// <summary>
        /// Berechnet das Startdatum einer internationalen Kalenderwoche
        /// </summary>
        /// <param name="calendarWeek">Die Kalenderwoche</param>
        /// <param name="year">Das Jahr</param>
        /// <returns>Gibt das Datum zurück, an dem die Kalenderwoche beginnt</returns>
        public DateTime GetCalendarWeekStartDate (int calendarWeek, int year)
        {
            // Basisdatum (1.1. des angegebenen Jahres) ermitteln
            var startDate = new DateTime (year, 1, 1);

            // Das Datum des ersten Wochentags dieser Woche ermitteln
            while (startDate.DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek) {
                startDate = startDate.AddDays (-1);
            }

            // Die Kalenderwoche ermitteln: Wenn es sich um die Woche 1 handelt,
            // ist dies das Basisdatum für die Berechnung, wenn nicht, müssen
            // sieben Tage aufaddiert werden
            var cw = GetCalendarWeek (startDate);
            if (cw.Week != 1) {
                startDate = startDate.AddDays (7);
            }

            // Das Ergebnisdatum ermitteln
            return startDate.AddDays ((calendarWeek - 1) * 7);
        }

    }

}