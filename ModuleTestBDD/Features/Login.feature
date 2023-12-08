Feature: Login


@tag1
Scenario: Login
	Given User will be on Homepage
	When User click on the Login Page
	Then Login page will be loaded
	When User click on the Test Login Page
	Then Test Login Page will be loaded
	When User will enter '<username>', '<password>'
	And User will click on the submit button
	Then Login is completed
Examples: 
	| username      | password          |
	| student       | Password123       |
	| incorrectUser | Password123       |
	| student       | incorrectPassword |
