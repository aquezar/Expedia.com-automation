using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Expedia.com.Pages
{
    public class TripDetails
    {
        private IWebDriver pageDriver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='flightModule-0']/article/div[2]/div[2]/div[1]/span[2]")]
        private IWebElement TDFrom { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='flightModule-0']/article/div[2]/div[2]/div[2]/span[2]")]
        private IWebElement TDTo { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@id='tsTotal']//span[@class='visuallyhidden']")]
        private IWebElement tripTotal { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[@class='toggle after-open']//span[contains(@id, 'totalPriceForPassenger')]")]
        private IList<IWebElement> tripForPassanger { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='FlightUDPBookNowButton1']//button[@class='btn-primary btn-action']")]
        private IWebElement ContinueBooking { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='details']//button[@class='btn-secondary btn-action']")]
        private IWebElement BookButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='departure-airport-automation-label-0']")]
        private IWebElement TripFrom { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='arrival-airportcode-automation-label-0']")]
        private IWebElement TripTo { get; set; }

        public TripDetails(IWebDriver driver)
        {
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        public void TripDetailPageOpens(string TripDetailTabTitle)
        {
            //unable to assert page title in a different way
            WebDriverWait wait = new WebDriverWait(pageDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleIs(TripDetailTabTitle + " | Expedia"));
            // --
            Assert.AreEqual(TripDetailTabTitle + " | Expedia", pageDriver.Title);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                pageDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public void Continue()
        {
            if (IsElementPresent(By.XPath(".//*[@id='FlightUDPBookNowButton1']//button[@class='btn-primary btn-action']")))
            {
                ContinueBooking.Click();
            }
            else
            {
                BookButton.Click();
            }               
            
        }

        public void CompareFlightsInfo(List<string> tripInfo, string from, string to)
        {
            Assert.AreEqual(tripInfo[0], (from + " - " + to));
          /*  for (int i = 1; i <= tripForPassanger.Count-1; i++)
            {
                Assert.AreEqual(tripInfo[1], tripForPassanger[i].Text);                    
            } */
        }
    }
}
