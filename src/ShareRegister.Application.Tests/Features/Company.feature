Feature: Company

This feature file is to test all features that affect the feature to create companies

@Companies
Scenario: Create company with valid information
	Given I provide the following information '<CompanyCode>','<Name>','<Isin>','<Street>','<Surburb>','<City>','<Country>','<PostalCode>','<Email>'	
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |	
	When I create a company
	Then I should get a success Company result with

Examples:
	| CompanyCode | Name                | ISIN   | Street | Surburb  | City   | Country  | PostalCode | Email            |
	| Mash        | Mashozhera Holdings | 123456 | 6875   | Madokero | Harare | Zimbabwe | 263        | email@domain.com |

Scenario: Create a company with a company code that already exists
	Given I provide the following information with existing company code '<ExistingCompanyCode>','<CompanyCode>','<Name>','<Isin>','<Street>','<Surburb>','<City>','<Country>','<PostalCode>','<Email>'	
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |	
	When I create a company
	Then I should get a failure Company result with error message '<ErrorMessage>'

	Examples:
	| CompanyCode | Name                | ISIN   | Street | Surburb  | City   | Country  | PostalCode | Email            | ErrorMessage                                         |
	| Mash        | Mashozhera Holdings | 123456 | 6875   | Madokero | Harare | Zimbabwe | 263        | email@domain.com | A company with the same company code already exists. |

Scenario: Create a company with a company name that already exists
	Given I provide the following information with existing company name '<CompanyCode>','<Name>','<Isin>','<Street>','<Surburb>','<City>','<Country>','<PostalCode>','<Email>'	
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |	
	When I create a company
	Then I should get a failure Company result with error message '<ErrorMessage>'

	Examples:
	| CompanyCode | Name                | ISIN   | Street | Surburb  | City   | Country  | PostalCode | Email            | ErrorMessage                                         |
	| Mash        | Mashozhera Holdings | 123456 | 6875   | Madokero | Harare | Zimbabwe | 263        | email@domain.com | A company with the same name already exists. |

Scenario: Create a company with a company ISIN that already exists
	Given I provide the following information with existing company ISIN '<CompanyCode>','<Name>','<Isin>','<Street>','<Surburb>','<City>','<Country>','<PostalCode>','<Email>'	
	And the telephone numbers are
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |	
	When I create a company
	Then I should get a failure Company result with error message '<ErrorMessage>'

	Examples:
	| CompanyCode | Name                | ISIN   | Street | Surburb  | City   | Country  | PostalCode | Email            | ErrorMessage                                         |
	| Mash        | Mashozhera Holdings | 123456 | 6875   | Madokero | Harare | Zimbabwe | 263        | email@domain.com | A company with the same ISIN already exists. |