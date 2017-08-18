using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Expedia.com.Pages
{
    public class Menu
    {
        private IWebDriver pageDriver;
        private readonly ScenarioContext scenarioContext;

        [FindsBy(How = How.Id, Using = "header-account-menu")]
        private IWebElement accountButton { get; set; }

        [FindsBy(How = How.Id, Using = "account-signin")]
        private IWebElement signInButton { get; set; }

        [FindsBy(How = How.Id, Using = "gss-signin-email")]
        private IWebElement signInEmailField { get; set; }

        [FindsBy(How = How.Id, Using = "gss-signin-password")]
        private IWebElement signInPasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "gss-signin-submit")]
        private IWebElement signInSignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "header-history")]
        private IWebElement myListsButton { get; set; }

        public Menu(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        public void ClickAccountButton()
        {
            accountButton.Click();
        }

        public void ClickSignIn()
        {
            signInButton.Click();
        }

        public void EnterEmail(string email)
        {
            signInEmailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            signInPasswordField.SendKeys(password);
        }

        public void ClickSignInButton()
        {
            signInSignInButton.Click();
        }

        public void ClickMyListsButton()
        {
            myListsButton.Click();
        }
    }
}
