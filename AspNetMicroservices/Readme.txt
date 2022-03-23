Mongo commands
- docker run -d -p 27017:27017 --name shopping-mango mongo -- it is used to run mongo image on local mongo port 27017 we can use different port .
- docker exec -it shopping-mongo /bin/bash
- mongo   -- to enter
- show dbs -- to show databases
- use CatalogDb -- it will create database
- db.createCollection('Products') -- it will create collectioon
- db.Products.insertMany([{},{}]) -- to insert many recods in database 
- db.Products.find({}).pretty() -- to get recods
- db.Products.remove({}) -- to remove a items 
- show database -- to all database
- show collections -- to all collections
- docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d -- to run container using docker compose
- docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down -- to down all containers

self signed certficates
-- dotnet dec-certs https --trust
-- https://github.com/binarythistle/S03E05---Docker-HTTPS-and-ASPNET-Core
-- https://medium.com/@woeterman_94/docker-in-visual-studio-unable-to-configure-https-endpoint-f95727187f5f
- dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\catalogAPI.pfx -p pa55w0rd! -- to create certificate
- dotnet dev-certs https --trust -- just to check its trusted
- <UserSecretsId>ls1-da35d88afa6c49b4865cc30b1b52316a</UserSecretsId> -- added to cproj
-  \Catalog\Catalog.API> dotnet user-secrets set "Kestrel:Certificates:Development:Password" "pa55w0rd!" -- to create secret
- C:\Users\toeng\AppData\Roaming\Microsoft\UserSecrets -- this path where secret is created we prefix with "ls1" 
-  - ASPNETCORE_URLS=https://+:443;http://+:80 -- default change to  - ASPNETCORE_URLS=https://+;http://+
---- https://stackoverflow.com/questions/69105151/net-core-5-docker-compose-manually-from-vscode-does-not-run-the-application -- this line solved my problem related https 

Enable SSL with ASP.NET Core using Nginx and Docker
-- https://blog.tonysneed.com/2019/10/13/enable-ssl-with-asp-net-core-using-nginx-and-docker/