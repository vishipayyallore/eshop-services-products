/*
  Description: Terraform Configuration File to create a Resource Group, and a Virtual Network
  Date: 15-Jul-2022
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

  backend "azurerm" {
    resource_group_name  = "rg-dnlh-12mar-dev"
    storage_account_name = "sttfstatedhls"
    container_name       = "terraformstate"
    key                  = "azstorage-terraform.tfstate"
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

#Add index.html to blob storage
resource "azurerm_storage_blob" "index_html" {
  name                   = "index.html"
  storage_account_name   = azurerm_storage_account.storage_account.name
  storage_container_name = "$web"
  type                   = "Block"
  content_type           = "text/html"
  source_content         = "<h1>This is static content coming from the Terraform</h1>"
}


output "static_website_url" {
  value = azurerm_storage_account.storage_account.primary_web_endpoint
}

output "website_details" {
  value = azurerm_storage_account.storage_account.static_website
}
