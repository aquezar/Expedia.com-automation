using Expedia.com.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    public class OneWaySteps
    {
        private IWebDriver driver;
        OneWaySearch search;
        public OneWaySteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
        }

        [Given(@"I open expedia\.com")]
        public void GivenIOpenExpedia_Com()
        {
            driver.Navigate().GoToUrl("http://expedia.com");
        }
        
        [Given(@"I navigate to Flights")]
        public void GivenINavigateToFlights()
        {
            search = new OneWaySearch(driver);
            search.GoToFlights();
        }

        [Given(@"I navigate to OneWay")]
        public void GivenINavigateToOneWay()
        {
            search.GoToOneWay();
        }

        [Given(@"I enter Flying from (.*)")]
        public void GivenIEnterFlyingFrom(string p0)
        {
            search.EnterFlyingFrom(p0);
        }

        [Given(@"I enter Flying to (.*)")]
        public void GivenIEnterFlyingTom(string p0)
        {
            search.EnterFlyingTo(p0);
        }

        [Given(@"I enter Departing (.*)")]
        public void GivenIEnterDepartingDate(string p0)
        {
            search.EnterDepartingDate(p0);
        }

        [Given(@"I choose number of (.*)")]
        public void GivenIChooseAdultsNumber(string p0)
        {
            search.SelectNumberOfAdults(p0);
        }

        [Given(@"I click Search button")]
        public void GivenIClickSearchButton()
        {
            search.Search();
        }

        [When(@"Validation message appears")]
        public void ThenValidationMessageAppears()
        {
            search.ValidationMessage();
        }

        [Then(@"Message text saying that Date is empty")]
        public void ThenMessageTextSayingThatDateIsEmpty()
        {
            search.DepartureDateEmptyValidation("Departure_empty");
        }


    }
}
