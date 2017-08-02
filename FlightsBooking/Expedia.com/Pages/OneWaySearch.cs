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

        private string departureDateValidationMessage = "Enter your departure date in this format: mm/dd/yyyy.";

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

        public void EnterFlyingFromValue(string from)
        {
            flyingFromField.Clear();
            flyingFromField.SendKeys(from);    
        }

        public void EnterFlyingToValue(string to)
        {
            flyingToField.Clear();
            flyingToField.SendKeys(to);
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
            //GetNumberOfPassangers();
            scenarioContext.Add("passangers", passangers);
        }

        /*private void GetNumberOfPassangers()
        {
            int passangersCount;
            int.TryParse(adultsDropdown.SelectedOption.Text, out passangersCount);
            scenarioContext.Add("passangers", passangersCount);
        }*/

        public void ClickSearchButton()
        {
            searchButton.Click();
        }

        public void ValidationMessage()
        {
            Assert.IsTrue(alertMessage.Displayed);
        }

        public void DepartureDateEmptyValidation(string testName)
        {
            Assert.AreEqual(departureDateValidator.Text, departureDateValidationMessage);

            Helper.HighlightElement(alertMessage, pageDriver);
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string dir = Path.GetDirectoryName(location) + "\\success_tests\\" + scenarioContext.ScenarioInfo.Title + "\\";
            string screenshotName = DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss-ff") + "_" + ConfigurationManager.AppSettings["Browser"] + ".png";
            Settings.TakeScreenShot(pageDriver, dir);
            Console.WriteLine("Screenshot created ->" + dir + screenshotName);
        }

    }
}
