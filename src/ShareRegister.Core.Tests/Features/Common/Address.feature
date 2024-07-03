Feature: Address

Create and manage address objects

@common
Scenario Outline: [Create a valid address]
	Given I capture the  valid values "<street>","<surburb>","<city>","<country>","<postalCode>"
	When I create an address
	Then I should get a success Address result with values "<street>","<surburb>","<city>","<country>","<postalCode>"

Examples:
	| street         | surburb   | city   | country  | postalCode        |
	| 1880 Section 5 | Kambuzuma | Harare | Zimbabwe |                   |
	| 1880 Section 5 | Kambuzuma | Harare | Zimbabwe | Postal code 00263 |

Scenario Outline: [Create a invalid address]
	Given I capture the invalid values "<street>","<surburb>","<city>","<country>","<postalCode>"
	When I create an address
	Then I should get a failure Address result with message "<failureMessage>"

Examples:
	| street         | surburb   | city   | country  | postalCode        | failureMessage       |
	|                | Kambuzuma | Harare | Zimbabwe |                   | Street is required.  |
	| 1880 Section 5 |           | Harare | Zimbabwe | Postal code 00263 | Surburb is required. |
	| 1880 Section 5 | Kambuzuma |        | Zimbabwe |                   | City is required.    |
	| 1880 Section 5 | Kambuzuma | Harare |          | Postal code 00263 | Country is required. |

Scenario Outline: [Update a valid address]
	Given I have a  valid address with values "<street>","<surburb>","<city>","<country>","<postalCode>"
	And I update the address with the following values  "<updatedStreet>","<updatedSurburb>","<updatedCity>","<updatedCountry>","<updatedPostalCode>"
	Then I should get a success Address result with values "<updatedStreet>","<updatedSurburb>","<updatedCity>","<updatedCountry>","<updatedPostalCode>"

Examples:
	| street         | surburb   | city   | country  | postalCode        | updatedStreet          | updatedSurburb    | updatedCity    | updatedCountry   | updatedPostalCode         |
	| 1880 Section 5 | Kambuzuma | Harare | Zimbabwe |                   | Updated 1880 Section 5 | Updated Kambuzuma | Updated Harare | Updated Zimbabwe |                           |
	| 1880 Section 5 | Kambuzuma | Harare | Zimbabwe | Postal code 00263 | Updated Section 5      | Updated Kambuzuma | Updated Harare | Updated Zimbabwe | Updated Postal code 00263 |

Scenario Outline: [Update a invalid address]
	Given I have a  valid address with values "<street>","<surburb>","<city>","<country>","<postalCode>"
	And I update the address with the following values  "<updatedStreet>","<updatedSurburb>","<updatedCity>","<updatedCountry>","<updatedPostalCode>"
	Then I should get a failure Address result with message "<failureMessage>"

Examples:
	| street         | surburb   | city   | country  | postalCode        | updatedStreet  | updatedSurburb | updatedCity | updatedCountry | updatedPostalCode | failureMessage       |
	| 1880 Section 5 | Kambuzuma | Harare | Zimbabwe | Postal code 00263 |                | Kambuzuma      | Harare      | Zimbabwe       |                   | Street is required.  | 
	| 1880 Section 5 | Kambuzuma | Harare | Zimbabwe | Postal code 00263 | 1880 Section 5 |                | Harare      | Zimbabwe       | Postal code 00263 | Surburb is required. | 
	| 1880 Section 5 | Kambuzuma | Harare | Zimbabwe | Postal code 00263 | 1880 Section 5 | Kambuzuma      |             | Zimbabwe       |                   | City is required.    | 
	| 1880 Section 5 | Kambuzuma | Harare | Zimbabwe | Postal code 00263 | 1880 Section 5 | Kambuzuma      | Harare      |                | Postal code 00263 | Country is required. | 