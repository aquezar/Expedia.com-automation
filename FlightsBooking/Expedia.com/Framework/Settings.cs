using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Expedia.com.Framework
{
    [Binding]
    public class Settings
    {
        public static IWebDriver driver;
        private static string screenshotName = ScenarioContext.Current.ScenarioInfo.Title + "_" + ConfigurationManager.AppSettings["Browser"] + "_" + DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss") + ".png";

        [BeforeScenario]
        public IWebDriver Init()
        {
            string browser = ConfigurationManager.AppSettings["Browser"];
            switch (browser)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    Console.WriteLine("Runing test in Firefox");
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    Console.WriteLine("Runing test in IE");
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    Console.WriteLine("Runing test in Chrome");
                    break;
                default:
                    break;
            }
            ScenarioContext.Current["driver"] = driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return driver;
        }


        [AfterScenario]
        private void Quit()
        {
            if(ScenarioContext.Current.TestError != null)
            {
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string dir = System.IO.Path.GetDirectoryName(location) + "\\failed_tests\\"; 
                Console.WriteLine("An error occured -> " + ScenarioContext.Current.TestError.Message);
                Console.WriteLine("Screenshot created in dir ->" + dir + screenshotName);
                TakeScreenShot(driver, dir);
            }

            driver.Quit();
        }

        public static void TakeScreenShot(IWebDriver driver, string savePath)
        {
            //var title = driver.Title;
            //var dateTime = DateTime.Now.ToString();
            var fileName = savePath + screenshotName;
            ITakesScreenshot screenshotHandler = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
        }
    }
}
