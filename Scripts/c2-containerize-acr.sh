#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to dockerize the application and push it to the docker registry
# Author: Apaar, and Swamy
# Date: 24-Mar-2022
# Modified: 01-Apr-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

TAG=latest
VERSION_TAG=$(git log -1 --pretty=format:%h)
SERVER_NAME=acreshopdev.azurecr.io

echo "version tag: $VERSION_TAG"

REPOSITORY=$SERVER_NAME/productsapi

az acr login -n $SERVER_NAME

docker build -f "./Source/Products.API/Dockerfile" -t $REPOSITORY:$TAG -t $REPOSITORY:$VERSION_TAG .

docker push $REPOSITORY:$TAG
docker push $REPOSITORY:$VERSION_TAG

echo 'PLEASE UPDATE THE ACR PASSWORD IN THE .BASHRC FILE !!'