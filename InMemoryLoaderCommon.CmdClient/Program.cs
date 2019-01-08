﻿//
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
using System.Threading.Tasks;
using log4net;

namespace InMemoryLoaderCommon.CmdClient
{
    class MainClass
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainClass));

        private static readonly ApplicationBase AppBase = ApplicationBase.Instance;

        public static async Task Main (string [] args)
        {
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





            Log.InfoFormat("{0}", "End InMemoryLoaderCommon.CmdCLient");
            Console.Read();
        }

    }

}
