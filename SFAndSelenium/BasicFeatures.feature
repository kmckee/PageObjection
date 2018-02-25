Feature: Basic Features
	In order to simplify the Selenium API
	I want elegant syntax for these step definitions.

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
	Then my name is "Kyle"

	@ignore
Scenario: Filling out a form with text fields
	Given I am browsing for an awful valentine
	When I choose to contact someone
	And I enter my information succinctly:
		| Name | Email           | Subject | Message |
		| Kyle | foo@nowhere.com | Hello   | World   |
	Then my name is "Kyle"
