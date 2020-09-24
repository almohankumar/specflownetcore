using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SpecflowNetCoreDemo.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNetCoreDemo.Driver
{
    public sealed class DriverManager
    {
        public static RemoteWebDriver GetDriver(BrowserMode mode)
        {

            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Settings.DriverPath);

            return new ChromeDriver(service, GetChromeOptions(mode));
            
        }

        private static ChromeOptions GetChromeOptions(BrowserMode browserMode)
        {          

            ChromeOptions options = new ChromeOptions();

            options.AddArguments("--window-size=1920,1080");
            options.AddArguments("disable-infobars");
            options.AddArguments("--ignore-certificate-errors");            

            if (browserMode == BrowserMode.Headless)
                options.AddArguments("--headless");

            return options;
        }

    }

    public enum BrowserMode
    {
        Headed,
        Headless
    }
}
