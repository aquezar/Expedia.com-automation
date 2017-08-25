using Expedia.com.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private string nonstopFlights = "Nonstop";
        private bool nonstopPresent;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sortBar']/div/fieldset/label/select")]
        private IWebElement dropdownSort;

        public SelectElement SearchSort
        {
            get { return new SelectElement(dropdownSort); }
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'btn-secondary btn-action t-select-btn')]")]
        private IWebElement selectButton { get; set; }

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

        [FindsBy(How = How.CssSelector, Using = ".primary.stops-emphasis")]
        private IList<IWebElement> resultsListStops { get; set; }

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

        //Checking that sorting option is set to sortingBy value(Price(Lowest), Duration(Shortest), etc.)
        private void CheckSortingByDropdownValue(string sortingBy)
        {
            Helper.HighlightIWebElement(dropdownSort, pageDriver);
            Assert.IsTrue(SearchSort.SelectedOption.Text == sortingBy);
            Helper.UnhighlightIWebElement(dropdownSort, pageDriver);
        }

        //Collecting info about cheepest ticket and pushing it to list, which added to context for further checks on Trip details and Payment pages
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
            CheckSortingByDropdownValue(sortOptionPriceLowest);
            CollectCheepestFlightInfo();
            selectButton.Click();
        }

        public void CheckSearchResultsDepartureAndArrival(string fromAirportCode, string toAirportCode)
        {
            for(int i = 0; i <= flightsListRoute.Count-1; i++)
            {
                Helper.HighlightIWebElement(flightsListRoute.ElementAt(i), pageDriver);
                Assert.AreEqual(flightsListRoute.ElementAt(i).Text, (fromAirportCode + " - " + toAirportCode));
                Helper.UnhighlightIWebElement(flightsListRoute.ElementAt(i), pageDriver);
            }
        }

        public void ChangeDepartureDate(string date)
        {
            departureDatePicker.Clear();
            departureDatePicker.SendKeys(date);
        }
       
        public void CheckDepartureDate()
        {
            Helper.HighlightIWebElement(flightDate, pageDriver);
            Assert.AreEqual(Helper.ConvertStringToDateFormat(departureDatePicker.GetAttribute("value"), '/', "ddd, MMM d"), flightDate.Text);
            Helper.UnhighlightIWebElement(flightDate, pageDriver);
        }

        public void ClickSearchButton()
        {
            searchButton.Click();
        }

        //Selecting Nonstop option in Stops filter if present
        public void SelectNonstopFilter()
        {
            if (filterStops[0].Text.Contains(nonstopFlights))
            {
                nonstopPresent = true;
            }
            else
            {
                nonstopPresent = false;
            }

            switch (nonstopPresent)
            {
                case true:
                    filterStops[0].Click();
                    break;
                case false:
                    Console.WriteLine("There's no Nonstop flights for selected route\\date.");
                    break;
            }
            Helper.CloseCommercialWindow(pageDriver);               
        }
        
        //Checking that displayed tickets are for flights without stops
        public void OnlyNonstopFlightsDisplayed()
        {
            switch (nonstopPresent)
            {
                case true:
                    for(int i = 0; i < resultsListStops.Count; i++)
                    {
                        Helper.HighlightIWebElement(resultsListStops.ElementAt(i), pageDriver);
                        Assert.AreEqual(nonstopFlights, resultsListStops.ElementAt(i).Text);
                        Helper.UnhighlightIWebElement(resultsListStops.ElementAt(i), pageDriver);
                    }
                    break;
                case false:
                    Console.WriteLine("There's no Nonstop flights for selected route\\date.");
                    break;
            }

        }
    }
}