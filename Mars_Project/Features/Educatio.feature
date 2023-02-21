Feature: Education


As a Seller I want to Add,Update and Delete Education in my profile
So that people can see my profile who seek for learning skills



@AddEducation	
Scenario Outline: 01_Add Education
When I navigate to Education page and Add education like '<University>', '<Country>', '<Title>','<Degree>' and '<GraduationYear>' to the profile Page.
Then  '<University>', '<Country>', '<Title>','<Degree>' and '<GraduationYear>' should be added to the profile Page successfully.
Examples: 
| University | Country    | Title | Degree | GraduationYear |
| DIU        | Bangladesh | B.Sc  | CSE    | 2007           |

@EditEducation
Scenario Outline:02_Edit Education
When I navigate to the Education tab and edit education like '<University>',and '<Degree>'
Then University and degree should be edited successfully
Examples: 
| University | Degree |
| MIT        | BIS    |

@DeleteEducation
Scenario:03_Delete Education
When I navigte to Education Tab and delete education record
Then Education record should be deleted successfully

