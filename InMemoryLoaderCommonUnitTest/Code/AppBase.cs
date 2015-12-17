using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	internal class AppBase
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(AppBase));
		/// <summary>
		/// The instance.
		/// </summary>
		private static volatile AppBase instance;
		/// <summary>
		/// The sync root.
		/// </summary>
		private static object syncRoot = new Object ();
		/// <summary>
		/// The common component path.
		/// </summary>
		public const string commonComponentPath = "/home/kaysta/github.com/InMemoryLoaderCommon/InMemoryLoaderCommon/bin/Debug/";

		/// <summary>
		/// Gets or sets the component loader.
		/// </summary>
		/// <value>The component loader.</value>
		public ComponentLoader ComponentLoader { 
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the common component loader.
		/// </summary>
		/// <value>The common component loader.</value>
		public CommonComponentLoader CommonComponentLoader { 
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryLoaderCommonUnitTest.AppBase"/> class.
		/// </summary>
		private AppBase ()
		{
			log4net.Config.XmlConfigurator.Configure ();
			ComponentLoader = ComponentLoader.Instance;
			CommonComponentLoader = new CommonComponentLoader();
			CommonComponentLoader.InitCommonComponents (commonComponentPath);
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static AppBase Instance {
			get {
				if (instance == null) {
					lock (syncRoot) {
						if (instance == null) {							
							instance = new AppBase ();
							log.DebugFormat ("Create a new instance of Type: {0}", instance.GetType ().ToString ());
						}
					}
				}

				return instance;
			}
		}
	}
}

