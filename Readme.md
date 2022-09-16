# eShop `Products` Microservice `API`

Description: **`To Be Done`**

## Status Badges

| PR, and CI Builds                                                                                                                                                                                                                  | Code QL                                                                                                                                                                                                                   |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [![Products-Api-CI](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/A5-Main-Products-Api.yml/badge.svg)](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/A5-Main-Products-Api.yml) | [![A6 CodeQL Analysis](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/A6-CodeQL-Analysis.yml/badge.svg)](https://github.com/vishipayyallore/eshop-services-products/actions/workflows/A6-CodeQL-Analysis.yml) |

## Solution Map Diagram

![Solution Map Diagram |150x150](./Documentation/Images/eshop-services-products.PNG)

## Pre-Requisites

> 1. Windows 10 / Ubuntu 20.04 / Mac OS 12.3 (build 21E230)
> 1. Visual Studio 2022
> 1. .NET 6
> 1. VS Code (<https://code.visualstudio.com/>)
> 1. Docker Desktop (<https://docs.docker.com/docker-for-windows/install/>)

---

## Links to individual sessions Documentation and its Videos

> 1. Please refer [Session1.md](./Documentation/Sessions/Session1.md) and [Video](https://www.youtube.com/watch?v=wQ0Xf4pKZaQ) for more details.
> 1. Please refer [Session2.md](./Documentation/Sessions/Session2.md) and [Video](https://www.youtube.com/watch?v=R8QIrph-rCI) for more details.
> 1. Please refer [Session3.md](./Documentation/Sessions/Session3.md) and [Video](https://www.youtube.com/watch?v=xst1bjb54JM) for more details.
> 1. Please refer [Session4.md](./Documentation/Sessions/Session4.md) and [Video](https://www.youtube.com/watch?v=G6dPdySKzbs) for more details.
> 1. Please refer [Session5.md](./Documentation/Sessions/Session5.md) and [Video](https://www.youtube.com/watch?v=LPI0VVM24KI) for more details.
> 1. Please refer [Session6.md](./Documentation/Sessions/Session6.md) and [Video](https://www.youtube.com/watch?v=FmMIF6_bGuw) for more details.
> 1. Please refer [Session7.md](./Documentation/Sessions/Session7.md) and [Video](https://www.youtube.com/watch?v=7abmbzh0ckA) for more details.
> 1. Please refer [Session8.md](./Documentation/Sessions/Session8.md) and [Video](https://www.youtube.com/watch?v=z5hxCeCowFM) for more details.

---

![Information |150x150](./Documentation/Images/Information.PNG)

## Session 9

## What are we going to do today?

> 1. Changes to Terraform `configuration files` for Azure Infrastructure (`10 Minutes`) [^1]
> 1. How GitHub Actions gets access on Azure Resources? (`5 Minutes`)
> 1. Deploying Infrastructure to Azure using GitHub Actions (`5 Minutes`)
> 1. Create Products.API's `docker image` and push it to `Docker Hub` using GitHub Actions (`5 Minutes`)
> 1. Deploy Products Microservice `docker image` from Docker Hub into `AKS` using GitHub Actions (`5 Minutes`)
> 1. CRUD Operations on the Deployed `Products` microservice into AKS using Postman (`5 Minutes`)
> 1. Hands of Azure Kubernetes Infrastructure using Portal / VS Code Extension / Azure Cloud Shell  (`10 Minutes`)
>     - Using `Azure Portal`
>     - Using `VS Code Extension`
>     - Using `Azure Cloud Shell`
> 1. Hands of Azure Kubernetes Infrastructure using Imperative way (`10 Minutes`)
>     - kubectl get nodes | pods | service | deployments
> 1. Review/Q & A/Panel Discussion (`5 Minutes`)
> 1. What is next in `Session 10`? (`5 Minutes`)

### Notes

[^1] Discuss coupling of Gate/CI/Release Build with Terraform Configuration for Source Code Repository Agnostic Deployment/Pattern

![Faster Your Seat Belt |150x150](./Documentation/Images/SeatBelt.PNG)

## 1. Changes to Terraform `configuration files` for Azure Infrastructure (`10 Minutes`)

> 1. Discussion and Demo

![Terraform Configuration Files |150x150](./Documentation/Images/S9/TF_ConfigurationFiles.PNG)

## 2. How GitHub Actions gets access on Azure Resources? (`5 Minutes`)

> 1. Discussion and Demo

### App Service In Azure

![App Service In Azure |150x150](./Documentation/Images/S9/AppService_In_Azure.PNG)

### GitHub Actions Secrets

![GitHub Actions Secrets |150x150](./Documentation/Images/S9/GitHubActions_Action_Secrets.PNG)

## 3. Deploying Infrastructure to Azure using GitHub Actions (`5 Minutes`)

> 1. Discussion and Demo

### Graph API Permissions for the Service Pricipal

![Graph API Permissions for the Service Pricipal |150x150](./Documentation/Images/S9/GraphAPIPermissions.PNG)

### Azure Resources creation with Terraform using GitHub Actions

![Azure Resources creation using Terraform |150x150](./Documentation/Images/S9/GitHubActions_AKS_Infra.PNG)

## 4. Create Products.API's `docker image` and push it to `Docker Hub` using GitHub Actions (`5 Minutes`)

> 1. Discussion and Demo
> 1. Build And Push Docker Image To Docker Hub
> 1. Products Micro Service Docker Image Docker Hub

### Build And Push Docker Image To Docker Hub

![Build And Push Docker Image To  Docker Hub |150x150](./Documentation/Images/S9/BuildAndPushDockerImageToHub.PNG)

### Products Micro Service Docker Image Docker Hub

![Products Micro Service Docker Image Docker Hub |150x150](./Documentation/Images/S9/DockerImage_DockerHub.PNG)

## 5. Deploy Products Microservice `docker image` from Docker Hub into `AKS` using GitHub Actions (`5 Minutes`)

> 1. Discussion and Demo

### Deployment To AKS For Approval

![Deployment To AKS For Approval |150x150](./Documentation/Images/S9/DeploymentToAKSForApproval.PNG)

### Deployment To AKS

![Deployment To AKS |150x150](./Documentation/Images/S9/DeploymentToAKS.PNG)

### Products Micro Service Docker Image Docker Hub

![Accessing the Products API from AKS |150x150](./Documentation/Images/S9/AccessTheProductsAPIFromK8s.PNG)

## 6. CRUD Operations on the Deployed `Products` microservice into AKS using Postman (`5 Minutes`)

> 1. Discussion and Demo
> 1. CRUD operations using Postman

### Validating the Products API's Endpoints using Postman

![Postman Collections for 8 environments |150x150](./Documentation/Images/S5/Postman_Collections.PNG)

## 7. Hands of Azure Kubernetes Infrastructure using Portal / VS Code Extension / Azure Cloud Shell (`10 Minutes`)

> 1. Discussion and Demo

### Using `Azure Portal`

> 1. Discussion and Demo

### Using `VS Code Extension`

> 1. Discussion and Demo

### Using `Azure Cloud Shell`

> 1. Discussion and Demo

![K8s from Cloud Shell |150x150](./Documentation/Images/S9/K8sFromCloudShell.PNG)

![K8s from Cloud Shell |150x150](./Documentation/Images/S9/K8sFromCloudShell_1.PNG)

## 8. Hands of Azure Kubernetes Infrastructure using Imperative way (`10 Minutes`)

> 1. Discussion and Demo

### kubectl get `nodes`

> 1. Discussion and Demo

### kubectl get `pods`

> 1. Discussion and Demo

### kubectl get `service`

> 1. Discussion and Demo

### kubectl get `deployments`

> 1. Discussion and Demo

## 9. Review/Q & A/Panel Discussion (`5 Minutes`)

> 1. Discussion

## 10. What is next in `Session 10`? (`5 Minutes`) on `14-Oct-2022`

> 1. Discussion on `eShop Main` Project Repository
> 1. Discussion on `eShop Services Products` Project Repository
> 1. Discussion on `How to configure and execute the solution` locally
> 1. Recap of our previous 9 sessions

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
