using CsvHelper;
using log4net;
using FrameworkLayer.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects.Login;
using System;
using System.Globalization;
using System.Reflection;
using TechTalk.SpecFlow;
using Utilities.AppUtils;
using Utilities.ConfigUtils;
using Utilities;
using Newtonsoft.Json;
using FrameworkLayer.Models;

namespace FrameworkLayer.StepDefinitions
{
    [Binding]
    public class LoginPageStepDefinitions : DriverUtilitiesInitializer
    {
        private readonly DriverHelper _driverHelper;
        private readonly LoginPage _loginPage;
        private readonly ScenarioContext _scenarioContext;
        private readonly TestSettings _testSettings;
        private readonly ILog _log;
        public LoginPageStepDefinitions(ScenarioContext scenarioContext, FeatureContext featureContext) : base((DriverHelper) scenarioContext["DriverHelper"])
        {
            _scenarioContext = scenarioContext;
            _driverHelper = (DriverHelper)scenarioContext["DriverHelper"];
            _loginPage = new LoginPage(_driverHelper);
            _testSettings = (TestSettings)featureContext["TestSettings"];
            _log = (ILog)scenarioContext["ILog"];
        }

        [Given(@"I am on Login Page")]
        public void GivenIAmOnLoginPage()
        {
            _log.Info("navigating to login page");
            _driverHelper.NavigateToUrl(_testSettings.UiTestUrl);
            _driverHelper.MaximizeWindow();
        }
       
        [Given(@"I am on Logged in using '([^']*)' file and navigated to Product Page")]
        public void GivenIAmOnLoggedInUsingFileAndNavigatedToProductPage(string fileName)
        {
            _driverHelper.NavigateToUrl(_testSettings.UiTestUrl);
            _driverHelper.MaximizeWindow();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);
            var userData = FileUtility.LoadCsvData(filePath);
            foreach(var user in userData)
            {
                _loginPage.Login(user.username, user.password);
            }
            _loginPage.ClickLoginButton();
        }

        [When(@"I enter a valid '([^']*)' details from corresponding json data")]
        public void WhenIEnterAValidAndPasswordFromResepectiveJsonData(string userName)
        {
            string sauceDemoUserData = File.ReadAllText($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\TestData\\loginCredentials.json");
            var sauceDemoUsersList = JsonConvert.DeserializeObject<SauceDemoUsersList>(sauceDemoUserData);
            var sauceDemoUser = sauceDemoUsersList.LoginCredentials.FirstOrDefault(user => user.UserName==userName);
            _loginPage.Login(userName, sauceDemoUser.Password);
        }

        [When(@"I enter user details: '([^']*)' and '([^']*)' from the csv file")]
        public void WhenIEnterUserDetailsAndFromTheCsvFile(string username, string password)
        {
            _loginPage.Login(username, password);
        }

        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            try
            {
                Assert.True(_driverHelper.GetUrl() == _testSettings.UiTestHomePageUrl, "Login in unsuccessful");
            }
            catch(AssertionException e)
            {
                screenshotHelper.CaptureWholeScreenshot("loginfailure");
                _log.Error("login Unsuccessful");
                throw;
            }
        }

    }
}
