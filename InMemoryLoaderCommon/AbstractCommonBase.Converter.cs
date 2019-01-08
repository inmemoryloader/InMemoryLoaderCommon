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

        #region Converter

        IDynamicClassInfo Converter;

        private void SetConverter()
        {
            if (Converter == null) Converter = ComponentLoader.GetClassReference("Converter");
        }


        public dynamic StringToBoolean(string paramValue)
        {
            SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "StringToBoolean", paramArgs);
        }

        public async Task<dynamic> StringToBooleanAsync(string paramValue)
        {
            SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "StringToBoolean", paramArgs);
        }


        public dynamic CharToBoolean(char paramValue)
        {
            SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "CharToBoolean", paramArgs);
        }

        public async Task<dynamic> CharToBooleanAsync(char paramValue)
        {
            SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "CharToBoolean", paramArgs);
        }


        public dynamic BooleanToString(bool paramValue)
        {
            SetConverter();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Converter, "BooleanToString", paramArgs);
        }

        public async Task<dynamic> BooleanToStringAsync(bool paramValue)
        {
            SetConverter();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Converter, "BooleanToString", paramArgs);
        }




        #endregion

    }

}
