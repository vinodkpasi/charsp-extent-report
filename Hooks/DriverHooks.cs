using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject2.Hooks
{
    public class DriverHooks:ExtentHooks
    {
        [TestInitialize]
        public void DriverTestInit()
        {
            Driver = new ChromeDriver();
        }

        [TestCleanup]
        public void DriverTestCleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                ExtentTest.Log(Status.Fail, "Test Fail");
                ExtentTest.Log(Status.Info, "Screenshot", new ScreenCapture(ScreenshotUtil.CaptureScreenshot(Driver,TestContext.TestName + DateTime.Now.ToString("_MMddyyyy_hhmmtt"))));
            }
            if (Driver != null)
                Driver.Quit();
        }

        protected IWebDriver Driver
        {
            get;
            set;
        }
    }
}
