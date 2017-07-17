using Expedia.com.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    public class SearchresultsSteps
    {

        readonly IWebDriver driver;

        public SearchresultsSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
        }

        [Given(@"I close (.*) if it opens")]
        public void GivenICloseCommercialIfItOpens(string p0)
        {
            new SearchResults(driver).CloseCommercial(p0);
        }

        [Given(@"I check that correct Search results opens, verifying by (.*)")]
        public void GivenICheckThatCorrectSearchResultsOpens(string p0)
        {
            new SearchResults(driver).CheckCorrectSearchPageOpened(p0);            
        }

        [Given(@"I check that search results is relevant to search request by (.*) and (.*)")]
        public void GivenICheckThatSearchResultsIsRelevantToSearchRequest(string p0, string p1)
        {
            new SearchResults(driver).CheckSearchResults(p0, p1);
        }


        [Given(@"I select flights")]
        public void GivenISelectFlights()
        {
            new SearchResults(driver).FlightSelect();
        }

        [Given(@"I change departure date to (.*)")]
        public void GivenIChangeDepartureDateTo(string p0)
        {
            new SearchResults(driver).changeDepartureDate(p0);
        }

        [When(@"I click Search button on Search Results page")]
        public void WhenIClickSearchButtonOnSearchResultsPage()
        {
            new SearchResults(driver).search();
        }

        [Then(@"Flights for new date are shown")]
        public void ThenFlightsForNewDateAreShown()
        {
            new SearchResults(driver).compareDates();
        }





    }
}
