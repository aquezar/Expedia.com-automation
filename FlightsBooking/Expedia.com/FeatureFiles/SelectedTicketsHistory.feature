@smoke
Feature: Selected tickets history
	In order to view my recent flights search results
	As a registered user
	I want to view my search history

Scenario Outline: Login, perform search and check history
	Given I open 'http://expedia.com'
	And I click 'Account' button in menu
	And I click 'Sign in' button in menu
	And I enter 'vklovak.test@gmail.com' in 'Email' input field
	And I enter 'password123' in 'Password' input field
	And I click Sign in button
	And I navigate to 'Flights' tab
	And I navigate to 'OneWay' tab
	And I enter <departureAirport> in 'Flying from' field
	And I enter <arrivalAirport> in 'Flying to' field
	And I enter <date> in 'Departing' field 
	And I choose number of <passangers> in Adults dropdown
	And I click Search button
	And After <searchResults> page opens
	And I select 'cheepest' ticket
	And Trip details page opens
	When I click 'My Lists' button in menu
	And I click Recently Viewed button
	And I click on my last selected ticket
	Then Trip details page opens
	And I check 'the departing and arrival airports'
	And I check flight <date>
	And I check 'departure time'
	And I check 'arrival time'
	And I check 'duration of flight'
	And I check 'ticket price'
 
 Examples: 
| departureAirport            | arrivalAirport                | date       | passangers | searchResults      |
| Berlin, Germany (TXL-Tegel) | Riga, Latvia (RIX-Riga Intl.) | 12/22/2017 | 1          | TXL to RIX Flights |