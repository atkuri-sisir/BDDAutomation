using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Elements;
using Utilities.AppUtils;

namespace PageObjects.Cart
{
    public partial class CartPage : DriverUtilitiesInitializer
    {
        private readonly DriverHelper _driverHelper;

        public CartPage(DriverHelper driverHelper) : base(driverHelper)
        {
            _driverHelper = driverHelper;
        }

        public void ClickAddToCartButton()
        {
            _driverHelper.LocateElement(AddToCartButton).Click();
        }

        public void ClickCartIcon()
        {
            waitHelper.WaitForElementToBeClickable(CartIcon, 5);
            _driverHelper.LocateElement(CartIcon).Click();
        }

        public void SortLowToHigh()
        {
            IWebElement sortDropDownButton = _driverHelper.LocateElement(SortDropDown);
            Dropdown dropDownElement = new Dropdown(_driverHelper, sortDropDownButton);
            dropDownElement.OptByText("Price (low to high)");
        }
    }
}
