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
        /// Kürzt einen Sting unter Berücksichtigung der Wörter
        /// </summary>
        /// <param name="paramValue">Der String</param>
        /// <param name="maxCharCount">Die maximale Anzahl an Zeichen im resultierenden String</param>
        /// <returns>Gibt den gekürzten String, gegebenenfalls mit drei Punkten am Ende zurück</returns>
        public string Abbreviate(string paramValue, int maxCharCount)
		{
			var result = String.Empty;

			// String an Leerzeichen splitten
			string[] words = paramValue.Split(' ');

			// Die Sonderfälle abhandeln, dass der gesamte String 
			// kürzer oder das erste Wort schon zu lang ist
			if (paramValue.Length <= maxCharCount)
			{
				return paramValue;
			}

			if (words.Length > 0 && words[0].Length > maxCharCount)
			{
				return words[0].Substring(0, maxCharCount - 3) + "...";
			}

			// Die Wörter durchgehen und in das Ergebnis schreiben bis die Maximallänge erreicht ist
			for (int i = 0; i < words.Length; i++)
			{
				if (result.Length + words[i].Length + 4 > maxCharCount)
				{
					return result + "...";
				}
				else
				{
					result += ' ' + words[i];
				}
			}

			return paramValue;
		}

    }

}
