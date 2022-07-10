# Session 4

## New Features

> 1. [Docker Commands](./DockerCommandsForMongo.md) for MongoDb Container with Volume Mounts

### 1. [Docker Commands](./DockerCommandsForMongo.md) for MongoDb Container with Volume Mounts

> 1. Discussion and Demo

**Note:** Path to the Docker Volume Mounts \\wsl$\docker-desktop-data\version-pack-data\community\docker\volumes

![Deploy Mongo Db as Container |150x150](../Images/S3/Docker_MongoDb_WithVolume.PNG)

## Docker Compose

> 1. Discussion and Demo
> 1. Docker-Compose.yml
> 1. Docker-Compose.override.yml

**docker-compose.yml**

```yaml
version: "3.4"

services:
    productsdb:
        image: mongo

    products.api:
        image: ${DOCKER_REGISTRY-}productsapi
        build:
            context: .
            dockerfile: Source/Products.API/Dockerfile

volumes:
    mongo_data:
```

**docker-compose.override.yml**

```yaml
version: "3.4"

services:
    productsdb:
        container_name: productsdb
        restart: always
        ports:
            - "27017:27017"
        volumes:
            - mongo_data:/data/db

    products.api:
        container_name: products.api
        environment:
            - ASPNETCORE_ENVIRONMENT=Development
            - ASPNETCORE_URLS=https://+:443;http://+:80
            - ASPNETCORE_HTTPS_PORT=8001
            - "MongoDbSettings__ConnectionString=mongodb://productsdb:27017"
        depends_on:
            - productsdb
        ports:
            - "8000:80"
            - "8001:443"
        volumes:
            - ${APPDATA}/ASP.NET/Https:/root/.aspnet/https:ro
```

## Deploy Single `Azure Container Instance` from Docker Hub Image

**Note:**

> 1. Enable the Network Access for Mongo Db
> 1. `MongoDbSettings__ConnectionString` should come from [`.bashrc`](../../Scripts/example.bashrc)

**Example MongoDb Settings**

```
MongoDbSettings__CollectionName = Products
MongoDbSettings__ConnectionString = mongodb+srv://YourUser:YourPassword@YourServer.azure.mongodb.net/proshop?retryWrites=true&w=majority
MongoDbSettings__DatabaseName = ProductsDb
```

**ACI Single Container Using Cli from Docker Hub**
![ACI Single Container Using Cli from Docker Hub |150x150](../Images/S3/Docker_to_ACI_using_azcli.PNG)

**Accessing the API from ACI Container**
![ACI Single Container |150x150](../Images/S3/ACI_Single_Container.PNG)

---

## Deploying `Multi Containers` in **App Service** using **Docker Compose**

[**Docker Compose File**](../../Deploy/eshop-products-api-az-webapp.yml)

```
version: '3.4'

services:
  productsdb:
    image: mongo
    container_name: productsdb
    restart: always
    ports:
      - "27017:27017"
    volumes:
      - mongo_data:/data/db

  products.api:
    image: vishipayyallore/eshop-services-products:latest
    container_name: products.api
    environment:
      - "MongoDbSettings__ConnectionString=mongodb://productsdb:27017"
    depends_on:
      - productsdb
    ports:
      - "8000:80"
    volumes:
      - ${APPDATA}/ASP.NET/Https:/root/.aspnet/https:ro

volumes:
  mongo_data:
```

**AppSettings** Under **Configuration** of App Service

```
MongoDbSettings_CollectionName = Products
MongoDbSettings_ConnectionString = mongodb://productsdb:27017
MongoDbSettings_DatabaseName = ProductsDb
```

**Deploy Multi Containers To App Services**
![Deploy Multi Containers To App Services |150x150](../Images/S3/DeployToAppServicesMultiContainer.PNG)

**Access API From App Services Multi Container**
![Access API From App Services Multi Container |150x150](../Images/S3/AccessAPIFromAppServicesMultiContainer.PNG)

---

## What is next in `Session 5`?

> 1. Discussion
