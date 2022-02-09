Feature: GetUser

@smoke
Scenario: Get User
	#Steps
	Given I would like to Get User
	When I send GET request to list the user with id 2
	Then Validate the users details