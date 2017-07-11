using Expedia.com.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    class PaymentSteps
    {

        readonly IWebDriver driver;

        List<double> ticketPrice;

        public PaymentSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            
        }

        [When(@"(.*) opens")]
        public void WhenPaymentPageOpens(string p0)
        {
            new Payment(driver).PaymentPageOpens(p0);       
        }

        [Then(@"Payment page Trip summary is corresponding to selected tickets")]
        public void ThenPaymentPageTripSummaryIsCorrespondingToSelectedTickets()
        {
            ticketPrice = (List<double>)ScenarioContext.Current["ticketPrice"];
            new Payment(driver).TripSummaryCheck(ticketPrice);

            driver.Quit();
        }

    }
}
