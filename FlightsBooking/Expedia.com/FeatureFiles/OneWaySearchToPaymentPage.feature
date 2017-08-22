@integration
Feature: One Way search
	In order to book my flight for one way
	As a user
	I want to perform search and proceed to payment after selecting flight

@cheepestTicket
@smoke
Scenario Outline: Cheepest flight
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
	And I check departure date for search results
	And I select 'cheepest' ticket
	And I check 'the departing and arrival airports'
	And I check flight <date>
	And I check 'departure time'
	And I check 'arrival time'
	And I check 'duration of flight'
	And I check 'ticket price'
	When I confirm flight
	Then Payment page opens 
	And I open Flight details
	And I check 'flight' <date> on Payment page
	And I check 'departing' <fromAirport> on Payment page
	And I check 'departure time' on Payment page
	And I check 'arrival' <toAirport> on Payment page
	And I check 'time of arrival' on Payment page
	And I check 'duration of flight' on Payment page
	And I check 'ticket price for each passanger' on Payment page
	And I check 'total price' on Payment page

Examples: 
| departureAirport                           | arrivalAirport                                    | date       | passangers | searchResults      | fromAirport | toAirport |
| London, England, UK (LHR-Heathrow)         | Fiumicino Airport (FCO), Italy                    | 11/10/2017 | 3          | LHR to FCO Flights | LHR         | FCO       |
| Krakow, Poland (KRK-John Paul II - Balice) | Manchester Airport (MAN), England, United Kingdom | 11/22/2017 | 1          | KRK to MAN Flights | KRK         | MAN       |
| New York, NY (JFK-John F. Kennedy Intl.)   | Vancouver, BC, Canada (YVR-Vancouver Intl.)       | 12/03/2017 | 1          | JFK to YVR Flights | JFK         | YVR       |
	
@nonstopFlights
Scenario Outline: Nonstop cheepest flight
	Given I open 'http://expedia.com'
	And I navigate to 'Flights' tab
	And I navigate to 'OneWay' tab
	And I enter <departureAirport> in 'Flying from' field
	And I enter <arrivalAirport> in 'Flying to' field
	And I enter <date> in 'Departing' field 
	And I choose number of <passangers> in Adults dropdown
	And I click Search button
	And After <searchResults> page opens
	And I select 'Nonstop' checkbox in filters
	And I check that only 'Nonstop' flights are displayed
	And I check correctness of search results by checking <fromAirport> and <toAirport>
	And I check departure date for search results
	And I select 'cheepest' ticket
	And I check 'the departing and arrival airports'
	And I check flight <date>
	And I check 'departure time'
	And I check 'arrival time'
	And I check 'duration of flight'
	And I check 'ticket price'
	When I confirm flight
	Then Payment page opens 
	And I open Flight details
	And I check 'flight' <date> on Payment page
	And I check 'departing' <fromAirport> on Payment page
	And I check 'departure time' on Payment page
	And I check 'arrival' <toAirport> on Payment page
	And I check 'time of arrival' on Payment page
	And I check 'duration of flight' on Payment page
	And I check 'ticket price for each passanger' on Payment page
	And I check 'total price' on Payment page

Examples: 
| departureAirport                         | arrivalAirport                              | date       | passangers | searchResults      | fromAirport | toAirport |
| Berlin, Germany (TXL-Tegel)              | Riga, Latvia (RIX-Riga Intl.)               | 12/22/2017 | 1          | TXL to RIX Flights | TXL         | RIX       |
| New York, NY (JFK-John F. Kennedy Intl.) | Vancouver, BC, Canada (YVR-Vancouver Intl.) | 12/03/2017 | 1          | JFK to YVR Flights | JFK         | YVR       |
| London, England, UK (LHR-Heathrow)       | Fiumicino Airport (FCO), Italy              | 11/10/2017 | 3          | LHR to FCO Flights | LHR         | FCO       |


@negative
@smoke
Scenario Outline: Search without Flying to field value
	Given I open 'http://expedia.com'
	And I navigate to 'Flights' tab
	And I navigate to 'OneWay' tab
	And I enter <departureAirport> in 'Flying from' field
	And I leave 'Flying to' field empty
	And I enter <date> in 'Departing' field 
	And I choose number of <passangers> in Adults dropdown
	When I click Search button
	Then Validation message appears
	And message text saying that 'Flying to field is empty'

Examples: 
| departureAirport                         | date       | passangers |
| Berlin, Germany (TXL-Tegel)              | 12/22/2017 | 1          |
| New York, NY (JFK-John F. Kennedy Intl.) | 12/03/2017 | 1          |

@negative
@smoke
Scenario Outline: Search without Flying from field value
	Given I open 'http://expedia.com'
	And I navigate to 'Flights' tab
	And I navigate to 'OneWay' tab
	And I leave 'Flying from' field empty
	And I enter <arrivalAirport> in 'Flying to' field
	And I enter <date> in 'Departing' field 
	And I choose number of <passangers> in Adults dropdown
	When I click Search button
	Then Validation message appears
	And message text saying that 'Flying from field is empty'

Examples: 
| arrivalAirport                           | date       | passangers |
| Berlin, Germany (TXL-Tegel)              | 12/22/2017 | 1          |
| New York, NY (JFK-John F. Kennedy Intl.) | 12/03/2017 | 1          |

