using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace Expedia.com.Framework
{
    [Binding]
    public class Settings
    {
        private IWebDriver driver;
        private static string processname;
        private static string screenshotName = DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss-ff") + "_" + ConfigurationManager.AppSettings["Browser"] + ".png";
        private readonly ScenarioContext scenarioContext;

        public Settings(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public IWebDriver Init()
        {
            string browser = ConfigurationManager.AppSettings["Browser"];
            switch (browser)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    processname = "firefox";
                    Console.WriteLine("Runing test in Firefox");
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    processname = "IEDriverServer";
                    Console.WriteLine("Runing test in IE");
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    processname = "chromedriver";
                    Console.WriteLine("Runing test in Chrome");
                    break;
                default:
                    break;
            }
            scenarioContext.Add("driver", driver);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }


        [AfterScenario]
        private void Quit()
        {
            string extendedLogging = ConfigurationManager.AppSettings["ExtendedLogging"];
            switch (extendedLogging)
            {
                case "True":
                    if (scenarioContext.TestError != null)
                    {
                        var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                        string dir = Path.GetDirectoryName(location) + "\\failed_tests\\" + scenarioContext.ScenarioInfo.Title + "\\";
                        Console.WriteLine("An error occured -> " + scenarioContext.TestError.Message);
                        Console.WriteLine("Screenshot created -> " + dir + screenshotName);
                        TakeScreenShot(driver, dir);
                    }
                    break;
                case "False":
                    break;
            }
            
            driver.Quit();
        }

        public static void TakeScreenShot(IWebDriver driver, string savePath)
        {
            var fileName = savePath + screenshotName;
            ITakesScreenshot screenshotHandler = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
        }

        [AfterTestRun]
        private static void KillDriverProcess()
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName(processname))
                { 
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            };
        }
    }
}
