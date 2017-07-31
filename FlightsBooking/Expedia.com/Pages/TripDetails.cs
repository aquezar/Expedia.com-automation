using Expedia.com.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class TripDetails
    {
        private IWebDriver pageDriver;

        //xpath absolute path .//*[@id='flightModule-0']/article/div[2]/div[2]/div[1]/span[2]
        [FindsBy(How = How.ClassName, Using = "fdp-location")]
        private IWebElement fromAirport { get; set; }
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='flightModule-0']/div[2]/span[@class='fdp-location']")] 
        private IWebElement toAirport { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='trip-totals']//span[@class='visuallyhidden']")]  
        private IWebElement tripTotalPrice { get; set; }

        //css = span[id*='totalPriceForPassenger']
        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'totalPriceForPassenger')]")] 
        private IList<IWebElement> ticketPriceForPassanger { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='FlightUDPBookNowButton1']//button[@class='btn-primary btn-action']")]
        private IWebElement continueBookingButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='details']//button[@class='btn-secondary btn-action']")]
        private IWebElement bookButton { get; set; }

        //XPath = .//*[@id='departure-airport-automation-label-0']
        [FindsBy(How = How.CssSelector, Using = "#departure-airport-automation-label-0")]
        private IWebElement flightFromAirportCode { get; set; }

        //id = arrival-airportcode-automation-label-0
        [FindsBy(How = How.XPath, Using = ".//*[@id='arrival-airportcode-automation-label-0']")]
        private IWebElement flightToAirportCode { get; set; }

        [FindsBy(How = How.Id, Using = "departure-time-automation-label-0")]
        private IWebElement flightDepartureTime { get; set; }

        [FindsBy(How = How.Id, Using = "arrival-time-automation-label-0")]
        private IWebElement flightArrivalTime { get; set; }

        [FindsBy(How = How.Id, Using = "duration-automation-label-0")]
        private IWebElement flightDuration { get; set; }

        [FindsBy(How = How.Id, Using = "departure-date-0")]
        private IWebElement flightDate { get; set; }

        public TripDetails(IWebDriver driver)
        {
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        private bool IsElementPresent(IWebElement element)
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

        public void ClickContinueBookingButton()
        {
            if (IsElementPresent(continueBookingButton))
            {
                continueBookingButton.Click();
            }
            else
            {
                bookButton.Click();
            }                         
        }

        public void CompareTicketsPricesInTripSummary(List<string> flightInfo)
        {
            List<double> ticketsPricesList = new List<double>();
            double priceOfTrip = 0.0;
            int passangers = (int)ScenarioContext.Current["passangers"];
            for (int i = passangers; i <= ticketPriceForPassanger.Count - 1; i++)
            {
                double ticketPrice;
                double.TryParse(flightInfo[1].Substring(1), out ticketPrice);
                double priceForPassanger;
                double.TryParse(ticketPriceForPassanger[i].Text.Substring(1), out priceForPassanger);
                Assert.IsTrue((priceForPassanger - ticketPrice) <= 1.0);
                ticketsPricesList.Add(priceForPassanger);
                priceOfTrip += ticketPrice;
            }
            ConvertTotalPrice();
            Assert.IsTrue(ConvertTotalPrice() - priceOfTrip <= 0.01);

            ScenarioContext.Current["ticketPrice"] = ticketsPricesList;
        }

        private double ConvertTotalPrice()
        {
            double convertedTotalPrice;
            double.TryParse(tripTotalPrice.GetAttribute("textContent").Substring(1), out convertedTotalPrice);
            return convertedTotalPrice;
        }

        public void SwitchToTripDetailsTab()
        {
            pageDriver.SwitchTo().Window(pageDriver.WindowHandles.Last());
        }

        public void CompareDepartureAndDestination(List<string> flightInfo)
        {
            Assert.AreEqual(flightInfo[0], (flightFromAirportCode.Text + " - " + flightToAirportCode.Text));
        }

        public void CompareDates(string date)
        {
            Assert.AreEqual(Helper.ConvertDate(date, '/', "ddd, MMM d"), flightDate.Text);
        }

        public void CompareDepartureTime(List<string> flightInfo)
        {
            Assert.AreEqual(flightInfo[2], (flightDepartureTime.Text.Remove(flightDepartureTime.Text.Length - 1)));
        }

        public void CompareArrivalTime(List<string> flightInfo)
        {
            Assert.AreEqual(flightInfo[3], (flightArrivalTime.Text.Remove(flightArrivalTime.Text.Length -1)));
        }

        public void CompareFlightDuration(List<string> flightInfo)
        {
            Assert.AreEqual(flightInfo[4], flightDuration.Text);
        }

    }
}
