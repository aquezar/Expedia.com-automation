@smoke
Feature: Selected tickets history
	In order to view my recent flights search results
	As a registered user
	I want to view my search history

Scenario Outline: Login, perform search and check history
	Given I open expedia.com
	And I click Account button in menu
	And I click Sign in button in menu
	And I enter my Email <address>
	And I enter my Password <password>
	And I click Sign in
	And I navigate to Flights
	And I navigate to OneWay
	And I enter Flying from <from>
	And I enter Flying to <to>
	And I enter Departing <date>
	And I choose number of <passangers>
	And I click Search button
	And After <searchTab> opens
	And I select cheepest ticket
	And Trip details page opens
	When I click My Lists button in menu
	And I click Recently Viewed button
	And I click on my last selected ticket
	Then Trip details page opens
	And I check the departing and arrival airports
	And I check flight <date>
	And I check departure time
	And I check arrival time
	And I check duration of flight
	And I check tecket price
 
 Examples: 
 | address                | password    | from                        | to                            | date       | passangers | searchTab          |
 | vklovak.test@gmail.com | password123 | Berlin, Germany (TXL-Tegel) | Riga, Latvia (RIX-Riga Intl.) | 12/22/2017 | 1          | TXL to RIX Flights |