Feature: Company

Create and manage company objects

@common
Scenario Outline: [Create a valid company]
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	When the Address is
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the email address
		| Email                 |
		| fmashozhera@gmail.com |
	When I create a company
	Then I should get a success Company result with

Examples:
	| CompanyCode | Name                | ISIN   |
	| Mash        | Mashozhera Holdings | 123456 |

Scenario Outline: [Create a invalid company]
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	When the Address is
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the email address
		| Email                 |
		| fmashozhera@gmail.com |
	When I create a with invalid company details
	Then I should get a failure Company result with message '<ErrorMessage>'

Examples:
	| CompanyCode | Name                | ISIN   | ErrorMessage             |
	|             | Mashozhera Holdings | 123456 | CompanyCode is required. |
	| Mash        |                     | 123456 | Name is required.        |
	| Mash        | Mashozhera Holdings |        | ISIN is required.        |

Scenario Outline: [Create a company with no address]
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the email address
		| Email                 |
		| fmashozhera@gmail.com |
	When I create a with company no address
	
	Then I should get a failure Company result with message '<Message>'

Examples:
	| CompanyCode | Name                | ISIN   | Message              |
	| Mash        | Mashozhera Holdings | 123456 | Address is required. |

Scenario Outline: [Create a company with no telephone numbers]
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	When the Address is
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	And the email address
		| Email                 |
		| fmashozhera@gmail.com |
	When I create a with invalid company details with no telephone numbers
	
	Then I should get a failure Company result with message '<Message>'
Examples:
	| CompanyCode | Name                | ISIN   | Message                         |
	| Mash        | Mashozhera Holdings | 123456 | Telephone numbers are required. |

Scenario Outline: [Create a company with no email]
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	When the Address is
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	When I create a company with no email address
	Then I should get a failure Company result with message '<Message>'

Examples:
	| CompanyCode | Name                | ISIN   | Message            |
	| Mash        | Mashozhera Holdings | 123456 | Email is required. |


Scenario Outline: [Update a valid company]
	Given I have a valid company
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	When the Address is
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the email address
		| Email                 |
		| fmashozhera@gmail.com |
	When I update a company
	Then I should get a success Company result with

Examples:
	| CompanyCode | Name                | ISIN   |
	| Mash        | Mashozhera Holdings | 123456 |

Scenario Outline: [Update a invalid company]
	Given I have a valid company
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	When the Address is
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the email address
		| Email                 |
		| fmashozhera@gmail.com |
	When I update a with invalid company details '<CompanyCode>','<Name>','<ISIN>'
	Then I should get a failure Company result with message '<ErrorMessage>'

Examples:
	| CompanyCode | Name                | ISIN   | ErrorMessage             |
	|             | Mashozhera Holdings | 123456 | CompanyCode is required. |
	| Mash        |                     | 123456 | Name is required.        |
	| Mash        | Mashozhera Holdings |        | ISIN is required.        |

Scenario Outline: [Update a company with no address]
	Given I have a valid company
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the email address
		| Email                 |
		| fmashozhera@gmail.com |
	When I update a with company no address
	
	Then I should get a failure Company result with message '<Message>'

Examples:
	| CompanyCode | Name                | ISIN   | Message              |
	| Mash        | Mashozhera Holdings | 123456 | Address is required. |

Scenario Outline: [Update a company with no telephone numbers]
	Given I have a valid company
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	When the Address is
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	And the email address
		| Email                 |
		| fmashozhera@gmail.com |
	When I update a with invalid company details with no telephone numbers
	
	Then I should get a failure Company result with message '<Message>'
Examples:
	| CompanyCode | Name                | ISIN   | Message                         |
	| Mash        | Mashozhera Holdings | 123456 | Telephone numbers are required. |

Scenario Outline: [Update a company with no email]
	Given I have a valid company
	Given I capture the  valid values '<CompanyCode>','<Name>','<ISIN>'
	When the Address is
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	When I update a company with no email address
	Then I should get a failure Company result with message '<Message>'

Examples:
	| CompanyCode | Name                | ISIN   | Message            |
	| Mash        | Mashozhera Holdings | 123456 | Email is required. |