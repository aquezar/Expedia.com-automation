@unit
Feature: Validation messages
	In order to fix mistakes when searching flights
	As a user
	I want to see error messages when i make mistakes

@departureDate
Scenario Outline: One Way search without departure date
	Given I open expedia.com
	And I navigate to Flights
	And I navigate to OneWay
	And I enter Flying from <from>
	And I enter Flying to <to>
	And I choose number of <passangers>
	And I click Search button
	When Validation message appears
	Then Message text saying that Date is empty
Examples: 
| from                               | to                                          | passangers | searchTab          | fromAirport | toAirport |
| Kiev, Ukraine (KBP-Borispol Intl.) | Budapest, Hungary(BUD - Ferenc Liszt Intl.) | 1          | KBP to BUD Flights | KBP         | BUD       |
