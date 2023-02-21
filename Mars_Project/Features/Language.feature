Feature: Language

As a Seller I want to Add,Update and Delete languages in my profile
So that people can see my profile who seek for learning skills

@)01_AddLanguage
Scenario Outline: 01_Add language in my profile
	When I navigate to the language page and add '<Language>' and '<Level>' and click on add button
	Then The record of '<Language>' and '<Level>' should be added successfully.
	Examples: 
	| Language | Level  |
	| Bengoli  | Fluent |

@02_EditLanguage
Scenario Outline: 02_Edit Language in my profile
When I navigate to the language page and Edit'<Language>' and '<Level>' 
Then '<Language>' and '<level>' should be edited successfully
Examples: 
| Language | Level  |
| English  | Basic |

@03_Deletelanguage
Scenario Outline: 03_Delete language in my profile
When I navigate to language page and Delete '<Language>' from profile page
Then The '<Language>' should be deleted successfully
Examples: 
| Language |
| English  |




