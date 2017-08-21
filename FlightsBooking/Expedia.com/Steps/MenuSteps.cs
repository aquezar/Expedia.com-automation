using Expedia.com.Pages;
using OpenQA.Selenium;
using System;
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

        [When(@"I click '(.*)' button in menu")]
        [Given(@"I click '(.*)' button in menu")]
        public void GivenIClickButtonInMenu(string buttonName)
        {
            menu = new Menu(driver, scenarioContext);
            switch (buttonName)
            {
                case "Account":
                    menu.ClickAccountButton();
                    break;
                case "Sign in":
                    menu.ClickSignInButton();
                    break;
                case "My Lists":
                    menu.ClickMyListsButton();
                    break;
                default:
                    Console.WriteLine("Ther's no such button in Main Menu");
                    break;
            }
        }

    }
}
