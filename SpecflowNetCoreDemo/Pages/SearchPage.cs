
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SpecflowNetCoreDemo.Driver;
using SpecflowNetCoreDemo.Extensions;
using SpecflowNetCoreDemo.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SpecflowNetCoreDemo.Pages;

namespace MyTestProject.Pages
{
    class SearchPage:BasePage
    {
        private readonly Page _page;
        public SearchPage(Page page) : base(page)
        {
            _page = page;
        }

        IWebElement txtSearch => DriverFactory.GetDriver().FindElementByXPath("//input[@title='Search']");
         IWebElement btnSearch => DriverFactory.GetDriver().FindElementByXPath("//input[@aria-label ='Google Search']"); 
        
        public void setSearchKey(string key)
        {
            txtSearch.SendKeys(key);
            DriverFactory.GetDriver().WaitForElementToBeVisible(btnSearch, 10);
        }

        public ResultPage Search()
        {
            btnSearch.Click();
            return new ResultPage(_page);
        }





    }
}
