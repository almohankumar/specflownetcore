using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNetCoreDemo.Extensions
{
    public static class WebDriverExtensions
    {

        private static readonly TimeSpan _pollingInterval = TimeSpan.FromMilliseconds(250);

        public static void WaitForElementToBeVisible(this RemoteWebDriver driver, IWebElement element ,int timeout)
        {

            TimeSpan timeSpan = TimeSpan.FromSeconds(timeout);
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            wait.PollingInterval = _pollingInterval;
            wait.Message = string.Format("Wait timed out at {0} seconds!", timeout);

            Func<IWebDriver, bool> condition = d =>
            {

                return element.Displayed;

            };

            wait.Until(condition);

        }

        public static void WaitForElementToBeEnabled(this RemoteWebDriver driver, IWebElement element, int timeout)
        {

            TimeSpan timeSpan = TimeSpan.FromSeconds(timeout);
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            wait.PollingInterval = _pollingInterval;
            wait.Message = string.Format("Wait timed out at {0} seconds!", timeout);

            Func<IWebDriver, bool> condition = d =>
            {

                return element.Displayed && element.Enabled;

            };

            wait.Until(condition);

        }

        public static void waitForUrlToContainText(this RemoteWebDriver driver, String text, int timeout)
        {

            TimeSpan timeSpan = TimeSpan.FromSeconds(timeout);
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            wait.PollingInterval = _pollingInterval;
            wait.Message = string.Format("URL doesn't contain '{0}' until {1} seconds!", text,timeout);

            Func<IWebDriver, bool> condition = d =>
            {
                return driver.Url.Contains(text);              

            };

            wait.Until(condition);

        }




    }
}
