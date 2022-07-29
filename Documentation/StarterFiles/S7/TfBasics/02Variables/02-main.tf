/*
    Description: This is a simple example of a Terraform Variables.
*/

terraform {
  required_version = ">= 1.2.5"
  required_providers {

    local = {
      source  = "hashicorp/local"
      version = "2.2.3"
    }

    random = {
      source  = "hashicorp/random"
      version = "3.3.2"
    }

  }
}

provider "local" {
  # Configuration options
}

provider "random" {
  # Configuration options
}

resource "local_file" "file" {
  filename        = var.filename
  file_permission = var.permission
  content         = var.content
}

resource "random_string" "stringdata" {
  length = var.length
  keepers = {
    length = var.length
  }
}

