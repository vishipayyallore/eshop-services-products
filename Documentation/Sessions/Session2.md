# Session 2

## New Features

> 1. Serilog third-party logger provider
> 1. Postman Collection
> 1. Show casing the existing Unit Tests

**Default Logging**
![Default Logging |150x150](../Images/S2_DefaultLogging.PNG)

**Serilog Logging**
![Serilog Logging inside Docker Container |150x150](../Images/S2_Serilog_Logging.PNG)

**Postman Collection Local**
![Postman Collection Local |150x150](../Images/S2_PostmanCollection_Local.PNG)

## Executing the solution in `Mac OS 12.3 (build 21E230)` using VS 2022

> 1. Discussion and Demo

## Executing the solution in `Ubuntu 20.04` using VS Code

> 1. Demo and Discussion

![Executing API In Ubuntu 20.04 Swagger |150x150](../Images/S2_Executing_API_In_Ubuntu_Swagger.PNG)


![Executing API In Ubuntu 20.04 |150x150](../Images/S2_Executing_API_In_Ubuntu_2004.PNG)

## Shell Scripts

> 1. Demo and Discussion

Please refer the [example.bashrc](./Scripts/example.bashrc) file for the shell script to be executed in the terminal.

```
code ~/.bashrc `Your choice of text editor`
source ~/.bashrc
echo $Environment_Variable_Name
```

## Build And Push Image To Docker Hub

![Build And Push Image To Docker Hub |150x150](../Images/S2_BuildAndPushImageToDockerHub.PNG)

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
![ACI Single Container Using Cli from Docker Hub |150x150](../Images/S2_Docker_to_ACI_using_azcli.PNG)

**Accessing the API from ACI Container**
![ACI Single Container |150x150](../Images/S2_ACI_Single_Container.PNG)

## Creating Azure Container Registry using Azure CLI

> 1. Demo and Discussion

![Creating ACR Using Azure CLI |150x150](../Images/S2_Creating_ACR_Using_AzureCLI.PNG)

## Build And Push Image To Azure Container Registry

![Build And Push Image To ACR |150x150](../Images/S2_BuildAndPushImageToACR.PNG)

## Deploy Single `Azure Container Instance` from `Azure Container Registry` Image

```
MongoDbSettings__CollectionName = Products
MongoDbSettings__ConnectionString = mongodb://productsdb:27017
MongoDbSettings__DatabaseName = ProductsDb
```

**ACI Single Container Using Cli from ACR**
![ACI Single Container Using Cli from ACR |150x150](../Images/S2_ACR_to_ACI_using_azcli.PNG)

**Accessing the API from ACI Container**
![ACI Single Container |150x150](../Images/S2_Accessing_ACI.PNG)

## Using Postman to hit the ACI instance. Environments- [ACI 1, ACI 2]

> 1. Demo & Discussion

![Postman Collection ACI |150x150](../Images/S2_PostmanCollection_ACI.PNG)

## Review/Q & A/Panel Discussion

> 1. Discussion

## What is next in `Session 3`?

> 1. Discussion