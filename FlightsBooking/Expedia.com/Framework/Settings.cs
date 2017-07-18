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
        public IWebDriver driver;

        [BeforeScenario]
        public IWebDriver InitFireFox()
        {
            string browser = ConfigurationManager.AppSettings["Browser"];
            switch (browser)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    break;
            }
                    //driver = new FirefoxDriver();
                    ScenarioContext.Current["driver"] = driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return driver;
        }


        [AfterScenario]
        private void Quit()
        {
            driver.Quit();
        }
    }
}
