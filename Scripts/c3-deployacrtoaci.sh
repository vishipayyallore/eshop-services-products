#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to create ACI single instance using docker image from docker registry
# Author: Apaar, and Swamy
# Date: 05-Apr-2022
# Modified: 05-Apr-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

# TODO: You should modify the .bashrc file. This is Temporary to showcase the demo
# AZ_ACR_PASSWORD=W0BAgPtC3wcQ0Op+tHwj481U7o51VJ01

az container create  --resource-group $AZ_RESOURCE_GROUP --name $AZ_ACI_FROM_ACR \
    --image $AZ_ACR_SERVER_NAME/$DOCKER_IMAGE_NAME:latest --restart-policy OnFailure \
    --environment-variables MongoDbSettings__CollectionName=$MongoDbSettings__CollectionName \
      MongoDbSettings__DatabaseName=$MongoDbSettings__DatabaseName \
    --secure-environment-variables MongoDbSettings__ConnectionString=$MongoDbSettings__ConnectionString \
    --ip-address Public --dns-name-label $AZ_ACI_FROM_ACR \
    --registry-username $AZ_ACR_USERNAME --registry-password $AZ_ACR_PASSWORD
