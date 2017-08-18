using Expedia.com.Pages;
using OpenQA.Selenium;
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

        [Given(@"I enter my Email (.*)")]
        public void GivenIEnterMyEmail(string p0)
        {
            signIn = new SignIn(driver, scenarioContext);
            signIn.EnterEmail(p0);
        }

        [Given(@"I enter my Password (.*)")]
        public void GivenIEnterMyPassword(string p0)
        {
            signIn.EnterPassword(p0);
        }

        [Given(@"I click Sign in")]
        public void GivenIClickSignIn()
        {
            signIn.ClickSignInButton();
        }
    }
}
