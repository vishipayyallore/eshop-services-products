#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to create ACI single instance using docker image from docker registry
# Author: Apaar, and Swamy
# Date: 05-Apr-2022
# Modified: 05-Apr-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

ACI_NAME=aci-productsapiv2
ACR_SERVER_NAME=acreshopdev.azurecr.io

az container create  --resource-group rg-dnlh-12mar-dev --name $ACI_NAME \
    --image $ACR_SERVER_NAME/productsapi:latest --restart-policy OnFailure \
    --environment-variables 'MongoDbSettings__CollectionName'='Products' 'MongoDbSettings__DatabaseName'='ProductsDb' \
    --secure-environment-variables MongoDbSettings__ConnectionString=$MongoDbSettings__ConnectionString \
    --ip-address Public --dns-name-label $ACI_NAME \
    --registry-username 'acreshopdev' --registry-password $ACR_PASSWORD
    
# az container create 
#   -n aci-demo-app-with-secure-environmentvariables 
#   -g demos 
#   --image "acrdemomagic.azurecr.io/aci-demo-app:latest" 
#   --registry-username "acrdemomagic" 
#   --registry-password "YOUR_ACR_PASSWORD" 
#   --secure-environment-variables  AzureStorageAccountConnectionString="YOUR_STORAGE_CONNECTION_STRING"    