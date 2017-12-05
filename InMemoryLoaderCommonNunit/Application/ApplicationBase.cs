//
// ApplicationBase.cs
//
// Author: responsive it <>
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
using log4net;

namespace Application
{
    /// <summary>
    /// Application base.
    /// </summary>
    internal sealed class ApplicationBase
    {
        /// <summary>
        /// The log.
        /// </summary>
        static readonly ILog log = LogManager.GetLogger(typeof(ApplicationBase));

        /// <summary>
        /// The instance.
        /// </summary>
        static volatile ApplicationBase instance;

        /// <summary>
        /// The sync root.
        /// </summary>
        static readonly object syncRoot = new Object();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        internal static ApplicationBase Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ApplicationBase();
                            log.DebugFormat("Create a new instance of Type: {0}", instance.GetType().ToString());
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Application.ApplicationBase"/> class.
        /// </summary>
        private ApplicationBase()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

    }

}