//
// CryptUtils.Rijndael.cs
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
using System.IO;
using System.Security.Cryptography;
using System.Text;
using InMemoryLoaderBase;

namespace PowerUpCryptUtils
{
    public partial class CryptUtils : AbstractComponent
    {
        /// <summary>
        /// The crypt pass phrase.
        /// </summary>
        static string _cryptPassPhrase = "Pas5pr@se";
        /// <summary>
        /// The crypt salt value.
        /// </summary>
        static string _cryptSaltValue = "s@1tValue";
        /// <summary>
        /// The crypt hash algorithm.
        /// </summary>
        static string _cryptHashAlgorithm = "SHA1";
        /// <summary>
        /// The crypt password iterations.
        /// </summary>
        static int _cryptPasswordIterations = 2;
        /// <summary>
        /// The crypt init vector.
        /// </summary>
        static string _cryptInitVector = "@1B2c3D4e5F6g7H8";
        /// <summary>
        /// The size of the crypt key.
        /// </summary>
        static int _cryptKeySize = 256;

        /// <summary>
        /// Sets the crypto parameter.
        /// </summary>
        /// <returns><c>true</c>, if crypto parameter was set, <c>false</c> otherwise.</returns>
        /// <param name="paramPhrase">Parameter phrase.</param>
        /// <param name="paramSalt">Parameter salt.</param>
        /// <param name="paramHash">Parameter hash.</param>
        /// <param name="paramIteration">Parameter iteration.</param>
        /// <param name="paramVector">Parameter vector.</param>
        /// <param name="paramKeySize">Parameter key size.</param>
        public bool SetCryptoParameter(string paramPhrase, string paramSalt, string paramHash, int paramIteration, string paramVector, int paramKeySize)
        {
            _cryptPassPhrase = paramPhrase;
            _cryptSaltValue = paramSalt;
            _cryptHashAlgorithm = paramHash;
            _cryptPasswordIterations = paramIteration;
            _cryptInitVector = paramVector;
            _cryptKeySize = paramKeySize;
            return true;
        }

        /// <summary>
        /// Encrypts specified plaintext using Rijndael symmetric key algorithm
        /// and returns a base64-encoded result. Source: http://www.obviex.com/samples/Encryption.aspx
        /// </summary>
        /// <param name="paramValue">
        /// Plaintext value to be encrypted.
        /// </param>
        /// <returns>
        /// Encrypted value formatted as a base64-encoded string.
        /// </returns>
        public string Encrypt(string paramValue)
        {
            // Convert strings into byte arrays.
            // Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
            // encoding.
            var initVectorBytes = Encoding.ASCII.GetBytes(_cryptInitVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(_cryptSaltValue);

            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            var plainTextBytes = Encoding.UTF8.GetBytes(paramValue);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            var password = new PasswordDeriveBytes(_cryptPassPhrase, saltValueBytes, _cryptHashAlgorithm, _cryptPasswordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            var keyBytes = password.GetBytes(_cryptKeySize / 8);

            // Create uninitialized Rijndael encryption object.
            var symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate encryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            var memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            var cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            var cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;
        }

        /// <summary>
        /// Decrypts specified ciphertext using Rijndael symmetric key algorithm.
        /// </summary>
        /// <param name="cipherText">
        /// Base64-formatted ciphertext value.
        /// </param>
        /// <returns>
        /// Decrypted string value.
        /// </returns>
        /// <remarks>
        /// Most of the logic in this function is similar to the Encrypt
        /// logic. In order for decryption to work, all parameters of this function
        /// - except cipherText value - must match the corresponding parameters of
        /// the Encrypt function which was called to generate the
        /// ciphertext.
        /// </remarks>
        public string Decrypt(string cipherText)
        {
            // Convert strings defining encryption key characteristics into byte
            // arrays. Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
            var initVectorBytes = Encoding.ASCII.GetBytes(_cryptInitVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(_cryptSaltValue);

            // Convert our ciphertext into a byte array.
            var cipherTextBytes = Convert.FromBase64String(cipherText);

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            var password = new PasswordDeriveBytes(_cryptPassPhrase, saltValueBytes, _cryptHashAlgorithm, _cryptPasswordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            var keyBytes = password.GetBytes(_cryptKeySize / 8);

            // Create uninitialized Rijndael encryption object.
            var symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate decryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            var memoryStream = new MemoryStream(cipherTextBytes);

            // Define cryptographic stream (always use Read mode for encryption).
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold ciphertext;
            // plaintext is never longer than ciphertext.
            var plainTextBytes = new byte[cipherTextBytes.Length];

            // Start decrypting.
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            var plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

            // Return decrypted string.   
            return plainText;
        }

    }

}