using Expedia.com.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Expedia.com.Pages
{
    class Payment
    {
        private IWebDriver pageDriver;

        private string pageTitle = "Expedia: Payment";
        private string departureTitleFlightDetailsLocator = ".departure-title";
        private string flightNonstop = "Nonstop";

        [FindsBy(How = How.XPath, Using = ".//span[contains(@id, 'totalPriceForPassenger')]")]
        private IList<IWebElement> tripSummary { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='trip-summary']//a[@data-toggle-text='One Way Flight']")]
        private IWebElement flightDetails { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='trip-summary']//div[@class='date-info']")] 
        private IWebElement flightDate { get; set; }

        [FindsBy(How = How.ClassName, Using = "departure-airport-codes")]
        private IWebElement departureAirportCode { get; set; }

        [FindsBy(How = How.ClassName, Using = "departure-time")]
        private IWebElement departureTime { get; set; }

        [FindsBy(How = How.ClassName, Using = "arrival-airport-codes")]
        private IWebElement arrivalAirportCode { get; set; }

        [FindsBy(How = How.ClassName, Using = "arrival-time")]
        private IWebElement arrivalTime { get; set; }

        [FindsBy(How = How.ClassName, Using = "duration")]
        private IWebElement flightDuration { get; set; }

        [FindsBy(How = How.ClassName, Using = "stop-information")]
        private IWebElement flightStops { get; set; }

        [FindsBy(How = How.Id, Using = "totalPriceForTrip")]
        private IWebElement totalPrice { get; set; }

        public Payment (IWebDriver driver)
        {
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        public void PaymentPageOpens()
        {
            IJavaScriptExecutor js = pageDriver as IJavaScriptExecutor;
            string title = (string)js.ExecuteScript("return document.title");
            Assert.IsTrue(title.Equals(pageTitle));
            //Assert.IsTrue(pageDriver.Title.Equals(pageTitle));
        }

        public void TripSummaryCheck(List<double> ticketPrice)
        {
            for (int i = 0; i <= tripSummary.Count - 1; i++)
            {
                double priceForPassanger;
                double.TryParse(tripSummary[i].Text.Substring(1), out priceForPassanger);
                Assert.AreEqual(ticketPrice[i], priceForPassanger);
            }
        }

        public void ShowFlightDetails()
        {
            flightDetails.Click();
            WebDriverWait wait = new WebDriverWait(pageDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(departureTitleFlightDetailsLocator)));
        }

        public void CheckTripDate(string date)
        {
            Assert.AreEqual(Helper.ConvertDate(date, '/', "ddd, MMM d"), flightDate.Text);
        }

        public void CheckDepartureAirport(string from)
        {
            Assert.AreEqual(from, departureAirportCode.Text);
        }

        public void CheckDepartureTime(List<string> flightInfo)
        {
            Assert.AreEqual(flightInfo[2], (departureTime.Text.Remove(departureTime.Text.Length - 1)));
        }

        public void CheckArrivalAirport(string to)
        {
            Assert.AreEqual(to, arrivalAirportCode.Text);
        }

        public void CheckArrivalTime(List<string> flightInfo)
        {
            Assert.AreEqual(flightInfo[3], (arrivalTime.Text.Remove(arrivalTime.Text.Length - 1)));
        }

        public void CheckFlightDuration(List<string> flightInfo)
        {
            string flightDurationAndStops;
            if(flightStops.Text == flightNonstop)
            {
                flightDurationAndStops = flightDuration.Text + " " + flightStops.Text;
            }
            else
            {
                flightDurationAndStops = flightDuration.Text + " " + (flightStops.Text.Remove(flightStops.Text.Length - 1));
            }
            
            Assert.AreEqual(flightInfo[4], flightDurationAndStops);
        }

        private double ConvertTotalPrice()
        {
            double convertedTotalPrice;
            double.TryParse(totalPrice.Text.Substring(1), out convertedTotalPrice);
            return convertedTotalPrice;
        }

        public void CheckTotalPrice()
        {
            double priceOfTrip = 0.0;
            for (int i = 0; i <= tripSummary.Count - 1; i++)
            {
                double priceOfTicket;  
                double.TryParse(tripSummary[i].Text.Substring(1), out priceOfTicket);
                priceOfTrip += priceOfTicket;                
            }
            Assert.IsTrue(ConvertTotalPrice() - priceOfTrip <= 0.01);
        }
    }
}
