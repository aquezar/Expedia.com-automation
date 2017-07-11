using Expedia.com.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    public class TripDetailSteps
    {

        readonly IWebDriver driver;
        private List<string>flight = new List<string>();

        public TripDetailSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            
        }

        [Given(@"I check that (.*) opens")]
        public void GivenICheckThatTripDetailPageOpens(string p0)
        {
            new TripDetails(driver).TripDetailPageOpens(p0);         
        }

        [Given(@"I compare the (.*) and (.*) values for selected and displayed flight")]
        public void GivenICompareTheKBPAndBUDValuesForSelectedAndDisplayedFlight(string p0, string p1)
        {
            flight = (List<string>)ScenarioContext.Current["flight"];
            new TripDetails(driver).CompareFlightsInfo(flight, p0, p1);
        }


        [Given(@"I confirm flight")]
        public void GivenIConfirmFlight()
        {
            new TripDetails(driver).Continue();
        }

    }
}
