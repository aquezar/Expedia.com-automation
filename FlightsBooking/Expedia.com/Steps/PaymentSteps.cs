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
            payment.PaymentPageOpens();       
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
                            Console.WriteLine("Checking parameter for ticket is incorrect");
                            break;
                    }
                    break;
                case "True":
                    break;
            }
        }
        /*[Then(@"I check flight (.*)")]
        public void ThenICheckFlightDate(string p0)
        {
            switch (lightweightMode)
            {
                case "False":
                    payment.CheckTripDate(p0);
                    break;
                case "True":
                    break;
            }          
        }

        [Then(@"I check departing (.*)")]
        public void ThenICheckDepartingAirport(string p0)
        {
            switch (lightweightMode)
            {
                case "False":
                    payment.CheckDepartureAirport(p0);
                    break;
                case "True":
                    break;
            }           
        }*/

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
                            payment.TripSummaryCheck(ticketPrice);
                            break;
                        case "total price":
                            payment.CheckTotalPrice();
                            break;
                        default:
                            Console.WriteLine("Checking parameter for ticket is incorrect");
                            break;
                    }
                    break;
                case "True":
                    break;
            }
        }




        /*[Then(@"I check departure time")]
        public void ThenICheckDepartureTime()
        {
            switch (lightweightMode)
            {
                case "False":
                    flight = (List<string>)scenarioContext["flight"];
                    payment.CheckDepartureTime(flight);
                    break;
                case "True":
                    break;
            }     
        }*/

        /* [Then(@"I check arrival (.*)")]
         public void ThenICheckArrivalAirport(string p0)
         {
             switch (lightweightMode)
             {
                 case "False":
                     payment.CheckArrivalAirport(p0);
                     break;
                 case "True":
                     break;
             }           
         }

         [Then(@"I check time of arrival")]
         public void ThenICheckTimeOfArrival()
         {
             switch (lightweightMode)
             {
                 case "False":
                     payment.CheckArrivalTime(flight);
                     break;
                 case "True":
                     break;
             }         
         }

        [Then(@"I check duration of flight")]
        public void ThenICheckDurationOfFlight()
        {
            switch (lightweightMode)
            {
                case "False":
                    payment.CheckFlightDuration(flight);
                    break;
                case "True":
                    break;
            }
        }

        [Then(@"I check ticket price for each passanger")]
        public void ThenICheckTicketPriceForEachPassanger()
        {
            switch (lightweightMode)
            {
                case "False":
                    ticketPrice = (List<double>)scenarioContext["ticketPrice"];
                    payment.TripSummaryCheck(ticketPrice);
                    break;
                case "True":
                    break;
            }          
        }

        [Then(@"I check total price")]
        public void ThenICheckTotalPrice()
        {
            payment.CheckTotalPrice();
        }*/


    }
}
