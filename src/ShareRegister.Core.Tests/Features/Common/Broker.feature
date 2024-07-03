Feature: Broker

Broker management feature

@tag1
Scenario: Create a broker providing valid information
	Given I capture the following broker information '<BrokerCode>','<Name>'
	And the broker telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the broker Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I save the broker information
	Then Then I should get a success broker result

Examples:
	| BrokerCode | Name |
	| CBZ        | CBZ  |

	
Scenario: Create a broker without providing broker name or broker code
	Given I capture the following broker information '<BrokerCode>','<Name>'
	And the broker telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the broker Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I save the broker information
	Then Then I should get a failure broker result with message '<ErrorMessage>'

Examples:
	| BrokerCode | Name | ErrorMessage             |
	|            | CBZ  | Broker code is required. |
	| CBZ        |      | Broker name is required. |

Scenario: Create a broker providing an address
	Given I capture the following broker information '<BrokerCode>','<Name>'
	And the broker telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	When I save the broker information
	Then Then I should get a failure broker result with message '<ErrorMessage>'

Examples:
	| BrokerCode | Name | ErrorMessage                |
	| CBZ        | CBZ  | Broker address is required. |

Scenario: Create a broker providing telephone numbers
	Given I capture the following broker information '<BrokerCode>','<Name>'
	And the broker Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I save the broker information
	Then Then I should get a failure broker result with message '<ErrorMessage>'

Examples:
	| BrokerCode | Name | ErrorMessage                         |
	| CBZ        | CBZ  | Enter at least one telephone number. |

Scenario: Update a broker providing valid information
	Given I have a broker with the following information  '<BrokerCode>','<Name>'
	And the broker telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the broker Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I retrieve the broker information
	And I update the information with the following valid information '<UpdatedBrokerCode>','<UpdatedName>'
	Then I should get a success broker result with the broker information updated to '<UpdatedBrokerCode>','<UpdatedName>'
Examples:
	| BrokerCode | Name | UpdatedBrokerCode | UpdatedName |
	| CBZ        | CBZ  | Updated CBZ       | Updated CBZ |


Scenario: Update a broker providing invalid information
	Given I have a broker with the following information  '<BrokerCode>','<Name>'
	And the broker telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the broker Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I retrieve the broker information
	And I update the information with the following valid information '<UpdatedBrokerCode>','<UpdatedName>'
	Then Then I should get a failure broker result with message '<ErrorMessage>'
Examples:
	| BrokerCode | Name | UpdatedBrokerCode   | UpdatedName | ErrorMessage             |
	| CBZ        | CBZ  |                     | Updated CBZ | Broker code is required. |
	| CBZ        | CBZ  | Updated broker code |             | Broker name is required. |


Scenario: Update a broker without providing address
	Given I have a broker with the following information  '<BrokerCode>','<Name>'
	And the broker telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the broker Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I retrieve the broker information
	And I update the information with the following valid information '<UpdatedBrokerCode>','<UpdatedName>' but do not provide an address
	Then Then I should get a failure broker result with message '<ErrorMessage>'
Examples:
	| BrokerCode | Name | UpdatedBrokerCode   | UpdatedName | ErrorMessage                |
	| CBZ        | CBZ  | Updated broker code | Updated CBZ | Broker address is required. |

Scenario: Update a broker without providing telephone numbers
	Given I have a broker with the following information  '<BrokerCode>','<Name>'
	And the broker telephone numbers
		| TelephoneNumber | TelephoneNumberType |
		| 123456          | Mobile              |
		| 78910           | Landline            |
		| 11111           | VoIP                |
	And the broker Address
		| Field      | Value    |
		| Street     | 6875     |
		| Surburb    | Madokero |
		| City       | Harare   |
		| Country    | Zimbabwe |
		| PostalCode | 263      |
	When I retrieve the broker information
	And I update the information with the following valid information '<UpdatedBrokerCode>','<UpdatedName>' but do not provide telepone numbers
	Then Then I should get a failure broker result with message '<ErrorMessage>'
Examples:
	| BrokerCode | Name | UpdatedBrokerCode   | UpdatedName | ErrorMessage                |
	| CBZ        | CBZ  | Updated broker code | Updated CBZ | Enter at least one telephone number. |
	