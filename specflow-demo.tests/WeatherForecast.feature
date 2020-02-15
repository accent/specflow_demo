Feature: Weather
	In order to prepare the right things for a trip
	As a traveller
	I want to check the weather for next five days 

Scenario: Valid weather forcast for next 5 days
	Given Server URL <baseUrl>
	When I request the GET data from <requestUrl>
	Then the result should be the weather forecast for next <days> days

Examples:
	| baseUrl                | requestUrl      | days |
	| http://localhost:52422 | weatherforecast | 5    |