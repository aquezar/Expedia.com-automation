using Expedia.com.Pages;
using OpenQA.Selenium;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    public class SearchresultsSteps
    {

        private IWebDriver driver;
        SearchResults results;
        private readonly ScenarioContext scenarioContext;
        private string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];

        public SearchresultsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];
        }

        [Given(@"After (.*) page opens")]
        public void GivenAfterSearchResultsOpens(string p0)
        {
            results = new SearchResults(driver, scenarioContext);
            results.AfterSearchPageOpened(p0);            
        }


        [Given(@"I check departure date for search results")]
        public void GivenICheckDepartureDateForSearchResults()
        {
            switch (lightweightMode)
            {
                case "False":
                    results.CompareDates();
                    break;
                case "True":
                    break;
            }
        }

        [Given(@"I check correctness of search results by checking (.*) and (.*)")]
        public void GivenICheckCorrectnessOfSearchResults(string p0, string p1)
        {
            
            switch (lightweightMode)
            {
                case "False":
                    results.CheckSearchResults(p0, p1);
                    break;
                case "True":
                    break;
            }
            
        }

       /* [Given(@"I check departure date for search results")]
        public void GivenICheckDepartureDateForSearchResults()
        {
            string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];
            switch (lightweightMode)
            {
                case "False":
                    results.CompareDates();
                    break;
                case "True":
                    break;
            }
        }*/

        [Given(@"I select '(.*)' ticket")]
        public void GivenISelectTicket(string ticketType)
        {
            switch (ticketType)
            {
                case "cheepest":
                    results.ClickFlightSelectForCheepestFlight();
                    break;
                default:
                    Console.WriteLine("Ticket type is incorrect");
                    break;
            }
            
        }

        [Given(@"I change departure date to (.*)")]
        public void GivenIChangeDepartureDateTo(string p0)
        {
            results.ChangeDepartureDate(p0);
        }

        [When(@"I click Search button on Search Results page")]
        public void WhenIClickSearchButtonOnSearchResultsPage()
        {
            results.ClickSearchButton();
        }

        [Then(@"Flights for new date are shown")]
        public void ThenFlightsForNewDateAreShown()
        {
            results.CompareDates();
        }

        [Given(@"I select Nonstop checkbox in filters")]
        public void GivenISelectNonstopCheckboxInFilters()
        {
            results.SelectNonstopFilter();
        }

        [Given(@"I check that only Nonstop flights are displayed")]
        public void GivenICheckThatOnlyNonstopFlightsAreDisplayed()
        {
            results.OnlyNonstopFlightsDisplayed();
        }

    }
}
