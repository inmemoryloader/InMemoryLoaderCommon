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
        const string CryptPassPhrase = "Pa_s5pr@se";
        /// <summary>
        /// The crypt salt value.
        /// </summary>
        const string CryptSaltValue = "s@1tValue!";
        /// <summary>
        /// The crypt hash algorithm.
        /// </summary>
        const string CryptHashAlgorithm = "SHA256";
        /// <summary>
        /// The crypt password iterations.
        /// </summary>
        const int CryptPasswordIterations = 6;
        /// <summary>
        /// The crypt init vector.
        /// </summary>
        const string CryptInitVector = "@1B2c3D4e5F6g7H8!?";
        /// <summary>
        /// The size of the crypt key.
        /// </summary>
        const int CryptKeySize = 256;
        /// <summary>
        /// The password.
        /// </summary>
        const string Password = "some0RanD!!pWd";
        /// <summary>
        /// The encrypted.
        /// </summary>
        const string Encrypted = "5ifOfTikmyeQN3Cb3mczYA==";

        /// <summary>
        /// Rijndaels the test.
        /// </summary>
        /// <returns><c>true</c>, if test was rijndaeled, <c>false</c> otherwise.</returns>
        internal bool RijndaelTest()
        {
            bool isCorrectEncrypt = false;

            // SetCryptoParameter
            object[] paramCryptArgs = { CryptPassPhrase, CryptSaltValue, CryptHashAlgorithm, CryptPasswordIterations, CryptInitVector, CryptKeySize };
            isCorrectEncrypt = ComponentLoader.InvokeMethod(base.CryptUtils, "SetCryptoParameter", paramCryptArgs);

            // Encrypt
            object[] paramEncrypt = { Password };
            string encryptedPwd = ComponentLoader.InvokeMethod(base.CryptUtils, "Encrypt", paramEncrypt);

            isCorrectEncrypt = isCorrectEncrypt && encryptedPwd.Equals(Encrypted) ? true : false;

            // Decrypt
            object[] paramDecrypt = { encryptedPwd };
            string decryptedPwd = ComponentLoader.InvokeMethod(base.CryptUtils, "Decrypt", paramDecrypt);

            isCorrectEncrypt = isCorrectEncrypt && decryptedPwd.Equals(Password) ? true : false;

            return isCorrectEncrypt;
        }

        #endregion


    }

}