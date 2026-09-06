using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using TechTalk.SpecFlow;
using Utilities.AppUtils;
using Utilities.ConfigUtils;

namespace FrameworkLayer.Hooks
{
    [Binding]
    public sealed class ProductHooks
    {
        private ChromeOptions _chromeOptions;
        private TestSettings _testSettings;
        private DriverHelper _driverHelper;

        [BeforeScenario("productpurchase", Order = 0)]
        public void BeforeScenario()
        {
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArguments("--incognito");
        }

        [BeforeScenario("productpurchase", Order = 1)]
        public void BeforeProductPurchaseScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _driverHelper = new DriverHelper();
            _testSettings = (TestSettings)featureContext["TestSettings"];
            _driverHelper.CreateDriver(_testSettings.ChromeBrowser, _chromeOptions);
            scenarioContext["DriverHelper"] = _driverHelper;
        }
    }
}