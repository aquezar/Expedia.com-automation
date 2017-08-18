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
    public class MenuSteps
    {
        private IWebDriver driver;
        Menu menu;
        private readonly ScenarioContext scenarioContext;

        public MenuSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];
        }

        [Given(@"I click Account button in menu")]
        public void GivenIClickAccountButtonInMenu()
        {
            menu = new Menu(driver, scenarioContext);
            menu.ClickAccountButton();
        }

        [Given(@"I click Sign in button in menu")]
        public void GivenIClickSignInButtonInMenu()
        {
            menu.ClickSignIn();
        }

        [When(@"I click My Lists button in menu")]
        public void WhenIClickMyListsButtonInMenu()
        {
            menu.ClickMyListsButton();
        }




    }
}
