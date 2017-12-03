// CommonComponentLoader.cs
//
// Author: Kay Stuckenschmidt <mailto.kaysta@gmail.com>
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
using System.Collections.Generic;
using System.IO;
using InMemoryLoader;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderCommon
{
    /// <summary>
    /// Common component loader.
    /// </summary>
    public sealed partial class CommonComponentLoader
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static ILog log = LogManager.GetLogger(typeof(CommonComponentLoader));

        /// <summary>
        /// The components.
        /// </summary>
        public Lazy<IList<IDynamicClassSetup>> Components;

        /// <summary>
        /// The string component.
        /// </summary>
        public IDynamicClassSetup StringComponent;
        /// <summary>
        /// The check component.
        /// </summary>
        public IDynamicClassSetup CheckComponent;
        /// <summary>
        /// The convert component.
        /// </summary>
        public IDynamicClassSetup ConvertComponent;
        /// <summary>
        /// The crypt component.
        /// </summary>
        public IDynamicClassSetup CryptComponent;
        /// <summary>
        /// The xml component.
        /// </summary>
        public IDynamicClassSetup XmlComponent;
        /// <summary>
        /// The date time component.
        /// </summary>
        public IDynamicClassSetup DateTimeComponent;
        /// <summary>
        /// The email component.
        /// </summary>
        public IDynamicClassSetup EmailComponent;
        /// <summary>
        /// The file system component.
        /// </summary>
        public IDynamicClassSetup FileSystemComponent;
        /// <summary>
        /// The get component.
        /// </summary>
        public IDynamicClassSetup GetComponent;

        /// <summary>
        /// The assembly path.
        /// </summary>
        private string assemblyPath;

        /// <summary>
        /// Gets or sets the assembly path.
        /// </summary>
        /// <value>The assembly path.</value>
        public string AssemblyPath
        {
            get
            {
                return assemblyPath;
            }

            set
            {
                assemblyPath = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:InMemoryLoaderCommon.CommonComponentLoader"/> class.
        /// </summary>
        public CommonComponentLoader()
        {
            if (Components == null)
            {
                Components = new Lazy<IList<IDynamicClassSetup>>();
            }
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

            log.Debug("Init Common Components");

            var compLoader = ComponentLoader.Instance;

            try
            {
                foreach (var component in Components.Value)
                {
                    object[] paramArgument = { AbstractPowerUpComponent.Key };
                    var init = compLoader.InvokeMethod(component.Assembly, component.Class, component.InitMethod, paramArgument);
                    log.DebugFormat("Assembly: {0}, Class: {1}, Is init: {2}", component.Assembly, component.Class, init);
                }
            }
            catch (Exception ex)
            {
                log.FatalFormat(ex.ToString());
            }

            compLoader.InitClassRegistry();

            return true;
        }

        /// <summary>
        /// Setups the common components.
        /// </summary>
        /// <returns><c>true</c>, if common components was setuped, <c>false</c> otherwise.</returns>
        /// <param name="paramPath">Parameter path.</param>
        private bool SetupCommonComponents(string paramPath)
        {
            if (!Components.IsValueCreated)
            {
                Components = new Lazy<IList<IDynamicClassSetup>>(() => new List<IDynamicClassSetup>());
            }

            if (string.IsNullOrEmpty(AssemblyPath))
            {
                AssemblyPath = paramPath;
            }

            if (StringComponent == null)
            {
                StringComponent = new DynamicClassSetup();
                StringComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpStringUtils.dll");
                StringComponent.Class = "StringUtils";
            }
            if (!Components.Value.Contains(StringComponent))
            {
                Components.Value.Add(StringComponent);
            }

            if (CheckComponent == null)
            {
                CheckComponent = new DynamicClassSetup();
                CheckComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpCheckUtils.dll");
                CheckComponent.Class = "CheckUtils";
            }
            if (!Components.Value.Contains(CheckComponent))
            {
                Components.Value.Add(CheckComponent);
            }

            if (ConvertComponent == null)
            {
                ConvertComponent = new DynamicClassSetup();
                ConvertComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpConvertUtils.dll");
                ConvertComponent.Class = "ConvertUtils";
            }
            if (!Components.Value.Contains(ConvertComponent))
            {
                Components.Value.Add(ConvertComponent);
            }

            if (CryptComponent == null)
            {
                CryptComponent = new DynamicClassSetup();
                CryptComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpCryptUtils.dll");
                CryptComponent.Class = "CryptUtils";
            }
            if (!Components.Value.Contains(CryptComponent))
            {
                Components.Value.Add(CryptComponent);
            }

            if (XmlComponent == null)
            {
                XmlComponent = new DynamicClassSetup();
                XmlComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpXmlUtils.dll");
                XmlComponent.Class = "XmlUtils";
            }
            if (!Components.Value.Contains(XmlComponent))
            {
                Components.Value.Add(XmlComponent);
            }

            if (DateTimeComponent == null)
            {
                DateTimeComponent = new DynamicClassSetup();
                DateTimeComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpDateTimeUtils.dll");
                DateTimeComponent.Class = "DateTimeUtils";
            }
            if (!Components.Value.Contains(DateTimeComponent))
            {
                Components.Value.Add(DateTimeComponent);
            }

            if (EmailComponent == null)
            {
                EmailComponent = new DynamicClassSetup();
                EmailComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpEmailUtils.dll");
                EmailComponent.Class = "EmailUtils";
            }
            if (!Components.Value.Contains(EmailComponent))
            {
                Components.Value.Add(EmailComponent);
            }

            if (FileSystemComponent == null)
            {
                FileSystemComponent = new DynamicClassSetup();
                FileSystemComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpFileSystemUtils.dll");
                FileSystemComponent.Class = "FileSystemUtils";
            }
            if (!Components.Value.Contains(FileSystemComponent))
            {
                Components.Value.Add(FileSystemComponent);
            }

            if (GetComponent == null)
            {
                GetComponent = new DynamicClassSetup();
                GetComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpGetUtils.dll");
                GetComponent.Class = "GetUtils";
            }
            if (!Components.Value.Contains(GetComponent))
            {
                Components.Value.Add(GetComponent);
            }
            return true;
        }
    }
}