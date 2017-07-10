Feature: One Way search
	In order to book my flight for one way only
	As unregistered user
	I want to perform search, select flight and proceed to payment

@searchflow
Scenario Outline: One Way
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
	And I select flights
	And I check that <tripDetailPage> opens 
	And I compare the <fromAirport> and <toAirport> values for selected and displayed flight
	When I confirm flight
	Then Payment page opens <paymentPage>

Examples: 
| from                               | to                                          | date       | passangers | searchTab          | commercialTab                  | tripDetailPage | paymentPage | fromAirport | toAirport |
| Kiev, Ukraine (KBP-Borispol Intl.) | Budapest, Hungary(BUD - Ferenc Liszt Intl.) | 09/05/2017 | 5          | KBP to BUD Flights | Search for Flights to Budapest | Trip Detail    | Expedia: Payment | KBP         | BUD       |