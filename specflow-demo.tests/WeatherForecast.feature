Feature: Weather
	In order to prepare the right things for a trip
	As a traveller
	I want to check the weather for next five days 

Scenario: Valid weather forcast for next 5 days
	Given Weather forecast url
	When I request the forecast
	Then the result should be the weather forecast for next 5 days

Examples: 
	| url                                    | days |
	| http://localhost:52422/weatherforecast | 5    |