using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects.Checkout;
using System;
using System.Reflection;
using TechTalk.SpecFlow;
using Utilities;
using Utilities.AppUtils;
using Utilities.ConfigUtils;

namespace FrameworkLayer.StepDefinitions
{
    [Binding]
    public class CheckoutPageStepDefinitions : DriverUtilitiesInitializer
    {
        private readonly DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        private readonly CheckoutPage _checkoutPage;
        private readonly TestSettings _testSettings;
        private readonly ILog _log;
        public CheckoutPageStepDefinitions(ScenarioContext scenarioContext, FeatureContext featureContext) : base((DriverHelper)scenarioContext["DriverHelper"])
        {
            _scenarioContext = scenarioContext;
            _driverHelper = (DriverHelper)_scenarioContext["DriverHelper"];
            _checkoutPage = new CheckoutPage(_driverHelper);
            _testSettings = (TestSettings)featureContext["TestSettings"];
            _log = (ILog)_scenarioContext["ILog"];
        }

        [When(@"I enter '([^']*)' , '([^']*)' and '([^']*)' for delivery")]
        public void WhenIEnterAndForDelivery(string firstname, string lastname, string pincode)
        {
            _driverHelper.LocateElement(By.XPath("//button[@id='checkout']")).Click();
            _checkoutPage.EnterFirstNameField(firstname);
            _checkoutPage.EnterLastNameField(lastname);
            _checkoutPage.EnterPincodeField(pincode);
        }

        [When(@"I click on continue button")]
        public void WhenIClickOnContinueButton()
        {
            _checkoutPage.ClickContinueButton();
        }

        [When(@"I click on finish button")]
        public void WhenIClickOnFinishButton()
        {
            _checkoutPage.ClickFinishButton();
        }

        [Then(@"I should be checked out successfully")]
        public void ThenIShouldBeCheckedOutSuccessfully()
        {
            try
            {
                Assert.True(_driverHelper.GetUrl() == _testSettings.UiTestCheckoutSuccessUrl, "Product Checkout is incomplete");
            }
            catch(AssertionException e)
            {
                screenshotHelper.CaptureWholeScreenshot("checkoutFailure");
                _log.Error("Checkout Failed");
                throw;
            }
        }
    }
}
