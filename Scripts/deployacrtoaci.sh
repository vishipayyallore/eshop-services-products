
az container create  --resource-group rg-dnlh-12mar-dev --name aci-productsapiv1 \
    --image vishipayyallore/productsapi:latest --restart-policy OnFailure \
    --secure-environment-variables Value=NoSecret
    