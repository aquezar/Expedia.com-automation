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
        private readonly ScenarioContext scenarioContext;
        public OneWaySteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];
        }

        [Given(@"I open expedia\.com")]
        public void GivenIOpenExpedia_Com()
        {
            driver.Navigate().GoToUrl("http://expedia.com");
        }
        
        [Given(@"I navigate to Flights")]
        public void GivenINavigateToFlights()
        {
            search = new OneWaySearch(driver, scenarioContext);
            search.GoToFlightsTab();
        }

        [Given(@"I navigate to OneWay")]
        public void GivenINavigateToOneWay()
        {
            search.GoToOneWayTab();
        }

        [Given(@"I enter Flying from (.*)")]
        public void GivenIEnterFlying(string p0)
        {
            search.EnterFlyingFromValue(p0);
        }

        [Given(@"I enter Flying to (.*)")]
        public void GivenIEnterFlyingTom(string p0)
        {
            search.EnterFlyingToValue(p0);
        }

        [Given(@"I enter Departing (.*)")]
        public void GivenIEnterDepartingDate(string p0)
        {
            search.EnterDepartingDateValue(p0);
        }

        [Given(@"I choose number of (.*)")]
        public void GivenIChooseAdultsNumber(int p0)
        {
            search.SelectNumberOfAdults(p0);
        }

        [When(@"I click Search button")]
        [Given(@"I click Search button")]
        public void GivenIClickSearchButton()
        {
            search.ClickSearchButton();
        }

        [Then(@"Validation message appears")]
        [When(@"Validation message appears")]
        public void ThenValidationMessageAppears()
        {
            search.ValidationMessage();
        }

        [Then(@"Message text saying that Date is empty")]
        public void ThenMessageTextSayingThatDateIsEmpty()
        {
            search.CheckValidationMessage("Enter your departure date in this format: mm/dd/yyyy.");
        }

        [Given(@"I leave Flying to field empty")]
        public void GivenILeaveFlyingToFieldEmpty()
        {
            search.ClearFlyingToField();
        }

        [Then(@"message text saying that Flying to field is empty")]
        public void ThenMessageTextSayingThatFlyingToFieldIsEmpty()
        {
            search.CheckValidationMessage("Tell us where you're flying to.");
        }

        [Given(@"I leave Flying from field empty")]
        public void GivenILeaveFlyingFromFieldEmpty()
        {
            search.ClearFlyingFromField();
        }

        [Then(@"message text saying that Flying from field is empty")]
        public void ThenMessageTextSayingThatFlyingFromFieldIsEmpty()
        {
            search.CheckValidationMessage("Tell us where you're flying from.");
        }



    }
}
