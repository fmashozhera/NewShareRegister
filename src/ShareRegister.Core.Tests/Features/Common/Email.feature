Feature: Email

Tests the email creation and validation functionality

@common
Scenario Outline: [Create a valid email]
	Given the valid email address "<EmailAddress>"
	When I call Email.Create
	Then i should get an success email result with value "<SuccessEmailValue>"

Examples:
	| EmailAddress         | SuccessEmailValue   |
	| email@domain.com    | email@domain.com    |
	| email@domain.co.zw  | email@domain.co.zw  |
	| email@domain.org.zw | email@domain.org.zw |


Scenario Outline: [Create a invalid email]
	Given the invalid email address "<EmailAddress>"
	When I call Email.Create
	Then i should get a failure email result with message "<EmailErrorMessage>"

Examples:
	| EmailAddress      | EmailErrorMessage     | 
	| emaildomain.co.zw | Invalid email format. | 
	| email@domainorgzw | Invalid email format. | 


Scenario: [Create an empty email]
	Given an empty email address
	When I call Email.Create
	Then i should get an Email is required error message "Email is required."
