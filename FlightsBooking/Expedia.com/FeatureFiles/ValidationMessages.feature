@unit
@smoke
Feature: Validation messages
	In order to fix mistakes when searching flights
	As a user
	I want to see error messages when i make mistakes

@departureDate
@smoke
Scenario Outline: One Way search without departure date
	Given I open 'http://expedia.com'
	And I navigate to 'Flights' tab
	And I navigate to 'OneWay' tab
	And I enter <departureAirport> in 'Flying from' field
	And I enter <arrivalAirport> in 'Flying to' field
	And I choose number of <passangers> in Adults dropdown
	And I click Search button
	When Validation message appears
	Then message text saying that 'Date is empty'
Examples: 
| from                               | to                                          | passangers | searchTab          | fromAirport | toAirport |
| Kiev, Ukraine (KBP-Borispol Intl.) | Budapest, Hungary(BUD - Ferenc Liszt Intl.) | 1          | KBP to BUD Flights | KBP         | BUD       |
