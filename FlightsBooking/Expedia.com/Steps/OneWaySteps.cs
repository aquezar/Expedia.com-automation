using Expedia.com.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    public class OneWaySteps
    {
        readonly IWebDriver driver;

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
            new OneWaySearch(driver).GoToFlights();
        }

        [Given(@"I navigate to OneWay")]
        public void GivenINavigateToOneWay()
        {
            new OneWaySearch(driver).GoToOneWay();
        }

        [Given(@"I enter Flying from (.*)")]
        public void GivenIEnterFlyingFrom(string p0)
        {
            new OneWaySearch(driver).EnterFlyingFrom(p0);
        }

        [Given(@"I enter Flying to (.*)")]
        public void GivenIEnterFlyingTom(string p0)
        {
            new OneWaySearch(driver).EnterFlyingTo(p0);
        }

        [Given(@"I enter Departing (.*)")]
        public void GivenIEnterDepartingDate(string p0)
        {
            new OneWaySearch(driver).EnterDepartingDate(p0);
        }

        [Given(@"I Choose Adults number (.*)")]
        public void GivenIChooseAdultsNumber(string p0)
        {
            new OneWaySearch(driver).SelectNumberOfAdults(p0);
        }

        [Given(@"I click Search button")]
        public void GivenIClickSearchButton()
        {
            new OneWaySearch(driver).Search();
        }
        
    }
}
