using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.AppUtils;

namespace Utilities.Elements
{
    public abstract class Element
    {
        protected DriverHelper driverHelper;
        protected IWebElement webElement;
        protected Element(DriverHelper driverHelper, IWebElement webElement)
        {
            this.driverHelper = driverHelper;
            this.webElement = webElement;
        }

        protected string Text => webElement.Text;

        protected bool IsDisplayed()
        {
            return webElement.Displayed;
        }
    }
}
