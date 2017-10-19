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

using System.Globalization;
using System.Linq;
using System.Threading;
using InMemoryLoader;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderCommon
{
	public abstract class AbstractCommonBase
	{

		private static readonly ILog log = LogManager.GetLogger(typeof(AbstractCommonBase));

		private static string assemblyPath;
		public string AssemblyPath { get { return assemblyPath; } set { assemblyPath = value; } }

		public ComponentLoader ComponentLoader { get; set; }

		public CommonComponentLoader CommonComponentLoader { get; set; }

		private static IDynamicClassInfo checkUtils = new DynamicClassInfo();
		public IDynamicClassInfo CheckUtils
		{
			get
			{
				if (checkUtils.ClassObject == null)
				{
					checkUtils = this.ComponentLoader.ComponentRegistry.Where(str => str.Key.Class.Equals("PowerUpCheckUtils.CheckUtils")).SingleOrDefault().Value;
				}
				return checkUtils;
			}
		}


		public AbstractCommonBase()
		{
			log4net.Config.XmlConfigurator.Configure();

			this.SetCulture();

			this.GetComponentPath();

			this.ComponentLoader = ComponentLoader.Instance;
			this.CommonComponentLoader = new CommonComponentLoader();
			this.CommonComponentLoader.InitCommonComponents(null);
		}

		public AbstractCommonBase(string assemblyPath)
		{
			log4net.Config.XmlConfigurator.Configure();

			this.SetCulture();

			this.GetComponentPath(assemblyPath);

			this.ComponentLoader = ComponentLoader.Instance;
			this.CommonComponentLoader = new CommonComponentLoader();
			this.CommonComponentLoader.InitCommonComponents(null);
		}

		public bool SetCulture()
		{
			var specificCulture = CultureInfo.CreateSpecificCulture(null);
			var uiCulture = new CultureInfo(null);

			Thread.CurrentThread.CurrentCulture = specificCulture;
			Thread.CurrentThread.CurrentUICulture = uiCulture;

			return true;
		}

		protected string GetComponentPath()
		{
			var compPath = string.Empty;


			return compPath;
		}

		protected string GetComponentPath(string assemblyPath)
		{
			var compPath = string.Empty;


			return compPath;
		}
	}
}
