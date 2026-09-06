using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using log4net;
using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using TechTalk.SpecFlow;
using Utilities;
using Utilities.AppUtils;
using Utilities.ConfigUtils;

namespace FrameworkLayer.Hooks
{
    [Binding]
    public sealed class LoginHooks
    {
        private TestSettings _testSettings;
        private DriverHelper _driverHelper;
        private ChromeOptions _chromeOptions;

        [BeforeScenario("login", Order = 0)]
        public void BeforeLoginDriverScenario()
        {
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArguments("--incognito");
        }

        [BeforeScenario("login", Order = 1)]
        public void BeforeLoginScenario(ScenarioContext scenarioContext, FeatureContext featureContext)

        {
            _driverHelper = new DriverHelper();
            _testSettings = (TestSettings)featureContext["TestSettings"];
            _driverHelper.CreateDriver(_testSettings.ChromeBrowser, _chromeOptions);
            scenarioContext["DriverHelper"] = _driverHelper;
        }

    }
}