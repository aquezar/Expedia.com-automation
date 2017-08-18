using Expedia.com.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Expedia.com.Steps
{
    [Binding]
    public class MyListsSteps
    {
        private IWebDriver driver;
        MyLists myLists;
        private readonly ScenarioContext scenarioContext;
        public MyListsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];
        }

        [When(@"I click Recently Viewed button")]
        public void WhenIClickRecentlyViewedButton()
        {
            myLists = new MyLists(driver, scenarioContext);
            myLists.ClickRecentlyViewedButton();
        }

        [When(@"I click on my last selected ticket")]
        public void WhenIClickOnMyLastSelectedTicket()
        {
            myLists.ClickTicketLink();
        }


    }
}
