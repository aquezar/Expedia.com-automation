using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Expedia.com.Pages
{
    class Payment
    {
        private IWebDriver pageDriver;
        double convertedTotalPrice;
        double priceOfTrip;
        private string departureDate;

        [FindsBy(How = How.XPath, Using = ".//span[contains(@id, 'totalPriceForPassenger')]")]
        private IList<IWebElement> tripSummary { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='trip-summary']//a[@data-toggle-text='One Way Flight']")]
        private IWebElement flightDetails { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='trip-summary']//div[@class='date-info']")] //".//*[@id='flight-details']//span[@class='flight-info-date font-change']"
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
            Assert.IsTrue(pageDriver.Title.Equals("Expedia: Payment"));
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
        }

        private void ConvertTripDate(string date)
        {
            var t = date.Split('/');
            int day;
            int month;
            int year;
            int.TryParse(t[2], out year);
            int.TryParse(t[0], out month);
            int.TryParse(t[1], out day);
            DateTime convertedDate = new DateTime(year, month, day);
            departureDate = convertedDate.ToString("ddd, MMM d");
        }

        public void CheckTripDate(string date)
        {
            ConvertTripDate(date);
            Assert.AreEqual(departureDate, flightDate.Text);
        }

        public void CheckDepartureAirport(string from)
        {
            Assert.AreEqual(from, departureAirportCode.Text);
        }

        public void CheckDepartureTime(List<string> tripInfo)
        {
            Assert.AreEqual(tripInfo[2], (departureTime.Text.Remove(departureTime.Text.Length - 1)));
        }

        public void CheckArrivalAirport(string to)
        {
            Assert.AreEqual(to, arrivalAirportCode.Text);
        }

        public void CheckArrivalTime(List<string> tripInfo)
        {
            Assert.AreEqual(tripInfo[3], (arrivalTime.Text.Remove(arrivalTime.Text.Length - 1)));
        }

        public void CheckFlightDuration(List<string> tripInfo)
        {
            string flightDurationAndStops;
            if(flightStops.Text == "Nonstop")
            {
                flightDurationAndStops = flightDuration.Text + " " + flightStops.Text;
            }
            else
            {
                flightDurationAndStops = flightDuration.Text + " " + (flightStops.Text.Remove(flightStops.Text.Length - 1));
            }
            
            Assert.AreEqual(tripInfo[4], flightDurationAndStops);
        }

        private void ConvertTotalPrice()
        {
            double.TryParse(totalPrice.Text.Substring(1), out convertedTotalPrice);
        }

        public void CheckTotalPrice()
        {
            
            for (int i = 0; i <= tripSummary.Count - 1; i++)
            {
                double priceOfTicket;  
                double.TryParse(tripSummary[i].Text.Substring(1), out priceOfTicket);
                priceOfTrip += priceOfTicket;                
            }
            
            ConvertTotalPrice();
            Assert.IsTrue(convertedTotalPrice - priceOfTrip <= 0.01);
        }
    }
}
