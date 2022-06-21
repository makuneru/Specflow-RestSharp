Feature: User Unsuccessful Registration

@smoke
Scenario: User unsuccessful Registration
	#Steps
	Given I input email "eve.holt@reqres.in"
	When I POST request to send only the email
	Then Validate that user is not registered due to missing password