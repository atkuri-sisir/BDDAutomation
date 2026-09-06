using FrameworkLayer.Hooks;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects.Cart;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.AppUtils;
using Utilities.ConfigUtils;

namespace FrameworkLayer.StepDefinitions
{
    [Binding]
    internal class ProductCartStepDefinitions : DriverUtilitiesInitializer
    {
        private readonly DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        private readonly CartPage _cartPage;
        private readonly TestSettings _testSettings;
        private readonly ILog _log;

        public ProductCartStepDefinitions(ScenarioContext scenarioContext, FeatureContext featureContext) : base((DriverHelper)scenarioContext["DriverHelper"])
        {
            _scenarioContext = scenarioContext;
            _driverHelper = (DriverHelper)_scenarioContext["DriverHelper"];
            _cartPage = new CartPage(_driverHelper);
            _testSettings = (TestSettings)featureContext["TestSettings"];
            _log = (ILog)_scenarioContext["ILog"];
        }

        [When(@"I sort products from low to high price")]
        public void WhenISortProductsFromLowToHighPrice()
        {
            _cartPage.SortLowToHigh();
        }

        [When(@"I add a product to cart")]
        public void WhenIAddAProductToCart()
        {
            _cartPage.ClickAddToCartButton();
        }

        [When(@"I click on cart icon")]
        public void WhenIClickOnCartIcon()
        {
            _cartPage.ClickCartIcon();
        }

        [Then(@"I should successfully see my product in the cart")]
        public void ThenIShouldSuccessfullySeeMyProductInTheCart()
        {
            try
            {
                Assert.True(_driverHelper.GetUrl() == _testSettings.UiTestCartUrl, "Not redirected to cart page");
            }
            catch(AssertionException e)
            {
                screenshotHelper.CaptureWholeScreenshot("cartAdditionFailure");
                _log.Error("Product Addition to Cart Failed");
                throw;
            }
        }

    }
}
