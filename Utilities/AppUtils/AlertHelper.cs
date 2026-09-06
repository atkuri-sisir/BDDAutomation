using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Utilities.AppUtils
{
    public class AlertHelper
    {
        private readonly DriverHelper _driverHelper;
        private IAlert _alert;

        public AlertHelper(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }
        
        public void SwitchToAlert()
        {
            _alert = _driverHelper.SwitchToAlert();
        }

        public void AcceptAlert()
        {
            _alert.Accept();
        }

        public void DismissAlert()
        {
            _alert.Dismiss();
        }

        public void EnterInput(string text)
        {
            _alert.SendKeys(text);
        }
    }
}
