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

            var stringToBoolean = AppBase.StringToBoolean("1");
            Log.InfoFormat("StringToBoolean [{0}]", stringToBoolean);

            var stringToBooleanAsync = await AppBase.StringToBooleanAsync("0");
            Log.InfoFormat("StringToBooleanAsync [{0}]", stringToBooleanAsync);


            var charToBoolean = AppBase.CharToBoolean('1');
            Log.InfoFormat("CharToBoolean [{0}]", charToBoolean);

            var charToBooleanAsync = await AppBase.CharToBooleanAsync('0');
            Log.InfoFormat("CharToBooleanAsync [{0}]", charToBooleanAsync);


            var booleanToString = AppBase.BooleanToString(false);
            Log.InfoFormat("BooleanToString [{0}]", booleanToString);

            var booleanToStringAsync = await AppBase.BooleanToStringAsync(true);
            Log.InfoFormat("BooleanToStringAsync [{0}]", booleanToStringAsync);


            var booleanToChar = AppBase.BooleanToChar(false);
            Log.InfoFormat("BooleanToChar [{0}]", booleanToChar);

            var booleanToCharAsync = await AppBase.BooleanToCharAsync(true);
            Log.InfoFormat("BooleanToCharAsync [{0}]", booleanToCharAsync);


            var stringToByteArray = (byte[])AppBase.StringToByteArray("0815");
            Log.InfoFormat("StringToByteArray [{0}]", stringToByteArray.Length);

            var stringToByteArrayAsync = (byte[])await AppBase.StringToByteArrayAsync("0815");
            Log.InfoFormat("StringToByteArrayAsync [{0}]", stringToByteArrayAsync.Length);

            var stringToByteArray2 = (byte[])AppBase.StringToByteArray("0815", Encoding.Default);
            Log.InfoFormat("StringToByteArray [{0}]", stringToByteArray2.Length);

            var stringToByteArrayAsync2 = (byte[])await AppBase.StringToByteArrayAsync("0815", Encoding.Default);
            Log.InfoFormat("StringToByteArrayAsync [{0}]", stringToByteArrayAsync2.Length);


            var toHashTable = "0=1|1=2|2=3";
            char toHashTableFelimiter = '|';

            var stringToHashtable = AppBase.StringToHashtable(toHashTable, toHashTableFelimiter);
            Log.InfoFormat("StringToHashtable [{0}]", stringToHashtable);

            var stringToHashtableAsync = await AppBase.StringToHashtableAsync(toHashTable, toHashTableFelimiter);
            Log.InfoFormat("StringToHashtableAsync [{0}]", stringToHashtableAsync);




            Log.InfoFormat("{0}", "End InMemoryLoaderCommon.CmdCLient");
            // Console.Read();

        }

    }

}
