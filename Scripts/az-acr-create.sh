#!/bin/bash

RESOURCEGROUPNAME=rg-dnlh-12mar-dev
ACRNAME=acreshopdev

output=$(az acr list -g $RESOURCEGROUPNAME --query "[? name == '$ACRNAME'] | length(@)")
echo $output

if [ $output == 0 ]
then
    echo $ACRNAME" ACR does not exist ... Creating ACR !"

    az acr create --resource-group $RESOURCEGROUPNAME --name $ACRNAME --sku Basic --admin-enabled true

else

    echo $ACRNAME" ACR exist!"    
fi
