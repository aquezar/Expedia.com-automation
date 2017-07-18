using Expedia.com.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    public class TripDetailSteps
    {

        private IWebDriver driver;
        private List<string>flight = new List<string>();
        TripDetails details;

        public TripDetailSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            
        }

        [Given(@"I check the (.*) and (.*)")]
        public void GivenICheckFromAndTo(string p0, string p1)
        {
            details = new TripDetails(driver);
            details.SwitchToTripDetailsTab();
            flight = (List<string>)ScenarioContext.Current["flight"];
            details.CompareDepartureAndDestination(flight, p0, p1);
        }

        [Given(@"I check flight (.*)")]
        public void GivenICheckDepartureDate(string p0)
        {
            details.CompareDates(p0);
        }

        [Given(@"I check departure time")]
        public void GivenICheckDepartureTime()
        {
            details.CompareDepartureTime(flight);
        }

        [Given(@"I check arrival time")]
        public void GivenICheckArrivalTime()
        {
            details.CompareArrivalTime(flight);
        }

        [Given(@"I check duration of flight")]
        public void GivenICheckFlightDuration()
        {
            details.CompareFlightDuration(flight);
        }

        [Given(@"I check tecket price")]
        public void GivenICheckTecketPrice()
        {
            details.CompareTicketsPricesInTripSummary(flight);
        }


        [Given(@"I confirm flight")]
        public void GivenIConfirmFlight()
        {
            details.Continue();
        }

    }
}
