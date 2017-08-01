using Expedia.com.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
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
            payment.ShowFlightDetails();
        }

        [Then(@"I check flight (.*)")]
        public void ThenICheckFlightDate(string p0)
        {
            payment.CheckTripDate(p0);
        }

        [Then(@"I check departing (.*)")]
        public void ThenICheckDepartingAirport(string p0)
        {
            payment.CheckDepartureAirport(p0);
        }

        [Then(@"I check departure time")]
        public void ThenICheckDepartureTime()
        {
            flight = (List<string>)scenarioContext["flight"];
            payment.CheckDepartureTime(flight);
        }

        [Then(@"I check arrival (.*)")]
        public void ThenICheckArrivalAirport(string p0)
        {
            payment.CheckArrivalAirport(p0);
        }

        [Then(@"I check time of arrival")]
        public void ThenICheckTimeOfArrival()
        {
            payment.CheckArrivalTime(flight);
        }

        [Then(@"I check duration of flight")]
        public void ThenICheckDurationOfFlight()
        {
            payment.CheckFlightDuration(flight);
        }

        [Then(@"I check ticket price for each passanger")]
        public void ThenICheckTicketPriceForEachPassanger()
        {
            ticketPrice = (List<double>)scenarioContext["ticketPrice"];
            payment.TripSummaryCheck(ticketPrice);
        }

        [Then(@"I check total price")]
        public void ThenICheckTotalPrice()
        {
            payment.CheckTotalPrice();
        }


    }
}
