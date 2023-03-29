using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM_MSTest.ReportClass;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_MSTest.BaseClass
{
    public class BasePage
    {
        public static IWebDriver driver;

        public static void SeleniumInit()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
        } // End of SeleniumInit

        public static void SeleniumQuit()
        {
            driver.Quit();
        }// End of SeleniumInit

        public static void TakeScreenshot(IWebDriver driver, Status status, string stepDetail)
        {
            //// Add Full directory (Absolute) if you want to attached screenshots
            //string path = @"..\..\..\Screenshots\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            //Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            //image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            //ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
            //    .CreateScreenCaptureFromPath(path + ".png").Build());

            // No need to save Screnshots on Folder
            byte[] imageArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromBase64String(base64ImageRepresentation, "data:image/png;base64,").Build());

        }// End of TakeScreenshot

        public void Write(IWebDriver driver, By by, string data)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshot(driver, Status.Pass, "Enter ");
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Enter Failed" + ex);
            }
        } // End of Write

        public void Click(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(driver, Status.Pass, "Click");
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Click Failed " + ex);
            }
        } // End of Click

        public void OpenUrl(IWebDriver driver, string url)
        {
            try
            {
                driver.Url = url;
                TakeScreenshot(driver, Status.Pass, "Open url");
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Open Url Failed " + ex);
            }
        } // End of OpenUrl
    } // End of BasePage
} // End of namespace
