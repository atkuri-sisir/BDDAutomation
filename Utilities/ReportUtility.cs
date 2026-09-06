using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter.Configuration;
using System.Reflection;

namespace Utilities
{
    public sealed class ReportUtility
    {
        private static ReportUtility _reportUtilityObj;
        public ExtentReports ExtentReport;
        public ExtentTest Feature;
        public ExtentTest Scenario;
        public ExtentTest Step;
        private string _dir;
        private string _testResultPath;

        private ReportUtility()
        {
            _dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            _testResultPath = _dir.Replace("bin\\Debug\\net6.0", "TestResults\\");

            var htmlReporter = new ExtentHtmlReporter(_testResultPath);
            htmlReporter.Config.DocumentTitle = "automation tests status report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            ExtentReport = new ExtentReports();
            ExtentReport.AttachReporter(htmlReporter);
        }
        public static ReportUtility GetReportInstance()
        {
            if(_reportUtilityObj == null)
            {
                _reportUtilityObj = new ReportUtility();
            }
            return _reportUtilityObj;
        }

        public void TearDownExtentReport()
        {
            ExtentReport.Flush();
        }
    }
}
