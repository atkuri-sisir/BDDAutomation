using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Login
{
    public partial class LoginPage
    {
        protected By UserNameField = By.Id("user-name");
        protected By PasswordField = By.Id("password");
        protected By LoginButton = By.Id("login-button");
        protected By ErrorMessage = By.Id("errorMessage");
    }
}
