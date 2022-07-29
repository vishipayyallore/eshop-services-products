/*
    Description: This is a simple example of a Terraform Multiple Providers demo.
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
  filename        = "./data/hello_world.txt"
  file_permission = 0700
  content         = "Hello Terraform World !!"
}

resource "random_string" "stringdata" {
  length = 10
  keepers = {
    length = 10
  }
}

