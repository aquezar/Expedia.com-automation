@One Way search
@integration
Feature: One Way search
	In order to book my flight for one way
	As a user
	I want to perform search and proceed to payment after selecting flight

@cheepestTicket
Scenario Outline: Cheepest flight
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
	And I check the departing and arrival airports
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
| from                                       | to                                                | date       | passangers | searchTab          | fromAirport | toAirport |
| London, England, UK (LHR-Heathrow)         | Fiumicino Airport (FCO), Italy                    | 11/10/2017 | 3          | LHR to FCO Flights | LH-         | FCO       |
| Krakow, Poland (KRK-John Paul II - Balice) | Manchester Airport (MAN), England, United Kingdom | 11/22/2017 | 1          | KRK to MAN Flights | KRK         | MAN       |
| New York, NY (JFK-John F. Kennedy Intl.)   | Vancouver, BC, Canada (YVR-Vancouver Intl.)       | 12/03/2017 | 1          | JFK to YVR Flights | JFK         | YVR       |
	
@nonstopFlights
Scenario Outline: Nonstop cheepest flight
	Given I open expedia.com
	And I navigate to Flights
	And I navigate to OneWay
	And I enter Flying from <from>
	And I enter Flying to <to>
	And I enter Departing <date>
	And I choose number of <passangers>
	And I click Search button
	And After <searchTab> opens
	And I select Nonstop checkbox in filters
	And I check that only Nonstop flights are displayed
	And I check correctness of search results by checking <fromAirport> and <toAirport>
	And I check departure date for search results
	And I select cheepest ticket
	And I check the departing and arrival airports
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
| from                                     | to                                          | date       | passangers | searchTab          | fromAirport | toAirport |
| Berlin, Germany (TXL-Tegel)              | Riga, Latvia (RIX-Riga Intl.)               | 12/22/2017 | 1          | TXL to RIX Flights | TXL         | RIX       |
| New York, NY (JFK-John F. Kennedy Intl.) | Vancouver, BC, Canada (YVR-Vancouver Intl.) | 12/03/2017 | 1          | JFK to YVR Flights | JFK         | YVR       |
| London, England, UK (LHR-Heathrow)       | Fiumicino Airport (FCO), Italy              | 11/10/2017 | 3          | LHR to FCO Flights | LHR         | FCO       |
