#!/bin/bash

RESOURCEGROUPNAME=rg-dnlh-12mar-dev
ACRNAME=acreshopdev

# az acr list -g rg-dnlh-12mar-dev --query '[].name | length(@)

output=$(az acr list -g rg-dnlh-12mar-dev --query '[].name | length(@)')
echo $output

if [ $output == 0 ]
then
    echo $ACRNAME" ACR does not exist ... Creating ACR !"

    az acr create --resource-group $RESOURCEGROUPNAME --name $ACRNAME --sku Basic

else

    echo $ACRNAME" ACR exist!"    
fi
