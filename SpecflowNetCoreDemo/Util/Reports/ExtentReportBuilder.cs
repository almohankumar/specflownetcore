using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using SpecflowNetCoreDemo.Driver;
using TechTalk.SpecFlow;

namespace SpecflowNetCoreDemo.Util.Reports
{
    public sealed class ExtentReportBuilder 
    {

        private static ExtentReports _extent;
        private static ExtentTest featureName;

        private ExtentTest _currentScenario;



        public static void CreateReport(string filePath)
        {
            var htmlReporter = new ExtentHtmlReporter(filePath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

           _extent = new ExtentReports();
           _extent.AttachReporter(htmlReporter);

        }


        public void SetFeature(FeatureContext featureContext)
        {
            featureName = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        public void SetNode(ScenarioContext scenarioContext)
            
        {
            
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                
                var mediaEntity = CaptureScreenshotAndReturnModel(scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                    _currentScenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    _currentScenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    _currentScenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaEntity);
            
            }
            else if (scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {

                if (stepType == "Given")
                    _currentScenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    _currentScenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _currentScenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }
        }

        public void SetScenario(ScenarioContext scenarioContext)
        {
            _currentScenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        public static ExtentReports GetReport()
        {
            return _extent;
        }


        public static void WriteReport()
        {
            _extent.Flush();
        }

        private MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)DriverFactory.GetDriver()).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }
    }
}
