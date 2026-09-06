using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.AppUtils;
using Utilities.Elements;

namespace Utilities.CustomElements
{
    public class CustomDropDown : Element
    {
        public CustomDropDown(DriverHelper driverHelper, IWebElement webElement)
            : base(driverHelper, webElement)
        {

        }

        public void SelectByText(string text, By locator)
        {
            webElement.Click();

            var dropDownOptions = driverHelper.LocateElements(locator);
            var optionToSelect = dropDownOptions.FirstOrDefault(option => option.Text.Equals(text));

            if(optionToSelect!=null)
            {
                optionToSelect.Click();
            }
            else
            {
                throw new NoSuchElementException($"Dropdown option with text: {text} was not found");
            }
        }
    }
}
