

## To test server function - open localhost:xxxx/user


## To pull in database updates
dotnet-ef database update


## Routes

Login: `/api/employee/login`
* expecting Email and Password
`Returns: 202 Accepted Logged in user sans password`

Register: `/api/employee/create`
`Returns: 201 Created, User object sans Password`