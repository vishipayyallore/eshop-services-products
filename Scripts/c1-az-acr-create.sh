#!/bin/bash

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: Script to dockerize the application and push it to the Azure Container Registry
# Author: Appar, Swamy
# Date: 25-Apr-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

output=$(az acr list -g $AZ_RESOURCE_GROUP --query "[? name == '$AZ_ACRNAME'] | length(@)")
echo $output

if [ $output == 0 ]
then
    echo $AZ_ACRNAME" ACR does not exist ... Creating ACR !"

    az acr create --resource-group $AZ_RESOURCE_GROUP --name $AZ_ACRNAME --sku Basic --admin-enabled true

else

    echo $AZ_ACRNAME" ACR exist!"    
fi
