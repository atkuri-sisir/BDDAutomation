using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.AppUtils;

namespace PageObjects.Alerts
{
    public partial class AlertPage : DriverUtilitiesInitializer
    {
        private readonly DriverHelper _driverHelper;

        public AlertPage(DriverHelper driverhelper) : base(driverhelper)
        {
            _driverHelper = driverhelper;
        }
        public void ClickAlertsDiv()
        {
            javaScriptHelper.scrollUntilVisible(_driverHelper.LocateElement(AlertsDiv));
            _driverHelper.LocateElement(AlertsDiv).Click();
        }

        public void ClickAlertsTab()
        {
            _driverHelper.ExecuteJavaScriptCommand("arguments[0].scrollIntoView(true);", _driverHelper.LocateElement(AlertsTab));
            _driverHelper.LocateElement(AlertsTab).Click();
        }

        public void ClickSimpleAlertButton()
        {
            _driverHelper.LocateElement(SimpleAlertButton).Click();
        }

        public void ClickTimerAlertButton()
        {
            _driverHelper.LocateElement(TimerAlertButton).Click();
        }

        public void ClickConfirmationAlertButton()
        {
            _driverHelper.LocateElement(ConfirmationAlertButton).Click();
        }

        public void ClickPromptAlertButton()
        {
            _driverHelper.LocateElement(PromptAlertButton).Click();
        }
    }
}
