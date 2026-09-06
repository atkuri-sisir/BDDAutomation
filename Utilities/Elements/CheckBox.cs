using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.AppUtils;

namespace Utilities.Elements
{
    public class CheckBox : Element
    {
        public CheckBox(DriverHelper driverHelper, IWebElement webElement)
            : base(driverHelper, webElement)
        {

        }
        public void Check()
        {
            if (!webElement.Selected)
            {
                webElement.Click();
            }
        }
        public void UnCheck()
        {
            if (webElement.Selected)
            {
                webElement.Click();
            }
        }
        public bool IsChecked()
        {
            return webElement.Selected;
        }
    }
}
