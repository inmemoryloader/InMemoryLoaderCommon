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

using System.Text.RegularExpressions;
using InMemoryLoaderBase;

namespace InMemoryLoaderCommon.Strings
{
    public partial class Strings : AbstractComponent
	{

        /// <summary>
        /// Extrahiert alle Wörter aus einem String
        /// </summary>
        /// <param name="paramValue">Der String</param>
        /// <returns>Gibt ein String-Array mit den einzelnen Wörtern zurück</returns>
        public string[] GetWords(string paramValue)
		{
			// Alle Wörter abfragen
			var matches = Regex.Matches(paramValue, @"\w{1,}");

			// Die MatchCollection in ein String-Array kopieren und zurückgeben
			string[] words = new string[matches.Count];
			for (int i = 0; i < matches.Count; i++)
			{
				words[i] = matches[i].Value;
			}
			return words;
		}

        /// <summary>
        /// GetWords
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramMinLength"></param>
        /// <returns>GetWords</returns>
		public string[] GetWords(string paramValue, int paramMinLength)
		{
			// Alle Wörter abfragen
			var matches = Regex.Matches(paramValue, @"\w{1,}");

			// Die MatchCollection in ein String-Array kopieren und zurückgeben
			string[] words = new string[matches.Count];
			for (int i = 0; i < matches.Count; i++)
			{
				if (matches[i].Value.Length >= paramMinLength)
				{
					words[i] = matches[i].Value; 
				}
			}
			return words;
		}

	}

}
