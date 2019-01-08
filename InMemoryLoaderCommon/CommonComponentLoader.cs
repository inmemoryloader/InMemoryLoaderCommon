// CommonComponentLoader.cs
//
// Author: Kay Stuckenschmidt
//
// Copyright (c) 2017 responsive-kaysta
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
using InMemoryLoader;
using log4net;

namespace InMemoryLoaderCommon
{
    /// <summary>
    /// Common component loader.
    /// </summary>
    public sealed class CommonComponentLoader
    {
        /// <summary>
        /// The log.
        /// </summary>
        static readonly ILog Log = LogManager.GetLogger(typeof(CommonComponentLoader));

        /// <summary>
        /// Gets or sets the assembly path.
        /// </summary>
        /// <value>The assembly path.</value>
        public string AssemblyPath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:InMemoryLoaderCommon.CommonComponentLoader"/> class.
        /// </summary>
        public CommonComponentLoader()
        {
            
        }

        /// <summary>
        /// Inits the common components.
        /// </summary>
        /// <returns><c>true</c>, if common components was inited, <c>false</c> otherwise.</returns>
        /// <param name="paramPath">Parameter path.</param>
        public bool InitCommonComponents(string paramPath)
        {
            if (string.IsNullOrEmpty(AssemblyPath))
            {
                AssemblyPath = paramPath;
            }

            SetupCommonComponents(AssemblyPath);
            Log.Debug("Init Common Components");
            var compLoader = ComponentLoader.Instance;

            try
            {
                /*
                foreach (var component in Components.Value)
                {
                    object[] paramArgument = { AbstractComponent.Key };
                    var init = compLoader.InvokeMethod(component.Assembly, component.Class, component.InitMethod, paramArgument);
                    Log.DebugFormat("Assembly: {0}, Class: {1}, Is init: {2}", component.Assembly, component.Class, init);
                }
                */
            }
            catch (Exception ex)
            {
                Log.FatalFormat(ex.ToString());
            }

            var isSet = compLoader.InitClassRegistry();
            return isSet;
        }

        /// <summary>
        /// Setups the common components.
        /// </summary>
        /// <returns><c>true</c>, if common components was setuped, <c>false</c> otherwise.</returns>
        /// <param name="paramPath">Parameter path.</param>
        void SetupCommonComponents(string paramPath)
        {
            
        }

    }

}