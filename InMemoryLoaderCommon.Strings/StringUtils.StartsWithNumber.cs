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
using log4net;
using System.Text.RegularExpressions;
using System.Threading;

namespace InMemoryLoaderCommon.Strings
{
	public partial class Strings : AbstractComponent
	{
		/// <summary>
		/// Überprüft, ob der übergebene String mit einer Zahl beginnt 
		/// und gibt die Zeichenlänge der Zahl zurück
		/// </summary>
		/// <param name="source">Der Quellstring</param>
		/// <param name="considerOnlyIntegers">Gibt an, ob nur Ganzzahlen
		/// berücksichtigt werden sollen</param>
		/// <returns>Gibt die Zeichenlänge der Zahl zurück falls eine solche
		/// am String-Anfang steht. Steht keine Zahl am Anfang des Strings,
		/// gibt die Methode 0 zurück</returns>
		public int StartsWithNumber(string source, bool considerOnlyIntegers)
		{
			// Muster für den regulären Ausdruck definieren
			string pattern;
			if (considerOnlyIntegers)
			{
				pattern = @"^\d{1,}";
			}
			else
			{
				string decimalSeparator = Regex.Escape(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
				pattern = @"^\d{1,}" + decimalSeparator + @"{0,1}\d{0,}";
			}
			// Match-Instanz erzeugen und überprüfen ob ein Treffer erzielt wurde
			Match match = Regex.Match(source, pattern);
			if (match.Success)
			{
				// Die Länge des gefundenen Teilstrings zurückgeben
				return match.Length;
			}
			else
			{
				return 0;
			}
		}
	}
}

