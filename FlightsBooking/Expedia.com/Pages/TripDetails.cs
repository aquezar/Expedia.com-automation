using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class TripDetails
    {
        private IWebDriver pageDriver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='flightModule-0']/article/div[2]/div[2]/div[1]/span[2]")]
        private IWebElement TDFrom { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='flightModule-0']/article/div[2]/div[2]/div[2]/span[2]")]
        private IWebElement TDTo { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='trip-totals']//span[@class='visuallyhidden']")]  //".//*[@id='tsTotal']//span[2]"
        private IWebElement tripTotal { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'totalPriceForPassenger')]")] 
        private IList<IWebElement> tripForPassanger { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='FlightUDPBookNowButton1']//button[@class='btn-primary btn-action']")]
        private IWebElement ContinueBooking { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='details']//button[@class='btn-secondary btn-action']")]
        private IWebElement BookButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='departure-airport-automation-label-0']")]
        private IWebElement TripFrom { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='arrival-airportcode-automation-label-0']")]
        private IWebElement TripTo { get; set; }

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

        public void CompareTicketsPricesInTripSummary(List<string> tripInfo)
        {
            List<double> ticketsPricesList = new List<double>();
            double priceOfTrip = 0.0;
            int passangers = (int)ScenarioContext.Current["passangers"];
            for (int i = passangers; i <= tripForPassanger.Count - 1; i++)
            {
                double ticketPrice;
                double.TryParse(tripInfo[1].Substring(1), out ticketPrice);
                double priceForPassanger;
                double.TryParse(tripForPassanger[i].Text.Substring(1), out priceForPassanger);
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
            double.TryParse(tripTotal.GetAttribute("textContent").Substring(1), out convertedTotalPrice);
            return convertedTotalPrice;
        }

        public void SwitchToTripDetailsTab()
        {
            pageDriver.SwitchTo().Window(pageDriver.WindowHandles.Last());

            /*if (pageDriver.Title != "Trip Details | Expedia")
            {
                pageDriver.Close();
                pageDriver.SwitchTo().Window(pageDriver.WindowHandles.Last());
            }*/

        }

        public void CompareDepartureAndDestination(List<string> tripInfo, string from, string to)
        {
            Assert.AreEqual(tripInfo[0], (from + " - " + to));
        }

        private string convertDepartureDate(string departure)
        {
            string departureDate;
            var t = departure.Split('/');
            int day;
            int month;
            int year;
            int.TryParse(t[2], out year);
            int.TryParse(t[0], out month);
            int.TryParse(t[1], out day);
            DateTime convertedDate = new DateTime(year, month, day);
            departureDate = convertedDate.ToString("ddd, MMM d");
            return departureDate;
        }

        public void CompareDates(string date)
        {
            Assert.AreEqual(convertDepartureDate(date), flightDate.Text);
        }

        public void CompareDepartureTime(List<string> tripInfo)
        {
            Assert.AreEqual(tripInfo[2], (flightDepartureTime.Text.Remove(flightDepartureTime.Text.Length - 1)));
        }

        public void CompareArrivalTime(List<string> tripInfo)
        {
            Assert.AreEqual(tripInfo[3], (flightArrivalTime.Text.Remove(flightArrivalTime.Text.Length - 1)));
        }

        public void CompareFlightDuration(List<string> tripInfo)
        {
            Assert.AreEqual(tripInfo[4], flightDuration.Text);
        }


    }
}
