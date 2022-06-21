Feature: User Successful Registration

@smoke
Scenario: User Successful Registration
	#Steps
	Given I input email "eve.holt@reqres.in" and password "pistol"
	When I POST request to register user
	Then Validate that user is successfully registered