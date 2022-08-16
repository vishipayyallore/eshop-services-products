# eShop `Products` Microservice `API`

Description: **`To Be Done`**

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

## Links to individual sessions Documentation and its Videos

> 1. Please refer [Session1.md](./Documentation/Sessions/Session1.md) and [Video](https://www.youtube.com/watch?v=wQ0Xf4pKZaQ) for more details.
> 1. Please refer [Session2.md](./Documentation/Sessions/Session2.md) and [Video](https://www.youtube.com/watch?v=R8QIrph-rCI) for more details.
> 1. Please refer [Session3.md](./Documentation/Sessions/Session3.md) and [Video](https://www.youtube.com/watch?v=xst1bjb54JM) for more details.
> 1. Please refer [Session4.md](./Documentation/Sessions/Session4.md) and [Video](https://www.youtube.com/watch?v=G6dPdySKzbs) for more details.
> 1. Please refer [Session5.md](./Documentation/Sessions/Session5.md) and [Video](https://www.youtube.com/watch?v=LPI0VVM24KI) for more details.
> 1. Please refer [Session6.md](./Documentation/Sessions/Session6.md) and [Video](https://www.youtube.com/watch?v=FmMIF6_bGuw) for more details.
> 1. Please refer [Session7.md](./Documentation/Sessions/Session7.md) and [Video](https://www.youtube.com/watch?v=7abmbzh0ckA) for more details.

---

![Information |150x150](./Documentation/Images/Information.PNG)

## Session 8

## What are we going to do today?

> 1. Deploy `S3 Bucket` and Static Web Site to AWS using Terraform (`5 Minutes`)
> 1. Discussion on AKS Infrastructure Terraform Configuration files (`5 Minutes`)
> 1. Discussion on GitHub Actions deploying AKS Infrastructure (`5 Minutes`)
> 1. Create Products.API's docker image and upload it to `Docker Hub` using Shell Scripts (`5 Minutes`)
> 1. Deploy Products Microservice docker image into AKS using Shell Scripts (`5 Minutes`)
> 1. Verify the Deployed `Products` microservice into AKS using Postman (`5 Minutes`)
> 1. Unit Testing (`5 Minutes`)
> 1. Static code Analysis (`5 Minutes`)
> 1. Software Composition (`5 Minutes`)
> 1. Code Review (`5 Minutes`)
> 1. Review/Q & A/Panel Discussion (`5 Minutes`)
> 1. What is next in `Session 9`? (`5 Minutes`)

![Faster Your Seat Belt |150x150](./Documentation/Images/SeatBelt.PNG)

## Deploy `S3 Bucket` and Static Web Site to AWS using Terraform (`5 Minutes`)

> 1. Discussion and Demo
> 1. Cloud Agnostic

![AWS S3 with Static Web Site |150x150](./Documentation/Images/S8/TF_AWS_S3_StaticWebSite.PNG)

## Discussion on AKS Infrastructure Terraform Configuration files (`5 Minutes`)

> 1. Discussion and Demo
> 1. Terraform Logs for Debugging
> 1. Terraform State in Azure
> 1. Terraform State in Terraform Cloud

![Resources creation using Terraform |150x150](./Documentation/Images/S8/Infra_In_Terraform.PNG)

**Terraform Environment Variables**

![Environment Variables |150x150](./Documentation/Images/S8/TF_EnvironmentVariables.PNG)

**Terraform Logs**

![Terraform Logs |150x150](./Documentation/Images/S8/TF_Logs.PNG)

**State in Terraform Cloud**
![State in Terraform Cloud |150x150](./Documentation/Images/S8/StateInTerraformCloud.PNG)

## Discussion on GitHub Actions deploying AKS Infrastructure (`5 Minutes`)

> 1. Discussion and Demo

![GitHub Actions deploying Infrastructure into Azure |150x150](./Documentation/Images/S8/GitHubActions_AKS_Infra.PNG)

## Create Products.API's docker image and upload it to `Docker Hub` using Shell Scripts (`5 Minutes`)

> 1. Discussion and Demo

![Create And Push Image To Docker |150x150](./Documentation/Images/S8/CreateAndPushImageToDocker.PNG)

## Deploy Products Microservice docker image into AKS using Shell Scripts (`5 Minutes`)

> 1. Discussion and Demo

![Deploy Docker Image into AKS using Scripts |150x150](./Documentation/Images/S8/DeployToAKS.PNG)

![eShop Products API inside AKS |150x150](./Documentation/Images/S8/eshop_ProductsAPI_Inside_AKS.PNG)

## Verify the Deployed `Products` microservice into AKS using Postman (`5 Minutes`)

> 1. Discussion and Demo
> 1. CRUD operations using Postman

![Validate Products API inside AKS using Postman |150x150](./Documentation/Images/S8/ValidateProductsAPI_insideAKS.PNG)

## Unit Testing (`5 Minutes`)

> 1. Discussion and Demo
> 1. Test Coverage

![Unit Testing and Code Coverage |150x150](./Documentation/Images/S8/UnitTesting_CodeCoverage.PNG)

## Static code Analysis (`5 Minutes`)

> 1. Discussion and Demo

![Static Code Analysis |150x150](./Documentation/Images/S8/StaticCodeAnalysis.PNG)

![JFrog scans Docker Images |150x150](./Documentation/Images/S8/JFrog_Scan.PNG)

## Software Composition (`5 Minutes`)

> 1. Discussion and Demo

## Code Review (`5 Minutes`)

> 1. Discussion and Demo

## Review/Q & A/Panel Discussion (`5 Minutes`)

> 1. Discussion

---

## What is next in `Session 9`? (`5 Minutes`) on `09-Sep-2022`

> 1. Deploy `S3 Bucket` to AWS using Terraform (`5 Minutes`)
> 1. Discussion on Infrastructure using Terraform (`5 Minutes`)
> 1. Deploy Products Microservice into AKS (`5 Minutes`)
> 1. Verify the Deployments using Postman (`10 Minutes`)
> 1. Unit Testing (`10 Minutes`)
> 1. Static code Analysis (`10 Minutes`)
> 1. Code Review (`5 Minutes`)
> 1. Software Composition (`5 Minutes`)

---

## `****************** WISH LIST ******************`

## New Features

> 1. Using Record for Product Dto
> 1. Using ResponseDto for sending Unified Response
> 1. Model Validations
> 1. Health Checks
> 1. Versioning
> 1. Paging, Filtering, Sorting, and Searching

## Registries

> 1. Azure Container Registry
> 1. GitHub Registry

## DevOps

> 1. CI/CD with Azure DevOps/GitHub Actions

## Deployments

> 1. Deployment into K8s using Docker Image
> 1. Deployment into K8s using ACR
> 1. Deployment into Container Apps
> 1. Kubernetes Service Mesh

## Alerts and Monitoring

> 1. Prometheus
> 1. Grafana

## Security

> 1. Static Analysis
> 1. Vulnerability Scanning
> 1. Supply Chain Security
> 1. Software Composition
> 1. Use Network Security Policies to Restrict Cluster Level Access
> 1. Cluster Hardening - RBAC
> 1. Properly Set Up Ingress Objects with Security Control
> 1. Protect Node Metadata and Endpoints

## Testing

> 1. Unit Testing
> 1. Integration Testing
> 1. Performance Testing

---

## Verify the Deployments using Postman (`10 Minutes`)

> 1. Discussion and Demo

### Verify the end points `locally` (Kestrel, IIS Express, Docker, Docker-Compose, and K8s)

> 1. Discussion and Demo

### Verify the end points from `Azure Container Instances`

> 1. Discussion and Demo

### Verify the end points `Docker Instances from App Service`

> 1. Discussion and Demo

### Verify the end points `Azure Kubernetes Service`

> 1. Discussion and Demo

![Postman Collections for 8 environments |150x150](./Documentation/Images/S5/Postman_Collections.PNG)
