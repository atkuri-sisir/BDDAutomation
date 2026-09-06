using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.AppUtils
{
    public class DriverHelper
    {
        private IWebDriver _driver;

        public void CreateDriver(string browser)
        {
            switch (browser)
            {
                case "chrome": _driver = new ChromeDriver(); break;
                case "edge": _driver = new EdgeDriver(); break;
                case "firefox": _driver = new FirefoxDriver(); break;
                default: Console.WriteLine("Invalid browser choice"); break;
            }
        }

        public void CreateDriver(string browser, Object browserOptions)
        {
            switch (browser)
            {
                case "chrome":
                    _driver = new ChromeDriver((ChromeOptions)browserOptions); break;
                case "edge":
                    _driver = new EdgeDriver((EdgeOptions)browserOptions); break;
                case "firefox":
                    _driver = new FirefoxDriver((FirefoxOptions)browserOptions); break;
                default: Console.WriteLine("Invalid browser choice"); break;
            }
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IWebElement LocateElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public ReadOnlyCollection<IWebElement> LocateElements(By locator)
        {
            return _driver.FindElements(locator);
        }

        public void MaximizeWindow()
        {
            _driver.Manage().Window.Maximize();
        }

        public Actions GetAction()
        {
            return new Actions(_driver);
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public void QuitDriver()
        {
            _driver.Quit();
        }

        public Screenshot GetWholeScreenshot(string fileName)
        {
            return _driver.TakeScreenshot();
        }

        public void WaitImplicitlyForSeconds(int timeout)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }
        public void WaitImplicitlyForMilliSeconds(int timeout)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeout);
        }

        public WebDriverWait GetExplicitWaitForSeconds(int timeout)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
        }

        public WebDriverWait GetExplicitWaitForMilliSeconds(int timeout)
        {
            return new WebDriverWait(_driver, TimeSpan.FromMilliseconds(timeout));
        }

        public DefaultWait<IWebDriver> GetFluentWaitForSeconds(int timeout)
        {
            return new DefaultWait<IWebDriver>(_driver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
        }

        public void OpenNewWindow()
        {
            _driver.SwitchTo().NewWindow(WindowType.Tab);
        }

        public object ExecuteJavaScriptCommand(string javascriptCommand, params Object[] objArray)
        {
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)_driver;
            return javascriptExecutor.ExecuteScript(javascriptCommand, objArray);
        }

        public IJavaScriptExecutor GetJavaScriptExecutor()
        {
            return (IJavaScriptExecutor)_driver;
        }
        public IAlert SwitchToAlert()
        {
            return _driver.SwitchTo().Alert();
        }

        public int GetWindowCount()
        {
            return _driver.WindowHandles.Count();
        }

        public string GetCurrentWindow()
        {
            return _driver.CurrentWindowHandle;
        }

        public ReadOnlyCollection<string> GetAllWindows()
        {
            return _driver.WindowHandles;
        }

        public void SwitchToWindow(string windowHandle)
        {
            _driver.SwitchTo().Window(windowHandle);
        }
    }
}
