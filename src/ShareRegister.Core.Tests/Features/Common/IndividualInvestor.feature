Feature: IndividualInvestor

Manage individual investors

@tag1
Scenario: Capture individual investor using valid information
	Given I capture the following individual investor information  '<Title>','<FirstName>','<LastName>','<IdentificationNumber>','<IdentificationType>'
	And the investor address is
		| Street | Surburb  | City   | Country  | PostalCode |
		| 6875   | Madokero | Harare | Zimbabwe | 263        |
	And the investor email address is 
		| Value            |
		| email@domain.com |
	And the investor telephone number is 
		| Value      | TelephoneNumberType |
		| 0727847234 | Mobile              |
	When i save the investor information
	Then I should get a sucess individual investor result

Examples:
	| Title | FirstName | LastName   | IdentificationNumber | IdentificationType | EmailAddress | TelephoneNumber | TelephoneNumberType |
	| Mr    | Fungai    | Mashozhera | 78-23423432K34       | National           |              | 1234566         | Mobile              |