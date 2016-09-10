Feature: Basket
	In order buy products
	As a customer
	I want to be able to populate a basket
	And retrieve a total cost

Background: 
	Given I have the following prices
	| Name   | Price |
	| Bread  | 100   |
	| Butter | 80    |
	| Milk   | 115   |
	And I have the following discounts
	| Product | Volume | Discount |
	| Milk    | 4      | 115      |

Scenario: Sum the price of the basket
	Given The basket has 1 Bread
	And 1 Butter
	And 1 Milk
	When I total the basket
	Then the total should be £2.95

@ignore
Scenario: Basket applies offers
	Given the basket has 2 Butter
	And 2 Bread
	When I total the basket
	Then the total should be £3.10

Scenario: Basket applies discounts
	Given the basket has 4 Milk
	When I total the basket
	Then the total should be £3.45

