
$kubernetesResourceGroup="wisco-ipsum" # needs to be unique to your subscription
$acrName='wiscoipsumacr43242' #must conform to the following pattern: '^[a-zA-Z0-9]*$
$aksClusterName='wisco-ipsum-cluster'
$location = 'eastus 2'
$numberOfNodes = 1 # In production, you're going to want to use at least three nodes.

Write-Host "Creating resource group $resourceGroupName"
az group create -l $location -n $kubernetesResourceGroup

Write-Host "Creating the Azure Container Registry"
az acr create --resource-group $kubernetesResourceGroup --name $acrName --sku Standard --location $location

Write-Host "Creating a Service Principal"
$sp= az ad sp create-for-rbac --skip-assignment | ConvertFrom-Json
$appId = $sp.appId
$appPassword = $sp.password

Write-Host "Taking a little nap to let the Service Principal propagate"
Start-Sleep -Seconds 30

Write-Host "Giving the Service Principal the ability to pull images from the registry"
$acrID=az acr show --resource-group $kubernetesResourceGroup --name $acrName --query "id" --output tsv
az role assignment create --assignee $appId --scope $acrID --role acrpull

Write-Host "Building a Kubernetes Cluster"
az aks create `
    --resource-group $kubernetesResourceGroup `
    --name $aksClusterName `
    --node-count $numberOfNodes `
    --service-principal $appId `
    --client-secret $appPassword `
    --generate-ssh-keys `
    --location $location

Write-Host "The resources have been created."