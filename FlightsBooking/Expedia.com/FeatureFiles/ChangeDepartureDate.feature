@Change departure date
@smoke
Feature: Change departure date in Search results
	In order to change departure date
	As a user
	I want to have the ability to cnhange departure date after performing search

@changeDate
Scenario Outline: Change Departure date
	Given I open 'http://expedia.com'
	And I navigate to 'Flights' tab
	And I navigate to 'OneWay' tab
	And I enter <departureAirport> in 'Flying from' field
	And I enter <arrivalAirport> in 'Flying to' field
	And I enter <date> in 'Departing' field 
	And I choose number of <passangers> in Adults dropdown
	And I click Search button
	And After <searchResults> page opens
	And I check correctness of search results by checking <fromAirport> and <toAirport>
	And I change departure date to <newDepartureDate>
	When I click Search button on Search Results page
	Then Flights for new date are shown
 

Examples: 
| departureAirport                   | arrivalAirport                              | date       | passangers | searchResults      | fromAirport | toAirport | newDepartureDate |
| Kiev, Ukraine (KBP-Borispol Intl.) | Budapest, Hungary(BUD - Ferenc Liszt Intl.) | 09/05/2017 | 1          | KBP to BUD Flights | KBP         | BUD       | 11/15/2017       |
| London, England, UK (LHR-Heathrow) | Berlin, Germany (TXL-Tegel)                 | 10/25/2017 | 3          | LHR to TXL Flights | LHR         | TXL       | 12/03/2017       |