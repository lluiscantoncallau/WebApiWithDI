nugets EntityFramework

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.InMemory

docker exec -it WebApiWithDI bash

GET https://localhost:32770/api/TodoItems
GET https://localhost:32770/api/TodoItems/1

https://code-maze.com/net-core-web-api-ef-core-code-first/

Comment Environment IF by create migrations

 Update-Database -Verbose -Context WebApiWithDI.TodoContextSqlServer
 Add-Migration WebApiWithDI.TodoContextSqlServer -Context WebApiWithDI.TodoContextSqlServer

 
GET https://localhost:32770/api/TodoItemSqlServers
GET https://localhost:32770/api/TodoItemSqlServers/1

docker run -v -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Altran2019!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest