
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 
# Description: .bashrc file for exporting environment variables
# Author: Apaar, Robbie, Swamy
# Date: 25-Apr-2022
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # 

# Docker Related 
export DOCKER_USERNAME='YourDockerUsername'
export DOCKER_IMAGE_NAME='eshop-services-products'

# Azure Related
export AZ_RESOURCE_GROUP='rg-eshop-dev-001'

# Azure Container Instances
export AZ_ACI_FROM_DOCKER='aci-productsapi-from-docker'
export AZ_ACI_FROM_ACR='aci-productsapi-from-acr'

# Azure Container Registry
export AZ_ACRNAME='acreshopdev'
export AZ_ACR_USERNAME='acreshopdev'
export AZ_ACR_PASSWORD='ACRsPASSWORD'
export AZ_ACR_SERVER_NAME=$AZ_ACRNAME.azurecr.io

# Azure App Service for Docker Compose
export AZ_APP_SERVICE_PLAN='plan-products-dev-001'
export AZ_WEB_APP_NAME='app-productsapi-dev-001'

# mongo Db
export MongoDbSettings__CollectionName='Products'
export MongoDbSettings__DatabaseName='ProductsDb'
export MongoDbSettings__ConnectionString='mongodb+srv://YourUser:YourPassword@YourServer.azure.mongodb.net/proshop?retryWrites=true&w=majority'
