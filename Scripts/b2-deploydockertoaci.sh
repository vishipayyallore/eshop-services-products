#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to create ACI single instance using docker image from docker registry
# Author: Apaar, and Swamy
# Date: 04-Apr-2022
# Modified: 04-Apr-2022, 23-Apr-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

az container create --resource-group $AZ_RESOURCE_GROUP --name $AZ_ACI_NAME_DOCKER \
    --image $DOCKER_USERNAME/$DOCKER_IMAGE_NAME:latest --restart-policy OnFailure \
    --environment-variables MongoDbSettings__CollectionName=$MongoDbSettings__CollectionName \
    MongoDbSettings__DatabaseName=$MongoDbSettings__DatabaseName \
    --secure-environment-variables MongoDbSettings__ConnectionString=$MongoDbSettings__ConnectionString \
    --ip-address Public --dns-name-label $AZ_ACI_NAME_DOCKER
    