using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

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
        public void FailedStepScreenCapture()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                ExtentTest.Log(Status.Fail, "Test Fail");
                string assemblyPath = Assembly.GetCallingAssembly().Location;
                string screenShotName = TestContext.TestName + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".png";
                string screenShotPath = assemblyPath.Substring(0, assemblyPath.LastIndexOf("bin")) + "Reports\\" + screenShotName;
                ExtentTest.Log(Status.Info, "Screenshot", new ScreenCapture(ScreenshotUtil.CaptureScreenshot(Driver, screenShotPath)));
            }
        }

        [TestCleanup]
        public void DriverCleanup()
        {
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
