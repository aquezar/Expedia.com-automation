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
        private readonly ScenarioContext scenarioContext;

        public TripDetailSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];         
        }

        [Given(@"I check the departing and arrival airports")]
        public void GivenICheckFromAndTo()
        {
            details = new TripDetails(driver, scenarioContext);
            details.SwitchToTripDetailsTab();
            flight = (List<string>)scenarioContext["flight"];
            details.CompareDepartureAndDestination(flight);
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

        [When(@"I confirm flight")]
        public void GivenIConfirmFlight()
        {
            details.ClickContinueBookingButton();
        }

    }
}
