using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using SeleniumBDDNet.Drivers;
using System.Collections.Concurrent;
using System.Globalization;
using TechTalk.SpecFlow;

namespace SeleniumBDDNet.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        


        //Global Variable for Extend report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        Screenshot screenshot;

       public static String path;

        WebDriver webDriver;
        string driverType = "chrome";
        CreateDrivers createDrivers = new CreateDrivers();
        //Main all feature in one  dictonary




        public static ConcurrentDictionary<string,ExtentTest> FeatureDictionary = new ConcurrentDictionary<string,ExtentTest>(); 


        private readonly IObjectContainer _objectcontainer;
        //https://docs.specflow.org/projects/specflow/en/latest/Bindings/Context-Injection.html
        public Hooks1(IObjectContainer objectContainer)
        {
            _objectcontainer = objectContainer;



        }

              
        [BeforeTestRun]
        public static void InitializeReport()
        {


            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result


            path = (workingDirectory + "/../../../Reports/");
            var dateTime = DateTime.Now; 

            var automationHtmlReport = new ExtentHtmlReporter(path + "Automation_" + dateTime);
            extent = new ExtentReports();
            extent.AttachReporter(automationHtmlReport);
              

        }

        [BeforeFeature]
        public static void BeforFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest(featureContext.FeatureInfo.Title);
            FeatureDictionary.TryAdd(featureContext.FeatureInfo.Title, featureName);


        }


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext _scenarioContext)
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping
            //TODO: implement logic that has to run before executing each scenario
            //Driver need to be taken from app .config implementation is pending - alok
         
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }


        [AfterStep]
        public void InsertStepInReport(ScenarioContext _scenarioContext)
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                   
                  scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.StepContext.TestError.InnerException);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.StepContext.TestError.InnerException);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.StepContext.TestError.InnerException);
                }

                var screenshotpath = path + "ScreenShot\\" + DateTime.Now + "_png";
                
                screenshot = ((ITakesScreenshot)createDrivers.getDriver(driverType)).GetScreenshot();               
                screenshot.SaveAsFile(screenshotpath);
                scenario.AddScreenCaptureFromPath(screenshotpath);

            }


        }


        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            
           // driverManager.quitDriver();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();

        }
    }
}