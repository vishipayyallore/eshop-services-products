#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to create Multi Containers inside App Service using docker image from docker registry
# Author: Apaar, and Swamy
# Date: 28-Apr-2022
# Modified: 28-Apr-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

az appservice plan create --name $AZ_APP_SERVICE_PLAN --resource-group $AZ_RESOURCE_GROUP --sku S1 --is-linux

az webapp create --resource-group $AZ_RESOURCE_GROUP --plan $AZ_APP_SERVICE_PLAN --name $AZ_WEB_APP_NAME \
  --multicontainer-config-type compose --multicontainer-config-file ./Deploy/eshop-products-api-web-docker.yml  