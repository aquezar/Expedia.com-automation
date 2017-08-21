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
        private static string WebDriverProcessName;
        
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
                    WebDriverProcessName = "firefox";
                    Console.WriteLine("Runing test in Firefox");
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    WebDriverProcessName = "IEDriverServer";
                    Console.WriteLine("Runing test in IE");
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    WebDriverProcessName = "chromedriver";
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
                        Console.WriteLine("Screenshot created -> " + dir + Helper.screenshotName);
                        Helper.TakeScreenShot(driver, dir);
                    }
                    break;
                case "False":
                    break;
            }
            
            driver.Quit();
        }

        [AfterTestRun]
        private static void KillWebDriverProcess()
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName(WebDriverProcessName))
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
