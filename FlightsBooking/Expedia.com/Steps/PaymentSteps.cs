using Expedia.com.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Expedia.com
{
    [Binding, Scope(Feature = "One Way search")]
    class PaymentSteps
    {
        private IWebDriver driver;
        private List<double> ticketPrice;
        private List<string> flight = new List<string>();
        Payment payment;
        private readonly ScenarioContext scenarioContext;
        private string lightweightMode = ConfigurationManager.AppSettings["LightweightMode"];

        public PaymentSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];          
        }

        [Then(@"Payment page opens")]
        public void ThenPaymentPageOpens()
        {
            payment = new Payment(driver, scenarioContext);
            payment.IsPaymentPageOpened();       
        }

        [Then(@"I open Flight details")]
        public void ThenIOpenFlightDetails()
        {  
            switch (lightweightMode)
            {
                case "False":
                    payment.ClickFlightDetails();
                    break;
                case "True":
                    break;
            }   
        }

        [Then(@"I check '(.*)' (.*) on Payment page")]
        public void ThenICheck(string checkingParameter, string value)
        {
            switch (lightweightMode)
            {
                case "False":
                    switch (checkingParameter)
                    {
                        case "flight":
                            payment.CheckTripDate(value);
                            break;
                        case "departing":
                            payment.CheckDepartureAirport(value);
                            break;
                        case "arrival":
                            payment.CheckArrivalAirport(value);
                            break;
                        default:
                            Console.WriteLine("Checking parameter " + checkingParameter.ToUpper() + " for ticket is incorrect");
                            break;
                    }
                    break;
                case "True":
                    break;
            }
        }

        [Then(@"I check '(.*)' on Payment page")]
        public void ThenICheckOnPaymentPage(string chekingParameter)
        {
            switch (lightweightMode)
            {
                case "False":
                    flight = (List<string>)scenarioContext["flight"];
                    switch (chekingParameter)
                    {
                        case "departure time":
                            payment.CheckDepartureTime(flight);
                            break;
                        case "time of arrival":
                            payment.CheckArrivalTime(flight);
                            break;
                        case "duration of flight":
                            payment.CheckFlightDuration(flight);
                            break;
                        case "ticket price for each passanger":
                            ticketPrice = (List<double>)scenarioContext["ticketPrice"];
                            payment.CheckTripSummary(ticketPrice);
                            break;
                        case "total price":
                            payment.CheckTotalPrice();
                            break;
                        default:
                            Console.WriteLine("Checking parameter " + chekingParameter.ToUpper() + " for ticket is incorrect");
                            break;
                    }
                    break;
                case "True":
                    break;
            }
        }

    }
}
