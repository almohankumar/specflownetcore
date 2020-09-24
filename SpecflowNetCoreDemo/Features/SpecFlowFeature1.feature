Feature: Search
	Search for a keyword in google

@mytag
Scenario: Perform search in google
	Given I navigate to google page
	And I enter the search key "Hello"
	When I hit search button
	Then I see the results
