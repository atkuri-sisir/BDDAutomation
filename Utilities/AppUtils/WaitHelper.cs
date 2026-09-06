using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Utilities.AppUtils
{
    public class WaitHelper
    {
        private readonly DriverHelper _driverHelper;
        public WaitHelper(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }

        public void WaitForElementToBeClickable(By locator, int timeout)
        {
            WebDriverWait explicitWait = _driverHelper.GetExplicitWaitForSeconds(timeout);
            explicitWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public void WaitForElementToBeVisibile(By locator, int timeout)
        {
            WebDriverWait explicitWait = _driverHelper.GetExplicitWaitForSeconds(timeout);
            explicitWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public void WaitForElementToBeSelected(By locator, int timeout)
        {
            WebDriverWait explicitWait = _driverHelper.GetExplicitWaitForSeconds(timeout);
            explicitWait.Until(ExpectedConditions.ElementToBeSelected(locator));
        }
        public void WaitForElementStateToBe(By locator, int timeout, bool selection)
        {
            WebDriverWait explicitWait = _driverHelper.GetExplicitWaitForSeconds(timeout);
            explicitWait.Until(ExpectedConditions.ElementSelectionStateToBe(locator, selection));
        }
        public void WaitForUrlToBe(string url, int timeout)
        {
            WebDriverWait explicitWait = _driverHelper.GetExplicitWaitForSeconds(timeout);
            explicitWait.Until(ExpectedConditions.UrlToBe(url));
        }
        public void WaitForAlertToBePresent(int timeout)
        {
            WebDriverWait explicitWait = _driverHelper.GetExplicitWaitForSeconds(timeout);
            explicitWait.Until(ExpectedConditions.AlertIsPresent());
        }
        public void WaitImplicitlyForSeconds(int timeout)
        {
            _driverHelper.WaitImplicitlyForSeconds(timeout);
        }
        public void WaitImplicitlyForMilliSeconds(int timeout)
        {
            _driverHelper.WaitImplicitlyForMilliSeconds(timeout);
        }
        public void FluentlyWaitForSeconds(By locator, int timeout)
        {
            var fluentWait = _driverHelper.GetFluentWaitForSeconds(timeout);
            fluentWait.Until(x => x.FindElement(locator));
        }
    }
}
