using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.AppUtils
{
    public class DriverUtilitiesInitializer
    {
        public WaitHelper waitHelper;
        public ScreenshotHelper screenshotHelper;
        public ActionsHelper actionsHelper;
        public AlertHelper alertHelper;
        public JavaScriptHelper javaScriptHelper;
        public DriverUtilitiesInitializer(DriverHelper driverHelper)
        {
            waitHelper = new WaitHelper(driverHelper);
            screenshotHelper = new ScreenshotHelper(driverHelper);
            actionsHelper = new ActionsHelper(driverHelper);
            alertHelper = new AlertHelper(driverHelper);
            javaScriptHelper = new JavaScriptHelper(driverHelper);
        }
    }
}
