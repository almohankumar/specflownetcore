using NUnit.Framework;
using Serilog;
using SpecflowNetCoreDemo.Driver;
using SpecflowNetCoreDemo.Extensions;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowNetCoreDemo.Steps
{
    [Binding]
    public sealed class StepDefinition2
    {

        [Given(@"I navigate to Yahoo")]
        public void GivenINavigateToYahoo()
        {
            Log.Information("Navigating to Yahoo page");
            DriverFactory.GetDriver().Navigate().GoToUrl("http://www.yahoo.com");
        }

        [Given(@"I sleep for some time")]
        public void GivenISleepForSomeTime()
        {
            Thread.Sleep(5);
            Assert.Fail("Purposely failed");
        }

        [Given(@"I navigate to Facebook")]
        public void GivenINavigateToFacebook()
        {
            Log.Information("Navigating to Facebook page");
            DriverFactory.GetDriver().Navigate().GoToUrl("http://www.facebook.com");
            Thread.Sleep(5);
            DriverFactory.GetDriver().waitForUrlToContainText("yahoo", 10);
        }




    }
}
