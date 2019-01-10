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

namespace InMemoryLoaderCommon.Strings
{
	public partial class Strings : AbstractComponent
	{
		/// <summary>
		/// Uppercases the first.
		/// </summary>
		/// <returns>The first.</returns>
		/// <param name="paramString">Parameter string.</param>
		public string UppercaseFirst(string paramString)
		{
			// Check for empty string.
			if (string.IsNullOrEmpty(paramString))
			{
				return string.Empty;
			}
			// Return char and concat substring.
			return char.ToUpper(paramString[0]) + paramString.Substring(1);
		}
		/// <summary>
		/// Lowercases the first.
		/// </summary>
		/// <returns>The first.</returns>
		/// <param name="paramString">Parameter string.</param>
		public string LowercaseFirst(string paramString)
		{
			// Check for empty string.
			if (string.IsNullOrEmpty(paramString))
			{
				return string.Empty;
			}
			// Return char and concat substring.
			return char.ToLower(paramString[0]) + paramString.Substring(1);
		}
	}
}

