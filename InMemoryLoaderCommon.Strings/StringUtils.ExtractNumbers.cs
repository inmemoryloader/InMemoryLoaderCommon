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
using System.Text.RegularExpressions;
using System.Threading;
using InMemoryLoaderBase;

namespace InMemoryLoaderCommon.Strings
{
    public partial class Strings : AbstractComponent
	{

		public double[] ExtractNumbers(string paramValue, bool extractOnlyIntegers)
		{
			// Muster für den regulären Ausdruck definieren
			string pattern;
			if (extractOnlyIntegers)
			{
				pattern = @"\d{1,}";
			}
			else
			{
				var decimalSeparator = Regex.Escape( Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
				pattern = @"\d{1,}" + decimalSeparator + @"{0,1}\d{0,}";
			}
			// Die Treffer ermitteln
			MatchCollection matches = Regex.Matches(paramValue, pattern);
			// Das Ergebnis in ein double-Array kopieren
			double[] result = new double[matches.Count];
			for (int i = 0; i < matches.Count; i++)
			{
				result[i] = Convert.ToDouble(matches[i].Value);
			}
			return result;
		}

	}

}

