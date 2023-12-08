Feature: Contact


@tag1
Scenario: Contact Page Details
	Given User will be on Homepage
	When User will click on the contact page
	Then Contact Page will be loaded
	When User will enter '<name>', '<lastname>', '<email>', '<comment>'
	And User will click on the captcha button
	And User will click on submit button
	Then Created login page will be loaded
Examples: 
	| name | lastname | email          | comment          |
	| Kavi | Mohan    | kavi@gmail.com | Hi,Its me Kaviii |