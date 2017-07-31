using Expedia.com.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    public class SearchresultsSteps
    {

        private IWebDriver driver;
        SearchResults results;

        public SearchresultsSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
        }

        [Given(@"After (.*) opens")]
        public void GivenAfterSearchResultsOpens(string p0)
        {
            results = new SearchResults(driver);
            results.AfterSearchPageOpened(p0);            
        }

        [Given(@"I check correctness of search results by checking (.*) and (.*)")]
        public void GivenICheckCorrectnessOfSearchResults(string p0, string p1)
        {
            results.CheckSearchResults(p0, p1);
        }

        [Given(@"I check departure date for search results")]
        public void GivenICheckDepartureDateForSearchResults()
        {
            results.CompareDates();
        }

        [Given(@"I select cheepest ticket")]
        public void GivenISelectFlights()
        {
            results.ClickFlightSelectForCheepestFlight();
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





    }
}
