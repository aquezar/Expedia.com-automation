using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Expedia.com.Framework
{
    class Helper
    {
        private static string extendedLogging = ConfigurationManager.AppSettings["ExtendedLogging"];
        public static string screenshotName = DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss-ff") + "_" + ConfigurationManager.AppSettings["Browser"] + ".png";

        //Converting date from string to DateTime
        //and returning it as string in specified format 
        public static string ConvertStringToDateFormat(string date, char splitSymbol, string format)
        {
            string departureDate;
            var t = date.Split(splitSymbol);
            int day;
            int month;
            int year;
            int.TryParse(t[2], out year);
            int.TryParse(t[0], out month);
            int.TryParse(t[1], out day);
            DateTime convertedDate = new DateTime(year, month, day);
            departureDate = convertedDate.ToString(format);
            return departureDate;
        }

        public static void HighlightIWebElement(IWebElement element, IWebDriver driver)
        {
            switch (extendedLogging)
            {
                case "True":
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, " border: 3px solid greenyellow;");
                    break;
                case "False":
                    break;
            }            
        }

        public static void UnhighlightIWebElement(IWebElement element, IWebDriver driver)
        {
            switch (extendedLogging)
            {
                case "True":
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, " border: 0px;");
                    break;
                case "False":
                    break;
            }
        }

        //Checks that IWebElement present on page
        public static bool IsIWebElementPresent(IWebElement element)
        {
            try
            {
                Assert.IsTrue(element.Displayed);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        //Closing commercial window.
        //Used to close commercial in come cases when clicking and switching to other tabs
        public static void CloseCommercialWindow(IWebDriver driver)
        {
            string commercialTabHandle = driver.WindowHandles.Last();
            var commercialWindow = driver.SwitchTo().Window(commercialTabHandle);

            if (!commercialWindow.Title.Contains("| Expedia"))
            {
                driver.Close();
                var originalTab = driver.SwitchTo().Window(driver.WindowHandles.First());
            }
            else
            {
                return;
            }
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

    }
}
