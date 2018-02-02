//
// ConvertUtils.cs
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

using InMemoryLoaderBase;

namespace PowerUpConvertUtils
{
    public partial class ConvertUtils : AbstractComponent
	{
		/// <summary>
		/// Strings to boolean.
		/// </summary>
		/// <returns><c>true</c>, if to boolean was strung, <c>false</c> otherwise.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool StringToBoolean(string paramValue)
		{
			if (paramValue == "1") return true;            
			else if (paramValue == "0") return false;            
			else return false;            
		}
		/// <summary>
		/// Chars to boolean.
		/// </summary>
		/// <returns><c>true</c>, if to boolean was chared, <c>false</c> otherwise.</returns>
		/// <param name="paramValue">Parameter value.</param>
		public bool CharToBoolean(char paramValue)
		{
			if (paramValue == '1') return true;
			else if (paramValue == '0') return false;
			else return false;
		}
		/// <summary>
		/// Booleans to string.
		/// </summary>
		/// <returns>The to string.</returns>
		/// <param name="paramValue">If set to <c>true</c> parameter value.</param>
		public string BooleanToString(bool paramValue)
		{
			if (paramValue == true) return "1";
			else if (paramValue == false) return "0";
			else return "0";            
		}
		/// <summary>
		/// Booleans to char.
		/// </summary>
		/// <returns>The to char.</returns>
		/// <param name="paramValue">If set to <c>true</c> parameter value.</param>
		public char BooleanToChar(bool paramValue)
		{
			if (paramValue == true) return '1';
			else if (paramValue == false) return '0';
			else return '0';
		}
	}
}

