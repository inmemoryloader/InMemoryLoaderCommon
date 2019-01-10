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
using log4net;
using System.Text.RegularExpressions;
using InMemoryLoaderBase.HelperEnum;

namespace InMemoryLoaderCommon.Strings
{
	public partial class Strings : AbstractComponent
	{
		/// <summary>
		/// Cut the specified value, size and direction.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="size">Size.</param>
		/// <param name="direction">Direction.</param>
		public string Cut(string value, int size, StringDirection direction)
		{
			string str;
			int length = value.Length;
			int cut;

			if (length > size && direction == StringDirection.Left)
			{
				cut = length - size;
				str = value.Remove(size, cut);
			}
			else if (length > size && direction == StringDirection.Right)
			{
				cut = size;
				str = value.Remove(0, cut);
			}
			else
			{
				str = value;
			}
			return str;
		}
	}
}

