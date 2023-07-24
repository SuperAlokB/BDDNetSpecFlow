Feature: Setup users

login users to application 
register users 


@tag1
Scenario: login into application
	Given application is open in browser
	When i enter username and password
	And i click on login button
	Then i should be logged into application
