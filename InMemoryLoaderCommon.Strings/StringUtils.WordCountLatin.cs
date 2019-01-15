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
using InMemoryLoaderBase;

namespace InMemoryLoaderCommon.Strings
{
    public partial class Strings : AbstractComponent
	{
		/// <summary>
		/// Ermittelt die Anzahl der Wörter in einem String mit lateinischen Zeichen (schnell im Vergleich zu <see cref="WordCount"/>)
		/// </summary>
		/// <param name="source">Der String</param>
		/// <returns>Gibt die ermittelte Anzahl zurück</returns>
		/// <remarks>
		/// Schnelle und speichersparende Methode zur Ermittlung der Anzahl 
		/// der Wörter in einem String. Funktioniert nur für lateinische Zeichen.
		/// Funktioniert nicht, wenn der Unicode-String Zeichen der Teiltabellen 
		/// ab der griechischen (ab Zeichen 0x0370) enthält.
		/// </remarks>
		public long WordCountLatin(string source)
		{
			bool newWord = false;
			long count = 0;
			// Alle Zeichen des Strings durchgehen
			for (int i = 0; i < source.Length; i++)
			{
				char c = source[i];
				// Überprüfen, ob das Zeichen größer ist als das letzte Zeichen im
				// unterstützten (lateinischen) Bereich der Unicode-Tabelle.
				if (c > '\u02FF')
				{
					throw new Exception("WordCount2 unterstützt keine Strings mit Unicode-Zeichen größer 0x02FF");
				}

				// Überprüfen, ob es ein Wort-Zeichen ist
				if ((c >= '\u0030' && c <= '\u0039') ||
					(c >= '\u0041' && c <= '\u005A') ||
					(c == '\u005F') ||
					(c >= '\u0061' && c <= '\u007A') ||
					(c == '\u00AA') ||
					(c == '\u00B5') ||
					(c == '\u00BA') ||
					(c >= '\u00C0' && c <= '\u00D6') ||
					(c >= '\u00D8' && c <= '\u00F6') ||
					(c >= '\u00F8' && c <= '\u0236') ||
					(c >= '\u0250' && c <= '\u02C1') ||
					(c >= '\u02C6' && c <= '\u02D1') ||
					(c >= '\u02E0' && c <= '\u02E4') ||
					(c == '\u02EE'))
				{
					// Wort-Zeichen
					if (newWord == false)
						count++;
					newWord = true;
				}
				else
				{
					// Kein Wort-Zeichen
					newWord = false;
				}
			}

			return count;
		}
	}
}

