﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Expedia.com.FeatureFiles
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("One Way search")]
    [NUnit.Framework.CategoryAttribute("integration")]
    [NUnit.Framework.CategoryAttribute("regression")]
    public partial class OneWaySearchFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "OneWaySearchToPaymentPage.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "One Way search", "\tIn order to book my flight for one way\r\n\tAs a user\r\n\tI want to perform search an" +
                    "d proceed to payment after selecting flight", ProgrammingLanguage.CSharp, new string[] {
                        "integration",
                        "regression"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cheepest flight")]
        [NUnit.Framework.CategoryAttribute("cheepestTicket")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        [NUnit.Framework.CategoryAttribute("e2e")]
        [NUnit.Framework.TestCaseAttribute("London, England, UK (LHR-Heathrow)", "Fiumicino Airport (FCO), Italy", "11/10/2017", "3", "LHR to FCO Flights", "LHR", "FCO", null)]
        [NUnit.Framework.TestCaseAttribute("Krakow, Poland (KRK-John Paul II - Balice)", "Manchester Airport (MAN), England, United Kingdom", "11/22/2017", "1", "KRK to MAN Flights", "KRK", "MAN", null)]
        [NUnit.Framework.TestCaseAttribute("New York, NY (JFK-John F. Kennedy Intl.)", "Vancouver, BC, Canada (YVR-Vancouver Intl.)", "12/03/2017", "1", "JFK to YVR Flights", "JFK", "YVR", null)]
        public virtual void CheepestFlight(string departureAirport, string arrivalAirport, string date, string passangers, string searchResults, string fromAirport, string toAirport, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "cheepestTicket",
                    "smoke",
                    "e2e"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cheepest flight", @__tags);
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given("I open \'http://expedia.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
 testRunner.And("I navigate to \'Flights\' tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I navigate to \'OneWay\' tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And(string.Format("I enter {0} in \'Flying from\' field", departureAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("I enter {0} in \'Flying to\' field", arrivalAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And(string.Format("I enter {0} in \'Departing\' field", date), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And(string.Format("I choose number of {0} in Adults dropdown", passangers), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("I click Search button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And(string.Format("After {0} page opens", searchResults), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And(string.Format("I check correctness of search results by checking {0} and {1}", fromAirport, toAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I check departure date for search results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I select \'cheepest\' ticket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I check \'the departing and arrival airports\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And(string.Format("I check flight {0}", date), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I check \'departure time\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I check \'arrival time\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("I check \'duration of flight\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I check \'ticket price\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I confirm flight", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("Payment page opens", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
 testRunner.And("I open Flight details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And(string.Format("I check \'flight\' {0} on Payment page", date), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And(string.Format("I check \'departing\' {0} on Payment page", fromAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("I check \'departure time\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And(string.Format("I check \'arrival\' {0} on Payment page", toAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("I check \'time of arrival\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I check \'duration of flight\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I check \'ticket price for each passanger\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I check \'total price\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Nonstop cheepest flight")]
        [NUnit.Framework.CategoryAttribute("nonstopFlights")]
        [NUnit.Framework.CategoryAttribute("e2e")]
        [NUnit.Framework.TestCaseAttribute("Berlin, Germany (TXL-Tegel)", "Riga, Latvia (RIX-Riga Intl.)", "12/22/2017", "1", "TXL to RIX Flights", "TXL", "RIX", null)]
        [NUnit.Framework.TestCaseAttribute("New York, NY (JFK-John F. Kennedy Intl.)", "Vancouver, BC, Canada (YVR-Vancouver Intl.)", "12/03/2017", "1", "JFK to YVR Flights", "JFK", "YVR", null)]
        [NUnit.Framework.TestCaseAttribute("London, England, UK (LHR-Heathrow)", "Fiumicino Airport (FCO), Italy", "11/10/2017", "3", "LHR to FCO Flights", "LHR", "FCO", null)]
        public virtual void NonstopCheepestFlight(string departureAirport, string arrivalAirport, string date, string passangers, string searchResults, string fromAirport, string toAirport, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "nonstopFlights",
                    "e2e"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Nonstop cheepest flight", @__tags);
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
 testRunner.Given("I open \'http://expedia.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.And("I navigate to \'Flights\' tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I navigate to \'OneWay\' tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And(string.Format("I enter {0} in \'Flying from\' field", departureAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And(string.Format("I enter {0} in \'Flying to\' field", arrivalAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And(string.Format("I enter {0} in \'Departing\' field", date), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And(string.Format("I choose number of {0} in Adults dropdown", passangers), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I click Search button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And(string.Format("After {0} page opens", searchResults), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("I select \'Nonstop\' checkbox in filters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("I check that only \'Nonstop\' flights are displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And(string.Format("I check correctness of search results by checking {0} and {1}", fromAirport, toAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("I check departure date for search results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("I select \'cheepest\' ticket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("I check \'the departing and arrival airports\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And(string.Format("I check flight {0}", date), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("I check \'departure time\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("I check \'arrival time\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("I check \'duration of flight\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("I check \'ticket price\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.When("I confirm flight", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
 testRunner.Then("Payment page opens", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
 testRunner.And("I open Flight details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And(string.Format("I check \'flight\' {0} on Payment page", date), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And(string.Format("I check \'departing\' {0} on Payment page", fromAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I check \'departure time\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And(string.Format("I check \'arrival\' {0} on Payment page", toAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("I check \'time of arrival\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("I check \'duration of flight\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("I check \'ticket price for each passanger\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("I check \'total price\' on Payment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search without Flying to field value")]
        [NUnit.Framework.CategoryAttribute("negative")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        [NUnit.Framework.TestCaseAttribute("Berlin, Germany (TXL-Tegel)", "12/22/2017", "1", null)]
        [NUnit.Framework.TestCaseAttribute("New York, NY (JFK-John F. Kennedy Intl.)", "12/03/2017", "1", null)]
        public virtual void SearchWithoutFlyingToFieldValue(string departureAirport, string date, string passangers, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "negative",
                    "smoke"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search without Flying to field value", @__tags);
#line 92
this.ScenarioSetup(scenarioInfo);
#line 93
 testRunner.Given("I open \'http://expedia.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 94
 testRunner.And("I navigate to \'Flights\' tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("I navigate to \'OneWay\' tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And(string.Format("I enter {0} in \'Flying from\' field", departureAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("I leave \'Flying to\' field empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And(string.Format("I enter {0} in \'Departing\' field", date), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And(string.Format("I choose number of {0} in Adults dropdown", passangers), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.When("I click Search button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
 testRunner.Then("Validation message appears", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
 testRunner.And("message text saying that \'Flying to field is empty\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search without Flying from field value")]
        [NUnit.Framework.CategoryAttribute("negative")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        [NUnit.Framework.TestCaseAttribute("Berlin, Germany (TXL-Tegel)", "12/22/2017", "1", null)]
        [NUnit.Framework.TestCaseAttribute("New York, NY (JFK-John F. Kennedy Intl.)", "12/03/2017", "1", null)]
        public virtual void SearchWithoutFlyingFromFieldValue(string arrivalAirport, string date, string passangers, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "negative",
                    "smoke"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search without Flying from field value", @__tags);
#line 111
this.ScenarioSetup(scenarioInfo);
#line 112
 testRunner.Given("I open \'http://expedia.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 113
 testRunner.And("I navigate to \'Flights\' tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And("I navigate to \'OneWay\' tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("I leave \'Flying from\' field empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.And(string.Format("I enter {0} in \'Flying to\' field", arrivalAirport), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.And(string.Format("I enter {0} in \'Departing\' field", date), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And(string.Format("I choose number of {0} in Adults dropdown", passangers), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.When("I click Search button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
 testRunner.Then("Validation message appears", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
 testRunner.And("message text saying that \'Flying from field is empty\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
