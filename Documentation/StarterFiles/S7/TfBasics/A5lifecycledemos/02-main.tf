/*
    Description: This is a simple example of a Terraform lifecycle demo.
*/

terraform {
  required_version = ">= 1.2.6"
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
  content         = random_string.stringdata.id # Implicit Dependencies
}

resource "random_string" "stringdata" {
  length = var.length
  keepers = {
    length = var.length
  }
  lifecycle {
    create_before_destroy = true
  }
}

resource "local_file" "fileforpet" {
  content  = random_pet.petdetails.id # Implicit Dependencies
  filename = var.filenameforpet
  depends_on = [
    random_pet.petdetails
  ]
}

resource "random_pet" "petdetails" {
  prefix    = "Mr"
  separator = " . "
  length    = "1"
}


