#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to dockerize the application and push it to the Azure Container Registry
# Author: Apaar, and Swamy
# Date: 24-Mar-2022
# Modified: 01-Apr-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

TAG=latest
VERSION_TAG=$(git log -1 --pretty=format:%h)

echo "version tag: $VERSION_TAG"

REPOSITORY=$AZ_ACR_SERVER_NAME/$DOCKER_IMAGE_NAME

az acr login -n $AZ_ACR_SERVER_NAME

docker build -f "./Source/Products.API/Dockerfile" -t $REPOSITORY:$TAG -t $REPOSITORY:$VERSION_TAG .

docker push $REPOSITORY:$TAG
docker push $REPOSITORY:$VERSION_TAG

echo 'PLEASE UPDATE THE ACR PASSWORD IN THE .BASHRC FILE !!'