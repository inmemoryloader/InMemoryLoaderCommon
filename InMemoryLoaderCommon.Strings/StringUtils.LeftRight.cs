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

using InMemoryLoaderBase;

namespace InMemoryLoaderCommon.Strings
{
    public partial class Strings : AbstractComponent
    {

        /// <summary>
        /// Extrahiert einen linken Teilstring aus einem String
        /// </summary>
        /// <param name="paramValue">Der Quellstring</param>
        /// <param name="paramCount">Die Anzahl zu extrahierender Zeichen</param>
        /// <returns>Gibt den extrahierten String zurück</returns>
        public string CutStringLeft(string paramValue, int paramCount)
        {
            if (paramValue.Length >= paramCount)
            {
                return paramValue.Substring(0, paramCount);
            }
            else
            {
                return paramValue;
            }
        }

        /// <summary>
        /// Extrahiert einen rechten Teilstring aus einem String
        /// </summary>
        /// <param name="paramValue">Der Quellstring</param>
        /// <param name="paramCount">Die Anzahl zu extrahierender Zeichen</param>
        /// <returns>Gibt den extrahierten String zurück</returns>
        public string CutStringRight(string paramValue, int paramCount)
        {
            int length = paramValue.Length;
            if (length >= paramCount)
            {
                return paramValue.Substring(length - paramCount, paramCount);
            }
            else
            {
                return paramValue;
            }
        }
    }
}

