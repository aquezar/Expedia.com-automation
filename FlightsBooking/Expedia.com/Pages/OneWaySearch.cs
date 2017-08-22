using Expedia.com.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.IO;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class OneWaySearch
    {
        private IWebDriver pageDriver;

        private readonly ScenarioContext scenarioContext;

        [FindsBy(How = How.Id, Using = "tab-flight-tab-hp")]
        private IWebElement flightsTab { get; set; }

        [FindsBy(How = How.Id, Using = "flight-type-one-way-label-hp-flight")]
        private IWebElement oneWayTab { get; set; }

        [FindsBy(How = How.Id, Using = "flight-origin-hp-flight")]
        private IWebElement flyingFromField { get; set; }

        [FindsBy(How = How.Id, Using = "flight-destination-hp-flight")]
        private IWebElement flyingToField { get; set; }

        [FindsBy(How = How.Id, Using = "flight-departing-single-hp-flight")]
        private IWebElement departingDatePicker { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='flight-adults-hp-flight']")]
        private IWebElement dropdownPassangers;
        private SelectElement adultsDropdown
        {
            get { return new SelectElement(dropdownPassangers); }
        }

        [FindsBy(How = How.Id, Using = "flight-children-hp-flight")]
        private IWebElement dropdownChildrens;
        private SelectElement childrenDropdown
        {
            get { return new SelectElement(dropdownChildrens); }
        }
    
        [FindsBy(How = How.XPath, Using = ".//*[@id='flight-departing-wrapper-single-hp-flight']/div/div/div[1]/button")]
        private IWebElement closeDatePicker { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-primary.btn-action.gcw-submit")]
        private IWebElement searchButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "error-link")]
        private IWebElement departureDateValidator { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='gcw-flights-form-hp-flight']/div[2]")]
        private IWebElement alertMessage { get; set; }

        public OneWaySearch(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        public void GoToFlightsTab()
        {
            flightsTab.Click();
        }

        public void GoToOneWayTab()
        {
            oneWayTab.Click();
        }

        public void EnterFlyingFromValue(string fromAirport)
        {
            flyingFromField.Clear();
            flyingFromField.SendKeys(fromAirport);    
        }

        public void EnterFlyingToValue(string toAirport)
        {
            flyingToField.Clear();
            flyingToField.SendKeys(toAirport);
        }

        public void EnterDepartingDateValue(string date)
        {
            departingDatePicker.Clear();
            departingDatePicker.SendKeys(date);
            closeDatePicker.Click();
        }

        public void SelectNumberOfAdults(int passangers)
        {
            adultsDropdown.SelectByIndex(passangers + 1);
            scenarioContext.Add("passangers", passangers);
        }

        public void ClickSearchButton()
        {
            searchButton.Click();
        }

        public void IsValidationMessageDisplayed()
        {
            Helper.HighlightIWebElement(alertMessage, pageDriver);
            Assert.IsTrue(alertMessage.Displayed);
            Helper.UnhighlightIWebElement(alertMessage, pageDriver);
        }

        public void CheckValidationMessage(string validationMessage)
        {
            Helper.HighlightIWebElement(departureDateValidator, pageDriver);
            Assert.AreEqual(departureDateValidator.Text, validationMessage);
            Helper.UnhighlightIWebElement(departureDateValidator, pageDriver);
        }

        public void ClearFlyingToField()
        {
            flyingToField.Clear();
        }

        public void ClearFlyingFromField()
        {
            flyingFromField.Clear();
        }

    }
}
