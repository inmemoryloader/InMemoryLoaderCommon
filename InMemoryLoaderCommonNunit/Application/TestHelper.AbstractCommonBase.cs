//
// TestHelper.AbstractCommonBase.cs
//
// Author: responsive kaysta <me@responsive-kaysta.ch>
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
using InMemoryLoaderCommon;

namespace Application
{
    internal partial class TestHelper: AbstractCommonBase
    {
        /// <summary>
        /// GetAssemblyPath_Test
        /// </summary>
        /// <returns><c>true</c>, if assembly path test was gotten, <c>false</c> otherwise.</returns>
        internal bool GetAssemblyPath_Test()
        {
            var path = base.GetAssemblyPath();
            bool isSet = false || !string.IsNullOrEmpty(path);
            return isSet;
        }

        /// <summary>
        /// SetCulture_Test
        /// </summary>
        /// <returns><c>true</c>, if culture test was set, <c>false</c> otherwise.</returns>
        internal bool SetCulture_Test()
        {
            return base.SetCulture();
        }

        /// <summary>
        /// SetInMemoryLoader_Test
        /// </summary>
        /// <returns><c>true</c>, if in memory loader test was set, <c>false</c> otherwise.</returns>
        internal bool SetInMemoryLoader_Test()
        {
            return base.SetInMemoryLoader();
        }

        /// <summary>
        /// SetClassRegistry_Test
        /// </summary>
        /// <returns><c>true</c>, if class registry test was set, <c>false</c> otherwise.</returns>
        internal bool SetClassRegistry_Test()
        {
            return base.SetClassRegistry();
        }

        /// <summary>
        /// SetInMemoryLoaderCommon_Test
        /// </summary>
        /// <returns><c>true</c>, if in memory loader common test was set, <c>false</c> otherwise.</returns>
        internal bool SetInMemoryLoaderCommon_Test()
        {
            return base.SetInMemoryLoaderCommon();
        }

        /// <summary>
        /// CommonsUtils test.
        /// </summary>
        /// <returns><c>true</c>, if utils test was commoned, <c>false</c> otherwise.</returns>
        internal bool CommonUtils_Test()
        {
            bool isSet = false;
            isSet = base.ConvertUtils != null;
            isSet = base.CryptUtils != null;
            isSet = base.DateTimeUtils != null;
            isSet = base.EmailUtils != null;
            isSet = base.FileSystemUtils != null;
            isSet = base.GetUtils != null;
            isSet = base.StringUtils != null;
            isSet = base.XmlUtils != null;
            return isSet;
        }

    }

}