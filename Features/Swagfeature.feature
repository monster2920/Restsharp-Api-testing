Feature: Swagfeature
	Automate employee webservice using restsharp

@mytag
Scenario:  Get Employees Details
     Given endpoint url is /api/v1/employees/{}
	 And i created a GET request
	 And i pass the url parameter as  17546
	 When i send the request 
	 Then I validated the status code Accepted USandeep

Scenario: Post Employee Details
	Given endpoint url is /api/v1/employee
	And i created a POST request
	And i add the Request body
	| Key           | Value   |
	| id            | 17546 |
	| name          |USandeep |
	| compitency    | string|
	| yearOfJoining | 2021    |
	| id            | 9999|
	| name          |Bunny  |
	| compitency    | gy|
	| yearOfJoining | 2022   |
	| id            | 9998 |
	| name          |chintan  |
	| compitency    | wer|
	| yearOfJoining | 2023   |
	When i send the request
	Then I validated the response statuscode as 'Created'
@put
Scenario: Update the Employee Details
	Given  endpoint url is /api/v1/employees/{id}
    And i created a PUT request
    And i pass the url parameter as 5436
	And i add the Request body
	| compitency | id  | name  | yearOfJoining |
	| wer       |  | puri | 2020        |
	When i send the request
	Then I validated the  response statuscode as 'Accepted'

	Scenario: Delete Employee by id
	
     Given endpoint url is /api/v1/employees/{id}
	 And i created a DELETE request
	 And i pass the url parameter as 0
	 When i send the request 
	 Then I validated the https code Accepted 410
