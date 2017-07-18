using Expedia.com.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding]
    class PaymentSteps
    {

        private IWebDriver driver;

        List<double> ticketPrice;
        Payment payment;

        public PaymentSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            
        }

        [When(@"Payment page opens")]
        public void WhenPaymentPageOpens()
        {
            payment = new Payment(driver);
            payment.PaymentPageOpens();       
        }

        [Then(@"Payment page Trip summary is corresponding to selected tickets")]
        public void ThenPaymentPageTripSummaryIsCorrespondingToSelectedTickets()
        {
            ticketPrice = (List<double>)ScenarioContext.Current["ticketPrice"];
            payment.TripSummaryCheck(ticketPrice);
        }

    }
}
