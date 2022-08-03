variable "filename" {
  type    = string
  default = "./data/hello_world.txt"
}

variable "content" {
  type    = string
  default = "This file contains a single line of data"
}

variable "permission" {
  type    = number
  default = 0700
}

variable "length" {
  type    = number
  default = 10
}
