Feature: Basic Features
	In order to simplify the Selenium API
	I want elegant syntax for these step definitions.

Scenario: Navigation and getting/setting form fields
	Given I am browsing for an awful valentine
	When I choose to contact someone
	And I enter my name as "Kyle"
	Then I see a contact form
	And my name is "Kyle"

Scenario: Ons with multiple lines
	Given I am browsing for an awful valentine
	When I choose to contact someone
	And I enter my information:
		| Name | Email           | Subject | Message |
		| Kyle | foo@nowhere.com | Hello   | World   |
	Then my name is "Kyle"

Scenario: Visits with multiple lines
	When I submit the following contact request:
		| Name | Email           | Subject | Message |
		| Kyle | foo@nowhere.com | Hello   | World   |
	Then I see an error: "Failed to send your message."

	@ignore
Scenario: Easier ways to pass tables into forms
	When I enter my information succinctly:
		| Name | Email           | Subject | Message |
		| Kyle | foo@nowhere.com | Hello   | World   |
	Then my name is "Kyle"
