

## To test server function - open localhost:xxxx/user


## To pull in database updates
dotnet-ef database update


## Routes

Login: `/api/employee/login`  
* Expects Email and Password  
`Returns: 202 Accepted Logged in user sans password`  

Register: `/api/employee/create`  
`Returns: 201 Created, User object sans Password`

Punch In/Out: `/api/timeclock/punch`
* Expects EmployeeId and bool PunchType (True = punch in, False = punch out)  

Get One Employee's Latest Punch: `/api/timeclock/punch/latest/{id}`  
* Expects one EmployeeId as a URL Parameter.

Get One Employee's List of Punches `/api/timeclock/punch/all/{id}`  
* Expects one EmployeeId as a URL Parameter.


