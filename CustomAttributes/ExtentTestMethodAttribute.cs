using AventStack.ExtentReports;
using TestProject2.Hooks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject2.CustomAttribtes
{
    public class ExtentTestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            TestResult[] results = base.Execute(testMethod);
            foreach (TestResult result in results)
            {
                if (result.Outcome == UnitTestOutcome.Failed)
                {
                    ExtentHooks.ExtentTest.Log(Status.Info, "Message:" + result.TestFailureException.Message);
                    if (result.TestFailureException.StackTrace != null)
                        ExtentHooks.ExtentTest.Log(Status.Info, "StackTrace:" + result.TestFailureException.StackTrace.ToString());
                    if (result.TestFailureException.InnerException != null)
                        ExtentHooks.ExtentTest.Log(Status.Info, "InnerException:" + result.TestFailureException.InnerException.ToString());
                }
            }
            ExtentHooks.ExtentTest.Log(Status.Info, "Test End");
            return results;
        }
    }
}
