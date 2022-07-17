/*
  Description: Terraform Configuration File to create a Resource Group, and a Virtual Network
  Date: 15-Jul-2022
*/

# Terraform/Settings Block
terraform {
  required_version = ">= 1.2.5"

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0"
    }
  }

  backend "azurerm" {
    resource_group_name  = "rg-dnlh-12mar-dev"
    storage_account_name = "sttfstatedhls"
    container_name       = "terraformstate"
    key                  = "azstorage-terraformstate.tfstate"
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

# Random String Resource
resource "random_string" "stroagesuffix" {
  length  = 6
  upper   = false
  special = false
  numeric = false
}

# Create Azure Storage account
resource "azurerm_storage_account" "storage_account" {
  name                = "stdemo${random_string.stroagesuffix.id}"
  resource_group_name = azurerm_resource_group.rgwomdtest002.name

  location                 = "eastus"
  account_tier             = "Standard"
  account_replication_type = "LRS"
  account_kind             = "StorageV2"

  static_website {
    index_document     = "index.html"
    error_404_document = "error.html"
  }

  tags = {
    environment = "Test"
    contact     = "Swamy PKV"
  }
}
