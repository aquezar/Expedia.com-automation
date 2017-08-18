using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Linq;

namespace Expedia.com.Framework
{
    class Helper
    {
        private static string tripDetailTitle = "Trip Detail | Expedia";
        public static string ConvertDate(string date, char splitSymbol, string format)
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

        public static void HighlightElement(IWebElement element, IWebDriver driver)
        {
            string extendedLogging = ConfigurationManager.AppSettings["ExtendedLogging"];
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

        public static void UnhighlightElement(IWebElement element, IWebDriver driver)
        {
            string extendedLogging = ConfigurationManager.AppSettings["ExtendedLogging"];
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

        public static bool IsElementPresent(IWebElement element)
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

        public static void CloseCommercial(IWebDriver driver) //(string commercialWinTitle, IWebDriver driver)
        {
            //Close commercial if opened 
            string commercialTabHandle = driver.WindowHandles.Last();
            var commercialWindow = driver.SwitchTo().Window(commercialTabHandle);

            if (!commercialWindow.Title.Contains("| Expedia")) //(commercialWindow.Title != tripDetailTitle)
            {
                driver.Close();
                var originalTab = driver.SwitchTo().Window(driver.WindowHandles.First());
            }
            else
            {
                return;
            }
        }
    }
}
