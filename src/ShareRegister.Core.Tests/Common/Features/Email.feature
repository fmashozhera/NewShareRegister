Feature: Email

Tests the email creation and validation functionality

@common
Scenario Outline: [Create a valid email]
	Given the valid "<Email>"
	When I call Email.Create
	Then i should get an email result with value "<SuccessEmailValue>" and success "<Success>"

Examples:
	| Email               | SuccessEmailValue   | Success |
	| email@domain.com    | email@domain.com    | true    |
	| email@domain.co.zw  | email@domain.co.zw  | true    |
	| email@domain.org.zw | email@domain.org.zw | true    |


Scenario Outline: [Create a invalid email]
	Given the valid "<Email>"
	When I call Email.Create
	Then i should get an email result with message "<EmailErrorMessage>" and success "<Success>"

Examples:
	| Email             | EmailErrorMessage     | Success |
	| emaildomain.co.zw | Invalid email format. | false   |
	| email@domainorgzw | Invalid email format. | false   |


Scenario: [Create an empty email]
	Given an empty email address
	When I call Email.Create
	Then i should get an Email is required error message "Email is required."
