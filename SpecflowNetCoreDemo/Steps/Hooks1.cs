using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Serilog;
using Serilog.Enrichers;
using SpecflowNetCoreDemo.Config;
using SpecflowNetCoreDemo.Driver;
using SpecflowNetCoreDemo.Util.Reports;
using System.Linq;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace SpecflowNetCoreDemo.Steps
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly ExtentReportBuilder _extentReportBuilder;        

        public Hooks1(FeatureContext featureContext, ScenarioContext scenarioContext, ExtentReportBuilder extentReportBuilder)
        {
            this._featureContext = featureContext;
            this._scenarioContext = scenarioContext;
            this._extentReportBuilder = extentReportBuilder;
        }
                

        [BeforeTestRun]
        public static void initializeReport()
        {
            
            ExtentReportBuilder.CreateReport(@"D:\Programming\vsWorkspace\solutions\SpecflowNetCoreDemo\ExtentReport.html");

            ConfigReader.LoadConfigs();

            Log.Logger = new LoggerConfiguration()
                .Enrich.With(new ThreadIdEnricher())
                  .WriteTo.Console(outputTemplate: "{Timestamp} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}")
                    .WriteTo.File(@"D:\Programming\vsWorkspace\solutions\SpecflowNetCoreDemo\log -.txt", 
                                    rollingInterval: RollingInterval.Day, 
                                    outputTemplate: "{Timestamp} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}")
                      .CreateLogger();


        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            if (!_scenarioContext.ScenarioInfo.Tags.Contains("@api"))
            {

               // RemoteWebDriver driver = new ChromeDriver(@"D:\Programming\vsWorkspace");


                DriverFactory.SetDriver(DriverManager.GetDriver(Settings.browserMode));

            }       
                         


            _extentReportBuilder.SetFeature(_featureContext);

            _extentReportBuilder.SetScenario(_scenarioContext);
           
        }


        [AfterStep]
        public void AddStepToReport()
        {
            _extentReportBuilder.SetNode(_scenarioContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (!_scenarioContext.ScenarioInfo.Tags.Contains("@api"))
            {
                DriverFactory.CloseAndQuitDriver();
            }
        }

        [AfterTestRun]
        public static void printReport()
        {
            ExtentReportBuilder.WriteReport();
            DriverFactory.DisposeDriver();
            Log.CloseAndFlush();
        }
    }
}
