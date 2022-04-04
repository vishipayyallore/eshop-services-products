#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to create ACI single instance using docker image from docker registry
# Author: Apaar, and Swamy
# Date: 04-Apr-2022
# Modified: 04-Apr-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

az container create  --resource-group rg-dnlh-12mar-dev --name aci-productsapiv1 \
    --image $DOCKER_USERNAME/productsapi:latest --restart-policy OnFailure \
    --environment-variables 'MongoDbSettings__CollectionName'='Products' 'MongoDbSettings__DatabaseName'='ProductsDb' \
    --secure-environment-variables MongoDbSettings__ConnectionString=$MongoDbSettings__ConnectionString \
    --ip-address Public --dns-name-label productsapiv1
    