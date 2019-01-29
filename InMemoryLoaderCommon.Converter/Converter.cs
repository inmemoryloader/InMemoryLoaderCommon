//
// Converter.cs
//
// Author: Kay Stuckenschmidt <dev-guru@responsive-it.biz>
//
// Copyright (c) 2019 responsive IT
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
using System.Collections;
using System.IO;
using System.Text;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderCommon.Converter
{
    public class Converter : AbstractComponent
    {
        static readonly ILog Log = LogManager.GetLogger(typeof(Converter));

        public Converter()
        {
            Log.DebugFormat("Create a new instance of Type: {0}", GetType());
        }


        public bool StringToBoolean(string paramValue)
        {
            if (paramValue == "1") return true;
            else if (paramValue == "0") return false;
            else return false;
        }

        public bool CharToBoolean(char paramValue)
        {
            if (paramValue == '1') return true;
            else if (paramValue == '0') return false;
            else return false;
        }

        public string BooleanToString(bool paramValue)
        {
            if (paramValue == true) return "1";
            else if (paramValue == false) return "0";
            else return "0";
        }

        public char BooleanToChar(bool paramValue)
        {
            if (paramValue == true) return '1';
            else if (paramValue == false) return '0';
            else return '0';
        }


        public byte[] StringToByteArray(string paramValue)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter br = new BinaryWriter(ms);
            br.Write(paramValue);
            byte[] byteReturn = ms.ToArray();
            return byteReturn;
        }

        public byte[] StringToByteArray(string paramValue, Encoding paramEncoding)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter br = new BinaryWriter(ms, paramEncoding);
            br.Write(paramValue);
            byte[] byteReturn = ms.ToArray();
            return byteReturn;
        }

        public byte[] FileContentToByteArray(string paramValue)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(paramValue, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(paramValue).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }


        public Hashtable StringToHashtable(string paramValue, char paramDelimit)
        {
            Hashtable ht = new Hashtable();
            int count = 0;
            foreach (string substr in paramValue.Split(paramDelimit))
            {
                ht.Add(count++, substr);
            }
            return ht;
        }


        public string MemoryStreamToString(MemoryStream parmStream)
        {
            StreamReader reader = new StreamReader(parmStream);
            string text = reader.ReadToEnd();
            return text;
        }


        public string ByteArrayToString(byte[] paramByteArray)
        {
            MemoryStream stream = new MemoryStream(paramByteArray);
            StreamReader reader = new StreamReader(stream, true);
            StringBuilder sb = new StringBuilder(reader.ReadToEnd(), reader.ReadToEnd().Length);
            return sb.ToString();
        }

        public string ByteArrayToString(byte[] paramByteArray, Encoding paramEncoding)
        {
            MemoryStream stream = new MemoryStream(paramByteArray);
            StreamReader reader = new StreamReader(stream, paramEncoding);
            StringBuilder sb = new StringBuilder(reader.ReadToEnd(), reader.ReadToEnd().Length);
            return sb.ToString();
        }


        public string StringFromUtf8ToAscii(string paramValue)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] byteArray = Encoding.UTF8.GetBytes(paramValue);
            byte[] asciiArray = Encoding.Convert(Encoding.UTF8, Encoding.Default, byteArray);
            string finalString = ascii.GetString(asciiArray);
            return finalString;
        }

        public string StringFromUtf8ToLatin1(string paramString)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(paramString);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            string msg = iso.GetString(isoBytes);
            return msg;
        }


        public long TryParseStringToLong(string str)
        {
            long.TryParse(str, out long result);
            return result;
        }

        public int TryParseStringToInt(string str)
        {
            int.TryParse(str, out int result);
            return result;
        }


    }

}
