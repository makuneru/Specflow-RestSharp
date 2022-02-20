Feature: ListsUsers

@smoke
Scenario: Lists Users
	#Steps
	Given I would like to list users
	When I send GET request to list the users on page 2
	Then Validate the list users page details
	Then Validate that "Lindsay" "Ferguson" is a valid user 