using PageObjects.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities.AppUtils;
using Utilities.ConfigUtils;
using log4net;

namespace FrameworkLayer.StepDefinitions
{
    [Binding]
    public class DemoQAStepDefinitions : DriverUtilitiesInitializer
    {
        private readonly DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        private readonly TestSettings _testSettings;
        private readonly AlertPage _alertPage;
        private readonly ILog _log;
        public DemoQAStepDefinitions(ScenarioContext scenarioContext, FeatureContext featureContext) : base((DriverHelper)scenarioContext["DriverHelper"])
        {
            _scenarioContext = scenarioContext;
            _driverHelper = (DriverHelper)_scenarioContext["DriverHelper"];
            _testSettings = (TestSettings)featureContext["TestSettings"];
            _log = (ILog)_scenarioContext["ILog"];
            _alertPage = new AlertPage(_driverHelper);
        }

        [Given(@"I am on alerts page")]
        public void GivenIAmOnAlertsPage()
        {
            _driverHelper.NavigateToUrl(_testSettings.DemoQAUrl);
            _driverHelper.MaximizeWindow();
            _alertPage.ClickAlertsDiv();
            _alertPage.ClickAlertsTab();
        }

        [When(@"I click on the simple alert button")]
        public void WhenIClickOnTheSimpleAlertButton()
        {
            _alertPage.ClickSimpleAlertButton();
        }

        [When(@"I switch to the alert")]
        public void WhenIAcceptTheAlert()
        {
            alertHelper.SwitchToAlert();
        }

        [Then(@"I should be able to close the alert")]
        public void ThenAlertShouldBeClosed()
        {
            alertHelper.AcceptAlert();
        }

        [When(@"I click on the prompt alert button")]
        public void WhenIClickOnThePromptAlertButton()
        {
            _alertPage.ClickPromptAlertButton();
        }

        [Then(@"I should be able to enter input into the prompt")]
        public void ThenIShouldBeAbleToEnterInputIntoThePrompt()
        {
            alertHelper.EnterInput("Entering prompt into the alert...");
            alertHelper.AcceptAlert();
        }
    }
}
