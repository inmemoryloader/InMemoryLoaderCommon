//
// AppBase.cs
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

using System;
using System.Configuration;
using System.Threading;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonTestSuite
{
	internal class AppBase : AbstractCommonBase
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger(typeof(AppBase));
		/// <summary>
		/// The instance.
		/// </summary>
		private static volatile AppBase instance;
		/// <summary>
		/// The sync root.
		/// </summary>
		private static object syncRoot = new Object();

		/// <summary>
		/// The common component path.
		/// </summary>
		internal string commonComponentPath { get { return ConfigurationManager.AppSettings["CommonComponentPath"].ToString(); } }
		/// <summary>
		/// Gets the console culture.
		/// </summary>
		/// <value>The console culture.</value>
		internal string consoleCulture { get { return ConfigurationManager.AppSettings["ConsoleCulture"].ToString(); } }

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryLoaderCommonUnitTest.AppBase"/> class.
		/// </summary>
		private AppBase()
		{
			log4net.Config.XmlConfigurator.Configure();

			log.DebugFormat("Create a new instance of Type: {0}", this.GetType().ToString());

			base.ConsoleCulture = this.consoleCulture;
			base.AssemblyPath = this.commonComponentPath;

			base.SetCulture();
			log.DebugFormat("CurrentCulture set to: {0}", Thread.CurrentThread.CurrentCulture.DisplayName);

			base.GetAssemblyPath();
			base.SetInMemoryLoader();
			base.SetClassRegistry();
			base.SetInMemoryLoaderCommon();

		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static AppBase Instance
		{
			get
			{
				if (instance == null)
				{
					lock (syncRoot)
					{
						if (instance == null)
						{
							instance = new AppBase();
							log.DebugFormat("Create a new instance of Type: {0}", instance.GetType().ToString());
						}
					}
				}
				return instance;
			}
		}

	}
}