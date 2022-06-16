# eShop `Products` Microservice `API`

Description: To Be Done

## Status Badges

| PR, and CI Builds                                                                                                                                                                                                                  | Code QL                                                                                                                                                                                                                   |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [![Products-Api-CI](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/Products-Api-CI.yml/badge.svg)](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/Products-Api-CI.yml) | [![CodeQL](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/codeql-analysis.yml) |

## Solution Map Diagram

![Solution Map Diagram |150x150](./Documentation/Images/eshop-services-products.PNG)

## Pre-Requisites

> 1. Windows 10 / Ubuntu 20.04 / Mac OS 12.3 (build 21E230)
> 1. Visual Studio 2022
> 1. .NET 6
> 1. VS Code (https://code.visualstudio.com/)
> 1. Docker Desktop (https://docs.docker.com/docker-for-windows/install/)

---

## Links to Documentation

> 1. Please refer [Session1.md](./Documentation/Sessions/Session1.md) for more details.
> 1. Please refer Session 1's [Video](https://www.youtube.com/watch?v=wQ0Xf4pKZaQ) for more details.
> 1. Please refer [Session2.md](./Documentation/Sessions/Session2.md) for more details.
> 1. Please refer Session 2's [Video](https://www.youtube.com/watch?v=R8QIrph-rCI) for more details.
> 1. Please refer [Session3.md](./Documentation/Sessions/Session3.md) for more details.
> 1. Please refer Session 3's [Video](https://www.youtube.com/watch?v=xst1bjb54JM) for more details.
                                      
---

## Session 4

---

## New Features

> 1. [Docker Commands](./Documentation/Sessions/DockerCommandsForMongo.md) for MongoDb Container with Volume Mounts

### 1. [Docker Commands](./Documentation/Sessions/DockerCommandsForMongo.md) for MongoDb Container with Volume Mounts
> 1. Discussion and Demo

**Note:** Path to the Docker Volume Mounts 
[\\wsl$\docker-desktop-data\version-pack-data\community\docker\volumes](\\\\wsl$\docker-desktop-data\version-pack-data\community\docker\volumes)

![Deploy Mongo Db as Container |150x150](./Documentation/Images/S3_Docker_MongoDb_WithVolume.PNG)

## Docker Compose

> 1. Demo and Discussion
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
> 1. `MongoDbSettings__ConnectionString` should come from [`.bashrc`](./Scripts/example.bashrc)

**Example MongoDb Settings**

```
MongoDbSettings__CollectionName = Products
MongoDbSettings__ConnectionString = mongodb+srv://YourUser:YourPassword@YourServer.azure.mongodb.net/proshop?retryWrites=true&w=majority
MongoDbSettings__DatabaseName = ProductsDb
```

**ACI Single Container Using Cli from Docker Hub**
![ACI Single Container Using Cli from Docker Hub |150x150](./Documentation/Images/S3_Docker_to_ACI_using_azcli.PNG)

**Accessing the API from ACI Container**
![ACI Single Container |150x150](./Documentation/Images/S3_ACI_Single_Container.PNG)

---

## Deploying `Multi Containers` in **App Service** using **Docker Compose**

[**Docker Compose File**](./Deploy/eshop-products-api-az-webapp.yml)

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
![Deploy Multi Containers To App Services |150x150](./Documentation/Images/S3_DeployToAppServicesMultiContainer.PNG)

**Access API From App Services Multi Container**
![Access API From App Services Multi Container |150x150](./Documentation/Images/S3_AccessAPIFromAppServicesMultiContainer.PNG)

---

## Deploying `Multi Containers` in **AKS** using **YML**

> 1. To be done

---

## Verify the Deployments using Postman

> 1. Demo and Discussion

### Verify the end points `locally`

> 1. Demo and Discussion

### Verify the end points from `Azure Container Instances`

> 1. Demo and Discussion

### Verify the end points `Docker Instances from App Service`

> 1. Demo and Discussion

### Verify the end points `Azure Kubernetes Service`

> 1. Demo and Discussion

## Review/Q & A/Panel Discussion

> 1. Discussion

## What is next in `Session 5`?

> 1. Discussion

---

## Session 5

---

## New Features

> 1. Using `Record` for `Product` Dto
> 1. Using `ResponseDto` for sending Unified Response
> 1. Model Validations



## CI with GitHub Actions

> 1. Products-Api-CI

[![Products-Api-CI](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/Products-Api-CI.yml/badge.svg)](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/Products-Api-CI.yml)

## CD with GitHub Actions

> 1. To Be Done

## Deployment

### Container Apps

> 1. GitHub Registry
> 1. Azure Container Apps

---

## Session 6

---

## New Features

> 1. Health Checks
> 1. Versioning
> 1. Unit Testing
> 1. Paging, Filtering, Sorting, and Searching

## Deployment

### Kubernetes

> 1. Azure Container Registry
> 1. Azure Kubernetes Service

---

## Session 6

---

## New Features

> 1. IaC with ARM/Bicep/Terraform
> 1. CI/CD with Azure DevOps/GitHub Actions

## Deployment

### Service Mesh

> 1. Azure Container Registry
> 1. Kubernetes Service Mesh
