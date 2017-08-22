using InMemoryLoader;
using InMemoryLoaderCommon;
using log4net;
using System;
using System.Configuration;
using System.Globalization;
using System.Threading;

namespace InMemoryLoaderCommonTestSuite
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
		internal string commonComponentPath { get { return ConfigurationManager.AppSettings ["CommonComponentPath"].ToString (); } }
		/// <summary>
		/// Gets the console culture.
		/// </summary>
		/// <value>The console culture.</value>
		internal string consoleCulture { get { return ConfigurationManager.AppSettings ["ConsoleCulture"].ToString (); } }

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
			this.ComponentLoader = ComponentLoader.Instance;
			this.CommonComponentLoader = new CommonComponentLoader ();
			this.CommonComponentLoader.InitCommonComponents (this.commonComponentPath);
			this.SetCulture ();
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

		/// <summary>
		/// Sets the culture.
		/// </summary>
		/// <returns><c>true</c>, if culture was set, <c>false</c> otherwise.</returns>
		private bool SetCulture ()
		{
			var specificCulture = CultureInfo.CreateSpecificCulture (this.consoleCulture);
			var uiCulture = new  CultureInfo (this.consoleCulture);

			Thread.CurrentThread.CurrentCulture = specificCulture;
			Thread.CurrentThread.CurrentUICulture = uiCulture;

			return true;
		}
	}
}