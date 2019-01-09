//
// MyClass.cs
//
// Author: Kay Stuckenschmidt
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
using System.Security.Cryptography;
using System.Text;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderCommon.Crypt
{

    public partial class Crypt : AbstractComponent
    {
        static readonly ILog Log = LogManager.GetLogger(typeof(Crypt));

        public Crypt()
        {
            Log.DebugFormat("Create a new instance of Type: {0}", GetType());
        }


        public byte[] Md5Encryption(string paramValue)
        {
            // Create instance of the crypto provider.
            var md5 = new MD5CryptoServiceProvider();

            // Required UTF8 Encoding used to encode the input value to a usable state.
            var textencoder = new UTF8Encoding();

            // Create a Byte array to store the encryption to return.
            var hashedbytes = md5.ComputeHash(textencoder.GetBytes(paramValue));

            // Destroy objects that aren't needed.
            md5.Clear();
            md5 = null;

            // return the hased bytes to the calling method.
            return hashedbytes;
        }

        public byte[] Md5SaltedHashEncryption(string paramValue)
        {
            // Create instance of the crypto provider.
            var md5 = new MD5CryptoServiceProvider();

            // Required UTF8 Encoding used to encode the input value to a usable state.
            var textencoder = new UTF8Encoding();

            // Create a Byte array to store the encryption to return.
            var hashedbytes = md5.ComputeHash(textencoder.GetBytes(paramValue));

            // Let's add the salt.
            paramValue += textencoder.GetString(hashedbytes);

            // Create a Byte array to store the salted hash.
            // Get the new byte array after adding the salt.
            var saltedhash = md5.ComputeHash(textencoder.GetBytes(paramValue));

            // Destroy objects that aren't needed.
            md5.Clear();
            md5 = null;

            // return the hased bytes to the calling method.
            return saltedhash;
        }

        public string GetMd5HashAsString(string text)
        {
            var md5 = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(text);
            var hash = md5.ComputeHash(bytes);
            var result = BitConverter.ToString(hash);
            return result;
        }


    }

}
