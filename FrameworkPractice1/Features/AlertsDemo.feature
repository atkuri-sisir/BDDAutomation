Feature: Alerts

Demo of various user interactions via selenium 

@alerts @UI
Scenario: Verify working of simple alerts
	Given I am on alerts page
	When I click on the simple alert button
	And I switch to the alert
	Then I should be able to close the alert

@alerts @UI
Scenario: Verify working of prompt alerts
	Given I am on alerts page
	When I click on the prompt alert button
	And I switch to the alert
	Then I should be able to enter input into the prompt


