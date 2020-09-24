
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SpecflowNetCoreDemo.Base;
using SpecflowNetCoreDemo.Driver;
using SpecflowNetCoreDemo.Extensions;
using SpecflowNetCoreDemo.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestProject.Pages
{
    class ResultPage:BasePage        
    {
        private readonly Page _page;
        public ResultPage(Page page) : base(page)
        {
            _page = page;
        }

        IWebElement firstResult => DriverFactory.GetDriver().FindElementByXPath("//h3[contains(text(),'Adele - Hello - YouTube')]");

        public void selectFirst()
        {
            
            firstResult.Click();
        }
    }
}
