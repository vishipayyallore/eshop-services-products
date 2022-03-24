#!/bin/bash

output=$(az acr list -g rg-dnlh-12mar-dev --query '[].name')
echo $output

