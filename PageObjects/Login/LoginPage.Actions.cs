using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.AppUtils;


namespace PageObjects.Login
{
    public partial class LoginPage : DriverUtilitiesInitializer
    {
        private readonly DriverHelper _driverHelper;
        
        public LoginPage(DriverHelper driverHelper) : base(driverHelper)
        {
            _driverHelper = driverHelper;
        }
        public void EnterUsername(string username)
        {
            _driverHelper.LocateElement(UserNameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driverHelper.LocateElement(PasswordField).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            _driverHelper.LocateElement(LoginButton).Click();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
        }
        
    }
}
