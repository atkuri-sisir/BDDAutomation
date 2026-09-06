using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using log4net;
using System.Reflection;
using TechTalk.SpecFlow;
using Utilities;
using Utilities.AppUtils;
using Utilities.ConfigUtils;

namespace FrameworkLayer.Hooks
{
    [Binding]
    public sealed class UIHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private static ILog log;
        private static ReportUtility _reportUtility;

        public UIHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _reportUtility = ReportUtility.GetReportInstance();
            log = LogUtility.GetLogger<UIHooks>();
            LogUtility.LogInit();
            log.Info("Starting the Test Run");
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _reportUtility.Feature = _reportUtility.ExtentReport.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            TestSettings testSettings = ConfigReader.GetConfig($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}//testsettings.json");
            featureContext["TestSettings"] = testSettings;
            log.Info("Starting the Feature");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _reportUtility.Scenario = _reportUtility.Feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            _scenarioContext["ILog"] = log;
            log.Info("Starting the Scenario");
        }

        [AfterStep]
        public void AfterStep()
        {

            Console.WriteLine("Running After Step...");

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            var stepName = _scenarioContext.StepContext.StepInfo.Text;

            if (_scenarioContext.TestError == null)
            {
                if (stepType.Equals("Given", StringComparison.OrdinalIgnoreCase))
                {
                    _reportUtility.Scenario.CreateNode<Given>(stepName).Pass("Step passed.");
                }
                else if (stepType.Equals("When", StringComparison.OrdinalIgnoreCase))
                {
                    _reportUtility.Scenario.CreateNode<When>(stepName).Pass("Step passed.");
                }
                else if (stepType.Equals("Then", StringComparison.OrdinalIgnoreCase))
                {
                    _reportUtility.Scenario.CreateNode<Then>(stepName).Pass("Step passed.");
                }
            }
            else
            {
                if (stepType.Equals("Given", StringComparison.OrdinalIgnoreCase))
                {
                    _reportUtility.Scenario.CreateNode<Given>(stepName).Fail(_scenarioContext.TestError.Message);
                }

                else if (stepType.Equals("When", StringComparison.OrdinalIgnoreCase))

                {
                    _reportUtility.Scenario.CreateNode<When>(stepName).Fail(_scenarioContext.TestError.Message);
                }
                else if (stepType.Equals("Then", StringComparison.OrdinalIgnoreCase))
                {
                    _reportUtility.Scenario.CreateNode<Then>(stepName).Fail(_scenarioContext.TestError.Message);
                }

            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var scenarioStatus = _scenarioContext.ScenarioExecutionStatus;
            if (scenarioStatus == ScenarioExecutionStatus.OK)
            {
                _reportUtility.Scenario.Pass("Test Scenario Passed Successfully");
                log.Info("Test Scenario Passed Successfully");
            }
            else
            {
                _reportUtility.Scenario.Fail("Test Scenario Failed");
                log.Info("Test Scenario Failed");
            }
            log.Info("Scenario Execution Ended");
        }

        [AfterScenario("UI")]
        public void AfterDriverScenario()
        {
            DriverHelper driverHelper = (DriverHelper)_scenarioContext["DriverHelper"];
            driverHelper.QuitDriver();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            log.Info("Feature Execution Ended");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _reportUtility.TearDownExtentReport();
            log.Info("Test Run Ended");
        }

    }
}