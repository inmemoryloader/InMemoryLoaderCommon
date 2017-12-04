//
// Culture.cs
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
using System.Globalization;

namespace PowerUpDateTimeUtils
{
    /// <summary>
    /// Verwaltet die Namen einer Kultur und gibt ein Array der verfügbaren Kulturen zurück
    /// </summary>
    public class Culture
    {
        /// <summary>
        /// Der Name der Kultur
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Der Anzeigename der Kultur
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="name">Der Name der Kultur</param>
        /// <param name="displayName">Der Anzeigename der Kultur</param>
        public Culture (string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

        /// <summary>
        /// Gibt den Namen und den Displaynamen zurück
        /// </summary>
        public override string ToString ()
        {
            return DisplayName + " (" + Name + ")";
        }

        /// <summary>
        /// Gibt die verfügbaren speziellen Kulturen zurück
        /// </summary>
        /// <returns></returns>
        public static Culture[] GetSpecificCultures ()
        {
            // Die verfügbaren Kulturen einlesen
            var cultures = CultureInfo.GetCultures (CultureTypes.SpecificCultures);

            // Sortieren
            Array.Sort (cultures, new CultureComparer ());

            // Ergebnis erzeugen
            var result = new Culture[cultures.Length];

            // Die Kulturen durchgehen und in das Array schreiben
            for (int i = 0; i < cultures.Length; i++) {
                result [i] = new Culture (cultures [i].Name, cultures [i].EnglishName);
            }

            // Ergebnis zurückgeben
            return result;
        }

    }

}