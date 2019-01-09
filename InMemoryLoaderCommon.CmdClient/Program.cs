//
// Program.cs
//
// Author: Kay Stuckenschmidt <kay@responsive-it.biz>
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
using System.Threading.Tasks;
using log4net;

namespace InMemoryLoaderCommon.CmdClient
{
    class MainClass
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainClass));

        private static readonly ApplicationBase AppBase = ApplicationBase.Instance;

        public static async Task Main(string[] args)
        {
            #region start/init

            var parameter = string.Empty;

            if (args.Length == 0)
            {
                parameter = "null";
            }
            else
            {
                parameter = args[0];
            }

            Log.InfoFormat("{0}", "Start InMemoryLoaderCommon.CmdCLient");

            // Init common components
            var isCommonInit = await AppBase.SetInMemoryLoaderCommonAsync();
            Log.InfoFormat("SetInMemoryLoaderCommonAsync [{0}]", isCommonInit);

            #endregion

            // Converter stuff --------------------------------------------------------------------
            // ####################################################################################

            // StringToBoolean
            // ####################################################################################

            var stringToBoolean = AppBase.StringToBoolean("1");
            Log.InfoFormat("StringToBoolean [{0}]", stringToBoolean);

            var stringToBooleanAsync = await AppBase.StringToBooleanAsync("0");
            Log.InfoFormat("StringToBooleanAsync [{0}]", stringToBooleanAsync);

            // CharToBoolean
            // ####################################################################################

            var charToBoolean = AppBase.CharToBoolean('1');
            Log.InfoFormat("CharToBoolean [{0}]", charToBoolean);

            var charToBooleanAsync = await AppBase.CharToBooleanAsync('0');
            Log.InfoFormat("CharToBooleanAsync [{0}]", charToBooleanAsync);


            // BooleanToString
            // ####################################################################################

            var booleanToString = AppBase.BooleanToString(false);
            Log.InfoFormat("BooleanToString [{0}]", booleanToString);

            var booleanToStringAsync = await AppBase.BooleanToStringAsync(true);
            Log.InfoFormat("BooleanToStringAsync [{0}]", booleanToStringAsync);


            // BooleanToChar
            // ####################################################################################

            var booleanToChar = AppBase.BooleanToChar(false);
            Log.InfoFormat("BooleanToChar [{0}]", booleanToChar);

            var booleanToCharAsync = await AppBase.BooleanToCharAsync(true);
            Log.InfoFormat("BooleanToCharAsync [{0}]", booleanToCharAsync);


            // StringToByteArray
            // ####################################################################################

            var stringToByteArray = (byte[])AppBase.StringToByteArray("0815");
            Log.InfoFormat("StringToByteArray [{0}]", stringToByteArray.Length);

            var stringToByteArrayAsync = (byte[])await AppBase.StringToByteArrayAsync("0815");
            Log.InfoFormat("StringToByteArrayAsync [{0}]", stringToByteArrayAsync.Length);

            var stringToByteArray2 = (byte[])AppBase.StringToByteArray("0815", Encoding.UTF8);
            Log.InfoFormat("StringToByteArray [{0}]", stringToByteArray2.Length);

            var stringToByteArrayAsync2 = (byte[])await AppBase.StringToByteArrayAsync("0815", Encoding.UTF8);
            Log.InfoFormat("StringToByteArrayAsync [{0}]", stringToByteArrayAsync2.Length);


            // StringToHashtable
            // ####################################################################################

            var toHashTable = "0=1|1=2|2=3";
            char toHashTableFelimiter = '|';

            var stringToHashtable = AppBase.StringToHashtable(toHashTable, toHashTableFelimiter);
            Log.InfoFormat("StringToHashtable [{0}]", stringToHashtable[0]);

            var stringToHashtableAsync = await AppBase.StringToHashtableAsync(toHashTable, toHashTableFelimiter);
            Log.InfoFormat("StringToHashtableAsync [{0}]", stringToHashtableAsync[0]);


            // MemoryStreamToString
            // ####################################################################################

            var memoryStream = new MemoryStream(stringToByteArray2);

            var memoryStreamToString = AppBase.MemoryStreamToString(memoryStream);
            Log.InfoFormat("MemoryStreamToString [{0}]", memoryStreamToString);

            var memoryStreamToStringAsync = await AppBase.MemoryStreamToStringAsync(memoryStream);
            Log.InfoFormat("MemoryStreamToStringAsync [{0}]", memoryStreamToStringAsync);


            // ByteArrayToString
            // ####################################################################################

            var byteArrayToString1 = AppBase.ByteArrayToString(stringToByteArray2);
            Log.InfoFormat("ByteArrayToString [{0}]", byteArrayToString1);

            var byteArrayToStringAsync1 = await AppBase.ByteArrayToStringAsync(stringToByteArray2);
            Log.InfoFormat("ByteArrayToStringAsync [{0}]", byteArrayToStringAsync1);

            var byteArrayToString2 = AppBase.ByteArrayToString(stringToByteArray2, Encoding.UTF8);
            Log.InfoFormat("ByteArrayToString [{0}]", byteArrayToString2);

            var byteArrayToStringAsync2 = await AppBase.ByteArrayToStringAsync(stringToByteArray2, Encoding.UTF8);
            Log.InfoFormat("ByteArrayToStringAsync [{0}]", byteArrayToStringAsync2);


            // StringFromUtf8ToAscii
            // ####################################################################################

            var stringFromUtf8ToAscii = AppBase.StringFromUtf8ToAscii("0815 - 123698");
            Log.InfoFormat("StringFromUtf8ToAscii [{0}]", stringFromUtf8ToAscii);

            var stringFromUtf8ToAsciiAsync = await AppBase.StringFromUtf8ToAsciiAsync("0815 - 123698");
            Log.InfoFormat("StringFromUtf8ToAsciiAsync [{0}]", stringFromUtf8ToAsciiAsync);


            // StringFromUtf8ToLatin1
            // ####################################################################################

            var stringFromUtf8ToLatin1 = AppBase.StringFromUtf8ToLatin1("0815 - 123698");
            Log.InfoFormat("StringFromUtf8ToLatin1 [{0}]", stringFromUtf8ToLatin1);

            var stringFromUtf8ToLatin1Async = await AppBase.StringFromUtf8ToLatin1Async("0815 - 123698");
            Log.InfoFormat("StringFromUtf8ToLatin1Async [{0}]", stringFromUtf8ToLatin1Async);


            // Crypt stuff ------------------------------------------------------------------------
            // ####################################################################################

            // Md5Encryption
            // ####################################################################################

            var md5Encryption = (byte[])AppBase.Md5Encryption("0815 - 123698");
            Log.InfoFormat("Md5Encryption [{0}]", md5Encryption.Length);

            var md5EncryptionAsync = (byte[])await AppBase.Md5EncryptionAsync("0815 - 123698");
            Log.InfoFormat("Md5EncryptionAsync [{0}]", md5EncryptionAsync.Length);

            var md5SaltedHashEncryption = (byte[])AppBase.Md5SaltedHashEncryption("0815 - 123698");
            Log.InfoFormat("Md5SaltedHashEncryption [{0}]", md5SaltedHashEncryption.Length);

            var md5SaltedHashEncryptionAsync = (byte[])await AppBase.Md5SaltedHashEncryptionAsync("0815 - 123698");
            Log.InfoFormat("Md5SaltedHashEncryptionAsync [{0}]", md5SaltedHashEncryptionAsync.Length);

            var getMd5HashAsString = AppBase.GetMd5HashAsString("0815 - 123698");
            Log.InfoFormat("GetMd5HashAsString [{0}]", getMd5HashAsString.Length);

            var getMd5HashAsStringAsync = await AppBase.GetMd5HashAsStringAsync("0815 - 123698");
            Log.InfoFormat("GetMd5HashAsStringAsync [{0}]", getMd5HashAsStringAsync.Length);


            // RijndaelManaged
            // ####################################################################################

            var setCryptoParameter = AppBase.SetCryptoParameter("nEed!som_p", "s@lTe!lOl", "SHA1", 2, "!VaCztorR=qw712_X<>", 256);
            Log.InfoFormat("SetCryptoParameter [{0}]", setCryptoParameter);

            var encrypt = AppBase.Encrypt("tHa_Pwd0815!");
            Log.InfoFormat("Encrypt [{0}]", encrypt);

            var decrypt = AppBase.Decrypt(encrypt);
            Log.InfoFormat("Decrypt [{0}]", decrypt);


            var setCryptoParameterAsync = await AppBase.SetCryptoParameterAsync("nEed!som_p", "s@lTe!lOl", "SHA1", 2, "!VaCztorR=qw712_X<>", 256);
            Log.InfoFormat("SetCryptoParameterAsync [{0}]", setCryptoParameterAsync);

            var encryptAsync = await AppBase.EncryptAsync("tHa_Pwd0815!");
            Log.InfoFormat("EncryptAsync [{0}]", encryptAsync);

            var decryptAsync = await AppBase.DecryptAsync(encryptAsync);
            Log.InfoFormat("DecryptAsync [{0}]", decryptAsync);






            Log.InfoFormat("{0}", "End InMemoryLoaderCommon.CmdCLient");
            // Console.Read();

        }

    }

}
