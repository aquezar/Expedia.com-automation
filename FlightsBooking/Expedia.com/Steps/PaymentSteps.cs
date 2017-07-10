using Expedia.com.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    class PaymentSteps
    {

        readonly IWebDriver driver;

        double ticketPrice;

        public PaymentSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            ticketPrice = (double)ScenarioContext.Current["ticketPrice"];
        }

        [Then(@"Payment page opens (.*)")]
        public void ThenPaymentPageOpens(string p0)
        {
            new Payment(driver).PaymentPageOpens(p0, ticketPrice);

            driver.Quit();
        }
    }
}
