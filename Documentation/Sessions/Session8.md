# Session 8

## What are we going to do today?

> 1. Deploy S3 Bucket and Static Web Site to AWS using Terraform (5 Minutes)
> 1. Discussion on AKS Infrastructure Terraform Configuration files (5 Minutes)
> 1. Discussion on GitHub Actions deploying AKS Infrastructure (5 Minutes)
> 1. Create Products.API's docker image and upload it to Docker Hub using Shell Scripts (5 Minutes)
> 1. Deploy Products Microservice docker image into AKS using Shell Scripts (5 Minutes)
> 1. Verify the Deployed Products microservice into AKS using Postman (5 Minutes)
> 1. Unit Testing (5 Minutes)
> 1. Static code Analysis (5 Minutes)
> 1. Software Composition Analysis (5 Minutes)
> 1. Code Review (5 Minutes)
> 1. Review/Q & A/Panel Discussion (5 Minutes)
> 1. What is next in Session 9? (5 Minutes)

## Deploy `S3 Bucket` and Static Web Site to AWS using Terraform (`5 Minutes`)

> 1. Discussion and Demo
> 1. Cloud Agnostic

![AWS S3 with Static Web Site |150x150](../Images/S8/TF_AWS_S3_StaticWebSite.PNG)

## Discussion on AKS Infrastructure Terraform Configuration files (`5 Minutes`)

> 1. Discussion and Demo
> 1. Terraform Logs for Debugging
> 1. Terraform State in Azure
> 1. Terraform State in Terraform Cloud

![Resources creation using Terraform |150x150](../Images/S8/Infra_In_Terraform.PNG)

**Terraform Environment Variables**

![Environment Variables |150x150](../Images/S8/TF_EnvironmentVariables.PNG)

**Terraform Logs**

![Terraform Logs |150x150](../Images/S8/TF_Logs.PNG)

**State in Terraform Cloud**
![State in Terraform Cloud |150x150](../Images/S8/StateInTerraformCloud.PNG)

## Discussion on GitHub Actions deploying AKS Infrastructure (`5 Minutes`)

> 1. Discussion and Demo

![GitHub Actions deploying Infrastructure into Azure |150x150](../Images/S8/GitHubActions_AKS_Infra.PNG)

## Create Products.API's docker image and upload it to `Docker Hub` using Shell Scripts (`5 Minutes`)

> 1. Discussion and Demo

![Create And Push Image To Docker |150x150](../Images/S8/CreateAndPushImageToDocker.PNG)

## Deploy Products Microservice docker image into AKS using Shell Scripts (`5 Minutes`)

> 1. Discussion and Demo

![Deploy Docker Image into AKS using Scripts |150x150](../Images/S8/DeployToAKS.PNG)

![eShop Products API inside AKS |150x150](../Images/S8/eshop_ProductsAPI_Inside_AKS.PNG)

## Verify the Deployed `Products` microservice into AKS using Postman (`5 Minutes`)

> 1. Discussion and Demo
> 1. CRUD operations using Postman

![Validate Products API inside AKS using Postman |150x150](../Images/S8/ValidateProductsAPI_insideAKS.PNG)

## Unit Testing (`5 Minutes`)

> 1. Discussion and Demo
> 1. Test Coverage

![Unit Testing and Code Coverage |150x150](../Images/S8/UnitTesting_CodeCoverage.PNG)

## Static code Analysis (`5 Minutes`)

> 1. Discussion and Demo

![Static Code Analysis |150x150](../Images/S8/StaticCodeAnalysis.PNG)

![JFrog scans Docker Images |150x150](../Images/S8/JFrog_Scan.PNG)

## Software Composition Analysis (`5 Minutes`)

> 1. Discussion and Demo

**FOSSA SCA**
![FOSSA SCA |150x150](../Images/S8/FOSSA_SCA.PNG)

## Code Review (`5 Minutes`)

> 1. Discussion and Demo

## Review/Q & A/Panel Discussion (`5 Minutes`)

> 1. Discussion

---

## What is next in `Session 9`? (`5 Minutes`) on `09-Sep-2022`

1. Changes to Terraform `configuration files` for Azure Infrastructure (`10 Minutes`) [^1]
1. Deploying AKS and other Infrastructure using GitHub Actions (`5 Minutes`)
1. Create Products.API's `docker image` and upload it to `Docker Hub` using GitHub Actions (`5 Minutes`)
1. Deploy Products Microservice using `docker image` from Docker Hub into `AKS` using GitHub Actions (`5 Minutes`)
1. CRUD Operations on the Deployed `Products` microservice into AKS using Postman (`5 Minutes`)
1. Hands of Azure Kubernetes Infrastructure using Portal / VS Code Extension (`10 Minutes`)
    - Using `Portal`
    - Using `VS Code Extension`
1. Hands of Azure Kubernetes Infrastructure using Imperative way (`10 Minutes`)
    - kubectl get nodes | pods | service | deployments
1. Review/Q & A/Panel Discussion (`5 Minutes`)
1. What is next in `Session 9`? (`5 Minutes`)
