nugets EntityFramework

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.InMemory

docker exec -it WebApiWithDI bash

GET https://localhost:32770/api/TodoItems
GET https://localhost:32770/api/TodoItems/1


Aplicada la metodologia comentada en esta url https://www.learnentityframeworkcore.com/migrations/seeding


docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Altran2019!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest