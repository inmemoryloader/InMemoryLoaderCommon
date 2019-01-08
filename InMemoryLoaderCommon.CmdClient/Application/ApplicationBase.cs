//
// ApplicationBase.cs
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
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using InMemoryLoader;
using InMemoryLoaderBase;
using log4net;
using log4net.Config;

namespace InMemoryLoaderCommon.CmdClient
{
    internal sealed class ApplicationBase : AbstractCommonBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ApplicationBase));
        private static readonly object SyncRoot = new object();
        private static readonly ComponentLoader CompLoader = ComponentLoader.Instance;

        private static volatile ApplicationBase _instance;

        private ApplicationBase()
        {
            XmlConfigurator.Configure();

            base.ConsoleCulture = ConfigurationManager.AppSettings["System.Culture"];

            var exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            AssemblyPath = exePath;

            SetCulture();
            SetInMemoryLoader();
            SetInMemoryLoaderCommon();

            Log.InfoFormat("Create a new instance of Type: {0}", GetType());
        }

        internal static ApplicationBase Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null) _instance = new ApplicationBase();
                }
                return _instance;
            }
        }


        private dynamic AsyncWrapper(IDynamicClassInfo classObject, string paramObject, object[] paramArgs)
        {
            if (string.IsNullOrEmpty(paramObject)) throw new ArgumentException();
            return Task.Run(() => CompLoader.InvokeMethod(classObject, paramObject, paramArgs));
        }

        internal async Task<dynamic> SomeCallAsync(string argument)
        {
            object[] paramArgs = { "argument" };
            IDynamicClassInfo dynamicClass = new DynamicClassInfo();
            var result = await AsyncWrapper(dynamicClass, string.Empty, paramArgs);
            return result;
        }
    }
}
