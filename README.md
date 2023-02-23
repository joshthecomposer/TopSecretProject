

## To test server function - open localhost:xxxx/user


## To pull in database updates
dotnet-ef database update


## Routes

Login: `/api/employee/login`  
* Expects Email and Password  

Register: `/api/employee/create`  

Punch In/Out: `/api/timeclock/punch`
* Expects EmployeeId and bool PunchType (True = punch in, False = punch out)  

Get One Employee's Latest Punch: `/api/timeclock/punch/{id}/latest`  
* Expects one EmployeeId as a URL Parameter.

Get One Employee's List of Punches: `/api/timeclock/punch/{id}/all`  
* Expects one EmployeeId as a URL Parameter.

Get All Employees with their Punches: `/api/timeclock/punch/all`  
* Accessible by an Admin/HR User.