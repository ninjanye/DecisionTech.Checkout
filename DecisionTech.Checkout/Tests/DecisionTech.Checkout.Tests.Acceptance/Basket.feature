Feature: Basket
	In order buy products
	As a customer
	I want to be able to populate a basket
	And retrieve a total cost

Scenario: Sum the price of the basket
	Given I have a basket with the following prices
	| Name   | Price |
	| Bread  | 100   |
	| Butter | 80    |
	| Milk   | 115   |
	And The basket has 1 bread, 1 butter, and 1 milk
	When I total the basket
	Then the total should be £2.95


