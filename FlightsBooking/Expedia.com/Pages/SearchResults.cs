﻿using NUnit.Framework;
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

        public List<string> selectedFlight = new List<string>(); //list for selected flight

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

        [FindsBy(How = How.XPath, Using = ".//li[contains(@id, 'flight-module-')]//div[@class='secondary truncate']")]
        private IWebElement selectedFlightAirlines { get; set; }

        public SearchResults(IWebDriver driver)
        {
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

       public void CloseCommercial(string commercialWinTitle)
        {
            //Close commercial if opened
            string commercialTabHandle = pageDriver.WindowHandles.Last();
            var commercialWindow = pageDriver.SwitchTo().Window(commercialTabHandle);

            if (commercialWindow.Title == commercialWinTitle)
            {
                pageDriver.Close();
                var originalTab = pageDriver.SwitchTo().Window(pageDriver.WindowHandles.First());
            }
        }
       public void CheckPageOpened(string searchTabTitle) 
        {
             //Check that correct page is opened
             Assert.AreEqual(searchTabTitle + " | Expedia", pageDriver.Title);
        }

        public void GetStopsFilter()
        {
            int StopsFilterCount = pageDriver.FindElement(By.Id("stops")).FindElements(By.ClassName("check filter-option")).Count;
            List<IWebElement> StopsFilter = pageDriver.FindElement(By.Id("stops")).FindElements(By.ClassName("check filter-option")).ToList();
            string[] StopFilterValues = new string[StopsFilterCount];
            for (int i = 0; i <= StopsFilterCount-1; i++)
            {
                StopFilterValues[i] = StopsFilter.ElementAt(i).Text;
            }
        }

        public void FlightSelect()
        {
            selectedFlight.Add(selectedFlightRoute.Text);
            selectedFlight.Add(selectedFlightPrice.Text);
            selectedFlight.Add(selectedFlightAirlines.Text);
            ScenarioContext.Current["flight"] = selectedFlight;
            SelectButton.Click();

            //Switch to Trip Detail
            string newTabHandle = pageDriver.WindowHandles.Last();
            pageDriver.SwitchTo().Window(newTabHandle);
        }

        public void CheckSearchResults(string from, string to)
        {
            for(int i = 0; i <= flightsListRoute.Count-1; i++)
            {
                Assert.AreEqual(flightsListRoute.ElementAt(i).Text, (from + " - " + to));
            }
        }
        
    }
}