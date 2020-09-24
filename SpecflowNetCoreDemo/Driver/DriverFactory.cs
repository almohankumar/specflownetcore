using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecflowNetCoreDemo.Driver
{
    public sealed class DriverFactory
    {

        private static ThreadLocal<RemoteWebDriver> _driver = new ThreadLocal<RemoteWebDriver>();

       

        public static RemoteWebDriver GetDriver()
        {
            return _driver.Value;
        }

        public static void SetDriver(RemoteWebDriver driver)
        {
            _driver.Value = driver;
        }

        public static bool IsDriverSet()
        {
            return _driver.IsValueCreated;
        }

        public static void CloseAndQuitDriver()
        {
            _driver.Value.Close();
            _driver.Value.Quit();
        }

        public static void DisposeDriver()
        {           
            _driver.Dispose();
        }


    }
}
