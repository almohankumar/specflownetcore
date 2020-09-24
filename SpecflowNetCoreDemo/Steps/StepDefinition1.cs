using AventStack.ExtentReports.Gherkin.Model;
using MyTestProject.Pages;
using Serilog;
using SpecflowNetCoreDemo.Base;
using SpecflowNetCoreDemo.Config;
using SpecflowNetCoreDemo.Driver;
using SpecflowNetCoreDemo.Pages;
using System.Threading;
using TechTalk.SpecFlow;


namespace SpecflowNetCoreDemo.Steps
{
    [Binding]
    public sealed class StepDefinition1:BaseStep
    {
        private readonly Page _page;    
       

        public StepDefinition1(Page page) : base(page)
        {
            _page = page;
        }

        [Given(@"I navigate to google page")]
        public void GivenINavigateToGooglePage()
         {

            Log.Logger.Information("Navigating to Google!");
            _page.CurrentPage = new SearchPage(_page); 

            
           DriverFactory.GetDriver().Navigate().GoToUrl(Settings.AUT);

        }

        [Given(@"I enter the search key ""(.*)""")]
        public void GivenIEnterTheSearchKey(string searchKey)
          
        {
           


            Log.Information("Using lo.information directly");
            _page.CurrentPage.As<SearchPage>().setSearchKey(searchKey);          
           
            
        }

        [When(@"I hit search button")]
        public void WhenIHitSearchButton()
        {
            _page.CurrentPage = _page.CurrentPage.As<SearchPage>().Search();
          
        }

        [Then(@"I see the results")]
        public void ThenISeeTheResults()
        {
            Thread.Sleep(10);          
        }

    }
}
