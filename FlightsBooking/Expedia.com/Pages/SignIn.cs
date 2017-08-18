using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class SignIn
    {
        private IWebDriver pageDriver;
        private readonly ScenarioContext scenarioContext;

        [FindsBy(How = How.Id, Using = "signin-loginid")]
        private IWebElement emailField { get; set; }

        [FindsBy(How = How.Id, Using = "signin-password")]
        private IWebElement passwordField { get; set; }

        [FindsBy(How = How.Id, Using = "submitButton")]
        private IWebElement signInButton { get; set; }

        public SignIn(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        public void EnterEmail(string email)
        {
            emailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
        }

        public void ClickSignInButton()
        {
            signInButton.Click();
        }
    }
}
