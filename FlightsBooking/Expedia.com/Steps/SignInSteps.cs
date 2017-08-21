using Expedia.com.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Expedia.com.Steps
{
    [Binding]
    public class SignInSteps
    {
        private IWebDriver driver;
        SignIn signIn;
        private readonly ScenarioContext scenarioContext;

        public SignInSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];
        }

        [Given(@"I enter '(.*)' in '(.*)' input field")]
        public void GivenIEnterInInputField(string value, string fieldName)
        {
            signIn = new SignIn(driver, scenarioContext);
            switch (fieldName)
            {
                case "Email":
                    signIn.EnterEmail(value);
                    break;
                case "Password":
                    signIn.EnterPassword(value);
                    break;
                default:
                    Console.WriteLine("Ther's now such field on Sign In page");
                    break;
            }
        }

        [Given(@"I click Sign in button")]
        public void GivenIClickSignIn()
        {
            signIn.ClickSignInButton();
        }
    }
}
