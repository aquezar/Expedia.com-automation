using Expedia.com.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    class PaymentSteps
    {
        private IWebDriver driver;
        private List<double> ticketPrice;
        private List<string> flight = new List<string>();
        Payment payment;
        private readonly ScenarioContext scenarioContext;
        public PaymentSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];          
        }

        [Then(@"Payment page opens")]
        public void ThenPaymentPageOpens()
        {
            payment = new Payment(driver, scenarioContext);
            payment.PaymentPageOpens();       
        }

        [Then(@"I open Flight details")]
        public void ThenIOpenFlightDetails()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    payment.ShowFlightDetails();
                    break;
                case "True":
                    break;
            }   
        }

        [Then(@"I check flight (.*)")]
        public void ThenICheckFlightDate(string p0)
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    payment.CheckTripDate(p0);
                    break;
                case "True":
                    break;
            }          
        }

        [Then(@"I check departing (.*)")]
        public void ThenICheckDepartingAirport(string p0)
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    payment.CheckDepartureAirport(p0);
                    break;
                case "True":
                    break;
            }           
        }

        [Then(@"I check departure time")]
        public void ThenICheckDepartureTime()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    flight = (List<string>)scenarioContext["flight"];
                    payment.CheckDepartureTime(flight);
                    break;
                case "True":
                    break;
            }     
        }

        [Then(@"I check arrival (.*)")]
        public void ThenICheckArrivalAirport(string p0)
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    payment.CheckArrivalAirport(p0);
                    break;
                case "True":
                    break;
            }           
        }

        [Then(@"I check time of arrival")]
        public void ThenICheckTimeOfArrival()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    payment.CheckArrivalTime(flight);
                    break;
                case "True":
                    break;
            }         
        }

        [Then(@"I check duration of flight")]
        public void ThenICheckDurationOfFlight()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    payment.CheckFlightDuration(flight);
                    break;
                case "True":
                    break;
            }           
        }

        [Then(@"I check ticket price for each passanger")]
        public void ThenICheckTicketPriceForEachPassanger()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    ticketPrice = (List<double>)scenarioContext["ticketPrice"];
                    payment.TripSummaryCheck(ticketPrice);
                    break;
                case "True":
                    break;
            }          
        }

        [Then(@"I check total price")]
        public void ThenICheckTotalPrice()
        {
            payment.CheckTotalPrice();
        }


    }
}
