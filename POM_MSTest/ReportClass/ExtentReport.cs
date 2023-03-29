using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using POM_MSTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_MSTest.ReportClass
{
    public class ExtentReport : BasePage
    {
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;

        public static void LogReport(string testCase)
        {
            extentReports = new ExtentReports();
            dirpath = @"..\..\TestExecutionReports\" + '_' + testCase;

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            htmlReporter.Config.Theme = Theme.Standard;

            extentReports.AttachReporter(htmlReporter);


        } // LogReport

    } // End of ExtentReport
}
