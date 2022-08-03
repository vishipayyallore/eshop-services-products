output "petdetails" {
  value = random_pet.petdetails
}

output "fileforpet" {
  value = local_file.fileforpet.content
}

output "stringdata" {
  value = random_string.stringdata.id
}

output "file" {
  value = local_file.file.content
}
