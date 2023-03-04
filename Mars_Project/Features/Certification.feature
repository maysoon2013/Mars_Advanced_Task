Feature: Certification

As a Seller I want to Add,Update and Delete languages in my profile
So that people can see my profile who seek for learning skills


@AddCertification


Scenario Outline:01_Add Certificate
When I navigate to Certification Page and click on Add new and enter '<Certificate>', '<CertifiedFrom>' select year and click on add 
Then The certication should be added successfully 
Examples: 
| Certificate | CertifiedFrom   |
| Tester      | IndustryConnect |

@EditCertification
Scenario Outline:02_Edit Certification
When  I navigate to the Certification tab and Edit '<Certificate>' and '<CertifiedFrom>' and '<year>'in the profile 
Then The '<Certificate>' and '<CertifiedFrom>' and '<year>'should be updated successfully
Examples: 
| Certificate | CertifiedFrom | year |
| selenium    | Udemy         | 2020 |

@DeleteCertification
Scenario: 03_Delete Certification
When I delete Certification from the profile
Then The Certification should be deleted from the profile successfully


