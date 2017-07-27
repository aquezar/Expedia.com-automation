using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class OneWaySearch
    {
        private IWebDriver pageDriver;

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

        public OneWaySearch(IWebDriver driver)
        {
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

        public void SelectNumberOfAdults(string passangers)
        {
            adultsDropdown.SelectByText(passangers);
            GetNumberOfPassangers();
        }

        private void GetNumberOfPassangers()
        {
            int passangersCount;
            int.TryParse(adultsDropdown.SelectedOption.Text, out passangersCount);
            ScenarioContext.Current["passangers"] = passangersCount;
        }

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
        }
    }
}
