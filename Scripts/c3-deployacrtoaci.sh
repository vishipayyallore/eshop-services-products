
az container create  --resource-group rg-dnlh-12mar-dev --name aci-productsapiv1 \
    --image vishipayyallore/productsapi:latest --restart-policy OnFailure \
    --secure-environment-variables Value=NoSecret

az container create 
  -n aci-demo-app-with-secure-environmentvariables 
  -g demos 
  --image "acrdemomagic.azurecr.io/aci-demo-app:latest" 
  --registry-username "acrdemomagic" 
  --registry-password "YOUR_ACR_PASSWORD" 
  --secure-environment-variables  AzureStorageAccountConnectionString="YOUR_STORAGE_CONNECTION_STRING"    