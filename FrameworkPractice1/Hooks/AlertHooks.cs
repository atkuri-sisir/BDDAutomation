using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using TechTalk.SpecFlow;
using Utilities.AppUtils;
using Utilities.ConfigUtils;

namespace FrameworkLayer.Hooks
{
    [Binding]
    public sealed class AlertHooks
    {
        private DriverHelper _driverHelper;
        private TestSettings _testSettings;
        private ChromeOptions _chromeOptions;

        [BeforeScenario("alerts", Order = 0)]
        public void BeforeAlertDriverScenario()
        {
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArguments("--incognito");
        }

        [BeforeScenario("alerts", Order = 1)]
        public void BeforeAlertScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _driverHelper = new DriverHelper();
            _testSettings = (TestSettings)featureContext["TestSettings"];
            _driverHelper.CreateDriver(_testSettings.ChromeBrowser, _chromeOptions);
            scenarioContext["DriverHelper"] = _driverHelper;
        }
    }
}