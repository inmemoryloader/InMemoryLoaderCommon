using System;
using System.Collections.Generic;
using System.IO;
using InMemoryLoader;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderCommon
{
	public sealed partial class CommonComponentLoader
    {
        private static ILog log = LogManager.GetLogger(typeof(CommonComponentLoader));

        public Lazy<IList<IDynamicClassSetup>> Components;

        public IDynamicClassSetup StringComponent;

        public IDynamicClassSetup CheckComponent;

        public IDynamicClassSetup ConvertComponent;

        public IDynamicClassSetup CryptComponent;

        public IDynamicClassSetup XmlComponent;

        public IDynamicClassSetup DateTimeComponent;

        public IDynamicClassSetup EmailComponent;

        public IDynamicClassSetup FileSystemComponent;

        public IDynamicClassSetup GetComponent;

		private string assemblyPath;

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

		public CommonComponentLoader()
        {
            if (this.Components == null)
            {
                this.Components = new Lazy<IList<IDynamicClassSetup>>();
            }
        }

        public bool InitCommonComponents(string paramPath)
        {
            if (string.IsNullOrEmpty(this.AssemblyPath))
            {
                this.AssemblyPath = paramPath;
            }

            SetupCommonComponents(this.AssemblyPath);

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

        private bool SetupCommonComponents(string paramPath)
        {
            if (!this.Components.IsValueCreated)
            {
                this.Components = new Lazy<IList<IDynamicClassSetup>>(() => new List<IDynamicClassSetup>());
            }

            if (string.IsNullOrEmpty(this.AssemblyPath))
            {
                this.AssemblyPath = paramPath;
            }

            if (this.StringComponent == null)
            {
                this.StringComponent = new DynamicClassSetup();
                this.StringComponent.Assembly = Path.Combine(this.AssemblyPath, "PowerUpStringUtils.dll");
                this.StringComponent.Class = "StringUtils";
            }
            if (!this.Components.Value.Contains(this.StringComponent))
            {
                this.Components.Value.Add(this.StringComponent);
            }

            if (this.CheckComponent == null)
            {
                this.CheckComponent = new DynamicClassSetup();
                this.CheckComponent.Assembly = Path.Combine(this.AssemblyPath, "PowerUpCheckUtils.dll");
                this.CheckComponent.Class = "CheckUtils";
            }
            if (!this.Components.Value.Contains(this.CheckComponent))
            {
                this.Components.Value.Add(this.CheckComponent);
            }

            if (this.ConvertComponent == null)
            {
                this.ConvertComponent = new DynamicClassSetup();
                this.ConvertComponent.Assembly = Path.Combine(this.AssemblyPath, "PowerUpConvertUtils.dll");
                this.ConvertComponent.Class = "ConvertUtils";
            }
            if (!this.Components.Value.Contains(this.ConvertComponent))
            {
                this.Components.Value.Add(this.ConvertComponent);
            }

            if (this.CryptComponent == null)
            {
                this.CryptComponent = new DynamicClassSetup();
                this.CryptComponent.Assembly = Path.Combine(this.AssemblyPath, "PowerUpCryptUtils.dll");
                this.CryptComponent.Class = "CryptUtils";
            }
            if (!this.Components.Value.Contains(this.CryptComponent))
            {
                this.Components.Value.Add(this.CryptComponent);
            }

            if (this.XmlComponent == null)
            {
                this.XmlComponent = new DynamicClassSetup();
                this.XmlComponent.Assembly = Path.Combine(this.AssemblyPath, "PowerUpXmlUtils.dll");
                this.XmlComponent.Class = "XmlUtils";
            }
            if (!this.Components.Value.Contains(this.XmlComponent))
            {
                this.Components.Value.Add(this.XmlComponent);
            }

            if (this.DateTimeComponent == null)
            {
                this.DateTimeComponent = new DynamicClassSetup();
                this.DateTimeComponent.Assembly = Path.Combine(this.AssemblyPath, "PowerUpDateTimeUtils.dll");
                this.DateTimeComponent.Class = "DateTimeUtils";
            }
            if (!this.Components.Value.Contains(this.DateTimeComponent))
            {
                this.Components.Value.Add(this.DateTimeComponent);
            }

            if (this.EmailComponent == null)
            {
                this.EmailComponent = new DynamicClassSetup();
                this.EmailComponent.Assembly = Path.Combine(this.AssemblyPath, "PowerUpEmailUtils.dll");
                this.EmailComponent.Class = "EmailUtils";
            }
            if (!this.Components.Value.Contains(this.EmailComponent))
            {
                this.Components.Value.Add(this.EmailComponent);
            }

            if (this.FileSystemComponent == null)
            {
                this.FileSystemComponent = new DynamicClassSetup();
                this.FileSystemComponent.Assembly = Path.Combine(this.AssemblyPath, "PowerUpFileSystemUtils.dll");
                this.FileSystemComponent.Class = "FileSystemUtils";
            }
            if (!this.Components.Value.Contains(this.FileSystemComponent))
            {
                this.Components.Value.Add(this.FileSystemComponent);
            }

            if (this.GetComponent == null)
            {
                this.GetComponent = new DynamicClassSetup();
                this.GetComponent.Assembly = Path.Combine(this.AssemblyPath, "PowerUpGetUtils.dll");
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

