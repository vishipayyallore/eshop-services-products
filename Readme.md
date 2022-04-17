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

> 1. Please refer [Session 1](./Documentation/Sessions/Session1.md) for more details.
> 1. Please refer [Session 1 Video](https://www.youtube.com/watch?v=wQ0Xf4pKZaQ) for more details.
> 1. Please refer [Session 2](./Documentation/Sessions/Session2.md) for more details.
> 1. Please refer [Session 2 Video](https://www.youtube.com/watch?v=R8QIrph-rCI) for more details.


---

## Session 1

---

## Docker Desktop

> 1. Demo and Discussion

## Mongo Db

> 1. Mongo Atlas
> 1. MongoDB Community Edition
> 1. MongoDB Docker Container
> 1. Mongo GUI Docker Container

## Current Features in Web API

> 1. Layered Architecture
> 1. Strongly typed Configuration
> 1. Swagger
> 1. appsettings.json, and secrets.json
> 1. Repository Pattern
> 1. Dependency Injection (Demo)

## Dockerfile

> 1. Demo and Discussion

## Local Execution Modes using VS 2022

**Note:** Mongo Db in Atlas and Docker Container

> 1. IIS Express
> 1. Kestrel
> 1. Docker
> 1. Docker Compose

![Execute With IIS Express |150x150](./Documentation/Images/ExecuteWithIISExpress.PNG)

![Execute With Kestrel |150x150](./Documentation/Images/ExecuteWithKestrel.PNG)

![Execute With Docker |150x150](./Documentation/Images/ExecuteWithDocker.PNG)

![Products API Docker Logs |150x150](./Documentation/Images/ProductsAPIDockerLogs.PNG)

![Execute With Docker Compose |150x150](./Documentation/Images/ExecuteWithDockerCompose.PNG)

---

## Session 2

---

## New Features

> 1. Configuring the configuration
> 1. Serilog third-party logger provider
> 1. Postman Collection
> 1. Show casing the existing Unit Tests

**Default Logging**
![Default Logging |150x150](./Documentation/Images/S2_DefaultLogging.PNG)

**Serilog Logging**
![Serilog Logging inside Docker Container |150x150](./Documentation/Images/S2_Serilog_Logging.PNG)

**Postman Collection Local**
![Postman Collection Local |150x150](./Documentation/Images/S2_PostmanCollection_Local.PNG)

## Executing the solution in `Mac OS 12.3 (build 21E230)` using VS 2022

> 1. Discussion and Demo

## Executing the solution in `Ubuntu 20.04` using VS Code

> 1. Demo and Discussion

![Executing API In Ubuntu 20.04 Swagger |150x150](./Documentation/Images/S2_Executing_API_In_Ubuntu_Swagger.PNG)


![Executing API In Ubuntu 20.04 |150x150](./Documentation/Images/S2_Executing_API_In_Ubuntu_2004.PNG)

## Shell Scripts

> 1. Demo and Discussion

Please refer the [example.bashrc](./Scripts/example.bashrc) file for the shell script to be executed in the terminal.

```
code ~/.bashrc `Your choice of text editor`
source ~/.bashrc
echo $Environment_Variable_Name
```

## Build And Push Image To Docker Hub

![Build And Push Image To Docker Hub |150x150](./Documentation/Images/S2_BuildAndPushImageToDockerHub.PNG)

## Deploy Single `Azure Container Instance` from Docker Hub Image

**Note:**

> 1. Enable the Network Access for Mongo Db
> 1. `MongoDbSettings__ConnectionString` should come from `.bashrc`

**Example MongoDb Settings**

```
MongoDbSettings__CollectionName = Products
MongoDbSettings__ConnectionString = mongodb://productsdb:27017
MongoDbSettings__DatabaseName = ProductsDb
```

**ACI Single Container Using Cli from Docker Hub**
![ACI Single Container Using Cli from Docker Hub |150x150](./Documentation/Images/S2_Docker_to_ACI_using_azcli.PNG)

**Accessing the API from ACI Container**
![ACI Single Container |150x150](./Documentation/Images/S2_ACI_Single_Container.PNG)

## Creating Azure Container Registry using Azure CLI

> 1. Demo and Discussion

![Creating ACR Using Azure CLI |150x150](./Documentation/Images/S2_Creating_ACR_Using_AzureCLI.PNG)

## Build And Push Image To Azure Container Registry

![Build And Push Image To ACR |150x150](./Documentation/Images/S2_BuildAndPushImageToACR.PNG)

## Deploy Single `Azure Container Instance` from `Azure Container Registry` Image

```
MongoDbSettings__CollectionName = Products
MongoDbSettings__ConnectionString = mongodb://productsdb:27017
MongoDbSettings__DatabaseName = ProductsDb
```

**ACI Single Container Using Cli from ACR**
![ACI Single Container Using Cli from ACR |150x150](./Documentation/Images/S2_ACR_to_ACI_using_azcli.PNG)

**Accessing the API from ACI Container**
![ACI Single Container |150x150](./Documentation/Images/S2_Accessing_ACI.PNG)

## Using Postman to hit the ACI instance. Environments- [ACI 1, ACI 2]

> 1. Demo & Discussion

![Postman Collection ACI |150x150](./Documentation/Images/S2_PostmanCollection_ACI.PNG)

## Review/Q & A/Panel Discussion

> 1. Discussion

## What is next in `Session 3`?

> 1. Discussion

---

## Session 3

---

## New Features

> 1. Docker Commands with Volume Mounts
> 1. DTO
> 1. Auto Mapper

## Docker Compose

> 1. Demo and Discussion
> 1. Docker-Compose.yml
> 1. Docker-Compose.override.yml

## Deployment

### `Multi Containers` in **Container Instances** using **Container Group**

> 1. To Be Done

### `Multi Containers` in **App Service** using **Docker Compose**

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
    image: vishipayyallore/productsapi:latest
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

![Deploy To App Services Multi Container |150x150](./Documentation/Images/DeployToAppServicesMultiContainer.PNG)

---

## Session 4

---

## New Features

> 1. Model Validations
> 1. Health Checks
> 1. Versioning

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

## Session 5

---

## New Features

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
