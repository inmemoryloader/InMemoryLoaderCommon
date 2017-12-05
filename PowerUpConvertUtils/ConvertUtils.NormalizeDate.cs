//
// ConvertUtils.NormalizeDate.cs
//
// Author: Kay Stuckenschmidt <mailto.kaysta@gmail.com>
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
using System.Globalization;
using InMemoryLoaderBase;

namespace PowerUpConvertUtils
{
    public partial class ConvertUtils : AbstractPowerUpComponent
    {
        /// <summary>
        /// Normalisiert ein Datum
        /// </summary>
        /// <param name="dateString">Das zu normalisierende Datum</param>
        /// <returns>Gibt das normalisierte Datum zurück</returns>
        public DateTime NormalizeDate(string dateString)
        {
            // Whitespaces entfernen
            dateString = dateString.Trim();

            // Versuch das Datum direkt zu konvertieren
            try
            {
                return DateTime.Parse(dateString);
            }
            catch
            {
            }

            // Das aktuelle Datumstrennzeichen ermitteln
            string dateSeparator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;

            if (dateString.IndexOf(dateSeparator, StringComparison.Ordinal) == -1)
            {

                // Wenn kein Punkt vorkommt: Versuch ein Datum im Format
                // ddmmyy[yy], ddmm oder d[d] zu erkennen                              
                if (dateString.Length >= 6 && dateString.Length < 8)
                {
                    // ddmmyy, ddmmyyy oder ddmmyyyy
                    dateString = dateString.Substring(0, 2) + "." + dateString.Substring(2, 2) + "." + dateString.Substring(4, dateString.Length - 4);
                }
                else if (dateString.Length == 4)
                {
                    // ddmm
                    dateString = dateString.Substring(0, 2) + "." + dateString.Substring(2, 2) + "." + DateTime.Now.Year;
                }
                else if (dateString.Length <= 2)
                {
                    // d oder dd
                    if (dateString.Length == 1)
                        dateString = "0" + dateString;
                    dateString = dateString.Substring(0, 2) + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                }
                else if (dateString.Length == 8)
                {
                    // yyyyMMDD -> DD.MM.yyyy
                    // dateString = dateString.Substring(0, 3) + "." + dateString.Substring(3, 4) + "." + dateString.Substring(4, 5);
                    string year = dateString.Substring(0, 4);
                    string month = dateString.Substring(4, 2);
                    string day = dateString.Substring(6, 2);

                    dateString = day + "." + month + "." + year;
                }

            }
            else
            {
                // Eingabe des Datums mit Punkten in der Form dd.mm oder 
                // dd. Zunächst einen eventuellen rechten Punkt entfernen
                while (dateString.EndsWith(dateSeparator))
                    dateString = dateString.Substring(0, dateString.Length - 1);

                // Ein im Format dd oder dd.mm angegebenes Datum um den
                // aktuellen Monat und das aktuelle Jahr ergänzen
                if (dateString.Length <= 2)
                {
                    // dd.
                    dateString = dateString + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                }
                else
                {
                    // dd.mm[.]
                    dateString = dateString + "." + DateTime.Now.Year;
                }
            }

            // Versuch das ermittelte deutsche Datum zu konvertieren
            return DateTime.Parse(dateString, CultureInfo.CreateSpecificCulture("de"));
        }
    }
}

