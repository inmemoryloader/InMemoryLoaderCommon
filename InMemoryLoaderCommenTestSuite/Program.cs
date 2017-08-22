using InMemoryLoaderBase;
using log4net;
using System;
using System.Configuration;
using System.IO;

namespace InMemoryLoaderCommonTestSuite
{
    class MainClass
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(MainClass));
        /// <summary>
        /// The app base.
        /// </summary>
        private static AppBase appBase = AppBase.Instance;

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        private static void Main(string[] args)
        {
            try
            {
                log.Info("Start InMemoryLoaderCommonTestSuite");

                var baseTestOk = RunBaseTest();
                log.InfoFormat("RunBaseTest = {0}", baseTestOk);

                var isGeneralInitTest = IsGeneralInitTest();
                log.InfoFormat("IsGeneralInitTest = {0}", isGeneralInitTest);

                var isInitTestLib = InitTestLib();
                log.InfoFormat("InitTestLib = {0}", isInitTestLib);


                /*

				// CheckUtils Test Cases
				var stringByteTest = InMemoryLoaderCommonTestSuite.CheckUtilsTest.Test.IsStringByteTest();
				log.InfoFormat("IsStringByteTest = {0}", stringByteTest);
				var stringDateTest = InMemoryLoaderCommonTestSuite.CheckUtilsTest.Test.IsStringDateTest();
				log.InfoFormat("IsStringDateTest = {0}", stringDateTest);
				var stringDecimalTest = InMemoryLoaderCommonTestSuite.CheckUtilsTest.Test.IsStringDecimalTest();
				log.InfoFormat("IsStringDecimalTest = {0}", stringDecimalTest);
				var stringDoubleTest = InMemoryLoaderCommonTestSuite.CheckUtilsTest.Test.IsStringDoubleTest();
				log.InfoFormat("IsStringDoubleTest = {0}", stringDoubleTest);
				var stringFloatTest = InMemoryLoaderCommonTestSuite.CheckUtilsTest.Test.IsStringFloatTest();
				log.InfoFormat("IsStringFloatTest = {0}", stringFloatTest);
				var stringIntTest = InMemoryLoaderCommonTestSuite.CheckUtilsTest.Test.IsStringIntTest();
				log.InfoFormat("IsStringIntTest = {0}", stringIntTest);
				var stringLongTest = InMemoryLoaderCommonTestSuite.CheckUtilsTest.Test.IsStringLongTest();
				log.InfoFormat("IsStringLongTest = {0}", stringLongTest);
				var urlValidTest = InMemoryLoaderCommonTestSuite.CheckUtilsTest.Test.IsUrlValidTest();
				log.InfoFormat("IsUrlValidTest = {0}", urlValidTest);

				// ConvertUtils Test Cases
				var convertBooleanTest = InMemoryLoaderCommonTestSuite.ConvertUtilsTest.Test.ConvertBooleanTest();
				log.InfoFormat("ConvertBooleanTest = {0}", convertBooleanTest);

				// CryptUtilsTest
				var cryptHashTest = InMemoryLoaderCommonTestSuite.CryptUtilsTest.Test.CryptHashTest();
				log.InfoFormat("CryptHashTest = {0}", cryptHashTest);
				var cryptRijndaelTest = InMemoryLoaderCommonTestSuite.CryptUtilsTest.Test.CryptRijndaelTest();
				log.InfoFormat("CryptRijndaelTest = {0}", cryptRijndaelTest);

				*/

                /*
				 
				// DateTimeUtilsTest
				var dateTimeCalendarWeekTest = InMemoryLoaderCommonTestSuite.DateTimeUtilsTest.Test.DateTimeCalendarWeekTest();
				log.InfoFormat("DateTimeCalendarWeekTest = {0}", dateTimeCalendarWeekTest);
				var dateTimeDiffTest = InMemoryLoaderCommonTestSuite.DateTimeUtilsTest.Test.DateTimeDiffTest();
				log.InfoFormat("DateTimeDiffTest = {0}", dateTimeDiffTest);
				var getAgeTest = InMemoryLoaderCommonTestSuite.DateTimeUtilsTest.Test.GetAgeTest();
				log.InfoFormat("GetAgeTest = {0}", getAgeTest);
				var getterTest = InMemoryLoaderCommonTestSuite.DateTimeUtilsTest.Test.GetterTest();
				log.InfoFormat("GetterTest = {0}", getterTest);
				var isPotentialTest = InMemoryLoaderCommonTestSuite.DateTimeUtilsTest.Test.IsPotentialDateTimeTest();
				log.InfoFormat("IsPotentialDateTimeTest = {0}", isPotentialTest);

				// GetUtilsTest
				var getUtilsTest = InMemoryLoaderCommonTestSuite.GetUtilsTest.Test.GetUtilsTest();
				log.InfoFormat("GetUtilsTest = {0}", getUtilsTest);

				// StringUtilsTest
				var stringUtilsTest = InMemoryLoaderCommonTestSuite.StringUtilsTest.Test.StringUtilsTest();
				log.InfoFormat("StringUtilsTest = {0}", stringUtilsTest);

				*/

                /*
				// EmailUtilsTest
				var sendSimpleTest = InMemoryLoaderCommonTestSuite.EmailUtilsTest.Test.SendSimpleTest();
				log.InfoFormat("SendSimpleTest = {0}", sendSimpleTest);

				// FileSystemUtilsTest
				var fileSystemUtilsCompareTest = InMemoryLoaderCommonTestSuite.FileSystemUtilsTest.Test.FileSystemUtilsCompareTest();
				log.InfoFormat("FileSystemUtilsCompareTest = {0}", fileSystemUtilsCompareTest);

				// XmlUtilsTest
				var xmlUtilsTest = InMemoryLoaderCommonTestSuite.XmlUtilsTest.Test.XmlUtilsTest();
				log.InfoFormat("XmlUtilsTest = {0}", xmlUtilsTest);

				*/

                Console.Read();
            }
            catch (Exception ex)
            {
                log.FatalFormat("{0}", ex);
            }
        }

        public static bool IsGeneralInitTest()
        {
            var general = new General();

            bool isOkay = false;

            isOkay = general.IsSimpleInit();
            isOkay = general.IsLinqInit();
            // isOkay = general.IsMethodInit ();

            return isOkay == false;
        }

        private static bool RunBaseTest()
        {
            try
            {
                bool baseTestOk = false;

                // appBase is typeof AppBase
                if (appBase != null)
                {
                    baseTestOk = true;
                }
                log.InfoFormat("Is Instanze AppBase = {0}", baseTestOk);

                // ComponentLoader is initialized
                if (appBase.ComponentLoader != null)
                {
                    baseTestOk = true;
                }
                log.InfoFormat("Is Instanze ComponentLoader = {0}", baseTestOk);

                // CommonComponentLoader is initialized
                if (appBase.CommonComponentLoader != null)
                {
                    baseTestOk = true;
                }
                log.InfoFormat("Is Instanze CommonComponentLoader = {0}", baseTestOk);

                var components = appBase.CommonComponentLoader.Components.Value.Count;
                log.InfoFormat("CommonComponentLoader contains {0} components", components);

                if (components > 0)
                {
                    baseTestOk = true;
                }

                if (log.IsDebugEnabled)
                {
                    foreach (var item in appBase.CommonComponentLoader.Components.Value)
                    {
                        log.Debug(item.Class.ToString());
                    }
                }

                return baseTestOk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool InitTestLib()
        {
            try
            {
                IDynamicClassSetup component = new DynamicClassSetup();

                var assembly = Path.Combine(@"D:\github\InMemoryLoaderMaster\InMemoryLoaderCommonLib\bin\Debug", "InMemoryLoaderCommonLib.dll");

                component.Assembly = assembly;
                component.Class = "EmptyClass";

                object[] paramInitArgument = { ConfigurationManager.AppSettings["ApplicationKey"].ToString() };
                var init = appBase.ComponentLoader.InvokeMethod(component.Assembly, component.Class, component.InitMethod, paramInitArgument);
                log.DebugFormat("Assembly: {0}, Class: {1}, Is init: {2}", component.Assembly, component.Class, init);

                object[] paramOpenArgument = { "1234" };
                var open = appBase.ComponentLoader.InvokeMethod(component.Assembly, component.Class, "IsInit", paramOpenArgument);
                log.InfoFormat("IsInit to: {0} is: {1}", component.Assembly, component.Class, open);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}