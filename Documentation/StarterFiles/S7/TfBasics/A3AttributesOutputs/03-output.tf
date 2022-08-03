output "localfileid" {
  value = local_file.file.id
}

output "localfilecontent" {
  value = local_file.file.content
}

output "stringdata" {
  value = random_string.stringdata
}