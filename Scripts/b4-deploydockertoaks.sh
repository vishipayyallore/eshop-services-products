#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to create Multi Containers inside AKS using docker image from docker registry
# Author: Swamy
# Date: 16-Jun-2022
# Modified: 16-Jun-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

kubectl apply -f ./Deploy/eshop-products-api-k8s.yml  