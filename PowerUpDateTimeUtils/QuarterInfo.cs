//
// QuarterInfo.cs
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
    /// Verwaltet Informationen zu einem Quartal
    /// </summary>
    public class QuarterInfo
    {
        readonly int _quarter;

        /// <summary>
        /// Das Quartal
        /// </summary>
        public int Quarter {
            get { return _quarter; }
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
        /// Das Startdatum des Quartals
        /// </summary>
        public DateTime StartDate {
            get { return _startDate; }
        }

        readonly DateTime _endDate;

        /// <summary>
        /// Das Enddatum des Quartals
        /// </summary>
        public DateTime EndDate {
            get { return _endDate; }
        }

        /// <summary>
        /// Konstruktor. Berechnet das Start- und das
        /// Enddatum des übergebenen Quartals.
        /// </summary>
        /// <param name="paramQuarter">Das Quartal</param>
        /// <param name="paramYear">Das Jahr</param>
        public QuarterInfo (int paramQuarter, int paramYear)
        {
            // Das übergebene Quartal und das Jahr überprüfen
            if (_quarter >= 1 && _quarter <= 4 && _year >= 0 && _year <= 9999) {
                // Quartal und Jahr übergeben
                _quarter = paramQuarter;
                _year = paramYear;

                // Ersten Tag im Quartal berechnen
                _startDate = new DateTime (_year, (_quarter * 3) - 2, 1);

                // Letzten Tag im Quartal berechnen
                _endDate = _startDate.AddMonths (3).AddDays (-1);
            } else {
                throw new ArgumentException ("Das Quartal muss eine Zahl zwischen 1 und 4 und das Jahr eine Zahl zwischen 0 und 9999 sein");
            }
        }

    }

}