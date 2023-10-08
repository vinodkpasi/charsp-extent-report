using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports.Reporter.Config;
namespace TestProject2.Hooks
{
    [TestClass]
    public class ExtentHooks
    {
        public TestContext TestContext { get; set; }
        
        public static ExtentTest ExtentTest { get; set; }
        
        static ExtentReports ExtentReports { get; set; }

        [AssemblyInitialize]
        public static void ExtentAssemblyInit(TestContext context)
        {
            ExtentReports = new ExtentReports();
            ExtentReports.AddSystemInfo("Host Name", Environment.MachineName);
            ExtentReports.AddSystemInfo("Environment", "QA");
            ExtentReports.AddSystemInfo("Database", "SQL");
            ExtentReports.AddSystemInfo("User Name", Environment.UserName);
            string assemblyPath = Assembly.GetCallingAssembly().Location;
            string projectRootPath = assemblyPath.Substring(0, assemblyPath.LastIndexOf("bin"));
            string reportPath = $"{projectRootPath}Reports\\Report{DateTime.Now.ToString("_MMddyyyy_hhmmtt")}.html";
            ExtentSparkReporter htmlreporter = new ExtentSparkReporter(reportPath);


            //Setting Theme
            htmlreporter.Config.Theme = Theme.Dark;
            //Setting ReportName
            htmlreporter.Config.ReportName = "Test Report";
            //Setting DocumentTitle
            htmlreporter.Config.DocumentTitle = "Test Title";
            //Setting Timeline
            htmlreporter.Config.TimelineEnabled = false;
            //Setting Protocol
            htmlreporter.Config.Protocol = Protocol.HTTPS;
            //Setting Encoding
            htmlreporter.Config.Encoding = "UTF-8";
            //Setting JS
            htmlreporter.Config.JS = "";
            //Setting CSS
            htmlreporter.Config.CSS = "";
            //Setting OfflineMode
            htmlreporter.Config.OfflineMode = true;
            

            //Loading configuration using xml file
           //  htmlreporter.LoadConfig($"{projectRootPath}extent-config.json");

            ExtentReports.AttachReporter(htmlreporter);
        }

        [TestInitialize]
        public void ExtentTestInit()
        {
            ExtentTest = ExtentReports.CreateTest(TestContext.TestName);
            ExtentTest.Log(Status.Info, "Test Start");
        }

        [AssemblyCleanup]
        public static void ExtentAssemblyCleanup()
        {
            ExtentReports.Flush();
        }

        [TestCleanup]
        public void ExtentTestCleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
                ExtentTest.Log(Status.Pass, "Test Pass");
        }
    }
}
