using Expedia.com.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Configuration;
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

        [Then(@"I check the departing and arrival airports")]
        [Given(@"I check the departing and arrival airports")]
        public void GivenICheckFromAndTo()
        {
            details = new TripDetails(driver, scenarioContext);
            details.SwitchToTripDetailsTab();
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":      
                    flight = (List<string>)scenarioContext["flight"];
                    details.CompareDepartureAndDestination(flight);
                    break;
                case "True":
                    break;
            }           
        }

        [Then(@"I check flight (.*)")]
        [Given(@"I check flight (.*)")]
        public void GivenICheckDepartureDate(string p0)
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    details.CompareDates(p0);
                    break;
                case "True":
                    break;
            }  
        }

        [Then(@"I check departure time")]
        [Given(@"I check departure time")]
        public void GivenICheckDepartureTime()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    details.CompareDepartureTime(flight);
                    break;
                case "True":
                    break;
            }         
        }

        [Then(@"I check arrival time")]
        [Given(@"I check arrival time")]
        public void GivenICheckArrivalTime()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    details.CompareArrivalTime(flight);
                    break;
                case "True":
                    break;
            }        
        }

        [Then(@"I check duration of flight")]
        [Given(@"I check duration of flight")]
        public void GivenICheckFlightDuration()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    details.CompareFlightDuration(flight);
                    break;
                case "True":
                    break;
            }      
        }

        [Then(@"I check tecket price")]
        [Given(@"I check tecket price")]
        public void GivenICheckTecketPrice()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    details.CompareTicketsPricesInTripSummary(flight);
                    break;
                case "True":
                    break;
            }           
        }

        [When(@"I confirm flight")]
        public void GivenIConfirmFlight()
        {
            details.ClickContinueBookingButton();
        }

        [Then(@"Trip details page opens")]
        public void ThenTripDetailsPageOpens()
        {
            details.TripDetailsPageOpened();
        }


    }
}
