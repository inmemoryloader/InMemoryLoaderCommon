using InMemoryLoader.WebExtension_Test.Application;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryLoader.WebExtension_Test
{
    class Program
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The app base.
        /// </summary>
        private static ApplicationBase appBase = ApplicationBase.Instance;

        static void Main(string[] args)
        {
            try
            {
                log.InfoFormat("{0}", "Start InMemoryLoader.WebExtension_Test");
                log.InfoFormat("{0}", "--------------------------------------------------------------------------------");



                Console.Read();
            }
            catch (Exception ex)
            {
                log.FatalFormat("{0}", ex.ToString());
            }
        }
    }
}
