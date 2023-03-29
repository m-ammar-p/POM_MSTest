using Microsoft.VisualStudio.TestTools.UnitTesting;
using POM_MSTest.BaseClass;
using POM_MSTest.PageClass;
using POM_MSTest.ReportClass;
using System;

namespace POM_MSTest
{
    [TestClass]
    public class TCExecution: ExtentReport
    {
        #region Get Set TestContext

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
        #endregion

        #region Assembly INIT AND CLEANUP
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            LogReport("TestReport");
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            extentReports.Flush();
        }
        #endregion

        #region CLASS INIT AND CLEANUP
        [ClassInitialize]
        public static void GetTestContext(TestContext test)
        {

        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {

        }
        #endregion


        #region TEST INIT AND CLEANUP
        [TestInitialize]
        public void TestInit()
        {
            // Extent Reports INIT
            exParentTest = extentReports.CreateTest(TestContext.TestName);

            SeleniumInit();
        } // End of TestInit

        [TestCleanup]
        public void TestCleanUp()
        {
            SeleniumQuit();
        } // End of SeleniumQuit
        #endregion


        [TestMethod]
        [TestCategory("Login Page")]
        [TestCategory("Login")]
        public void Login_TC001()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login("https://adactinhotelapp.com");
        }

        [TestMethod]
        [TestCategory("Login Page")]
        [TestCategory("Login CSV")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"..\..\DataFiles\Data.csv", "data#csv", DataAccessMethod.Sequential)]
        public void LoginWithCSV_TC002()
        {
            string url = TestContext.DataRow[0].ToString();
            string userName = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();

            LoginPage loginPage = new LoginPage();
            loginPage.Login(url, userName, password);
        }

        [TestMethod]
        [TestCategory("Login Page")]
        [TestCategory("Login XML")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"..\..\DataFiles\\Data.xml", "Login", DataAccessMethod.Sequential)]
        public void LoginWithXML_TC003()
        {
            string url = TestContext.DataRow[0].ToString();
            string userName = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();

            LoginPage loginPage = new LoginPage();
            loginPage.Login(url, userName, password);
        }

        [TestMethod]
        [TestCategory("Login Page")]
        [TestCategory("Login DataRow")]
        [DataRow("http://adactinhotelapp.com/", "AmirImam", "AmirImam")]
        [DataRow("http://adactinhotelapp.com/", "@#$@#$@", "@#$@#$")]
        [DataRow("http://adactinhotelapp.com/", "Invalid", "Invalid")]
        [DataRow("http://adactinhotelapp.com/", " ", " ")]
        public void LoginWithDataRow_TC004(string url, string userName, string password)
        {

            LoginPage loginPage = new LoginPage();
            loginPage.Login(url, userName, password);
        }

        [TestMethod]
        [TestCategory("Login Page")]
        [TestCategory("Login Extent Report XML")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"..\..\DataFiles\\Data.xml", "Login", DataAccessMethod.Sequential)]
        public void LoginExtentReport_TC005()
        {
            string url = TestContext.DataRow["url"].ToString();
            string userName = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();

            exChildTest = exParentTest.CreateNode("Open Url");
            OpenUrl(driver, url);

            LoginPage loginPage = new LoginPage();
            loginPage.LoginExtentReport(userName, password);
        }


    } // End of TCExecution
} // End of namespace
