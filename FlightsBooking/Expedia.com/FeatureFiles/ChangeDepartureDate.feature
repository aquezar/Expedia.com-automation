Feature: Change departure date in Search results
	In order to change departure date
	As unregistered user
	I want to have the ability to cnhange departure date after performing search

@changeDate
Scenario Outline: Change Departure date
	Given I open expedia.com
	And I navigate to Flights
	And I navigate to OneWay
	And I enter Flying from <from>
	And I enter Flying to <to>
	And I enter Departing <date>
	And I Choose Adults number <passangers>
	And I click Search button
	And I close <commercialTab> if it opens
	And I check that correct Search results opens, verifying by <searchTab>
	And I check that search results is relevant to search request by <fromAirport> and <toAirport>
	And I change departure date to <newDepartureDate>
	When I click Search button on Search Results page
	Then Flights for new date are shown
 

Examples: 
| from                               | to                                          | date       | passangers | searchTab          | commercialTab                  | fromAirport | toAirport | newDepartureDate |
| Kiev, Ukraine (KBP-Borispol Intl.) | Budapest, Hungary(BUD - Ferenc Liszt Intl.) | 09/05/2017 | 1          | KBP to BUD Flights | Search for Flights to Budapest | KBP         | BUD       | 11/15/2017       |
| London, England, UK (LHR-Heathrow) | Berlin, Germany (TXL-Tegel)                 | 10/18/2017 | 3          | LHR to TXL Flights | Search for Flights to Berlin   | LHR         | TXL       | 12/03/2017       |