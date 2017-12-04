//
// AbstractApplicationBase.cs
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
        static readonly ILog Log = LogManager.GetLogger(typeof(AbstractCommonBase));

        /// <summary>
        /// Gets or sets the common component loader.
        /// </summary>
        /// <value>The common component loader.</value>
        public CommonComponentLoader CommonComponentLoader { get; set; }

        /// <summary>
        /// Gets the check utils.
        /// </summary>
        /// <value>The check utils.</value>
        public IDynamicClassInfo CheckUtils
        {
            get
            {
                return base.ComponentLoader.ComponentRegistry.SingleOrDefault (str => str.Key.Class.EndsWith ("CheckUtils", System.StringComparison.CurrentCulture)).Value;
            }
        }

        /// <summary>
        /// Gets the convert utils.
        /// </summary>
        /// <value>The convert utils.</value>
        public IDynamicClassInfo ConvertUtils
        {
            get
            {
				return base.ComponentLoader.ComponentRegistry.SingleOrDefault (str => str.Key.Class.EndsWith ("ConvertUtils", System.StringComparison.CurrentCulture)).Value;
            }
        }

        /// <summary>
        /// Gets the crypt utils.
        /// </summary>
        /// <value>The crypt utils.</value>
        public IDynamicClassInfo CryptUtils
        {
            get
            {
                return base.ComponentLoader.ComponentRegistry.SingleOrDefault (str => str.Key.Class.EndsWith ("CryptUtils", System.StringComparison.CurrentCulture)).Value;
            }
        }

        /// <summary>
        /// Gets the date time utils.
        /// </summary>
        /// <value>The date time utils.</value>
        public IDynamicClassInfo DateTimeUtils
        {
            get
            {
                return base.ComponentLoader.ComponentRegistry.SingleOrDefault (str => str.Key.Class.EndsWith ("DateTimeUtils", System.StringComparison.CurrentCulture)).Value;
            }
        }

        /// <summary>
        /// Gets the email utils.
        /// </summary>
        /// <value>The email utils.</value>
        public IDynamicClassInfo EmailUtils
        {
            get
            {
                return base.ComponentLoader.ComponentRegistry.SingleOrDefault (str => str.Key.Class.EndsWith ("EmailUtils", System.StringComparison.CurrentCulture)).Value;
            }
        }

        /// <summary>
        /// Gets the file system utils.
        /// </summary>
        /// <value>The file system utils.</value>
        public IDynamicClassInfo FileSystemUtils
        {
            get
            {
                return base.ComponentLoader.ComponentRegistry.SingleOrDefault (str => str.Key.Class.EndsWith ("FileSystemUtils", System.StringComparison.CurrentCulture)).Value;
            }
        }

        /// <summary>
        /// Gets the get utils.
        /// </summary>
        /// <value>The get utils.</value>
        public IDynamicClassInfo GetUtils
        {
            get
            {
                return base.ComponentLoader.ComponentRegistry.SingleOrDefault (str => str.Key.Class.EndsWith ("GetUtils", System.StringComparison.CurrentCulture)).Value;
            }
        }

        /// <summary>
        /// Gets the string utils.
        /// </summary>
        /// <value>The string utils.</value>
        public IDynamicClassInfo StringUtils
        {
            get
            {
                return base.ComponentLoader.ComponentRegistry.SingleOrDefault (str => str.Key.Class.EndsWith ("StringUtils", System.StringComparison.CurrentCulture)).Value;
            }
        }

        /// <summary>
        /// Gets the xml utils.
        /// </summary>
        /// <value>The xml utils.</value>
        public IDynamicClassInfo XmlUtils
        {
            get
            {
                return base.ComponentLoader.ComponentRegistry.SingleOrDefault (str => str.Key.Class.EndsWith ("XmlUtils", System.StringComparison.CurrentCulture)).Value;
            }
        }

        /// <summary>
        /// Sets the in memory loader common.
        /// </summary>
        /// <returns><c>true</c>, if in memory loader common was set, <c>false</c> otherwise.</returns>
        public virtual bool SetInMemoryLoaderCommon()
        {
            CommonComponentLoader = new CommonComponentLoader();
            var isSet = CommonComponentLoader.InitCommonComponents(base.AssemblyPath);
            Log.DebugFormat("CommonComponentLoader set: {0}", isSet);
            return true;
        }

    }

}