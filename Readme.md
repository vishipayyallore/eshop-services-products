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

> 1. Please refer [Session1.md](./Documentation/Sessions/Session1.md) and [Video](https://www.youtube.com/watch?v=wQ0Xf4pKZaQ)for more details.
> 1. Please refer [Session2.md](./Documentation/Sessions/Session2.md) and [Video](https://www.youtube.com/watch?v=R8QIrph-rCI) for more details.
> 1. Please refer [Session3.md](./Documentation/Sessions/Session3.md) and [Video](https://www.youtube.com/watch?v=xst1bjb54JM) for more details.
> 1. Please refer [Session4.md](./Documentation/Sessions/Session4.md) and [Video](https://www.youtube.com/watch?v=G6dPdySKzbs) for more details.
> 1. Please refer [Session5.md](./Documentation/Sessions/Session5.md) and [Video](https://www.youtube.com/watch?v=LPI0VVM24KI) for more details.

---

## Session 6

## What are we going to do today?

> 1. Azure Resource Creation - Manual (`3 Minutes`)
> 1. Introduction to PowerShell and Az Module (`3 Minutes`)
> 1. Create a Web App in using .PS1 (`4 Minutes`)
> 1. Introduction to `Azure CLI` (`3 Minutes`)
> 1. Create a Web App in using `Azure CLI` (`4 Minutes`)
> 1. What is IaC? (`3 Minutes`)
> 1. Introduction to ARM (`5 Minutes`)
> 1. Deploy SQL Server, Database using ARM + .PS1 (`5 Minutes`)
> 1. Deplopy App Service, Web App using ARM + AZ CLI .sh (`5 Minutes`)
> 1. Introduction to Terraform (`5 Minutes`)
> 1. Deploy Virtual Network, and AKS using Terraform (`10 Minutes`)
> 1. Review/Q & A/Panel Discussion (`5 Minutes`)
> 1. What is next in `Session 6`? (`5 Minutes`)

![Faster Your Seat Belt |150x150](./Documentation/Images/SeatBelt.PNG)

## Azure Resource Creation - Manual (`3 Minutes`)

> 1. Demo and Discussion

## Introduction to PowerShell and Az Module (`3 Minutes`)

> 1. Demo and Discussion

## Create a Windows & Ubuntu Virtual Machine in using .PS1 (`4 Minutes`)

> 1. Demo and Discussion
> 1. Creating [Windows VM](./Documentation/StarterFiles/S6/CreateVmWindows.ps1)
> 1. Creating [Ubuntu VM](./Documentation/StarterFiles/S6/CreateVmUbuntu.ps1)

**Create a Ubuntu VM**

```PowerShell
# Variables
$SubscriptionName = "Your Subscription Name"
$RGName = "rg-az204-psubuntu-dev-001"
$LocationName = "CentralUS"
$BaseName = "jul2022ubuntu"
$VmName = "vm$($BaseName)"
$VNetName = "vnet$($BaseName)"
$SubNetName = "default"
$NsgName = "nsg$($BaseName)"
$NicName = "nic$($BaseName)"
$PublicDns = "publicdns$($BaseName)$(Get-Random)"
$PortsToOpen = 80, 22
$username = 'demouser'
$password = ConvertTo-SecureString 'ToBeDone' -AsPlainText -Force
$NsgRuleForSsh = "NetworkSecurityGroupRuleForSSH"
$NsgRuleForWeb = "NetworkSecurityGroupRuleForWeb"

# Generate the SHH keys
ssh-keygen -t rsa -b 4096

# Connecting to Subscription
Connect-AzAccount
Set-AzContext -SubscriptionName $SubscriptionName

Get-AzVm

New-AzResourceGroup -Name $RGName -Location $LocationName

$CredentialsForVm = New-Object System.Management.Automation.PSCredential ($username, $password)

##### Create virtual network resources

# Create a subnet configuration
$subnetConfig = New-AzVirtualNetworkSubnetConfig -Name $SubNetName -AddressPrefix 192.168.1.0/24

# Create a virtual network
$vnet = New-AzVirtualNetwork -ResourceGroupName $RGName -Location $LocationName -Name $VNetName `
  -AddressPrefix 192.168.0.0/16 -Subnet $subnetConfig

# Create a public IP address and specify a DNS name
$pip = New-AzPublicIpAddress -ResourceGroupName $RGName -Location $LocationName -AllocationMethod Static `
  -IdleTimeoutInMinutes 4 -Name $PublicDns

##### Network Security Group and traffic rule

# Create an inbound network security group rule for port 22
$nsgRuleSSH = New-AzNetworkSecurityRuleConfig -Name $NsgRuleForSsh -Protocol "Tcp" -Direction "Inbound" -Priority 1000 `
  -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange $PortsToOpen[1] -Access "Allow"

# Create an inbound network security group rule for port 80
$nsgRuleWeb = New-AzNetworkSecurityRuleConfig -Name $NsgRuleForWeb -Protocol "Tcp" -Direction "Inbound" -Priority 1001 `
  -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange $PortsToOpen[0] -Access "Allow"

# Create a network security group
$nsg = New-AzNetworkSecurityGroup -ResourceGroupName $RGName -Location $LocationName -Name $NsgName `
  -SecurityRules $nsgRuleSSH, $nsgRuleWeb

##### Virtual Network Interface card (NIC)
# Create a virtual network card and associate with public IP address and NSG
$nic = New-AzNetworkInterface -Name $NicName -ResourceGroupName $RGName -Location $LocationName `
  -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $pip.Id -NetworkSecurityGroupId $nsg.Id

##### Create a virtual machine

#### Verify the VM Size before working on the next command
##### Get-AzComputeResourceSku | where {$_.Locations -icontains "centralus"}

# Create a virtual machine configuration ##### -DisablePasswordAuthentication
$vmConfig = New-AzVMConfig -VMName $VmName -VMSize "Standard_D1_v2" | `
  Set-AzVMOperatingSystem -Linux -ComputerName $VmName -Credential $CredentialsForVm  | `
  Set-AzVMSourceImage -PublisherName "Canonical" -Offer "UbuntuServer" -Skus "20.04-LTS" -Version "latest" | `
  Add-AzVMNetworkInterface -Id $nic.Id

# Configure the SSH key
# $sshPublicKey = cat C:\Users\YourUser\.ssh\id_rsa.pub ## When On Local Laptop
$sshPublicKey = cat /home/YourUser/.ssh/id_rsa.pub ## When inside Azure Cloud Shell
Add-AzVMSshPublicKey -VM $vmconfig -KeyData $sshPublicKey -Path "/home/demouser/.ssh/authorized_keys"

New-AzVM -ResourceGroupName $RGName -Location $LocationName -VM $vmConfig

Get-AzPublicIpAddress -ResourceGroupName $RGName -Name $PublicDns | Select-Object IpAddress

> ssh -i C:\Users\YourUser\.ssh\id_rsa demouser@VmPublicIpAddress ## From Local Laptop
> ssh -i /home/YourUser/.ssh/id_rsa demouser@VmPublicIpAddress ## From Local Laptop

ssh -i /home/YourUser/.ssh/id_rsa demouser@40.77.1.129


##### Inside the Ubuntu VM
sudo apt-get -y update
sudo apt-get -y install nginx

# visit the URL
http://VmPublicIpAddress
```

## Introduction to PowerShell, Azure CLI (`3 Minutes`)

> 1. Demo and Discussion

## Create a Web App in using Azure CLI (`4 Minutes`)

> 1. Demo and Discussion

## What is IaC? (`3 Minutes`)

> 1. Demo and Discussion
> 1. `Provisioning Tools` Azure Resource Manager (ARM), Terraform (TF), and Cloud Formation (CF)
> 1. Configuration Management, and Server Templating tools

**Reference:** [What is infrastructure as code](https://docs.microsoft.com/en-us/devops/deliver/what-is-infrastructure-as-code)

## Introduction to ARM (`5 Minutes`)

> 1. Demo and Discussion

## Deploy SQL Server, Database using ARM + .PS1 (`5 Minutes`)

> 1. Demo and Discussion

## Deplopy App Service, Web App using ARM + AZ CLI .sh (`5 Minutes`)

> 1. Demo and Discussion

## Introduction to Terraform (`5 Minutes`)

> 1. Demo and Discussion
> 1. Private and Public Clouds. HashiCorp Configuration Language (HCL - Declarative Language)

## Deploy Virtual Network, and AKS using Terraform (`10 Minutes`)

> 1. Demo and Discussion
> 1. Providers - Official, Verified, and Community
> 1. What is Block Configuration?

```
BlockName Provider_ResourceType ResourceName
{
   Arguments
}
```

```
resource "local_file" "hello"{
   filename = "Sample.txt"
   content = "Hello World !!"
}
```

> 1. Few of the Terraform commands

```
terraform init
terraform plan (Review the execution plan)
terraform apply
terraform destroy
terraform show
```

## Review/Q & A/Panel Discussion (`5 Minutes`)

> 1. Discussion

## What is next in `Session 7`? (`5 Minutes`)

> 1. Discussion

---

## `**Wish List**`

## New Features (`10 Minutes`)

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

> 1. IaC with ARM/Bicep/Terraform
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

> 1. Demo and Discussion

### Verify the end points `locally` (Kestrel, IIS Express, Docker, Docker-Compose, and K8s)

> 1. Demo and Discussion

### Verify the end points from `Azure Container Instances`

> 1. Demo and Discussion

### Verify the end points `Docker Instances from App Service`

> 1. Demo and Discussion

### Verify the end points `Azure Kubernetes Service`

> 1. Demo and Discussion

![Postman Collections for 8 environments |150x150](./Documentation/Images/S5/Postman_Collections.PNG)
