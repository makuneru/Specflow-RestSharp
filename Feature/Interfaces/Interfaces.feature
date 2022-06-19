Feature: Interfaces

@api
  Scenario: All interfaces
	Given Create Request "interfaces" with "Get" method
	And Execute API request
	Then Returned status code will be "OK"
	And Validate API response content
	
@api
  Scenario: All interfaces in interface group
	Given Create Request "groups/{groupId}/interfaces" with "Get" method
	When Create URL segment for "groupId" with parameter "fa4655cc-4272-41fb-aea3-cd4f8330b720"
	And Execute API request
	Then Returned status code will be "OK"
	And Validate API response content

@api
  Scenario: Interface in interface group
	Given Create Request "groups/{groupId}/interfaces/{interfaceId}" with "Get" method
	When Create URL segment for "groupId" with parameter "fa4655cc-4272-41fb-aea3-cd4f8330b720"
	When Create URL segment for "interfaceId" with parameter "6125a4fb-f02b-41c2-9656-b03defb98906"
	And Execute API request
	Then Returned status code will be "OK"
	And Validate API response content