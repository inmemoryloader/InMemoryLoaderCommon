// Strings.cs
//
// Author: Kay Stuckenschmidt
//
// Copyright (c) 2017 responsive-kaysta
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
using System.Text;
using InMemoryLoaderBase;

namespace InMemoryLoaderCommon.Strings
{
    public partial class Strings : AbstractComponent
    {

        public string ReplaceString(string source, string find, string replacement, bool ignoreCase, int start, int count)
        {
            int pos1 = 0, pos2 = 0;
            int findStringLen = find.Length;
            string baseString;
            string result = null;
            // Den Sonderfall abhandeln, dass count mit 0 angegeben ist
            if (count == 0)
            {
                return source;
            }
            // Wenn der Vergleich ohne Berücksichtigung der Groß-/Kleinschreibung
            // erfolgen soll, werden der zu durchsuchende und der Suchstring einfach in
            // Kleinschreibung umgewandelt
            if (ignoreCase)
            {
                baseString = source.ToLower();
                find = find.ToLower();
            }
            else
            {
                baseString = source;
            }
            // Erstes Vorkommen des Suchstrings suchen
            pos2 = baseString.IndexOf(find, StringComparison.Ordinal);
            // Den String durchgehen, solange der Suchstring noch gefunden wurde
            int findIndex = -1;
            int replaceCount = 0;
            while (pos2 != -1)
            {
                findIndex++;
                if (findIndex >= start)
                {
                    // Wenn der Index des gefundenen Teilstrings größer/gleich start ist:
                    // Das Ergebnis zusammensetzen und die Such-Indizes auf die neuen
                    // Positionen setzen
                    result += source.Substring(pos1, pos2 - pos1) + replacement;
                    pos1 = pos2 + findStringLen;
                    pos2 = baseString.IndexOf(find, pos1, StringComparison.Ordinal);
                    // Wenn count größer -1 definiert ist: Überprüfen, ob die Anzahl
                    // erreicht ist
                    replaceCount++;
                    if (count > -1 && replaceCount >= count)
                    {
                        break;
                    }
                }
                else
                {
                    // Index des gefundenen Teilstrings ist noch kleiner start:
                    // Teilstring ohne zu ersetzen an das Ergebnis anhängen
                    result += source.Substring(pos1, pos2 - pos1 + findStringLen);
                    // Such-Positionen aktualisieren
                    pos1 = pos2 + findStringLen;
                    pos2 = baseString.IndexOf(find, pos1, StringComparison.Ordinal);
                }
            }
            if (pos1 < source.Length)
            {
                // Wenn nach dem letzten Suchstring noch ein Teilstring gespeichert ist,
                // diesen hinten anhängen
                result += source.Substring(pos1, source.Length - pos1);
            }
            // Ergebnis zurückgeben
            return result;
        }

        public string ReplaceString(string source, string find, string replacement, bool ignoreCase)
        {
            return ReplaceString(source, find, replacement, ignoreCase, 0, -1);
        }

        public string ReplaceString(string text, char ToReplace, char ReplaceWith)
        {
            StringBuilder sb = new StringBuilder(text);
            sb.Replace(ToReplace, ReplaceWith);
            return sb.ToString();
        }

        public string ReplaceCharAt(string parmString, int parmPos, char parmChar)
        {
            return parmString.Substring(0, parmPos) + parmChar + parmString.Substring(parmPos + 1);
        }
    }
}

