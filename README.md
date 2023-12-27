# clientes
Desenvolvimento de uma aplicação para um teste.

## Comandos para Migrations
-> Dentro do projeto Clientes.Infrastructure: dotnet ef migrations add FirtsMigration -s ../Clientes.API/Clientes.API.csproj -o ./Persistence/Migrations
-> Em seguida: dotnet ef database update -s ../Clientes.API/Clientes.API.csproj

