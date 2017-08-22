using Expedia.com.Pages;
using OpenQA.Selenium;
using System;
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

        [Given(@"I open '(.*)'")]
        public void GivenIOpen(string homePageUrl)
        {
            driver.Navigate().GoToUrl(homePageUrl);
        }

        [Given(@"I navigate to '(.*)' tab")]
        public void GivenINavigateToTab(string tabName)
        {
            search = new OneWaySearch(driver, scenarioContext);
            switch (tabName)
            {
                case "Flights":
                    search.GoToFlightsTab();
                    break;
                case "OneWay":
                    search.GoToOneWayTab();
                    break;
                default:
                    Console.WriteLine("Tab name " + tabName.ToUpper() + " is incorrect");
                    break;
            }
        }

        [Given(@"I enter (.*) in '(.*)' field")]
        public void GivenIEnterValueInField(string fieldValue, string fieldName)
        {
            switch (fieldName)
            {
                case "Flying from":
                    search.EnterFlyingFromValue(fieldValue);
                    break;
                case "Flying to":
                    search.EnterFlyingToValue(fieldValue);
                    break;
                case "Departing":
                    search.EnterDepartingDateValue(fieldValue);
                    break;
                default:
                    Console.WriteLine("Field name " + fieldName.ToUpper() + " is incorrect");
                    break;
            }
        }

        [Given(@"I choose number of (.*) in Adults dropdown")]
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
            search.IsValidationMessageDisplayed();
        }

        [Given(@"I leave '(.*)' field empty")]
        public void GivenILeaveFieldEmpty(string fieldName)
        {
            switch (fieldName)
            {
                case "Flying to":
                    search.ClearFlyingToField();
                    break;
                case "Flying from":
                    search.ClearFlyingFromField();
                    break;
                default:
                    Console.WriteLine("Field name " + fieldName.ToUpper() + " is incorrect");
                    break;
            }
        }

        [Then(@"message text saying that '(.*)'")]
        public void ThenMessageTextSayingThat(string validationMessageTrigger)
        {
            switch (validationMessageTrigger)
            {
                case "Flying from field is empty":
                    search.CheckValidationMessage("Tell us where you're flying from.");
                    break;
                case "Flying to field is empty":
                    search.CheckValidationMessage("Tell us where you're flying to.");
                    break;
                case "Date is empty":
                    search.CheckValidationMessage("Enter your departure date in this format: mm/dd/yyyy.");
                    break;
                default:
                    Console.WriteLine("Validation message trigger " + validationMessageTrigger.ToUpper() + " is incorrect");
                    break;
            }
        }



    }
}
