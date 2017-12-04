//
// DateTimeUtils.IsGermanHoliday.cs
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

namespace PowerUpDateTimeUtils
{
    public partial class DateTimeUtils : AbstractPowerUpComponent
    {
        /// <summary>
        /// Ermittelt, ob ein bestimmter Tag ein Feiertag ist
        /// </summary>
        /// <param name="paramDate">Das Datum des Tages</param>
        /// <param name="paramName">In diesem Argument gibt die Methode den Namen des Feiertags zurück, falls es sich um einen solchen handelt</param>
        /// <param name="paramIsNationWide">In diesem Argument gibt die Methode zurück, ob es sich um einen bundesweiten Feiertag handelt</param>
        /// <returns>Gibt true zurück wenn es sich bei dem übergebenen Datum um einen Feiertag handelt</returns>
        public GermanSpecialDay IsGermanHoliday(DateTime paramDate)
        {
            var specialDay = new GermanSpecialDay();

            // Auflistung der besonderen Tage des angegebenen Jahres erzeugen, 
            // durchgehen und das Datum der Feiertage mit dem angegebenen Datum
            // vergleichen
            foreach (GermanSpecialDay gsd in GetGermanSpecialDays(paramDate.Year).Values)
            {
                if (paramDate.Day == gsd.Date.Day && paramDate.Month == gsd.Date.Month)
                {
                    // Datum gefunden
                    if (gsd.IsHoliday)
                    {
                        specialDay.IsHoliday = true;
                        specialDay.IsNationwide = gsd.IsNationwide;
                        specialDay.Name = gsd.Name;
                        specialDay.Key = gsd.Key;
                        specialDay.Date = gsd.Date;
                    }
                    else
                    {
                        specialDay.IsHoliday = false;
                        specialDay.IsNationwide = gsd.IsNationwide;
                        specialDay.Name = gsd.Name;
                        specialDay.Key = gsd.Key;
                        specialDay.Date = gsd.Date;
                    }
                }
            }
            // Tag wurde nicht gefunden
            return specialDay;
        }

    }

}