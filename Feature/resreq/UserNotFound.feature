Feature: UserNotFound

@smoke
Scenario: User Not Found
	#Steps
	Given I would like to test user not found 
	When I send GET request with invalid id 99
	Then Validate that user is not found and has 404 response.