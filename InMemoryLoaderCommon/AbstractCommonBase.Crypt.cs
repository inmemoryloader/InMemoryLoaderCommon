//
// AbstractCommonBase.Converter.cs
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

using System.Threading.Tasks;
using InMemoryLoader;
using InMemoryLoaderBase;

namespace InMemoryLoaderCommon
{
    public abstract partial class AbstractCommonBase : AbstractLoaderBase
    {

        #region Crypt

        IDynamicClassInfo Crypt;
        bool CryptSet;

        private void SetCrypt()
        {
            if (Crypt == null)
            {
                Crypt = ComponentLoader.GetClassReference("Crypt");
            }
            CryptSet = true;
        }

        // Md5Encryption
        // ####################################################################################

        public dynamic Md5Encryption(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Crypt, "Md5Encryption", paramArgs);
        }

        public async Task<dynamic> Md5EncryptionAsync(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Crypt, "Md5Encryption", paramArgs);
        }


        // Md5SaltedHashEncryption
        // ####################################################################################

        public dynamic Md5SaltedHashEncryption(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Crypt, "Md5SaltedHashEncryption", paramArgs);
        }

        public async Task<dynamic> Md5SaltedHashEncryptionAsync(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Crypt, "Md5SaltedHashEncryption", paramArgs);
        }


        // GetMd5HashAsString
        // ####################################################################################

        public dynamic GetMd5HashAsString(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Crypt, "GetMd5HashAsString", paramArgs);
        }

        public async Task<dynamic> GetMd5HashAsStringAsync(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Crypt, "GetMd5HashAsString", paramArgs);
        }


        // RijndaelManaged
        // ####################################################################################

        public dynamic SetCryptoParameter(string paramPhrase, string paramSalt, string paramHash, int paramIteration, string paramVector, int paramKeySize)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramPhrase, paramSalt, paramHash, paramIteration, paramVector, paramKeySize };
            return ComponentLoader.InvokeMethod(Crypt, "SetCryptoParameter", paramArgs);
        }

        public dynamic Encrypt(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Crypt, "Encrypt", paramArgs);
        }

        public dynamic Decrypt(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Crypt, "Decrypt", paramArgs);
        }


        public async Task<dynamic> SetCryptoParameterAsync(string paramPhrase, string paramSalt, string paramHash, int paramIteration, string paramVector, int paramKeySize)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramPhrase, paramSalt, paramHash, paramIteration, paramVector, paramKeySize };
            return await InvokeMethodAsync(Crypt, "SetCryptoParameter", paramArgs);
        }

        public async Task<dynamic> EncryptAsync(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Crypt, "Encrypt", paramArgs);
        }

        public async Task<dynamic> DecryptAsync(string paramValue)
        {
            if (!CryptSet) SetCrypt();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Crypt, "Decrypt", paramArgs);
        }


        #endregion

    }

}
