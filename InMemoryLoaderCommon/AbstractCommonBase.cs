//
// AbstractApplicationBase.cs
//
// Author: Kay Stuckenschmidt
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

using System.Threading.Tasks;
using InMemoryLoader;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderCommon
{
    public abstract class AbstractCommonBase : AbstractLoaderBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AbstractCommonBase));

        public CommonComponentLoader CommonComponentLoader { get; set; }

        public virtual bool SetInMemoryLoaderCommon()
        {
            CommonComponentLoader = new CommonComponentLoader();
            var isSet = CommonComponentLoader.InitCommonComponents(base.AssemblyPath);
            Log.DebugFormat("CommonComponentLoader set: {0}", isSet);
            return isSet;
        }

        public virtual async Task<bool> SetInMemoryLoaderCommonAsync()
        {
            CommonComponentLoader = new CommonComponentLoader();
            var isSet = await CommonComponentLoader.InitCommonComponentsAsync(base.AssemblyPath);
            Log.DebugFormat("CommonComponentLoader set: {0}", isSet);
            return isSet;
        }

        IDynamicClassInfo Converter;
        private void SetConverter()
        {
            if (Converter == null) Converter = ComponentLoader.GetClassReference("Converter");
        }

        public bool StringToBoolean(string paramString)
        {
            SetConverter();
            object[] paramArgs = { paramString };
            return ComponentLoader.InvokeMethod(Converter, "StringToBoolean", paramArgs);
        }

        public async Task<bool> StringToBooleanAsync(string paramString)
        {
            SetConverter();
            object[] paramArgs = { paramString };
            return await InvokeMethodAsync(Converter, "StringToBoolean", paramArgs);
        }





    }

}