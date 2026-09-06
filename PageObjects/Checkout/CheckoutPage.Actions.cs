using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.AppUtils;

namespace PageObjects.Checkout
{
    public partial class CheckoutPage : DriverUtilitiesInitializer
    {
        private readonly DriverHelper _driverHelper;

        public CheckoutPage(DriverHelper driverHelper) : base(driverHelper)
        {
            _driverHelper = driverHelper;
        }

        public void EnterFirstNameField(string firstName)
        {
            _driverHelper.LocateElement(FirstNameField).SendKeys(firstName);
        }

        public void EnterLastNameField(string lastName)
        {
            _driverHelper.LocateElement(LastNameField).SendKeys(lastName);
        }

        public void EnterPincodeField(string pincode)
        {
            _driverHelper.LocateElement(PincodeField).SendKeys(pincode);
        }

        public void ClickContinueButton()
        {
            _driverHelper.LocateElement(ContinueButton).Click();
        }

        public void ClickFinishButton()
        {
            waitHelper.WaitForElementToBeClickable(FinishButton, 5);
            _driverHelper.LocateElement(FinishButton).Click();
        }
    }
}
