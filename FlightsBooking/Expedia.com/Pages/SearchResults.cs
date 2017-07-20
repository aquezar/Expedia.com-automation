using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class SearchResults
    {
        private IWebDriver pageDriver;

        public List<string> selectedFlight = new List<string>(); //list for selected flight

        private string departureDate;

        [FindsBy(How = How.Id, Using = "departure-airport-1")]
        private IWebElement SearchFlyingFrom { get; set; }

        [FindsBy(How = How.Id, Using = "arrival-airport-1")]
        private IWebElement SearchFlyingTo { get; set; }

        [FindsBy(How = How.Id, Using = "departure-date-1")]
        private IWebElement SearchDepartureDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='sortBar']/div/fieldset/label/select")]
        private IWebElement dropdownSort;
        public SelectElement SearchSort
        {
            get { return new SelectElement(dropdownSort); }
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'btn-secondary btn-action t-select-btn')]")]
        private IWebElement SelectButton { get; set; }

        //From-To airports codes
        [FindsBy(How = How.XPath, Using = ".//li[contains(@id, 'flight-module-')]//div[@data-test-id='airports']")]
        private IList<IWebElement> flightsListRoute { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[contains(@id, 'flight-module-')]//div[@data-test-id='airports']")]
        private IWebElement selectedFlightRoute { get; set; }

        //Price of flight
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
        private IWebElement departure { get; set; }

        [FindsBy(How = How.ClassName, Using = "title-date-rtv")]
        private IWebElement flightDate { get; set; }

        [FindsBy(How = How.Id, Using = "flight-wizard-search-button")]
        private IWebElement searchButton { get; set; }

        public SearchResults(IWebDriver driver)
        {
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

       
       public void AfterSearchPageOpened(string searchTabTitle) 
        {
            Assert.AreEqual(searchTabTitle + " | Expedia", pageDriver.Title);
        }

        private void CollectCheepestFlightInfo()
        {
            selectedFlight.Add(selectedFlightRoute.Text);
            selectedFlight.Add(selectedFlightPrice.Text);
            selectedFlight.Add(flightDepartureTime.Text);
            selectedFlight.Add(flightArrivalTime.Text);
            selectedFlight.Add((flightDuration.Text + ", " + flightStops.Text));
            ScenarioContext.Current["flight"] = selectedFlight;
        }

        public void FlightSelect()
        {
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

        public void changeDepartureDate(string date)
        {
            departure.Clear();
            departure.SendKeys(date);
        }

        private void convertDepartureDate()
        {
            var t = departure.GetAttribute("value").Split('/');
            int day;
            int month;
            int year;
            int.TryParse(t[2], out year);
            int.TryParse(t[0], out month);
            int.TryParse(t[1], out day);
            DateTime convertedDate = new DateTime(year, month, day);
            departureDate = convertedDate.ToString("ddd, MMM d");
        }
        
        public void compareDates()
        {
            convertDepartureDate();
            Assert.AreEqual(departureDate, flightDate.Text);
        }

        public void search()
        {
            searchButton.Click();
        }
    }
}