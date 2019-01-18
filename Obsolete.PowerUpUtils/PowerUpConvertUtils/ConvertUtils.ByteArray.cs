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
using System.IO;
using System.Text;

namespace PowerUpConvertUtils
{
    public partial class ConvertUtils : AbstractComponent
	{
        /// <summary>
        /// Strings to byte array.
        /// </summary>
        /// <returns>The to byte array.</returns>
        /// <param name="paramString">String.</param>
        public byte[] StringToByteArray(string paramString)
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter br = new BinaryWriter(ms);
			br.Write(paramString);
			byte[] byteReturn = ms.ToArray();
			return byteReturn;
		}
        /// <summary>
        /// Strings to byte array.
        /// </summary>
        /// <returns>The to byte array.</returns>
        /// <param name="paramString">String.</param>
        /// <param name="paramEncoding">Encoding.</param>
        public byte[] StringToByteArray(string paramString, Encoding paramEncoding)
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter br = new BinaryWriter(ms, paramEncoding);
			br.Write(paramString);
			byte[] byteReturn = ms.ToArray();
			return byteReturn;
		}
        /// <summary>
        /// Files the content to byte array.
        /// </summary>
        /// <returns>The content to byte array.</returns>
        /// <param name="paramFile">File.</param>
        public byte[] FileContentToByteArray(string paramFile)
		{
			byte[] buff = null;
			FileStream fs = new FileStream(paramFile, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);
			long numBytes = new FileInfo(paramFile).Length;
			buff = br.ReadBytes((int)numBytes);
			return buff;
		}
	}
}

