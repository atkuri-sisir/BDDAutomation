@ProductPurchase
Feature: Home Page

Testing the core functionality of the sauce demo application

Background: 
	Given I am on Logged in using 'loginTestData.csv' file and navigated to Product Page

@productpurchase @UI
@DataSource:../TestData/checkoutDetails.json
Scenario: Verify complete product purchase feature
	When I sort products from low to high price
	And I add a product to cart
	And I click on cart icon
    And I enter '<firstname>' , '<lastname>' and '<pincode>' for delivery
	And I click on continue button
	And I click on finish button
	Then I should be checked out successfully



