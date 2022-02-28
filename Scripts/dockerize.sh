#!/bin/bash
TAG=latest
VERSION_TAG=$(git log -1 --pretty=format:%h)
DOCKER_USERNAME=YourDockerUsername

REPOSITORY=$DOCKER_USERNAME/productsapi

docker login

docker build -f "./Source/Products.API/Dockerfile" -t $REPOSITORY:$TAG -t $REPOSITORY:$VERSION_TAG .

docker push $REPOSITORY:$TAG
docker push $REPOSITORY:$VERSION_TAG
