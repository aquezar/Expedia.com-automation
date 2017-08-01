using Expedia.com.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class SearchResults
    {
        private IWebDriver pageDriver;

        public List<string> selectedFlight = new List<string>();
        private readonly ScenarioContext scenarioContext;

        private string pageTitleSufix = " | Expedia";
        private string sortOptionPriceLowest = "Price (Lowest)";

        [FindsBy(How = How.XPath, Using = ".//*[@id='sortBar']/div/fieldset/label/select")]
        private IWebElement dropdownSort;

        public SelectElement SearchSort
        {
            get { return new SelectElement(dropdownSort); }
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'btn-secondary btn-action t-select-btn')]")]
        private IWebElement SelectButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[contains(@id, 'flight-module-')]//div[@data-test-id='airports']")]
        private IList<IWebElement> flightsListRoute { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[contains(@id, 'flight-module-')]//div[@data-test-id='airports']")]
        private IWebElement selectedFlightRoute { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[contains(@id, 'flight-module-')]//div[contains(@class, 'offer-price')]/span[@class='visuallyhidden']")]
        private IWebElement selectedFlightPrice { get; set; }

        [FindsBy(How = How.ClassName, Using = "departure-time")]
        private IWebElement flightDepartureTime { get; set; }

        [FindsBy(How = How.ClassName, Using = "arrival-time")]
        private IWebElement flightArrivalTime { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[contains(@class, 'primary duration')]")]
        private IWebElement flightDuration { get; set; }
        
        [FindsBy(How = How.XPath, Using = ".//div[contains(@class, 'primary stops')]")]
        private IWebElement flightStops { get; set; }

        [FindsBy(How = How.Id, Using = "departure-date-1")]
        private IWebElement departureDatePicker { get; set; }

        [FindsBy(How = How.ClassName, Using = "title-date-rtv")]
        private IWebElement flightDate { get; set; }

        [FindsBy(How = How.Id, Using = "flight-wizard-search-button")]
        private IWebElement searchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "fieldset#stops label")]
        private IList<IWebElement> filterStops { get; set; }

        [FindsBy(How = How.CssSelector, Using = "fieldset#airlines label")]
        private IList<IWebElement> filterAirlines { get; set; }

        [FindsBy(How = How.CssSelector, Using = "fieldset#departure-times label")]
        private IList<IWebElement> filterDepartureTime { get; set; }

        public SearchResults(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);           
        }
       
       public void AfterSearchPageOpened(string searchTabTitle) 
        {
            Assert.AreEqual(searchTabTitle + pageTitleSufix, pageDriver.Title);
        }

        private void CheckSortingBy(string sortingBy)
        {
            Assert.IsTrue(SearchSort.SelectedOption.Text == sortingBy);
        }
        private void CollectCheepestFlightInfo()
        {
            selectedFlight.Add(selectedFlightRoute.Text);
            selectedFlight.Add(selectedFlightPrice.Text);
            selectedFlight.Add(flightDepartureTime.Text);
            selectedFlight.Add(flightArrivalTime.Text);
            selectedFlight.Add((flightDuration.Text + ", " + flightStops.Text));
            scenarioContext.Add("flight", selectedFlight);
        }

        public void ClickFlightSelectForCheepestFlight()
        {
            CheckSortingBy(sortOptionPriceLowest);
            CollectCheepestFlightInfo();
            SelectButton.Click();
        }

        public void CheckSearchResults(string from, string to)
        {
            for(int i = 0; i <= flightsListRoute.Count-1; i++)
            {
                Assert.AreEqual(flightsListRoute.ElementAt(i).Text, (from + " - " + to));
            }
        }

        public void ChangeDepartureDate(string date)
        {
            departureDatePicker.Clear();
            departureDatePicker.SendKeys(date);
        }
       
        public void CompareDates()
        {
            Assert.AreEqual(Helper.ConvertDate(departureDatePicker.GetAttribute("value"), '/', "ddd, MMM d"), flightDate.Text);
        }

        public void ClickSearchButton()
        {
            searchButton.Click();
        }
    }
}