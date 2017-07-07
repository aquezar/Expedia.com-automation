using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Expedia.com.Pages
{
    class Payment
    {
        private IWebDriver pageDriver;

        public Payment (IWebDriver driver)
        {
            pageDriver = driver;
            PageFactory.InitElements(pageDriver, this);
        }

        public void PaymentPageOpens(string paymentTitle)
        {
            string PaymentPageTitle = pageDriver.Title;
            Assert.IsTrue(PaymentPageTitle.Equals(paymentTitle));
        }
    }
}
