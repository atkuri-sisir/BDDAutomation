using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V126.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.AppUtils
{
    public class JavaScriptHelper
    {
        private readonly DriverHelper _driverHelper;
        private IJavaScriptExecutor javaScriptExecutor;

        public JavaScriptHelper(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            javaScriptExecutor = _driverHelper.GetJavaScriptExecutor();
        }

        public void scrollUntilVisible(IWebElement element)
        {
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void scrollByAmount(int pixels)
        {
            javaScriptExecutor.ExecuteScript($"window.scrollBy(0,{pixels})");
        }

        public string GetTitle()
        {
            return (string)javaScriptExecutor.ExecuteScript("return document.title;");
        }

        public void EnterInput(By inputLocator, string value)
        {
            javaScriptExecutor.ExecuteScript($"document.getElementById('{inputLocator}').value='{value}'");
        }

        public void ClickElement(IWebElement element)
        {
            javaScriptExecutor.ExecuteScript($"arguments[0].click();", element);
        }
    }
}
