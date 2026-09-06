using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Checkout
{
    public partial class CheckoutPage
    {
        public By FirstNameField = By.XPath("//input[@id='first-name']");
        public By LastNameField = By.XPath("//input[@id='last-name']");
        public By PincodeField = By.XPath("//input[@id='postal-code']");
        public By ContinueButton = By.XPath("//input[@id='continue']");
        public By FinishButton = By.XPath("//button[@id='finish']");
    }
}
