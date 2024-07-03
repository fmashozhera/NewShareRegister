Feature: Bank

Bank creation and management

@tag1
Scenario: Create a bank providing valid information
	Given I enter the following valid bank informtion '<Name>','<BankCode>'
	And the telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I create the bank
	Then I should get a success bank result
Examples:
	| Name              | BankCode |
	| CBZ Bank Zimbabwe | CBZ      |

Scenario: Create a bank providing inadequate information
	Given I enter the following valid bank informtion '<Name>','<BankCode>'
	And the telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I create the bank
	Then I should get a failure result with message '<ErrorMessage>'
Examples:
	| Name              | BankCode | ErrorMessage           |
	|                   | CBZ      | Bank name is required. |
	| CBZ Bank Zimbabwe |          | Bank code is required. |
	                                

Scenario: Create a bank with no address
	Given I enter the following valid bank informtion '<Name>','<BankCode>'
	And the telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	When I create the bank
	Then I should get a failure result with message '<ErrorMessage>'
Examples:
	| Name     | BankCode | ErrorMessage         |
	| CBZ Bank | CBZ      | Address is required. |

	
Scenario: Create a bank with no telephone numbers
	Given I enter the following valid bank informtion '<Name>','<BankCode>'
	And the Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I create the bank
	Then I should get a failure result with message '<ErrorMessage>'
Examples:
	| Name              | BankCode | ErrorMessage                           |
	| CBZ Bank Zimbabwe | CBZ      | Provide at least one telephone number. |


Scenario: Add Bank branch
	Given I have a bank with the following details '<BankName>','<BankCode>'
	And the telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I get the bank
	And I enter the following branch details '<Name>','<BranchCode>'
	When I save the branch
	Then I should get a success result
Examples:
	| Name    | BranchCode | BankName | BankCode |
	| Westend | BIC        | ZB Bank  | ZB       |

Scenario: Add Bank branch without a code or name
	Given I have a bank with the following details '<BankName>','<BankCode>'
	And the telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I get the bank
	And I enter the following branch details '<Name>','<BranchCode>'
	When I save the branch
	Then I should get a failure branch result with message '<ErrorMessage>'
Examples:
	| Name    | BranchCode | BankName | BankCode | ErrorMessage             |
	|         | BIC        | ZB Bank  | ZB       | Branch name is required. |
	| Westend |            | ZB Bank  | ZB       | Branch code is required. |
