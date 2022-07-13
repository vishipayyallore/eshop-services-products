/*
  Description: Terraform Configuration File to create a Resource Group, and a Virtual Network
  Date: 11-Jul-2022
*/

# Terraform/Settings Block
terraform {
  required_version = ">= 1.2.4"
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0"
    }
  }
}

# Provider Block
provider "azurerm" {
  features {
  }
}

# Resource Block - Resource Group
resource "azurerm_resource_group" "rgwomdtest002" {
  name     = "rg-womd-test-002" // Azure Resource Group Name
  location = "eastus"           // Azure Region

  tags = {
    environment = "Test"
    contact     = "Swamy PKV"
  }
}

resource "azurerm_network_security_group" "nsgwomdtest002" {
  name                = "nsg-womd-test-002"
  location            = azurerm_resource_group.rgwomdtest002.location
  resource_group_name = azurerm_resource_group.rgwomdtest002.name
}

resource "azurerm_virtual_network" "vnetwomdtest002" {
  name                = "vnet-womd-test-002"
  location            = azurerm_resource_group.rgwomdtest002.location
  resource_group_name = azurerm_resource_group.rgwomdtest002.name
  address_space       = ["10.0.0.0/16"]

  subnet {
    name           = "subnet-frontend"
    address_prefix = "10.0.1.0/24"
  }

  subnet {
    name           = "subnet-datastore"
    address_prefix = "10.0.2.0/24"
    security_group = azurerm_network_security_group.nsgwomdtest002.id
  }

  tags = {
    environment = "Test"
  }
}
