//
// TestHelper.PowerUpCryptUtils.cs
//
// Author: responsive it
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

using InMemoryLoaderCommon;

namespace InMemoryLoaderCommonNunit
{
    internal partial class TestHelper : AbstractCommonBase
    {

        #region CryptUtils.Rijndael

        /// <summary>
        /// The crypt pass phrase.
        /// </summary>
        const string cryptPassPhrase = "Pa_s5pr@se";
        /// <summary>
        /// The crypt salt value.
        /// </summary>
        const string cryptSaltValue = "s@1tValue!";
        /// <summary>
        /// The crypt hash algorithm.
        /// </summary>
        const string cryptHashAlgorithm = "SHA256";
        /// <summary>
        /// The crypt password iterations.
        /// </summary>
        const int cryptPasswordIterations = 6;
        /// <summary>
        /// The crypt init vector.
        /// </summary>
        const string cryptInitVector = "@1B2c3D4e5F6g7H8!?";
        /// <summary>
        /// The size of the crypt key.
        /// </summary>
        const int cryptKeySize = 256;
        /// <summary>
        /// The password.
        /// </summary>
        const string password = "some0RanD!!pWd";
        /// <summary>
        /// The encrypted.
        /// </summary>
        const string encrypted = "5ifOfTikmyeQN3Cb3mczYA==";

        internal bool RijndaelTest()
        {
            bool isCorrectEncrypt = false;

            // SetCryptoParameter
            object[] paramCryptArgs = { cryptPassPhrase, cryptSaltValue, cryptHashAlgorithm, cryptPasswordIterations, cryptInitVector, cryptKeySize };
            isCorrectEncrypt = ComponentLoader.InvokeMethod(base.CryptUtils, "SetCryptoParameter", paramCryptArgs);

            // Encrypt
            object[] paramEncrypt = { password };
            string encryptedPwd = ComponentLoader.InvokeMethod(base.CryptUtils, "Encrypt", paramEncrypt);

            isCorrectEncrypt = isCorrectEncrypt && encryptedPwd.Equals(encrypted) ? true : false;

            // Decrypt
            object[] paramDecrypt = { encryptedPwd };
            string decryptedPwd = ComponentLoader.InvokeMethod(base.CryptUtils, "Decrypt", paramDecrypt);

            isCorrectEncrypt = isCorrectEncrypt && decryptedPwd.Equals(password) ? true : false;

            return isCorrectEncrypt;
        }

        #endregion


    }

}