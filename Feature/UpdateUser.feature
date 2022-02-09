Feature: UpdateUser

@smoke
Scenario: Update user
	#Steps
	Given I update name "morpheus" and job "Test Automation Eng"
	When I send PUT request to update user details of id 2
	Then Validate that user is updated