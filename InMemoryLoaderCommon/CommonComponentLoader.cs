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
        static ILog Log = LogManager.GetLogger(typeof(CommonComponentLoader));

        /// <summary>
        /// The components.
        /// </summary>
        public Lazy<IList<IDynamicClassSetup>> Components;

        /// <summary>
        /// The string component.
        /// </summary>
        IDynamicClassSetup _stringComponent;
        /// <summary>
        /// The check component.
        /// </summary>
        IDynamicClassSetup _checkComponent;
        /// <summary>
        /// The convert component.
        /// </summary>
        IDynamicClassSetup _convertComponent;
        /// <summary>
        /// The crypt component.
        /// </summary>
        IDynamicClassSetup _cryptComponent;
        /// <summary>
        /// The xml component.
        /// </summary>
        IDynamicClassSetup _xmlComponent;
        /// <summary>
        /// The date time component.
        /// </summary>
        IDynamicClassSetup _dateTimeComponent;
        /// <summary>
        /// The email component.
        /// </summary>
        IDynamicClassSetup _emailComponent;
        /// <summary>
        /// The file system component.
        /// </summary>
        IDynamicClassSetup _fileSystemComponent;
        /// <summary>
        /// The get component.
        /// </summary>
        IDynamicClassSetup _getComponent;

        /// <summary>
        /// Gets or sets the assembly path.
        /// </summary>
        /// <value>The assembly path.</value>
        public string AssemblyPath
        {
            get;
            set;
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

            Log.Debug("Init Common Components");

            var compLoader = ComponentLoader.Instance;

            try
            {
                foreach (var component in Components.Value)
                {
                    object[] paramArgument = { AbstractPowerUpComponent.Key };
                    var init = compLoader.InvokeMethod(component.Assembly, component.Class, component.InitMethod, paramArgument);
                    Log.DebugFormat("Assembly: {0}, Class: {1}, Is init: {2}", component.Assembly, component.Class, init);
                }
            }
            catch (Exception ex)
            {
                Log.FatalFormat(ex.ToString());
            }

            compLoader.InitClassRegistry();

            return true;
        }

        /// <summary>
        /// Setups the common components.
        /// </summary>
        /// <returns><c>true</c>, if common components was setuped, <c>false</c> otherwise.</returns>
        /// <param name="paramPath">Parameter path.</param>
        bool SetupCommonComponents(string paramPath)
        {
            if (!Components.IsValueCreated)
            {
                Components = new Lazy<IList<IDynamicClassSetup>>(() => new List<IDynamicClassSetup>());
            }

            if (string.IsNullOrEmpty(AssemblyPath))
            {
                AssemblyPath = paramPath;
            }

            if (_stringComponent == null)
            {
                _stringComponent = new DynamicClassSetup();
                _stringComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpStringUtils.dll");
                _stringComponent.Class = "StringUtils";
            }
            if (!Components.Value.Contains(_stringComponent))
            {
                Components.Value.Add(_stringComponent);
            }

            if (_checkComponent == null)
            {
                _checkComponent = new DynamicClassSetup();
                _checkComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpCheckUtils.dll");
                _checkComponent.Class = "CheckUtils";
            }
            if (!Components.Value.Contains(_checkComponent))
            {
                Components.Value.Add(_checkComponent);
            }

            if (_convertComponent == null)
            {
                _convertComponent = new DynamicClassSetup();
                _convertComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpConvertUtils.dll");
                _convertComponent.Class = "ConvertUtils";
            }
            if (!Components.Value.Contains(_convertComponent))
            {
                Components.Value.Add(_convertComponent);
            }

            if (_cryptComponent == null)
            {
                _cryptComponent = new DynamicClassSetup();
                _cryptComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpCryptUtils.dll");
                _cryptComponent.Class = "CryptUtils";
            }
            if (!Components.Value.Contains(_cryptComponent))
            {
                Components.Value.Add(_cryptComponent);
            }

            if (_xmlComponent == null)
            {
                _xmlComponent = new DynamicClassSetup();
                _xmlComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpXmlUtils.dll");
                _xmlComponent.Class = "XmlUtils";
            }
            if (!Components.Value.Contains(_xmlComponent))
            {
                Components.Value.Add(_xmlComponent);
            }

            if (_dateTimeComponent == null)
            {
                _dateTimeComponent = new DynamicClassSetup();
                _dateTimeComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpDateTimeUtils.dll");
                _dateTimeComponent.Class = "DateTimeUtils";
            }
            if (!Components.Value.Contains(_dateTimeComponent))
            {
                Components.Value.Add(_dateTimeComponent);
            }

            if (_emailComponent == null)
            {
                _emailComponent = new DynamicClassSetup();
                _emailComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpEmailUtils.dll");
                _emailComponent.Class = "EmailUtils";
            }
            if (!Components.Value.Contains(_emailComponent))
            {
                Components.Value.Add(_emailComponent);
            }

            if (_fileSystemComponent == null)
            {
                _fileSystemComponent = new DynamicClassSetup();
                _fileSystemComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpFileSystemUtils.dll");
                _fileSystemComponent.Class = "FileSystemUtils";
            }
            if (!Components.Value.Contains(_fileSystemComponent))
            {
                Components.Value.Add(_fileSystemComponent);
            }

            if (_getComponent == null)
            {
                _getComponent = new DynamicClassSetup();
                _getComponent.Assembly = Path.Combine(AssemblyPath, "PowerUpGetUtils.dll");
                _getComponent.Class = "GetUtils";
            }
            if (!Components.Value.Contains(_getComponent))
            {
                Components.Value.Add(_getComponent);
            }
            return true;
        }
    }
}