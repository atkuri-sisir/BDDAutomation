Feature: APITestDemo

Apis are essential building blocks of many softwares today. So,
Api testing plays an essential role in software testing.

@breedapiget
Scenario: Verify the service
	Given I call the api
	Then I should get the response

@booksapiget
Scenario: Verfiy the get service of book store api from demoqa site
	Given I call the books api
	Then I Should get the books response

@booksapipostuser
Scenario: Verify user creation of book store api
	Given I have the user credentials from a json file
	When I post the user credentials to create user
	Then I should get the response that user is created

@booksapigeneratetoken
Scenario: Verify generating auth token of book store api
	Given I have the user credentials from a json file
	When I post the user credentials to generate a token
	Then I should get the token as response

@booksapipostbooks
Scenario: Verify book addition of book store api
	Given I have the user credentials from a json file
	When I post the user credentials to generate a token
	And I post the books data with the authorization token
	Then I should get response as books are added

@booksapideletebooks
Scenario: verify delete books deletion of book store api
	Given I have the user credentials from a json file
	When I post the user credentials to generate a token
	And I delete the specified book data using the authorization token
	Then I should get response as book is deleted



