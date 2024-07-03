Feature: TelephoneNumber

Tests the telephone number creation and validation functionality

@common
Scenario Outline: [Create a valid telephone number]
	Given the valid '<TelephoneNumber>' with type '<TelephoneNumberType>'
	When I call TelephoneNumber.Create
	Then i should get a success telephone number result with '<Success>'

Examples:
	| TelephoneNumber | Success | TelephoneNumberType |
	| 1234561245    | true    | Mobile              |
	| +263123456    | true    | Landline            |
	| 0864568964    | true    | VoIP                |


Scenario Outline: [Create a invalid telephone number]
	Given the invalid "<TelephoneNumber>" with type '<TelephoneNumberType>'
	When I call TelephoneNumber.Create
	Then i should get a failure telephone number result with message "<Message>"

Examples:
	| TelephoneNumber | Message                      | TelephoneNumberType |
	|                 | TelephoneNumber is required. | Mobile              |
	| abdc323434      | Invalid telephone number.     | Landline            |
	

