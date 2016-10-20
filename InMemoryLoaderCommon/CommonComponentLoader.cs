using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using log4net;
using InMemoryLoader;
using InMemoryLoaderBase;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommon
{
    /// <summary>
    /// Component loader.
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
        /// Gets or sets the assembly path.
        /// </summary>
        /// <value>The assembly path.</value>
        public string assemblyPath
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerUpCommon.CommonComponentLoader"/> class.
        /// </summary>
        public CommonComponentLoader()
        {
            if (this.Components == null)
            {
                this.Components = new Lazy<IList<IDynamicClassSetup>>();
            }
        }

        /// <summary>
        /// Inits the common components.
        /// </summary>
        /// <returns><c>true</c>, if common components was inited, <c>false</c> otherwise.</returns>
        /// <param name="paramPath">Parameter path.</param>
        public bool InitCommonComponents(string paramPath)
        {
            if (string.IsNullOrEmpty(this.assemblyPath))
            {
                this.assemblyPath = paramPath;
            }

            SetupCommonComponents(this.assemblyPath);

            log.Debug("Init Common Components");

            var compLoader = ComponentLoader.Instance;

            try
            {
                foreach (var component in this.Components.Value)
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
            if (!this.Components.IsValueCreated)
            {
                this.Components = new Lazy<IList<IDynamicClassSetup>>(() => new List<IDynamicClassSetup>());
            }

            if (string.IsNullOrEmpty(this.assemblyPath))
            {
                this.assemblyPath = paramPath;
            }

            if (this.StringComponent == null)
            {
                this.StringComponent = new DynamicClassSetup();
                this.StringComponent.Assembly = Path.Combine(this.assemblyPath, "PowerUpStringUtils.dll");
                this.StringComponent.Class = "StringUtils";
            }
            if (!this.Components.Value.Contains(this.StringComponent))
            {
                this.Components.Value.Add(this.StringComponent);
            }

            if (this.CheckComponent == null)
            {
                this.CheckComponent = new DynamicClassSetup();
                this.CheckComponent.Assembly = Path.Combine(this.assemblyPath, "PowerUpCheckUtils.dll");
                this.CheckComponent.Class = "CheckUtils";
            }
            if (!this.Components.Value.Contains(this.CheckComponent))
            {
                this.Components.Value.Add(this.CheckComponent);
            }

            if (this.ConvertComponent == null)
            {
                this.ConvertComponent = new DynamicClassSetup();
                this.ConvertComponent.Assembly = Path.Combine(this.assemblyPath, "PowerUpConvertUtils.dll");
                this.ConvertComponent.Class = "ConvertUtils";
            }
            if (!this.Components.Value.Contains(this.ConvertComponent))
            {
                this.Components.Value.Add(this.ConvertComponent);
            }

            if (this.CryptComponent == null)
            {
                this.CryptComponent = new DynamicClassSetup();
                this.CryptComponent.Assembly = Path.Combine(this.assemblyPath, "PowerUpCryptUtils.dll");
                this.CryptComponent.Class = "CryptUtils";
            }
            if (!this.Components.Value.Contains(this.CryptComponent))
            {
                this.Components.Value.Add(this.CryptComponent);
            }

            if (this.XmlComponent == null)
            {
                this.XmlComponent = new DynamicClassSetup();
                this.XmlComponent.Assembly = Path.Combine(this.assemblyPath, "PowerUpXmlUtils.dll");
                this.XmlComponent.Class = "XmlUtils";
            }
            if (!this.Components.Value.Contains(this.XmlComponent))
            {
                this.Components.Value.Add(this.XmlComponent);
            }

            if (this.DateTimeComponent == null)
            {
                this.DateTimeComponent = new DynamicClassSetup();
                this.DateTimeComponent.Assembly = Path.Combine(this.assemblyPath, "PowerUpDateTimeUtils.dll");
                this.DateTimeComponent.Class = "DateTimeUtils";
            }
            if (!this.Components.Value.Contains(this.DateTimeComponent))
            {
                this.Components.Value.Add(this.DateTimeComponent);
            }

            if (this.EmailComponent == null)
            {
                this.EmailComponent = new DynamicClassSetup();
                this.EmailComponent.Assembly = Path.Combine(this.assemblyPath, "PowerUpEmailUtils.dll");
                this.EmailComponent.Class = "EmailUtils";
            }
            if (!this.Components.Value.Contains(this.EmailComponent))
            {
                this.Components.Value.Add(this.EmailComponent);
            }

            if (this.FileSystemComponent == null)
            {
                this.FileSystemComponent = new DynamicClassSetup();
                this.FileSystemComponent.Assembly = Path.Combine(this.assemblyPath, "PowerUpFileSystemUtils.dll");
                this.FileSystemComponent.Class = "FileSystemUtils";
            }
            if (!this.Components.Value.Contains(this.FileSystemComponent))
            {
                this.Components.Value.Add(this.FileSystemComponent);
            }

            if (this.GetComponent == null)
            {
                this.GetComponent = new DynamicClassSetup();
                this.GetComponent.Assembly = Path.Combine(this.assemblyPath, "PowerUpGetUtils.dll");
                this.GetComponent.Class = "GetUtils";
            }
            if (!this.Components.Value.Contains(this.GetComponent))
            {
                this.Components.Value.Add(this.GetComponent);
            }
            return true;
        }
    }
}

