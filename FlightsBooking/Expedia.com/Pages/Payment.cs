using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Expedia.com.Pages
{
    class Payment
    {
        private IWebDriver pageDriver;

        [FindsBy(How = How.XPath, Using = ".//span[contains(@id, 'totalPriceForPassenger')]")]
        private IList<IWebElement> tripSummary { get; set; }




        //span[contains(@id, 'totalPriceForPassenger')]

        public Payment (IWebDriver driver)
        {
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        public void PaymentPageOpens(string paymentTitle, double ticketPrice)
        {
            string PaymentPageTitle = pageDriver.Title;
            Assert.IsTrue(PaymentPageTitle.Equals(paymentTitle));

            
            for(int i = 0; i <= tripSummary.Count-1; i++)
            {
                double priceForPassanger;
                double.TryParse(tripSummary[i].Text.Substring(1), out priceForPassanger);
                Assert.AreEqual(ticketPrice, priceForPassanger);
            }
        }
    }
}
