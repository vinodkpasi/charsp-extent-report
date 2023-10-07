using OpenQA.Selenium;
using System.Reflection;
namespace TestProject2
{
    public class ScreenshotUtil
    {
        public static string CaptureScreenshot(IWebDriver driver, string imagePath)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(imagePath, ScreenshotImageFormat.Png);
            return imagePath;
        }
    }
}
