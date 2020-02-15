Feature: Empty

Scenario: Empty returns empty OK
	Given Server URL http://localhost:52422/
	When I request the GET data from Empty
	Then The result should be 200