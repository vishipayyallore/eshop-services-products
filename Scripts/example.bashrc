# Docker Related 
export DOCKER_USERNAME='YourDockerUsername'
export DOCKER_IMAGE_NAME='eshop-services-products'

# Azure Related
export AZ_RESOURCE_GROUP='rg-womd-dev-001'

# Azure Container Instances
export AZ_ACI_NAME_DOCKER='aci-productsapi-docker'

# Azure Container Registry
export AZ_ACRNAME='acreshopdev'
export AZ_ACR_USERNAME='acreshopdev'
export AZ_ACR_PASSWORD='ACRsPASSWORD'
export AZ_ACR_SERVER_NAME=$AZ_ACRNAME.azurecr.io

# mongo Db
export MongoDbSettings__CollectionName='Products'
export MongoDbSettings__DatabaseName='ProductsDb'
export MongoDbSettings__ConnectionString='mongodb+srv://YourUser:YourPassword@YourServer.azure.mongodb.net/proshop?retryWrites=true&w=majority'
