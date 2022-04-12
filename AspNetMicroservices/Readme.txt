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
- docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up --build -- we doing this when we change e.g basketApi and its already create ,it will update that e.g we made change for discount.grpc
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
Basket.API 
- docker pull redis -- to pull redis image
- docker run -d -p 6379:6379 --name aspnet-redis redis -- to run redis
- docker logs -f aspnet-redis -- to see logs of redis
- docker exec -it aspnet-redis /bin/bash -- to intorrect with redis
-- redis-cli -- to use cli * set key value | get key* -- to interroct with redis
Portainer.io
-- this is used to see all images ,logs container of application by pull and setup portainer
Discount Api
-- add posgress
-- docker pull dpage/pgadmin4 --add pgadmin image in docker compose for postgree managment dashboard
-- discountdatabase is hotname -- to connect with
-- create table Coupon (            -- create from dpage
	Id serial primary key not null,
	ProductName varchar(24) not null,
	Description text,
	Amount decimal 
);
Discount Grpc
-- https://www.dotnetcurry.com/aspnet-core/1514/grpc-asp-net-core-3 -- this link solve https certificate issue
Order.API
-- Login failed for user sa when i configure it throug docker-compose 
-- solved above issue by following -- https://github.com/Microsoft/mssql-docker/issues/283
-- and https://bigdata-etl.com/microsoft-ms-sql-server-ms-docker-docker-compose/
-- and https://stackoverflow.com/questions/39175194/docker-compose-persistent-data-mysql
RabitMq
-- helpull resource -- https://x-team.com/blog/set-up-rabbitmq-with-docker-compose/
-- Rabbitmq doesn't start with docker-compose -- this link help to solve -- https://stackoverflow.com/questions/63116838/rabbitmq-doesnt-start-with-docker-compose
-- rabbitmq managment default password and username is "guest"
-- don't specify host in  yaml file under environment if spcify then mention in url default is / -- https://stackoverflow.com/questions/40957599/how-to-find-rabbitmq-url
-- mass transit have builten retry mechinsim so we don't have to try -- 
Docker important point
-- remember if want reference to another class libray and alread user Container Orchestrator Support then next time use Docker support after deleting docker file
-- docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down -- then next
-- use -- docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up --build -- 