using Expedia.com.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class OneWaySearch
    {
        private IWebDriver pageDriver;

        [FindsBy(How = How.Id, Using = "tab-flight-tab-hp")]
        private IWebElement FlightsTab { get; set; }

        [FindsBy(How = How.Id, Using = "flight-type-one-way-label-hp-flight")]
        private IWebElement OneWayTab { get; set; }

        [FindsBy(How = How.Id, Using = "flight-origin-hp-flight")]
        private IWebElement FlyingFrom { get; set; }

        [FindsBy(How = How.Id, Using = "flight-destination-hp-flight")]
        private IWebElement FlyingTo { get; set; }

        [FindsBy(How = How.Id, Using = "flight-departing-single-hp-flight")]
        private IWebElement DepartingDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='flight-adults-hp-flight']")]
        private IWebElement dropdownPassangers;
        private SelectElement Passangers
        {
            get { return new SelectElement(dropdownPassangers); }
        }

        [FindsBy(How = How.Id, Using = "flight-children-hp-flight")]
        private IWebElement dropdownChildrens;
        private SelectElement Childrens
        {
            get { return new SelectElement(dropdownChildrens); }
        }

        [FindsBy(How = How.XPath, Using = ".//select[contains(@id, 'flight-age-select-')]")]
        private IWebElement dropdownChildrensAge;
        private SelectElement ChildrensAge
        {
            get { return new SelectElement(dropdownChildrensAge); }
        }
    
        [FindsBy(How = How.XPath, Using = ".//*[@id='flight-departing-wrapper-single-hp-flight']/div/div/div[1]/button")]
        private IWebElement CloseDatePicker { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-primary.btn-action.gcw-submit")]
        private IWebElement SearchButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "error-link")]
        private IWebElement departureDateValidator { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='gcw-flights-form-hp-flight']/div[2]")]
        private IWebElement alertMessage { get; set; }

        public OneWaySearch(IWebDriver driver)
        {
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        public void GoToFlights()
        {
            FlightsTab.Click();
        }

        public void GoToOneWay()
        {
            OneWayTab.Click();
        }

        public void EnterFlyingFrom(string from)
        {
            FlyingFrom.Clear();
            FlyingFrom.SendKeys(from);    
        }

        public void EnterFlyingTo(string to)
        {
            FlyingTo.Clear();
            FlyingTo.SendKeys(to);
        }

        public void EnterDepartingDate(string date)
        {
            DepartingDate.Clear();
            DepartingDate.SendKeys(date);
            CloseDatePicker.Click();
        }

        public void SelectNumberOfAdults(string passangers)
        {
            Passangers.SelectByText(passangers);
            PassNumberOfPassangers();
        }

        private void PassNumberOfPassangers()
        {
            int passangersCount;
            int.TryParse(Passangers.SelectedOption.Text, out passangersCount);
            ScenarioContext.Current["passangers"] = passangersCount;
        }

        public void Search()
        {
            SearchButton.Click();
        }

        public void ValidationMessage()
        {
            Assert.IsTrue(alertMessage.Displayed);
        }

        public void DepartureDateEmptyValidation(string testName)
        {
            Assert.AreEqual(departureDateValidator.Text, "Enter your departure date in this format: mm/dd/yyyy..");
        }
    }
}
