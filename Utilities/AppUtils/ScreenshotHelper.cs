using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.AppUtils
{
    public class ScreenshotHelper
    {
        private readonly DriverHelper _driverHelper;

        public ScreenshotHelper(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }
        
        public void CaptureWholeScreenshot(string fileName)
        {
            var screenshot = _driverHelper.GetWholeScreenshot(fileName);
            string debugPath = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}";
            debugPath = debugPath.Replace("\\bin\\Debug\\net6.0", "\\Screenshots");
            screenshot.SaveAsFile($"{debugPath}\\{fileName}_{DateTime.Now:yyyyMMdd_HHmmssfff}.png"); 
        }

        public void CaptureScreenshotOfElement(IWebElement element, string fileName)
        {
            var screenshot = ((WebElement)element).GetScreenshot();
            string directoryPath = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}//Screenshots";
            string filePath = $"{directoryPath}//{fileName}_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";
            screenshot.SaveAsFile(filePath);
        }

    }
}
