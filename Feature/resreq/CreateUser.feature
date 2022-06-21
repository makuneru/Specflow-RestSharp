Feature: Get Interface

@smoke
Scenario: Get Interface
	#Steps
	Given I input name "morpheus" and job "leader"
	When I send create user POST request
	Then Validate that user is created