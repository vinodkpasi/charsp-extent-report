using OpenQA.Selenium;
using System.Reflection;
namespace TestProject2
{
    public class ScreenshotUtil
    {
        public static string CaptureScreenshot(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string assemblyPath = Assembly.GetCallingAssembly().Location;
            string imagePath = assemblyPath.Substring(0, assemblyPath.LastIndexOf("bin")) + "Reports\\" + screenShotName + ".png";
            screenshot.SaveAsFile(imagePath, ScreenshotImageFormat.Png);
            return imagePath;
        }
    }
}
