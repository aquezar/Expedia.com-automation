using Expedia.com.Pages;
using OpenQA.Selenium;
using System;
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
        private string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];

        public TripDetailSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];         
        }

        [Then(@"I check '(.*)'")]
        [Given(@"I check '(.*)'")]
        public void GivenICheck(string checkParameter)
        {
            details = new TripDetails(driver, scenarioContext);
            details.SwitchToTripDetailsTab();
            switch (lightweightMode)
            {
                case "False":
                    flight = (List<string>)scenarioContext["flight"];
                    switch (checkParameter)
                    {
                        case "the departing and arrival airports":
                            details.CompareDepartureAndDestination(flight);
                            break;
                        case "departure time":
                            details.CompareDepartureTime(flight);
                            break;
                        case "arrival time":
                            details.CompareArrivalTime(flight);
                            break;
                        case "duration of flight":
                            details.CompareFlightDuration(flight);
                            break;
                        case "tecket price":
                            details.CompareTicketsPricesInTripSummary(flight);
                            break;
                        default:
                            Console.WriteLine("Checking parameter for ticket is incorrect");
                            break;
                    }
                    break;
                case "True":
                    break;
            }
            
        }

        [Then(@"I check flight (.*)")]
        [Given(@"I check flight (.*)")]
        public void GivenICheckDepartureDate(string date)
        {
            switch (lightweightMode)
            {
                case "False":
                    details.CompareDates(date);
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

        [Given(@"Trip details page opens")]
        [Then(@"Trip details page opens")]
        public void ThenTripDetailsPageOpens()
        {
            if(details == null)
            {
                details = new TripDetails(driver, scenarioContext);
            }
            details.TripDetailsPageOpened();
        }


    }
}
