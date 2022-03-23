#!/bin/bash
TAG=latest
VERSION_TAG=$(git log -1 --pretty=format:%h)
# DOCKER_USERNAME=$1 # 1st Parameter

echo "version tag: $VERSION_TAG"

REPOSITORY=$DOCKER_USERNAME/productsapi

docker login

docker build -f "./Source/Products.API/Dockerfile" -t $REPOSITORY:$TAG -t $REPOSITORY:$VERSION_TAG .

docker push $REPOSITORY:$TAG
docker push $REPOSITORY:$VERSION_TAG

# For ACR
# docker tag $REPOSITORY:$TAG acrregistry.azurecr.io/$REPOSITORY:$TAG
# docker push acrregistry.azurecr.io/$REPOSITORY:$TAG
