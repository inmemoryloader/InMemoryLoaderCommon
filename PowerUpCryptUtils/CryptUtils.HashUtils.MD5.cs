//
// CryptUtils.HashUtils.MD5.cs
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

using System;
using System.Security.Cryptography;
using System.Text;
using InMemoryLoaderBase;

namespace PowerUpCryptUtils
{
    public partial class CryptUtils : AbstractPowerUpComponent
    {
        /// <summary>
        /// Encrypts the string to a byte array using the MD5 Encryption Algorithm.
        /// <see cref="System.Security.Cryptography.MD5CryptoServiceProvider"/>
        /// </summary>
        /// <param name="paramValue">System.String. Usually a password.</param>
        /// <returns>System.Byte[]</returns>
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

        /// <summary>
        /// Encrypts the string to a byte array using the MD5 Encryption 
        /// Algorithm with an additional Salted Hash.
        /// <see cref="System.Security.Cryptography.MD5CryptoServiceProvider"/>
        /// </summary>
        /// <param name="paramValue">System.String. Usually a password.</param>
        /// <returns>System.Byte[]</returns>
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

        /// <summary>
        /// Gets the M d5 hash as string.
        /// </summary>
        /// <returns>The M d5 hash as string.</returns>
        /// <param name="text">Text.</param>
        public string GetMd5HashAsString(string text)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(text);
            var hash = md5.ComputeHash(bytes);
            var result = BitConverter.ToString(hash);
            return result;
        }

    }

}