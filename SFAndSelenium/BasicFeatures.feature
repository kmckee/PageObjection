Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Contacting someone
	Given I am browsing for an awful valentine
	When I choose to contact someone
	And I enter my name as "Kyle"
	Then I see a contact form
	And my name is "Kyle"

Scenario: Steps with multiple lines
	Given I am browsing for an awful valentine
	When I choose to contact someone
	And I enter my information:
		| Name | Email           | Subject | Message |
		| Kyle | foo@nowhere.com | Hello   | World   |

Scenario: Filling out a form with text fields
	Given I am browsing for an awful valentine
	When I choose to contact someone
	And I enter my information succinctly:
		| Name | Email           | Subject | Message |
		| Kyle | foo@nowhere.com | Hello   | World   |
