Feature: Login

This feature provides us to be able to login and check the result

Background: Navigate homepage
Given User navigates to login page

@scopedBinding
Scenario: User should be able to login with valid credentials
	When User enters valid credentials '<userName>' and '<Password>'
	Then User should be able to login

Examples:
	| userName                | Password     |
	| standard_user           | secret_sauce |
	| problem_user            | secret_sauce |
	| performance_glitch_user | secret_sauce |

@scopedBinding
Scenario: User should not be able to login	
	When User enters invalid credentials '<userName>' and '<Password>'
	Then User should not be able to login
	
Examples:
	| userName | Password     |
	| sadsadas | secret_sauce |
	| ffsdawa  | secret_sauce |

@scopedBinding
Scenario: User should not be able to login with locked user
	When User enters invalid credentials 'locked_out_user' and 'secret_sauce'
	Then User should not be able to login with locked user

@scopedBinding
Scenario: After successfull login check the item's names are different for problem user
	When User enters invalid credentials 'problem_user' and 'secret_sauce'
	Then User should be able to see the item names are different from product details

#This test is failed because of 4. image. This image is same with the homepage but there is no product.	
@scopedBinding
Scenario: After successfull login check the item's images are different for problem user
	When User enters invalid credentials 'problem_user' and 'secret_sauce'
	Then User should be able to see the items' images are different from product details

@scopedBinding
Scenario: User should be able to purchase product
	When User enters invalid credentials 'performance_glitch_user' and 'secret_sauce'
	Then User should be able to see the items are same with product details
	When User add a product
	Then User should be able to purchase the product