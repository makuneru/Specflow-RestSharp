Feature: User Unsuccessful Login

@smoke
Scenario: User Unsuccessful Login
	#Steps
	Given I input password "cityslicka"
	When I POST request to send using password
	Then Validate that user is not loggedin due to missing Email or username