Feature: One Way search
	In order to book my flight for one way only
	As unregistered user
	I want to perform search and proceed to payment after selecting flight

@searchFlow
Scenario Outline: One Way
	Given I open expedia.com
	And I navigate to Flights
	And I navigate to OneWay
	And I enter Flying from <from>
	And I enter Flying to <to>
	And I enter Departing <date>
	And I Choose Adults number <passangers>
	And I click Search button
	And After <searchTab> opens
	And I check correctness of search results by checking <fromAirport> and <toAirport>
	And I select cheepest ticket
	And I check the <fromAirport> and <toAirport>
	And I check flight <date>
	And I check departure time
	And I check arrival time
	And I check duration of flight
	And I check tecket price
	And I confirm flight
	When Payment page opens 
	Then Payment page Trip summary is corresponding to selected tickets

Examples: 
| from                               | to                                          | date       | passangers | searchTab          | fromAirport | toAirport |
| Kiev, Ukraine (KBP-Borispol Intl.) | Budapest, Hungary(BUD - Ferenc Liszt Intl.) | 09/05/2017 | 1          | KBP to BUD Flights | KBP         | BUD       |
| London, England, UK (LHR-Heathrow) | Berlin, Germany (TXL-Tegel)                 | 10/25/2017 | 3          | LHR to TXL Flights | LHR         | TXL       |