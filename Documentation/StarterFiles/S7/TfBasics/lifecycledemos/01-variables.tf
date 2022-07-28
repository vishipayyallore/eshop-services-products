variable "length" {
  type    = number
  default = 10
}

variable "filename" {
  type    = string
  default = "./data/random_text.txt"
}

variable "filenameforpet" {
  type    = string
  default = "./data/random_pet.txt"
}

variable "content" {
  type    = string
  default = "This file contains a single line of data"
}

variable "permission" {
  type    = number
  default = 0700
}
