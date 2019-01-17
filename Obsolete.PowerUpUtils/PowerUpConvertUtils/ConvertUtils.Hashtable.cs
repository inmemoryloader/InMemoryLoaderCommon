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
using System.Collections;

namespace PowerUpConvertUtils
{
    public partial class ConvertUtils : AbstractComponent
	{
        /// <summary>
        /// Strings to hashtable.
        /// </summary>
        /// <returns>The to hashtable.</returns>
        /// <param name="paramString">String.</param>
        /// <param name="paramDelimit">Delimit.</param>
        public Hashtable StringToHashtable(string paramString, char[] paramDelimit)
		{
			Hashtable ht = new Hashtable();
			int count = 0;
			foreach (string substr in paramString.Split(paramDelimit))
			{
				ht.Add(count++, substr);
			}
			return ht;
		}
	}
}

