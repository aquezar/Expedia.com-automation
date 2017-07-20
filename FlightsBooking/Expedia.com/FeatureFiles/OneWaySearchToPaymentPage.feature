Feature: One Way search
	In order to book my flight for one way
	As a user
	I want to perform search and proceed to payment after selecting flight

@searchFlow
Scenario Outline: One Way Search
	Given I open expedia.com
	And I navigate to Flights
	And I navigate to OneWay
	And I enter Flying from <from>
	And I enter Flying to <to>
	And I enter Departing <date>
	And I choose number of <passangers>
	And I click Search button
	And After <searchTab> opens
	And I check correctness of search results by checking <fromAirport> and <toAirport>
	And I check departure date for search results
	And I select cheepest ticket
	And I check the <fromAirport> and <toAirport>
	And I check flight <date>
	And I check departure time
	And I check arrival time
	And I check duration of flight
	And I check tecket price
	When I confirm flight
	Then Payment page opens 
	And I open Flight details
	And I check flight <date>
	And I check departing <fromAirport>
	And I check departure time
	And I check arrival <toAirport>
	And I check time of arrival
	And I check duration of flight
	And I check ticket price for each passanger
	And I check total price
	


Examples: 
| from                               | to                                          | date       | passangers | searchTab          | fromAirport | toAirport |
| Kiev, Ukraine (KBP-Borispol Intl.) | Budapest, Hungary(BUD - Ferenc Liszt Intl.) | 09/05/2017 | 1          | KBP to BUD Flights | KBP         | BUD       |
| London, England, UK (LHR-Heathrow) | Berlin, Germany (TXL-Tegel)                 | 10/25/2017 | 3          | LHR to TXL Flights | LHR         | TXL       |

