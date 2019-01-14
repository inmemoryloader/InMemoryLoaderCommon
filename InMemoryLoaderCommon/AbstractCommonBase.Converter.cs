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

using System.IO;
using System.Text;
using System.Threading.Tasks;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderBase.HelperEnum;

namespace InMemoryLoaderCommon
{
    public abstract partial class AbstractCommonBase : AbstractLoaderBase
    {

        #region Converter

        IDynamicClassInfo Converter;
        bool CoverterSet;

        private void SetConverter()
        {
            if (Converter == null)
            {
                Converter = ComponentLoader.GetClassReference("Converter");
            }
            CoverterSet = true;
        }

        // StringToBoolean
        // ####################################################################################

        public dynamic StringToBoolean(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "StringToBoolean", paramArgs);
        }

        public async Task<dynamic> StringToBooleanAsync(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "StringToBoolean", paramArgs);
        }


        // CharToBoolean
        // ####################################################################################

        public dynamic CharToBoolean(char paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "CharToBoolean", paramArgs);
        }

        public async Task<dynamic> CharToBooleanAsync(char paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "CharToBoolean", paramArgs);
        }


        // BooleanToString
        // ####################################################################################

        public dynamic BooleanToString(bool paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "BooleanToString", paramArgs);
        }

        public async Task<dynamic> BooleanToStringAsync(bool paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "BooleanToString", paramArgs);
        }


        // BooleanToChar
        // ####################################################################################

        public dynamic BooleanToChar(bool paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "BooleanToChar", paramArgs);
        }

        public async Task<dynamic> BooleanToCharAsync(bool paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "BooleanToChar", paramArgs);
        }


        // StringToByteArray
        // ####################################################################################

        public dynamic StringToByteArray(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "StringToByteArray", paramArgs);
        }

        public async Task<dynamic> StringToByteArrayAsync(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "StringToByteArray", paramArgs);
        }

        public dynamic StringToByteArray(string paramValue, Encoding encoding)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "StringToByteArray", paramArgs);
        }

        public async Task<dynamic> StringToByteArrayAsync(string paramValue, Encoding encoding)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "StringToByteArray", paramArgs);
        }


        // StringToHashtable
        // ####################################################################################

        public dynamic StringToHashtable(string paramValue, char paramDelimit)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue, paramDelimit };
            return ComponentLoader.InvokeMethod(Converter, "StringToHashtable", paramArgs);
        }

        public async Task<dynamic> StringToHashtableAsync(string paramValue, char paramDelimit)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue, paramDelimit };
            return await InvokeMethodAsync(Converter, "StringToHashtable", paramArgs);
        }


        // MemoryStreamToString
        // ####################################################################################

        public dynamic MemoryStreamToString(MemoryStream parmStream)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { parmStream };
            return ComponentLoader.InvokeMethod(Converter, "MemoryStreamToString", paramArgs);
        }

        public async Task<dynamic> MemoryStreamToStringAsync(MemoryStream parmStream)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { parmStream };
            return await InvokeMethodAsync(Converter, "MemoryStreamToString", paramArgs);
        }


        // ByteArrayToString
        // ####################################################################################

        public dynamic ByteArrayToString(byte[] paramByteArray)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramByteArray };
            return ComponentLoader.InvokeMethod(Converter, "ByteArrayToString", paramArgs);
        }

        public async Task<dynamic> ByteArrayToStringAsync(byte[] paramByteArray)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramByteArray };
            return await InvokeMethodAsync(Converter, "ByteArrayToString", paramArgs);
        }

        public dynamic ByteArrayToString(byte[] paramByteArray, Encoding paramEncoding)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramByteArray, paramEncoding };
            return ComponentLoader.InvokeMethod(Converter, "ByteArrayToString", paramArgs);
        }

        public async Task<dynamic> ByteArrayToStringAsync(byte[] paramByteArray, Encoding paramEncoding)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramByteArray, paramEncoding };
            return await InvokeMethodAsync(Converter, "ByteArrayToString", paramArgs);
        }


        // StringFromUtf8ToAscii
        // ####################################################################################

        public dynamic StringFromUtf8ToAscii(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "StringFromUtf8ToAscii", paramArgs);
        }

        public async Task<dynamic> StringFromUtf8ToAsciiAsync(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "StringFromUtf8ToAscii", paramArgs);
        }


        // StringFromUtf8ToLatin1
        // ####################################################################################

        public dynamic StringFromUtf8ToLatin1(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "StringFromUtf8ToLatin1", paramArgs);
        }

        public async Task<dynamic> StringFromUtf8ToLatin1Async(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "StringFromUtf8ToLatin1", paramArgs);
        }


        // StringTo converter
        // ####################################################################################

        public dynamic TryParseStringToLong(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "TryParseStringToLong", paramArgs);
        }

        public async Task<dynamic> TryParseStringToLongAsync(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "TryParseStringToLong", paramArgs);
        }


        public dynamic TryParseStringToInt(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "TryParseStringToInt", paramArgs);
        }

        public async Task<dynamic> TryParseStringToIntAsync(string paramValue)
        {
            if (!CoverterSet) SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "TryParseStringToInt", paramArgs);
        }


        #endregion


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


        #region Strings

        IDynamicClassInfo Strings;
        bool StringsSet;

        private void SetStrings()
        {
            if (Strings == null)
            {
                Strings = ComponentLoader.GetClassReference("Strings");
            }
            StringsSet = true;
        }


        // AbbreviateString
        // ####################################################################################

        public dynamic AbbreviateString(string paramValue, int maxCharCount)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, maxCharCount };
            return ComponentLoader.InvokeMethod(Strings, "Abbreviate", paramArgs);
        }

        public async Task<dynamic> AbbreviateStringAsync(string paramValue, int maxCharCount)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, maxCharCount };
            return await InvokeMethodAsync(Strings, "Abbreviate", paramArgs);
        }


        // CountOccurenceOfString
        // ####################################################################################

        public dynamic CountOccurenceOfString(string paramValue, string paramMatch)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramMatch };
            return ComponentLoader.InvokeMethod(Strings, "CountOccurenceOfString", paramArgs);
        }

        public async Task<dynamic> CountOccurenceOfStringAsync(string paramValue, string paramMatch)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramMatch };
            return await InvokeMethodAsync(Strings, "CountOccurenceOfString", paramArgs);
        }


        // CutString
        // ####################################################################################

        public dynamic CutString(string paramValue, int paramSize, StringDirection paramDirection)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramSize, paramDirection };
            return ComponentLoader.InvokeMethod(Strings, "CutString", paramArgs);
        }

        public async Task<dynamic> CutStringAsync(string paramValue, int paramSize, StringDirection paramDirection)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramSize, paramDirection };
            return await InvokeMethodAsync(Strings, "CutString", paramArgs);
        }


        // ExtractNumbers
        // ####################################################################################

        public dynamic ExtractNumbers(string paramValue, bool extractOnlyIntegers)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, extractOnlyIntegers };
            return ComponentLoader.InvokeMethod(Strings, "ExtractNumbers", paramArgs);
        }

        public async Task<dynamic> ExtractNumbersAsync(string paramValue, bool extractOnlyIntegers)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, extractOnlyIntegers };
            return await InvokeMethodAsync(Strings, "ExtractNumbers", paramArgs);
        }


        // GetWords
        // ####################################################################################

        public dynamic GetWords(string paramValue)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Strings, "GetWords", paramArgs);
        }

        public async Task<dynamic> GetWordsAsync(string paramValue)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Strings, "GetWords", paramArgs);
        }

        public dynamic GetWords(string paramValue, int paramMinLength)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramMinLength };
            return ComponentLoader.InvokeMethod(Strings, "GetWords", paramArgs);
        }

        public async Task<dynamic> GetWordsAsync(string paramValue, int paramMinLength)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramMinLength };
            return await InvokeMethodAsync(Strings, "GetWords", paramArgs);
        }


        // ReplaceString/Char
        // ####################################################################################

        public dynamic ReplaceString(string source, string find, string replacement, bool ignoreCase, int start, int count)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, find, replacement, ignoreCase, start, count };
            return ComponentLoader.InvokeMethod(Strings, "ReplaceString", paramArgs);
        }

        public async Task<dynamic> ReplaceStringAsync(string source, string find, string replacement, bool ignoreCase, int start, int count)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, find, replacement, ignoreCase, start, count };
            return await InvokeMethodAsync(Strings, "ReplaceString", paramArgs);
        }

        public dynamic ReplaceString(string source, string find, string replacement, bool ignoreCase)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, find, replacement, ignoreCase };
            return ComponentLoader.InvokeMethod(Strings, "ReplaceString", paramArgs);
        }

        public async Task<dynamic> ReplaceStringAsync(string source, string find, string replacement, bool ignoreCase)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, find, replacement, ignoreCase };
            return await InvokeMethodAsync(Strings, "ReplaceString", paramArgs);
        }

        public dynamic ReplaceString(string source, char ToReplace, char ReplaceWith)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, ToReplace, ReplaceWith };
            return ComponentLoader.InvokeMethod(Strings, "ReplaceString", paramArgs);
        }

        public async Task<dynamic> ReplaceStringAsync(string source, char ToReplace, char ReplaceWith)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, ToReplace, ReplaceWith };
            return await InvokeMethodAsync(Strings, "ReplaceString", paramArgs);
        }

        public dynamic ReplaceCharAt(string parmString, int parmPos, char parmChar)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { parmString, parmPos, parmChar };
            return ComponentLoader.InvokeMethod(Strings, "ReplaceCharAt", paramArgs);
        }

        public async Task<dynamic> ReplaceCharAtAsync(string parmString, int parmPos, char parmChar)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { parmString, parmPos, parmChar };
            return await InvokeMethodAsync(Strings, "ReplaceCharAt", paramArgs);
        }


        #endregion


    }

}
