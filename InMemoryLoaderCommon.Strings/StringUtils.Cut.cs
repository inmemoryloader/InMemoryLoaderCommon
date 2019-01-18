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
using InMemoryLoaderBase.HelperEnum;

namespace InMemoryLoaderCommon.Strings
{
    public partial class Strings : AbstractComponent
	{

		public string CutString(string paramValue, int paramSize, StringDirection paramDirection)
		{
			string str;
			int length = paramValue.Length;
			int cut;

			if (length > paramSize && paramDirection == StringDirection.Left)
			{
				cut = length - paramSize;
				str = paramValue.Remove(paramSize, cut);
			}
			else if (length > paramSize && paramDirection == StringDirection.Right)
			{
				cut = paramSize;
				str = paramValue.Remove(0, cut);
			}
			else
			{
				str = paramValue;
			}
			return str;
		}
	}
}

