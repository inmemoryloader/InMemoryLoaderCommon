//
// MonthInfo.cs
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

namespace PowerUpDateTimeUtils
{
    /// <summary>
    /// Verwaltet Informationen zu einem Monat
    /// </summary>
    public class MonthInfo
    {
        readonly int _month;

        /// <summary>
        /// Das Quartal
        /// </summary>
        public int Month {
            get { return _month; }
        }

        readonly int _year;

        /// <summary>
        /// Das Jahr
        /// </summary>
        public int Year {
            get { return _year; }
        }

        readonly DateTime _startDate;

        /// <summary>
        /// Das Startdatum des Monats
        /// </summary>
        public DateTime StartDate {
            get { return _startDate; }
        }

        readonly DateTime _endDate;

        /// <summary>
        /// Das Enddatum des Monats
        /// </summary>
        public DateTime EndDate {
            get { return _endDate; }
        }

        /// <summary>
        /// Konstruktor. Berechnet das Start- und das
        /// Enddatum des übergebenen Monate.
        /// </summary>
        /// <param name="paramMonth">Der Monat</param>
        /// <param name="paramYear">Das Jahr</param>
        public MonthInfo (int paramMonth, int paramYear)
        {
            // Die Argumente überprüfen
            if (_month < 1 || _month > 12 || _year < 0 || _year > 9999) {
                throw new ArgumentException ("Der Monat muss ein Wert zwischen 1 und 12 " + "und das Jahr muss ein Wert zwischen 0 und 9999 sein");
            }

            // Argumente übergeben
            _month = paramMonth;
            _year = paramYear;

            // Den ersten Tag des Monats ermitteln
            _startDate = new DateTime (_year, _month, 1);

            // Den letzten Tag des Monats ermitteln
            if (_month == 12) {
                _month = 1;
                _year++;
            } else {
                _month++;
            }
            _endDate = new DateTime (_year, _month, 1).AddDays (-1);
        }

    }

}