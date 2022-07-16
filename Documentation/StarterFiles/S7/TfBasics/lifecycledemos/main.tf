/*
    Description: This is a simple example of a Terraform lifecycle demo.
*/

terraform {
  required_version = ">= 1.2.4"
  required_providers {
    local = {
      source  = "hashicorp/local"
      version = "2.2.3"
    }
  }
}

provider "local" {
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
  lifecycle {
    create_before_destroy = true
  }
}

