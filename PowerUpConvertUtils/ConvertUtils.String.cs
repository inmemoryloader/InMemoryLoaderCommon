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
		/// Memories the stream to string.
		/// </summary>
		/// <returns>The stream to string.</returns>
		/// <param name="parmStream">Parm stream.</param>
		public string MemoryStreamToString(MemoryStream parmStream)
		{
			StreamReader reader = new StreamReader(parmStream);
			string text = reader.ReadToEnd();
			return text;
		}
        /// <summary>
        /// Bytes the array to string.
        /// </summary>
        /// <returns>The array to string.</returns>
        /// <param name="paramByteArray">Bytearray.</param>
        public string ByteArrayToString(byte[] paramByteArray)
		{
			MemoryStream stream = new MemoryStream(paramByteArray);
			StreamReader reader = new StreamReader(stream, true);
			StringBuilder sb = new StringBuilder(reader.ReadToEnd(), reader.ReadToEnd().Length);
			return sb.ToString();
		}
        /// <summary>
        /// Bytes the array to string.
        /// </summary>
        /// <returns>The array to string.</returns>
        /// <param name="paramByteArray">Bytearray.</param>
        /// <param name="paramEncoding">Encoding.</param>
        public string ByteArrayToString(byte[] paramByteArray, Encoding paramEncoding)
		{
			MemoryStream stream = new MemoryStream(paramByteArray);
			StreamReader reader = new StreamReader(stream, paramEncoding);
			StringBuilder sb = new StringBuilder(reader.ReadToEnd(), reader.ReadToEnd().Length);
			return sb.ToString();
		}
        /// <summary>
		/// Decodes from UTF8 to ASCII.
		/// </summary>
		/// <returns>The from UTF8 to ASCII.</returns>
		/// <param name="paramString">Parameter string.</param>
		public string StringFromUtf8ToAscii(string paramString)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] byteArray = Encoding.UTF8.GetBytes(paramString);
            byte[] asciiArray = Encoding.Convert(Encoding.UTF8, Encoding.Default, byteArray);
            string finalString = ascii.GetString(asciiArray);
            return finalString;
        }
        /// <summary>
        /// Decodes from UTF8 to latin1.
        /// </summary>
        /// <returns>The from UTF8 to latin1.</returns>
        /// <param name="paramString">Parameter string.</param>
        public string StringFromUtf8ToLatin1(string paramString)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(paramString);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            string msg = iso.GetString(isoBytes);
            return msg;
        }
    }
}

