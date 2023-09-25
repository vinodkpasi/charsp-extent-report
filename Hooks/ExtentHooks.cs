using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            ExtentReports.AddSystemInfo("User Name", Environment.UserName);
            string assemblyPath = Assembly.GetCallingAssembly().Location;
            string projectRootPath = assemblyPath.Substring(0, assemblyPath.LastIndexOf("bin"));
            string reportPath = $"{projectRootPath}Reports\\Report{DateTime.Now.ToString("_MMddyyyy_hhmmtt")}.html";
            var htmlreporter = new ExtentSparkReporter(reportPath);
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
