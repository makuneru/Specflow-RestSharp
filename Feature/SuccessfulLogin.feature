﻿Feature: User Successful Login

@smoke
Scenario: User Successful Login
	#Steps
	Given I would like to login email "eve.holt@reqres.in" and password "cityslicka"
	When I POST request to login using email and password
	Then Validate that user is successfully logged in