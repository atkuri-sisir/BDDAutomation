@loginFeature
Feature: Login Page

Testing Login functionality is fundamental before checking the actual functionality
of any software. The current feature describes testing login functionality of sauce demo.

Background: 
	Given I am on Login Page

@login @UI
Scenario Outline: Verify login feature_1
	When I enter a valid '<username>' details from corresponding json data
	And I click on the login button
	Then I should be logged in successfully
Examples: 
	| username        |
	| standard_user   |
	| locked_out_user |
	| problem_user    |
	| error_user      |
	| visual_user     |


@login @UI
@DataSource:../TestData/multipleLoginTestData.csv
Scenario: Verify login feature_2
	When I enter user details: '<username>' and '<password>' from the csv file
	And I click on the login button
	Then I should be logged in successfully

