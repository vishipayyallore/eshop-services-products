/*
  Description: Terraform Configuration File to create a Resource Group
  Date: 11-Jul-2022
*/

# Terraform/Settings Block
terraform {
  required_version = ">= 1.2.6"

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0"
    }
  }

  # backend "azurerm" {
  #   resource_group_name  = "rg-dnlh-12mar-dev"
  #   storage_account_name = "sttfstatedhls"
  #   container_name       = "terraformstate"
  #   key                  = "azrg-terraform.tfstate"
  # }

}

# Provider Block
provider "azurerm" {
  features {
  }
}

# Resource Block - Resource Group
resource "azurerm_resource_group" "rg-womd-test-001" {
  name     = "rg-womd-test-001" // Azure Resource Group Name
  location = "eastus"           // Azure Region

  tags = {
    environment = "test"
    contact     = "Swamy PKV"
  }
}
