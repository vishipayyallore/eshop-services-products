#!/bin/bash

# RESOURCEGROUPNAME=rg-dnlh-12mar-dev
# ACRNAME=acreshopdev

output=$(az acr list -g $AZ_RESOURCE_GROUP --query "[? name == '$AZ_ACRNAME'] | length(@)")
echo $output

if [ $output == 0 ]
then
    echo $AZ_ACRNAME" ACR does not exist ... Creating ACR !"

    az acr create --resource-group $AZ_RESOURCE_GROUP --name $AZ_ACRNAME --sku Basic --admin-enabled true

else

    echo $AZ_ACRNAME" ACR exist!"    
fi
