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

using System.Linq;
using InMemoryLoader;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderCommon
{
    /// <summary>
    /// AbstractCommonBase
    /// </summary>
    public abstract class AbstractCommonBase : AbstractLoaderBase
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(AbstractCommonBase));

        /// <summary>
        /// Gets or sets the common component loader.
        /// </summary>
        /// <value>The common component loader.</value>
        public CommonComponentLoader CommonComponentLoader { get; set; }

        /// <summary>
        /// Sets the in memory loader common.
        /// </summary>
        /// <returns><c>true</c>, if in memory loader common was set, <c>false</c> otherwise.</returns>
        public virtual bool SetInMemoryLoaderCommon()
        {
            CommonComponentLoader = new CommonComponentLoader();
            var isSet = CommonComponentLoader.InitCommonComponents(base.AssemblyPath);
            Log.DebugFormat("CommonComponentLoader set: {0}", isSet);
            return isSet;
        }

    }

}