Feature: DeleteUser

@smoke
Scenario: Delete user
	#Steps
	Given I delete user by id
	When I send delete request to delete user with id 2
	Then Validate that user is deleted