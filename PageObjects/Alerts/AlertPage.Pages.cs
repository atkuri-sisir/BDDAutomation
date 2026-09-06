using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Alerts
{
    public partial class AlertPage
    {
        protected By AlertsDiv = By.XPath("//h5[contains(text(),'Alerts')]");
        protected By AlertsTab = By.XPath("//span[text()='Alerts']");
        protected By SimpleAlertButton = By.XPath("//button[@id='alertButton']");
        protected By TimerAlertButton = By.XPath("//button[@id='timerAlertButton']");
        protected By ConfirmationAlertButton = By.XPath("//button[@id='confirmButton']");
        protected By PromptAlertButton = By.XPath("//button[@id='promtButton']");
    }
}
