//
// TestHelper.PowerUpDateTimeUtils.cs
//
// Author: responsive kaysta <>
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

namespace PowerUpDateTimeUtils
{
    public partial class DateTimeUtils : AbstractPowerUpComponent
    {
        /// <summary>
        /// Berechnet ein Alter in Jahren
        /// </summary>
        /// <param name="lowerDate">Das kleinere Datum</param>
        /// <param name="higherDate">Das größere Datum</param>
        /// <returns>Gibt das Alter in ganzen Jahren zurück</returns>
        public int GetAge (DateTime lowerDate, DateTime higherDate)
        {
            return GetAge (new DateTimeOffset (lowerDate), new DateTimeOffset (higherDate));
        }

        /// <summary>
        /// Berechnet ein Alter in Jahren
        /// </summary>
        /// <param name="lowerDate">Das kleinere Datum</param>
        /// <param name="higherDate">Das größere Datum</param>
        /// <returns>Gibt das Alter in ganzen Jahren zurück</returns>
        public int GetAge (DateTimeOffset lowerDate, DateTimeOffset higherDate)
        {
            // Basis-Alter als Differenz zwischen den Jahren ermitteln
            int age = higherDate.Year - lowerDate.Year;

            // Wenn der Monat des größeren Datums kleiner oder wenn der Monat gleich 
            // und der Tag kleiner ist, muss ein Jahr abgezogen werden
            if ((higherDate.Month < lowerDate.Month) || (higherDate.Month == lowerDate.Month && higherDate.Day < lowerDate.Day)) {
                age--;
            }

            return age;
        }
    }
}

