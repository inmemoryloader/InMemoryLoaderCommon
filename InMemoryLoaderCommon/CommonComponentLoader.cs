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