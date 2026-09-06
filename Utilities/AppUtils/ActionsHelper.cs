using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Utilities.AppUtils
{
    public class ActionsHelper
    {
        private readonly DriverHelper _driverHelper;
        private static Actions _actionObj;

        public ActionsHelper(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }

        public void CreateAction()
        {
            _actionObj = _driverHelper.GetAction();
        }

        public static void EnterCapitalizedInput(string input)
        {
            _actionObj.KeyDown(Keys.Shift)
                .SendKeys(input)
                .KeyUp(Keys.Shift).Perform();
        }

        public static void CopyEverything()
        {
            _actionObj.KeyDown(Keys.Control)
                .SendKeys("a")
                .SendKeys("c")
                .KeyUp(Keys.Control).Perform();
        }
    }
}
