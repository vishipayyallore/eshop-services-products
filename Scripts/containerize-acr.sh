#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to dockerize the application and push it to the docker registry
# Author: Apaar, and Swamy
# Date: 24-Mar-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

# az acr show -n eshopsolutiondev001 -g rg-dnlh-12mar-dev

TAG=latest
VERSION_TAG=$(git log -1 --pretty=format:%h)

echo "version tag: $VERSION_TAG"

REPOSITORY=$DOCKER_USERNAME/productsapi

docker login

docker build -f "./Source/Products.API/Dockerfile" -t $REPOSITORY:$TAG -t $REPOSITORY:$VERSION_TAG .

docker push $REPOSITORY:$TAG
docker push $REPOSITORY:$VERSION_TAG

# For ACR
# docker tag $REPOSITORY:$TAG acrregistry.azurecr.io/$REPOSITORY:$TAG
# docker push acrregistry.azurecr.io/$REPOSITORY:$TAG
