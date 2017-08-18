using Expedia.com.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class MyLists
    {
        private IWebDriver pageDriver;
        private readonly ScenarioContext scenarioContext;

        [FindsBy(How = How.Id, Using = "history-list-button")]
        private IWebElement recentlyViewedButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".summary-title.no-change-message")]
        private IWebElement lastTicketSelectedDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "h3.group-title.truncate")]
        private IWebElement flightRoute { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".group-superlative-1")]
        private IWebElement flightDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".history-item-list")]
        private IWebElement ticketLink { get; set; }

        public MyLists(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        public void ClickRecentlyViewedButton()
        {
            recentlyViewedButton.Click();
        }

        public void ClickTicketLink()
        {
            ticketLink.Click();
        }
    }
}
