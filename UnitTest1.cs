using AventStack.ExtentReports;
using OpenQA.Selenium;
using TestProject2.CustomAttribtes;
using TestProject2.Hooks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject2
{
    [TestClass]
    public class UnitTest1: DriverHooks
    {
        [ExtentTestMethod]
        public void Successful_Login_With_Valid_Credentials()
        {
            Driver.Url = "https://the-internet.herokuapp.com/login";
            Driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            ExtentTest.Log(Status.Pass, "Entered username");

            Driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            ExtentTest.Log(Status.Pass, "Entered password");

            Driver.FindElement(By.CssSelector("[type=submit]")).Click();
            ExtentTest.Log(Status.Pass, "Clicked on submit button");

            string message = Driver.FindElement(By.Id("flash-messages")).Text;
            Assert.IsTrue(message.Contains("You logged into a secure area!"));
            ExtentTest.Log(Status.Pass, "Vefied login successfully");
        }

        [ExtentTestMethod]
        public void Successful_Login_With_Invalid_Credentials()
        {

            Driver.Url = "https://the-internet.herokuapp.com/login";
            Driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            ExtentTest.Log(Status.Pass, "Entered username");

            Driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            ExtentTest.Log(Status.Pass, "Entered password");

            Driver.FindElement(By.CssSelector("[type=submit]")).Click();
            ExtentTest.Log(Status.Pass, "Clicked on submit button");

            string message = Driver.FindElement(By.Id("flash-messagess")).Text;
            Assert.IsTrue(message.Contains("You logged into a secure area!"));
            ExtentTest.Log(Status.Pass, "Vefied login successfully");
        }
    }
}




