/*
    Description: This is a simple example of a Terraform Resource Dependencies demo.
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
  content         = random_string.string.id # Implicit Dependencies
}

resource "random_string" "string" {
  length = var.length
  keepers = {
    length = var.length
  }
}

resource "local_file" "fileforpet" {
  content  = <<EOT
                This is a file for pet.
                It also shows explicit dependencies.
                ${random_pet.petdetails.id}
              EOT
  filename = var.filenameforpet
  depends_on = [
    random_pet.petdetails # Explicit Dependencies
  ]
}

resource "random_pet" "petdetails" {
  prefix    = "Mr"
  separator = " . "
  length    = "1"
}


