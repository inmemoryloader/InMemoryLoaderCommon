using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryLoader.WebExtension.Application
{
    public class ApplicationBase
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(ApplicationBase));
        /// <summary>
        /// The instance.
        /// </summary>
        private static volatile ApplicationBase instance;
        /// <summary>
        /// The sync root.
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Gets or sets the component loader.
        /// </summary>
        /// <value>The component loader.</value>
        public ComponentLoader ComponentLoader
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:InMemoryLoaderTestConsole.AppBase"/> class.
        /// </summary>
        private ApplicationBase()
        {
            ComponentLoader = ComponentLoader.Instance;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ApplicationBase Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ApplicationBase();
                            log.DebugFormat("Create a new instance of Type: {0}", instance.GetType().ToString());
                        }
                    }
                }

                return instance;
            }
        }
    }
}