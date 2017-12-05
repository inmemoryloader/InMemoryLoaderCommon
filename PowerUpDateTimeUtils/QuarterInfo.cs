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
        readonly int quarter;

        /// <summary>
        /// Das Quartal
        /// </summary>
        public int Quarter {
            get { return quarter; }
        }

        readonly int year;

        /// <summary>
        /// Das Jahr
        /// </summary>
        public int Year {
            get { return year; }
        }

        readonly DateTime startDate;

        /// <summary>
        /// Das Startdatum des Quartals
        /// </summary>
        public DateTime StartDate {
            get { return startDate; }
        }

        readonly DateTime endDate;

        /// <summary>
        /// Das Enddatum des Quartals
        /// </summary>
        public DateTime EndDate {
            get { return endDate; }
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
            if (quarter >= 1 && quarter <= 4 && year >= 0 && year <= 9999) {
                // Quartal und Jahr übergeben
                quarter = paramQuarter;
                year = paramYear;

                // Ersten Tag im Quartal berechnen
                startDate = new DateTime (year, (quarter * 3) - 2, 1);

                // Letzten Tag im Quartal berechnen
                endDate = startDate.AddMonths (3).AddDays (-1);
            } else {
                throw new ArgumentException ("Das Quartal muss eine Zahl zwischen 1 und 4 und das Jahr eine Zahl zwischen 0 und 9999 sein");
            }
        }

    }

}