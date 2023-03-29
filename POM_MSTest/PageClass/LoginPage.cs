using OpenQA.Selenium;
using POM_MSTest.BaseClass;
using POM_MSTest.ReportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_MSTest.PageClass
{
    public class LoginPage: BasePage
    {
        #region Login Page Locators
        // Login Page Locators

        By locUserName = By.Id("username");
        By locPassword = By.Id("password");
        By locBtnLogin = By.Id("login");

        #endregion

        public void Login(string url)
        {
            driver.Url = url;

            driver.FindElement(locUserName).SendKeys("AmirImam");
            driver.FindElement(locPassword).SendKeys("AmirImam");
            driver.FindElement(locBtnLogin).Click();
        } // End of Login

        public void Login(string url,string username, string password)
        {
            driver.Url = url;

            driver.FindElement(locUserName).SendKeys(username);
            driver.FindElement(locPassword).SendKeys(password);
            driver.FindElement(locBtnLogin).Click();
        } // End of Login DataSource

        public void LoginExtentReport(string username, string password)
        {
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Login");

            Write(driver, locUserName, username);
            Write(driver, locPassword, password);
            Click(driver, locBtnLogin);
        } // End of LoginExtentReport DataSource 

    } //End of LoginPage
} // End of namespace
