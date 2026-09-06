using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.AppUtils;

namespace Utilities.Elements
{
    public class Dropdown : Element
    {
        public SelectElement DropdownElement;
        public Dropdown(DriverHelper driverHelper, IWebElement webElement)
            : base(driverHelper, webElement)
        {
            DropdownElement = new SelectElement(webElement);
        }

        public bool IsMultipleSelect()
        {
            return DropdownElement.IsMultiple;
        }

        public IList<IWebElement> GetTotalList()
        {
            return DropdownElement.Options;
        }

        public IWebElement GetSelectedOption()
        {
            return DropdownElement.SelectedOption;
        }

        public IList<IWebElement> GetAllSelectedOptions()
        {
            if(IsMultipleSelect())
            {
                return DropdownElement.AllSelectedOptions;
            }
            else
            {
                Console.WriteLine("Cannot retrieve multiple options from a single-select dropdown");
                return null;
            }
        }

        public void OptByIndex(int id)
        {
            DropdownElement.SelectByIndex(id);
        }

        public void OptByValue(string value)
        {
            DropdownElement.SelectByValue(value);
        }

        public void OptByText(string text)
        {
            DropdownElement.SelectByText(text);
        }

    }
}
