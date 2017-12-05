//
// GermanSpecialDays.cs
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

namespace PowerUpDateTimeUtils
{
    /// <summary>
    /// Auflistung zur Verwaltung der speziellen Tage in Deutschland
    /// </summary>
    public class GermanSpecialDays : Dictionary<GermanSpecialDayKey,  GermanSpecialDay>
    {
        readonly int year;

        /// <summary>
        /// Gibt das Jahr zurück, für das diese speziellen Tage gelten
        /// </summary>
        public int Year {
            get { return year; }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="paramYear">Das Jahr</param>
        internal GermanSpecialDays (int paramYear)
        {
            year = paramYear;
        }

        /// <summary>
        /// Fügt der Auflistung ein neues GermanSpecialDay-Objekt hinzu
        /// </summary>
        /// <param name="paramKey">Der Konstanten-Wert des hinzuzufügenden Tags</param>
        /// <param name="paramName">Der Name des Tags</param>
        /// <param name="paramDate">Das Datum des Tags</param>
        /// <param name="paramNationWide">Gibt an, ob der spezielle Tag bundesweit gilt</param>
        /// <param name="paramHoliday">Gibt an, ob der spezielle Tag ein Feiertag ist</param>
        internal void Add (GermanSpecialDayKey paramKey, string paramName, DateTime paramDate, bool paramNationWide, bool paramHoliday)
        {
            base.Add (paramKey, new GermanSpecialDay (paramKey, paramName, paramDate, paramNationWide, paramHoliday));
        }
    }
}

