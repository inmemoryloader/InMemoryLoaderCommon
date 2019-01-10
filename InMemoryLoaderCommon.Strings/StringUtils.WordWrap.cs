//
// StringUtils.WordWrap.cs
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
using System.Text.RegularExpressions;
using System.Text;

namespace InMemoryLoaderCommon.Strings
{
    public partial class Strings : AbstractComponent
    {
        /// <summary>
        /// Bricht einen String an einem (virtuellen) rechten Rand um
        /// </summary>
        /// <param name="text">Der umzubrechende String</param>
        /// <param name="maxCharWidth">Die maximale Zeichenbreite der Fläche auf der der String ausgegeben werden soll</param>
        /// <returns>Gibt einen String zurück, der den Originalstring inklusive passenden Zeilenumbrüchen enthält</returns>
        public string WordWrap(string text, int maxCharWidth)
        {
            // StringBuilder für den umbrochenen Text erzeugen
            StringBuilder wrappedText = new StringBuilder();
            if (!string.IsNullOrEmpty(text))
            {
                // Tabs durch Leerzeichen ersetzen um
                // Darstellungs-Probleme zu vermeiden
                text = text.Replace("\t", "   ");
                // Aufteilen des Textes in einzelne Zeilen
                string[] rows = Regex.Split(text, Environment.NewLine);
                foreach (string row in rows)
                {
                    // Zeilenumbruch an die vorherige Zeile anfügen
                    if (wrappedText.Length > 0)
                    {
                        wrappedText.Append(Environment.NewLine);
                    }
                    // Text in einzelne Wort-Token aufsplitten
                    // Als Trennzeichen werden alle Nicht-Wort-Zeichen und
                    // der Bindestrich verwendet
                    MatchCollection matches = Regex.Matches(row, @"\w{1,}(\W|-){0,}");
                    // Die einzelnen Wort-Token durchgehen und ausgeben
                    int currentWidth = 0;
                    for (int i = 0; i < matches.Count; i++)
                    {
                        Match match = matches[i];
                        // Den Sonderfall behandeln, dass das erste Wort-Token 
                        // zu lang ist
                        if (i == 0 && match.Value.Length > maxCharWidth)
                        {
                            // Aktuelles Token ablegen
                            wrappedText.Append(match.Value);
                        }
                        else
                        {
                            if (currentWidth + match.Value.Length <= maxCharWidth)
                            {
                                // Aktuelles Token ablegen
                                wrappedText.Append(match.Value);
                            }
                            else
                            {
                                // Das Wort passt nicht mehr in die Spalte
                                // Zeilenumbruch generieren
                                if (wrappedText.Length > 0)
                                {
                                    wrappedText.Append(Environment.NewLine);
                                }
                                // Token ablegen
                                wrappedText.Append(match.Value);
                                // Die aktuelle Breite wieder auf den Anfang setzen
                                currentWidth = 0;
                            }
                            // Die aktuelle Breite um die Wortlänge hochzählen
                            currentWidth += match.Value.Length;
                        }
                    }
                }
            }
            return wrappedText.ToString();
        }
    }
}

